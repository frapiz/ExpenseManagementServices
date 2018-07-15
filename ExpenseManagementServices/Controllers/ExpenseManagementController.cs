using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagementServices.BL;
using ExpenseManagementShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseManagementController : ControllerBase
    {
        IExpenseManagementBS expenseManagement = new ExpenseManagementBS();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseDto>> Get()
        {
            return expenseManagement
                    .GetExpenses()
                    .ToList();
        }


        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] string ExpenseDto)
        {

        }

    }
}