using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace 画像変換くん.Converters
{
    public class LaplacianConverterImpl : IConverterImpl
    {
        private readonly MatType _matType = MatType.CV_8U;

        public string LabelText => $"{nameof(LaplacianConverterImpl)}, MatType={_matType}";

        public Mat GetConvertImage(Mat input)
        {
            Mat result = new Mat();
            Cv2.Laplacian(input, result, MatType.CV_8U);

            return result;
        }
    }
}