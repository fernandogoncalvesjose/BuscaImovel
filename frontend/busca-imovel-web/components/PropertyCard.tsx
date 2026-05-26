import Link from "next/link";
import Badge from "@/components/ui/Badge";
import Card from "@/components/ui/Card";
import ImageWithFallback from "@/components/ImageWithFallback";
import { formatCurrency } from "@/utils/formatters";
import { Property } from "@/types/property";

interface PropertyCardProps {
    property: Property;
    medianPricePerM2?: number;
}

export default function PropertyCard({
    property,
    medianPricePerM2,
}: PropertyCardProps) {
    const badges: string[] = [];

    if (property.isPetFriendly) badges.push("Aceita pet");
    if (property.isFurnished) badges.push("Mobiliado");
    if (property.condoFee && property.condoFee > 0 && property.condoFee < 300)
        badges.push("Baixo condomínio");
    if (medianPricePerM2 && property.pricePerSquareMeter <= medianPricePerM2)
        badges.push("Menor preço/m²");
    // New announcement: within 14 days
    if (property.createdAt) {
        const created = new Date(property.createdAt);
        const days = (Date.now() - created.getTime()) / (1000 * 60 * 60 * 24);
        if (days <= 14) badges.push("Novo anúncio");
    }
    // Simple cost-benefit heuristic
    if (
        property.totalMonthlyCost &&
        property.pricePerSquareMeter &&
        property.pricePerSquareMeter < 5000
    )
        badges.push("Bom custo-benefício");
    return (
        <Card className="overflow-hidden">
            <div className="grid gap-4 sm:grid-cols-[1.2fr_1fr]">
                <div className="relative h-56 overflow-hidden bg-slate-100 sm:h-auto">
                    <ImageWithFallback
                        src={property.imageUrl ?? undefined}
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
                        <div className="mt-2 flex flex-wrap gap-2">
                            {badges.slice(0, 4).map((b) => (
                                <span
                                    key={b}
                                    className="inline-flex items-center rounded-full bg-primary/10 px-3 py-1 text-xs font-semibold text-primary"
                                >
                                    {b}
                                </span>
                            ))}
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
                        <div className="rounded-3xl border border-slate-200 bg-white px-4 py-3 text-sm shadow-sm">
                            <p className="text-xs text-slate-500">
                                Custo mensal estimado
                            </p>
                            <div className="mt-1 flex items-baseline gap-2">
                                <span className="text-2xl font-bold text-slate-900">
                                    {formatCurrency(property.totalMonthlyCost)}
                                </span>
                                <span className="text-sm text-slate-500">
                                    /mês
                                </span>
                            </div>
                            <p className="mt-2 text-xs text-slate-500">
                                Inclui aluguel, condomínio e IPTU
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </Card>
    );
}
