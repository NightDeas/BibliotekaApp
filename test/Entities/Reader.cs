using System;
using System.Collections.Generic;

namespace test.Entities;

public partial class Reader
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int GenderId { get; set; }

    public string Address { get; set; } = null!;

    public string? Phone { get; set; }

    public string Passport { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<TakenBook> TakenBooks { get; set; } = new List<TakenBook>();
}
