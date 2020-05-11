using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


		public Kvadratic(byte r, byte g, byte b)
		{
			pin = false;
			size = 10;
			rect = new Rectangle();
			rect.Width = size;
			rect.Height = size;
			Color c = Color.FromRgb(r, g, b);
			SolidColorBrush bb = new SolidColorBrush(c);
			Brush boja = bb;
			rect.Fill = boja;
		}

	}
}
