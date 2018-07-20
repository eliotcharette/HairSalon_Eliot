using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _stylist;
    private int _id;

    public Stylist (string stylist, int Id = 0)
    {
      _stylist = stylist;
      _id = Id;
    }
    public string GetStylist()
    {
      return _stylist;
    }
    public int GetId()
    {
      return _id;
    }
    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `stylists` WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int itemId = 0;
      string itemStylist = "";

      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemStylist = rdr.GetString(1);
      }

      Stylist foundStylist= new Stylist(itemStylist, itemId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return foundStylist;
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylist = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemStylist = rdr.GetString(1);
        Stylist newStylist = new Stylist(itemStylist, itemId);
        allStylist.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylist;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylists` (`stylist`) VALUES (@Stylist);";

      MySqlParameter stylist = new MySqlParameter();
      stylist.ParameterName = "@Stylist";
      stylist.Value = this._stylist;
      cmd.Parameters.Add(stylist);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public List<Specialty> GetSpecialties()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM stylists
      JOIN specialties_stylists ON (stylists.id = specialties_stylists.stylist_id)
      JOIN specialties ON (specialties_stylists.specialty_id = specialties.id)
      WHERE stylists.id = @StylistId;";

      MySqlParameter authorIdParameter = new MySqlParameter();
      authorIdParameter.ParameterName = "@StylistId";
      authorIdParameter.Value = _id;
      cmd.Parameters.Add(authorIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Specialty> specialties = new List<Specialty>{};

      while(rdr.Read())
      {
        int SpecialtyId = rdr.GetInt32(0);
        string SpecialtyTitle = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(SpecialtyTitle);
        specialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return specialties;
    }
    public List<Client> GetClients()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT clients.* FROM stylists
      JOIN clients_stylists ON (stylists.id = clients_stylists.stylist_id)
      JOIN clients ON (clients_stylists.client_id = clients.id)
      WHERE stylists.id = @StylistId;";

      MySqlParameter authorIdParameter = new MySqlParameter();
      authorIdParameter.ParameterName = "@StylistId";
      authorIdParameter.Value = _id;
      cmd.Parameters.Add(authorIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Client> clients = new List<Client>{};

      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientTitle = rdr.GetString(1);
        int stylistID = rdr.GetInt32(2);
        Client newClient = new Client(ClientTitle, stylistID);
        clients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return clients;
    }
    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool cuisineEquality = (this.GetStylist() == newStylist.GetStylist());
        return (idEquality && cuisineEquality);
      }
    }
    public void Edit(string newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET stylist = @newStylist WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);

      MySqlParameter stylist = new MySqlParameter();
      stylist.ParameterName = "@newStylist";
      stylist.Value = newStylist;
      cmd.Parameters.Add(stylist);

      cmd.ExecuteNonQuery();
      _stylist = newStylist;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void AddSpecialty(Specialty newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties_stylists (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = _id;
      cmd.Parameters.Add(stylist_id);

      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = newSpecialty.GetId();
      cmd.Parameters.Add(specialty_id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void AddClient(Client newClient)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients_stylists (stylist_id, client_id) VALUES (@StylistId, @ClientId);";

      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = _id;
      cmd.Parameters.Add(stylist_id);

      MySqlParameter client_id = new MySqlParameter();
      client_id.ParameterName = "@ClientId";
      client_id.Value = newClient.GetId();
      cmd.Parameters.Add(client_id);

      cmd.ExecuteNonQuery();
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
      cmd.CommandText = @"DELETE FROM `stylists` WHERE Id = @thisId;";

      cmd.Parameters.Add(new MySqlParameter("@thisId", _id));

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
