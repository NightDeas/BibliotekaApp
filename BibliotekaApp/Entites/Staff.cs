using System;
using System.Collections.Generic;

namespace BibliotekaApp.Entites;

public partial class Staff
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Address { get; set; } = null!;

    public string? Phone { get; set; }

    public string Passport { get; set; } = null!;

    public int PostId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual ICollection<TakenBook> TakenBooks { get; set; } = new List<TakenBook>();
}
