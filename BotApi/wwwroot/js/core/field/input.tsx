import ErrorMessage from "@components/error-message";
import React from "react";

const Input = React.memo((props: any) => {
  const { input, meta, value, onFocusSelect, ...rest } = props;
  return (
    <>
      <input
        {...rest}
        {...input}
        autoComplete="off"
        onBlur={(e: any) => {
          input.onBlur(e);
          if (props.onBlur && e.target.value) {
            props.onBlur(e.target.value);
          }
        }}
        onFocus={(e) => {
          input.onFocus(e);
          onFocusSelect && e.target.select();
        }}
        onChange={(e) => {
          input.onChange(e); //final-form's onChange
          if (props.onChange) {
            props.onChange(e.target);
          }
        }}
      />
      <ErrorMessage touched={meta?.touched} error={meta?.error} />
    </>
  );
});

export default Input;
