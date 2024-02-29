using Microsoft.EntityFrameworkCore;
using SkyrimQuestLog.Models;
using System.IO.Pipelines;

namespace SkyrimQuestLog.Data
{
    public class SkyrimQuestLogDb : DbContext
    {
        public SkyrimQuestLogDb(DbContextOptions<SkyrimQuestLogDb> options)
        : base(options) { }

        public DbSet<Quest> Quests { get; set; }
    }
}
