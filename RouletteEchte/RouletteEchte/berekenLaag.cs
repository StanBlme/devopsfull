using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteEchte
{
    class berekenLaag
    {
        private int _teller;
        public int Teller
        {
            set { _teller = value; CheckGe(); }
        }
        //return van getal
        private int _getal;
        public int Getal
        {
            get { return _getal; }
        }

        private void CheckGe()
        {
            int[] fotoNr = new int[37] { 0, 26, 3, 35, 12, 28, 7, 29, 18, 22, 9, 31, 14, 20, 1, 33, 16, 24, 5, 10, 23, 8, 30, 11, 36, 13, 27, 6, 34, 17, 25, 2, 21, 4, 19, 15, 32 };
            for (int i = 0; i < 18; i++)
            {
                _getal = fotoNr[_teller];
            }
        }

        //timer2/beweging pijl
        //locatie tussen pijl en linkerkant
        private int _pijlLeft;
        public int PijlLeft
        {
            set { _pijlLeft = value; pijlSnelEnKrachtBew(); }
            get { return _pijlLeft; }
        }
        //snelheidKracht toe/afname op roulette
        private int _balkSnelhd;
        public int BalkSnelhd
        {
            get { return _balkSnelhd; }
        }
        //linkergrens pijl
        private int _teller1 = 200;
        //rechtergrens pijl
        private int _teller2 = 1100;
        //(1) bewerking voor beweging pijl + (2) kracht laten toepassen op roulette
        private void pijlSnelEnKrachtBew()
        {
            //(1)
            if (_pijlLeft == _teller1 && _pijlLeft!= 1100)
            {
                //(30) bepaald snelheid naar rechts
                _teller1 += 30;
                //teller waarde in pijlwaarde zetten
                _pijlLeft = _teller1;
                //reset teller na elke tik om grens te bewaren
                _teller2 = 1100;
            }
            if (_pijlLeft == _teller2 && _pijlLeft != 200)
            {
                //(30) bepaald snelheid naar links
                _teller2 -= 30;
                //teller waarde in pijlwaarde zetten
                _pijlLeft = _teller2;
                //reset teller na elke tik om grens te bewaren
                _teller1 = 200;
            }
            //(2)
            //kracht met balk laten toenemen/afnemen op roulette met de locatie van de pijl
            if (_pijlLeft >= 200 && _pijlLeft <= 650)
            {
                //met locatie bewerking maken voor toepassing kracht
                _balkSnelhd = (_pijlLeft - 200) / 4;

            }
            else
            {
                //met locatie bewerking maken voor toepassing kracht
                _balkSnelhd = (450 - (_pijlLeft - 650)) / 4;
            }
        }
    }
}
