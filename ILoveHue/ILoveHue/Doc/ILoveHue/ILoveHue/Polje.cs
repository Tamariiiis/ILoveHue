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

		public Color Boja
		{
			get { return boja; }
			set { boja = value; }
		}






	}
}
