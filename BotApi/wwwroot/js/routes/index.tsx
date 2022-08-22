import Main from "@app/components/main";
import RoomDetails from "@app/components/room-details";

const routes = [
  { path: "/", exact: true, component: Main },
  {
    path: "/details/:roomId/:hotelCode",
    component: RoomDetails
  }
];

export default routes;
