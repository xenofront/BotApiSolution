import styled from "styled-components";
import { NavLink as RouterLink } from "react-router-dom";

export interface IButtonProps {
  background?: "green" | "blue" | "gold";
  size?: "md" | "lg";
}

const BtnBase = styled.button<IButtonProps>`
  border-radius: 4px;
  outline: none;
  margin: 0;
  cursor: pointer;
  transition: all 0.2s ease-in-out;

  padding: ${(props) => getSize(props.size).padding};
  font-size: ${(props) => getSize(props.size).fontSize};
`;

export const Btn = styled(BtnBase)<IButtonProps>`
  border: 1px solid;
  border-color: ${(props) => getBackground(props.background).background};
  color: white;
  background: ${(props) => getBackground(props.background).background};
  padding: ${(props) => getSize(props.size).padding};
  font-size: ${(props) => getSize(props.size).fontSize};

  &:hover {
    background: ${(props) => getBackground(props.background).backgroundHover};
    border-color: ${(props) => getBackground(props.background).backgroundHover};
  }

  &:active {
    background-color: #ff9c00;
    border-color: #ff9c00;
  }
`;

export const BtnOutline = styled(BtnBase)<IButtonProps>`
  color: ${(props) => getBackground(props.background).background};
  border-color: ${(props) => getBackground(props.background).background};

  border-style: solid;
  border-width: 1px;
  background: white;

  &:hover {
    color: white;
    background: ${(props) => getBackground(props.background).background};
    border-color: ${(props) => getBackground(props.background).background};
  }

  &:active {
    background-color: ${(props) =>
      getBackground(props.background).backgroundHover};
    border-color: ${(props) => getBackground(props.background).backgroundHover};
  }
`;

export const LinkBtn = styled(RouterLink)<IButtonProps>`
  text-decoration: none;
  border-radius: 4px;
  outline: none;
  margin: 0;
  cursor: pointer;
  transition: all 0.2s ease-in-out;

  padding: ${(props) => getSize(props.size).padding};
  font-size: ${(props) => getSize(props.size).fontSize};

  color: ${(props) => getBackground(props.background).background};
  border-color: ${(props) => getBackground(props.background).background};

  border-style: solid;
  border-width: 1px;
  background: white;

  &:hover {
    color: white;
    background: ${(props) => getBackground(props.background).background};
    border-color: ${(props) => getBackground(props.background).background};
  }

  &:active {
    background-color: ${(props) =>
      getBackground(props.background).backgroundHover};
    border-color: ${(props) => getBackground(props.background).backgroundHover};
  }
`;

function getSize(size: string) {
  if (!size) {
    return { padding: "0.25rem 0.5rem", fontSize: ".875rem" };
  }
  if (size === "lg") {
    return { padding: ".5rem 1rem", fontSize: "1.25rem" };
  }
  if (size === "md") {
    return { padding: ".375rem .75rem", fontSize: "1rem" };
  }
}

function getBackground(color: string) {
  if (!color || color === "green") {
    return { background: "#06a77d", backgroundHover: "#047c5c" };
  }
  if (color === "gold") {
    return { background: "#ff9c00", backgroundHover: "rgb(255, 156, 0)" };
  }
  if (color === "blue") {
    return { background: "blue", backgroundHover: "blue" };
  }
}
