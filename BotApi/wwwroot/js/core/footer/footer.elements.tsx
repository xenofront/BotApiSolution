import styled from "styled-components";

export const Container = styled.footer`
  margin-top: auto;
  padding: 20px;
  background: #222e50;
`;

export const Wrapper = styled.div`
  text-align: center;
  margin-bottom: 8px;
  margin-top: 10px;
`;

export const Column = styled.div`
  display: flex;
  flex-direction: column;
  text-align: center;
  margin-left: 60px;
`;

export const Row = styled.div`
  display: grid;
  grid-template-columns: repeat(1, minmax(230px, 1fr));
  grid-gap: 20px;

  @media (max-width: 1000px) {
    grid-template-columns: repeat(1, minmax(200px, 1fr));
  }
`;

export const Link = styled.a`
  color: white;
  margin-bottom: 20px;
  font-size: ${(props) => props.theme.fontSize};
  text-decoration: none;

  &:hover {
    color: #ff9c00;
    transition: 200ms ease-in;
  }
`;

export const Title = styled.p`
  font-size: 20px;
  color: white;
  margin-bottom: 40px;
  font-weight: bold;
`;

export const Text = styled.span`
  color: white;
  font-size: ${(props) => props.theme.fontSize};
`;
