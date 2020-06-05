using System.Drawing;
using OpenCvSharp;

namespace 画像変換くん.Converters
{
    public interface IConverterImpl
    {
        string LabelText { get; }

        Mat GetConvertImage(Mat input);
    }
}