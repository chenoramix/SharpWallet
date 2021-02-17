using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWallet
{
    class Database
    {
        public string hashSha256 { get; set; }
        public List<Entry> listEntry { get; set; }

        public Database()
        {
            listEntry = new List<Entry>();
        }
        
        //create database
        public void createDatabase(string pathFilename)
        {

        }

        public void loadDatabase(string pathFilename)
        {

        }

        public void addEntry(Entry entry)
        {
            listEntry.Add(entry);
        }

        public void removeEntry(string entryName)
        {

        }
    }
}
