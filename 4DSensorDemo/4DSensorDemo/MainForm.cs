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

namespace _4DSensorDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Q1_1_Button_Click(object sender, EventArgs e)
        {
            var form = new FormQ1_1();
            form.ShowDialog();
        }

        private void Q1_2_Button_Click(object sender, EventArgs e)
        {
            var form = new FormQ1_2();
            form.ShowDialog();
        }

        const int threshold = 10;
        private async void Q2_1_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //var filePath = @"D:\Interview\4D\4DSensorDemo\Sample\Input\sample2.png";

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff" + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
                dialog.Title = "Select a image file";

                var dirPath = (Directory.GetParent(Application.StartupPath)).Parent.Parent.FullName;

                dialog.InitialDirectory = Path.Combine(dirPath, @"Sample\Input");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Noise1_LinkLabel.Visible = false;
                    Action_Label.Text = "Processing...wait";
                    EanbleControls(false);

                    var targetImage = Image.FromFile(dialog.FileName);
                    Bitmap processImage = new Bitmap(targetImage);

                    int[] surroundings = new int[] { -1, -1, -1, -1, -1 };// store the left, top. right, bottom and center brightness

                    var outputPath = Path.Combine(dirPath, @"Sample\Output\") + Path.GetFileNameWithoutExtension(dialog.FileName) + "_" + Guid.NewGuid().ToString("N")  + Path.GetExtension(dialog.FileName);
                    await Task.Factory.StartNew(() => ProcessNoise(processImage, threshold, surroundings, outputPath));

                    Action_Label.Text = "Completed";
                    Noise1_LinkLabel.Text = outputPath;
                    Noise1_LinkLabel.Visible = true;
                }
                else
                {
                    Action_Label.Text = "User canceled";
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Exception occured: {0}", ex.Message));
            }
            finally
            {
                EanbleControls(true);
            }
        }

        private async void Q2_2_Button_Click(object sender, EventArgs e)
        {
            try
            {
               
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff" + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
                dialog.Title = "Select a image file";

                var dirPath = (Directory.GetParent(Application.StartupPath)).Parent.Parent.FullName;

                dialog.InitialDirectory = Path.Combine(dirPath, @"Sample\Input");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Noise2_LinkLabel.Visible = false;
                    Action_Label.Text = "Processing...wait";
                    EanbleControls(false);

                    var targetImage = Image.FromFile(dialog.FileName);

                    Bitmap processImage = new Bitmap(targetImage);

                    int[] surroundings = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 , -1};

                    var outputPath = Path.Combine(dirPath, @"Sample\Output\") + Path.GetFileNameWithoutExtension(dialog.FileName) + "_" + Guid.NewGuid().ToString("N") + Path.GetExtension(dialog.FileName);
                    await Task.Factory.StartNew(() => ProcessNoise(processImage, threshold, surroundings, outputPath));

                    Action_Label.Text = "Completed";
                    Noise2_LinkLabel.Text = outputPath;
                    Noise2_LinkLabel.Visible = true;
                }
                else
                {
                    Action_Label.Text = "User canceled";
                }

    
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception occured: {0}", ex.Message));
            }
            finally
            {
                EanbleControls(true);
            }
        }

        private void ProcessNoise(Bitmap image, int threshold, int[] surroundings, string outputPath)
        {
            Bitmap newImage = new Bitmap(image);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    surroundings[(int)SurroundingEnum.Center]= CalculateBrightness(image, x, y);
                    surroundings[(int)SurroundingEnum.Left] = x - 1 < 0 ? -1 : CalculateBrightness(image, x - 1, y);
                    surroundings[(int)SurroundingEnum.Top] = y - 1 < 0 ? -1 : CalculateBrightness(image, x, y - 1);
                    surroundings[(int)SurroundingEnum.Right] = x + 1 > image.Width - 1 ? -1 : CalculateBrightness(image, x + 1, y);
                    surroundings[(int)SurroundingEnum.Bottom] = y + 1 > image.Height - 1 ? -1 : CalculateBrightness(image, x, y + 1);

                    int avgBrightness = -1;
                    int adjustBrightness = -1;

                    switch (surroundings.Length)
                    {
                        case 5:
                            avgBrightness = surroundings.ToList().GetRange(0, 4).Where(s => s != -1).Sum() / surroundings.ToList().GetRange(0, 4).Where(s => s != -1).Count();
                            if (Math.Abs(surroundings[(int)SurroundingEnum.Center] - avgBrightness) > threshold)
                            {
                                adjustBrightness = avgBrightness - surroundings[(int)SurroundingEnum.Center];

                                var pixelR = (newImage.GetPixel(x, y).R + adjustBrightness) > 255 ? 255 : (newImage.GetPixel(x, y).R + adjustBrightness) < 0 ? 0 : (newImage.GetPixel(x, y).R + adjustBrightness);
                                var pixelG = (newImage.GetPixel(x, y).G + adjustBrightness) > 255 ? 255 : (newImage.GetPixel(x, y).G + adjustBrightness) < 0 ? 0 : (newImage.GetPixel(x, y).G + adjustBrightness);
                                var pixelB = (newImage.GetPixel(x, y).B + adjustBrightness) > 255 ? 255 : (newImage.GetPixel(x, y).B + adjustBrightness) < 0 ? 0 : (newImage.GetPixel(x, y).B + adjustBrightness);

                                newImage.SetPixel(x, y, Color.FromArgb(pixelR, pixelG, pixelB));

                            }
                            break;
                        case 9:
                            surroundings[(int)SurroundingEnum.LeftTop] = x - 1 < 0 || y - 1 < 0 ? -1 : CalculateBrightness(image, x - 1, y - 1);
                            surroundings[(int)SurroundingEnum.RightTop] = y - 1 < 0 || x + 1 > image.Width - 1 ? -1 : CalculateBrightness(image, x + 1, y - 1);
                            surroundings[(int)SurroundingEnum.LeftBottom] = x - 1 < 0 || y + 1  > image.Height - 1 ? -1 : CalculateBrightness(image, x - 1, y +1);
                            surroundings[(int)SurroundingEnum.RightBottom] = x + 1 > image.Width - 1 || y + 1 > image.Height - 1 ? -1 : CalculateBrightness(image, x + 1, y +1);

                            avgBrightness = surroundings.Where(s => s != -1).Sum() / (surroundings.Where(s => s != -1).Count());
                            if (Math.Abs(surroundings[(int)SurroundingEnum.Center] - avgBrightness) > threshold)
                            {
                                Array.Sort(surroundings, (v1, v2 )=> { return v1 < v2 ? -1 : v1 > v2 ? 1 : 0; }); // sort by descending
                                var validateCount = surroundings.Where(v => v != -1).Count();
                               if (validateCount == 9)
                                {
                                    adjustBrightness = (surroundings.ToList().GetRange(2, 5).Sum() / 5) - surroundings[(int)SurroundingEnum.Center];
                                    var pixelR = (newImage.GetPixel(x, y).R + adjustBrightness) > 255 ? 255 : (newImage.GetPixel(x, y).R + adjustBrightness) < 0 ? 0 : (newImage.GetPixel(x, y).R + adjustBrightness);
                                    var pixelG = (newImage.GetPixel(x, y).G + adjustBrightness) > 255 ? 255 : (newImage.GetPixel(x, y).G + adjustBrightness) < 0 ? 0 : (newImage.GetPixel(x, y).G + adjustBrightness);
                                    var pixelB = (newImage.GetPixel(x, y).B + adjustBrightness) > 255 ? 255 : (newImage.GetPixel(x, y).B + adjustBrightness) < 0 ? 0 : (newImage.GetPixel(x, y).B + adjustBrightness);

                                    newImage.SetPixel(x, y, Color.FromArgb(pixelR, pixelG, pixelB));
                                    //newImage.SetPixel(x, y, Color.LightGreen);
                                }

                            }
                            break;
                    }
                               
                }
            }

            // save to ouput
            //newImage.Save(@"D:\Interview\4D\4DSensorDemo\Sample\Output\sample2.png");
            newImage.Save(outputPath);
        }

        private int CalculateBrightness(Bitmap image, int coordX, int coordY)
        {
            return (int)(0.21 * (image.GetPixel(coordX, coordY).R) +
                0.72 * (image.GetPixel(coordX, coordY).G) +
                0.07 * (image.GetPixel(coordX, coordY).B));
        }

        private void EanbleControls(bool isEnable)
        {
            Q1_1_Button.Enabled = isEnable;
            Q1_2_Button.Enabled = isEnable;
            Q2_1_Button.Enabled = isEnable;
            Q2_2_Button.Enabled = isEnable;
            Noise1_LinkLabel.Enabled = isEnable;
            Noise2_LinkLabel.Enabled = isEnable;

            Action_Label.Focus();
        }

        public enum SurroundingEnum : int
        {
            Left = 0,
            Top,
            Right,
            Bottom,
            Center,
            LeftTop,
            RightTop,
            LeftBottom,
            RightBottom,
        }

        private void Noise2_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void Noise1_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }
    }
}
