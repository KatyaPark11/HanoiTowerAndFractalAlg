using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Dictionary<int, Color> colors = new Dictionary<int, Color>()
        {
            { 1, Color.DeepPink }, { 2, Color.DarkMagenta }, { 3, Color.HotPink }
        };
        private int colorNum = 1;

        public Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод, который отрисовывает наши ветки
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        /// <param name="len">Длина</param>
        /// <param name="angle">Угол поворота</param>

        public void DrawFractal(int x, int y, int len, double angle, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            double x1, y1; 
            x1 = x + len * Math.Sin(angle * Math.PI * 2 / 360.0); 
            y1 = y + len * Math.Cos(angle * Math.PI * 2 / 360.0); 
            g.DrawLine(new Pen(colors[colorNum], len/25), x, panel1.Height - y, (int)x1, panel1.Height - (int)y1);
            if (colorNum == colors.Count)
                colorNum = 1;
            else colorNum++;

            if (len > 17) 
            {
                DrawFractal((int)x1, (int)y1, (int)(len / 1.5), angle + 35, e);
                DrawFractal((int)x1, (int)y1, (int)(len / 1.5), angle - 35, e); 
                DrawFractal((int)x1, (int)y1, (int)(len / 1.5), angle + 15, e);
                DrawFractal((int)x1, (int)y1, (int)(len / 1.5), angle - 15, e);
            }
        }

        /// <summary>
        /// Событие Paint
        /// </summary>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawFractal(panel1.Width/2,0,200,0,e);
        }
    }
}
