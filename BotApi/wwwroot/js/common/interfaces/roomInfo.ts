export interface IRoomInfo {
  code: string;
  name: string;
  unitType: string;
  licenseNumber: any;
  description: string;
  sortOrder: number;
  active: boolean;
  capacity: IRoomCapacity;
  photos: IRoomPhoto[];
  amenities: string[];
}

interface IRoomCapacity {
  minPers: number;
  maxPers: number;
  maxAdults: number;
  maxInfants: number;
  childrenAllowed: number;
}

export interface IRoomPhoto {
  title: string;
  xsmall: string;
  small: string;
  medium: string;
  large: string;
}
