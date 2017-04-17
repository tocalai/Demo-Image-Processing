using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4DSensorDemo
{

    public class ColorHelper
    {
        private static readonly Lazy<ColorHelper> LazyInstance = new Lazy<ColorHelper>(() => new ColorHelper());

        public static ColorHelper Instance { get { return LazyInstance.Value; } }

        public const double milimetresPerInch = 25.4; // as one inch is 25.4 mm

        public ColorHelper()
        {

        }

        /// <summary>
        /// Changed the brightness of color
        /// </summary>
        /// <param name="color">input color</param>
        /// <param name="factor">range for 1(lightest) to -1(darkest)</param>
        /// <returns></returns>
        public Color ChangeColorBrightness(Color color, float factor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (factor < 0)
            {
                factor = 1 + factor;
                red *= factor;
                green *= factor;
                blue *= factor;
            }
            else
            {
                red = (255 - red) * factor + red;
                green = (255 - green) * factor + green;
                blue = (255 - blue) * factor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }
    }
}
