using System;
using System.Collections.Generic;

namespace test.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Duties { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
