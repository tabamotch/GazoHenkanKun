using System;
using OpenCvSharp;

namespace 画像変換くん.Converters
{
    public class HoughLinesPConverterImpl : IConverterImpl
    {
        public string LabelText { get; } = "確率的ハフ変換";
        public Mat GetConvertImage(Mat input)
        {
            Mat gray = new Mat();

            if (input.Channels() != 1)
            {
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            }
            else
            {
                input.CopyTo(gray);
            }

            var lines = Cv2.HoughLinesP(gray, 1, Math.PI / (4 * 180), 70, 150);

            Cv2.CvtColor(gray, gray, ColorConversionCodes.GRAY2BGR);

            foreach (var line in lines)
            {
                Cv2.Line(gray, line.P1, line.P2, Scalar.Red, 2, LineTypes.AntiAlias);
            }

            return gray;
        }
    }
}