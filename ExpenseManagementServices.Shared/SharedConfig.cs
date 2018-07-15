using Microsoft.Extensions.Configuration;
using System;

namespace ExpenseManagementServices.Shared
{
    public static class SharedConfig
    {
        public static IConfiguration Configuration { get; set; }
    }
}
