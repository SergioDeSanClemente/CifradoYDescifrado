using Microsoft.EntityFrameworkCore;
using SegundoPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoPost.Data {
    public class UsersContext: DbContext {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
