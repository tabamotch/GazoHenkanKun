using OpenCvSharp;

namespace 画像変換くん.Converters
{
    public class RinkakuExtractImpl : IConverterImpl
    {
        public string LabelText => "輪郭抽出";
        public Mat GetConvertImage(Mat input)
        {
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            input = input.CvtColor(ColorConversionCodes.BGR2GRAY);

            //輪郭検出  
            Cv2.FindContours(input, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            Mat result = input.CvtColor(ColorConversionCodes.GRAY2BGR);

            for (int i = 0; i < contours.Length; i++)
            {
                Cv2.DrawContours(result, contours, i, Scalar.Red, 2, LineTypes.Link8, hierarchy, 0);
            }

            return result;
        }
    }
}