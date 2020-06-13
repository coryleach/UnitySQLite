<p align="center">
<img align="center" src="https://raw.githubusercontent.com/coryleach/UnityPackages/master/Documentation/GameframeFace.gif" />
</p>
<h1 align="center">Gameframe.SQLite 👋</h1>

<!-- BADGE-START -->
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/c2a754590edd4f7b92d1252f83708b05)](https://www.codacy.com/manual/coryleach/UnitySQLite?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=coryleach/UnitySQLite&amp;utm_campaign=Badge_Grade)
![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/coryleach/UnitySQLite?include_prereleases)
[![openupm](https://img.shields.io/npm/v/com.gameframe.sceneswitcher?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.gameframe.sceneswitcher/)
![GitHub](https://img.shields.io/github/license/coryleach/UnitySQLite)

[![twitter](https://img.shields.io/twitter/follow/coryleach.svg?style=social)](https://twitter.com/coryleach)
<!-- BADGE-END -->

SQLite Package

## Quick Package Install

#### Using UnityPackageManager (for Unity 2019.3 or later)
Open the package manager window (menu: Window > Package Manager)<br/>
Select "Add package from git URL...", fill in the pop-up with the following link:<br/>
https://github.com/coryleach/UnitySQLite.git#1.0.2<br/>

#### Using UnityPackageManager (for Unity 2019.1 or later)

Find the manifest.json file in the Packages folder of your project and edit it to look like this:
```js
{
  "dependencies": {
    "com.gameframe.sqlite": "https://github.com/coryleach/UnitySQLite.git#1.0.2",
    ...
  },
}
```

<!-- DOC-START -->
<!-- 
Changes between 'DOC START' and 'DOC END' will not be modified by readme update scripts
-->

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

<!-- DOC-END -->

## Author

👤 **Cory Leach**

* Twitter: [@coryleach](https://twitter.com/coryleach)
* Github: [@coryleach](https://github.com/coryleach)


## Show your support

Give a ⭐️ if this project helped you!

***
_This README was generated with ❤️ by [Gameframe.Packages](https://github.com/coryleach/unitypackages)_
