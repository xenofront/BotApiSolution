import React from "react";
import { useVirtual } from "react-virtual";
import "./react-virtual.scss";

interface IReactVirtual {
  data?: any;
}

function RowVirtualizerFixed(props: IReactVirtual) {
  const parentRef = React.useRef<HTMLDivElement>();

  const rowVirtualizer = useVirtual({
    size: props.data.length,
    parentRef,
    estimateSize: React.useCallback(() => 25, []),
    overscan: 10
  });

  return (
    <>
      <div
        ref={parentRef}
        className="list"
        style={{
          maxHeight: `100px`,
          position: "absolute",
          width: "1000px",
          overflow: "auto"
        }}
      >
        <div
          style={{
            height: `${rowVirtualizer.totalSize}px`,
            width: "100%",
            position: "relative"
          }}
        >
          {rowVirtualizer.virtualItems.map((row) => (
            <div
              key={row.index}
              className="list-item"
              style={{
                position: "absolute",
                top: 0,
                left: 0,
                width: "100%",
                height: `${row.size}px`,
                transform: `translateY(${row.start}px)`
              }}
            >
              {props.data[row.index].name}
            </div>
          ))}
        </div>
      </div>
    </>
  );
}

export default RowVirtualizerFixed;
