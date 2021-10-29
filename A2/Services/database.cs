using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace A2.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection db;
        public Database(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<transaction>().Wait();
        }
        public Task<List<transaction>> GetRecent()
        {
            var recent = db.QueryAsync<transaction>("SELECT * FROM [Transaction] ORDER BY Id DESC LIMIT 1");
            return recent;
        }
        public Task<List<transaction>> GetTrans()
        {
            return db.Table<transaction>().ToListAsync();
        }
        public Task<int> AddTrans(transaction trans)
        {
            return db.InsertAsync(trans);
        }

    }
}
