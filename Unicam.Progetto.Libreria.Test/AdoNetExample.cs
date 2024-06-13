using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Abstractions;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Test
{
    public class AdoNetExample : IExample
    {
        public void RunExample()
        {
            AggiungiLibro();
            getLibri();
        }

        private void AggiungiLibro ()
        {
            using (var connection = new SqlConnection())
            {

                //stringa di connessione
                connection.ConnectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=Libreria;User Id=progetto; Password=progetto";
                connection.Open();

                //aggiungo le cose, creo il comando
                var cmd = new SqlCommand();
                //comando usato in una determinata connesione
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO Libro (Nome, Autore, DataPubblicazione, Editore) VALUES (@NOME, @AUTORE, @DATA_PUBBLICAZIONE, @EDITORE)";
                cmd.Parameters.AddWithValue("@NOME", "Circe");
                cmd.Parameters.AddWithValue("@AUTORE", "Madeline Miller");
                cmd.Parameters.AddWithValue("@DATA_PUBBLICAZIONE", "11/11/1999");
                cmd.Parameters.AddWithValue("@EDITORE", "Giunti");
                //non devo leggere nessun risultato
                cmd.ExecuteNonQuery();
            }
        }

        private void getLibri()
        {
            using (var connection = new SqlConnection())
            {

                //stringa di connessione
                connection.ConnectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=Libreria;User Id=progetto; Password=progetto";
                connection.Open();

                //aggiungo le cose, creo il comando
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT LibroId, Nome, Autore, DataPubblicazione, Editore FROM Libro";

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //casto perche reader restituisce object
                            var libro = new Libro();
                            libro.LibroId = (int)reader["LibroId"];
                            libro.Nome = (string)reader["Nome"];
                            libro.Autore = (string)reader["Autore"];
                            libro.DataPubblicazione = (DateTime)reader["DataPubblicazione"];
                            libro.Editore = (string)reader["Editore"];
                        }
                    }
                }
            }
        }
    }
}

//tutto ciò è particolarmente oneroso in termini di codice. Dovremmo fornire tali metodi per ogni tabella del database.
/*
 Per questo ci serviamo invece di un altra tecnologia, gli ORM (Object-Relational Mapping). Questi ci consentono di interfacciarci al progetto
con un approccio code-first, attraverso il quale dopo aver creato le classi che costituiscono la nostra applicazione, l'ORM può mapparle
automaticamente in un database e renderle disponibili per la persistenza dei dati, tutto a partire dal nostro codice. Entitiy Framework Core
(l'ORM che utilizzeremo) si serve di un database provider che si interfaccia tra il database e la nostra applicazione. Analizza le richieste dell'app
le traduce nel linguaggio del db (quindi non dovremmo specificare per forza una connessione statica come in questo esempio) e gliele inoltra. (Cambierà db provider)
Una volta finite le operazione, il db restituisce in risultato che passa al db provider per farlo tradurre. Ecco qui che mappa automaticamente le risposte
del db nella nostra applicazione.
 
 */
