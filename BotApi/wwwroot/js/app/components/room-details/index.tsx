import { getRoomInfo } from "@api/api-queries";
import { IRoomInfo } from "@common/interfaces/roomInfo";
import Card from "@core/card";
import ImageSlider from "@core/image-slider";
import React, { useState, useEffect } from "react";
import Skeleton from "react-loading-skeleton";
import { useParams } from "react-router";

function RoomDetails() {
  const [roomInfo, setRoomInfo] = useState<IRoomInfo>();
  const { roomId, hotelCode } =
    useParams<{ roomId: string; hotelCode: string }>();

  useEffect(() => {
    const query = async () => {
      const info = await getRoomInfo(hotelCode, roomId);
      setRoomInfo(info);
    };
    query();
  }, []);

  return (
    <>
      {!roomInfo ? (
        <Card>
          <Skeleton width={"80%"} />
          <Skeleton width={"65%"} />
          <Skeleton width={"70%"} />
          <Skeleton width={"80%"} />
          <Skeleton width={"70%"} />
        </Card>
      ) : (
        <Card>
          <div>{roomInfo.code}</div>
          <div>{roomInfo.amenities}</div>
          <div>{roomInfo.name}</div>
          <div dangerouslySetInnerHTML={{ __html: roomInfo.description }}></div>
          <ImageSlider photos={roomInfo.photos} />
        </Card>
      )}
    </>
  );
}

export default RoomDetails;
