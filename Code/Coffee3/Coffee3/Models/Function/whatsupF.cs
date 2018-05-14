using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coffee3.Models.Entities;

namespace Coffee3.Models.Function
{
    public class whatsupF
    {
        private Coffee mycoffee;

        public whatsupF()
        {
            mycoffee = new Coffee();
        }

        // Trả về All record
        public IQueryable<whatsup> DSwhatsup
        {
            get { return mycoffee.whatsups; }
        }
        // Trả về một đối tượng  khi biết Khóa
        public whatsup FindEntity(string code)
        {
            whatsup dbEntry = mycoffee.whatsups.Find(code);
            return dbEntry;
        }
        // Thêm một đối tượng
        public bool Insert(whatsup model)
        {
            whatsup dbEntry = mycoffee.whatsups.Find(model.code);

            if (dbEntry != null)
            {
                return false;

            }
            mycoffee.whatsups.Add(model);

            mycoffee.SaveChanges();

            return true;
        }

        // Sửa một đối tượng
        public bool Update(whatsup model)
        {
            whatsup dbEntry = mycoffee.whatsups.Find(model.code);
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
            whatsup dbEntry = mycoffee.whatsups.Find(code);
            if (dbEntry == null)
            {
                return false;
            }
            mycoffee.whatsups.Remove(dbEntry);

            mycoffee.SaveChanges();
            return true;
        }

    }
}