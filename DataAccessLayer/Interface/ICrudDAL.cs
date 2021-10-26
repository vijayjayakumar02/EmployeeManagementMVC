using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
   public interface ICrudDAL
    {
     
        IEnumerable<Employee> GetAll();

     
        Employee Get(int id);

        void Create(Employee employee);

        void Update(Employee employee);

        bool Delete(int id);
    }
}
