using System;
using System.Collections.Generic;

namespace ExpenseManagementServices.BL.Model
{
    public partial class SysTypeExpenses
    {
        public SysTypeExpenses()
        {
            WExpense = new HashSet<WExpense>();
        }

        public long SrgKey { get; set; }
        public string TypeExpense { get; set; }
        public string Desc { get; set; }

        public ICollection<WExpense> WExpense { get; set; }
    }
}
