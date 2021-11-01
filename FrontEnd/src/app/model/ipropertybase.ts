export interface IPropertyBase {
  id: number;
  sellRent: number;
  name: string;
  propertyType: string;
  furnishingType: string;
  price: number;
  bhk: number; // Bedroom, Hall, Kitchen
  builtArea: number;
  city: string;
  readyToMove: boolean; // Ready To Move
  image?: string;
  estPossessionOn: string;
}
