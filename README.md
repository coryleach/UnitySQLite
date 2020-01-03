<h1 align="center">Welcome to com.gameframe.sqlite 👋</h1>
<p>
  <img alt="Version" src="https://img.shields.io/badge/version-1.0.0-blue.svg?cacheSeconds=2592000" />
  <a href="https://twitter.com/coryleach">
    <img alt="Twitter: coryleach" src="https://img.shields.io/twitter/follow/coryleach.svg?style=social" target="_blank" />
  </a>
</p>

> SQLite Package for Unity</br>

## Quick Package Install

#### Using UnityPackageManager (for Unity 2019.1 or later)

Find the manifest.json file in the Packages folder of your project and edit it to look like this:
```js
{
  "dependencies": {
    "com.gameframe.sqlite": "https://github.com/coryleach/UnitySQLite.git#1.0.0",
    ...
  },
}
```

## Usage

```c#
using Mono.Data.SqliteClient;

// Create database
string path = Application.persistentDataPath + "/" + "My_Test_Database";
string connection = "URI=file:" + path;

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
```

## Author

👤 **Cory Leach**

* Twitter: [@coryleach](https://twitter.com/coryleach)
* Github: [@coryleach](https://github.com/coryleach)

## Show your support

Give a ⭐️ if this project helped you!

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_
