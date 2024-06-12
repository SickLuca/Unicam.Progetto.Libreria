using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Abstractions;

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
                cmd.Parameters.AddWithValue("@NOME", "Buchi Neri e universi neonati");
                cmd.Parameters.AddWithValue("@AUTORE", "Stephen Hawking");
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
