import { getProperties } from "@api/api-queries";
import { required } from "@common/utils/validation";
import { valuesArray } from "@common/_shared/shared-fields";
import { Button } from "@core/button";
import DatePicker from "@core/datepicker";
import { Select, SelectAsync } from "@core/select";
import { IAppState } from "@redux/rootReducer";
import { SelectedHotelTypes } from "@redux/sagas/selected-hotel-saga";
import { addDays } from "date-fns";
import debounce from "debounce-promise";
import React, { useEffect, useRef, useState } from "react";
import { Field, Form } from "react-final-form";
import { shallowEqual, useDispatch, useSelector } from "react-redux";

interface IMainForm {
  onSubmitAvailabilityInfo: (data: any) => void;
  isLoading: (x: boolean) => void;
}

function MainForm({ onSubmitAvailabilityInfo, isLoading }: IMainForm) {
  const dispatch = useDispatch();

  const hotelSaga = useSelector(
    (state: IAppState) => state.selectedHotelSaga,
    shallowEqual
  );

  const [hotelOptions, setHotelOptions] = useState([]);
  const [selectedHotel, setSelectedHotel] = useState(hotelSaga.selectedHotel);
  const [menuIsOpen, setMenuIsOpen] = useState(false);

  useEffect(() => {
    if (!selectedHotel) {
      return;
    }
    dispatch({
      type: SelectedHotelTypes.HOTEL_STORE,
      payload: selectedHotel
    });
  }, [selectedHotel]);

  const debouncedCall = useRef(
    debounce(async (nextValue) => {
      return await getProperties(nextValue);
    }, 1000)
  ).current;

  const loadProperties = async (
    text: string,
    callback: (options: readonly any[]) => void
  ): Promise<any> => {
    if (text.length > 3) {
      setMenuIsOpen(false);
      isLoading(true);
      const result = await debouncedCall(text);
      isLoading(false);
      setMenuIsOpen(true);
      const options = result.map((x: { name: string; code: any }) => ({
        label: x.name,
        value: x.code
      }));
      callback(options);
      setHotelOptions(options);
    }
  };

  const onChange = (option: any) => {
    setSelectedHotel({ label: option?.label, value: option?.value });
  };

  return (
    <div className="card mb-4">
      <div className="card-body">
        <Form
          onSubmit={onSubmitAvailabilityInfo}
          initialValues={{
            code: selectedHotel?.value || "",
            location: "",
            checkin: addDays(new Date(), 10),
            checkout: "",
            nights: valuesArray[1],
            rooms: valuesArray[1],
            adults: valuesArray[2],
            children: valuesArray[0],
            infants: valuesArray[0]
          }}
          keepDirtyOnReinitialize
          render={({ handleSubmit }) => (
            <form onSubmit={handleSubmit}>
              <div className="row mb-3">
                <div className="col-md-6 col-xs-12">
                  <div className="form-group position-relative">
                    <label className="label">Location</label>
                    <Field
                      name="location"
                      onChangeFunc={onChange}
                      component={SelectAsync}
                      disabled
                      placeholder="Type location name"
                      showSeparatorAndDropdown={false}
                    />
                  </div>
                </div>
                <div className="col-md-6 col-xs-12">
                  <div className="form-group position-relative">
                    <label className="label">Hotel</label>
                    <Field
                      name="code"
                      value={selectedHotel}
                      onChangeFunc={onChange}
                      component={SelectAsync}
                      customDefaultValue={selectedHotel}
                      isClearable={true}
                      options={hotelOptions}
                      loadOptions={loadProperties}
                      placeholder="Type hotel name"
                      menuIsOpen={menuIsOpen}
                      validate={required}
                    />
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="form-group col-md-5 col-xs-12">
                  <label className="label">Check in</label>
                  <div className="input-group">
                    <span className="input-group-text" id="addon-date">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="16"
                        height="16"
                        fill="currentColor"
                        className="bi bi-calendar3"
                        viewBox="0 0 16 16"
                      >
                        <path d="M14 0H2a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2zM1 3.857C1 3.384 1.448 3 2 3h12c.552 0 1 .384 1 .857v10.286c0 .473-.448.857-1 .857H2c-.552 0-1-.384-1-.857V3.857z" />
                        <path d="M6.5 7a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm3 0a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm3 0a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm-9 3a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm3 0a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm3 0a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm3 0a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm-9 3a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm3 0a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm3 0a1 1 0 1 0 0-2 1 1 0 0 0 0 2z" />
                      </svg>
                    </span>
                    <Field
                      name="checkin"
                      isClearable={true}
                      className="form-control form-control-sm"
                      component={DatePicker}
                      minDate={addDays(new Date(), 1)}
                      placeholderText={new Date().toLocaleDateString("el", {})}
                      validate={required}
                    />
                  </div>
                </div>
                <div className="form-group col-md-2 col-xs-12">
                  <label className="label">Nights</label>
                  <Field
                    name="nights"
                    options={valuesArray.slice(1)}
                    isSearchable={false}
                    className="form-control"
                    component={Select}
                    validate={required}
                  />
                </div>
              </div>
              <div className="row mb-3 mt-2">
                <div className="form-group col-md-4 col-xs-12">
                  <label className="label">Rooms</label>
                  <Field
                    name="rooms"
                    options={valuesArray.slice(1, 6)}
                    isSearchable={false}
                    component={Select}
                    validate={required}
                  />
                </div>
                <div className="form-group col-md-4 col-xs-12">
                  <label className="label">Adults</label>
                  <Field
                    name="adults"
                    options={valuesArray.slice(1, 6)}
                    isSearchable={false}
                    component={Select}
                    validate={required}
                  />
                </div>
                <div className="form-group col-md-4 col-xs-12">
                  <label className="label">Children</label>
                  <Field
                    name="children"
                    options={valuesArray.slice(0, 6)}
                    isSearchable={false}
                    component={Select}
                  />
                </div>
              </div>
              <div className="d-flex justify-content-end">
                <Button>Search</Button>
              </div>
            </form>
          )}
        />
      </div>
    </div>
  );
}

export default MainForm;
