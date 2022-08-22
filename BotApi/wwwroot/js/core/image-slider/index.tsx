import { IRoomPhoto } from "@common/interfaces/roomInfo";
import SliderContainer from "@core/image-slider/imageSlider.elements";
import React, { useState } from "react";

interface IImageSlider {
  photos: IRoomPhoto[];
}

function ImageSlider({ photos }: IImageSlider) {
  const [currentPhoto, setCurrentPhoto] = useState(0);

  const nextPhoto = () => {
    setCurrentPhoto(currentPhoto === photos.length ? 0 : currentPhoto + 1);
  };

  const prevPhoto = () => {
    setCurrentPhoto(currentPhoto === 0 ? photos.length - 1 : currentPhoto - 1);
  };

  return (
    <>
      <button onClick={prevPhoto}>prev</button>
      <button onClick={nextPhoto}>next</button>
      {photos.map((photo, index) => {
        return (
          <div key={index}>
            {index === currentPhoto && (
              <SliderContainer image={photo}></SliderContainer>
            )}
          </div>
        );
      })}
    </>
  );
}

export default ImageSlider;
