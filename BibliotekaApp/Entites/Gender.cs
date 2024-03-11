using System;
using System.Collections.Generic;

namespace BibliotekaApp.Entites;

public partial class Gender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Reader> Readers { get; set; } = new List<Reader>();
}
