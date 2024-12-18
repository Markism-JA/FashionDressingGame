using Microsoft.EntityFrameworkCore;

namespace FashionDressingGame.Database;

public class FashionGameDbContext : DbContext
{
    public DbSet<ECharacter?> Characters { get; set; }
    public DbSet<EAppearance> Appearances { get; set; }
    public DbSet<ETop> Tops { get; set; }
    public DbSet<EBottom> Bottoms { get; set; }
    public DbSet<EOuterWear> OuterWears { get; set; }
    public DbSet<EJewelry> Jewelries { get; set; }
    public DbSet<EClothing> Clothings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql("server=localhost;database=FashionGameDb;user=root;password=12345678910",
                new MySqlServerVersion(new Version(8, 0, 23)));
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ECharacter - Appearance relationship with cascade delete
        modelBuilder.Entity<ECharacter>()
            .HasOne(c => c.Appearance)
            .WithMany()  // Removed reverse navigation
            .HasForeignKey(c => c.AppearanceID)
            .OnDelete(DeleteBehavior.Cascade);

        // ECharacter - Clothing relationship with cascade delete
        modelBuilder.Entity<ECharacter>()
            .HasOne(c => c.Clothing)
            .WithMany()  // Removed reverse navigation
            .HasForeignKey(c => c.ClothingID)
            .OnDelete(DeleteBehavior.Cascade);
        
        // EClothing - Top relationship
        modelBuilder.Entity<EClothing>()
            .HasOne(c => c.Top)
            .WithMany()  // Removed reverse navigation
            .HasForeignKey(c => c.TopId);

        // EClothing - Bottom relationship
        modelBuilder.Entity<EClothing>()
            .HasOne(c => c.Bottom)
            .WithMany()  // Removed reverse navigation
            .HasForeignKey(c => c.BottomId);

        // EClothing - OuterWear relationship
        modelBuilder.Entity<EClothing>()
            .HasOne(c => c.OuterWear)
            .WithMany()  // Removed reverse navigation
            .HasForeignKey(c => c.OuterWearId);

        // EClothing - Jewelry relationship
        modelBuilder.Entity<EClothing>()
            .HasOne(c => c.Jewelry)
            .WithMany()  // Removed reverse navigation
            .HasForeignKey(c => c.JewelryId);

        modelBuilder.Entity<ECharacter>()
            .HasIndex(c => c.AppearanceID)
            .HasDatabaseName("IX_ECharacter_Appearance");

        modelBuilder.Entity<ECharacter>()
            .HasIndex(c => c.ClothingID)
            .HasDatabaseName("IX_ECharacter_Clothing");

        modelBuilder.Entity<EClothing>()
            .HasIndex(c => c.TopId)
            .HasDatabaseName("IX_EClothing_Top");

        modelBuilder.Entity<EClothing>()
            .HasIndex(c => c.BottomId)
            .HasDatabaseName("IX_EClothing_Bottom");

        modelBuilder.Entity<EClothing>()
            .HasIndex(c => c.OuterWearId)
            .HasDatabaseName("IX_EClothing_OuterWear");

        modelBuilder.Entity<EClothing>()
            .HasIndex(c => c.JewelryId)
            .HasDatabaseName("IX_EClothing_Jewelry");
    }
}

//dotnet ef migrations add InitialCreate
// dotnet ef database update