using BurgerWebApp3BHWII.Models;
using Npgsql;

namespace BurgerWebApp3BHWII.Repositories;

public class KategorienRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=burgerdb;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);

        connection.Open();
        return connection;
    }

    public List<Kategorie> GetAllKategorien()
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen

        using NpgsqlCommand cmd = new NpgsqlCommand("Select * from kategorie;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Kategorie> kategorien = new List<Kategorie>();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            Kategorie newKategorie = new Kategorie();
            newKategorie.kategorieid = (int)reader["kategorieid"];
            newKategorie.title = (string)reader["title"];
            
            kategorien.Add(newKategorie);
        }

        myConnection.Close();
        //mit return zurückgeben
        return kategorien;
    }
}