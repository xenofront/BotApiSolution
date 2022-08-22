import "./select.scss";
import ErrorMessage from "@core/error-message";
import React from "react";
import { createFilter, default as ReactSelect } from "react-select";
import AsyncSelect from "react-select/async";
// @ts-ignore
import { FixedSizeList } from "react-window";

const option = (
  styles: React.CSSProperties,
  { data, isSelected, isFocused, options }: any
): React.CSSProperties => ({
  ...styles,
  borderTopLeftRadius:
    (isSelected && options.indexOf(data) === 0) ||
    (isFocused && options.indexOf(data) === 0)
      ? "4px"
      : "",
  borderTopRightRadius:
    (isSelected && options.indexOf(data) === 0) ||
    (isFocused && options.indexOf(data) === 0)
      ? "4px"
      : "",
  borderBottomLeftRadius:
    options.length === 1 ||
    (options.length === 1 && isFocused) ||
    (isSelected && options.indexOf(data) === options.length - 1) ||
    (isFocused && options.indexOf(data) === options.length - 1)
      ? "4px"
      : "",
  borderBottomRightRadius:
    options.length === 1 ||
    (options.length === 1 && isFocused) ||
    (isSelected && options.indexOf(data) === options.length - 1) ||
    (isFocused && options.indexOf(data) === options.length - 1)
      ? "4px"
      : ""
});

const meStyles = {
  control: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    minHeight: "31px",
    height: "31px"
  }),
  multiValue: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    marginLeft: "2px",
    marginRight: "2px",
    marginTop: "-2px"
  }),
  singleValue: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    marginLeft: "2px",
    marginRight: "2px",
    marginTop: "-2px"
  }),
  placeholder: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    marginLeft: "2px",
    marginRight: "2px",
    marginTop: "-2px"
  }),
  input: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    marginLeft: "2px",
    marginRight: "2px",
    marginTop: "-2px"
  }),
  menu: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    zIndex: 1000
  }),
  option,
  menuList: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    paddingTop: "0px",
    paddingBottom: "0px"
  }),
  indicatorSeparator: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    marginTop: "6px",
    marginBottom: "10px"
  }),
  dropdownIndicator: (styles: React.CSSProperties): React.CSSProperties => ({
    ...styles,
    marginTop: "-3px"
  })
};

// const meStyles = {
//   menuList: (styles: React.CSSProperties): React.CSSProperties => ({
//     ...styles,
//     paddingTop: "0px",
//     paddingBottom: "0px"
//   }),
//   menu: (styles: React.CSSProperties): React.CSSProperties => ({
//     ...styles,
//     zIndex: 1000
//   }),
//   option
// };

export const Select = React.memo((props: any) => {
  if (props.onChangeFunc === undefined) {
    return (
      <>
        <ReactSelect
          styles={meStyles}
          filterOption={createFilter({ ignoreAccents: false })}
          options={props.options}
          isDisabled={props.disabled || false}
          isLoading={props.isLoading}
          isSearchable={props.isSearchable}
          isClearable={props.isClearable || false}
          isMulti={props.isMulti}
          defaultValue={props.defaultValue}
          placeholder={props.placeholder}
          {...props.input}
        />
        <ErrorMessage touched={props.meta?.touched} error={props.meta?.error} />
      </>
    );
  }
  return (
    <>
      <ReactSelect
        styles={meStyles}
        filterOption={createFilter({ ignoreAccents: false })}
        components={{ MenuList }}
        options={props.options}
        isDisabled={props.disabled || false}
        isLoading={props.isLoading}
        isSearchable={props.isSearchable}
        isClearable={props.isClearable || false}
        isMulti={props.isMulti}
        defaultValue={props.defaultValue}
        onChange={props.onChangeFunc}
        value={props.value}
        {...props}
      />
      <ErrorMessage touched={props.meta?.touched} error={props.meta?.error} />
    </>
  );
});

export const SelectAsync = React.memo((props: any) => {
  return (
    <>
      <AsyncSelect
        styles={{
          meStyles,
          indicatorSeparator: (styles) => ({
            ...styles,
            display: !props.showSeparatorAndDropdown && "none"
          }),
          dropdownIndicator: (styles) => ({
            ...styles,
            display: !props.showSeparatorAndDropdown && "none"
          })
        }}
        filterOption={createFilter({ ignoreAccents: false })}
        components={{ MenuList }}
        noOptionsMessage={() => null}
        options={props.options}
        isDisabled={props.disabled || false}
        isLoading={props.isLoading}
        isSearchable={props.isSearchable}
        isClearable={props.isClearable || false}
        isMulti={props.isMulti}
        defaultValue={
          props.customDefaultValue?.value ? props.customDefaultValue : null
        }
        defaultInputValue={props.defaultInputValue}
        defaultOptions={props.defaultOptions}
        cacheOptions={props.cacheOptions}
        onChange={props.onChangeFunc}
        placeholder={props.placeholder}
        value={props.value}
        classNamePrefix="react-select"
        {...props}
      />
      <ErrorMessage touched={props.meta?.touched} error={props.meta?.error} />
    </>
  );
});

function MenuList(props: any) {
  const { children, maxHeight } = props;

  const height = getHeight(
    children.length,
    children[0]?.props.data.label.length,
    maxHeight
  );

  return (
    <FixedSizeList
      height={height}
      itemCount={children.length || 0}
      itemSize={37}
      width="auto"
      minWidth="300px"
      style={{
        overflowX:
          children.length === 1 &&
          children[0].props.data.label.length >= 31 &&
          "scroll"
      }}
    >
      {({ index, style }: { index: any; style: any }) => (
        <div style={{ ...style, whiteSpace: "nowrap" }}>{children[index]}</div>
      )}
    </FixedSizeList>
  );
}

function getHeight(childrenLength: number, firstChild: number, maxHeight: any) {
  if (!childrenLength) {
    return 0;
  }
  if (childrenLength === 1 && firstChild >= 30) {
    return 57;
  } else if (childrenLength < 10) {
    return childrenLength * 40;
  } else if (isNaN(maxHeight)) {
    return 0;
  } else if (maxHeight) {
    return maxHeight;
  }
}
