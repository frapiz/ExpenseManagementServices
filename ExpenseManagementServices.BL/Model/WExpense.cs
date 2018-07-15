using System;
using System.Collections.Generic;

namespace ExpenseManagementServices.BL.Model
{
    public partial class WExpense
    {
        public long SrgKey { get; set; }
        public long TypeExpenseSrgKey { get; set; }
        public DateTime DtExpense { get; set; }
        public string Desc { get; set; }

        public SysTypeExpenses TypeExpenseSrgKeyNavigation { get; set; }
    }
}
