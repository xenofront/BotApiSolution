import { required } from "@common/utils/validation";
import Input from "@components/field/input";
import RowVirtualizerFixed from "@components/react-virtual";
import React, { useState } from "react";
import { Field } from "react-final-form";

interface IProps {
  label: string;
}

function FieldSelectReactVirtual(props: IProps) {
  const [show, setShow] = useState(false);

  return (
    <>
      <label className="label">{props.label}</label>
      <Field
        name="location"
        className="form-control form-control-sm"
        validate={required}
      >
        {(fieldProps) => {
          const funs = () => {
            setShow(true);
          };
          const onBlur = () => {
            setShow(false);
          };
          fieldProps.input.onFocus = funs;
          fieldProps.input.onBlur = onBlur;

          return <Input {...fieldProps} />;
        }}
      </Field>
      <RowVirtualizerFixed />
    </>
  );
}

export default FieldSelectReactVirtual;
