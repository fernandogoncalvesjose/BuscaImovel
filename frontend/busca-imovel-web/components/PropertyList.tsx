import { Property } from "@/types/property";
import PropertyCard from "@/components/PropertyCard";

interface PropertyListProps {
    properties: Property[];
    medianPricePerM2?: number;
}

export default function PropertyList({
    properties,
    medianPricePerM2,
}: PropertyListProps) {
    return (
        <div className="space-y-6">
            {properties.map((item) => (
                <PropertyCard
                    key={item.id}
                    property={item}
                    medianPricePerM2={medianPricePerM2}
                />
            ))}
        </div>
    );
}
