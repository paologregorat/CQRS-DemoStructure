using CQRSSAmple.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace CQRSSAmple.Domain.Infrasctructure
{
    public class EntityContext: DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
            
        }
        
        public virtual DbSet<EntityOne> EntitiesOne { get; set; } = null!;
        public virtual DbSet<EntityTwo> EntitiesTwo { get; set; } = null!;
        
        public virtual DbSet<Operatore> Operatori { get; set; } = null!;
    }
}