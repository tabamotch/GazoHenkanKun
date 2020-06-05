using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace 画像変換くん.Converters
{
    public class CannyEdgeConverterImpl : IConverterImpl
    {
        private double _threshold1, _threshold2;

        public string LabelText => $"{nameof(CannyEdgeConverterImpl)}, threshold1={_threshold1}, threshold2={_threshold2}";

        public CannyEdgeConverterImpl(double threshold1 = 40.0d, double threshold2 = 200.0d)
        {
            _threshold1 = threshold1;
            _threshold2 = threshold2;
        }

        public Mat GetConvertImage(Mat input)
        {
            Mat result = new Mat();
            Cv2.Canny(input, result, _threshold1, _threshold2);

            return result;
        }
    }
}