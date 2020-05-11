using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		private void Pin()
		{
			matrica[0, 0].Pin = true;

			matrica[matrica.GetLength(0) - 1, 0].Pin = true;

			matrica[0, matrica.GetLength(0) - 1].Pin = true;

			matrica[matrica.GetLength(0) - 1, matrica.GetLength(0) - 1].Pin = true;
		}

		public Tabela(int m, int n)
		{
			matrica = new Kvadratic[m, n];
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					matrica[i, j] = new Kvadratic();
				}

			}
		}
	}
}
