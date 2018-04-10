
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;

using System.Windows.Media.Media3D;

namespace Wpf3DTest {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public GeometryModel3D[] mGeometry = new GeometryModel3D[85];
        public bool mDown;
		public System.Windows.Point mLastPos;
		public int[] r = new int[85];
		public int[] g = new int[85];
		public int[] b = new int[85];
		public double[] up = new double[85];

		public MainWindow() {
            InitializeComponent();
            
            
            Random ran = new Random();
            for (int i = 0; i < 85; i++)
            {
                //up[i] = -0.3+ran.Next(10)/100.0*(-1);
                r[i] = ran.Next(255);
                g[i] = ran.Next(255);
                b[i] = ran.Next(255);
            }
            //BuildSolid(r, g, b, up);
            //turn(mGeometry);
            
        }
        static void Tri(MeshGeometry3D mesh, int one, int two, int three)
        {
            mesh.TriangleIndices.Add(one);
            mesh.TriangleIndices.Add(two);
            mesh.TriangleIndices.Add(three);
        }
        static void DTri(MeshGeometry3D mesh, int one, int two, int three)
        {
            Tri(mesh, one, two, three);
            Tri(mesh, one, three, two);
        }
        static void DDTri(MeshGeometry3D mesh, int one, int two, int three, int n)
        {
            DTri(mesh, one, two, three);
            DTri(mesh, one+n, two+n, three+n);
        }
        static void Make_Regions(/*MeshGeometry3D[] mesh*/
            MeshGeometry3D mesh1, MeshGeometry3D mesh2, MeshGeometry3D mesh3, MeshGeometry3D mesh4, MeshGeometry3D mesh5, MeshGeometry3D mesh6, MeshGeometry3D mesh7, MeshGeometry3D mesh8,
            MeshGeometry3D mesh9, MeshGeometry3D mesh10, MeshGeometry3D mesh11, MeshGeometry3D mesh12, MeshGeometry3D mesh13, MeshGeometry3D mesh14, MeshGeometry3D mesh15, MeshGeometry3D mesh16,
            MeshGeometry3D mesh17, MeshGeometry3D mesh18, MeshGeometry3D mesh19, MeshGeometry3D mesh20, MeshGeometry3D mesh21, MeshGeometry3D mesh22, MeshGeometry3D mesh23, MeshGeometry3D mesh24,
            MeshGeometry3D mesh25, MeshGeometry3D mesh26, MeshGeometry3D mesh27, MeshGeometry3D mesh28, MeshGeometry3D mesh29, MeshGeometry3D mesh30, MeshGeometry3D mesh31, MeshGeometry3D mesh32,
            MeshGeometry3D mesh33, MeshGeometry3D mesh34, MeshGeometry3D mesh35, MeshGeometry3D mesh36, MeshGeometry3D mesh37, MeshGeometry3D mesh38, MeshGeometry3D mesh39, MeshGeometry3D mesh40,
            MeshGeometry3D mesh41, MeshGeometry3D mesh42, MeshGeometry3D mesh43, MeshGeometry3D mesh44, MeshGeometry3D mesh45, MeshGeometry3D mesh46, MeshGeometry3D mesh47, MeshGeometry3D mesh48,
            MeshGeometry3D mesh49, MeshGeometry3D mesh50, MeshGeometry3D mesh51, MeshGeometry3D mesh52, MeshGeometry3D mesh53, MeshGeometry3D mesh54, MeshGeometry3D mesh55, MeshGeometry3D mesh56,
            MeshGeometry3D mesh57, MeshGeometry3D mesh58, MeshGeometry3D mesh59, MeshGeometry3D mesh60, MeshGeometry3D mesh61, MeshGeometry3D mesh62, MeshGeometry3D mesh63, MeshGeometry3D mesh64,
            MeshGeometry3D mesh65, MeshGeometry3D mesh66, MeshGeometry3D mesh67, MeshGeometry3D mesh68, MeshGeometry3D mesh69, MeshGeometry3D mesh70, MeshGeometry3D mesh71, MeshGeometry3D mesh72,
            MeshGeometry3D mesh73, MeshGeometry3D mesh74, MeshGeometry3D mesh75, MeshGeometry3D mesh76, MeshGeometry3D mesh77, MeshGeometry3D mesh78, MeshGeometry3D mesh79, MeshGeometry3D mesh80,
            MeshGeometry3D mesh81, MeshGeometry3D mesh82, MeshGeometry3D mesh83, MeshGeometry3D mesh84, MeshGeometry3D mesh85, double[] up)
        {
            double w = 1024;
            double h = 533;
            double s = 5;
            //Севастополь
            mesh1.Positions.Add(new Point3D(7 / w * s, 299 / h * s, 0));
            mesh1.Positions.Add(new Point3D(7 / w * s, 305 / h * s, 0));
            mesh1.Positions.Add(new Point3D(14 / w * s, 305 / h * s, 0));
            mesh1.Positions.Add(new Point3D(13 / w * s, 299 / h * s, 0));
            //
            mesh1.Positions.Add(new Point3D(7 / w * s, 299 / h * s, up[0]));
            mesh1.Positions.Add(new Point3D(7 / w * s, 305 / h * s, up[0]));
            mesh1.Positions.Add(new Point3D(14 / w * s, 305 / h * s, up[0]));
            mesh1.Positions.Add(new Point3D(13 / w * s, 299 / h * s, up[0]));
            //Крым
            //mesh2.Positions.Add(new Point3D(7 / w * s, 299 / h * s, 0));
            //mesh2.Positions.Add(new Point3D(7 / w * s, 305 / h * s, 0));
            //mesh2.Positions.Add(new Point3D(14 / w * s, 305 / h * s, 0));
            //mesh2.Positions.Add(new Point3D(13 / w * s, 299 / h * s, 0));
            mesh2.Positions.Add(new Point3D(5 / w * s, 287 / h * s, 0));
            mesh2.Positions.Add(new Point3D(22 / w * s, 294 / h * s, 0));
            mesh2.Positions.Add(new Point3D(20 / w * s, 308 / h * s, 0));
            mesh2.Positions.Add(new Point3D(27 / w * s, 320 / h * s, 0));
            mesh2.Positions.Add(new Point3D(23 / w * s, 323 / h * s, 0));
            mesh2.Positions.Add(new Point3D(10 / w * s, 311 / h * s, 0));
            mesh2.Positions.Add(new Point3D(2 / w * s, 310 / h * s, 0));
            mesh2.Positions.Add(new Point3D(1 / w * s, 303 / h * s, 0));
            //
            //mesh2.Positions.Add(new Point3D(7 / w * s, 299 / h * s, up[1]));
            //mesh2.Positions.Add(new Point3D(7 / w * s, 305 / h * s, up[1]));
            //mesh2.Positions.Add(new Point3D(14 / w * s, 305 / h * s, up[1]));
            //mesh2.Positions.Add(new Point3D(13 / w * s, 299 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(5 / w * s, 287 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(22 / w * s, 294 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(20 / w * s, 308 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(27 / w * s, 320 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(23 / w * s, 323 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(10 / w * s, 311 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(2 / w * s, 310 / h * s, up[1]));
            mesh2.Positions.Add(new Point3D(1 / w * s, 303 / h * s, up[1]));
            //Краснодарский край
            mesh3.Positions.Add(new Point3D(26 / w * s, 329 / h * s, 0));
            mesh3.Positions.Add(new Point3D(35 / w * s, 334 / h * s, 0));
            mesh3.Positions.Add(new Point3D(55 / w * s, 330 / h * s, 0));
            mesh3.Positions.Add(new Point3D(63 / w * s, 355 / h * s, 0));
            mesh3.Positions.Add(new Point3D(50 / w * s, 372 / h * s, 0));
            mesh3.Positions.Add(new Point3D(35 / w * s, 374 / h * s, 0));
            mesh3.Positions.Add(new Point3D(28 / w * s, 369 / h * s, 0));
            //mesh3.Positions.Add(new Point3D(32 / w * s, 364 / h * s, 0));
            //mesh3.Positions.Add(new Point3D(41 / w * s, 355 / h * s, 0));
            //mesh3.Positions.Add(new Point3D(34 / w * s, 348 / h * s, 0));
            //mesh3.Positions.Add(new Point3D(38 / w * s, 344 / h * s, 0));
            //mesh3.Positions.Add(new Point3D(50 / w * s, 356 / h * s, 0));
            //mesh3.Positions.Add(new Point3D(39 / w * s, 367 / h * s, 0));
            //
            mesh3.Positions.Add(new Point3D(26 / w * s, 329 / h * s, up[2]));
            mesh3.Positions.Add(new Point3D(35 / w * s, 334 / h * s, up[2]));
            mesh3.Positions.Add(new Point3D(55 / w * s, 330 / h * s, up[2]));
            mesh3.Positions.Add(new Point3D(63 / w * s, 355 / h * s, up[2]));
            mesh3.Positions.Add(new Point3D(50 / w * s, 372 / h * s, up[2]));
            mesh3.Positions.Add(new Point3D(35 / w * s, 374 / h * s, up[2]));
            mesh3.Positions.Add(new Point3D(28 / w * s, 369 / h * s, up[2]));
            //mesh3.Positions.Add(new Point3D(32 / w * s, 364 / h * s, up[2]));
            //mesh3.Positions.Add(new Point3D(41 / w * s, 355 / h * s, up[2]));
            //mesh3.Positions.Add(new Point3D(34 / w * s, 348 / h * s, up[2]));
            //mesh3.Positions.Add(new Point3D(38 / w * s, 344 / h * s, up[2]));
            //mesh3.Positions.Add(new Point3D(50 / w * s, 356 / h * s, up[2]));
            //mesh3.Positions.Add(new Point3D(39 / w * s, 367 / h * s, up[2]));
            //Адыгея
            mesh4.Positions.Add(new Point3D(32 / w * s, 364 / h * s, 0));
            mesh4.Positions.Add(new Point3D(41 / w * s, 355 / h * s, 0));
            mesh4.Positions.Add(new Point3D(34 / w * s, 348 / h * s, 0));
            mesh4.Positions.Add(new Point3D(38 / w * s, 344 / h * s, 0));
            mesh4.Positions.Add(new Point3D(50 / w * s, 356 / h * s, 0));
            mesh4.Positions.Add(new Point3D(39 / w * s, 367 / h * s, 0));
            //
            mesh4.Positions.Add(new Point3D(32 / w * s, 364 / h * s, up[3]));
            mesh4.Positions.Add(new Point3D(41 / w * s, 355 / h * s, up[3]));
            mesh4.Positions.Add(new Point3D(34 / w * s, 348 / h * s, up[3]));
            mesh4.Positions.Add(new Point3D(38 / w * s, 344 / h * s, up[3]));
            mesh4.Positions.Add(new Point3D(50 / w * s, 356 / h * s, up[3]));
            mesh4.Positions.Add(new Point3D(39 / w * s, 367 / h * s, up[3]));
            //Карачаево-Черкесская
            mesh5.Positions.Add(new Point3D(35 / w * s, 374 / h * s, 0));
            mesh5.Positions.Add(new Point3D(50 / w * s, 372 / h * s, 0));
            mesh5.Positions.Add(new Point3D(52 / w * s, 386 / h * s, 0));
            mesh5.Positions.Add(new Point3D(43 / w * s, 389 / h * s, 0));
            //
            mesh5.Positions.Add(new Point3D(35 / w * s, 374 / h * s, up[4]));
            mesh5.Positions.Add(new Point3D(50 / w * s, 372 / h * s, up[4]));
            mesh5.Positions.Add(new Point3D(52 / w * s, 386 / h * s, up[4]));
            mesh5.Positions.Add(new Point3D(43 / w * s, 389 / h * s, up[4]));
            //Кабардино-Балкарская
            mesh6.Positions.Add(new Point3D(43 / w * s, 389 / h * s, 0));
            mesh6.Positions.Add(new Point3D(52 / w * s, 386 / h * s, 0));
            mesh6.Positions.Add(new Point3D(63 / w * s, 392 / h * s, 0));
            mesh6.Positions.Add(new Point3D(62 / w * s, 398 / h * s, 0));
            mesh6.Positions.Add(new Point3D(48 / w * s, 400 / h * s, 0));
            //
            mesh6.Positions.Add(new Point3D(43 / w * s, 389 / h * s, up[5]));
            mesh6.Positions.Add(new Point3D(52 / w * s, 386 / h * s, up[5]));
            mesh6.Positions.Add(new Point3D(63 / w * s, 392 / h * s, up[5]));
            mesh6.Positions.Add(new Point3D(62 / w * s, 398 / h * s, up[5]));
            mesh6.Positions.Add(new Point3D(48 / w * s, 400 / h * s, up[5]));
            //Северная Осетия
            mesh7.Positions.Add(new Point3D(48 / w * s, 400 / h * s, 0));
            mesh7.Positions.Add(new Point3D(62 / w * s, 398 / h * s, 0));
            mesh7.Positions.Add(new Point3D(64 / w * s, 402 / h * s, 0));
            mesh7.Positions.Add(new Point3D(55 / w * s, 410 / h * s, 0));
            //
            mesh7.Positions.Add(new Point3D(48 / w * s, 400 / h * s, up[6]));
            mesh7.Positions.Add(new Point3D(62 / w * s, 398 / h * s, up[6]));
            mesh7.Positions.Add(new Point3D(64 / w * s, 402 / h * s, up[6]));
            mesh7.Positions.Add(new Point3D(55 / w * s, 410 / h * s, up[6]));
            //Ингушетия
            mesh8.Positions.Add(new Point3D(55 / w * s, 410 / h * s, 0));
            mesh8.Positions.Add(new Point3D(64 / w * s, 402 / h * s, 0));
            mesh8.Positions.Add(new Point3D(66 / w * s, 409 / h * s, 0));
            mesh8.Positions.Add(new Point3D(57 / w * s, 414 / h * s, 0));
            //
            mesh8.Positions.Add(new Point3D(55 / w * s, 410 / h * s, up[7]));
            mesh8.Positions.Add(new Point3D(64 / w * s, 402 / h * s, up[7]));
            mesh8.Positions.Add(new Point3D(66 / w * s, 409 / h * s, up[7]));
            mesh8.Positions.Add(new Point3D(57 / w * s, 414 / h * s, up[7]));
            //Чеченская
            mesh9.Positions.Add(new Point3D(57 / w * s, 414 / h * s, 0));
            mesh9.Positions.Add(new Point3D(66 / w * s, 409 / h * s, 0));
            mesh9.Positions.Add(new Point3D(64 / w * s, 402 / h * s, 0));
            mesh9.Positions.Add(new Point3D(72 / w * s, 403 / h * s, 0));
            mesh9.Positions.Add(new Point3D(79 / w * s, 412 / h * s, 0));
            mesh9.Positions.Add(new Point3D(70 / w * s, 420 / h * s, 0));
            mesh9.Positions.Add(new Point3D(57 / w * s, 422 / h * s, 0));
            //
            mesh9.Positions.Add(new Point3D(57 / w * s, 414 / h * s, up[8]));
            mesh9.Positions.Add(new Point3D(66 / w * s, 409 / h * s, up[8]));
            mesh9.Positions.Add(new Point3D(64 / w * s, 402 / h * s, up[8]));
            mesh9.Positions.Add(new Point3D(72 / w * s, 403 / h * s, up[8]));
            mesh9.Positions.Add(new Point3D(79 / w * s, 412 / h * s, up[8]));
            mesh9.Positions.Add(new Point3D(70 / w * s, 420 / h * s, up[8]));
            mesh9.Positions.Add(new Point3D(57 / w * s, 422 / h * s, up[8]));
            //Дагестан
            mesh10.Positions.Add(new Point3D(57 / w * s, 422 / h * s, 0));
            mesh10.Positions.Add(new Point3D(70 / w * s, 420 / h * s, 0));
            mesh10.Positions.Add(new Point3D(79 / w * s, 412 / h * s, 0));
            mesh10.Positions.Add(new Point3D(72 / w * s, 403 / h * s, 0));
            mesh10.Positions.Add(new Point3D(84 / w * s, 396 / h * s, 0));
            mesh10.Positions.Add(new Point3D(90 / w * s, 404 / h * s, 0));
            mesh10.Positions.Add(new Point3D(77 / w * s, 446 / h * s, 0));
            mesh10.Positions.Add(new Point3D(61 / w * s, 445 / h * s, 0));
            //
            mesh10.Positions.Add(new Point3D(57 / w * s, 422 / h * s, up[9]));
            mesh10.Positions.Add(new Point3D(70 / w * s, 420 / h * s, up[9]));
            mesh10.Positions.Add(new Point3D(79 / w * s, 412 / h * s, up[9]));
            mesh10.Positions.Add(new Point3D(72 / w * s, 403 / h * s, up[9]));
            mesh10.Positions.Add(new Point3D(84 / w * s, 396 / h * s, up[9]));
            mesh10.Positions.Add(new Point3D(90 / w * s, 404 / h * s, up[9]));
            mesh10.Positions.Add(new Point3D(77 / w * s, 446 / h * s, up[9]));
            mesh10.Positions.Add(new Point3D(61 / w * s, 445 / h * s, up[9]));
            //Якутия
            mesh11.Positions.Add(new Point3D(605 / w * s, 184 / h * s, 0));
            mesh11.Positions.Add(new Point3D(677 / w * s, 163 / h * s, 0));
            mesh11.Positions.Add(new Point3D(734 / w * s, 163 / h * s, 0));
            mesh11.Positions.Add(new Point3D(831 / w * s, 110 / h * s, 0));
            mesh11.Positions.Add(new Point3D(853 / w * s, 155 / h * s, 0));
            mesh11.Positions.Add(new Point3D(833 / w * s, 256 / h * s, 0));
            mesh11.Positions.Add(new Point3D(794 / w * s, 379 / h * s, 0));
            mesh11.Positions.Add(new Point3D(710 / w * s, 398 / h * s, 0));
            mesh11.Positions.Add(new Point3D(701 / w * s, 381 / h * s, 0));
            mesh11.Positions.Add(new Point3D(668 / w * s, 355 / h * s, 0));
            mesh11.Positions.Add(new Point3D(632 / w * s, 382 / h * s, 0));
            mesh11.Positions.Add(new Point3D(616 / w * s, 315 / h * s, 0));
            //
            mesh11.Positions.Add(new Point3D(605 / w * s, 184 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(677 / w * s, 163 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(734 / w * s, 163 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(831 / w * s, 110 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(853 / w * s, 155 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(833 / w * s, 256 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(794 / w * s, 379 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(710 / w * s, 398 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(701 / w * s, 381 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(668 / w * s, 355 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(632 / w * s, 382 / h * s, up[10]));
            mesh11.Positions.Add(new Point3D(616 / w * s, 315 / h * s, up[10]));
            //Чукотская автономная область
            mesh12.Positions.Add(new Point3D(832 / w * s, 110 / h * s, 0));
            mesh12.Positions.Add(new Point3D(859 / w * s, 53 / h * s, 0));
            mesh12.Positions.Add(new Point3D(927 / w * s, 6 / h * s, 0));
            mesh12.Positions.Add(new Point3D(956 / w * s, 31 / h * s, 0));
            mesh12.Positions.Add(new Point3D(933 / w * s, 41 / h * s, 0));
            mesh12.Positions.Add(new Point3D(933 / w * s, 71 / h * s, 0));
            mesh12.Positions.Add(new Point3D(958 / w * s, 77 / h * s, 0));
            mesh12.Positions.Add(new Point3D(959 / w * s, 113 / h * s, 0));
            mesh12.Positions.Add(new Point3D(887 / w * s, 152 / h * s, 0));
            mesh12.Positions.Add(new Point3D(852 / w * s, 155 / h * s, 0));
            //
            mesh12.Positions.Add(new Point3D(832 / w * s, 110 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(859 / w * s, 53 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(927 / w * s, 6 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(956 / w * s, 31 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(933 / w * s, 41 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(933 / w * s, 71 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(958 / w * s, 77 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(959 / w * s, 113 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(887 / w * s, 152 / h * s, up[11]));
            mesh12.Positions.Add(new Point3D(852 / w * s, 155 / h * s, up[11]));
            //Камчатская область
            mesh13.Positions.Add(new Point3D(888 / w * s, 151 / h * s, 0));
            mesh13.Positions.Add(new Point3D(959 / w * s, 113 / h * s, 0));
            mesh13.Positions.Add(new Point3D(947 / w * s, 178 / h * s, 0));
            //mesh13.Positions.Add(new Point3D(956 / w * s, 31 / h * s, 0));
            mesh13.Positions.Add(new Point3D(963 / w * s, 206 / h * s, 0));
            mesh13.Positions.Add(new Point3D(1000 / w * s, 305 / h * s, 0));
            mesh13.Positions.Add(new Point3D(937 / w * s, 257 / h * s, 0));
            mesh13.Positions.Add(new Point3D(929 / w * s, 179 / h * s, 0));
            mesh13.Positions.Add(new Point3D(919 / w * s, 156 / h * s, 0));
            mesh13.Positions.Add(new Point3D(912 / w * s, 160 / h * s, 0));
            mesh13.Positions.Add(new Point3D(917 / w * s, 178 / h * s, 0));
            //
            mesh13.Positions.Add(new Point3D(888 / w * s, 151 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(959 / w * s, 113 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(947 / w * s, 178 / h * s, up[12]));
            //mesh13.Positions.Add(new Point3D(956 / w * s, 31 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(963 / w * s, 206 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(1000 / w * s, 305 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(937 / w * s, 257 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(929 / w * s, 179 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(919 / w * s, 156 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(912 / w * s, 160 / h * s, up[12]));
            mesh13.Positions.Add(new Point3D(917 / w * s, 178 / h * s, up[12]));
            //Магаданская область
            mesh14.Positions.Add(new Point3D(852 / w * s, 155 / h * s, 0));
            mesh14.Positions.Add(new Point3D(888 / w * s, 151 / h * s, 0));
            mesh14.Positions.Add(new Point3D(917 / w * s, 179 / h * s, 0));
            mesh14.Positions.Add(new Point3D(903 / w * s, 242 / h * s, 0));
            mesh14.Positions.Add(new Point3D(864 / w * s, 276 / h * s, 0));
            mesh14.Positions.Add(new Point3D(833 / w * s, 256 / h * s, 0));
            //
            mesh14.Positions.Add(new Point3D(852 / w * s, 155 / h * s, up[13]));
            mesh14.Positions.Add(new Point3D(888 / w * s, 151 / h * s, up[13]));
            mesh14.Positions.Add(new Point3D(917 / w * s, 179 / h * s, up[13]));
            mesh14.Positions.Add(new Point3D(903 / w * s, 242 / h * s, up[13]));
            mesh14.Positions.Add(new Point3D(864 / w * s, 276 / h * s, up[13]));
            mesh14.Positions.Add(new Point3D(833 / w * s, 256 / h * s, up[13]));
            //Хабаровский край
            mesh15.Positions.Add(new Point3D(834 / w * s, 256 / h * s, 0));
            mesh15.Positions.Add(new Point3D(864 / w * s, 276 / h * s, 0));
            mesh15.Positions.Add(new Point3D(829 / w * s, 373 / h * s, 0));
            mesh15.Positions.Add(new Point3D(880 / w * s, 368 / h * s, 0));
            mesh15.Positions.Add(new Point3D(909 / w * s, 446 / h * s, 0));
            mesh15.Positions.Add(new Point3D(876 / w * s, 476 / h * s, 0));
            mesh15.Positions.Add(new Point3D(868 / w * s, 455 / h * s, 0));
            mesh15.Positions.Add(new Point3D(838 / w * s, 455 / h * s, 0));
            mesh15.Positions.Add(new Point3D(838 / w * s, 405 / h * s, 0));
            mesh15.Positions.Add(new Point3D(795 / w * s, 379 / h * s, 0));
            //
            mesh15.Positions.Add(new Point3D(834 / w * s, 256 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(864 / w * s, 276 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(829 / w * s, 373 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(880 / w * s, 368 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(909 / w * s, 446 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(876 / w * s, 476 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(868 / w * s, 455 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(838 / w * s, 455 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(838 / w * s, 405 / h * s, up[14]));
            mesh15.Positions.Add(new Point3D(795 / w * s, 379 / h * s, up[14]));
            //Сахалинская область
            mesh16.Positions.Add(new Point3D(879 / w * s, 344 / h * s, 0));
            mesh16.Positions.Add(new Point3D(935 / w * s, 394 / h * s, 0));
            mesh16.Positions.Add(new Point3D(923 / w * s, 399 / h * s, 0));
            mesh16.Positions.Add(new Point3D(949 / w * s, 428 / h * s, 0));
            mesh16.Positions.Add(new Point3D(939 / w * s, 441 / h * s, 0));
            mesh16.Positions.Add(new Point3D(880 / w * s, 360 / h * s, 0));
            //
            mesh16.Positions.Add(new Point3D(879 / w * s, 344 / h * s, up[15]));
            mesh16.Positions.Add(new Point3D(935 / w * s, 394 / h * s, up[15]));
            mesh16.Positions.Add(new Point3D(923 / w * s, 399 / h * s, up[15]));
            mesh16.Positions.Add(new Point3D(949 / w * s, 428 / h * s, up[15]));
            mesh16.Positions.Add(new Point3D(939 / w * s, 441 / h * s, up[15]));
            mesh16.Positions.Add(new Point3D(880 / w * s, 360 / h * s, up[15]));
            //Приморский край
            mesh17.Positions.Add(new Point3D(909 / w * s, 446 / h * s, 0));
            mesh17.Positions.Add(new Point3D(902 / w * s, 515 / h * s, 0));
            mesh17.Positions.Add(new Point3D(877 / w * s, 527 / h * s, 0));
            mesh17.Positions.Add(new Point3D(859 / w * s, 513 / h * s, 0));
            mesh17.Positions.Add(new Point3D(874 / w * s, 477 / h * s, 0));
            //
            mesh17.Positions.Add(new Point3D(909 / w * s, 446 / h * s, up[16]));
            mesh17.Positions.Add(new Point3D(902 / w * s, 515 / h * s, up[16]));
            mesh17.Positions.Add(new Point3D(877 / w * s, 527 / h * s, up[16]));
            mesh17.Positions.Add(new Point3D(859 / w * s, 513 / h * s, up[16]));
            mesh17.Positions.Add(new Point3D(874 / w * s, 477 / h * s, up[16]));
            //Амурская область
            mesh18.Positions.Add(new Point3D(709 / w * s, 397 / h * s, 0));
            mesh18.Positions.Add(new Point3D(794 / w * s, 378 / h * s, 0));
            mesh18.Positions.Add(new Point3D(839 / w * s, 405 / h * s, 0));
            mesh18.Positions.Add(new Point3D(838 / w * s, 456 / h * s, 0));
            mesh18.Positions.Add(new Point3D(831 / w * s, 465 / h * s, 0));
            mesh18.Positions.Add(new Point3D(806 / w * s, 464 / h * s, 0));
            mesh18.Positions.Add(new Point3D(772 / w * s, 431 / h * s, 0));
            mesh18.Positions.Add(new Point3D(740 / w * s, 435 / h * s, 0));
            //
            mesh18.Positions.Add(new Point3D(709 / w * s, 397 / h * s, up[17]));
            mesh18.Positions.Add(new Point3D(794 / w * s, 378 / h * s, up[17]));
            mesh18.Positions.Add(new Point3D(839 / w * s, 405 / h * s, up[17]));
            mesh18.Positions.Add(new Point3D(838 / w * s, 456 / h * s, up[17]));
            mesh18.Positions.Add(new Point3D(831 / w * s, 465 / h * s, up[17]));
            mesh18.Positions.Add(new Point3D(806 / w * s, 464 / h * s, up[17]));
            mesh18.Positions.Add(new Point3D(772 / w * s, 431 / h * s, up[17]));
            mesh18.Positions.Add(new Point3D(740 / w * s, 435 / h * s, up[17]));
            //Еврейская автономная область
            mesh19.Positions.Add(new Point3D(869 / w * s, 456 / h * s, 0));
            mesh19.Positions.Add(new Point3D(832 / w * s, 466 / h * s, 0));
            mesh19.Positions.Add(new Point3D(839 / w * s, 456 / h * s, 0));
            //
            mesh19.Positions.Add(new Point3D(869 / w * s, 456 / h * s, up[18]));
            mesh19.Positions.Add(new Point3D(832 / w * s, 466 / h * s, up[18]));
            mesh19.Positions.Add(new Point3D(839 / w * s, 456 / h * s, up[18]));
            //Читинская область
            mesh20.Positions.Add(new Point3D(701 / w * s, 381 / h * s, 0));
            mesh20.Positions.Add(new Point3D(709 / w * s, 397 / h * s, 0));
            mesh20.Positions.Add(new Point3D(740 / w * s, 435 / h * s, 0));
            mesh20.Positions.Add(new Point3D(725 / w * s, 495 / h * s, 0));
            mesh20.Positions.Add(new Point3D(634 / w * s, 508 / h * s, 0));
            mesh20.Positions.Add(new Point3D(695 / w * s, 434 / h * s, 0));
            mesh20.Positions.Add(new Point3D(681 / w * s, 404 / h * s, 0));
            //
            mesh20.Positions.Add(new Point3D(701 / w * s, 381 / h * s, up[19]));
            mesh20.Positions.Add(new Point3D(709 / w * s, 397 / h * s, up[19]));
            mesh20.Positions.Add(new Point3D(740 / w * s, 435 / h * s, up[19]));
            mesh20.Positions.Add(new Point3D(725 / w * s, 495 / h * s, up[19]));
            mesh20.Positions.Add(new Point3D(634 / w * s, 508 / h * s, up[19]));
            mesh20.Positions.Add(new Point3D(695 / w * s, 434 / h * s, up[19]));
            mesh20.Positions.Add(new Point3D(681 / w * s, 404 / h * s, up[19]));
            //Республика Бурятия
            mesh21.Positions.Add(new Point3D(681 / w * s, 403 / h * s, 0));
            mesh21.Positions.Add(new Point3D(695 / w * s, 433 / h * s, 0));
            mesh21.Positions.Add(new Point3D(633 / w * s, 507 / h * s, 0));
            mesh21.Positions.Add(new Point3D(594 / w * s, 509 / h * s, 0));
            mesh21.Positions.Add(new Point3D(553 / w * s, 484 / h * s, 0));
            mesh21.Positions.Add(new Point3D(557 / w * s, 472 / h * s, 0));
            mesh21.Positions.Add(new Point3D(606 / w * s, 491 / h * s, 0));
            mesh21.Positions.Add(new Point3D(633 / w * s, 439 / h * s, 0));
            //
            mesh21.Positions.Add(new Point3D(681 / w * s, 403 / h * s, up[20]));
            mesh21.Positions.Add(new Point3D(695 / w * s, 433 / h * s, up[20]));
            mesh21.Positions.Add(new Point3D(633 / w * s, 507 / h * s, up[20]));
            mesh21.Positions.Add(new Point3D(594 / w * s, 509 / h * s, up[20]));
            mesh21.Positions.Add(new Point3D(553 / w * s, 484 / h * s, up[20]));
            mesh21.Positions.Add(new Point3D(557 / w * s, 472 / h * s, up[20]));
            mesh21.Positions.Add(new Point3D(606 / w * s, 491 / h * s, up[20]));
            mesh21.Positions.Add(new Point3D(633 / w * s, 439 / h * s, up[20]));
            //Иркутская область
            mesh22.Positions.Add(new Point3D(616 / w * s, 315 / h * s, 0));
            mesh22.Positions.Add(new Point3D(631 / w * s, 381 / h * s, 0));
            mesh22.Positions.Add(new Point3D(668 / w * s, 356 / h * s, 0));
            mesh22.Positions.Add(new Point3D(701 / w * s, 381 / h * s, 0));
            mesh22.Positions.Add(new Point3D(682 / w * s, 404 / h * s, 0));
            mesh22.Positions.Add(new Point3D(632 / w * s, 439 / h * s, 0));
            mesh22.Positions.Add(new Point3D(607 / w * s, 491 / h * s, 0));
            mesh22.Positions.Add(new Point3D(556 / w * s, 472 / h * s, 0));
            mesh22.Positions.Add(new Point3D(539 / w * s, 463 / h * s, 0));
            mesh22.Positions.Add(new Point3D(530 / w * s, 451 / h * s, 0));
            mesh22.Positions.Add(new Point3D(583 / w * s, 387 / h * s, 0));
            //
            mesh22.Positions.Add(new Point3D(616 / w * s, 315 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(631 / w * s, 381 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(668 / w * s, 356 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(701 / w * s, 381 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(682 / w * s, 404 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(632 / w * s, 439 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(607 / w * s, 491 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(556 / w * s, 472 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(539 / w * s, 463 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(530 / w * s, 451 / h * s, up[21]));
            mesh22.Positions.Add(new Point3D(583 / w * s, 387 / h * s, up[21]));
            //Красноярский край
            mesh23.Positions.Add(new Point3D(575 / w * s, 124 / h * s, 0));
            mesh23.Positions.Add(new Point3D(611 / w * s, 147 / h * s, 0));
            mesh23.Positions.Add(new Point3D(605 / w * s, 183 / h * s, 0));
            mesh23.Positions.Add(new Point3D(615 / w * s, 315 / h * s, 0));
            mesh23.Positions.Add(new Point3D(583 / w * s, 387 / h * s, 0));
            mesh23.Positions.Add(new Point3D(530 / w * s, 451 / h * s, 0));
            mesh23.Positions.Add(new Point3D(540 / w * s, 463 / h * s, 0));
            mesh23.Positions.Add(new Point3D(488 / w * s, 481 / h * s, 0));
            mesh23.Positions.Add(new Point3D(480 / w * s, 433 / h * s, 0));
            mesh23.Positions.Add(new Point3D(478 / w * s, 416 / h * s, 0));
            mesh23.Positions.Add(new Point3D(459 / w * s, 354 / h * s, 0));
            mesh23.Positions.Add(new Point3D(463 / w * s, 334 / h * s, 0));
            mesh23.Positions.Add(new Point3D(470 / w * s, 191 / h * s, 0));
            //
            mesh23.Positions.Add(new Point3D(575 / w * s, 124 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(611 / w * s, 147 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(605 / w * s, 183 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(615 / w * s, 315 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(583 / w * s, 387 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(530 / w * s, 451 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(540 / w * s, 463 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(488 / w * s, 481 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(480 / w * s, 433 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(478 / w * s, 416 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(459 / w * s, 354 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(463 / w * s, 334 / h * s, up[22]));
            mesh23.Positions.Add(new Point3D(470 / w * s, 191 / h * s, up[22]));
            //Республика Тыва
            mesh24.Positions.Add(new Point3D(488 / w * s, 481 / h * s, 0));
            mesh24.Positions.Add(new Point3D(538 / w * s, 462 / h * s, 0));
            mesh24.Positions.Add(new Point3D(557 / w * s, 473 / h * s, 0));
            mesh24.Positions.Add(new Point3D(555 / w * s, 484 / h * s, 0));
            mesh24.Positions.Add(new Point3D(545 / w * s, 516 / h * s, 0));
            mesh24.Positions.Add(new Point3D(475 / w * s, 510 / h * s, 0));
            //
            mesh24.Positions.Add(new Point3D(488 / w * s, 481 / h * s, up[23]));
            mesh24.Positions.Add(new Point3D(538 / w * s, 462 / h * s, up[23]));
            mesh24.Positions.Add(new Point3D(557 / w * s, 473 / h * s, up[23]));
            mesh24.Positions.Add(new Point3D(555 / w * s, 484 / h * s, up[23]));
            mesh24.Positions.Add(new Point3D(545 / w * s, 516 / h * s, up[23]));
            mesh24.Positions.Add(new Point3D(475 / w * s, 510 / h * s, up[23]));
            //Республика Алтай
            mesh25.Positions.Add(new Point3D(428 / w * s, 493 / h * s, 0));
            mesh25.Positions.Add(new Point3D(455 / w * s, 475 / h * s, 0));
            mesh25.Positions.Add(new Point3D(465 / w * s, 477 / h * s, 0));
            mesh25.Positions.Add(new Point3D(474 / w * s, 510 / h * s, 0));
            mesh25.Positions.Add(new Point3D(458 / w * s, 518 / h * s, 0));
            //
            mesh25.Positions.Add(new Point3D(428 / w * s, 493 / h * s, up[24]));
            mesh25.Positions.Add(new Point3D(455 / w * s, 475 / h * s, up[24]));
            mesh25.Positions.Add(new Point3D(465 / w * s, 477 / h * s, up[24]));
            mesh25.Positions.Add(new Point3D(474 / w * s, 510 / h * s, up[24]));
            mesh25.Positions.Add(new Point3D(458 / w * s, 518 / h * s, up[24]));
            //Алтайский край
            mesh26.Positions.Add(new Point3D(386 / w * s, 442 / h * s, 0));
            mesh26.Positions.Add(new Point3D(447 / w * s, 442 / h * s, 0));
            mesh26.Positions.Add(new Point3D(455 / w * s, 477 / h * s, 0));
            mesh26.Positions.Add(new Point3D(428 / w * s, 495 / h * s, 0));
            mesh26.Positions.Add(new Point3D(396 / w * s, 482 / h * s, 0));
            //
            mesh26.Positions.Add(new Point3D(386 / w * s, 442 / h * s, up[25]));
            mesh26.Positions.Add(new Point3D(447 / w * s, 442 / h * s, up[25]));
            mesh26.Positions.Add(new Point3D(455 / w * s, 477 / h * s, up[25]));
            mesh26.Positions.Add(new Point3D(428 / w * s, 495 / h * s, up[25]));
            mesh26.Positions.Add(new Point3D(396 / w * s, 482 / h * s, up[25]));
            //Республика Хакасия
            mesh27.Positions.Add(new Point3D(479 / w * s, 442 / h * s, 0));
            mesh27.Positions.Add(new Point3D(489 / w * s, 480 / h * s, 0));
            mesh27.Positions.Add(new Point3D(465 / w * s, 477 / h * s, 0));
            //
            mesh27.Positions.Add(new Point3D(479 / w * s, 442 / h * s, up[26]));
            mesh27.Positions.Add(new Point3D(489 / w * s, 480 / h * s, up[26]));
            mesh27.Positions.Add(new Point3D(465 / w * s, 477 / h * s, up[26]));
            //Кемеровская область
            mesh28.Positions.Add(new Point3D(447 / w * s, 419 / h * s, 0));
            mesh28.Positions.Add(new Point3D(478 / w * s, 416 / h * s, 0));
            mesh28.Positions.Add(new Point3D(479 / w * s, 433 / h * s, 0));
            mesh28.Positions.Add(new Point3D(466 / w * s, 477 / h * s, 0));
            mesh28.Positions.Add(new Point3D(454 / w * s, 476 / h * s, 0));
            mesh28.Positions.Add(new Point3D(447 / w * s, 443 / h * s, 0));
            //
            mesh28.Positions.Add(new Point3D(447 / w * s, 419 / h * s, up[27]));
            mesh28.Positions.Add(new Point3D(478 / w * s, 416 / h * s, up[27]));
            mesh28.Positions.Add(new Point3D(479 / w * s, 433 / h * s, up[27]));
            mesh28.Positions.Add(new Point3D(466 / w * s, 477 / h * s, up[27]));
            mesh28.Positions.Add(new Point3D(454 / w * s, 476 / h * s, up[27]));
            mesh28.Positions.Add(new Point3D(447 / w * s, 443 / h * s, up[27]));
            //Новосибирская область
            mesh29.Positions.Add(new Point3D(373 / w * s, 426 / h * s, 0));
            mesh29.Positions.Add(new Point3D(390 / w * s, 388 / h * s, 0));
            mesh29.Positions.Add(new Point3D(446 / w * s, 419 / h * s, 0));
            mesh29.Positions.Add(new Point3D(447 / w * s, 443 / h * s, 0));
            mesh29.Positions.Add(new Point3D(387 / w * s, 440 / h * s, 0));
            //
            mesh29.Positions.Add(new Point3D(373 / w * s, 426 / h * s, up[28]));
            mesh29.Positions.Add(new Point3D(390 / w * s, 388 / h * s, up[28]));
            mesh29.Positions.Add(new Point3D(446 / w * s, 419 / h * s, up[28]));
            mesh29.Positions.Add(new Point3D(447 / w * s, 443 / h * s, up[28]));
            mesh29.Positions.Add(new Point3D(387 / w * s, 440 / h * s, up[28]));
            //Омская область
            mesh30.Positions.Add(new Point3D(341 / w * s, 397 / h * s, 0));
            mesh30.Positions.Add(new Point3D(358 / w * s, 379 / h * s, 0));
            mesh30.Positions.Add(new Point3D(354 / w * s, 364 / h * s, 0));
            mesh30.Positions.Add(new Point3D(361 / w * s, 358 / h * s, 0));
            mesh30.Positions.Add(new Point3D(391 / w * s, 367 / h * s, 0));
            mesh30.Positions.Add(new Point3D(391 / w * s, 388 / h * s, 0));
            mesh30.Positions.Add(new Point3D(374 / w * s, 426 / h * s, 0));
            //
            mesh30.Positions.Add(new Point3D(341 / w * s, 397 / h * s, up[29]));
            mesh30.Positions.Add(new Point3D(358 / w * s, 379 / h * s, up[29]));
            mesh30.Positions.Add(new Point3D(354 / w * s, 364 / h * s, up[29]));
            mesh30.Positions.Add(new Point3D(361 / w * s, 358 / h * s, up[29]));
            mesh30.Positions.Add(new Point3D(391 / w * s, 367 / h * s, up[29]));
            mesh30.Positions.Add(new Point3D(391 / w * s, 388 / h * s, up[29]));
            mesh30.Positions.Add(new Point3D(374 / w * s, 426 / h * s, up[29]));
            //Тюменская область
            mesh31.Positions.Add(new Point3D(328 / w * s, 390 / h * s, 0));
            mesh31.Positions.Add(new Point3D(312 / w * s, 362 / h * s, 0));
            mesh31.Positions.Add(new Point3D(330 / w * s, 344 / h * s, 0));
            mesh31.Positions.Add(new Point3D(360 / w * s, 336 / h * s, 0));
            mesh31.Positions.Add(new Point3D(390 / w * s, 367 / h * s, 0));
            mesh31.Positions.Add(new Point3D(361 / w * s, 358 / h * s, 0));
            mesh31.Positions.Add(new Point3D(354 / w * s, 364 / h * s, 0));
            mesh31.Positions.Add(new Point3D(357 / w * s, 378 / h * s, 0));
            mesh31.Positions.Add(new Point3D(341 / w * s, 396 / h * s, 0));
            //
            mesh31.Positions.Add(new Point3D(328 / w * s, 390 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(312 / w * s, 362 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(330 / w * s, 344 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(360 / w * s, 336 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(390 / w * s, 367 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(361 / w * s, 358 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(354 / w * s, 364 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(357 / w * s, 378 / h * s, up[30]));
            mesh31.Positions.Add(new Point3D(341 / w * s, 396 / h * s, up[30]));
            //Курганская область
            mesh32.Positions.Add(new Point3D(285 / w * s, 384 / h * s, 0));
            mesh32.Positions.Add(new Point3D(289 / w * s, 357 / h * s, 0));
            mesh32.Positions.Add(new Point3D(312 / w * s, 362 / h * s, 0));
            mesh32.Positions.Add(new Point3D(327 / w * s, 391 / h * s, 0));
            //mesh32.Positions.Add(new Point3D(390 / w * s, 367 / h * s, 0));
            //
            mesh32.Positions.Add(new Point3D(285 / w * s, 384 / h * s, up[31]));
            mesh32.Positions.Add(new Point3D(289 / w * s, 357 / h * s, up[31]));
            mesh32.Positions.Add(new Point3D(312 / w * s, 362 / h * s, up[31]));
            mesh32.Positions.Add(new Point3D(327 / w * s, 391 / h * s, up[31]));
            //mesh32.Positions.Add(new Point3D(390 / w * s, 367 / h * s, up[31]));
            //Челябинская область
            mesh33.Positions.Add(new Point3D(246 / w * s, 399 / h * s, 0));
            mesh33.Positions.Add(new Point3D(240 / w * s, 389 / h * s, 0));
            mesh33.Positions.Add(new Point3D(261 / w * s, 367 / h * s, 0));
            mesh33.Positions.Add(new Point3D(246 / w * s, 354 / h * s, 0));
            mesh33.Positions.Add(new Point3D(254 / w * s, 349 / h * s, 0));
            mesh33.Positions.Add(new Point3D(267 / w * s, 360 / h * s, 0));
            //mesh33.Positions.Add(new Point3D(269 / w * s, 360 / h * s, 0));
            mesh33.Positions.Add(new Point3D(269 / w * s, 347 / h * s, 0));
            mesh33.Positions.Add(new Point3D(288 / w * s, 357 / h * s, 0));
            mesh33.Positions.Add(new Point3D(284 / w * s, 385 / h * s, 0));
            //
            mesh33.Positions.Add(new Point3D(246 / w * s, 399 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(240 / w * s, 389 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(261 / w * s, 367 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(246 / w * s, 354 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(254 / w * s, 349 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(267 / w * s, 360 / h * s, up[32]));
            //mesh33.Positions.Add(new Point3D(269 / w * s, 360 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(269 / w * s, 347 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(288 / w * s, 357 / h * s, up[32]));
            mesh33.Positions.Add(new Point3D(284 / w * s, 385 / h * s, up[32]));
            //Челябинская область
            mesh34.Positions.Add(new Point3D(180 / w * s, 355 / h * s, 0));
            mesh34.Positions.Add(new Point3D(212 / w * s, 335 / h * s, 0));
            mesh34.Positions.Add(new Point3D(216 / w * s, 345 / h * s, 0));
            mesh34.Positions.Add(new Point3D(221 / w * s, 388 / h * s, 0));
            mesh34.Positions.Add(new Point3D(241 / w * s, 389 / h * s, 0));
            mesh34.Positions.Add(new Point3D(247 / w * s, 400 / h * s, 0));
            mesh34.Positions.Add(new Point3D(245 / w * s, 418 / h * s, 0));
            mesh34.Positions.Add(new Point3D(206 / w * s, 395 / h * s, 0));
            //
            mesh34.Positions.Add(new Point3D(180 / w * s, 355 / h * s, up[33]));
            mesh34.Positions.Add(new Point3D(212 / w * s, 335 / h * s, up[33]));
            mesh34.Positions.Add(new Point3D(216 / w * s, 345 / h * s, up[33]));
            mesh34.Positions.Add(new Point3D(221 / w * s, 388 / h * s, up[33]));
            mesh34.Positions.Add(new Point3D(241 / w * s, 389 / h * s, up[33]));
            mesh34.Positions.Add(new Point3D(247 / w * s, 400 / h * s, up[33]));
            mesh34.Positions.Add(new Point3D(245 / w * s, 418 / h * s, up[33]));
            mesh34.Positions.Add(new Point3D(206 / w * s, 395 / h * s, up[33]));
            //Томская область
            mesh35.Positions.Add(new Point3D(391 / w * s, 388 / h * s, 0));
            mesh35.Positions.Add(new Point3D(390 / w * s, 366 / h * s, 0));
            mesh35.Positions.Add(new Point3D(413 / w * s, 344 / h * s, 0));
            mesh35.Positions.Add(new Point3D(458 / w * s, 354 / h * s, 0));
            mesh35.Positions.Add(new Point3D(478 / w * s, 415 / h * s, 0));
            mesh35.Positions.Add(new Point3D(446 / w * s, 419 / h * s, 0));
            //
            mesh35.Positions.Add(new Point3D(391 / w * s, 388 / h * s, up[34]));
            mesh35.Positions.Add(new Point3D(390 / w * s, 366 / h * s, up[34]));
            mesh35.Positions.Add(new Point3D(413 / w * s, 344 / h * s, up[34]));
            mesh35.Positions.Add(new Point3D(458 / w * s, 354 / h * s, up[34]));
            mesh35.Positions.Add(new Point3D(478 / w * s, 415 / h * s, up[34]));
            mesh35.Positions.Add(new Point3D(446 / w * s, 419 / h * s, up[34]));
            //Ханты-Манскийский авт.округ-ЮГРА
            mesh36.Positions.Add(new Point3D(314 / w * s, 280 / h * s, 0));
            mesh36.Positions.Add(new Point3D(355 / w * s, 243 / h * s, 0));
            mesh36.Positions.Add(new Point3D(463 / w * s, 335 / h * s, 0));
            mesh36.Positions.Add(new Point3D(459 / w * s, 354 / h * s, 0));
            mesh36.Positions.Add(new Point3D(413 / w * s, 344 / h * s, 0));
            mesh36.Positions.Add(new Point3D(390 / w * s, 367 / h * s, 0));
            mesh36.Positions.Add(new Point3D(359 / w * s, 335 / h * s, 0));
            mesh36.Positions.Add(new Point3D(330 / w * s, 344 / h * s, 0));
            //
            mesh36.Positions.Add(new Point3D(314 / w * s, 280 / h * s, up[35]));
            mesh36.Positions.Add(new Point3D(355 / w * s, 243 / h * s, up[35]));
            mesh36.Positions.Add(new Point3D(463 / w * s, 335 / h * s, up[35]));
            mesh36.Positions.Add(new Point3D(459 / w * s, 354 / h * s, up[35]));
            mesh36.Positions.Add(new Point3D(413 / w * s, 344 / h * s, up[35]));
            mesh36.Positions.Add(new Point3D(390 / w * s, 367 / h * s, up[35]));
            mesh36.Positions.Add(new Point3D(359 / w * s, 335 / h * s, up[35]));
            mesh36.Positions.Add(new Point3D(330 / w * s, 344 / h * s, up[35]));
            //Ямало-ненецкий авт.округ
            mesh37.Positions.Add(new Point3D(355 / w * s, 243 / h * s, 0));
            mesh37.Positions.Add(new Point3D(389 / w * s, 219 / h * s, 0));
            mesh37.Positions.Add(new Point3D(392 / w * s, 206 / h * s, 0));
            mesh37.Positions.Add(new Point3D(436 / w * s, 169 / h * s, 0));
            mesh37.Positions.Add(new Point3D(468 / w * s, 191 / h * s, 0));
            mesh37.Positions.Add(new Point3D(463 / w * s, 333 / h * s, 0));
            //
            mesh37.Positions.Add(new Point3D(355 / w * s, 243 / h * s, up[36]));
            mesh37.Positions.Add(new Point3D(389 / w * s, 219 / h * s, up[36]));
            mesh37.Positions.Add(new Point3D(392 / w * s, 206 / h * s, up[36]));
            mesh37.Positions.Add(new Point3D(436 / w * s, 169 / h * s, up[36]));
            mesh37.Positions.Add(new Point3D(468 / w * s, 191 / h * s, up[36]));
            mesh37.Positions.Add(new Point3D(463 / w * s, 333 / h * s, up[36]));
            //Ненецкий авт. округ
            mesh38.Positions.Add(new Point3D(281 / w * s, 175 / h * s, 0));
            mesh38.Positions.Add(new Point3D(391 / w * s, 206 / h * s, 0));
            mesh38.Positions.Add(new Point3D(388 / w * s, 217 / h * s, 0));
            mesh38.Positions.Add(new Point3D(361 / w * s, 227 / h * s, 0));
            mesh38.Positions.Add(new Point3D(297 / w * s, 196 / h * s, 0));
            //
            mesh38.Positions.Add(new Point3D(281 / w * s, 175 / h * s, up[37]));
            mesh38.Positions.Add(new Point3D(391 / w * s, 206 / h * s, up[37]));
            mesh38.Positions.Add(new Point3D(388 / w * s, 217 / h * s, up[37]));
            mesh38.Positions.Add(new Point3D(361 / w * s, 227 / h * s, up[37]));
            mesh38.Positions.Add(new Point3D(297 / w * s, 196 / h * s, up[37]));
            //Руспублика Коми
            mesh39.Positions.Add(new Point3D(296 / w * s, 196 / h * s, 0));
            mesh39.Positions.Add(new Point3D(360 / w * s, 227 / h * s, 0));
            mesh39.Positions.Add(new Point3D(388 / w * s, 219 / h * s, 0));
            mesh39.Positions.Add(new Point3D(356 / w * s, 244 / h * s, 0));
            mesh39.Positions.Add(new Point3D(314 / w * s, 280 / h * s, 0));
            mesh39.Positions.Add(new Point3D(260 / w * s, 270 / h * s, 0));
            mesh39.Positions.Add(new Point3D(240 / w * s, 271 / h * s, 0));
            mesh39.Positions.Add(new Point3D(248 / w * s, 250 / h * s, 0));
            //
            mesh39.Positions.Add(new Point3D(296 / w * s, 196 / h * s, up[38]));
            mesh39.Positions.Add(new Point3D(360 / w * s, 227 / h * s, up[38]));
            mesh39.Positions.Add(new Point3D(388 / w * s, 219 / h * s, up[38]));
            mesh39.Positions.Add(new Point3D(356 / w * s, 244 / h * s, up[38]));
            mesh39.Positions.Add(new Point3D(314 / w * s, 280 / h * s, up[38]));
            mesh39.Positions.Add(new Point3D(260 / w * s, 270 / h * s, up[38]));
            mesh39.Positions.Add(new Point3D(240 / w * s, 271 / h * s, up[38]));
            mesh39.Positions.Add(new Point3D(248 / w * s, 250 / h * s, up[38]));
            //Свердловская область
            mesh40.Positions.Add(new Point3D(313 / w * s, 280 / h * s, 0));
            mesh40.Positions.Add(new Point3D(330 / w * s, 343 / h * s, 0));
            mesh40.Positions.Add(new Point3D(312 / w * s, 362 / h * s, 0));
            mesh40.Positions.Add(new Point3D(288 / w * s, 357 / h * s, 0));
            mesh40.Positions.Add(new Point3D(269 / w * s, 346 / h * s, 0));
            mesh40.Positions.Add(new Point3D(258 / w * s, 337 / h * s, 0));
            //
            mesh40.Positions.Add(new Point3D(313 / w * s, 280 / h * s, up[39]));
            mesh40.Positions.Add(new Point3D(330 / w * s, 343 / h * s, up[39]));
            mesh40.Positions.Add(new Point3D(312 / w * s, 362 / h * s, up[39]));
            mesh40.Positions.Add(new Point3D(288 / w * s, 357 / h * s, up[39]));
            mesh40.Positions.Add(new Point3D(269 / w * s, 346 / h * s, up[39]));
            mesh40.Positions.Add(new Point3D(258 / w * s, 337 / h * s, up[39]));
            //Республика Башкортостан
            mesh41.Positions.Add(new Point3D(217 / w * s, 345 / h * s, 0));
            mesh41.Positions.Add(new Point3D(242 / w * s, 323 / h * s, 0));
            mesh41.Positions.Add(new Point3D(258 / w * s, 338 / h * s, 0));
            mesh41.Positions.Add(new Point3D(269 / w * s, 346 / h * s, 0));
            mesh41.Positions.Add(new Point3D(268 / w * s, 359 / h * s, 0));
            mesh41.Positions.Add(new Point3D(254 / w * s, 350 / h * s, 0));
            mesh41.Positions.Add(new Point3D(247 / w * s, 354 / h * s, 0));
            mesh41.Positions.Add(new Point3D(260 / w * s, 367 / h * s, 0));
            mesh41.Positions.Add(new Point3D(240 / w * s, 389 / h * s, 0));
            mesh41.Positions.Add(new Point3D(221 / w * s, 388 / h * s, 0));
            //
            mesh41.Positions.Add(new Point3D(217 / w * s, 345 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(242 / w * s, 323 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(258 / w * s, 338 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(269 / w * s, 346 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(268 / w * s, 359 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(254 / w * s, 350 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(247 / w * s, 354 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(260 / w * s, 367 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(240 / w * s, 389 / h * s, up[40]));
            mesh41.Positions.Add(new Point3D(221 / w * s, 388 / h * s, up[40]));
            //Пермский край
            mesh42.Positions.Add(new Point3D(242 / w * s, 321 / h * s, 0));
            mesh42.Positions.Add(new Point3D(256 / w * s, 296 / h * s, 0));
            mesh42.Positions.Add(new Point3D(261 / w * s, 270 / h * s, 0));
            mesh42.Positions.Add(new Point3D(314 / w * s, 281 / h * s, 0));
            mesh42.Positions.Add(new Point3D(258 / w * s, 337 / h * s, 0));
            //
            mesh42.Positions.Add(new Point3D(242 / w * s, 321 / h * s, up[41]));
            mesh42.Positions.Add(new Point3D(256 / w * s, 296 / h * s, up[41]));
            mesh42.Positions.Add(new Point3D(261 / w * s, 270 / h * s, up[41]));
            mesh42.Positions.Add(new Point3D(314 / w * s, 281 / h * s, up[41]));
            mesh42.Positions.Add(new Point3D(258 / w * s, 337 / h * s, up[41]));
            //Удмурская республика
            mesh43.Positions.Add(new Point3D(221 / w * s, 310 / h * s, 0));
            mesh43.Positions.Add(new Point3D(254 / w * s, 296 / h * s, 0));
            mesh43.Positions.Add(new Point3D(243 / w * s, 323 / h * s, 0));
            //
            mesh43.Positions.Add(new Point3D(221 / w * s, 310 / h * s, up[42]));
            mesh43.Positions.Add(new Point3D(254 / w * s, 296 / h * s, up[42]));
            mesh43.Positions.Add(new Point3D(243 / w * s, 323 / h * s, up[42]));
            //Республика Татарстан(Татарстан)
            mesh44.Positions.Add(new Point3D(216 / w * s, 346 / h * s, 0));
            mesh44.Positions.Add(new Point3D(212 / w * s, 334 / h * s, 0));
            mesh44.Positions.Add(new Point3D(200 / w * s, 323 / h * s, 0));
            mesh44.Positions.Add(new Point3D(185 / w * s, 308 / h * s, 0));
            mesh44.Positions.Add(new Point3D(219 / w * s, 301 / h * s, 0));
            mesh44.Positions.Add(new Point3D(221 / w * s, 310 / h * s, 0));
            mesh44.Positions.Add(new Point3D(235 / w * s, 326 / h * s, 0));
            //
            mesh44.Positions.Add(new Point3D(216 / w * s, 346 / h * s, up[43]));
            mesh44.Positions.Add(new Point3D(212 / w * s, 334 / h * s, up[43]));
            mesh44.Positions.Add(new Point3D(200 / w * s, 323 / h * s, up[43]));
            mesh44.Positions.Add(new Point3D(185 / w * s, 308 / h * s, up[43]));
            mesh44.Positions.Add(new Point3D(219 / w * s, 301 / h * s, up[43]));
            mesh44.Positions.Add(new Point3D(221 / w * s, 310 / h * s, up[43]));
            mesh44.Positions.Add(new Point3D(235 / w * s, 326 / h * s, up[43]));
            //Кировская область
            mesh45.Positions.Add(new Point3D(220 / w * s, 311 / h * s, 0));
            mesh45.Positions.Add(new Point3D(219 / w * s, 300 / h * s, 0));
            mesh45.Positions.Add(new Point3D(203 / w * s, 281 / h * s, 0));
            mesh45.Positions.Add(new Point3D(211 / w * s, 268 / h * s, 0));
            mesh45.Positions.Add(new Point3D(227 / w * s, 255 / h * s, 0));
            mesh45.Positions.Add(new Point3D(240 / w * s, 243 / h * s, 0));
            mesh45.Positions.Add(new Point3D(248 / w * s, 250 / h * s, 0));
            mesh45.Positions.Add(new Point3D(240 / w * s, 271 / h * s, 0));
            mesh45.Positions.Add(new Point3D(260 / w * s, 270 / h * s, 0));
            mesh45.Positions.Add(new Point3D(255 / w * s, 296 / h * s, 0));
            //
            mesh45.Positions.Add(new Point3D(220 / w * s, 311 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(219 / w * s, 300 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(203 / w * s, 281 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(211 / w * s, 268 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(227 / w * s, 255 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(240 / w * s, 243 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(248 / w * s, 250 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(240 / w * s, 271 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(260 / w * s, 270 / h * s, up[44]));
            mesh45.Positions.Add(new Point3D(255 / w * s, 296 / h * s, up[44]));
            //Архангельск
            mesh46.Positions.Add(new Point3D(226 / w * s, 164 / h * s, 0));
            mesh46.Positions.Add(new Point3D(282 / w * s, 175 / h * s, 0));
            mesh46.Positions.Add(new Point3D(296 / w * s, 197 / h * s, 0));
            mesh46.Positions.Add(new Point3D(248 / w * s, 249 / h * s, 0));
            mesh46.Positions.Add(new Point3D(239 / w * s, 241 / h * s, 0));
            mesh46.Positions.Add(new Point3D(204 / w * s, 192 / h * s, 0));
            //
            mesh46.Positions.Add(new Point3D(226 / w * s, 164 / h * s, up[45]));
            mesh46.Positions.Add(new Point3D(282 / w * s, 175 / h * s, up[45]));
            mesh46.Positions.Add(new Point3D(296 / w * s, 197 / h * s, up[45]));
            mesh46.Positions.Add(new Point3D(248 / w * s, 249 / h * s, up[45]));
            mesh46.Positions.Add(new Point3D(239 / w * s, 241 / h * s, up[45]));
            mesh46.Positions.Add(new Point3D(204 / w * s, 192 / h * s, up[45]));
            //Вологодская область
            mesh47.Positions.Add(new Point3D(204 / w * s, 193 / h * s, 0));
            mesh47.Positions.Add(new Point3D(240 / w * s, 243 / h * s, 0));
            mesh47.Positions.Add(new Point3D(227 / w * s, 255 / h * s, 0));
            mesh47.Positions.Add(new Point3D(189 / w * s, 236 / h * s, 0));
            mesh47.Positions.Add(new Point3D(173 / w * s, 217 / h * s, 0));
            mesh47.Positions.Add(new Point3D(165 / w * s, 211 / h * s, 0));
            mesh47.Positions.Add(new Point3D(166 / w * s, 199 / h * s, 0));
            mesh47.Positions.Add(new Point3D(189 / w * s, 187 / h * s, 0));
            //
            mesh47.Positions.Add(new Point3D(204 / w * s, 193 / h * s, up[46]));
            mesh47.Positions.Add(new Point3D(240 / w * s, 243 / h * s, up[46]));
            mesh47.Positions.Add(new Point3D(227 / w * s, 255 / h * s, up[46]));
            mesh47.Positions.Add(new Point3D(189 / w * s, 236 / h * s, up[46]));
            mesh47.Positions.Add(new Point3D(173 / w * s, 217 / h * s, up[46]));
            mesh47.Positions.Add(new Point3D(165 / w * s, 211 / h * s, up[46]));
            mesh47.Positions.Add(new Point3D(166 / w * s, 199 / h * s, up[46]));
            mesh47.Positions.Add(new Point3D(189 / w * s, 187 / h * s, up[46]));
            //Мурманская область
            mesh48.Positions.Add(new Point3D(230 / w * s, 110 / h * s, 0));
            mesh48.Positions.Add(new Point3D(245 / w * s, 93 / h * s, 0));
            mesh48.Positions.Add(new Point3D(273 / w * s, 93 / h * s, 0));
            mesh48.Positions.Add(new Point3D(277 / w * s, 152 / h * s, 0));
            mesh48.Positions.Add(new Point3D(268 / w * s, 160 / h * s, 0));
            mesh48.Positions.Add(new Point3D(255 / w * s, 155 / h * s, 0));
            mesh48.Positions.Add(new Point3D(242 / w * s, 128 / h * s, 0));
            //
            mesh48.Positions.Add(new Point3D(230 / w * s, 110 / h * s, up[47]));
            mesh48.Positions.Add(new Point3D(245 / w * s, 93 / h * s, up[47]));
            mesh48.Positions.Add(new Point3D(273 / w * s, 93 / h * s, up[47]));
            mesh48.Positions.Add(new Point3D(277 / w * s, 152 / h * s, up[47]));
            mesh48.Positions.Add(new Point3D(268 / w * s, 160 / h * s, up[47]));
            mesh48.Positions.Add(new Point3D(255 / w * s, 155 / h * s, up[47]));
            mesh48.Positions.Add(new Point3D(242 / w * s, 128 / h * s, up[47]));
            //Реуспублика Карелия
            mesh49.Positions.Add(new Point3D(230 / w * s, 110 / h * s, 0));
            mesh49.Positions.Add(new Point3D(241 / w * s, 128 / h * s, 0));
            mesh49.Positions.Add(new Point3D(226 / w * s, 164 / h * s, 0));
            mesh49.Positions.Add(new Point3D(205 / w * s, 191 / h * s, 0));
            mesh49.Positions.Add(new Point3D(193 / w * s, 183 / h * s, 0));
            mesh49.Positions.Add(new Point3D(174 / w * s, 175 / h * s, 0));
            mesh49.Positions.Add(new Point3D(169 / w * s, 149 / h * s, 0));
            mesh49.Positions.Add(new Point3D(196 / w * s, 150 / h * s, 0));
            //
            mesh49.Positions.Add(new Point3D(230 / w * s, 110 / h * s, up[48]));
            mesh49.Positions.Add(new Point3D(241 / w * s, 128 / h * s, up[48]));
            mesh49.Positions.Add(new Point3D(226 / w * s, 164 / h * s, up[48]));
            mesh49.Positions.Add(new Point3D(205 / w * s, 191 / h * s, up[48]));
            mesh49.Positions.Add(new Point3D(193 / w * s, 183 / h * s, up[48]));
            mesh49.Positions.Add(new Point3D(174 / w * s, 175 / h * s, up[48]));
            mesh49.Positions.Add(new Point3D(169 / w * s, 149 / h * s, up[48]));
            mesh49.Positions.Add(new Point3D(196 / w * s, 150 / h * s, up[48]));
            //Ленинградская область
            mesh50.Positions.Add(new Point3D(168 / w * s, 150 / h * s, 0));
            mesh50.Positions.Add(new Point3D(160 / w * s, 170 / h * s, 0));
            mesh50.Positions.Add(new Point3D(174 / w * s, 175 / h * s, 0));
            mesh50.Positions.Add(new Point3D(193 / w * s, 183 / h * s, 0));
            mesh50.Positions.Add(new Point3D(188 / w * s, 187 / h * s, 0));
            mesh50.Positions.Add(new Point3D(166 / w * s, 198 / h * s, 0));
            mesh50.Positions.Add(new Point3D(136 / w * s, 172 / h * s, 0));
            mesh50.Positions.Add(new Point3D(136 / w * s, 156 / h * s, 0));
            //
            mesh50.Positions.Add(new Point3D(168 / w * s, 150 / h * s, up[49]));
            mesh50.Positions.Add(new Point3D(160 / w * s, 170 / h * s, up[49]));
            mesh50.Positions.Add(new Point3D(174 / w * s, 175 / h * s, up[49]));
            mesh50.Positions.Add(new Point3D(193 / w * s, 183 / h * s, up[49]));
            mesh50.Positions.Add(new Point3D(188 / w * s, 187 / h * s, up[49]));
            mesh50.Positions.Add(new Point3D(166 / w * s, 198 / h * s, up[49]));
            mesh50.Positions.Add(new Point3D(136 / w * s, 172 / h * s, up[49]));
            mesh50.Positions.Add(new Point3D(136 / w * s, 156 / h * s, up[49]));
            //Калининградская область
            mesh51.Positions.Add(new Point3D(52 / w * s, 135 / h * s, 0));
            mesh51.Positions.Add(new Point3D(59 / w * s, 132 / h * s, 0));
            mesh51.Positions.Add(new Point3D(69 / w * s, 137 / h * s, 0));
            mesh51.Positions.Add(new Point3D(70 / w * s, 155 / h * s, 0));
            mesh51.Positions.Add(new Point3D(64 / w * s, 158 / h * s, 0));
            //
            mesh51.Positions.Add(new Point3D(52 / w * s, 135 / h * s, up[50]));
            mesh51.Positions.Add(new Point3D(59 / w * s, 132 / h * s, up[50]));
            mesh51.Positions.Add(new Point3D(69 / w * s, 137 / h * s, up[50]));
            mesh51.Positions.Add(new Point3D(70 / w * s, 155 / h * s, up[50]));
            mesh51.Positions.Add(new Point3D(64 / w * s, 158 / h * s, up[50]));
            //Псковская область
            mesh52.Positions.Add(new Point3D(136 / w * s, 157 / h * s, 0));
            mesh52.Positions.Add(new Point3D(137 / w * s, 172 / h * s, 0));
            mesh52.Positions.Add(new Point3D(125 / w * s, 192 / h * s, 0));
            mesh52.Positions.Add(new Point3D(115 / w * s, 203 / h * s, 0));
            mesh52.Positions.Add(new Point3D(110 / w * s, 203 / h * s, 0));
            mesh52.Positions.Add(new Point3D(111 / w * s, 172 / h * s, 0));
            //
            mesh52.Positions.Add(new Point3D(136 / w * s, 157 / h * s, up[51]));
            mesh52.Positions.Add(new Point3D(137 / w * s, 172 / h * s, up[51]));
            mesh52.Positions.Add(new Point3D(125 / w * s, 192 / h * s, up[51]));
            mesh52.Positions.Add(new Point3D(115 / w * s, 203 / h * s, up[51]));
            mesh52.Positions.Add(new Point3D(110 / w * s, 203 / h * s, up[51]));
            mesh52.Positions.Add(new Point3D(111 / w * s, 172 / h * s, up[51]));
            //Новгородская область
            mesh53.Positions.Add(new Point3D(136 / w * s, 173 / h * s, 0));
            mesh53.Positions.Add(new Point3D(166 / w * s, 197 / h * s, 0));
            mesh53.Positions.Add(new Point3D(166 / w * s, 211 / h * s, 0));
            mesh53.Positions.Add(new Point3D(125 / w * s, 191 / h * s, 0));
            //
            mesh53.Positions.Add(new Point3D(136 / w * s, 173 / h * s, up[52]));
            mesh53.Positions.Add(new Point3D(166 / w * s, 197 / h * s, up[52]));
            mesh53.Positions.Add(new Point3D(166 / w * s, 211 / h * s, up[52]));
            mesh53.Positions.Add(new Point3D(125 / w * s, 191 / h * s, up[52]));
            //Тверская область
            mesh54.Positions.Add(new Point3D(125 / w * s, 193 / h * s, 0));
            mesh54.Positions.Add(new Point3D(166 / w * s, 212 / h * s, 0));
            mesh54.Positions.Add(new Point3D(172 / w * s, 218 / h * s, 0));
            mesh54.Positions.Add(new Point3D(157 / w * s, 236 / h * s, 0));
            mesh54.Positions.Add(new Point3D(132 / w * s, 225 / h * s, 0));
            mesh54.Positions.Add(new Point3D(115 / w * s, 204 / h * s, 0));
            //
            mesh54.Positions.Add(new Point3D(125 / w * s, 193 / h * s, up[53]));
            mesh54.Positions.Add(new Point3D(166 / w * s, 212 / h * s, up[53]));
            mesh54.Positions.Add(new Point3D(172 / w * s, 218 / h * s, up[53]));
            mesh54.Positions.Add(new Point3D(157 / w * s, 236 / h * s, up[53]));
            mesh54.Positions.Add(new Point3D(132 / w * s, 225 / h * s, up[53]));
            mesh54.Positions.Add(new Point3D(115 / w * s, 204 / h * s, up[53]));
            //Ярославльская область
            mesh55.Positions.Add(new Point3D(173 / w * s, 218 / h * s, 0));
            mesh55.Positions.Add(new Point3D(189 / w * s, 236 / h * s, 0));
            mesh55.Positions.Add(new Point3D(175 / w * s, 244 / h * s, 0));
            mesh55.Positions.Add(new Point3D(165 / w * s, 244 / h * s, 0));
            mesh55.Positions.Add(new Point3D(157 / w * s, 236 / h * s, 0));
            //
            mesh55.Positions.Add(new Point3D(173 / w * s, 218 / h * s, up[54]));
            mesh55.Positions.Add(new Point3D(189 / w * s, 236 / h * s, up[54]));
            mesh55.Positions.Add(new Point3D(175 / w * s, 244 / h * s, up[54]));
            mesh55.Positions.Add(new Point3D(165 / w * s, 244 / h * s, up[54]));
            mesh55.Positions.Add(new Point3D(157 / w * s, 236 / h * s, up[54]));
            //Костромская область
            mesh56.Positions.Add(new Point3D(189 / w * s, 237 / h * s, 0));
            mesh56.Positions.Add(new Point3D(228 / w * s, 256 / h * s, 0));
            mesh56.Positions.Add(new Point3D(212 / w * s, 269 / h * s, 0));
            mesh56.Positions.Add(new Point3D(187 / w * s, 262 / h * s, 0));
            mesh56.Positions.Add(new Point3D(174 / w * s, 244 / h * s, 0));
            //
            mesh56.Positions.Add(new Point3D(189 / w * s, 237 / h * s, up[55]));
            mesh56.Positions.Add(new Point3D(228 / w * s, 256 / h * s, up[55]));
            mesh56.Positions.Add(new Point3D(212 / w * s, 269 / h * s, up[55]));
            mesh56.Positions.Add(new Point3D(187 / w * s, 262 / h * s, up[55]));
            mesh56.Positions.Add(new Point3D(174 / w * s, 244 / h * s, up[55]));
            //Ивановская область
            mesh57.Positions.Add(new Point3D(164 / w * s, 243 / h * s, 0));
            mesh57.Positions.Add(new Point3D(175 / w * s, 244 / h * s, 0));
            mesh57.Positions.Add(new Point3D(187 / w * s, 262 / h * s, 0));
            mesh57.Positions.Add(new Point3D(175 / w * s, 264 / h * s, 0));
            //
            mesh57.Positions.Add(new Point3D(164 / w * s, 243 / h * s, up[56]));
            mesh57.Positions.Add(new Point3D(175 / w * s, 244 / h * s, up[56]));
            mesh57.Positions.Add(new Point3D(187 / w * s, 262 / h * s, up[56]));
            mesh57.Positions.Add(new Point3D(175 / w * s, 264 / h * s, up[56]));
            //Владимирская область
            mesh58.Positions.Add(new Point3D(157 / w * s, 238 / h * s, 0));
            mesh58.Positions.Add(new Point3D(164 / w * s, 244 / h * s, 0));
            mesh58.Positions.Add(new Point3D(175 / w * s, 266 / h * s, 0));
            mesh58.Positions.Add(new Point3D(158 / w * s, 272 / h * s, 0));
            mesh58.Positions.Add(new Point3D(152 / w * s, 261 / h * s, 0));
            //
            mesh58.Positions.Add(new Point3D(157 / w * s, 238 / h * s, up[57]));
            mesh58.Positions.Add(new Point3D(164 / w * s, 244 / h * s, up[57]));
            mesh58.Positions.Add(new Point3D(175 / w * s, 266 / h * s, up[57]));
            mesh58.Positions.Add(new Point3D(158 / w * s, 272 / h * s, up[57]));
            mesh58.Positions.Add(new Point3D(152 / w * s, 261 / h * s, up[57]));
            //Нижегородская область
            mesh59.Positions.Add(new Point3D(175 / w * s, 265 / h * s, 0));
            mesh59.Positions.Add(new Point3D(186 / w * s, 262 / h * s, 0));
            //mesh59.Positions.Add(new Point3D(187 / w * s, 263 / h * s, 0));
            mesh59.Positions.Add(new Point3D(211 / w * s, 269 / h * s, 0));
            mesh59.Positions.Add(new Point3D(204 / w * s, 280 / h * s, 0));
            mesh59.Positions.Add(new Point3D(190 / w * s, 287 / h * s, 0));
            mesh59.Positions.Add(new Point3D(182 / w * s, 296 / h * s, 0));
            mesh59.Positions.Add(new Point3D(160 / w * s, 279 / h * s, 0));
            mesh59.Positions.Add(new Point3D(159 / w * s, 272 / h * s, 0));
            //
            mesh59.Positions.Add(new Point3D(175 / w * s, 265 / h * s, up[58]));
            mesh59.Positions.Add(new Point3D(186 / w * s, 262 / h * s, up[58]));
            //mesh59.Positions.Add(new Point3D(187 / w * s, 263 / h * s, up[58]));
            mesh59.Positions.Add(new Point3D(211 / w * s, 269 / h * s, up[58]));
            mesh59.Positions.Add(new Point3D(204 / w * s, 280 / h * s, up[58]));
            mesh59.Positions.Add(new Point3D(190 / w * s, 287 / h * s, up[58]));
            mesh59.Positions.Add(new Point3D(182 / w * s, 296 / h * s, up[58]));
            mesh59.Positions.Add(new Point3D(160 / w * s, 279 / h * s, up[58]));
            mesh59.Positions.Add(new Point3D(159 / w * s, 272 / h * s, up[58]));
            //Республика Марий Эл
            mesh60.Positions.Add(new Point3D(191 / w * s, 288 / h * s, 0));
            mesh60.Positions.Add(new Point3D(203 / w * s, 281 / h * s, 0));
            mesh60.Positions.Add(new Point3D(219 / w * s, 302 / h * s, 0));
            mesh60.Positions.Add(new Point3D(200 / w * s, 300 / h * s, 0));
            //
            mesh60.Positions.Add(new Point3D(191 / w * s, 288 / h * s, up[59]));
            mesh60.Positions.Add(new Point3D(203 / w * s, 281 / h * s, up[59]));
            mesh60.Positions.Add(new Point3D(219 / w * s, 302 / h * s, up[59]));
            mesh60.Positions.Add(new Point3D(200 / w * s, 300 / h * s, up[59]));
            //Чувашия
            mesh61.Positions.Add(new Point3D(191 / w * s, 288 / h * s, 0));
            mesh61.Positions.Add(new Point3D(200 / w * s, 301 / h * s, 0));
            mesh61.Positions.Add(new Point3D(186 / w * s, 309 / h * s, 0));
            mesh61.Positions.Add(new Point3D(180 / w * s, 302 / h * s, 0));
            mesh61.Positions.Add(new Point3D(181 / w * s, 296 / h * s, 0));
            //
            mesh61.Positions.Add(new Point3D(191 / w * s, 288 / h * s, up[60]));
            mesh61.Positions.Add(new Point3D(200 / w * s, 301 / h * s, up[60]));
            mesh61.Positions.Add(new Point3D(186 / w * s, 309 / h * s, up[60]));
            mesh61.Positions.Add(new Point3D(180 / w * s, 302 / h * s, up[60]));
            mesh61.Positions.Add(new Point3D(181 / w * s, 296 / h * s, up[60]));
            //Самарская область
            mesh62.Positions.Add(new Point3D(199 / w * s, 323 / h * s, 0));
            mesh62.Positions.Add(new Point3D(212 / w * s, 334 / h * s, 0));
            mesh62.Positions.Add(new Point3D(180 / w * s, 355 / h * s, 0));
            mesh62.Positions.Add(new Point3D(174 / w * s, 331 / h * s, 0));
            //
            mesh62.Positions.Add(new Point3D(199 / w * s, 323 / h * s, up[61]));
            mesh62.Positions.Add(new Point3D(212 / w * s, 334 / h * s, up[61]));
            mesh62.Positions.Add(new Point3D(180 / w * s, 355 / h * s, up[61]));
            mesh62.Positions.Add(new Point3D(174 / w * s, 331 / h * s, up[61]));
            //Саратовская область
            mesh63.Positions.Add(new Point3D(150 / w * s, 364 / h * s, 0));
            mesh63.Positions.Add(new Point3D(145 / w * s, 353 / h * s, 0));
            mesh63.Positions.Add(new Point3D(126 / w * s, 316 / h * s, 0));
            mesh63.Positions.Add(new Point3D(128 / w * s, 308 / h * s, 0));
            mesh63.Positions.Add(new Point3D(140 / w * s, 304 / h * s, 0));
            mesh63.Positions.Add(new Point3D(164 / w * s, 323 / h * s, 0));
            mesh63.Positions.Add(new Point3D(174 / w * s, 332 / h * s, 0));
            mesh63.Positions.Add(new Point3D(180 / w * s, 355 / h * s, 0));
            //
            mesh63.Positions.Add(new Point3D(150 / w * s, 364 / h * s, up[62]));
            mesh63.Positions.Add(new Point3D(145 / w * s, 353 / h * s, up[62]));
            mesh63.Positions.Add(new Point3D(126 / w * s, 316 / h * s, up[62]));
            mesh63.Positions.Add(new Point3D(128 / w * s, 308 / h * s, up[62]));
            mesh63.Positions.Add(new Point3D(140 / w * s, 304 / h * s, up[62]));
            mesh63.Positions.Add(new Point3D(164 / w * s, 323 / h * s, up[62]));
            mesh63.Positions.Add(new Point3D(174 / w * s, 332 / h * s, up[62]));
            mesh63.Positions.Add(new Point3D(180 / w * s, 355 / h * s, up[62]));
            //Ульяновская область
            mesh64.Positions.Add(new Point3D(175 / w * s, 331 / h * s, 0));
            mesh64.Positions.Add(new Point3D(164 / w * s, 323 / h * s, 0));
            mesh64.Positions.Add(new Point3D(170 / w * s, 305 / h * s, 0));
            mesh64.Positions.Add(new Point3D(181 / w * s, 302 / h * s, 0));
            mesh64.Positions.Add(new Point3D(185 / w * s, 308 / h * s, 0));
            mesh64.Positions.Add(new Point3D(200 / w * s, 323 / h * s, 0));
            //
            mesh64.Positions.Add(new Point3D(175 / w * s, 331 / h * s, up[63]));
            mesh64.Positions.Add(new Point3D(164 / w * s, 323 / h * s, up[63]));
            mesh64.Positions.Add(new Point3D(170 / w * s, 305 / h * s, up[63]));
            mesh64.Positions.Add(new Point3D(181 / w * s, 302 / h * s, up[63]));
            mesh64.Positions.Add(new Point3D(185 / w * s, 308 / h * s, up[63]));
            mesh64.Positions.Add(new Point3D(200 / w * s, 323 / h * s, up[63]));
            //Пензенская область
            mesh65.Positions.Add(new Point3D(140 / w * s, 304 / h * s, 0));
            mesh65.Positions.Add(new Point3D(146 / w * s, 287 / h * s, 0));
            mesh65.Positions.Add(new Point3D(170 / w * s, 305 / h * s, 0));
            mesh65.Positions.Add(new Point3D(164 / w * s, 325 / h * s, 0));
            //
            mesh65.Positions.Add(new Point3D(140 / w * s, 304 / h * s, up[64]));
            mesh65.Positions.Add(new Point3D(146 / w * s, 287 / h * s, up[64]));
            mesh65.Positions.Add(new Point3D(170 / w * s, 305 / h * s, up[64]));
            mesh65.Positions.Add(new Point3D(164 / w * s, 325 / h * s, up[64]));
            //Саранская область
            mesh66.Positions.Add(new Point3D(151 / w * s, 287 / h * s, 0));
            mesh66.Positions.Add(new Point3D(160 / w * s, 278 / h * s, 0));
            mesh66.Positions.Add(new Point3D(181 / w * s, 296 / h * s, 0));
            mesh66.Positions.Add(new Point3D(180 / w * s, 302 / h * s, 0));
            mesh66.Positions.Add(new Point3D(170 / w * s, 305 / h * s, 0));
            //
            mesh66.Positions.Add(new Point3D(151 / w * s, 287 / h * s, up[65]));
            mesh66.Positions.Add(new Point3D(160 / w * s, 278 / h * s, up[65]));
            mesh66.Positions.Add(new Point3D(181 / w * s, 296 / h * s, up[65]));
            mesh66.Positions.Add(new Point3D(180 / w * s, 302 / h * s, up[65]));
            mesh66.Positions.Add(new Point3D(170 / w * s, 305 / h * s, up[65]));
            //Рязанская область
            mesh67.Positions.Add(new Point3D(152 / w * s, 287 / h * s, 0));
            mesh67.Positions.Add(new Point3D(146 / w * s, 287 / h * s, 0));
            mesh67.Positions.Add(new Point3D(132 / w * s, 278 / h * s, 0));
            mesh67.Positions.Add(new Point3D(127 / w * s, 270 / h * s, 0));
            mesh67.Positions.Add(new Point3D(133 / w * s, 262 / h * s, 0));
            mesh67.Positions.Add(new Point3D(152 / w * s, 262 / h * s, 0));
            mesh67.Positions.Add(new Point3D(159 / w * s, 272 / h * s, 0));
            mesh67.Positions.Add(new Point3D(160 / w * s, 279 / h * s, 0));
            //
            mesh67.Positions.Add(new Point3D(152 / w * s, 287 / h * s, up[66]));
            mesh67.Positions.Add(new Point3D(146 / w * s, 287 / h * s, up[66]));
            mesh67.Positions.Add(new Point3D(132 / w * s, 278 / h * s, up[66]));
            mesh67.Positions.Add(new Point3D(127 / w * s, 270 / h * s, up[66]));
            mesh67.Positions.Add(new Point3D(133 / w * s, 262 / h * s, up[66]));
            mesh67.Positions.Add(new Point3D(152 / w * s, 262 / h * s, up[66]));
            mesh67.Positions.Add(new Point3D(159 / w * s, 272 / h * s, up[66]));
            mesh67.Positions.Add(new Point3D(160 / w * s, 279 / h * s, up[66]));
            //Смоленская область
            mesh68.Positions.Add(new Point3D(110 / w * s, 203 / h * s, 0));
            mesh68.Positions.Add(new Point3D(115 / w * s, 204 / h * s, 0));
            mesh68.Positions.Add(new Point3D(132 / w * s, 225 / h * s, 0));
            mesh68.Positions.Add(new Point3D(127 / w * s, 234 / h * s, 0));
            mesh68.Positions.Add(new Point3D(101 / w * s, 233 / h * s, 0));
            mesh68.Positions.Add(new Point3D(94 / w * s, 231 / h * s, 0));
            //
            mesh68.Positions.Add(new Point3D(110 / w * s, 203 / h * s, up[67]));
            mesh68.Positions.Add(new Point3D(115 / w * s, 204 / h * s, up[67]));
            mesh68.Positions.Add(new Point3D(132 / w * s, 225 / h * s, up[67]));
            mesh68.Positions.Add(new Point3D(127 / w * s, 234 / h * s, up[67]));
            mesh68.Positions.Add(new Point3D(101 / w * s, 233 / h * s, up[67]));
            mesh68.Positions.Add(new Point3D(94 / w * s, 231 / h * s, up[67]));
            //Калужская область
            mesh69.Positions.Add(new Point3D(128 / w * s, 234 / h * s, 0));
            mesh69.Positions.Add(new Point3D(130 / w * s, 249 / h * s, 0));
            mesh69.Positions.Add(new Point3D(112 / w * s, 250 / h * s, 0));
            mesh69.Positions.Add(new Point3D(103 / w * s, 246 / h * s, 0));
            mesh69.Positions.Add(new Point3D(101 / w * s, 233 / h * s, 0));
            //
            mesh69.Positions.Add(new Point3D(128 / w * s, 234 / h * s, up[68]));
            mesh69.Positions.Add(new Point3D(130 / w * s, 249 / h * s, up[68]));
            mesh69.Positions.Add(new Point3D(112 / w * s, 250 / h * s, up[68]));
            mesh69.Positions.Add(new Point3D(103 / w * s, 246 / h * s, up[68]));
            mesh69.Positions.Add(new Point3D(101 / w * s, 233 / h * s, up[68]));
            //Брянская область
            mesh70.Positions.Add(new Point3D(84 / w * s, 225 / h * s, 0));
            mesh70.Positions.Add(new Point3D(95 / w * s, 232 / h * s, 0));
            mesh70.Positions.Add(new Point3D(101 / w * s, 232 / h * s, 0));
            mesh70.Positions.Add(new Point3D(103 / w * s, 246 / h * s, 0));
            mesh70.Positions.Add(new Point3D(94 / w * s, 255 / h * s, 0));
            mesh70.Positions.Add(new Point3D(85 / w * s, 254 / h * s, 0));
            mesh70.Positions.Add(new Point3D(75 / w * s, 235 / h * s, 0));
            //
            mesh70.Positions.Add(new Point3D(84 / w * s, 225 / h * s, up[69]));
            mesh70.Positions.Add(new Point3D(95 / w * s, 232 / h * s, up[69]));
            mesh70.Positions.Add(new Point3D(101 / w * s, 232 / h * s, up[69]));
            mesh70.Positions.Add(new Point3D(103 / w * s, 246 / h * s, up[69]));
            mesh70.Positions.Add(new Point3D(94 / w * s, 255 / h * s, up[69]));
            mesh70.Positions.Add(new Point3D(85 / w * s, 254 / h * s, up[69]));
            mesh70.Positions.Add(new Point3D(75 / w * s, 235 / h * s, up[69]));
            //Тульская область
            mesh71.Positions.Add(new Point3D(112 / w * s, 250 / h * s, 0));
            mesh71.Positions.Add(new Point3D(131 / w * s, 250 / h * s, 0));
            mesh71.Positions.Add(new Point3D(134 / w * s, 261 / h * s, 0));
            mesh71.Positions.Add(new Point3D(126 / w * s, 269 / h * s, 0));
            mesh71.Positions.Add(new Point3D(116 / w * s, 268 / h * s, 0));
            //
            mesh71.Positions.Add(new Point3D(112 / w * s, 250 / h * s, up[70]));
            mesh71.Positions.Add(new Point3D(131 / w * s, 250 / h * s, up[70]));
            mesh71.Positions.Add(new Point3D(134 / w * s, 261 / h * s, up[70]));
            mesh71.Positions.Add(new Point3D(126 / w * s, 269 / h * s, up[70]));
            mesh71.Positions.Add(new Point3D(116 / w * s, 268 / h * s, up[70]));
            //Московская область
            mesh72.Positions.Add(new Point3D(132 / w * s, 225 / h * s, 0));
            mesh72.Positions.Add(new Point3D(157 / w * s, 238 / h * s, 0));
            mesh72.Positions.Add(new Point3D(153 / w * s, 261 / h * s, 0));
            mesh72.Positions.Add(new Point3D(132 / w * s, 262 / h * s, 0));
            mesh72.Positions.Add(new Point3D(131 / w * s, 250 / h * s, 0));
            mesh72.Positions.Add(new Point3D(129 / w * s, 234 / h * s, 0));
            //
            mesh72.Positions.Add(new Point3D(132 / w * s, 225 / h * s, up[71]));
            mesh72.Positions.Add(new Point3D(157 / w * s, 238 / h * s, up[71]));
            mesh72.Positions.Add(new Point3D(153 / w * s, 261 / h * s, up[71]));
            mesh72.Positions.Add(new Point3D(132 / w * s, 262 / h * s, up[71]));
            mesh72.Positions.Add(new Point3D(131 / w * s, 250 / h * s, up[71]));
            mesh72.Positions.Add(new Point3D(129 / w * s, 234 / h * s, up[71]));
            //Курская область
            mesh73.Positions.Add(new Point3D(85 / w * s, 254 / h * s, 0));
            mesh73.Positions.Add(new Point3D(93 / w * s, 254 / h * s, 0));
            mesh73.Positions.Add(new Point3D(104 / w * s, 275 / h * s, 0));
            mesh73.Positions.Add(new Point3D(107 / w * s, 281 / h * s, 0));
            mesh73.Positions.Add(new Point3D(100 / w * s, 282 / h * s, 0));
            mesh73.Positions.Add(new Point3D(81 / w * s, 271 / h * s, 0));
            //
            mesh73.Positions.Add(new Point3D(85 / w * s, 254 / h * s, up[72]));
            mesh73.Positions.Add(new Point3D(93 / w * s, 254 / h * s, up[72]));
            mesh73.Positions.Add(new Point3D(104 / w * s, 275 / h * s, up[72]));
            mesh73.Positions.Add(new Point3D(107 / w * s, 281 / h * s, up[72]));
            mesh73.Positions.Add(new Point3D(100 / w * s, 282 / h * s, up[72]));
            mesh73.Positions.Add(new Point3D(81 / w * s, 271 / h * s, up[72]));
            //Орловская область
            mesh74.Positions.Add(new Point3D(103 / w * s, 247 / h * s, 0));
            mesh74.Positions.Add(new Point3D(112 / w * s, 251 / h * s, 0));
            mesh74.Positions.Add(new Point3D(116 / w * s, 268 / h * s, 0));
            mesh74.Positions.Add(new Point3D(105 / w * s, 275 / h * s, 0));
            mesh74.Positions.Add(new Point3D(94 / w * s, 254 / h * s, 0));
            //
            mesh74.Positions.Add(new Point3D(103 / w * s, 247 / h * s, up[73]));
            mesh74.Positions.Add(new Point3D(112 / w * s, 251 / h * s, up[73]));
            mesh74.Positions.Add(new Point3D(116 / w * s, 268 / h * s, up[73]));
            mesh74.Positions.Add(new Point3D(105 / w * s, 275 / h * s, up[73]));
            mesh74.Positions.Add(new Point3D(94 / w * s, 254 / h * s, up[73]));
            //Липецкая область
            mesh75.Positions.Add(new Point3D(116 / w * s, 269 / h * s, 0));
            mesh75.Positions.Add(new Point3D(127 / w * s, 270 / h * s, 0));
            mesh75.Positions.Add(new Point3D(131 / w * s, 279 / h * s, 0));
            mesh75.Positions.Add(new Point3D(120 / w * s, 294 / h * s, 0));
            mesh75.Positions.Add(new Point3D(108 / w * s, 281 / h * s, 0));
            mesh75.Positions.Add(new Point3D(105 / w * s, 275 / h * s, 0));
            //
            mesh75.Positions.Add(new Point3D(116 / w * s, 269 / h * s, up[74]));
            mesh75.Positions.Add(new Point3D(127 / w * s, 270 / h * s, up[74]));
            mesh75.Positions.Add(new Point3D(131 / w * s, 279 / h * s, up[74]));
            mesh75.Positions.Add(new Point3D(120 / w * s, 294 / h * s, up[74]));
            mesh75.Positions.Add(new Point3D(108 / w * s, 281 / h * s, up[74]));
            mesh75.Positions.Add(new Point3D(105 / w * s, 275 / h * s, up[74]));
            //Тамбовская область
            mesh76.Positions.Add(new Point3D(131 / w * s, 279 / h * s, 0));
            mesh76.Positions.Add(new Point3D(145 / w * s, 287 / h * s, 0));
            mesh76.Positions.Add(new Point3D(140 / w * s, 304 / h * s, 0));
            mesh76.Positions.Add(new Point3D(129 / w * s, 308 / h * s, 0));
            mesh76.Positions.Add(new Point3D(120 / w * s, 295 / h * s, 0));
            //
            mesh76.Positions.Add(new Point3D(131 / w * s, 279 / h * s, up[75]));
            mesh76.Positions.Add(new Point3D(145 / w * s, 287 / h * s, up[75]));
            mesh76.Positions.Add(new Point3D(140 / w * s, 304 / h * s, up[75]));
            mesh76.Positions.Add(new Point3D(129 / w * s, 308 / h * s, up[75]));
            mesh76.Positions.Add(new Point3D(120 / w * s, 295 / h * s, up[75]));
            //Белгородская область
            mesh77.Positions.Add(new Point3D(80 / w * s, 271 / h * s, 0));
            mesh77.Positions.Add(new Point3D(100 / w * s, 283 / h * s, 0));
            mesh77.Positions.Add(new Point3D(91 / w * s, 303 / h * s, 0));
            //
            mesh77.Positions.Add(new Point3D(80 / w * s, 271 / h * s, up[76]));
            mesh77.Positions.Add(new Point3D(100 / w * s, 283 / h * s, up[76]));
            mesh77.Positions.Add(new Point3D(91 / w * s, 303 / h * s, up[76]));
            //Воронежская область
            mesh78.Positions.Add(new Point3D(101 / w * s, 283 / h * s, 0));
            mesh78.Positions.Add(new Point3D(107 / w * s, 282 / h * s, 0));
            mesh78.Positions.Add(new Point3D(120 / w * s, 294 / h * s, 0));
            mesh78.Positions.Add(new Point3D(128 / w * s, 309 / h * s, 0));
            mesh78.Positions.Add(new Point3D(126 / w * s, 314 / h * s, 0));
            mesh78.Positions.Add(new Point3D(106 / w * s, 316 / h * s, 0));
            mesh78.Positions.Add(new Point3D(92 / w * s, 313 / h * s, 0));
            mesh78.Positions.Add(new Point3D(90 / w * s, 304 / h * s, 0));
            //
            mesh78.Positions.Add(new Point3D(101 / w * s, 283 / h * s, up[77]));
            mesh78.Positions.Add(new Point3D(107 / w * s, 282 / h * s, up[77]));
            mesh78.Positions.Add(new Point3D(120 / w * s, 294 / h * s, up[77]));
            mesh78.Positions.Add(new Point3D(128 / w * s, 309 / h * s, up[77]));
            mesh78.Positions.Add(new Point3D(126 / w * s, 314 / h * s, up[77]));
            mesh78.Positions.Add(new Point3D(106 / w * s, 316 / h * s, up[77]));
            mesh78.Positions.Add(new Point3D(92 / w * s, 313 / h * s, up[77]));
            mesh78.Positions.Add(new Point3D(90 / w * s, 304 / h * s, up[77]));
            //Волгоградская область
            mesh79.Positions.Add(new Point3D(145 / w * s, 353 / h * s, 0));
            mesh79.Positions.Add(new Point3D(125 / w * s, 364 / h * s, 0));
            mesh79.Positions.Add(new Point3D(111 / w * s, 358 / h * s, 0));
            mesh79.Positions.Add(new Point3D(95 / w * s, 355 / h * s, 0));
            mesh79.Positions.Add(new Point3D(90 / w * s, 340 / h * s, 0));
            mesh79.Positions.Add(new Point3D(106 / w * s, 316 / h * s, 0));
            mesh79.Positions.Add(new Point3D(126 / w * s, 315 / h * s, 0));
            //
            mesh79.Positions.Add(new Point3D(145 / w * s, 353 / h * s, up[78]));
            mesh79.Positions.Add(new Point3D(125 / w * s, 364 / h * s, up[78]));
            mesh79.Positions.Add(new Point3D(111 / w * s, 358 / h * s, up[78]));
            mesh79.Positions.Add(new Point3D(95 / w * s, 355 / h * s, up[78]));
            mesh79.Positions.Add(new Point3D(90 / w * s, 340 / h * s, up[78]));
            mesh79.Positions.Add(new Point3D(106 / w * s, 316 / h * s, up[78]));
            mesh79.Positions.Add(new Point3D(126 / w * s, 315 / h * s, up[78]));
            //Астраханская область
            mesh80.Positions.Add(new Point3D(122 / w * s, 402 / h * s, 0));
            mesh80.Positions.Add(new Point3D(101 / w * s, 401 / h * s, 0));
            mesh80.Positions.Add(new Point3D(103 / w * s, 388 / h * s, 0));
            mesh80.Positions.Add(new Point3D(111 / w * s, 388 / h * s, 0));
            mesh80.Positions.Add(new Point3D(111 / w * s, 358 / h * s, 0));
            mesh80.Positions.Add(new Point3D(125 / w * s, 364 / h * s, 0));
            //
            mesh80.Positions.Add(new Point3D(122 / w * s, 402 / h * s, up[79]));
            mesh80.Positions.Add(new Point3D(101 / w * s, 401 / h * s, up[79]));
            mesh80.Positions.Add(new Point3D(103 / w * s, 388 / h * s, up[79]));
            mesh80.Positions.Add(new Point3D(111 / w * s, 388 / h * s, up[79]));
            mesh80.Positions.Add(new Point3D(111 / w * s, 358 / h * s, up[79]));
            mesh80.Positions.Add(new Point3D(125 / w * s, 364 / h * s, up[79]));
            //Ростовская область!!!!!!! :)
            mesh81.Positions.Add(new Point3D(61 / w * s, 320 / h * s, 0));
            mesh81.Positions.Add(new Point3D(74 / w * s, 326 / h * s, 0));
            mesh81.Positions.Add(new Point3D(92 / w * s, 315 / h * s, 0));
            mesh81.Positions.Add(new Point3D(106 / w * s, 317 / h * s, 0));
            mesh81.Positions.Add(new Point3D(91 / w * s, 340 / h * s, 0));
            mesh81.Positions.Add(new Point3D(95 / w * s, 356 / h * s, 0));
            mesh81.Positions.Add(new Point3D(86 / w * s, 369 / h * s, 0));
            mesh81.Positions.Add(new Point3D(63 / w * s, 355 / h * s, 0));
            mesh81.Positions.Add(new Point3D(55 / w * s, 329 / h * s, 0));
            //
            mesh81.Positions.Add(new Point3D(61 / w * s, 320 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(74 / w * s, 326 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(92 / w * s, 315 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(106 / w * s, 317 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(91 / w * s, 340 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(95 / w * s, 356 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(86 / w * s, 369 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(63 / w * s, 355 / h * s, up[80]));
            mesh81.Positions.Add(new Point3D(55 / w * s, 329 / h * s, up[80]));
            //Республика Калмыкия
            mesh82.Positions.Add(new Point3D(91 / w * s, 403 / h * s, 0));
            mesh82.Positions.Add(new Point3D(84 / w * s, 396 / h * s, 0));
            mesh82.Positions.Add(new Point3D(63 / w * s, 356 / h * s, 0));
            mesh82.Positions.Add(new Point3D(87 / w * s, 368 / h * s, 0));
            mesh82.Positions.Add(new Point3D(95 / w * s, 355 / h * s, 0));
            mesh82.Positions.Add(new Point3D(112 / w * s, 359 / h * s, 0));
            mesh82.Positions.Add(new Point3D(111 / w * s, 387 / h * s, 0));
            mesh82.Positions.Add(new Point3D(102 / w * s, 389 / h * s, 0));
            mesh82.Positions.Add(new Point3D(101 / w * s, 403 / h * s, 0));
            //
            mesh82.Positions.Add(new Point3D(91 / w * s, 403 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(84 / w * s, 396 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(63 / w * s, 356 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(87 / w * s, 368 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(95 / w * s, 355 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(112 / w * s, 359 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(111 / w * s, 387 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(102 / w * s, 389 / h * s, up[81]));
            mesh82.Positions.Add(new Point3D(101 / w * s, 403 / h * s, up[81]));
            //Ставропольский край
            mesh83.Positions.Add(new Point3D(63 / w * s, 355 / h * s, 0));
            mesh83.Positions.Add(new Point3D(84 / w * s, 396 / h * s, 0));
            mesh83.Positions.Add(new Point3D(72 / w * s, 402 / h * s, 0));
            mesh83.Positions.Add(new Point3D(64 / w * s, 401 / h * s, 0));
            mesh83.Positions.Add(new Point3D(52 / w * s, 386 / h * s, 0));
            mesh83.Positions.Add(new Point3D(51 / w * s, 373 / h * s, 0));
            //
            mesh83.Positions.Add(new Point3D(63 / w * s, 355 / h * s, up[82]));
            mesh83.Positions.Add(new Point3D(84 / w * s, 396 / h * s, up[82]));
            mesh83.Positions.Add(new Point3D(72 / w * s, 402 / h * s, up[82]));
            mesh83.Positions.Add(new Point3D(64 / w * s, 401 / h * s, up[82]));
            mesh83.Positions.Add(new Point3D(52 / w * s, 386 / h * s, up[82]));
            mesh83.Positions.Add(new Point3D(51 / w * s, 373 / h * s, up[82]));
            //Москва
            mesh84.Positions.Add(new Point3D(139 / w * s, 240 / h * s, 0));
            mesh84.Positions.Add(new Point3D(146 / w * s, 240 / h * s, 0));
            mesh84.Positions.Add(new Point3D(145 / w * s, 247 / h * s, 0));
            mesh84.Positions.Add(new Point3D(139 / w * s, 246 / h * s, 0));
            //
            mesh84.Positions.Add(new Point3D(139 / w * s, 240 / h * s, up[83]));
            mesh84.Positions.Add(new Point3D(146 / w * s, 240 / h * s, up[83]));
            mesh84.Positions.Add(new Point3D(145 / w * s, 247 / h * s, up[83]));
            mesh84.Positions.Add(new Point3D(139 / w * s, 246 / h * s, up[83]));
            //СПБ
            mesh85.Positions.Add(new Point3D(152 / w * s, 159 / h * s, 0));
            mesh85.Positions.Add(new Point3D(158 / w * s, 158 / h * s, 0));
            mesh85.Positions.Add(new Point3D(158 / w * s, 164 / h * s, 0));
            mesh85.Positions.Add(new Point3D(152 / w * s, 164 / h * s, 0));
            //
            mesh85.Positions.Add(new Point3D(152 / w * s, 159 / h * s, up[84]));
            mesh85.Positions.Add(new Point3D(158 / w * s, 158 / h * s, up[84]));
            mesh85.Positions.Add(new Point3D(158 / w * s, 164 / h * s, up[84]));
            mesh85.Positions.Add(new Point3D(152 / w * s, 164 / h * s, up[84]));
        }
        static void sides(MeshGeometry3D mesh,int n)
        {
            for (int i=0;i<n-1;i++)
            {
                Tri(mesh, i, i+1, i+n);
                Tri(mesh, i, i + n, i + 1);
                Tri(mesh, i+1, i + n, i + n + 1);
                Tri(mesh, i + 1, i + n + 1, i + n);
            }
            Tri(mesh, 0, n - 1, n);
            Tri(mesh, 0, n, n - 1);
            Tri(mesh, n, n - 1, n + n - 1);
            Tri(mesh, n, n + n - 1, n - 1);
        }
        static void surf(MeshGeometry3D mesh, int n)
        {
            for (int i = 0; i < n - 2; i++)
                DDTri(mesh, 0, i + 1,i+2,n);
        }
        /// <summary>
        /// 
        /// ТРЕУГОЛЬНИКИ
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        static void Triangles(/*MeshGeometry3D mesh*/
            MeshGeometry3D mesh1, MeshGeometry3D mesh2, MeshGeometry3D mesh3, MeshGeometry3D mesh4, MeshGeometry3D mesh5, MeshGeometry3D mesh6, MeshGeometry3D mesh7, MeshGeometry3D mesh8,
            MeshGeometry3D mesh9, MeshGeometry3D mesh10, MeshGeometry3D mesh11, MeshGeometry3D mesh12, MeshGeometry3D mesh13, MeshGeometry3D mesh14, MeshGeometry3D mesh15, MeshGeometry3D mesh16,
            MeshGeometry3D mesh17, MeshGeometry3D mesh18, MeshGeometry3D mesh19, MeshGeometry3D mesh20, MeshGeometry3D mesh21, MeshGeometry3D mesh22, MeshGeometry3D mesh23, MeshGeometry3D mesh24,
            MeshGeometry3D mesh25, MeshGeometry3D mesh26, MeshGeometry3D mesh27, MeshGeometry3D mesh28, MeshGeometry3D mesh29, MeshGeometry3D mesh30, MeshGeometry3D mesh31, MeshGeometry3D mesh32,
            MeshGeometry3D mesh33, MeshGeometry3D mesh34, MeshGeometry3D mesh35, MeshGeometry3D mesh36, MeshGeometry3D mesh37, MeshGeometry3D mesh38, MeshGeometry3D mesh39, MeshGeometry3D mesh40,
            MeshGeometry3D mesh41, MeshGeometry3D mesh42, MeshGeometry3D mesh43, MeshGeometry3D mesh44, MeshGeometry3D mesh45, MeshGeometry3D mesh46, MeshGeometry3D mesh47, MeshGeometry3D mesh48,
            MeshGeometry3D mesh49, MeshGeometry3D mesh50, MeshGeometry3D mesh51, MeshGeometry3D mesh52, MeshGeometry3D mesh53, MeshGeometry3D mesh54, MeshGeometry3D mesh55, MeshGeometry3D mesh56,
            MeshGeometry3D mesh57, MeshGeometry3D mesh58, MeshGeometry3D mesh59, MeshGeometry3D mesh60, MeshGeometry3D mesh61, MeshGeometry3D mesh62, MeshGeometry3D mesh63, MeshGeometry3D mesh64,
            MeshGeometry3D mesh65, MeshGeometry3D mesh66, MeshGeometry3D mesh67, MeshGeometry3D mesh68, MeshGeometry3D mesh69, MeshGeometry3D mesh70, MeshGeometry3D mesh71, MeshGeometry3D mesh72,
            MeshGeometry3D mesh73, MeshGeometry3D mesh74, MeshGeometry3D mesh75, MeshGeometry3D mesh76, MeshGeometry3D mesh77, MeshGeometry3D mesh78, MeshGeometry3D mesh79, MeshGeometry3D mesh80,
            MeshGeometry3D mesh81, MeshGeometry3D mesh82, MeshGeometry3D mesh83, MeshGeometry3D mesh84, MeshGeometry3D mesh85)
        {
            //Севастополь
            DDTri(mesh1, 0, 3, 1, 4);
            DDTri(mesh1, 1, 3, 2, 4);
            sides(mesh1, 4);
            //Крым
            DDTri(mesh2, 0, 1, 7, 8);
            DDTri(mesh2, 1, 7, 2, 8);
            DDTri(mesh2, 2, 6, 7, 8);
            DDTri(mesh2, 2, 5, 6, 8);
            DDTri(mesh2, 2, 5, 4, 8);
            DDTri(mesh2, 3, 5, 4, 8);
            sides(mesh2, 8);
            //Краснодарский край
            DDTri(mesh3, 0, 1, 6, 7);
            DDTri(mesh3, 1, 6, 2, 7);
            DDTri(mesh3, 6, 2, 3, 7);
            DDTri(mesh3, 6, 4, 3, 7);
            DDTri(mesh3, 4, 5, 6, 7);
            sides(mesh3,7);
            //Адыгея
            DDTri(mesh4, 0, 1, 5, 6);
            DDTri(mesh4, 1, 5, 4, 6);
            DDTri(mesh4, 2, 1, 4, 6);
            DDTri(mesh4, 2, 3, 4, 6);
            sides(mesh4, 6);
            //Карачаево-Черкесская
            DDTri(mesh5, 0, 1, 2, 4);
            DDTri(mesh5, 2, 3, 0, 4);
            sides(mesh5, 4);
            //Кабардино-Балкарская
            DDTri(mesh6, 0, 1, 4, 5);
            DDTri(mesh6, 1, 4, 3, 5);
            DDTri(mesh6, 1, 2, 3, 5);
            sides(mesh6,5);
            //Северная Осетия
            DDTri(mesh7, 0, 1, 2, 4);
            DDTri(mesh7, 2, 3, 0, 4);
            sides(mesh7, 4);
            //Ингушетия
            DDTri(mesh8, 0, 1, 2, 4);
            DDTri(mesh8, 2, 3, 0, 4);
            sides(mesh8, 4);
            //Чеченская
            DDTri(mesh9, 0, 1, 6, 7);
            DDTri(mesh9, 1, 5, 6, 7);
            DDTri(mesh9, 1, 4, 5, 7);
            DDTri(mesh9, 1, 3, 4, 7);
            DDTri(mesh9, 1, 2, 3, 7);
            sides(mesh9, 7);
            //Дагестан
            DDTri(mesh10, 0, 1, 7, 8);
            DDTri(mesh10, 1, 6, 7, 8);
            DDTri(mesh10, 1, 2, 6, 8);
            DDTri(mesh10, 2, 5, 6, 8);
            DDTri(mesh10, 2, 5, 4, 8);
            DDTri(mesh10, 2, 3, 4, 8);
            sides(mesh10, 8);
            //Якутия
            DDTri(mesh11, 0, 1, 11, 12);
            DDTri(mesh11, 1, 2, 11, 12);
            DDTri(mesh11, 2, 10, 11, 12);
            DDTri(mesh11, 2, 9, 10, 12);
            DDTri(mesh11, 2, 8, 9, 12);
            DDTri(mesh11, 2, 7, 8, 12);
            DDTri(mesh11, 2, 8, 9, 12);
            DDTri(mesh11, 2, 6, 7, 12);
            DDTri(mesh11, 2, 5, 6, 12);
            DDTri(mesh11, 2, 4, 5, 12);
            DDTri(mesh11, 2, 3, 4, 12);
            sides(mesh11,12);
            //Чукотская автономная область
            DDTri(mesh12, 0, 1, 9, 10);
            DDTri(mesh12, 1, 8, 9, 10);
            DDTri(mesh12, 1, 7, 8, 10);
            DDTri(mesh12, 5, 6, 7, 10);
            DDTri(mesh12, 1, 5, 7, 10);
            DDTri(mesh12, 1, 4, 5, 10);
            DDTri(mesh12, 1, 3, 4, 10);
            DDTri(mesh12, 1, 2, 3, 10);
            sides(mesh12, 10);
            //Камчатская область
            DDTri(mesh13, 0, 8, 9, 10);
            DDTri(mesh13, 0, 7, 8, 10);
            DDTri(mesh13, 0, 1, 7, 10);
            DDTri(mesh13, 1, 6, 7, 10);
            DDTri(mesh13, 1, 2, 6, 10);
            DDTri(mesh13, 2, 5, 6, 10);
            //DDTri(mesh13, 2, 5, 6, 10);
            DDTri(mesh13, 2, 3, 5, 10);
            DDTri(mesh13, 3, 4, 5, 10);
            sides(mesh13, 10);
            //Магаданская область
            /*DDTri(mesh14, 0, 1, 2, 6);
            DDTri(mesh14, 0, 2, 3, 6);
            DDTri(mesh14, 0, 3, 4, 6);
            DDTri(mesh14, 0, 4, 5, 6);*/
            surf(mesh14, 6);
            sides(mesh14, 6);
            //Хабаровский край
            DDTri(mesh15, 0, 1, 2, 10);
            DDTri(mesh15, 0, 2, 9, 10);
            DDTri(mesh15, 2, 8, 9, 10);
            DDTri(mesh15, 2, 3, 8, 10);
            DDTri(mesh15, 3, 7, 8, 10);
            DDTri(mesh15, 3, 6, 7, 10);
            DDTri(mesh15, 3, 5, 6, 10);
            DDTri(mesh15, 3, 4, 5, 10);
            sides(mesh15, 10);
            //Сахалинская область
            DDTri(mesh16, 0, 1, 2, 6);
            DDTri(mesh16, 0, 2, 5, 6);
            DDTri(mesh16, 2, 5, 4, 6);
            DDTri(mesh16, 2, 3, 4, 6);
            sides(mesh16, 6);
            //Приморский край
            surf(mesh17, 5);
            sides(mesh17, 5);
            //Амурская область
            surf(mesh18, 8);
            sides(mesh18, 8);
            //Еврейская автономная область
            surf(mesh19, 3);
            sides(mesh19, 3);
            //Читинская область
            DDTri(mesh20, 0, 1, 6, 7);
            DDTri(mesh20, 1, 2, 6, 7);
            DDTri(mesh20, 5, 6, 2, 7);
            DDTri(mesh20, 2, 3, 5, 7);
            DDTri(mesh20, 3, 4, 5, 7);
            sides(mesh20, 7);
            //Республика Бурятия
            DDTri(mesh21, 0, 1, 7, 8);
            DDTri(mesh21, 1, 2, 7, 8);
            DDTri(mesh21, 6, 7, 2, 8);
            DDTri(mesh21, 2, 3, 6, 8);
            DDTri(mesh21, 3, 4, 6, 8);
            DDTri(mesh21, 4, 5, 6, 8);
            sides(mesh21, 8);
            //Иркутская область
            surf(mesh22, 11);
            sides(mesh22, 11);
            //Красноярский край
            surf(mesh23, 13);
            sides(mesh23, 13);
            //Республика Тыва
            surf(mesh24, 6);
            sides(mesh24, 6);
            //Республика Алтай
            surf(mesh25, 5);
            sides(mesh25, 5);
            //Алтайский край
            surf(mesh26, 5);
            sides(mesh26, 5);
            //Республика Хакасия
            surf(mesh27, 3);
            sides(mesh27, 3);
            //Кемеровская область
            surf(mesh28, 6);
            sides(mesh28, 6);
            //Новосибирская область
            surf(mesh29, 5);
            sides(mesh29, 5);
            //Омская область
            DDTri(mesh30, 0, 1, 6, 7);
            DDTri(mesh30, 1, 5, 6, 7);
            DDTri(mesh30, 1, 2, 3, 7);
            DDTri(mesh30, 1, 3, 4, 7);
            DDTri(mesh30, 1, 4, 5, 7);
            sides(mesh30, 7);
            //Тюменская область
            DDTri(mesh31, 0, 1, 8, 9);
            DDTri(mesh31, 1, 7, 8, 9);
            DDTri(mesh31, 1, 2, 7, 9);
            DDTri(mesh31, 2, 6, 7, 9);
            DDTri(mesh31, 2, 3, 6, 9);
            DDTri(mesh31, 3, 5, 6, 9);
            DDTri(mesh31, 3, 4, 5, 9);
            sides(mesh31, 9);
            //Курганская область
            surf(mesh32, 4);
            sides(mesh32, 4);
            //Челябинская область
            DDTri(mesh33, 0, 1, 2, 9);
            DDTri(mesh33, 2, 8, 0, 9);
            DDTri(mesh33, 2, 5, 8, 9);
            DDTri(mesh33, 2, 3, 4, 9);
            DDTri(mesh33, 2, 4, 5, 9);
            DDTri(mesh33, 5, 6, 7, 9);
            DDTri(mesh33, 5, 7, 8, 9);
            sides(mesh33, 9);
            //Оренбургская область
            surf(mesh34, 8);
            sides(mesh34, 8);
            //Томская область
            surf(mesh35, 6);
            sides(mesh35, 6);
            //Ханты-Манскийский авт.округ-ЮГРА
            surf(mesh36, 8);
            sides(mesh36, 8);
            //Ямало-ненецкий авт.округ
            surf(mesh37, 6);
            sides(mesh37, 6);
            //Ненецкий авт. округ
            surf(mesh38, 5);
            sides(mesh38, 5);
            //Республика Коми
            surf(mesh39, 8);
            sides(mesh39, 8);
            //Свердловская область
            surf(mesh40, 6);
            sides(mesh40, 6);
            //Республика Башкортостан
            DDTri(mesh41, 0, 1, 2, 10);
            DDTri(mesh41, 0, 5, 6, 10);
            DDTri(mesh41, 0, 2, 5, 10);
            DDTri(mesh41, 2, 3, 4, 10);
            DDTri(mesh41, 2, 4, 5, 10);
            DDTri(mesh41, 0, 6, 7, 10);
            DDTri(mesh41, 0, 7, 8, 10);
            DDTri(mesh41, 0, 8, 9, 10);
            sides(mesh41, 10);
            //Пермский край
            surf(mesh42, 5);
            sides(mesh42, 5);
            //Удмурская республика
            surf(mesh43, 3);
            sides(mesh43, 3);
            //Республика Татарстан(Татарстан)
            surf(mesh44, 7);
            sides(mesh44, 7);
            //Кировская область
            DDTri(mesh45, 0, 1, 9, 10);
            DDTri(mesh45, 1, 2, 9, 10);
            DDTri(mesh45, 2, 3, 9, 10);
            DDTri(mesh45, 3, 7, 9, 10);
            DDTri(mesh45, 7, 8, 9, 10);
            DDTri(mesh45, 3, 4, 7, 10);
            DDTri(mesh45, 4, 5, 6, 10);
            DDTri(mesh45, 4, 6, 7, 10);
            sides(mesh45, 10);
            //Архангельск
            surf(mesh46, 6);
            sides(mesh46, 6);
            //Вологодская область
            surf(mesh47, 8);
            sides(mesh47, 8);
            //Мурманская область
            surf(mesh48, 7);
            sides(mesh48, 7);
            //Реуспублика Карелия
            DDTri(mesh49, 0, 1, 7, 8);
            DDTri(mesh49, 1, 2, 7, 8);
            DDTri(mesh49, 2, 3, 7, 8);
            DDTri(mesh49, 3, 4, 7, 8);
            DDTri(mesh49, 4, 5, 7, 8);
            DDTri(mesh49, 5, 6, 7, 8);
            sides(mesh49, 8);
            //Ленинградская область
            DDTri(mesh50, 0, 1, 7, 8);
            DDTri(mesh50, 1, 2, 3, 8);
            DDTri(mesh50, 1, 3, 4, 8);
            DDTri(mesh50, 1, 4, 5, 8);
            DDTri(mesh50, 1, 5, 6, 8);
            DDTri(mesh50, 1, 6, 7, 8);
            sides(mesh50, 8);
            //Калининградская область
            surf(mesh51, 5);
            sides(mesh51, 5);
            //Псковская область
            surf(mesh52, 6);
            sides(mesh52, 6);
            //Новгородская область
            surf(mesh53, 4);
            sides(mesh53, 4);
            //Тверская область
            surf(mesh54, 6);
            sides(mesh54, 6);
            //Ярославльская область
            surf(mesh55, 5);
            sides(mesh55, 5);
            //Костромская область
            surf(mesh56, 5);
            sides(mesh56, 5);
            //Ивановская область
            surf(mesh57, 4);
            sides(mesh57, 4);
            //Владимирская область
            surf(mesh58, 5);
            sides(mesh58, 5);
            //Нижегородская область
            surf(mesh59, 8);
            sides(mesh59, 8);
            //Республика Марий Эл
            surf(mesh60, 4);
            sides(mesh60, 4);
            //Чувашия
            surf(mesh61, 5);
            sides(mesh61, 5);
            //Самарская область
            surf(mesh62, 4);
            sides(mesh62, 4);
            //Саратовская область
            surf(mesh63, 8);
            sides(mesh63, 8);
            //Ульяновская область
            surf(mesh64, 6);
            sides(mesh64, 6);
            //Пензенская область
            surf(mesh65, 4);
            sides(mesh65, 4);
            //Саранская область
            surf(mesh66, 5);
            sides(mesh66, 5);
            //Рязанская область
            surf(mesh67, 8);
            sides(mesh67, 8);
            //Смоленская область
            surf(mesh68, 6);
            sides(mesh68, 6);
            //Калужская область
            surf(mesh69, 5);
            sides(mesh69, 5);
            //Брянская область
            surf(mesh70, 7);
            sides(mesh70, 7);
            //Тульская область
            surf(mesh71, 5);
            sides(mesh71, 5);
            //Московская область
            surf(mesh72, 6);
            sides(mesh72, 6);
            //Курская область
            surf(mesh73, 6);
            sides(mesh73, 6);
            //Орловская область
            surf(mesh74, 5);
            sides(mesh74, 5);
            //Липецкая область
            surf(mesh75, 6);
            sides(mesh75, 6);
            //Тамбовская область
            surf(mesh76, 5);
            sides(mesh76, 5);
            //Белгородская область
            surf(mesh77, 3);
            sides(mesh77, 3);
            //Воронежская область
            surf(mesh78, 8);
            sides(mesh78, 8);
            //Волгоградская область
            surf(mesh79, 7);
            sides(mesh79, 7);
            //Астраханская область
            surf(mesh80, 6);
            sides(mesh80, 6);
            //Ростовская область
            DDTri(mesh81, 0, 1, 8, 9);
            DDTri(mesh81, 1, 7, 8, 9);
            DDTri(mesh81, 1, 6, 7, 9);
            DDTri(mesh81, 1, 4, 6, 9);
            DDTri(mesh81, 4, 5, 6, 9);
            DDTri(mesh81, 1, 2, 3, 9);
            DDTri(mesh81, 1, 3, 4, 9);
            sides(mesh81, 9);
            //Республика Калмыкия
            surf(mesh82, 9);
            sides(mesh82, 9);
            //Ставропольский край
            surf(mesh83, 6);
            sides(mesh83, 6);
            //Москва
            surf(mesh84, 4);
            sides(mesh84, 4);
            //СПБ
            surf(mesh85, 4);
            sides(mesh85, 4);
        }
        public void BuildSolid(int[] r, int[] g, int[] b,double[] up)
        {
            // MeshGeometry3D[] mesh = new MeshGeometry3D[85];
            
                MeshGeometry3D mesh1 = new MeshGeometry3D();
                MeshGeometry3D mesh2 = new MeshGeometry3D();
                MeshGeometry3D mesh3 = new MeshGeometry3D();
                MeshGeometry3D mesh4 = new MeshGeometry3D();
                MeshGeometry3D mesh5 = new MeshGeometry3D();
                MeshGeometry3D mesh6 = new MeshGeometry3D();
                MeshGeometry3D mesh7 = new MeshGeometry3D();
                MeshGeometry3D mesh8 = new MeshGeometry3D();
                MeshGeometry3D mesh9 = new MeshGeometry3D();
                MeshGeometry3D mesh10 = new MeshGeometry3D();
                MeshGeometry3D mesh11 = new MeshGeometry3D();
                MeshGeometry3D mesh12 = new MeshGeometry3D();
                MeshGeometry3D mesh13 = new MeshGeometry3D();
                MeshGeometry3D mesh14 = new MeshGeometry3D();
                MeshGeometry3D mesh15 = new MeshGeometry3D();
                MeshGeometry3D mesh16 = new MeshGeometry3D();
                MeshGeometry3D mesh17 = new MeshGeometry3D();
                MeshGeometry3D mesh18 = new MeshGeometry3D();
                MeshGeometry3D mesh19 = new MeshGeometry3D();
                MeshGeometry3D mesh20 = new MeshGeometry3D();
                MeshGeometry3D mesh21 = new MeshGeometry3D();
                MeshGeometry3D mesh22 = new MeshGeometry3D();
                MeshGeometry3D mesh23 = new MeshGeometry3D();
                MeshGeometry3D mesh24 = new MeshGeometry3D();
                MeshGeometry3D mesh25 = new MeshGeometry3D();
                MeshGeometry3D mesh26 = new MeshGeometry3D();
                MeshGeometry3D mesh27 = new MeshGeometry3D();
                MeshGeometry3D mesh28 = new MeshGeometry3D();
                MeshGeometry3D mesh29 = new MeshGeometry3D();
                MeshGeometry3D mesh30 = new MeshGeometry3D();
                MeshGeometry3D mesh31 = new MeshGeometry3D();
                MeshGeometry3D mesh32 = new MeshGeometry3D();
                MeshGeometry3D mesh33 = new MeshGeometry3D();
                MeshGeometry3D mesh34 = new MeshGeometry3D();
                MeshGeometry3D mesh35 = new MeshGeometry3D();
                MeshGeometry3D mesh36 = new MeshGeometry3D();
                MeshGeometry3D mesh37 = new MeshGeometry3D();
                MeshGeometry3D mesh38 = new MeshGeometry3D();
                MeshGeometry3D mesh39 = new MeshGeometry3D();
                MeshGeometry3D mesh40 = new MeshGeometry3D();
                MeshGeometry3D mesh41 = new MeshGeometry3D();
                MeshGeometry3D mesh42 = new MeshGeometry3D();
                MeshGeometry3D mesh43 = new MeshGeometry3D();
                MeshGeometry3D mesh44 = new MeshGeometry3D();
                MeshGeometry3D mesh45 = new MeshGeometry3D();
                MeshGeometry3D mesh46 = new MeshGeometry3D();
                MeshGeometry3D mesh47 = new MeshGeometry3D();
                MeshGeometry3D mesh48 = new MeshGeometry3D();
                MeshGeometry3D mesh49 = new MeshGeometry3D();
                MeshGeometry3D mesh50 = new MeshGeometry3D();
                MeshGeometry3D mesh51 = new MeshGeometry3D();
                MeshGeometry3D mesh52 = new MeshGeometry3D();
                MeshGeometry3D mesh53 = new MeshGeometry3D();
                MeshGeometry3D mesh54 = new MeshGeometry3D();
                MeshGeometry3D mesh55 = new MeshGeometry3D();
                MeshGeometry3D mesh56 = new MeshGeometry3D();
                MeshGeometry3D mesh57 = new MeshGeometry3D();
                MeshGeometry3D mesh58 = new MeshGeometry3D();
                MeshGeometry3D mesh59 = new MeshGeometry3D();
                MeshGeometry3D mesh60 = new MeshGeometry3D();
                MeshGeometry3D mesh61 = new MeshGeometry3D();
                MeshGeometry3D mesh62 = new MeshGeometry3D();
                MeshGeometry3D mesh63 = new MeshGeometry3D();
                MeshGeometry3D mesh64 = new MeshGeometry3D();
                MeshGeometry3D mesh65 = new MeshGeometry3D();
                MeshGeometry3D mesh66 = new MeshGeometry3D();
                MeshGeometry3D mesh67 = new MeshGeometry3D();
                MeshGeometry3D mesh68 = new MeshGeometry3D();
                MeshGeometry3D mesh69 = new MeshGeometry3D();
                MeshGeometry3D mesh70 = new MeshGeometry3D();
                MeshGeometry3D mesh71 = new MeshGeometry3D();
                MeshGeometry3D mesh72 = new MeshGeometry3D();
                MeshGeometry3D mesh73 = new MeshGeometry3D();
                MeshGeometry3D mesh74 = new MeshGeometry3D();
                MeshGeometry3D mesh75 = new MeshGeometry3D();
                MeshGeometry3D mesh76 = new MeshGeometry3D();
                MeshGeometry3D mesh77 = new MeshGeometry3D();
                MeshGeometry3D mesh78 = new MeshGeometry3D();
                MeshGeometry3D mesh79 = new MeshGeometry3D();
                MeshGeometry3D mesh80 = new MeshGeometry3D();
                MeshGeometry3D mesh81 = new MeshGeometry3D();
                MeshGeometry3D mesh82 = new MeshGeometry3D();
                MeshGeometry3D mesh83 = new MeshGeometry3D();
                MeshGeometry3D mesh84 = new MeshGeometry3D();
                MeshGeometry3D mesh85 = new MeshGeometry3D();
            

            Make_Regions(mesh1,  mesh2, mesh3,  mesh4,  mesh5,  mesh6,  mesh7,  mesh8,
             mesh9,  mesh10,  mesh11,  mesh12,  mesh13,  mesh14,  mesh15,  mesh16,
             mesh17,  mesh18,  mesh19,  mesh20,  mesh21,  mesh22,  mesh23,  mesh24,
             mesh25,  mesh26,  mesh27,  mesh28,  mesh29,  mesh30,  mesh31,  mesh32,
             mesh33,  mesh34,  mesh35,  mesh36,  mesh37,  mesh38,  mesh39,  mesh40,
             mesh41,  mesh42,  mesh43,  mesh44,  mesh45,  mesh46,  mesh47,  mesh48,
             mesh49,  mesh50,  mesh51,  mesh52,  mesh53,  mesh54,  mesh55,  mesh56,
             mesh57,  mesh58,  mesh59,  mesh60,  mesh61,  mesh62,  mesh63,  mesh64,
             mesh65,  mesh66,  mesh67,  mesh68,  mesh69,  mesh70,  mesh71,  mesh72,
             mesh73,  mesh74,  mesh75,  mesh76,  mesh77,  mesh78,  mesh79,  mesh80,
             mesh81,  mesh82,  mesh83,  mesh84,  mesh85, up);

            Triangles(mesh1, mesh2, mesh3, mesh4, mesh5, mesh6, mesh7, mesh8,
             mesh9, mesh10, mesh11, mesh12, mesh13, mesh14, mesh15, mesh16,
             mesh17, mesh18, mesh19, mesh20, mesh21, mesh22, mesh23, mesh24,
             mesh25, mesh26, mesh27, mesh28, mesh29, mesh30, mesh31, mesh32,
             mesh33, mesh34, mesh35, mesh36, mesh37, mesh38, mesh39, mesh40,
             mesh41, mesh42, mesh43, mesh44, mesh45, mesh46, mesh47, mesh48,
             mesh49, mesh50, mesh51, mesh52, mesh53, mesh54, mesh55, mesh56,
             mesh57, mesh58, mesh59, mesh60, mesh61, mesh62, mesh63, mesh64,
             mesh65, mesh66, mesh67, mesh68, mesh69, mesh70, mesh71, mesh72,
             mesh73, mesh74, mesh75, mesh76, mesh77, mesh78, mesh79, mesh80,
             mesh81, mesh82, mesh83, mesh84, mesh85);

            int i = 0;
            //foreach (var x in mesh)
            //{
            
                System.Windows.Media.SolidColorBrush br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
                mGeometry[i] = new GeometryModel3D(mesh1, new DiffuseMaterial(br));
                mGeometry[i].Transform = new Transform3DGroup();
                group.Children.Add(mGeometry[i]);
                i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh2, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh3, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh4, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh5, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh6, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh7, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh8, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh9, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh10, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh11, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh12, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh13, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh14, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh15, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh16, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh17, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh18, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh19, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh20, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh21, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh22, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh23, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh24, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh25, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh26, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh27, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh28, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh29, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh30, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh31, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh32, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh33, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh34, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh35, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh36, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh37, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh38, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh39, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh40, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh41, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh42, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh43, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh44, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh45, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh46, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh47, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh48, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh49, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh50, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh51, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh52, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh53, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh54, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh55, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh56, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh57, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh58, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh59, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh60, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh61, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh62, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh63, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh64, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh65, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh66, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh67, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh68, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh69, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh70, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh71, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh72, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh73, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh74, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh75, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh76, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh77, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh78, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh79, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh80, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh81, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh82, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh83, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh84, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r[i], (byte)g[i], (byte)b[i]));
            mGeometry[i] = new GeometryModel3D(mesh85, new DiffuseMaterial(br));
            mGeometry[i].Transform = new Transform3DGroup();
            group.Children.Add(mGeometry[i]);
            i++;
            //}
        }

		private void Grid_MouseWheel(object sender, MouseWheelEventArgs e) {
			camera.Position = new Point3D(camera.Position.X, camera.Position.Y, camera.Position.Z - e.Delta / 250D);
            //System.Windows.Media.Media3D.PointLight
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			camera.Position = new Point3D(camera.Position.X, camera.Position.Y, -10);
            foreach (var x in mGeometry)
            {
                x.Transform = new Transform3DGroup();
            }
        }

		private void Grid_MouseMove(object sender, MouseEventArgs e) {
			if(mDown) {
                System.Windows.Point pos = Mouse.GetPosition(viewport);
				System.Windows.Point actualPos = new System.Windows.Point(pos.X - viewport.ActualWidth / 2, viewport.ActualHeight / 2 - pos.Y);
				double dx = actualPos.X - mLastPos.X, dy = actualPos.Y - mLastPos.Y;

				double mouseAngle = 0;
				if(dx != 0 && dy != 0) {
					mouseAngle = Math.Asin(Math.Abs(dy) / Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
					if(dx < 0 && dy > 0) mouseAngle += Math.PI / 2;
					else if(dx < 0 && dy < 0) mouseAngle += Math.PI;
					else if(dx > 0 && dy < 0) mouseAngle += Math.PI * 1.5;
				}
				else if(dx == 0 && dy != 0) mouseAngle = Math.Sign(dy) > 0 ? Math.PI / 2 : Math.PI * 1.5;
				else if(dx != 0 && dy == 0) mouseAngle = Math.Sign(dx) > 0 ? 0 : Math.PI;

				double axisAngle = mouseAngle + Math.PI / 2;

				Vector3D axis = new Vector3D(Math.Cos(axisAngle) * 4, Math.Sin(axisAngle) * 4, 0);

				double rotation = 0.01 * Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

                QuaternionRotation3D r = new QuaternionRotation3D(new Quaternion(axis, rotation * 180 / Math.PI));
                foreach (var x in mGeometry)
                {
                    Transform3DGroup group = x.Transform as Transform3DGroup;
                    group.Children.Add(new RotateTransform3D(r));

                }
                mLastPos = actualPos;
			}
		}

		private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
			if(e.LeftButton != MouseButtonState.Pressed) return;
			mDown = true;
			System.Windows.Point pos = Mouse.GetPosition(viewport);
			mLastPos = new System.Windows.Point(pos.X - viewport.ActualWidth / 2, viewport.ActualHeight / 2 - pos.Y);
		}

		private void Grid_MouseUp(object sender, MouseButtonEventArgs e) {
			mDown = false;
		}

        public static void CreateBitmapFromVisual(Visual target, string fileName)
        {
            if (target == null || string.IsNullOrEmpty(fileName))
            {
                return;
            }

            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((Int32)bounds.Width, (Int32)bounds.Height, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext context = visual.RenderOpen())
            {
                VisualBrush visualBrush = new VisualBrush(target);
                context.DrawRectangle(visualBrush, null, new Rect(new System.Windows.Point(), bounds.Size));
            }

            renderTarget.Render(visual);
            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
            using (Stream stm = File.Create(fileName))
            {
                bitmapEncoder.Save(stm);
            }
        }
        public void turn(GeometryModel3D[] mGeometry)
        {
            RotateTransform3D myRotateTransform3D = new RotateTransform3D();
            AxisAngleRotation3D myAxisAngleRotation3d = new AxisAngleRotation3D();
            myAxisAngleRotation3d.Axis = new Vector3D(0, 0, -1);
            myAxisAngleRotation3d.Angle = 90;
            myRotateTransform3D.Rotation = myAxisAngleRotation3d;

            // Add the rotation transform to a Transform3DGroup
            Transform3DGroup myTransform3DGroup = new Transform3DGroup();
            myTransform3DGroup.Children.Add(myRotateTransform3D);

            RotateTransform3D myRotateTransform3D2 = new RotateTransform3D();
            AxisAngleRotation3D myAxisAngleRotation3d2 = new AxisAngleRotation3D();
            myAxisAngleRotation3d2.Axis = new Vector3D(0, 1, 0);
            myAxisAngleRotation3d2.Angle = 45;
            myRotateTransform3D2.Rotation = myAxisAngleRotation3d2;

            // Add the rotation transform to a Transform3DGroup
            myTransform3DGroup.Children.Add(myRotateTransform3D2);
            // Create and apply a scale transformation that stretches the object along the local x-axis  
            // by 200 percent and shrinks it along the local y-axis by 50 percent.
            //ScaleTransform3D myScaleTransform3D = new ScaleTransform3D();
            //myScaleTransform3D.ScaleX = 1;
            //myScaleTransform3D.ScaleY = 1;
            //myScaleTransform3D.ScaleZ = 1;

            // Add the scale transform to the Transform3DGroup.
            //myTransform3DGroup.Children.Add(myScaleTransform3D);

            // Set the Transform property of the GeometryModel to the Transform3DGroup which includes 
            // both transformations. The 3D object now has two Transformations applied to it.
            foreach (var x in mGeometry)
            {
                x.Transform = myTransform3DGroup;
                //x.Transform = new Transform3DGroup();
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CreateBitmapFromVisual(viewport, "Screen.png");            
        }
    }

}
