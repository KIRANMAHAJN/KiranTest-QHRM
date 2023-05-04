using KiranTest.Models;
using KiranTest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KiranTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : Controller
    {
        private readonly IEmp _IEmp;
        public EmpController(IEmp Emp)
        {
            _IEmp = Emp;    
        }
        //GetEmployee
        [HttpGet]
        public async Task<IActionResult> GetEmpList()
        {
            var result = await _IEmp.GetEmp();
            return Ok(result);
        }

        //AddEmployee
        [HttpPost]
        public async Task<IActionResult> saveEmp(TblEmployee Emp)
        {
            try
            {
                var result = await _IEmp.SaveEmp(Emp);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data form the server");
            }

        }

        //DeleteEmployee
        [HttpDelete("{ProductId}")]
        //Delete//
        public async Task<IActionResult> DeleteEmp(int ProductId)
        {
            try
            {
                var result = await _IEmp.DeleteEmp(ProductId);
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Enter delete from the server");
            }
        }

        //UpdateEmployee
        [HttpGet("{ProductId}")]
        [HttpPut]
        [Route("Emp")]
        public async Task<IActionResult> UpdateEmp(TblEmployee Emp)
        {
            try
            {
                await _IEmp.UpdateEmp(Emp);
                return Ok("Update Successfully");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreving data form the server");
            }
        }
    }
}
