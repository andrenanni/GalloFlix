using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NanniFlix.Models;
using Microsoft.AspNetCore.Identity;

namespace NanniFlix.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Configuração do Muitos para muitos do MovieGenre
        builder.Entity<MovieGenre>().HasKey(
            mg => new { mg.MovieId, mg.GenreId }
        );
        builder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.Genres)
            .HasForeignKey(mg => mg.MovieId);

        builder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(mg => mg.GenreId);
        #endregion

        #region Polular usuário
            List<IdentityRole> roles = new(){
                new IdentityRole(){
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole(){
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuário",
                    NormalizedName = "USUÁRIO"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles); 

            List<IdentityUser> users = new(){
                new IdentityUser(){
                    Id = Guid.NewGuid().ToString(),
                    Email = "admin@nanniflix.com",
                    NormalizedEmail = "ADMIN@NANNIFLIX.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    LockoutEnabled = false,
                    EmailConfirmed = true
                },
                new IdentityUser(){
                    Id = Guid.NewGuid().ToString(),
                    Email = "user@hotmail.com",
                    NormalizedEmail = "USER@HOTMAIL.COM",
                    UserName = "User",
                    NormalizedUserName = "USER",
                    LockoutEnabled = true,
                    EmailConfirmed = true
                }
            };
            foreach (var user in users)
            {   
                PasswordHasher<IdentityUser> pass = new();
                user.PasswordHash = pass.HashPassword(user, "@adminadmin");
            }
            builder.Entity<IdentityUser>().HasData(users);

            List<AppUser> appUsers = new(){
                new AppUser{
                    AppUserId = users[0].Id,
                    Name = "André Nanni",
                    Birthday = DateTime.Parse("08/05/1998"),
                    Photo = ""
                },
                new AppUser{
                    AppUserId = users[1].Id,
                    Name = "Visitante",
                    Birthday = DateTime.Parse("05/10/2008"),
                    Photo = ""
                },
            };
            builder.Entity<AppUser>().HasData(appUsers);

            List<IdentityUserRole<string>> userRoles = new(){
                new IdentityUserRole<string>(){
                    UserId = users[0].Id,
                    RoleId = roles[0].Id
                },
                new IdentityUserRole<string>(){
                    UserId = users[0].Id,
                    RoleId = roles[1].Id
                },
                new IdentityUserRole<string>(){
                    UserId = users[1].Id,
                    RoleId = roles[1].Id
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}