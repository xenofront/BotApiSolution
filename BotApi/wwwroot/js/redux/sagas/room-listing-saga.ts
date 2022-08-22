import Api from "@api/api";
import { localhost } from "@api/endpoints";
import { IRate } from "@common/interfaces/availability";
import { logError } from "@common/_shared/error-handler";
import { Reducer } from "redux";
import { call, put, takeLatest } from "redux-saga/effects";

export interface IRoomListingState {
  isRoomListingLoading: boolean;
  availabilityInfos: IRate[];
}

export enum RoomListingTypes {
  ROOM_LISTING_REQUEST = "ROOM_LISTING_REQUEST",
  ROOM_LISTING_RESPONSE = "ROOM_LISTING_RESPONSE"
}

let initialState: IRoomListingState = {
  isRoomListingLoading: false,
  availabilityInfos: []
};

const reducer: Reducer<IRoomListingState> = (
  state: IRoomListingState = initialState,
  command
) => {
  switch (command.type) {
    case RoomListingTypes.ROOM_LISTING_REQUEST:
      return {
        ...state,
        isRoomListingLoading: true
      };
    case RoomListingTypes.ROOM_LISTING_RESPONSE:
      return {
        ...state,
        isRoomListingLoading: false,
        availabilityInfos: command.payload.response
      };
    default:
      return state;
  }
};

export default reducer;

let api = new Api();

function* getAvailabilityInfo(request: any): any {
  try {
    const response = yield call(
      api.post,
      `${localhost}/availabilityinfo`,
      request.payload
    );
    yield put({
      type: RoomListingTypes.ROOM_LISTING_RESPONSE,
      payload: { response }
    });
  } catch (err) {
    logError(err);
  }
}

export const roomListingSaga = [
  takeLatest(RoomListingTypes.ROOM_LISTING_REQUEST, getAvailabilityInfo)
];
