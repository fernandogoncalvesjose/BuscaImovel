import { Property, PropertyFilter } from '@/types/property';

const apiUrl = process.env.NEXT_PUBLIC_API_URL?.replace(/\/$/, '');

if (!apiUrl) {
  throw new Error('NEXT_PUBLIC_API_URL não está configurado no frontend');
}

function buildSearchParams(filters: PropertyFilter) {
  const params = new URLSearchParams();

  if (filters.transactionType) params.set('transactionType', filters.transactionType);
  if (filters.propertyType) params.set('propertyType', filters.propertyType);
  if (filters.neighborhood) params.set('neighborhood', filters.neighborhood);
  if (filters.sourceName) params.set('sourceName', filters.sourceName);
  if (filters.query && filters.query.trim()) params.set('query', filters.query.trim());
  if (typeof filters.minPrice === 'number') params.set('minPrice', String(filters.minPrice));
  if (typeof filters.maxPrice === 'number') params.set('maxPrice', String(filters.maxPrice));
  if (typeof filters.minBedrooms === 'number') params.set('minBedrooms', String(filters.minBedrooms));
  if (typeof filters.minParkingSpaces === 'number') params.set('minParkingSpaces', String(filters.minParkingSpaces));
  if (typeof filters.minArea === 'number') params.set('minArea', String(filters.minArea));
  if (typeof filters.isPetFriendly === 'boolean') params.set('isPetFriendly', String(filters.isPetFriendly));
  if (typeof filters.isFurnished === 'boolean') params.set('isFurnished', String(filters.isFurnished));

  return params.toString();
}

async function fetchJson<T>(url: string): Promise<T> {
  const response = await fetch(url, { cache: 'no-store' });

  if (!response.ok) {
    throw new Error('Falha ao carregar dados da API');
  }

  return response.json();
}

export async function getProperties(filters: PropertyFilter): Promise<Property[]> {
  const params = buildSearchParams(filters);
  const url = `${apiUrl}/api/properties${params ? `?${params}` : ''}`;
  return fetchJson<Property[]>(url);
}

export async function getPropertyById(id: string): Promise<Property | null> {
  const url = `${apiUrl}/api/properties/${id}`;
  try {
    return await fetchJson<Property>(url);
  } catch {
    return null;
  }
}

export async function getNeighborhoods(): Promise<string[]> {
  return fetchJson<string[]>(`${apiUrl}/api/properties/neighborhoods`);
}

export async function getSources(): Promise<string[]> {
  return fetchJson<string[]>(`${apiUrl}/api/properties/sources`);
}
