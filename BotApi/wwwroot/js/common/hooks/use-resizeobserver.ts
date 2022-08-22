import { useEffect, useState } from "react";

function useResizeObserver(ref: React.MutableRefObject<any>) {
  const [dimensions, setDimensions] = useState<DOMRectReadOnly>(null);

  useEffect(() => {
    const observerTarget = ref.current;
    const observer = new ResizeObserver((entries: ResizeObserverEntry[]) => {
      entries.forEach((entry) => {
        setDimensions(entry.contentRect);
      });
    });

    observer.observe(observerTarget);

    return () => observer.unobserve(observerTarget);
  }, [ref]);

  return dimensions;
}

export default useResizeObserver;
