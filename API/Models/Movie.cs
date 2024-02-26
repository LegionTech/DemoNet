using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
  [Table("Movie")]
  public class Movie
  {
    [Column("Id")]
    public int Id { get; set; }

    [Column("Title")]
    public string Title { get; set; }

    [Column("Year")]
    public string Year { get; set; }
  }
}
