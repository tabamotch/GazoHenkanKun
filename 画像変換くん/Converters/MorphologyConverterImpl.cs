using OpenCvSharp;

namespace 画像変換くん.Converters
{
    public class MorphologyConverterImpl : IConverterImpl
    {
        private MorphTypes _morphTypes;

        public string LabelText => $"{nameof(MorphologyConverterImpl)}, MorphTypes={_morphTypes}";

        public MorphologyConverterImpl(MorphTypes morphTypes = MorphTypes.Erode)
        {
            _morphTypes = morphTypes;
        }

        public Mat GetConvertImage(Mat input)
        {
            input.ConvertTo(input, MatType.CV_8UC1);

            Mat result = new Mat();
            Cv2.MorphologyEx(input, result, _morphTypes, null);

            return result;
        }
    }
}