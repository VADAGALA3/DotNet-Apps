using CRUD_COREAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD_COREAPI.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<Employee> Employees
        {
            get;
            set;
        }

    }
}
