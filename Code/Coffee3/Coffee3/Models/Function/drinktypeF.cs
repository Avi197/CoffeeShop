using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coffee3.Models.Entities;

namespace Coffee3.Models.Function
{
    public class drinktypeF
    {
        private Coffee mycoffee;

        public drinktypeF()
        {
            mycoffee = new Coffee();
        }

        // Trả về All record
        public IQueryable<drinktype> listdrinktype
        {
            get { return mycoffee.drinktypes; }
        }
        // Trả về một đối tượng  khi biết Khóa
        public drinktype FindEntity(string code)
        {
            drinktype dbEntry = mycoffee.drinktypes.Find(code);
            return dbEntry;
        }
        // Thêm một đối tượng
        public bool Insert(drinktype model)
        {
            drinktype dbEntry = mycoffee.drinktypes.Find(model.code);

            if (dbEntry != null)
            {
                return false;

            }
            mycoffee.drinktypes.Add(model);

            mycoffee.SaveChanges();

            return true;
        }

        // Sửa một đối tượng
        public bool Update(drinktype model)
        {
            drinktype dbEntry = mycoffee.drinktypes.Find(model.code);
            //   LoaiBanDoc dbEntry = mycoffee.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.nameof = model.nameof;

            // Sửa các trường khác cũng như vậy
            mycoffee.SaveChanges();

            return true;
        }

        // Xóa một đối tượng
        public bool Delete(string code)
        {
            drinktype dbEntry = mycoffee.drinktypes.Find(code);
            if (dbEntry == null)
            {
                return false;
            }
            mycoffee.drinktypes.Remove(dbEntry);

            mycoffee.SaveChanges();
            return true;
        }
    }
}