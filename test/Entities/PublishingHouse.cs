using System;
using System.Collections.Generic;

namespace test.Entities;

public partial class PublishingHouse : IName
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Town { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
