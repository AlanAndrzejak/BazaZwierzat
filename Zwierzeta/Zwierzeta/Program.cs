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


    class Program
    {

        static void Main(string[] args)
        {
            string connectionString;
            string zmiana;
            int Id_Gada;
            int Id_Ssaka;
            OBD pol = new OBD();
            ArrayList Gady = new ArrayList();
            ArrayList Ssaki = new ArrayList();
            if (pol.server()) // zapytanie z jakim serverem chcemy sie polaczyc
            {
                connectionString = pol.Bazowa();
            }
            else
            {
                connectionString = pol.NewCon();
            }
            if (pol.Polaczenie(connectionString)) // Sprawdzenie czy jest mozliwe polaczenie sie z baza danych
            {
                Console.WriteLine("Witaj!");
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                do
                {
                    pol.konsola(); 
                    zmiana = Console.ReadLine();
                    switch (zmiana)
                    {
                        case ("1"):
                            {
                                    Id_Gada = pol.Gady(conn); // wez ID z bazy danych
                                    Gad Tadek = new Gad();
                                    Tadek.ustaw_id = ++Id_Gada; // nadaj obiektowi id z bazy danych o jeden wieksze
                                    Tadek.Znaczenie(); // opis 
                                    Tadek.Zwierzak();// opis 
                                    Tadek.Urodzilem();// opis 

                                    Tadek.All(); // funkcja zbierajaca dane
                                    Gady.Add(Tadek);// dodanie obiektu do listy
                                    pol.wsadz_gada(Gady, conn); // wywolanie funckji dodajacej do bazy danych
                                    Gady.Remove(Tadek); // usuniecie obiektu z listy
                                    Tadek = null; // zwolenienie obiektu
                                
                                break;
                            }
                        case ("2"):
                            {
                                Id_Ssaka = pol.Ssak(conn);// wez ID z bazy danych
                                Ssak Marek = new Ssak();
                                Marek.ustaw_id = ++Id_Ssaka;// nadaj obiektowi id z bazy danych o jeden wieksze
                                Marek.Zwierzak();// opis 
                                Marek.Urodzilem();// opis 

                                Marek.All();// funkcja zbierajaca dane
                                Ssaki.Add(Marek);// dodanie obiektu do listy
                                pol.wsadz_ssaka(Ssaki, conn);// wywolanie funckji dodajacej do bazy danych
                                Ssaki.Remove(Marek);// usuniecie obiektu z listy
                                Marek = null;// zwolenienie obiektu

                            break;
                            }
                        case ("3"):
                            {

                                Console.WriteLine("Zegnaj!");
                                conn.Close();
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("Nie ma takiej opcji :( ");
                                break;
                            }
                    }
                } while (zmiana != "3");

            }
            else
            {
                pol.blad();
            }

                Console.Read();
            
        }
    }
}
