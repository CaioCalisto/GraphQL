using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Infrastructure.Entities;

[Table("author")]
public class Author
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name", TypeName = "varchar(200)")]
    [Required]
    public string Name { get; set; }

    [Column("born_date", TypeName = "DATE")]
    [Required]
    public DateOnly BornDate { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();

    internal static Author Generate(string name, DateOnly bornDate)
    {
        return new ()
        {
            Name = name,
            BornDate = bornDate
        };
    }

    internal static Author Generate(int id, string name, DateOnly bornDate)
    {
        return new ()
        {
            Id = id,
            Name = name,
            BornDate = bornDate
        };
    }
}