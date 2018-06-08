using ShoppingCarts.Helpers.Interface;
using ShoppingCarts.iOS.Database;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]

namespace ShoppingCarts.iOS.Database
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
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection
            return conn;
        }

        #endregion ISQLite implementation
    }
}