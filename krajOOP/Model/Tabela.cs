using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace projekatOOP.Model
{
    class Tabela
    {
		private Kvadratic[,] matrica;

		public Kvadratic[,] Matrica
		{
			get { return matrica; }
			set { matrica = value; }
		}

        private Kvadratic[,] tacnaMatrica;

        public Kvadratic[,] TacnaMatrica
        {
            get { return tacnaMatrica; }
            set { tacnaMatrica = value; }
        }


        private Canvas cnv;

        public Canvas Cnv
        {
            get { return cnv; }
            set { cnv = value; }
        }
        public void Pin()
		{
			matrica[0, 0].Pin = true;

			matrica[matrica.GetLength(0) - 1, 0].Pin = true;

			matrica[0, matrica.GetLength(1) - 1].Pin = true;

			matrica[matrica.GetLength(0) - 1, matrica.GetLength(1) - 1].Pin = true;
		}
        private void makeCorners()
        {
            matrica[0, 0] = new Kvadratic(3, 227, 252,size);
            matrica[matrica.GetLength(0) - 1, 0] = new Kvadratic(123, 209, 145,size);
            matrica[0, matrica.GetLength(1) - 1] = new Kvadratic(252, 3, 227,size);
            matrica[matrica.GetLength(0) - 1, matrica.GetLength(1) - 1]  = new Kvadratic(196, 35, 43,size);

            //cnv.Children.Add(matrica[0, 0].Rect);
            //cnv.Children.Add(matrica[matrica.GetLength(0) - 1, 0].Rect);
            //cnv.Children.Add(matrica[0, matrica.GetLength(1) - 1].Rect);
            //cnv.Children.Add(matrica[matrica.GetLength(0) - 1, matrica.GetLength(1) - 1].Rect);
        }
        private byte Rand()
        {
            Random r = new Random();
            byte b = Convert.ToByte(r.Next(12, 255));
            return b;
        }

        private double size;

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        /*public void Otkaci()
        {
            for (int i = 0; i < matrica.GetLength(0); i++)
            {
                for (int j = 0; j < matrica.GetLength(1); j++)
                {
                    cnv.Children.Remove(matrica[i, j].Rect);
                }
            }
        }*/

        public void Refresh()
        {
            int m = 9;
            int n = 9;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Canvas.SetLeft(matrica[i, j].Rect, (matrica[i, j].Rect.Width + 1) * i);
                    Canvas.SetTop(matrica[i, j].Rect, (matrica[i, j].Rect.Height + 1) * j);
                }
            }
        }
        public Tabela(int m,int n, Canvas cnvs)
		{
            Size = cnvs.Width - m+1;
            size = size / m;
			matrica = new Kvadratic[m, n];
            tacnaMatrica = new Kvadratic[m, n];
            Cnv = cnvs;
            makeCorners();
            Pin();
            for (int i = 0; i < m; i++)
            {
               //MessageBox.Show(Convert.ToString((matrica[0, 0].R - matrica[matrica.GetLength(0) - 1, 0].R) / (m - 1)));
                int rr = Convert.ToInt32(( matrica[0, 0].R - matrica[matrica.GetLength(0) - 1, 0].R)/(m));
                int gg = Convert.ToInt32((matrica[0, 0].G - matrica[matrica.GetLength(0) - 1, 0].G)/(m));
                int bb = Convert.ToInt32((matrica[0, 0].B - matrica[matrica.GetLength(0) - 1, 0].B)/(m));

                //MessageBox.Show(Convert.ToString( matrica[0, 0].R + rr * i + "," + matrica[0,0].R+ ", "+ rr));
                byte r = Convert.ToByte( matrica[0, 0].R - rr * i);
                byte g = Convert.ToByte(matrica[0, 0].G - gg * i);
                byte b = Convert.ToByte(matrica[0, 0].B - bb * i);

                matrica[i, 0] = new Kvadratic(r, g, b,size);
                //cnv.Children.Add(matrica[i, 0].Rect);

                rr = Convert.ToInt32((matrica[0, m - 1].R - matrica[n - 1, m - 1].R)/(m ));
                gg = Convert.ToInt32((matrica[0, m - 1].G - matrica[n - 1, m - 1].G)/(m ));
                bb = Convert.ToInt32((matrica[0, m - 1].B - matrica[n - 1, m - 1].B)/(m ));


                r = Convert.ToByte(matrica[0, m - 1].R - rr * i);
                g = Convert.ToByte(matrica[0, m - 1].G - gg * i);
                b = Convert.ToByte(matrica[0, m - 1].B - bb * i);

                matrica[i, m - 1] = new Kvadratic(r, g, b,size);
                //cnv.Children.Add(matrica[i, m - 1].Rect);
            }

            for (int j = 0; j < n; j++)
            {
                int rr = Convert.ToInt32((matrica[0, 0].R - matrica[0, n - 1].R) / (n ));
                int gg = Convert.ToInt32((matrica[0, 0].G - matrica[0, n - 1].G) / (n ));
                int bb = Convert.ToInt32((matrica[0, 0].B - matrica[0, n - 1].B) / (n ));

                byte r = Convert.ToByte(matrica[0, 0].R - rr * j);
                byte g = Convert.ToByte(matrica[0, 0].G - gg * j);
                byte b = Convert.ToByte(matrica[0, 0].B - bb * j);

                matrica[0, j] = new Kvadratic(r, g, b,size);
                //cnv.Children.Add(matrica[0, j].Rect);

                rr = Convert.ToInt32((matrica[ n - 1, 0].R - matrica[n - 1, m - 1].R) / (n ));
                gg = Convert.ToInt32((matrica[ n - 1, 0].G - matrica[n - 1, m - 1].G) / (n ));
                bb = Convert.ToInt32((matrica[ n - 1, 0].B - matrica[n - 1, m - 1].B) / (n ));


                r = Convert.ToByte(matrica[n - 1, 0].R - rr * j);
                g = Convert.ToByte(matrica[n - 1, 0].G - gg * j);
                b = Convert.ToByte(matrica[n - 1, 0].B - bb * j);

                matrica[n - 1, j] = new Kvadratic(r, g, b,size);
                //cnv.Children.Add(matrica[n - 1, j].Rect);

            }

			for (int i = 1; i < m - 1; i++)
			{
				for (int j = 1; j < n - 1; j++)
				{
                    int rr = Convert.ToInt32((matrica[i, 0].R - matrica[i, n - 1].R) / (n ));
                    int gg = Convert.ToInt32((matrica[i, 0].G - matrica[i, n - 1].G) / (n ));
                    int bb = Convert.ToInt32((matrica[i, 0].B - matrica[i, n - 1].B) / (n ));

                    byte r = Convert.ToByte(matrica[i, 0].R - rr * j);
                    byte g = Convert.ToByte(matrica[i, 0].G - gg * j);
                    byte b = Convert.ToByte(matrica[i, 0].B - bb * j);

                    matrica[i, j] = new Kvadratic(r,g,b,size);
                    //cnv.Children.Add(matrica[i, j].Rect);
				}

			}


            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cnv.Children.Add(matrica[i, j].Rect);
                    Canvas.SetLeft(matrica[i, j].Rect, (matrica[i, j].Rect.Width + 1) * i);
                    Canvas.SetTop(matrica[i, j].Rect, (matrica[i, j].Rect.Height + 1) * j);
                }
            }
		}
	}
}
