using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
  [Table("Music")]
  public class Music
  {
    [Column("Id")]
    public int Id { get; set; }

    [Column("Title")]
    public string Title { get; set; }

    [Column("Artist")]
    public string Artist { get; set; }
  }
}
