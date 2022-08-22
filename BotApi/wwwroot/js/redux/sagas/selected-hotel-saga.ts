import { isNullLiteral } from "@babel/types";
import { Reducer } from "redux";
import { put, takeLatest } from "redux-saga/effects";

interface ISelectedHotelProps {
  code: string;
  name: string;
  url: string;
  currency: string;
  rating: number;
  type: string;
  infourl: string;
  bookurl: string;
  photo: string;
  distance: number;
  location: { lat: any; lon: any; name: string; country: string };
}

export interface ISelectedHotel {
  selectedHotel: any;
}

export enum SelectedHotelTypes {
  HOTEL_STORE = "HOTEL_STORE"
}

let initialState: ISelectedHotel = {
  selectedHotel: null
};

const reducer: Reducer<ISelectedHotel> = (
  state: ISelectedHotel = initialState,
  command
) => {
  switch (command.type) {
    case SelectedHotelTypes.HOTEL_STORE:
      return {
        ...state,
        selectedHotel: command.payload
      };
    default:
      return state;
  }
};

export default reducer;

function storeHotel(data: any) {
  put({
    type: SelectedHotelTypes.HOTEL_STORE,
    payload: { data }
  });
}

export const selectedHotelSaga = [
  takeLatest(SelectedHotelTypes.HOTEL_STORE, storeHotel)
];
