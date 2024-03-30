using System;
using System.Collections.Generic;

namespace test.Entities;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Note { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
