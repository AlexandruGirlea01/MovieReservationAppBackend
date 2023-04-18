using AppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public DbSet<Projection> Projections => Set<Projection>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Reservation> Reservations => Set<Reservation>();
}