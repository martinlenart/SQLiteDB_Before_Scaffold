using System;
using Microsoft.EntityFrameworkCore;

namespace NorthwindDbLibrary
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        { }
    }
}
