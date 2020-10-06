using Dapper.Contrib.Extensions;
using FirmaTakip.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Repositories
{
    public class DpCompanyRepository
    {
        public List<Company> GelAll()
        {
            using var connection = new SqlConnection("server=DELL_PC\\SQLEXPRESS;database=FirmaTakipDb;integrated security=true;");
            return connection.GetAll<Company>().ToList();
        }
    }
}
