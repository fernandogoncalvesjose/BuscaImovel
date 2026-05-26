export default function Header() {
    return (
        <section className="rounded-[2rem] border border-slate-200 bg-white px-6 py-8 shadow-soft sm:px-10">
            <div className="max-w-3xl space-y-4">
                <p className="inline-flex rounded-full bg-emerald-100 px-4 py-1 text-sm font-semibold uppercase tracking-[0.15em] text-emerald-900">
                    Encontre o imóvel ideal
                </p>
                <h1 className="text-4xl font-semibold tracking-tight text-slate-950 sm:text-5xl">
                    Busca Imóvel
                </h1>
                <p className="max-w-xl text-lg leading-8 text-slate-600">
                    Todos os imóveis em um só lugar. Filtre por bairro, tipo de
                    imóvel, preço e preferências para encontrar a opção certa em
                    São Paulo.
                </p>
            </div>
        </section>
    );
}
