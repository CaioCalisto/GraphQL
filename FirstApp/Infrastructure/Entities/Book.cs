using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Infrastructure.Entities;

[Table("book")]
public class Book
{
    [Column("id")]
    public int Id { get; set; }

    [Column(name: "title", TypeName = "varchar(250)")]
    [Required]
    public string Title { get; set; }

    [Column("published_date", TypeName = "DATE")]
    [Required]
    public DateOnly PublishedDate { get; set; }

    [Column("author_id")]
    [ForeignKey("author_id")]
    [Required]
    public int AuthorId { get; set; }

    public Author Author { get; set; }

    internal static Book Generate(string title, DateOnly publishedDate, int authorId)
    {
        return new()
        {
            Title = title,
            PublishedDate = publishedDate,
            AuthorId = authorId,
        };
    }
    internal static Book Generate(int id, string title, DateOnly publishedDate, int authorId)
    {
        return new()
        {
            Id = id,
            Title = title,
            PublishedDate = publishedDate,
            AuthorId = authorId,
        };
    }
}