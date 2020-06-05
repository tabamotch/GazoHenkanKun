using System.Data;
using OpenCvSharp;

namespace 画像変換くん.Converters
{
    public class AdaptiveThresholdConterterImpl : IConverterImpl
    {
        private int _blockSize;

        private double _c;

        public string LabelText => $"{nameof(AdaptiveThresholdConterterImpl)}, BlockSize={_blockSize}, c={_c}";

        public AdaptiveThresholdConterterImpl(int blockSize = 9, double c = 12d)
        {
            _blockSize = blockSize;
            _c = c;
        }

        public Mat GetConvertImage(Mat input)
        {
            Mat result = new Mat();
            Cv2.CvtColor(input, result, ColorConversionCodes.BGR2GRAY);
            Cv2.AdaptiveThreshold(result, result, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, _blockSize, _c);

            Cv2.CvtColor(result, result, ColorConversionCodes.GRAY2BGR);

            return result;
        }
    }
}