using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace dotnetwebapiproject.Models;

public class CustomerDbContext : DbContext
{

    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
        // try
        // {
        //     var dbCreator= Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        //     if(dbCreator != null)
        //     {
        //         if(!dbCreator.CanConnect())dbCreator.Create();
        //         if(!dbCreator.HasTables())dbCreator.CreateTables();
        //     }

        // }
        // catch(Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }
public DbSet<Customer> Customers {get; set;}
}