using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Client
  {
    private string _client;
    private int _stylistId;
    private int _id;

    public Client (string client, int stylistId, int Id = 0)
    {
      _client = client;
      _stylistId = stylistId;
      _id = Id;
    }
    public string GetClient()
    {
      return _client;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public int GetId()
    {
      return _id;
    }
    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int itemId = 0;
      string itemClient = "";
      int itemStylistId = 0;

      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemClient = rdr.GetString(1);
        itemStylistId = rdr.GetInt32(2);
      }

      Client foundClient = new Client(itemClient, itemStylistId, itemId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return foundClient;
    }
    public static List<Client> FindByStylist(int stylistId)
    {
      List<Client> styleClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `clients` WHERE stylist_id = @thisStylist_id;";
      MySqlParameter stylist = new MySqlParameter();
      stylist.ParameterName = "@thisStylist_id";
      stylist.Value = stylistId;
      cmd.Parameters.Add(stylist);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = 0;
        string itemClient = "";
        int itemStylistId = 0;

        Client newClient = new Client(itemClient, itemStylistId, itemId);
        styleClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return styleClients;
    }
    public static List<Client> GetAll()
    {
      List<Client> allClient = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemClient = rdr.GetString(1);
        int itemStylistId = rdr.GetInt32(2);
        Client newClient = new Client(itemClient, itemStylistId, itemId);
        allClient.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClient;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `clients` (`client`, `stylist_id`) VALUES (@itemClient, @itemStylistId);";

      MySqlParameter client = new MySqlParameter();
      client.ParameterName = "@itemClient";
      client.Value = this._client;
      cmd.Parameters.Add(client);

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@itemStylistId";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool cuisineEquality = (this.GetClient() == newClient.GetClient());
        return (idEquality && cuisineEquality);
      }
    }
    public void Edit(string newClient)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET clients = @newClient WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);

      MySqlParameter client = new MySqlParameter();
      client.ParameterName = "@newClient";
      client.Value = newClient;
      cmd.Parameters.Add(client);

      cmd.ExecuteNonQuery();
      _client = newClient;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM `clients` WHERE Id = @thisId;";

      cmd.Parameters.Add(new MySqlParameter("@thisId", _id));

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
