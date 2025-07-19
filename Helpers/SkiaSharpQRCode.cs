using QRCoder;
using SkiaSharp;

namespace QRCoder.SkiaSharp
{
    public class SkiaSharpQRCode
    {
        private readonly QRCodeData qrCodeData;

        public SkiaSharpQRCode(QRCodeData data)
        {
            qrCodeData = data;
        }

        public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkColor, SKColor lightColor)
        {
            int size = qrCodeData.ModuleMatrix.Count * pixelsPerModule;
            var image = new SKBitmap(size, size);
            using var canvas = new SKCanvas(image);
            canvas.Clear(lightColor);

            using var paint = new SKPaint { Color = darkColor };
            for (int y = 0; y < qrCodeData.ModuleMatrix.Count; y++)
            {
                for (int x = 0; x < qrCodeData.ModuleMatrix.Count; x++)
                {
                    if (qrCodeData.ModuleMatrix[y][x])
                    {
                        canvas.DrawRect(x * pixelsPerModule, y * pixelsPerModule, pixelsPerModule, pixelsPerModule, paint);
                    }
                }
            }

            return image;
        }

        public SKBitmap GetGraphic(int pixelsPerModule = 20)
        {
            return GetGraphic(pixelsPerModule, SKColors.Black, SKColors.White);
        }
    }
}
