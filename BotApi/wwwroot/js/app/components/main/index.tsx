import AvailabilityList from "@app/components/availability-list";
import MainForm from "@app/components/main-form";
import { IAvailabilityRequest, IRate } from "@common/interfaces/availability";
import { postDateField } from "@common/_shared/date-utils";
import { IAppState } from "@redux/rootReducer";
import { RoomListingTypes } from "@redux/sagas/room-listing-saga";
import React, { useEffect, useState } from "react";
import { shallowEqual, useDispatch, useSelector } from "react-redux";

function Main() {
  const dispatch = useDispatch();
  const roomListingSaga = useSelector(
    (state: IAppState) => state.roomListingSaga,
    shallowEqual
  );

  const [availabilityInfos, setAvailabilityInfos] = useState<IRate[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setAvailabilityInfos(roomListingSaga.availabilityInfos);
  }, [roomListingSaga.availabilityInfos]);

  const availablityInfoRequest = async (data: any) => {
    setLoading(true);
    const request: IAvailabilityRequest = {
      code: data.code,
      location: data.location,
      checkin: postDateField(data.checkin),
      checkout: data.checkout,
      nights: data.nights.value,
      rooms: data.rooms.value,
      adults: data.adults.value,
      children: data.children.value,
      infants: data.infants.value
    };
    dispatch({
      type: RoomListingTypes.ROOM_LISTING_REQUEST,
      payload: request
    });
    setAvailabilityInfos(roomListingSaga.availabilityInfos);
    setLoading(false);
  };

  return (
    <>
      <MainForm
        onSubmitAvailabilityInfo={availablityInfoRequest}
        isLoading={(x) => setLoading(x)}
      />
      {availabilityInfos?.length > 0 && (
        <AvailabilityList
          availabilityInfos={availabilityInfos}
          loading={loading}
        />
      )}
    </>
  );
}

export default Main;
