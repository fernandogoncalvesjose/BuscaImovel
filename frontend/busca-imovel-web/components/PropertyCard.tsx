import Link from "next/link";
import Badge from "@/components/ui/Badge";
import Card from "@/components/ui/Card";
import { formatCurrency } from "@/utils/formatters";
import { Property } from "@/types/property";

interface PropertyCardProps {
    property: Property;
}

export default function PropertyCard({ property }: PropertyCardProps) {
    return (
        <Card className="overflow-hidden">
            <div className="grid gap-4 sm:grid-cols-[1.2fr_1fr]">
                <div className="relative h-56 overflow-hidden bg-slate-100 sm:h-auto">
                    <img
                        src={
                            property.imageUrl ||
                            "https://images.unsplash.com/photo-1494526585095-c41746248156?auto=format&fit=crop&w=900&q=80"
                        }
                        alt={property.title}
                        className="h-full w-full object-cover"
                    />
                </div>
                <div className="flex flex-col justify-between gap-4 p-5">
                    <div className="space-y-3">
                        <div className="flex flex-wrap items-center gap-2">
                            <Badge>{property.transactionType}</Badge>
                            <Badge>{property.propertyType}</Badge>
                            <Badge>{property.sourceName}</Badge>
                        </div>
                        <div>
                            <h3 className="text-xl font-semibold text-slate-950">
                                {property.title}
                            </h3>
                            <p className="mt-1 text-sm text-slate-500">
                                {property.neighborhood} • {property.city}
                            </p>
                        </div>
                        <div className="grid gap-2 sm:grid-cols-2">
                            <div className="rounded-3xl bg-slate-50 px-4 py-3 text-sm text-slate-700">
                                <span className="block text-xs uppercase tracking-[0.15em] text-slate-400">
                                    Preço
                                </span>
                                <strong className="block mt-1 text-lg text-slate-950">
                                    {formatCurrency(property.price)}
                                </strong>
                            </div>
                            <div className="rounded-3xl bg-slate-50 px-4 py-3 text-sm text-slate-700">
                                <span className="block text-xs uppercase tracking-[0.15em] text-slate-400">
                                    Preço por m²
                                </span>
                                <strong className="block mt-1 text-lg text-slate-950">
                                    {formatCurrency(
                                        property.pricePerSquareMeter,
                                    )}
                                </strong>
                            </div>
                        </div>
                        <div className="grid gap-2 sm:grid-cols-2">
                            <div className="rounded-3xl bg-slate-50 px-4 py-3 text-sm text-slate-600">
                                Condomínio{" "}
                                <span className="font-semibold text-slate-900">
                                    {formatCurrency(property.condoFee ?? 0)}
                                </span>
                            </div>
                            <div className="rounded-3xl bg-slate-50 px-4 py-3 text-sm text-slate-600">
                                IPTU{" "}
                                <span className="font-semibold text-slate-900">
                                    {formatCurrency(property.iptu ?? 0)}
                                </span>
                            </div>
                        </div>
                    </div>

                    <div className="grid gap-3 rounded-3xl border border-slate-200 bg-slate-50 p-4 text-sm text-slate-700 sm:grid-cols-2">
                        <div>
                            <p className="text-slate-500">Área</p>
                            <strong className="text-slate-950">
                                {property.area} m²
                            </strong>
                        </div>
                        <div>
                            <p className="text-slate-500">Quartos</p>
                            <strong className="text-slate-950">
                                {property.bedrooms}
                            </strong>
                        </div>
                        <div>
                            <p className="text-slate-500">Banheiros</p>
                            <strong className="text-slate-950">
                                {property.bathrooms}
                            </strong>
                        </div>
                        <div>
                            <p className="text-slate-500">Vagas</p>
                            <strong className="text-slate-950">
                                {property.parkingSpaces}
                            </strong>
                        </div>
                    </div>

                    <div className="flex flex-col gap-3 sm:flex-row sm:items-center sm:justify-between">
                        <Link
                            href={`/properties/${property.id}`}
                            className="inline-flex items-center justify-center rounded-3xl bg-primary px-4 py-3 text-sm font-semibold text-white transition hover:bg-primaryDark"
                        >
                            Ver detalhes
                        </Link>
                        <span className="text-sm text-slate-500">
                            Total mensal:{" "}
                            <strong className="text-slate-900">
                                {formatCurrency(property.totalMonthlyCost)}
                            </strong>
                        </span>
                    </div>
                </div>
            </div>
        </Card>
    );
}
