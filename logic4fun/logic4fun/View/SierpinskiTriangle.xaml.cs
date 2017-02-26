using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace logic4fun.View
{
    public partial class SierpinskiTriangle : ContentPage
    {
        float root = 1.73205081f;
        int step = 5; //recursion level

        public SierpinskiTriangle()
        {
            InitializeComponent();
        }

        private void OnPaintSample(object sender, SKPaintSurfaceEventArgs e)
        {
            float width = e.Info.Width;
            float height = e.Info.Height;
            float len = Math.Min(height, width);

            SKCanvas canvas = e.Surface.Canvas;

            using (var paint = new SKPaint())
            {
                paint.Color = Color.Black.ToSKColor();

                using (var path = new SKPath()) //main triangle
                {
                    path.MoveTo(len * 0.5f, 0f);
                    path.RLineTo(len / 2, 1.5f * len / root);
                    path.RLineTo(-len, 0);
                    path.Close();

                    canvas.DrawPath(path, paint);
                }
            }

            float x = len / 2;
            float y = 1.5f * len / root;

            Crop_triangle(canvas, x, y, len / 2, 0); // center
        }

        public void Crop_triangle(SKCanvas canvas, float x, float y, float len, int lvl)
        {
            using (var paint = new SKPaint())
            {
                paint.Color = Color.White.ToSKColor();
                using (var path = new SKPath())
                {
                    path.MoveTo(x, y);
                    path.RLineTo(-len / 2, -1.5f * len / root);
                    path.RLineTo(len, 0);
                    path.Close();

                    canvas.DrawPath(path, paint);
                }
            }

            if (lvl < step)
            {
                Crop_triangle(canvas, x, y - 1.5f * len / root, len / 2, lvl + 1); // top
                Crop_triangle(canvas, x - len / 2, y, len / 2, lvl + 1); // rigth
                Crop_triangle(canvas, x + len / 2, y, len / 2, lvl + 1); // left
            }
        }
    }
}

