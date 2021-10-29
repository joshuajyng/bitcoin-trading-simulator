using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace A2.Services
{
    [Table("Transaction")]
    public class transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } //1, 1,000,000, 0, 0, null
        public int Cash { get; set; }
        public int Btc { get; set; }
        public int Amount { get; set; }
        public string Buy { get; set; }
        
    }
}
