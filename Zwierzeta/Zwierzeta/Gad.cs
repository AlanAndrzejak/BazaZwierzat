using System;
namespace Zwierzeta
{
    internal class Gad:Zwierz
    {
        
        private const string urodzony = "jajorodny";

        //opis
        public void Znaczenie()
        {
            Console.WriteLine("Gady (Reptilia, od łac. repto – czołgać się)");
        }

        // funkcje obowiazkowe z klasy bazowej
        public override void Urodzilem()
        {
            Console.WriteLine("Jestem {0} i wlasnie mnie stworzyles", urodzony);
        }

        public override void Zwierzak()
        {
            Console.WriteLine("Jestem gadem");
        }
    }
}