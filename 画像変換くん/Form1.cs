using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using 画像変換くん.Converters;

namespace 画像変換くん
{
    public partial class Form1 : Form
    {
        private Mat _currentMat = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<IConverterImpl> implList = new List<IConverterImpl>();
            implList.Add(new AdaptiveThresholdConterterImpl());
            implList.Add(new CannyEdgeConverterImpl());
            implList.Add(new CannyEdgeConverterImpl(20d, 220d));
            implList.Add(new CannyEdgeConverterImpl(70d, 170d));
            implList.Add(new LaplacianConverterImpl());
            implList.Add(new RinkakuExtractImpl());
            implList.Add(new MorphologyConverterImpl(MorphTypes.Erode));
            implList.Add(new MorphologyConverterImpl(MorphTypes.Dilate));
            implList.Add(new MorphologyConverterImpl(MorphTypes.Gradient));
            implList.Add(new HoughLinesPConverterImpl());

            foreach (IConverterImpl item in implList)
            {
                comboBox1.Items.Add(item);
            }

            comboBox1.DataSource = implList;
            comboBox1.DisplayMember = nameof(IConverterImpl.LabelText);
        }

        private void fileSanshoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                textBox1.Text = dialog.FileName;
            }
        }

        private void readImageButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show(this, "指定された画像ファイルが見つかりません。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Mat input = Cv2.ImRead(textBox1.Text);
            SetImage(input);
        }

        private void henkanButton_Click(object sender, EventArgs e)
        {
            IConverterImpl impl = (IConverterImpl) comboBox1.SelectedItem;
            Mat result = impl.GetConvertImage(_currentMat);
            result.ConvertTo(result, MatType.CV_8UC3);

            SetImage(result);
        }

        private void SetImage(Mat input)
        {
            pictureBox1.Image = input.ToBitmap();
            _currentMat?.Dispose();
            _currentMat = input;
        }
    }
}
