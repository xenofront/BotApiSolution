import React from "react";
import { ErrorMessageSpan } from "./errorMessage.elements";

interface IErrorMessage {
  touched: boolean;
  error: string;
}

const ErrorMessage = React.memo((props: IErrorMessage) => {
  return (
    <>
      {props.touched && props.error && (
        <ErrorMessageSpan>{props.error}</ErrorMessageSpan>
      )}
    </>
  );
});

export default ErrorMessage;
