﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using static Wpf3DTest.MainWindow;

namespace Project
{
    public partial class Font1 : Form
    {

        public static DialogSettings DialSet = new DialogSettings();

        public bool SecWindow = false;

        public string PathToFile = "";

		public static bool AutoGen = DialSet.AutoGenBox.Checked;

        public static int x = 0;

		public Font1()
        {

			
            InitializeComponent();
			this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2 - Size.Width / 2), Screen.PrimaryScreen.Bounds.Height / 2 - Size.Height / 2);
			AddOwnedForm(DialSet);
        }

		private void Font1_Load(object sender, EventArgs e)
        {
            
            MainPicture.Image = Properties.Resources.map5;
            this.Icon = Properties.Resources.icon;
            
        }

        /*private void Picture2D_Click(object sender, EventArgs e)
        {
            InputModule.InputText.KeyValues PictureMap = InputModule.InputText.EnterValues();
            Dictionary<string, Dictionary<string, double>> q = InputModule.Input.RunInputModule(PathToFile, PictureMap);
            List < Tuple<int[], int[], int[], int[], int[]> > lv = SorterModule.Sorter.ToDrawer(q, PictureMap, 128, 128, 0, 255, 255, 0);
            string s = "mapsnkeys//map5.png";
            DrawMap.DrawMap.PaintMap(ref s,lv.First().Item3, lv.First().Item4, lv.First().Item5, lv.First().Item1, lv.First().Item2);

        }*/
        private void Picture2D_Click(object sender, EventArgs e)
        {
			//  try
			//формат ARGB
			if (int.TryParse(DialSet.Drob.Text, out x) && (DialSet.Gradient.Checked || DialSet.Palitra.Checked))
			{
				if (x > 0 && x <= 20)
				{
					InputModule.InputText.KeyValues PictureMap = InputModule.InputText.EnterValues();
					Dictionary<string, Dictionary<string, double>> q = InputModule.Input.RunInputModule(PathToFile, PictureMap);
					List<Tuple<int[], int[], int[], int[], int[], int[], int[]>> lv = SorterModule.Sorter.ToDrawer(q, PictureMap, DialSet.Gradient.Checked);
					var bitmap = DM.PaintMap(Properties.Resources.map5, lv.First().Item3, lv.First().Item4, lv.First().Item5, lv.First().Item6, lv.First().Item1, lv.First().Item2);
					MainPicture.Image = bitmap;
					label1.Text = InputModule.Input.nam;
					double[] a = SorterModule.Sorter.FormForLegend();
					Tuple<int[], int[], int[], int[]> ffl = SorterModule.Sorter.FormForLegendColors(DialSet.Gradient.Checked);
					bitmap = DM.PaintLegend(ffl.Item1, ffl.Item2, ffl.Item3, ffl.Item4, a);
					LegendPicture.Image = bitmap;
				}
			}
            /*catch (Exception exception)
            {
                MessageBox.Show("Не верные данные " + exception.Message);
            }*/

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (MainPicture.Image != null && LegendPicture.Image != null) //если в pictureBox есть изображение
            {
                Bitmap bmp1 = new Bitmap(MainPicture.Image);
                Bitmap bmp2 = new Bitmap(LegendPicture.Image);
                Bitmap final_bmp = new Bitmap(bmp1.Width, bmp1.Height + bmp2.Height);
                Graphics g = Graphics.FromImage(final_bmp);
                g.DrawImage(bmp1, 0, 0, bmp1.Width, bmp1.Height);
                g.DrawImage(bmp2, 0, bmp1.Height, bmp2.Width, bmp2.Height);
                g.Dispose();
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files (*.BMP)|*.BMP|Image Files (*.JPG)|*.JPG|Image Files (*.PNG)|*.PNG";
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        final_bmp.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                        //MainPicture.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            
            openFileDialog1.Filter = "TXT, Excel files (*.txt; *.xlsx)|*.txt; *.xlsx";
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Открыть файл...";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

                PathToFile = openFileDialog1.FileName;

            }
        }

        private void Picture3D_Click(object sender, EventArgs e)
        {
			if (int.TryParse(DialSet.Drob.Text, out x) && (DialSet.Gradient.Checked || DialSet.Palitra.Checked))
			{
				if (x > 0 && x <= 20)
				{
					var a = new Wpf3DTest.MainWindow();
					InputModule.InputText.KeyValues PictureMap = InputModule.InputText.EnterValues();
					Dictionary<string, Dictionary<string, double>> q = InputModule.Input.RunInputModule(PathToFile, PictureMap);
					List<Tuple<int[], int[], int[], int[], int[], int[], int[]>> lv = SorterModule.Sorter.ToDrawer(q, PictureMap, DialSet.Gradient.Checked);
					a.InitializeComponent();
					for (int i = 0; i < 85; i++)
					{
						a.r[i] = lv.First().Item4[i];
						a.g[i] = lv.First().Item5[i];
						a.b[i] = lv.First().Item6[i];
						a.up[i] = -lv.First().Item7[i] * 0.1;
					}
					a.BuildSolid(a.r, a.g, a.b, a.up);
					a.turn(a.mGeometry);
					a.RenderSize = new System.Windows.Size(947,471);
					a.Width = MainPicture.Width + 14;
					a.Height = MainPicture.Height + 7;
					a.Left = Location.X + MainPicture.Location.X;
					a.Top = Location.Y + MainPicture.Location.Y + 31;
					

					//Location.X + MainPicture.Location.X, Location.Y + MainPicture.Location.Y, Location.X + MainPicture.Location.X + MainPicture.Width, Location.Y + MainPicture.Location.Y + MainPicture.Height
					a.Visibility = System.Windows.Visibility.Visible;
					label1.Text = InputModule.Input.nam;
					double[] u = SorterModule.Sorter.FormForLegend();
					Tuple<int[], int[], int[], int[]> ffl = SorterModule.Sorter.FormForLegendColors(DialSet.Gradient.Checked);
					Bitmap bitmap = DM.PaintLegend(ffl.Item1, ffl.Item2, ffl.Item3, ffl.Item4, u);
					LegendPicture.Image = bitmap;
				}
			}
		}

        private void Settings_Click(object sender, EventArgs e)
        {
            
                Point p = new Point(Location.X + Width - 15, Location.Y);
                DialSet.Location = p;
                DialSet.Visible = true;
                
               
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Font1_FormClosing(object sender, FormClosingEventArgs e)
        {
			
            System.Environment.Exit(0);
        }

        
    }
}
