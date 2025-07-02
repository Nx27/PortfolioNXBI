//var canvas;
//var ctx;

//window.drawOnCanvas = function () {
//  canvas = document.getElementById('myCanvasIntro');
//  if (canvas.getContext) {
    
//  }
//}

//const drawWidth = 32;   // Your drawing canvas width (in virtual pixels)
//const drawHeight = 32;  // Your drawing canvas height

//const displayWidth = 512;  // Final HTML canvas size
//const displayHeight = 512;


//// Set canvas internal resolution (drawing resolution × scale factor)
//const scaleX = Math.floor(displayWidth / drawWidth);
//const scaleY = Math.floor(displayHeight / drawHeight);
//const scale = Math.min(scaleX, scaleY); // use integer scaling to avoid blur

//// Set actual drawing resolution (logical pixels)
//canvas.width = drawWidth * scale;
//canvas.height = drawHeight * scale;

//// Set CSS size (what's seen on screen)
//canvas.style.width = `${canvas.width}px`;
//canvas.style.height = `${canvas.height}px`;

//// Ensure pixel-perfect rendering
//ctx.imageSmoothingEnabled = false;

//// You can now draw at the logical "draw" size but scaled up
//function drawPixel(x, y, color) {
//  ctx.fillStyle = color;
//  ctx.fillRect(x * scale, y * scale, scale, scale);
//}

//// Example pixel art (draws a smiley)
//drawPixel(8, 8, "#000");
//drawPixel(23, 8, "#000");
//drawPixel(8, 24, "#000");
//drawPixel(9, 25, "#000");
//drawPixel(10, 26, "#000");
//drawPixel(11, 27, "#000");
//drawPixel(20, 24, "#000");
//drawPixel(19, 25, "#000");
//drawPixel(18, 26, "#000");
//drawPixel(17, 27, "#000");