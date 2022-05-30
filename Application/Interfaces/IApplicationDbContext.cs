using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Property> Properties { get; set; }
        Task<int> SaveChangesAsync();
    }
}
