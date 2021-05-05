export interface KeyValuePair { 
  id: number; 
  name: string; 
}

export interface RealEstate {
  id: number; 
  
}

export interface SaveRealEstate {
  id: number; 
  claddingId: number;
  area: number;
  level: number;
  numberOfRooms: number;
  price: number;
  address: string;
  isBooked: boolean;
}