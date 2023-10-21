using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Fractal
{
    public partial class Form : System.Windows.Forms.Form
    {
        Pen pen = new Pen(Color.Black);

        public Form()
        {
            InitializeComponent();
            SetCenterScreenMode();
        }

        private Dictionary<int, Color> colors = new Dictionary<int, Color>()
        {
            { 1, Color.Maroon }, { 2, Color.DarkMagenta }, { 3, Color.IndianRed }
        };
        private int colorNum = 1;

        /// <summary>
        /// Метод для отрисовки кривой Госпера
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        /// <param name="len">Длина</param>
        /// <param name="u">Коэффициент смещения координат для отрисовки линии</param>
        /// <param name="t">Определение плотности изображения</param>
        /// <param name="q">Коэффициент определения длины линии</param>
        void DrawGosperCurve(double x, double y, double len, double u, int t, int q, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (t > 0)
            {
                if (q == 1)
                {
                    x += len * Math.Cos(u);
                    y -= len * Math.Sin(u);
                    u += Math.PI;
                }
                u -= 2 * Math.PI / 19;
                len /= Math.Sqrt(7);

                Paint(ref x, ref y, len, u, t - 1, 0, e);
                Paint(ref x, ref y, len, u + Math.PI / 3, t - 1, 1, e);
                Paint(ref x, ref y, len, u + Math.PI, t - 1, 1, e);
                Paint(ref x, ref y, len, u + 2 * Math.PI / 3, t - 1, 0, e);
                Paint(ref x, ref y, len, u, t - 1, 0, e);
                Paint(ref x, ref y, len, u, t - 1, 0, e);
                Paint(ref x, ref y, len, u - Math.PI / 3, t - 1, 1, e);
            }
            else
            {
                g.DrawLine(new Pen(colors[colorNum], (int)len / 25), (float)Math.Round(x), (float)Math.Round(y), 
                    (float)Math.Round(x + Math.Cos(u) * len), (float)Math.Round(y - Math.Sin(u) * len));
                if (colorNum == colors.Count)
                    colorNum = 1;
                else colorNum++;
            }
        }

        private new void Paint(ref double x, ref double y, double len, double u, int t, int q, PaintEventArgs e)
        {
            DrawGosperCurve(x, y, len, u, t, q, e);
            x += len * Math.Cos(u);
            y -= len * Math.Sin(u);
        }

        /// <summary>
        /// Событие Paint
        /// </summary>
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            DrawGosperCurve(220, Panel.Height - 300, 500, 0, 5, 0, e);
        }

        private void SetCenterScreenMode()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
