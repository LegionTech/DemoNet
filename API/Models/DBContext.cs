using Microsoft.EntityFrameworkCore;

namespace API.Models
{
  public class DBContext: DbContext
  {
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    { 
    
    
    }

    public DbSet<Music> Musics { get; set; } = null!;
    //public DbSet<Movie> Movies { get; set; } = null!;

  }
}
