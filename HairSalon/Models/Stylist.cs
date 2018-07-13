using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _stylist;
    private string _specialty;
    private int _id;

    public Stylist (string stylist, string specialty, int Id = 0)
    {
      _stylist = stylist;
      _specialty = specialty;
      _id = Id;
    }
    public string GetStylist()
    {
      return _stylist;
    }
    public string GetSpecialty()
    {
      return _specialty;
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
      string itemSpecialty = "";

      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemStylist = rdr.GetString(1);
        itemSpecialty = rdr.GetString(2);
      }

      Stylist foundStylist= new Stylist(itemStylist, itemSpecialty, itemId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return foundStylist;
    }
    // public static List<Stylist> GetIndian()
    // {
    //   List<Stylist> allIndian = new List<Stylist> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM stylists WHERE cuisine_id = 4;";
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int itemId = rdr.GetInt32(0);
    //     string itemStylist = rdr.GetString(1);
    //     int itemSpecialty = rdr.GetInt32(2);
    //     Stylist indianStylist = new Stylist(itemStylist, itemSpecialty, itemId);
    //     allIndian.Add(indianStylist);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allIndian;
    // }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylist = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemStylist = rdr.GetString(1);
        string itemSpecialty = rdr.GetString(2);
        Stylist newStylist = new Stylist(itemStylist, itemSpecialty, itemId);
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
      cmd.CommandText = @"INSERT INTO `stylists` (`stylist`, `specialty`) VALUES (@itemStylist, @itemSpecialty);";

      MySqlParameter stylist = new MySqlParameter();
      stylist.ParameterName = "@itemStylist";
      stylist.Value = this._stylist;
      cmd.Parameters.Add(stylist);

      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@itemSpecialty";
      specialty.Value = this._specialty;
      cmd.Parameters.Add(specialty);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
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
      cmd.CommandText = @"UPDATE stylists SET stylists = @newStylist WHERE id = @searchId;";
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

  }
}
