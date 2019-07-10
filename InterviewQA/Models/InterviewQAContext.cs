using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQAApi.Models
{
    public class InterviewQAContext : DbContext
    {
        public InterviewQAContext(DbContextOptions<InterviewQAContext> options) :base(options)
        {

        }

        public DbSet<InterviewQA> InterviewQAs { get; set; }
    }
}
