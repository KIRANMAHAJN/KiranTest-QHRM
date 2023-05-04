using KiranTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KiranTest.Service
{
    public class Emp:IEmp
    {
        //GetEmployee

        private readonly KiranTestContext _kiranTestContext;

        public Emp(KiranTestContext kiranTestContext)
        {
            _kiranTestContext = kiranTestContext;
        }
        
        public async Task<IEnumerable<TblEmployee>> GetEmp()
        {

            var Emplist = await _kiranTestContext.TblEmployee.ToListAsync();
            return Emplist;
        }
        //AddEmployee
        public async Task<TblEmployee> SaveEmp(TblEmployee Emp)
        {
            _kiranTestContext.TblEmployee.Add(Emp);
            await _kiranTestContext.SaveChangesAsync();
            return Emp;
        }

        //DeleteEmployee
        public async Task<TblEmployee> DeleteEmp(int ProductId)
        {
            var result = await _kiranTestContext.TblEmployee.FirstOrDefaultAsync(x => x.ProductId == ProductId);
            if (result == null)
            {
                return null;
            }
            _kiranTestContext.TblEmployee.Remove(result);
            await _kiranTestContext.SaveChangesAsync();
            return result;
        }

        //UpdateEmployee

        public async Task<TblEmployee> UpdateEmp(TblEmployee Emp)
        {
            _kiranTestContext.Entry(Emp).State = EntityState.Modified;
            await _kiranTestContext.SaveChangesAsync();
            return Emp;
        }

        //public Task<TblEmployee> AddEmp(TblEmployee Emp)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
