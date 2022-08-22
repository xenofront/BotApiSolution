import React from "react";
import { Btn, BtnOutline, IButtonProps, LinkBtn } from "./button.elements";

interface IProps extends IButtonProps {
  type?: "submit" | "button" | "reset";
  className?: string;
  children: React.ReactNode;
}

export function Button({
  children,
  className,
  type,
  size,
  background
}: IProps) {
  return (
    <Btn
      size={size}
      background={background}
      className={className}
      type={type || "submit"}
    >
      {children}
    </Btn>
  );
}

export function ButtonOutline({
  children,
  className,
  type,
  size,
  background
}: IProps) {
  return (
    <BtnOutline
      size={size}
      background={background}
      className={className}
      type={type || "submit"}
    >
      {children}
    </BtnOutline>
  );
}

export function LinkButton({
  children,
  className,
  type,
  size,
  background,
  to
}: IProps & {
  to: any;
}) {
  return (
    <LinkBtn
      to={{ ...to }}
      size={size}
      background={background}
      className={className}
      type={type || "submit"}
    >
      {children}
    </LinkBtn>
  );
}
