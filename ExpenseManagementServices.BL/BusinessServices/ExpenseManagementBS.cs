using ExpenseManagementServices.BL.Model;
using ExpenseManagementShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManagementServices.BL
{
    public class ExpenseManagementBS : IExpenseManagementBS
    {
        public IEnumerable<ExpenseDto> GetExpenses()
        {
            using (var ctx = new ExpenseManagementContext())
            {
                return ctx.WExpense
                      .Select(e => new ExpenseDto()
                      {
                          SrgKey = e.SrgKey,
                          DtExpense = e.DtExpense,
                          TypeExpense = e.TypeExpenseSrgKeyNavigation.Desc,
                          Desc = e.Desc
                      })
                      .ToList();
            }
        }
    }
}
