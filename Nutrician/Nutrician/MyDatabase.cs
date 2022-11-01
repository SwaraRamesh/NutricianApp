using Nutrician;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseEx.Droid
{
    public class MyDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public MyDatabase(String dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPersonAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return _database.InsertAsync(person);
        }

        public async Task<int> DeletPersonAsync(Person person)
        {
            return await _database.DeleteAsync(person);
        }

        public Task<int> UpdatePersonAsync(Person person)
        {
            return _database.UpdateAsync(person);
        }
    }
}