using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeMachineEntites;

namespace DAL.Interface
{
    public interface IDataAccess<T>
    {
        bool SaveEmployee(Empdata emp);
        bool Update(Empdata emp);
        bool Delete(Empdata emp);
        List<T> GetData();
    }
}
