using System;
using System.IO;

using ShoppingCarts.Droid.Database;
using ShoppingCarts.Helpers.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]

namespace ShoppingCarts.Droid.Database
{
    public class SqliteService : ISQLite
    {
        public SqliteService()
        {
        }

        #region ISQLite implementation

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLiteEx.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            // Return the database connection
            return conn;
        }

        #endregion ISQLite implementation
    }
}