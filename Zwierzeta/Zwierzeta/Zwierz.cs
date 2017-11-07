using System;

namespace Zwierzeta
{
    abstract internal class Zwierz
    {

        // Zmienne: 
        private int id;
        private string gatunek;
        private string nazwa;
        private string glos;
        private float zycie;
        private string jem;
        private string region;
        // Metody ktore musza byc w klasie pochodnej
        abstract public void Zwierzak();
        abstract public void Urodzilem();

        // Kontrola wprowadzania danych: 
        public virtual float kontrola( string a)
        {
            float b;
            if (float.TryParse(a, out b))
                return b;
            else 
            return 0;
        }
        
        //Funkcja wywolujaca ustawianie
        virtual public void All()
        {
            Podaj_gatunek();
            Podaj_nazwe();
            Podaj_glos();
            Podaj_zycie();
            Podaj_jem();
            Podaj_region();
        }
        // Funckja tworzaca nowego czlonka rodziny


        // Funkcje zapytujace o zmienne: 
        public void Podaj_gatunek() { Console.WriteLine("Podaj moj gatunek : ");
            gatunek = Console.ReadLine(); }

        public void Podaj_nazwe() { Console.WriteLine("Prosze nazwij mnie jak chcesz : ");
            ustaw_nazwa = Console.ReadLine(); }

        public void Podaj_glos() { Console.WriteLine("Jaki dzwiek wydobywam? : ");
            ustaw_glos = Console.ReadLine(); }

        public void Podaj_zycie() { Console.WriteLine("Prosze podaj sredni wiek zycia : ");
            string wiek = Console.ReadLine();
            ustaw_zycie = kontrola(wiek); }

        public void Podaj_jem() { Console.WriteLine("Czym sie karmie? ");
            ustaw_jem = Console.ReadLine(); }

        public void Podaj_region() { Console.WriteLine("W jakim regionie zyje : ");
            ustaw_region = Console.ReadLine(); }

        // Settery gettery: 
        public int ustaw_id
        {
            get{ return id; }
            set{ id = value; }
        }

        public string ustaw_gatunek
        {
            get { return gatunek; }
            set { gatunek = value; }
        }
        public string ustaw_nazwa
        {
            get{return nazwa;}
            set{nazwa=value;}
        }
         public string ustaw_glos
        {
            get { return glos; }
            set { glos = value; }
        }
         public float ustaw_zycie
        {
            get { return zycie; }
            set { zycie = value; }
        }
         public string ustaw_jem
        {
            get { return jem; }
            set { jem = value; }
        }
         public string ustaw_region
        {
            get { return region; }
            set { region = value; }
        }

    }
}