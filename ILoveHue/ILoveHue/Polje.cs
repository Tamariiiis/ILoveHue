using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ILoveHue
{
    class Polje
    {
		public Polje(int i, Color b)
		{
			i = 5;
			b = Colors.Red;
		}

		public Polje(int i, int j)
		{
			this.i = i;
			this.j = j;
		}

		private bool pin;

		public bool Pin
		{
			get { return pin; }
			set { pin = value; }
		}

		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private Color boja;
		private int i;
		private int j;

		public Color Boja
		{
			get { return boja; }
			set { boja = value; }
		}

		public override string ToString()
		{
			return boja.ToString();	
		}




	}
}
