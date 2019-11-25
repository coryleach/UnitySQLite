using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Mono.Data.SqliteClient;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SQLiteRuntimeTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CreateTable_InsertValue_ReadValue()
        {
            // Use the Assert class to test conditions
            // Create database
            string path = Application.persistentDataPath + "/" + "My_Test_Database";
            string connection = "URI=file:" + path;

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            
            // Open connection
            IDbConnection dbcon = new SqliteConnection(connection);
            dbcon.Open();

            // Create table
            IDbCommand dbcmd;
            dbcmd = dbcon.CreateCommand();
            string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";
		
            dbcmd.CommandText = q_createTable;
            dbcmd.ExecuteReader();

            // Insert values in table
            IDbCommand cmnd = dbcon.CreateCommand();
            cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (0, 5)";
            cmnd.ExecuteNonQuery();

            // Read and print all values in table
            IDbCommand cmnd_read = dbcon.CreateCommand();
            IDataReader reader;
            string query ="SELECT * FROM my_table";
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();

            while (reader.Read())
            {
                Debug.Log("id: " + reader[0].ToString());
                Debug.Log("val: " + reader[1].ToString());
            }

            // Close connection
            dbcon.Close();
            
            File.Delete(path);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        /*[UnityTest]
        public IEnumerator SQLiteRuntimeTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }*/
    }
}
