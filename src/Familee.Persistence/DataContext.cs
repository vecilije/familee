using Familee.Application.Persistence;
using Familee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Familee.Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<FamilyMember> FamilyMembers { get; set; }
    }
}