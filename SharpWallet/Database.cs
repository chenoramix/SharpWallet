using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWallet
{
    class Database
    {
        private string hashSha256;
        private List<Entry> listEntry;

        public Database()
        {
            listEntry = new List<Entry>();
        }
        //set hash
        public void setHash(string hash)
        {
            this.hashSha256 = hash;
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
