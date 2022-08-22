import React from "react";
import styled, { keyframes } from "styled-components";

const imageAnimation = keyframes`
    0% {
        opacity: 0
    }
    100% {
        opacity: 1
    }
`;

const Container = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  animation: ${imageAnimation} 2s ease;
`;

const Slider = styled.div`
  width: 80%;
  height: 80%;
`;

const Img = styled.img`
  width: 90%;
  height: 80%;

  min-height: 400px;
  /* @media (min-width: 1000px) {
    width: 700px;
    height: 500px;
  } */
`;

const SliderContainer = ({ image }: any) => {
  return (
    <Container>
      <Slider>
        <Img src={image.large} />
      </Slider>
    </Container>
  );
};

export default SliderContainer;
