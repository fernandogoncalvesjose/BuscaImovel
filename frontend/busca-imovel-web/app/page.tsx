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
                        <EmptyState message="Nenhum imóvel encontrado com esses filtros." />
                    ) : (
                        <PropertyList properties={visibleProperties} />
                    )}
                </div>
            </section>
        </main>
    );
}
