using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        { 

        }
        public Microsoft.EntityFrameworkCore.DbSet<TransferLog> TransferLogs { get; set; }
    }
}
