import ErrorMessage from "@core/error-message";
import React from "react";
import { default as ReactDatepicker } from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "./datepicker.scss";

// interface IDatePickerProps {
//   minDate: Date;
//   maxDate: Date;
//   disabled: boolean;
//   placeholderText: string;
//   isClearable: boolean;
//   selected: boolean;
//   dateFormat: string;
//   onChange: (e: any) => void;
//   input: FieldInputProps<any>;
//   meta: FieldMetaState<any>;
// }

const DatePicker = React.memo((props: any) => {
  const {
    input: { name, onChange, value, ...restInput },
    meta,
    selected,
    disabled,
    ...rest
  } = props;

  return (
    <>
      <ReactDatepicker
        {...rest}
        {...restInput}
        locale={"en"}
        disabled={props.disabled}
        placeholderText={props.placeholderText}
        isClearable={props.isClearable}
        todayButton="Go to Today"
        selected={value ? value : selected}
        dateFormat={props.dateFormat ? props.dateFormat : "dd/MM/yyyy"}
        onChange={(e) => {
          onChange(e); // input Onchange
          if (props.onChange) props.onChange(e); // props change
        }}
        peekNextMonth
        showMonthDropdown
        showYearDropdown
        minDate={props.minDate}
        maxDate={props.maxDate}
        dropdownMode="select"
      />
      <div style={{ marginLeft: "5px", marginTop: "5px" }}>
        <ErrorMessage touched={meta.touched} error={meta.error} />
      </div>
    </>
  );
});

export default DatePicker;
