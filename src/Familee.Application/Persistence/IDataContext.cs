using System.Threading;
using System.Threading.Tasks;
using Familee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Familee.Application.Persistence
{
    public interface IDataContext
    { 
        DbSet<FamilyMember> FamilyMembers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}