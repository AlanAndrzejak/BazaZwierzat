using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;

namespace Zwierzeta
{
    class OBD
    { // baza danych na zasadzie DO NOT COPY, reczne umieszanie w binie przy zmianie bazy danych
        public void konsola() // wybory przy bazie danych
        {
            Console.WriteLine("Prosze wybierz z nastepujacych opcji: \n"
                    + " [1] Dodanie Gada \n"
                    + " [2] Dodanie Ssaka \n"
                    + " [3] Wyjscie z programu\n"
                    + "Twoj wybor: ");
        }
        public bool server() // zapytanie o server bazowy
        {
            Console.WriteLine("Czy polaczyc sie z serverem bazowym?[T/N]");
            string z = Console.ReadLine();
            if (z == "t" || z == "T")
                return true;
            else
                return false;
        }

        public void blad()// informacja o wystapieniu bledy
        {
            Console.WriteLine("Wystapil blad w komunikacji z baza danych");
        }

        public string Bazowa()
        {
            return ConfigurationManager.ConnectionStrings["Zwierzeta.Properties.Settings.atlaszwierzatConnectionString"].ConnectionString;
        }
        public string NewCon()
        {
            Console.WriteLine("Prosze podac nazwe projektu: ");
            string nazwaprojektu = Console.ReadLine();
            nazwaprojektu.Trim();
            Console.WriteLine("Prosze podac nazwe bazydanych: ");
            string nazwabazy = Console.ReadLine();
            nazwabazy.Trim();
            try {
                return ConfigurationManager.ConnectionStrings[nazwaprojektu + ".Properties.Settings." + nazwabazy + "ConnectionString"].ConnectionString;
            }
            catch (Exception e){
                Console.WriteLine("\n\n Blad connection stringa {0}" + e);
                return ""; }

        }

        public string Last_Id_ssaki() // query na  ostatnie ID z tabeli ssaki
        {
            return "SELECT max(id) id FROM Ssaki";
        }
        public string Last_Id_gady() // query na  ostatnie ID z tabeli gady
        {
            return "SELECT max(id) id FROM Gady";
        }

        public void wsadz_gada( ArrayList a, SqlConnection con) // Insertowanie
        {
            var famGady = a.OfType<Gad>();
            var obiekt = from Gad in famGady // wybierz z listy obiekt 
                             select Gad; 
            foreach (var animal in obiekt) // dla kazdego obiektu w liscie zrob inserta
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO Gady VALUES(@id, @gatunek, @nazwa, @glos, @zycie, @jem, @region)", con);
                command1.Parameters.AddWithValue("@id", animal.ustaw_id); 
                command1.Parameters.AddWithValue("@gatunek", animal.ustaw_gatunek);
                command1.Parameters.AddWithValue("@nazwa", animal.ustaw_nazwa);
                command1.Parameters.AddWithValue("@glos", animal.ustaw_glos);
                command1.Parameters.AddWithValue("@zycie", animal.ustaw_zycie);
                command1.Parameters.AddWithValue("@jem", animal.ustaw_jem);
                command1.Parameters.AddWithValue("@region", animal.ustaw_region);
                command1.ExecuteNonQuery();
                Console.WriteLine("Wrzuciles gada o id: {0}", animal.ustaw_id);
            }
        }
        public void wsadz_ssaka(ArrayList a, SqlConnection con) // Insertowanie
        {
            var famSsaki = a.OfType<Ssak>();
            var obiekt = from Sak in famSsaki // wybierz z listy obiekt 
                         select Sak;
            foreach (var animal in obiekt) // dla kazdego obiektu w liscie zrob inserta
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO Ssaki VALUES(@id, @gatunek, @nazwa, @glos, @zycie, @jem, @region, @Ilosc_Czlonkow)", con);
                command1.Parameters.AddWithValue("@id", animal.ustaw_id);
                command1.Parameters.AddWithValue("@gatunek", animal.ustaw_gatunek);
                command1.Parameters.AddWithValue("@nazwa", animal.ustaw_nazwa);
                command1.Parameters.AddWithValue("@glos", animal.ustaw_glos);
                command1.Parameters.AddWithValue("@zycie", animal.ustaw_zycie);
                command1.Parameters.AddWithValue("@jem", animal.ustaw_jem);
                command1.Parameters.AddWithValue("@region", animal.ustaw_region);
                command1.Parameters.AddWithValue("@Ilosc_Czlonkow", animal.ustaw_konczyny);
                command1.ExecuteNonQuery();
                Console.WriteLine("Wrzuciles ssaka o id: {0}", animal.ustaw_id);
            }
            Console.ReadKey();
        }

        public bool Polaczenie(string connectionString) // sprawdzenie polaczenia
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\n \n blad polaczenia {0}" + e);
                return false;
            }
        }
        public int Gady(SqlConnection con)    // sciagniecie ostatniego id
        {
            string query = Last_Id_gady(); // query na ostatnie id 
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    int max_id=0;
                    while (rdr.Read())
                    {
                        try
                        {
                            max_id = (int)rdr["id"];// zebranie max id
                        }
                        catch (Exception) { Console.WriteLine("Wynik zapytania pusty, trzeba cos dodac"); }
                    }
                    rdr.Close();
                    return max_id;
                }
                 rdr.Close();
                return 0; // jezeli nie ma rekordow id od zera
            }
        }

        public int Ssak(SqlConnection conn) //sciagniecie ostatniego id
        {
            string query = Last_Id_ssaki(); // query na ostatnie id 
            using (SqlCommand cmd = new SqlCommand(query, conn))

            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    int max_id = 0;
                    while (rdr.Read())
                    {
                        try
                        {
                            max_id = (int)rdr["id"];// zebranie max id
                        }
                        catch (Exception) { Console.WriteLine("Wynik zapytania pusty, trzeba cos dodac"); }
                    }
                    rdr.Close();
                    return max_id;
                }
                rdr.Close();
                return 0; // jezeli nie ma rekordow id od zera
            }
        }

    }

}
