import Link from "next/link";
import { notFound } from "next/navigation";
import { getPropertyById } from "@/services/propertyService";
import { formatCurrency } from "@/utils/formatters";

interface PropertyPageProps {
    params: {
        id: string;
    };
}

export default async function PropertyPage({ params }: PropertyPageProps) {
    const property = await getPropertyById(params.id);

    if (!property) {
        notFound();
    }

    return (
        <main className="mx-auto max-w-6xl px-4 py-10 sm:px-6 lg:px-8">
            <Link
                href="/"
                className="mb-6 inline-flex items-center rounded-full border border-slate-200 bg-white px-4 py-2 text-sm font-medium text-slate-700 shadow-sm transition hover:border-slate-300 hover:bg-slate-50"
            >
                ← Voltar para busca
            </Link>
            <div className="grid gap-8 lg:grid-cols-[1.3fr_0.7fr]">
                <section className="space-y-5 rounded-[2rem] bg-white p-6 shadow-soft">
                    <div className="overflow-hidden rounded-[1.75rem] bg-slate-100">
                        <img
                            src={
                                property.imageUrl ||
                                "https://images.unsplash.com/photo-1494526585095-c41746248156?auto=format&fit=crop&w=900&q=80"
                            }
                            alt={property.title}
                            className="h-[420px] w-full object-cover"
                        />
                    </div>
                    <div className="space-y-3">
                        <div className="flex flex-wrap items-center gap-3">
                            <span className="rounded-full bg-emerald-100 px-3 py-1 text-sm font-semibold text-emerald-800">
                                {property.transactionType}
                            </span>
                            <span className="rounded-full bg-slate-100 px-3 py-1 text-sm font-medium text-slate-700">
                                {property.propertyType}
                            </span>
                            <span className="rounded-full bg-slate-100 px-3 py-1 text-sm font-medium text-slate-700">
                                {property.sourceName}
                            </span>
                        </div>
                        <div className="space-y-2">
                            <h1 className="text-3xl font-semibold tracking-tight text-slate-950">
                                {property.title}
                            </h1>
                            <p className="text-sm text-slate-500">
                                {property.neighborhood} • {property.city}
                            </p>
                        </div>
                        <div className="grid gap-3 sm:grid-cols-2 lg:grid-cols-3">
                            <div className="rounded-3xl border border-slate-200 bg-slate-50 p-4">
                                <p className="text-sm text-slate-500">Preço</p>
                                <p className="mt-1 text-lg font-semibold text-slate-900">
                                    {formatCurrency(property.price)}
                                </p>
                            </div>
                            <div className="rounded-3xl border border-slate-200 bg-slate-50 p-4">
                                <p className="text-sm text-slate-500">
                                    Custo mensal total
                                </p>
                                <p className="mt-1 text-lg font-semibold text-slate-900">
                                    {formatCurrency(property.totalMonthlyCost)}
                                </p>
                            </div>
                            <div className="rounded-3xl border border-slate-200 bg-slate-50 p-4">
                                <p className="text-sm text-slate-500">
                                    Valor por m²
                                </p>
                                <p className="mt-1 text-lg font-semibold text-slate-900">
                                    {formatCurrency(
                                        property.pricePerSquareMeter,
                                    )}
                                </p>
                            </div>
                        </div>
                    </div>
                    <div className="rounded-[1.75rem] border border-slate-200 bg-slate-50 p-6">
                        <h2 className="text-xl font-semibold text-slate-950">
                            Descrição
                        </h2>
                        <p className="mt-4 leading-7 text-slate-700">
                            {property.description}
                        </p>
                    </div>
                </section>

                <aside className="space-y-6 rounded-[2rem] bg-white p-6 shadow-soft">
                    <div className="rounded-[1.75rem] border border-slate-200 bg-slate-50 p-5">
                        <h2 className="text-lg font-semibold text-slate-950">
                            Detalhes rápidos
                        </h2>
                        <ul className="mt-4 space-y-4 text-sm text-slate-700">
                            <li>
                                <strong className="block text-slate-900">
                                    Endereço
                                </strong>
                                {property.address || "Não disponível"}
                            </li>
                            <li>
                                <strong className="block text-slate-900">
                                    Bairro
                                </strong>
                                {property.neighborhood}
                            </li>
                            <li>
                                <strong className="block text-slate-900">
                                    Área
                                </strong>
                                {property.area} m²
                            </li>
                            <li>
                                <strong className="block text-slate-900">
                                    Quartos
                                </strong>
                                {property.bedrooms}
                            </li>
                            <li>
                                <strong className="block text-slate-900">
                                    Banheiros
                                </strong>
                                {property.bathrooms}
                            </li>
                            <li>
                                <strong className="block text-slate-900">
                                    Vagas
                                </strong>
                                {property.parkingSpaces}
                            </li>
                            <li>
                                <strong className="block text-slate-900">
                                    Pet friendly
                                </strong>
                                {property.isPetFriendly ? "Sim" : "Não"}
                            </li>
                            <li>
                                <strong className="block text-slate-900">
                                    Mobiliado
                                </strong>
                                {property.isFurnished ? "Sim" : "Não"}
                            </li>
                        </ul>
                    </div>
                    <div className="space-y-4 rounded-[1.75rem] border border-slate-200 bg-slate-50 p-5">
                        <p className="text-sm text-slate-500">
                            Fonte do anúncio
                        </p>
                        <p className="font-medium text-slate-900">
                            {property.sourceName}
                        </p>
                        <a
                            href={property.sourceUrl}
                            target="_blank"
                            rel="noreferrer"
                            className="inline-flex w-full justify-center rounded-3xl bg-primary px-4 py-3 text-sm font-semibold text-white transition hover:bg-primaryDark"
                        >
                            Ver anúncio original
                        </a>
                    </div>
                </aside>
            </div>
        </main>
    );
}
