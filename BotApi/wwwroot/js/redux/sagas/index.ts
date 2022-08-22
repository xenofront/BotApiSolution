import { roomListingSaga } from "@redux/sagas/room-listing-saga";
import { selectedHotelSaga } from "@redux/sagas/selected-hotel-saga";
import { all } from "redux-saga/effects";

export default function* rootSaga() {
  yield all([...roomListingSaga, ...selectedHotelSaga]);
}
