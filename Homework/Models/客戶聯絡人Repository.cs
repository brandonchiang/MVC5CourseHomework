using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework.Models
{
    public class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
    {
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p=>p.IsDeleted==false);
        }

        public IQueryable<客戶聯絡人> Empty()
        {
            return this.All().Where(p => p.Id == -1); //一定不會有資料，只是為了想要宣告一個空的
        }

        internal 客戶聯絡人 Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.IsDeleted == false);
        }

        public IQueryable<客戶聯絡人> filterBy職稱(string 職稱)
        {
            return base.All().Where(p => p.IsDeleted == false && p.職稱.Contains(職稱));
        }
    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}