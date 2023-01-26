using Microsoft.EntityFrameworkCore;
using Resilia.Academy.Api.Entities;

namespace Resilia.Academy.Api.DataAccess
{
    /// <summary>
    /// DB context used for the API database.
    /// </summary>
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Represents the entries into the database.
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }
   
    }
}
