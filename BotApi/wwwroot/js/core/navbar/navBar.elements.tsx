import styled from "styled-components";
import { NavLink as RouterLink } from "react-router-dom";

export const Container = styled.nav`
  background: #222e50;
  height: 80px;
  display: flex;
  justify-content: space-between;
  padding: 0.5rem calc((100vw - 1000px) 2);
  z-index: 10;
  margin-bottom: 25px;
`;

export const Logo = styled.img`
  background: white;

  &:hover {
    background: #ff9c00;
    transition: 200ms ease-in;
  }
`;
export const Link = styled(RouterLink)`
  color: #fff;
  display: flex;
  align-items: center;
  text-decoration: none;
  padding: 0 1rem;
  height: 100%;
  font-size: ${(props) => props.theme.fontSize};
  cursor: pointer;

  &:hover {
    color: #ff9c00;
    transition: 200ms ease-in;
  }
`;

export const Bars = styled.div`
  display: none;
  color: #fff;

  @media screen and (max-width: 768px) {
    display: block;
    position: absolute;
    top: 0;
    right: 0;
    transform: translate(-100%, 75%);
    font-size: 1.8rem;
    cursor: pointer;
  }
`;

export const Menu = styled.div`
  display: flex;
  align-items: center;
  margin-right: -24px;

  @media screen and (max-width: 768px) {
    display: none;
  }
`;

export const Button = styled.div`
  display: flex;
  align-items: center;
  margin-right: 24px;

  @media screen and (max-width: 768px) {
    display: none;
  }
`;

export const ButtonLink = styled(RouterLink)`
  border-radius: 4px;
  background: #ff9c00;
  padding: 10px 22px;
  font-size: ${(props) => props.theme.fontSize};
  color: black;
  border: none;
  outline: none;
  cursor: pointer;
  transition: all 0.2s ease-in-out;
  text-decoration: none;

  &:hover {
    color: white;
    transition: 200ms ease-in;
  }
`;
