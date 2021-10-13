using Microsoft.EntityFrameworkCore;
using System;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Data
{
    public class UnivercityDbContext : DbContext
    {
        public virtual DbSet<Ins> Instructor { get; set; }
    }
}
