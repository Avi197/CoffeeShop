using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coffee3.Models.Entities;

namespace Coffee3.Models.Function
{
    public class drinkF
    {
        private Coffee mycoffee;

        public drinkF()
        {
            mycoffee = new Coffee();
        }

        public IQueryable<drink> listdrink
        {
            get { return mycoffee.drinks; }
        }
        
        //public List<drink> GetListDrink()
        //{
        //    return mycoffee.drinks.ToList();
        //}
        

        public drink FindEntity(string code)
        {
            drink dbEntry = mycoffee.drinks.Find(code);
            return dbEntry;
        }

        public bool Insert(drink model)
        {
            drink dbEntry = mycoffee.drinks.Find(model.code);

            if (dbEntry != null)
            {
                return false;

            }
            mycoffee.drinks.Add(model);

            mycoffee.SaveChanges();

            return true;
        }

        public bool Update(drink model)
        {
            drink dbEntry = mycoffee.drinks.Find(model.code);
            //   LoaiBanDoc dbEntry = mycoffee.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.nameof = model.nameof;
            mycoffee.SaveChanges();

            return true;
        }

        public bool Delete(string code)
        {
            drink dbEntry = mycoffee.drinks.Find(code);
            if (dbEntry == null)
            {
                return false;
            }
            mycoffee.drinks.Remove(dbEntry);

            mycoffee.SaveChanges();
            return true;
        }
    }
}