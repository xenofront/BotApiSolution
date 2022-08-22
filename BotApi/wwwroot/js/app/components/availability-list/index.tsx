import { IRate } from "@common/interfaces/availability";
import { LinkButton } from "@core/button";
import Card from "@core/card";
import { IAppState } from "@redux/rootReducer";
import { format as formatDate } from "date-fns";
import React from "react";
import Skeleton from "react-loading-skeleton";
import { shallowEqual, useSelector } from "react-redux";

interface IAvailInfo {
  availabilityInfos: IRate[];
  loading: boolean;
}

function AvailabilityList({ availabilityInfos, loading }: IAvailInfo) {
  const hotelSaga = useSelector(
    (state: IAppState) => state.selectedHotelSaga,
    shallowEqual
  );

  return (
    <div className="row">
      {loading ? (
        <Card title={<Skeleton />}>
          <div style={{ width: "300px", height: "200px" }}>
            <Skeleton height={200} width={300} />
          </div>
          <Skeleton />
          <Skeleton />
          <Skeleton />
        </Card>
      ) : (
        availabilityInfos.map((x) => (
          <div className="mb-2 col-lg-6" key={x.id}>
            <div className="card-body">
              <div
                className="d-flex"
                style={{
                  backgroundImage: `url(${x.url.photoM})`,
                  backgroundRepeat: "no-repeat",
                  height: "400px",
                  backgroundSize: "cover"
                }}
              >
                <div
                  className="col align-self-end d-flex flex-column"
                  style={{
                    background: "rgba(255, 255, 255, 0.7)",
                    backdropFilter: "blur(12px)",
                    borderRadius: ".5em",
                    padding: "1em",
                    margin: "1em",
                    backgroundClip: "padding-box",
                    boxShadow: "10px 10px 10px rgb(46, 54, 68, 0.003)"
                  }}
                >
                  <div>price €{x.pricing.price}</div>
                  <div>
                    payment due{" "}
                    {formatDate(
                      new Date(x.payments[0].due),
                      "dd/MM/yyyy hh:mm"
                    )}
                  </div>
                  <div>{x.rate}</div>
                  <div className="col d-flex justify-content-end">
                    <LinkButton
                      className="align-self-end"
                      to={{
                        pathname: `/details/${x.type}/${hotelSaga.selectedHotel.value}`
                      }}
                    >
                      Подробнее
                      <img
                        src={require("../../../../images/arrow.svg").default}
                        width="18px"
                        style={{ marginLeft: "5px", marginBottom: "2px" }}
                      />
                    </LinkButton>
                  </div>
                </div>
              </div>
            </div>
          </div>
        ))
      )}
    </div>
  );
}

export default AvailabilityList;
