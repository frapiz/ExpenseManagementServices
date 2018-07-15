using ExpenseManagementShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManagementServices.BL
{
    public interface IExpenseManagementBS
    {
        IEnumerable<ExpenseDto> GetExpenses();
    }
}
