export type Property = {
  id: string;
  title: string;
  description: string;
  transactionType: string;
  propertyType: string;
  price: number;
  condoFee?: number;
  iptu?: number;
  area: number;
  bedrooms: number;
  bathrooms: number;
  parkingSpaces: number;
  neighborhood: string;
  city: string;
  address?: string;
  isPetFriendly: boolean;
  isFurnished: boolean;
  sourceName: string;
  sourceUrl: string;
  imageUrl?: string;
  totalMonthlyCost: number;
  pricePerSquareMeter: number;
};

export type PropertyFilter = {
  query?: string;
  transactionType?: string;
  propertyType?: string;
  neighborhood?: string;
  sourceName?: string;
  minPrice?: number;
  maxPrice?: number;
  minBedrooms?: number;
  minParkingSpaces?: number;
  minArea?: number;
  isPetFriendly?: boolean;
  isFurnished?: boolean;
};
