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

        internal 客戶聯絡人 Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.IsDeleted == false);
        }
    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}