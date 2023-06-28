using MAUI_Demo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Demo.Helpers
{
    public class Database
    {
        private SQLiteAsyncConnection _database;
        private readonly string _databasePath;
        private async Task Init()
        {
            if (_database != null)
            {
                return;
            }

            var options = new SQLiteConnectionString(_databasePath, true, "password", postKeyAction: c =>
            {
                c.Execute("PRAGMA cipher_compatibility = 3");
            });
            _database = new SQLiteAsyncConnection(options);
            await _database.CreateTableAsync<User>();
        }

        public Database(string dbPath)
        {
            _databasePath = dbPath;
        }

        #region [Person Data ]
        public async Task<List<User>> GetPeopleAsync()
        {
            await Init();

            return await _database.Table<User>().ToListAsync();
        }

        public async Task<int> SavePersonAsync(User person)
        {
            await Init();

            return await _database.InsertAsync(person);
        }

        public async Task<int> UpdatePersonAsync(User person)
        {
            await Init();

            return await _database.UpdateAsync(person);
        }

        public async Task<int> DeletePersonAsync(int userId)
        {
            await Init();

            return await _database.DeleteAsync(userId);
        }
        #endregion
    }
}
