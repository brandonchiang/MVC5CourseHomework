using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p=>p.IsDeleted==false);
        }

        public 客戶資料 Find(int id)
        {
            return this.All().Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<string> getCalalogList()
        {
            return base.All().Select(d=>d.客戶分類).Distinct();
        }
        public IQueryable<客戶資料> filterByCatalog(string catalog)
        {
            return base.All().Where(p => p.IsDeleted == false && p.客戶分類.Equals(catalog));
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}