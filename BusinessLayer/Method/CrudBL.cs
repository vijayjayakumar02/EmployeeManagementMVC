using BusinessLayer.Interface;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Method
{
    public class CrudBL : ICrudBL
    {
        private readonly ICrudBL _crudBL;
        public CrudBL(ICrudBL crudBL)
        {
            this._crudBL = crudBL;
        }
        public void Create(Employee employee)
        {
            try
            {
                _crudBL.Create(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
