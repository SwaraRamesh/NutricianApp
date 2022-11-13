using Nutrician;
using Nutrician.Models;
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
            _database.CreateTableAsync<MedicalCondition>().Wait();
        }
        //m

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

        public Task<List<MedicalCondition>> GetMedicalConditionAsync()
        {
            return _database.Table<MedicalCondition>().ToListAsync();
        }

        public Task<int> SaveConditionAsync(MedicalCondition condition)
        {
            return _database.InsertAsync(condition);
        }

        public async Task<int> DeleteConditionAsync(MedicalCondition condition)
        {
            return await _database.DeleteAsync(condition);
        }

        public Task<int> UpdateConditionAsync(MedicalCondition condition)
        {
            return _database.UpdateAsync(condition);
        }

        public Task<int> SaveAllConditionsAsync(List<MedicalCondition> condition)
        {
            return _database.InsertAllAsync(condition);
        }
    }
}