
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using KiranTest.Models;

namespace KiranTest.Service
{
    public interface IEmp
    {
        Task<IEnumerable<TblEmployee>> GetEmp();
        Task<TblEmployee> SaveEmp(TblEmployee Emp);
        Task<TblEmployee> DeleteEmp(int ProductId);
        Task<TblEmployee> UpdateEmp(TblEmployee reg);



    }
}
