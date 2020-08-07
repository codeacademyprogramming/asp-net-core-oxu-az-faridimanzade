using Microsoft.EntityFrameworkCore;
using Oxu.az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oxu.az.Contexts
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> dbContext)
            :base(dbContext)
        {
        }

        public DbSet<News> News { get; set; }
    }
}
