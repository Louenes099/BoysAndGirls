using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoysAndGirls8.Areas.Boy.Models;
using BoysAndGirls8.Areas.Teacher.Models;

namespace BoysAndGirls8.Data
{
    public class BoysAndGirls8Context : DbContext
    {
        public BoysAndGirls8Context (DbContextOptions<BoysAndGirls8Context> options)
            : base(options)
        {
        }

        public DbSet<BoysAndGirls8.Areas.Boy.Models.BoyTask> BoyTasks { get; set; }

        public DbSet<BoysAndGirls8.Areas.Teacher.Models.TeacherTask> TeacherTasks { get; set; }
    }
}
