import { Property } from "@/types/property";
import { formatCurrency } from "@/utils/formatters";

interface ComparisonGridProps {
    property: Property;
}

export default function ComparisonGrid({ property }: ComparisonGridProps) {
    return (
        <div className="rounded-2xl border border-slate-200 bg-white p-4">
            <h4 className="text-sm font-semibold text-slate-900">
                Comparação rápida
            </h4>
            <div className="mt-3 grid grid-cols-2 gap-3 text-sm text-slate-700">
                <div className="rounded-lg bg-slate-50 p-3">
                    <div className="text-xs text-slate-500">Preço</div>
                    <div className="mt-1 font-semibold text-slate-900">
                        {formatCurrency(property.price)}
                    </div>
                </div>
                <div className="rounded-lg bg-slate-50 p-3">
                    <div className="text-xs text-slate-500">Condomínio</div>
                    <div className="mt-1 font-semibold text-slate-900">
                        {formatCurrency(property.condoFee ?? 0)}
                    </div>
                </div>
                <div className="rounded-lg bg-slate-50 p-3">
                    <div className="text-xs text-slate-500">IPTU</div>
                    <div className="mt-1 font-semibold text-slate-900">
                        {formatCurrency(property.iptu ?? 0)}
                    </div>
                </div>
                <div className="rounded-lg bg-slate-50 p-3">
                    <div className="text-xs text-slate-500">Total mensal</div>
                    <div className="mt-1 font-semibold text-slate-900">
                        {formatCurrency(property.totalMonthlyCost)}
                    </div>
                </div>
                <div className="col-span-2 mt-2 rounded-lg bg-slate-50 p-3">
                    <div className="text-xs text-slate-500">Preço por m²</div>
                    <div className="mt-1 font-semibold text-slate-900">
                        {formatCurrency(property.pricePerSquareMeter)}
                    </div>
                </div>
            </div>
        </div>
    );
}
