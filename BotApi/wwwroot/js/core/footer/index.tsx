import React from "react";
import {
  Container,
  Wrapper,
  Row,
  Column,
  Link,
  Title,
  Text
} from "./footer.elements";

interface IProps {
  children: any;
}

const Footer = ({ children, ...rest }: IProps) => (
  <Container {...rest}>{children}</Container>
);

Footer.Wrapper = ({ children, ...rest }: IProps) => (
  <Wrapper {...rest}>{children}</Wrapper>
);

Footer.Row = ({ children, ...rest }: IProps) => <Row {...rest}>{children}</Row>;

Footer.Column = ({ children, ...rest }: IProps) => (
  <Column {...rest}>{children}</Column>
);

Footer.Link = ({
  children,
  ...rest
}: IProps & { href: string; target: string }) => (
  <Link {...rest}>{children}</Link>
);

Footer.Title = ({ children, ...rest }: IProps) => (
  <Title {...rest}>{children}</Title>
);

Footer.Text = ({ children, ...rest }: IProps) => (
  <Text {...rest}>{children}</Text>
);

function FooterContainer() {
  return (
    <Footer>
      <Footer.Wrapper>
        <Footer.Title>Copyright &copy; 2021. All Rights Reserved.</Footer.Title>
        <Footer.Text>Powered by </Footer.Text>
        <Footer.Link
          target="_blank"
          href="https://docs.microsoft.com/en-us/dotnet/core/dotnet-five"
        >
          .NET 5
        </Footer.Link>
        <Footer.Text> and</Footer.Text>
        <Footer.Link target="_blank" href="https://reactjs.org/">
          {" "}
          React
        </Footer.Link>
      </Footer.Wrapper>
    </Footer>
  );
}

export default FooterContainer;
