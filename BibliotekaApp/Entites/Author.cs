using System;
using System.Collections.Generic;

namespace BibliotekaApp.Entites;

public partial class Author
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public DateTime? DateOfDead { get; set; }

    public int GenderId { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Gender Gender { get; set; } = null!;
}
