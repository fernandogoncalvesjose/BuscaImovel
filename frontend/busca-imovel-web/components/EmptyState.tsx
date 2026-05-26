interface EmptyStateProps {
    message?: string;
    onClear?: () => void;
}

export default function EmptyState({
    message = "Nenhum resultado encontrado.",
    onClear,
}: EmptyStateProps) {
    return (
        <div className="rounded-[2rem] border border-slate-200 bg-white p-10 text-center shadow-soft">
            <p className="text-lg font-semibold text-slate-950">
                Sem resultados
            </p>
            <p className="mt-3 text-sm leading-6 text-slate-600">{message}</p>
            <div className="mt-6 flex justify-center gap-3">
                <button
                    onClick={onClear}
                    className="rounded-3xl border border-slate-200 bg-white px-4 py-2 text-sm font-medium text-slate-700"
                >
                    Limpar filtros
                </button>
            </div>
        </div>
    );
}
