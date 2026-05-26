export default function LoadingState() {
    return (
        <div className="rounded-[2rem] border border-slate-200 bg-white p-10 text-center shadow-soft">
            <div className="mx-auto mb-6 h-14 w-14 animate-spin rounded-full border-4 border-slate-200 border-t-primary" />
            <p className="text-lg font-semibold text-slate-950">
                Carregando imóveis
            </p>
            <p className="mt-3 text-sm leading-6 text-slate-600">
                Aguarde enquanto buscamos as melhores opções para você.
            </p>
        </div>
    );
}
