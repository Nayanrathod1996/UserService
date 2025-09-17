using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data;

public partial class UserServiceContext : DbContext
{
    public UserServiceContext()
    {
    }

    public UserServiceContext(DbContextOptions<UserServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FirstName).HasColumnName("First_Name");
            entity.Property(e => e.LastName).HasColumnName("Last_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
