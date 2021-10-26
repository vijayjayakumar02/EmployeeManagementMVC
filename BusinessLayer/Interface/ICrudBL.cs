using BusinessLayer.Model;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface ICrudBL
    {
        IEnumerable<Employee> GetAll();


        Employee Get(int id);

        void Create(Employee employee);

        void Update(Employee employee);

        bool Delete(int id);
    }
}
