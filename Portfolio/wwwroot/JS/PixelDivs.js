let PixelSize = 4;
let Element;
let ElementID;
let goOnce = true;
export function snapToPixelGrid(elementID, pixelSize = 4) {
  ElementID = elementID;
  PixelSize = pixelSize; 
  Element = document.getElementById(ElementID);
  const rect = Element.getBoundingClientRect();
  const snappedWidth = Math.ceil(rect.width / pixelSize) * pixelSize;
  const snappedHeight = Math.ceil(rect.height / pixelSize) * pixelSize;

  Element.style.width = snappedWidth + "px";
  Element.style.height = snappedHeight + "px";
  if (goOnce) {
    window.addEventListener('resize', () => snapToPixelGrid(ElementID, PixelSize));
    window.addEventListener('load', () => snapToPixelGrid(ElementID, PixelSize));
    goOnce = false;
  }
}

export function removeListeners() {
  window.removeListeners('resize', () => snapToPixelGrid(ElementID, PixelSize));
  window.removeListeners('load', ()=> snapToPixelGrid(ElementID, PixelSize));
}