export function PixelOverlayDivs(divId, pixelBorderSize) {
  let div = document.getElementById(divId);
  if (!div) { console.warn("no div found"); return };
  let clientRect = div.getBoundingClientRect();
  let pixelXAxis = Math.floor(clientRect.width / pixelBorderSize);
  let pixelYAxis = Math.floor(clientRect.height / pixelBorderSize);
  let container = document.createElement("Container");
  div.appendChild(container);
  for (let i = 0; i < pixelYAxis; i++) {
    for (let j = 0; j < pixelXAxis; j++) {
      let pixelDiv = document.createElement("div");
      pixelDiv.style.width = "4px";
      pixelDiv.style.height = "4px";
      pixelDiv.style.zIndex = "-1";
      container.appendChild(pixelDiv);
    }
  }
}
