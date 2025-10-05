export function PixelOverlayDivs(divId, pixelBorderSize) {
  let div = document.getElementById(divId);
  if (!div) { console.warn("no div found"); return };
  let clientRect = div.getBoundingClientRect();
  let pixelXAxis = clientRect.width / pixelBorderSize;
  let pixelYAxis = clientRect.height / pixelBorderSize;
  for (let i = 0; i < pixelYAxis; i++) {
    for (let j = 0; j < pixelXAxis; j++) {
      let pixelDiv = document.createElement("div");
      pixelDiv.style.position = "relative";
      div.appendChild(pixelDiv);
    }
  }
}
