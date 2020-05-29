using projekatOOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace projekatOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public static class FrameworkElementExt
    {

        public static void BringToFront(this FrameworkElement element)
        {
            if (element == null) return;
            Canvas parent = element.Parent as Canvas;
            if (parent == null) return;
            var maxZ = parent.Children.OfType<UIElement>().Where(x => x != element).Select(x => Canvas.GetZIndex(x)).Max();
            Canvas.SetZIndex(element, maxZ + 1);
        }
    }
    public partial class MainWindow : Window
    {
        Tabela t;
        Tabela nova;
        DispatcherTimer timer;

        Point firstClick;
        Point secondClick;

        int brKlik = 0;
        public MainWindow()
        {
            InitializeComponent();

            t = new Tabela(9, 9, cnvIgra);
            //nova = RandTabelu(t);
            //t = nova;
            lblBroj.BringToFront();
            //lblBroj.HorizontalAlignment = HorizontalAlignment.Center;
            lblBroj.VerticalAlignment = VerticalAlignment.Center;

            timer = new DispatcherTimer();
            //EventHandler DispatcherTimer_Tick = null;
            timer.Tick += new EventHandler(DispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        int br = 4;
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            br--;
            if (br == 0)
            {
                lblBroj.Visibility = Visibility.Hidden;
                nova = RandTabelu(t);
                timer.Stop();
            }
            else
            {
                lblBroj.Content = "     " + br;
            }
        }


        private static Tabela RandTabelu(Tabela t)
        {
            //t.Otkaci();
            Tabela nova = t;
            Random r = new Random();
            int max = t.Matrica.GetLength(0);

            
            for(int i = 0; i < t.Matrica.GetLength(0); i++)
            {
                for(int j = 0; j < t.Matrica.GetLength(1); j++)
                {
                    t.TacnaMatrica[i, j] = t.Matrica[i, j];
                }
            }

            for (int i = 0; i < t.Matrica.GetLength(0); i++)
            {
                for (int j = 0; j < t.Matrica.GetLength(1); j++)
                {
                    int p = r.Next(0, max);
                    int q = r.Next(0, max);
                    Kvadratic k = t.Matrica[i, j];
                    Kvadratic k2 = t.Matrica[p, q];
                    t.Pin();
                    if (k.Pin || k2.Pin)
                    {
                        continue;
                    }
                    else
                    {
                        //MessageBox.Show(Convert.ToString(t.Matrica[0, 0].Pin));
                        Kvadratic tmp = t.Matrica[i, j];
                        t.Matrica[i, j] = t.Matrica[p, q];
                        t.Matrica[p, q] = tmp;
                        Canvas.SetLeft(t.Matrica[i, j].Rect, (t.Matrica[i, j].Rect.Width + 1) * i);
                        Canvas.SetTop(t.Matrica[i, j].Rect, (t.Matrica[i, j].Rect.Height + 1) * j);

                        Canvas.SetLeft(t.Matrica[p, q].Rect, (t.Matrica[p, q].Rect.Width + 1) * p);
                        Canvas.SetTop(t.Matrica[p, q].Rect, (t.Matrica[p, q].Rect.Height + 1) * q);
                    }
                }
            }
            return nova;
        }

        private bool Proveri()
        {
            for (int i = 0; i < t.Matrica.GetLength(0); i++)
            {
                for (int j = 0; j < t.Matrica.GetLength(1); j++)
                {
                    if (t.Matrica[i, j].R != t.TacnaMatrica[i, j].R && t.Matrica[i, j].G != t.TacnaMatrica[i, j].G && t.Matrica[i, j].B != t.TacnaMatrica[i, j].B)
                        return false;
                }
            }
            return true;
        }

        private void Zameni(Point a, Point b)
        {
            
            int prviX = (int)(a.X / (t.Size + 1));
            int prviY = (int)(a.Y / (t.Size + 1));
            int drugiX = (int)(b.X / (t.Size + 1));
            int drugiY = (int)(b.Y / (t.Size + 1));
            //MessageBox.Show(prviX.ToString());
            if (t.Matrica[prviX, prviY].Pin || t.Matrica[drugiX, drugiY].Pin)
                return;
            //MessageBox.Show(t.Matrica[prviX, prviY].ToString());


            Kvadratic temp = t.Matrica[prviX, prviY];
            t.Matrica[prviX, prviY] = t.Matrica[drugiX, drugiY];
            t.Matrica[drugiX, drugiY] = temp;
            //MessageBox.Show(t.Matrica[prviX, prviY].ToString());
            //MessageBox.Show("zamena");
            //MessageBox.Show("zamena");

            
            /*for (int i = 0; i < t.Matrica.GetLength(0); i++)
            {
                for (int j = 0; j < t.Matrica.GetLength(1); j++)
                {
                    t.Matrica[i, j] = t.TacnaMatrica[i, j];
                }
            }*/
            

            cnvIgra.InvalidateVisual();
            cnvIgra.UpdateLayout();
            t.Refresh();

            if (Proveri())
            {
                lblBroj.HorizontalAlignment = HorizontalAlignment.Left;
                lblBroj.VerticalAlignment = VerticalAlignment.Center;
                lblBroj.Content = "BRAVO!!";
                lblBroj.Visibility = Visibility.Visible;
            }
        }
        private void cnvIgra_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (brKlik == 0)
            {
                firstClick = e.GetPosition(cnvIgra);
                brKlik++;
            }
            else
            {
                secondClick = e.GetPosition(cnvIgra);
                brKlik--;
                Zameni(firstClick, secondClick);
            }
        }
    }
}
