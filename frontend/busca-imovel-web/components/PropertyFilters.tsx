"use client";

import { PropertyFilter } from "@/types/property";
import Button from "@/components/ui/Button";
import Checkbox from "@/components/ui/Checkbox";
import Input from "@/components/ui/Input";
import Label from "@/components/ui/Label";
import Select from "@/components/ui/Select";

interface PropertyFiltersProps {
    filter: PropertyFilter;
    propertyTypes: string[];
    neighborhoods: string[];
    sources: string[];
    onFilterChange: (filter: PropertyFilter) => void;
}

const transactionOptions = [
    { value: "", label: "Qualquer" },
    { value: "Aluguel", label: "Aluguel" },
    { value: "Compra", label: "Compra" },
];

export default function PropertyFilters({
    filter,
    propertyTypes,
    neighborhoods,
    sources,
    onFilterChange,
}: PropertyFiltersProps) {
    function updateFilter<K extends keyof PropertyFilter>(
        key: K,
        value: PropertyFilter[K],
    ) {
        onFilterChange({ ...filter, [key]: value });
    }

    function resetFilters() {
        onFilterChange({
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
        });
    }

    return (
        <aside className="space-y-6 rounded-[2rem] border border-slate-200 bg-white p-6 shadow-soft">
            <div className="space-y-3">
                <h2 className="text-xl font-semibold text-slate-950">
                    Buscar imóveis
                </h2>
                <p className="text-sm leading-6 text-slate-600">
                    Use filtros inteligentes para encontrar anúncios com
                    rapidez.
                </p>
            </div>

            <div className="space-y-4">
                <div>
                    <Label htmlFor="search">
                        Buscar por bairro ou palavra-chave
                    </Label>
                    <Input
                        id="search"
                        value={filter.query ?? ""}
                        onChange={(event) =>
                            updateFilter("query", event.target.value)
                        }
                        placeholder="Ex: Pinheiros, 2 quartos, cobertura"
                    />
                </div>

                <div>
                    <Label htmlFor="transactionType">Tipo de negociação</Label>
                    <Select
                        id="transactionType"
                        value={filter.transactionType || ""}
                        onChange={(event) =>
                            updateFilter("transactionType", event.target.value)
                        }
                    >
                        {transactionOptions.map((item) => (
                            <option key={item.value} value={item.value}>
                                {item.label}
                            </option>
                        ))}
                    </Select>
                </div>

                <div>
                    <Label htmlFor="propertyType">Tipo de imóvel</Label>
                    <Select
                        id="propertyType"
                        value={filter.propertyType || ""}
                        onChange={(event) =>
                            updateFilter("propertyType", event.target.value)
                        }
                    >
                        <option value="">Qualquer</option>
                        {propertyTypes.map((type) => (
                            <option key={type} value={type}>
                                {type}
                            </option>
                        ))}
                    </Select>
                </div>

                <div>
                    <Label htmlFor="neighborhood">Bairro</Label>
                    <Select
                        id="neighborhood"
                        value={filter.neighborhood || ""}
                        onChange={(event) =>
                            updateFilter("neighborhood", event.target.value)
                        }
                    >
                        <option value="">Qualquer</option>
                        {neighborhoods.map((neighborhood) => (
                            <option key={neighborhood} value={neighborhood}>
                                {neighborhood}
                            </option>
                        ))}
                    </Select>
                </div>

                <div className="grid gap-4 sm:grid-cols-2">
                    <div>
                        <Label htmlFor="minPrice">Preço mínimo</Label>
                        <Input
                            id="minPrice"
                            type="number"
                            value={filter.minPrice ?? ""}
                            onChange={(event) =>
                                updateFilter(
                                    "minPrice",
                                    event.target.value
                                        ? Number(event.target.value)
                                        : undefined,
                                )
                            }
                            placeholder="R$"
                        />
                    </div>
                    <div>
                        <Label htmlFor="maxPrice">Preço máximo</Label>
                        <Input
                            id="maxPrice"
                            type="number"
                            value={filter.maxPrice ?? ""}
                            onChange={(event) =>
                                updateFilter(
                                    "maxPrice",
                                    event.target.value
                                        ? Number(event.target.value)
                                        : undefined,
                                )
                            }
                            placeholder="R$"
                        />
                    </div>
                </div>

                <div className="grid gap-4 sm:grid-cols-2">
                    <div>
                        <Label htmlFor="minBedrooms">Quartos mínimos</Label>
                        <Input
                            id="minBedrooms"
                            type="number"
                            value={filter.minBedrooms ?? ""}
                            onChange={(event) =>
                                updateFilter(
                                    "minBedrooms",
                                    event.target.value
                                        ? Number(event.target.value)
                                        : undefined,
                                )
                            }
                            placeholder="0"
                        />
                    </div>
                    <div>
                        <Label htmlFor="minParkingSpaces">Vagas mínimas</Label>
                        <Input
                            id="minParkingSpaces"
                            type="number"
                            value={filter.minParkingSpaces ?? ""}
                            onChange={(event) =>
                                updateFilter(
                                    "minParkingSpaces",
                                    event.target.value
                                        ? Number(event.target.value)
                                        : undefined,
                                )
                            }
                            placeholder="0"
                        />
                    </div>
                </div>

                <div>
                    <Label htmlFor="minArea">Área mínima (m²)</Label>
                    <Input
                        id="minArea"
                        type="number"
                        value={filter.minArea ?? ""}
                        onChange={(event) =>
                            updateFilter(
                                "minArea",
                                event.target.value
                                    ? Number(event.target.value)
                                    : undefined,
                            )
                        }
                        placeholder="0"
                    />
                </div>

                <div className="grid gap-3 sm:grid-cols-2">
                    <label className="inline-flex items-center gap-3 rounded-3xl border border-slate-200 bg-slate-50 px-4 py-3">
                        <Checkbox
                            checked={Boolean(filter.isPetFriendly)}
                            onChange={(event) =>
                                updateFilter(
                                    "isPetFriendly",
                                    event.target.checked ? true : undefined,
                                )
                            }
                        />
                        <span className="text-sm text-slate-700">
                            Aceita pet
                        </span>
                    </label>
                    <label className="inline-flex items-center gap-3 rounded-3xl border border-slate-200 bg-slate-50 px-4 py-3">
                        <Checkbox
                            checked={Boolean(filter.isFurnished)}
                            onChange={(event) =>
                                updateFilter(
                                    "isFurnished",
                                    event.target.checked ? true : undefined,
                                )
                            }
                        />
                        <span className="text-sm text-slate-700">
                            Mobiliado
                        </span>
                    </label>
                </div>

                <div>
                    <Label htmlFor="sourceName">Fonte do anúncio</Label>
                    <Select
                        id="sourceName"
                        value={filter.sourceName || ""}
                        onChange={(event) =>
                            updateFilter("sourceName", event.target.value)
                        }
                    >
                        <option value="">Qualquer</option>
                        {sources.map((source) => (
                            <option key={source} value={source}>
                                {source}
                            </option>
                        ))}
                    </Select>
                </div>
            </div>

            <Button type="button" className="w-full" onClick={resetFilters}>
                Limpar filtros
            </Button>
        </aside>
    );
}
