using System;
using System.Collections.Generic;

namespace test.Entities;

public partial class TakenBook
{
    public int BookId { get; set; }

    public int BookReaderId { get; set; }

    public DateTime DateOfGet { get; set; }

    public DateTime? DateOfBack { get; set; }

    public bool IsBack { get; set; }

    public int StaffId { get; set; }

    public int Id { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Reader BookReader { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
