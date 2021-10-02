export interface IPropertyBase {
  Id: number;
  SellRent: number;
  Name: string;
  PType: string;
  FType: string;
  Price: number;
  BHK: number; // Bedroom, Hall, Kitchen
  BuiltArea: number;
  City: string;
  RTM: number; // Ready To Move
  Image?: string;
}
