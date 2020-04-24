using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveHue
{
    class ILoveHue
    {
        private Polje[,] matPolje;

        int n = 0;

        public void Pin()
        {
            matPolje[0, 0].Pin = true;

            matPolje[matPolje.GetLength(0) - 1, 0].Pin = true;

            matPolje[0, matPolje.GetLength(0) - 1].Pin = true;

            matPolje[matPolje.GetLength(0) - 1, matPolje.GetLength(0) - 1].Pin = true;

        }





    }
}
