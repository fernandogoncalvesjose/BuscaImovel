"use client";

import { useEffect, useMemo, useState } from "react";
import Header from "@/components/Header";
import PropertyFilters from "@/components/PropertyFilters";
import PropertyList from "@/components/PropertyList";
import LoadingState from "@/components/LoadingState";
import EmptyState from "@/components/EmptyState";
import {
    getNeighborhoods,
    getProperties,
    getSources,
} from "@/services/propertyService";
import { Property, PropertyFilter } from "@/types/property";

const initialFilter: PropertyFilter = {
    query: "",
    transactionType: "",
    propertyType: "",
    neighborhood: "",
    sourceName: "",
    minPrice: undefined,
    maxPrice: undefined,
    minBedrooms: undefined,
    minParkingSpaces: undefined,
    minArea: undefined,
    isPetFriendly: undefined,
    isFurnished: undefined,
};

export default function HomePage() {
    const [filter, setFilter] = useState<PropertyFilter>(initialFilter);
    const [properties, setProperties] = useState<Property[]>([]);
    const [neighborhoods, setNeighborhoods] = useState<string[]>([]);
    const [sources, setSources] = useState<string[]>([]);
    const [propertyTypes, setPropertyTypes] = useState<string[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [sort, setSort] = useState<string>("recent");

    async function loadData(currentFilter: PropertyFilter) {
        setLoading(true);
        setError("");

        try {
            const [items, neighborhoodList, sourceList] = await Promise.all([
                getProperties(currentFilter),
                getNeighborhoods(),
                getSources(),
            ]);

            setProperties(items);
            setNeighborhoods(neighborhoodList);
            setSources(sourceList);
            setPropertyTypes(
                Array.from(
                    new Set(items.map((item) => item.propertyType)),
                ).sort(),
            );
        } catch (err) {
            setError(
                "Não foi possível carregar os imóveis. Tente novamente mais tarde.",
            );
            setProperties([]);
        } finally {
            setLoading(false);
        }
    }

    useEffect(() => {
        loadData(filter);
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [
        filter.query,
        filter.transactionType,
        filter.propertyType,
        filter.neighborhood,
        filter.sourceName,
        filter.minPrice,
        filter.maxPrice,
        filter.minBedrooms,
        filter.minParkingSpaces,
        filter.minArea,
        filter.isPetFriendly,
        filter.isFurnished,
    ]);

    const visibleProperties = useMemo(() => {
        const query = filter.query?.trim().toLowerCase();
        if (!query) {
            return properties;
        }

        return properties.filter((property) => {
            return (
                property.title.toLowerCase().includes(query) ||
                property.description.toLowerCase().includes(query) ||
                property.neighborhood.toLowerCase().includes(query) ||
                property.city.toLowerCase().includes(query)
            );
        });
    }, [filter.query, properties]);

    const medianPricePerM2 = useMemo(() => {
        if (!visibleProperties.length) return undefined;
        const values = visibleProperties
            .map((p) => p.pricePerSquareMeter)
            .sort((a, b) => a - b);
        const mid = Math.floor(values.length / 2);
        return values.length % 2 !== 0
            ? values[mid]
            : (values[mid - 1] + values[mid]) / 2;
    }, [visibleProperties]);

    const sortedProperties = useMemo(() => {
        const list = [...visibleProperties];
        switch (sort) {
            case "priceAsc":
                return list.sort((a, b) => a.price - b.price);
            case "priceDesc":
                return list.sort((a, b) => b.price - a.price);
            case "monthlyAsc":
                return list.sort(
                    (a, b) => a.totalMonthlyCost - b.totalMonthlyCost,
                );
            case "areaDesc":
                return list.sort((a, b) => b.area - a.area);
            case "pricePerM2Asc":
                return list.sort(
                    (a, b) => a.pricePerSquareMeter - b.pricePerSquareMeter,
                );
            case "recent":
            default:
                return list.sort((a, b) => {
                    const da = a.createdAt
                        ? new Date(a.createdAt).getTime()
                        : 0;
                    const db = b.createdAt
                        ? new Date(b.createdAt).getTime()
                        : 0;
                    return db - da;
                });
        }
    }, [visibleProperties, sort]);

    return (
        <main className="mx-auto flex min-h-screen max-w-7xl flex-col gap-8 px-4 py-8 sm:px-6 lg:px-8">
            <Header />
            <section className="grid gap-6 xl:grid-cols-[360px_1fr]">
                <PropertyFilters
                    filter={filter}
                    neighborhoods={neighborhoods}
                    sources={sources}
                    propertyTypes={propertyTypes}
                    onFilterChange={setFilter}
                />
                <div className="space-y-4">
                    <div className="mb-2 flex items-center justify-between gap-4">
                        <div className="text-sm text-slate-600">
                            {sortedProperties.length} imóveis encontrados
                        </div>
                        <div className="flex items-center gap-3">
                            <label className="text-sm text-slate-600">
                                Ordenar por
                            </label>
                            <select
                                value={sort}
                                onChange={(e) => setSort(e.target.value)}
                                className="rounded-3xl border border-slate-200 bg-white px-3 py-2 text-sm"
                            >
                                <option value="recent">Mais recentes</option>
                                <option value="priceAsc">Menor preço</option>
                                <option value="priceDesc">Maior preço</option>
                                <option value="monthlyAsc">
                                    Menor custo mensal
                                </option>
                                <option value="areaDesc">Maior área</option>
                                <option value="pricePerM2Asc">
                                    Menor preço/m²
                                </option>
                            </select>
                        </div>
                    </div>
                    {loading ? (
                        <LoadingState />
                    ) : error ? (
                        <div className="rounded-3xl border border-red-200 bg-red-50 p-6 text-red-900">
                            <strong className="block text-lg font-semibold">
                                Erro
                            </strong>
                            <p className="mt-2 text-sm leading-6">{error}</p>
                        </div>
                    ) : visibleProperties.length === 0 ? (
                        <EmptyState
                            message="Nenhum imóvel encontrado com esses filtros."
                            onClear={() => setFilter(initialFilter)}
                        />
                    ) : (
                        <PropertyList
                            properties={sortedProperties}
                            medianPricePerM2={medianPricePerM2}
                        />
                    )}
                </div>
            </section>
        </main>
    );
}
