using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.Linq;
using DictionaryEditorDbNew.Models;

namespace DictionaryEditorDbNew
{

    public class DatabaseContext : DbContext
    {
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<ForeignWord> ForeignWords { get; set; }
        public DbSet<RussianWord> RussianWords { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<Cases> Cases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

       
    }
}
