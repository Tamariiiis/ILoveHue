using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace projekatOOP.Model
{
    class Kvadratic
    {
		private Rectangle rect;

		public Rectangle Rect
		{
			get { return rect; }
			set { rect = value; }
		}

		private double size;

		public double Size
		{
			get { return size; }
			set { size = value; }
		}

		private bool pin;

		public bool Pin
		{
			get { return pin; }
			set { pin = value; }
		}

        private byte r;

        public byte R
        {
            get { return r; }
            set { r = value; }
        }

        private byte g;

        public byte G
        {
            get { return g; }
            set { g = value; }
        }

        private byte b;

        public byte B
        {
            get { return b; }
            set { b = value; }
        }

		private Color c;

		public Color C
		{
			get { return c; }
			set { c = value; }
		}



		public Kvadratic(byte r, byte g, byte b,double size)
		{
            R = r;
            G = g;
            B = b;
			pin = false;
			rect = new Rectangle();
			rect.Width = size;
			rect.Height = size;
			c = Color.FromRgb(r, g, b);
			SolidColorBrush bb = new SolidColorBrush(c);
			Brush boja = bb;
			rect.Fill = boja;
		}


		public override string ToString()
		{
			return r.ToString();
		}
	}
}
