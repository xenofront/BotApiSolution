export type IAvailabilityRequest = {
  code: string;
  checkin: string;
  location: string;
  rooms: number;
  adults: number;
  children?: number;
  infants?: number;
} & ({ checkout: string } | { nights: number });

export interface IRate {
  id: number;
  type: string;
  room: string;
  rate: string;
  rateDesc: string;
  paymentPolicy: string;
  paymentPolicyId: number;
  cancellationPolicy: string;
  cancellationPolicyId: number;
  cancellationPenalty: string;
  remaining: number;
  minStay: string;
  cancellationExpiry: any;
  board: number;
  url: {
    website: any;
    info: any;
    engine: any;
    photo: any;
    photoM: any;
    photoL: any;
    rate: any;
    room: any;
  };
  pricing: {
    stay: any;
    extras: any;
    taxes: any;
    excludedCharges: any;
    price: any;
    margin: any;
  };
  retail: {
    stay: any;
    extras: any;
    taxes: any;
    excludedCharges: any;
    price: any;
    discount: any;
  };
  payments: {
    due: string;
    amount: number;
  }[];
  cancellationFees: {
    after: string;
    fee: number;
  };
}
