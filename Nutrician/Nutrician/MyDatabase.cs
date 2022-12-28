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

        public Task<Person> GetPersonByUsernameAsync(String username)
        {
            return _database.Table<Person>().Where(p => p.Username.Equals(username)).FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return _database.InsertOrReplaceAsync(person);
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

        public Task<List<MedicalCondition>> GetDisplayCondition()
        {
            return _database.Table<MedicalCondition>().ToListAsync();
        }

        public Task<MedicalCondition> GetConditionName(String name, int id) {
            return _database.Table<MedicalCondition>().Where(p => p.Name == name).Where(p => p.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAllConditionsAsync()
        {
            return await _database.DeleteAllAsync<MedicalCondition>();
        }

        public Task<List<MedicalCondition>> Search(string search)
        {
            return _database.Table<MedicalCondition>().Where(p => p.Name.Contains(search)||
                                       p.Suggestions.Contains(search)).ToListAsync();
            //async = sends it as it reads from the database
        }

        /*public Task<List<MedicalCondition>> Search2(string search)
        {
            return _database.Table<MedicalCondition>().Where(p => p.Suggestions.StartsWith(search)).ToListAsync();
        }
       */

        public async Task<int> DeleteAllAccountsAsync()
        {
            return await _database.DeleteAllAsync<Person>();
        }

        public Task<int> SaveReminderAsync(Reminder reminder)
        {
            return _database.InsertOrReplaceAsync(reminder);
        }

        public async Task<int> DeletReminderAsync(Reminder reminder)
        {
            return await _database.DeleteAsync(reminder);
        }

        public Task<int> UpdateReminderAsync(Reminder reminder)
        {
            return _database.UpdateAsync(reminder);
        }

        public Task<int> SaveMyListAsync(MyList list)
        {
            return _database.InsertOrReplaceAsync(list);
        }

        public async Task<int> DeletMyListAsync(MyList list)
        {
            return await _database.DeleteAsync(list);
        }

        public Task<int> UpdateMyListAsync(MyList list)
        {
            return _database.UpdateAsync(list);
        }
    }
}