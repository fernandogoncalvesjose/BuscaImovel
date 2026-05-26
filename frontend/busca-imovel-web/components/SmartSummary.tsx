import { Property } from "@/types/property";
import { formatCurrency } from "@/utils/formatters";

interface SmartSummaryProps {
    property: Property;
}

export default function SmartSummary({ property }: SmartSummaryProps) {
    const profile = `${property.area}m², ${property.bedrooms} quartos e ${property.parkingSpaces} vaga${property.parkingSpaces > 1 ? "s" : ""}`;

    const positives: string[] = [];
    if (property.isFurnished) positives.push("mobiliado");
    if (property.isPetFriendly) positives.push("aceita pet");
    if (property.condoFee && property.condoFee < 400)
        positives.push("condomínio baixo");
    if (property.pricePerSquareMeter && property.pricePerSquareMeter < 5000)
        positives.push("bom preço/m²");

    const summary = `Este ${property.propertyType.toLowerCase()} em ${property.neighborhood} possui ${profile}. O custo mensal estimado é de ${formatCurrency(property.totalMonthlyCost)}, considerando aluguel, condomínio e IPTU.`;

    return (
        <div className="rounded-2xl border border-slate-200 bg-slate-50 p-5">
            <h3 className="text-lg font-semibold text-slate-900">
                Resumo inteligente
            </h3>
            <p className="mt-3 text-sm text-slate-700">{summary}</p>
            {positives.length > 0 && (
                <p className="mt-3 text-sm text-slate-700">
                    Principais pontos:{" "}
                    <strong className="text-slate-900">
                        {positives.join(", ")}
                    </strong>
                </p>
            )}
        </div>
    );
}
