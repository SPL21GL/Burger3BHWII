using BurgerWebApp3BHWII.Models;
using Npgsql;

namespace BurgerWebApp3BHWII.Repositories;

public class BurgerRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=burger;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        
        connection.Open();
        return connection;
    }
    
    public List<Burger> GetAllBurgers()
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen
        
        using NpgsqlCommand cmd = new NpgsqlCommand("Select * from Burger;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Burger> burgers = new List<Burger>();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            Burger newBurger = new Burger();
            newBurger.BurgerId = (int) reader["BurgerId"];
            newBurger.Title = (string) reader["Title"];
            newBurger.Description = (string) reader["Description"];
            newBurger.InventedDate = (DateTime) reader["Invented"];
            newBurger.Price = (double) reader["Price"];
            
            burgers.Add(newBurger);
        }
        
        myConnection.Close();
        //mit return zurückgeben
        return burgers;
    }

    public void CreateBurger(Burger burger)
    {
        
    }

    public void DeleteBurger(int burgerId)
    {
        
    }

    public void UpdateBurger(Burger burger)
    {
        
    }
}