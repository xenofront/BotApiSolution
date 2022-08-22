import Api from "@api/api";
import { localhost } from "@api/endpoints";
import { IAvailabilityRequest, IRate } from "@common/interfaces/availability";
import { IRoomInfo } from "@common/interfaces/roomInfo";

const api = new Api();

export async function getProperties(propertyName: string) {
  return await api.get(
    `${localhost}/properties`,
    `?propertyname=${propertyName}`
  );
}

export async function getAvailabilityInfo(
  availabilityInfoReq: IAvailabilityRequest
): Promise<IRate[]> {
  return await api.post(`${localhost}/availabilityinfo`, availabilityInfoReq);
}

export async function getRoomInfo(
  hotelCode: string,
  roomId: string
): Promise<IRoomInfo> {
  return await api.get(
    `${localhost}/roomInfo`,
    `?hotelCode=${hotelCode}&roomId=${roomId}`
  );
}
