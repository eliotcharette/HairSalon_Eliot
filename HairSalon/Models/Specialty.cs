using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Specialty
  {
    private string _specialty;
    private int _id;

    public Specialty (string specialty, int Id = 0)
    {
      _specialty = specialty;
      _id = Id;
    }
    public string GetSpecialty()
    {
      return _specialty;
    }
    public int GetId()
    {
      return _id;
    }
    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `specialties` WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int itemId = 0;
      string itemSpecialty = "";

      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemSpecialty = rdr.GetString(1);
      }

      Specialty foundSpecialty= new Specialty(itemSpecialty, itemId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return foundSpecialty;
    }
    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialty = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemSpecialty = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(itemSpecialty, itemId);
        allSpecialty.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialty;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `specialties` (`specialty`) VALUES (@Specialty);";

      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@Specialty";
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
    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
      JOIN specialties_stylists ON (specialties.id = specialties_stylists.specialty_id)
      JOIN stylists ON (specialties_stylists.stylist_id = stylists.id)
      WHERE specialties.id = @SpecialtyId;";

      MySqlParameter authorIdParameter = new MySqlParameter();
      authorIdParameter.ParameterName = "@SpecialtyId";
      authorIdParameter.Value = _id;
      cmd.Parameters.Add(authorIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> specialties = new List<Stylist>{};

      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistTitle = rdr.GetString(1);
        Stylist newStylist = new Stylist(StylistTitle);
        specialties.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return specialties;
    }
    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = (this.GetId() == newSpecialty.GetId());
        bool cuisineEquality = (this.GetSpecialty() == newSpecialty.GetSpecialty());
        return (idEquality && cuisineEquality);
      }
    }
    public void Edit(string newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialties SET specialties = @newSpecialty WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);

      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@newSpecialty";
      specialty.Value = newSpecialty;
      cmd.Parameters.Add(specialty);

      cmd.ExecuteNonQuery();
      _specialty = newSpecialty;

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
      cmd.CommandText = @"DELETE FROM `specialties` WHERE Id = @thisId;";

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
      cmd.CommandText = @"DELETE FROM specialties;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
