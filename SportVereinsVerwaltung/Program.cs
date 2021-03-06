﻿using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace SportVereinsVerwaltung
{
  class Program
  {
    static void Main(string[] args)
    {
       IDbConnection dbcon;
       dbcon = new MySqlConnection(SVVConfig.ConnectionString);
       dbcon.Open();
       IDbCommand dbcmd = dbcon.CreateCommand();

       string sql =
           "SELECT * " +
           "FROM tunterricht";
       dbcmd.CommandText = sql;
       IDataReader reader = dbcmd.ExecuteReader();
       while(reader.Read()) {
            string FirstName = (string) reader["U_Raum"];
            string LastName = (string) reader["U_Fach"];
            Console.WriteLine("Name: " +
                  FirstName + " " + LastName);
       }
       // clean up
       reader.Close();
       reader = null;
       dbcmd.Dispose();
       dbcmd = null;
       dbcon.Close();
       dbcon = null;
    }
  }
}


