using CrushOn.Core.Entities;
using Microsoft.EntityFrameworkCore;

public class CrushOnContext : DbContext
{
    public CrushOnContext(DbContextOptions<CrushOnContext> options) : base(options) { }

    public DbSet<SellerModel> Sellers { get; set; }
}