interface EmptyStateProps {
    message?: string;
}

export default function EmptyState({
    message = "Nenhum resultado encontrado.",
}: EmptyStateProps) {
    return (
        <div className="rounded-[2rem] border border-slate-200 bg-white p-10 text-center shadow-soft">
            <p className="text-lg font-semibold text-slate-950">
                Sem resultados
            </p>
            <p className="mt-3 text-sm leading-6 text-slate-600">{message}</p>
        </div>
    );
}
