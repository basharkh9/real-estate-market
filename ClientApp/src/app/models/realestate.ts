export interface KeyValuePair { 
  id: number; 
  name: string; 
}

export interface RealEstate {
  id: number; 
  model: KeyValuePair;
  make: KeyValuePair; 
}

export interface SaveRealEstate {
  id: number; 
  claddingId: number;
  area: number;
  level: number;
  numberofroom: number;
  price: number;
  address: string;

}