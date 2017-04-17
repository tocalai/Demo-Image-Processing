using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4DSensorDemo
{
    public partial class FormQ1_2 : Form
    {
        public FormQ1_2()
        {
            InitializeComponent();
        }

        private void FormQ1_2_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();

            graphicsObj.PageUnit = GraphicsUnit.Millimeter;
            graphicsObj.Clear(Color.White);

            var heightInMilimeter = this.ClientSize.Height / graphicsObj.DpiY * ColorHelper.milimetresPerInch;
            var widthInMilimeter = this.ClientSize.Width / graphicsObj.DpiX * ColorHelper.milimetresPerInch;

            // factor begin with 1 for lightest
            var colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, 1);
            Pen blackPen = new Pen(colorChangedBrightness, 1f);
            Pen whitePen = new Pen(Color.White, 1f);

            List<LinePair> list = new List<LinePair>();

            Point L1sPoint = new Point(1, 1);
            Point L1ePoint = new Point((int)Math.Round(widthInMilimeter, MidpointRounding.AwayFromZero) - 1, 1);
            LinePair firstPair = new LinePair()
            {
                BlackSPoint = L1sPoint,
                BlackEPoint = L1ePoint,
                WhiteSPoint = new PointF((float)L1sPoint.X, (float)L1sPoint.Y + blackPen.Width),
                WhiteEPoint = new PointF((float)L1ePoint.X, (float)L1ePoint.Y + blackPen.Width)
            };

            list.Add(firstPair);

            graphicsObj.DrawLine(blackPen, firstPair.BlackSPoint, firstPair.BlackEPoint);
            graphicsObj.DrawLine(whitePen, firstPair.WhiteSPoint, firstPair.WhiteEPoint);

            var cycleCount = (int)(heightInMilimeter / (blackPen.Width + whitePen.Width));
            for (int cycle = 1; cycle < cycleCount; cycle++)
            {
                Debug.Assert(list.Count > 0, "List must bigger than zero");

                var halfCount = Math.Floor((double)cycleCount / 2);
                float factor = 0;
                var unit = (1 - (-1)) / (heightInMilimeter / 2);
                var round = Math.Floor((heightInMilimeter / 2 / 2));
                float multiple = halfCount  > 2 * round ? 1 : ((float)halfCount * 2) / (float)(heightInMilimeter / 2 / 2);
                if (cycle <= halfCount)
                {

                    factor = (float)(1 - cycle * multiple * unit);
                    colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, factor);                   
                }
                else
                {
                    factor = (float)(-1 + (cycle - halfCount) * multiple * unit);
                    colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, factor);
                }

                Debug.WriteLine(string.Format("H-cycle = {0}, factor = {1}", cycle, factor));
                blackPen.Color = colorChangedBrightness;

                var preSet = list[list.Count - 1];
                PointF LnsPoint = new PointF((float)preSet.WhiteSPoint.X, preSet.WhiteSPoint.Y + (float)whitePen.Width);
                PointF LnePoint = new PointF((float)preSet.WhiteEPoint.X, preSet.WhiteEPoint.Y + (float)whitePen.Width);
                LinePair newPair = new LinePair()
                {
                    BlackSPoint = LnsPoint,
                    BlackEPoint = LnePoint,
                    WhiteSPoint = new PointF((float)LnsPoint.X, (float)LnsPoint.Y + blackPen.Width),
                    WhiteEPoint = new PointF((float)LnePoint.X, (float)LnePoint.Y + blackPen.Width)
                };

                graphicsObj.DrawLine(blackPen, newPair.BlackSPoint, newPair.BlackEPoint);
                graphicsObj.DrawLine(whitePen, newPair.WhiteSPoint, newPair.WhiteEPoint);

                list.Add(newPair);
            }


            colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, 1);
            Color black_V = Color.FromArgb(255, colorChangedBrightness);
            Color white_V = Color.FromArgb(0, Color.White); 

            blackPen = new Pen(black_V, 1f);
            whitePen = new Pen(white_V, 1f);

            Point L1sPoint_v = new Point(1, 1);
            Point L1ePoint_V = new Point(1, (int)Math.Round(heightInMilimeter, MidpointRounding.AwayFromZero));
            LinePair firstPair_V = new LinePair()
            {
                BlackSPoint = L1sPoint_v,
                BlackEPoint = L1ePoint_V,
                WhiteSPoint = new PointF((float)L1sPoint_v.X + blackPen.Width, (float)L1sPoint_v.Y),
                WhiteEPoint = new PointF((float)L1ePoint_V.X + blackPen.Width, (float)L1ePoint_V.Y)
            };

            list.Add(firstPair_V);

            graphicsObj.DrawLine(blackPen, firstPair_V.BlackSPoint, firstPair_V.BlackEPoint);
            graphicsObj.DrawLine(whitePen, firstPair_V.WhiteSPoint, firstPair_V.WhiteEPoint);

            var cycleCountV = (int)(widthInMilimeter / (blackPen.Width + whitePen.Width));
            for (int cycle = 1; cycle < cycleCountV; cycle++)
            {
                Debug.Assert(list.Count > 0, "List must bigger than zero");

                var halfCount = Math.Floor((double)cycleCountV / 2);
                float factor = 0;
                var unit = (1 - (-1)) / (widthInMilimeter / 2);
                var round = Math.Floor((widthInMilimeter / 2 / 2));
                float multiple = halfCount > 2 * round ? 1 : ((float)halfCount * 2) / (float)(widthInMilimeter / 2 / 2);
                if (cycle <= halfCount)
                {

                    factor = (float)(1 - cycle * multiple * unit);
                    colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, factor);
                }
                else
                {
                    factor = (float)(-1 + (cycle - halfCount) * multiple * unit);
                    colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, factor);
                }

                Debug.WriteLine(string.Format("V-cycle = {0}, factor = {1}", cycle, factor));
                blackPen.Color = colorChangedBrightness;

                var preSet = list[list.Count - 1];
                PointF LnsPoint = new PointF((float)preSet.WhiteSPoint.X + (float)whitePen.Width, preSet.WhiteSPoint.Y);
                PointF LnePoint = new PointF((float)preSet.WhiteEPoint.X + (float)whitePen.Width, preSet.WhiteEPoint.Y);
                LinePair newPair = new LinePair()
                {
                    BlackSPoint = LnsPoint,
                    BlackEPoint = LnePoint,
                    WhiteSPoint = new PointF((float)LnsPoint.X + blackPen.Width, (float)LnsPoint.Y),
                    WhiteEPoint = new PointF((float)LnePoint.X + blackPen.Width, (float)LnePoint.Y)
                };

                graphicsObj.DrawLine(blackPen, newPair.BlackSPoint, newPair.BlackEPoint);
                graphicsObj.DrawLine(whitePen, newPair.WhiteSPoint, newPair.WhiteEPoint);


                list.Add(newPair);


            }
        }
    }
}
