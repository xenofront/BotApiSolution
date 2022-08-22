import React from "react";

interface ICard {
  title?: string | any;
  icon?: string;
  bodyClassName?: string;
  children?: any;
  minHeight?: string;
}

const Card = React.memo((props: ICard) => {
  return (
    <div className="card">
      {/* {props.title && (
        <div className="card-header">
          <i className={props.icon} /> {props.title}
        </div>
      )} */}
      <div
        style={{ minHeight: props.minHeight }}
        className={`card-body ${props.bodyClassName ?? ""}`}
      >
        {props.children}
      </div>
    </div>
  );
});

export default Card;
