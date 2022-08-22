import React from "react";
import {
  Bars,
  Button,
  ButtonLink,
  Container,
  Link,
  Logo,
  Menu
} from "./navBar.elements";

// React.HTMLAttributes<HTMLImageElement>
interface IProps {
  children: JSX.Element | JSX.Element[] | string;
}

const Nav = ({ children, ...rest }: IProps) => (
  <Container {...rest}>{children}</Container>
);

Nav.Link = ({ children, ...rest }: any) => <Link {...rest}>{children}</Link>;

Nav.Logo = ({ children, ...rest }: any) => <Logo {...rest}>{children}</Logo>;

Nav.Bars = ({ children, ...rest }: IProps) => <Bars {...rest}>{children}</Bars>;

Nav.Menu = ({ children, ...rest }: IProps) => <Menu {...rest}>{children}</Menu>;

Nav.Button = ({ children, ...rest }: IProps) => (
  <Button {...rest}>{children}</Button>
);

Nav.ButtonLink = ({ children, ...rest }: any) => (
  <ButtonLink {...rest}>{children}</ButtonLink>
);

function NavContainer() {
  return (
    <Nav>
      <Nav.Link to="/" style={{ backrgound: "black" }}>
        <Nav.Logo
          height="60px"
          src={require("../../../images/logo.svg").default}
        ></Nav.Logo>
      </Nav.Link>
      <Nav.Bars>X</Nav.Bars>
      <Nav.Menu>
        <Nav.Link to="#">About</Nav.Link>
        <Nav.Link to="#">Services</Nav.Link>
        <Nav.Link to="#">Contact Us</Nav.Link>
      </Nav.Menu>
      <Nav.Button>
        <Nav.ButtonLink to="#">Login In</Nav.ButtonLink>
      </Nav.Button>
    </Nav>
  );
}

export default NavContainer;
