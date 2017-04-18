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
    public partial class FormQ1_1 : Form
    {
        public FormQ1_1()
        {
            InitializeComponent();
        }

   
        private void FormQ1_1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();

            graphicsObj.PageUnit = GraphicsUnit.Millimeter;
            graphicsObj.Clear(Color.White);

            var heightInMilimeter = this.ClientSize.Height / graphicsObj.DpiY * ColorHelper.milimetresPerInch;
            var widthInMilimeter = this.ClientSize.Width / graphicsObj.DpiX * ColorHelper.milimetresPerInch;

            // start with pure white
            var colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, 1);
            Pen blackPen = new Pen(colorChangedBrightness, 1f);
            Pen whitePen = new Pen(Color.White, 1f);

            List<LinePair> list = new List<LinePair>();

            Point L1sPoint = new Point(1, 1);
            Point L1ePoint = new Point(1, (int)Math.Round(heightInMilimeter) - 1);
            LinePair firstPair = new LinePair()
            {
                BlackSPoint = L1sPoint,
                BlackEPoint = L1ePoint,
                WhiteSPoint = new PointF(L1sPoint.X + whitePen.Width, L1sPoint.Y),
                WhiteEPoint = new PointF(L1ePoint.X + whitePen.Width, L1ePoint.Y)
            };

            list.Add(firstPair);

            // draw the first pair
            graphicsObj.DrawLine(blackPen, firstPair.BlackSPoint, firstPair.BlackEPoint);
            graphicsObj.DrawLine(whitePen, firstPair.WhiteSPoint, firstPair.WhiteEPoint);
            var cycleCount = (int)((widthInMilimeter / (blackPen.Width + whitePen.Width)));
            for (int cycle = 1; cycle < cycleCount; cycle++)
            {
                Debug.Assert(list.Count > 0, "List must bigger than zero");

                var unit = (1 - (-1)) / (widthInMilimeter);
                var round = Math.Floor((widthInMilimeter));
                var mutiple = cycleCount > round ? 1 : round / cycleCount;// let the brightness changed more significantly

                // calculate the factor of brightness, changed from light to black
                var factor = (float)((1 - cycle * mutiple * unit));
                colorChangedBrightness = ColorHelper.Instance.ChangeColorBrightness(Color.Black, factor);
                blackPen.Color = colorChangedBrightness;

                Debug.WriteLine(string.Format("cycle = {0}, factor = {1}", cycle, factor));

                var preSet = list[list.Count - 1];
                PointF LnsPoint = new PointF(preSet.WhiteSPoint.X + whitePen.Width, preSet.WhiteSPoint.Y);
                PointF LnePoint = new PointF(preSet.WhiteEPoint.X + whitePen.Width, preSet.WhiteEPoint.Y);
                LinePair newPair = new LinePair()
                {
                    BlackSPoint = LnsPoint,
                    BlackEPoint = LnePoint,
                    WhiteSPoint = new PointF(LnsPoint.X + blackPen.Width, LnsPoint.Y),
                    WhiteEPoint = new PointF(LnePoint.X + blackPen.Width, LnePoint.Y)
                };

                graphicsObj.DrawLine(blackPen, newPair.BlackSPoint, newPair.BlackEPoint);
                graphicsObj.DrawLine(whitePen, newPair.WhiteSPoint, newPair.WhiteEPoint);


                list.Add(newPair);
          
                
            }
        }
    }

}
