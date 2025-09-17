using System;
using System.Collections.Generic;

namespace UserService.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
