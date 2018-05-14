using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coffee3.Models.Entities;


namespace Coffee3.Models.Function
{
    public class adminaccountF
    {
        private Coffee mycoffee;

        public adminaccountF()
        {
            mycoffee = new Coffee();
        }
        public adminaccount Login(string username, string pass)
        {
            var result = mycoffee.adminaccounts.Where(a => a.username.Equals(username) &&
                                                       a.passwordhash.Equals(pass)).FirstOrDefault();
            adminaccount t = null;
            if (result != null)
            {
                t = new adminaccount
                {
                    username = result.username,
                    passwordhash = result.passwordhash
                };

            }
            return t;
        }
        // Trả về All record
        public IQueryable<adminaccount> DSadminaccount
        {
            get { return mycoffee.adminaccounts; }
        }

        public adminaccount FindEntity(string username)
        {
            adminaccount dbEntry = mycoffee.adminaccounts.Find(username);
            return dbEntry;
        }

        public bool Insert(adminaccount model)
        {
            adminaccount dbEntry = mycoffee.adminaccounts.Find(model.username);

            if (dbEntry != null)
            {
                return false;

            }
            mycoffee.adminaccounts.Add(model);

            mycoffee.SaveChanges();

            return true;
        }

        public bool Update(adminaccount model)
        {
            adminaccount dbEntry = mycoffee.adminaccounts.Find(model.username);
            //   LoaiBanDoc dbEntry = mycoffee.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.passwordhash = model.passwordhash;

            mycoffee.SaveChanges();

            return true;
        }

        public bool Delete(string username)
        {
            adminaccount dbEntry = mycoffee.adminaccounts.Find(username);
            if (dbEntry == null)
            {
                return false;
            }
            mycoffee.adminaccounts.Remove(dbEntry);

            mycoffee.SaveChanges();
            return true;
        }

    }
}