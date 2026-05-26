import PropertyDetail from "@/components/PropertyDetail";
import { notFound } from "next/navigation";
import { getPropertyById } from "@/services/propertyService";

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

    return <PropertyDetail property={property} />;
}
