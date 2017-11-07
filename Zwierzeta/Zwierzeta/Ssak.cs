using System;

namespace Zwierzeta
{
    internal class Ssak:Zwierz
    {

        private int ilosc_konczyn;
        private const string urodzony = "zyworodny";

        //setter getter 
        public int ustaw_konczyny {
            get
            {
                return ilosc_konczyn;
            }
            set
            {
                ilosc_konczyn = value;
            }

        }

        //Funkcja wywolujaca ustawianie
        override public void All()
        {
            base.All();
            Podaj_konczyny();
        }

        public void Podaj_konczyny()
        {
            Console.WriteLine("Podaj moja ilosc konczyn : ");
            string konczyny = Console.ReadLine();
            ustaw_konczyny = (int)(base.kontrola(konczyny));
        }
        // funkcje obowiazkowe z klasy bazowej
        public override void Urodzilem()
        {
            Console.WriteLine("Jestem {0} i wlasnie mnie stworzyles", urodzony);
        }

        public override void Zwierzak()
        {
            Console.WriteLine("Jestem Ssakiem jednak dalej trzeba mnie troche uzupelnic");
        }

    }
}