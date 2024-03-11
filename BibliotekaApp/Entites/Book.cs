using System;
using System.Collections.Generic;

namespace BibliotekaApp.Entites;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AuthorId { get; set; }

    public int PublisherId { get; set; }

    public int YearOfPublication { get; set; }

    public int GenreId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual PublishingHouse Publisher { get; set; } = null!;

    public virtual ICollection<TakenBook> TakenBooks { get; set; } = new List<TakenBook>();
}
