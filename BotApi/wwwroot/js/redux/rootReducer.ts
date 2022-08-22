import roomListingSaga, {
  IRoomListingState
} from "@redux/sagas/room-listing-saga";
import selectedHotelSaga, {
  ISelectedHotel
} from "@redux/sagas/selected-hotel-saga";
import { connectRouter, RouterState } from "connected-react-router";
import { combineReducers } from "redux";

export interface IAppState {
  router: RouterState;
  roomListingSaga: IRoomListingState;
  selectedHotelSaga: ISelectedHotel;
}

function rootReducer(history: any) {
  return combineReducers({
    router: connectRouter(history),
    roomListingSaga,
    selectedHotelSaga
  });
}

export default rootReducer;
