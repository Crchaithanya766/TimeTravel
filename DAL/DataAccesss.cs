using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class DataAccesss : IDataAccess<Empdata>
    {
        public bool Delete(Empdata emp)
        {
            using (var del = new chinniDBEntities1())
            {
                del.Entry(emp).State = EntityState.Deleted;
                del.SaveChanges();
            }
            return true;
        }

        //public bool DeleteEmployee(Empdata emp)
        //{
        //    using (var db = new chinniDBEntities())
        //    {
        //        db.Entry(emp).State = EntityState.Deleted;
        //        db.SaveChanges();
                
        //    }
        //    return true;
        //}

        public List<Empdata> GetData()
        {
            List<Empdata> list = new List<Empdata>();
            using (var data = new chinniDBEntities1())
            {
                list = (from d in data.Empdatas select d).ToList();
            }
            return list;
        }

        public bool SaveEmployee(Empdata emp)
        {
            using (var db = new chinniDBEntities1())
            {
                db.Empdatas.Add(emp);
                db.SaveChanges();
            }
            return true;
        }

        public bool Update(Empdata emp)
        {
            using (var db = new chinniDBEntities1())
            {
               
                
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            return true;
        }
    }
}
