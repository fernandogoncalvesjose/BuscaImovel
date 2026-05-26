import { Property } from "@/types/property";
import PropertyCard from "@/components/PropertyCard";

interface PropertyListProps {
    properties: Property[];
}

export default function PropertyList({ properties }: PropertyListProps) {
    return (
        <div className="space-y-6">
            {properties.map((item) => (
                <PropertyCard key={item.id} property={item} />
            ))}
        </div>
    );
}
