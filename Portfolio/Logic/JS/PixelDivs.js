class PixelDivs {
  GetDivSize(div) {
    clientRect = div.getBoundingClientRect();
    return { width: clientRect.width, height: clientRect.height };
  }

  PixelOverlayDivs(div, pixelBorderSize) {
    GetDivSize(div);

  }

}