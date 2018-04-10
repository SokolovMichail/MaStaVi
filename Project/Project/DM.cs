using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static System.Math;

namespace Project
{
	public partial class DM
	{

			public static Bitmap PaintMap(Bitmap map, int[] a, int[] r, int[] g, int[] b, int[] x, int[] y)
			{
				Color old = map.GetPixel(x[0], y[0]);
				Graphics gr = Graphics.FromImage(map);
					for (int i = 0; i < r.Length; i++)
					{
						Point p = new Point(x[i], y[i]);
						MapFill.FloodFill(gr, p, Color.FromArgb(a[i], r[i], g[i], b[i]), ref map);
					}
				gr.Dispose();
				return (map);
			}

		static string NumbersOfLegend(double a)
		{
			double b = 0;
			string l = "";
				if (a < 100000)
					l = a.ToString();
				else
				{
					b = (int)Math.Truncate(a) / 1000;
					l = b.ToString() + "K";
				}
				if (b > 1000)
				{
					b = b / 1000;
					l = b.ToString() + "M";
				}
			return (l);
		}

		public static Bitmap PaintLegend(int[] a, int[] r, int[] g, int[] b, double[] numbers)
		{
			int w = 668;  //длина легенды
			int h = 33;					//высота легенды
			int n = int.Parse(Project.Font1.DialSet.Drob.Text);     //кол-во цветов
			double MyScale = (double) w / (double)n;        //единица длины шкалы
			Bitmap res = new Bitmap(w, 43);
			try
			{
				
				Font font = new Font(new FontFamily("Arial"), 9, FontStyle.Regular);
				SolidBrush brush = new SolidBrush(Color.White);
				Pen pen = new Pen(brush, 2);
				using (Graphics gr = Graphics.FromImage(res))
				{
					//Прямоугольники
					gr.FillRectangle(brush, 0, 0, w, h + 10);
					for (int i = 0; i < n; i++)
					{
						brush.Color = Color.FromArgb(a[i], r[i], g[i], b[i]);
						gr.FillRectangle(brush, (int)Floor(i * MyScale), 0, (int)Floor((i + 1) * MyScale), (h / 3) * 2);
					}
					pen.Color = Color.Black;
					//Границы прямоугольников
					for (int i = 0; i <= n; i++)
					{
						gr.DrawLine(pen, (int)Floor(i * MyScale), 0, (int)Floor(i * MyScale), 22);
					}
					gr.DrawLine(pen, 0, 0, (int)Floor(MyScale * n), 0);
					gr.DrawLine(pen, 0, 22, (int)Floor(MyScale * n), 22);

					brush.Color = Color.Black;

					//Числа
					string t = NumbersOfLegend(numbers[0]);
					SizeF tsize = new SizeF();
					tsize = gr.MeasureString(t, font);
					gr.DrawString(t, font, brush, new PointF(0, (h / 3) * 2 + 5));
					for (int i = 1; i < n; i++)
					{
						t = NumbersOfLegend(numbers[i]);
						tsize = gr.MeasureString(t, font);
						gr.DrawString(t, font, brush, new PointF((int)Floor(MyScale * i - tsize.Width / 2), (h / 3) * 2 + 5));
					}
					t = NumbersOfLegend(numbers[n]);
					tsize = gr.MeasureString(t, font);
					gr.DrawString(t, font, brush, new PointF(w - tsize.Width, (h / 3) * 2 + 5));
				}
				font.Dispose();
				brush.Dispose();
				pen.Dispose();
			}
			catch { Project.Font1.DialSet.label3.Text = "5";}
			return (res);
		}


		public class GDI
		{
			public IntPtr CreateSolidBRUSH(uint color)
			{
				return CreateSolidBrush(color);
			}

			public bool ExtFloodFILL(IntPtr hdcSourse, int x, int y, uint сolorRefColor, uint nFillType)
			{
				return ExtFloodFill(hdcSourse, x, y, сolorRefColor, nFillType);
			}

			public IntPtr SelectOBJECT(IntPtr hDCSourse, IntPtr hBitmap)
			{
				return SelectObject(hDCSourse, hBitmap);
			}

			public IntPtr CreateCOMPATIBLEDC(IntPtr hdcSourse)
			{
				return CreateCompatibleDC(hdcSourse);
			}

			public bool DeleteOBJECT(IntPtr hObject)
			{
				return DeleteObject(hObject);
			}


			[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
			private static extern IntPtr CreateSolidBrush(uint crColor);

			[DllImport("gdi32", CharSet = CharSet.Auto)]
			private static extern bool ExtFloodFill(IntPtr hDC, int x, int y, uint сolorRefColor, uint nFillType);

			[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
			private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

			[DllImport("gdi32.dll")]
			private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

			[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
			private static extern bool DeleteObject(IntPtr hObject);
		}

		public class MapFill
		{
			public MapFill()
			{
			}
			/// <summary>
			/// Заливка области
			/// </summary>
			/// <param name="g">Графикс отображаемого объекта (например, панели)</param>
			/// <param name="pos">Точка, в которой начинается заливка</param>    
			/// <param name="colorFill">Цвет заливки</param>
			/// <param name="img">Битмап, который отображается на нашем объекте</param>
			public static void FloodFill(Graphics g, Point pos, Color colorFill, ref Bitmap img)
			{
				GDI d = new GDI();

				// Цвет в точке, с которой начинается заливка


				Color colorBegin = img.GetPixel(pos.X, pos.Y);

				// DC панели
				IntPtr panelDC = g.GetHdc();

				// DC в памяти, совместимый с панелью
				IntPtr memDC = d.CreateCOMPATIBLEDC(panelDC);

				// Создаем и подсовываем свою кисть
				IntPtr hBrush = d.CreateSolidBRUSH((uint)ColorTranslator.ToWin32(colorFill));
				IntPtr hOldBr = d.SelectOBJECT(memDC, hBrush);

				// Подсовываем свой битмап
				IntPtr hBMP = img.GetHbitmap();
				IntPtr hOldBmp = d.SelectOBJECT(memDC, hBMP);

				// Заливаем (заливается благодаря совместимости с панелью, в противном случае 
				// заливки на битмапе не произойдет)
				d.ExtFloodFILL(memDC, pos.X, pos.Y, (uint)ColorTranslator.ToWin32(colorBegin), 1);

				// Записываем полученный залитый битмап в наш битмап
				img.Dispose();
				img = Bitmap.FromHbitmap(hBMP);

				// Возвращаем на место предыдущие кисть и битмап
				d.SelectOBJECT(memDC, hOldBr);
				d.SelectOBJECT(memDC, hOldBmp);

				// Освобождаем использованные ресурсы
				d.DeleteOBJECT(hBMP);
				d.DeleteOBJECT(hBrush);
				d.DeleteOBJECT(memDC);
				g.ReleaseHdc(panelDC);
			}
		}
	}

}

