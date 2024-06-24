using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DictionaryEditorDbNew.Models;
using System.Collections.Generic;

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
        //public DbSet<ForeignWordsRussianWords> ForeignWordsRussianWords { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Example>()
        //       .HasOne(e => e.ForeignWord)
        //       .WithMany(fw => fw.Examples)
        //       .HasForeignKey(e => e.ForeignWordId);

        //    modelBuilder.Entity<ForeignWord>()
        //        .HasOne(fw => fw.Dictionary)
        //        .WithMany(d => d.ForeignWords)
        //        .HasForeignKey(fw => fw.DictionaryId);

        //    //modelBuilder.Entity<RussianWord>()
        //    //    .HasMany(rw => rw.ForeignWords)
        //    //    .WithMany(fw => fw.RussianWords)
        //    //    .UsingEntity<Dictionary<string, object>>(
        //    //        "RussianWordForeignWord",
        //    //        j => j.HasOne<ForeignWord>().WithMany().HasForeignKey("ForeignWordId"),
        //    //        j => j.HasOne<RussianWord>().WithMany().HasForeignKey("RussianWordId"));

        //    var reader = new StreamReader("C:\\Users\\79187\\source\\repos\\DictionaryEditorNew4\\DictionaryEditorNew\\wwwroot\\json\\json.json");
        //    var res = JsonConvert.DeserializeObject<List<Word>>(reader.ReadToEnd());
        //    var newDict = new Dictionary() { Id = Guid.NewGuid(), Name = "Осетино-русский" };
        //    var fWords = new List<ForeignWord>();
        //    var rWords = new List<RussianWord>();
        //    var examples = new List<Example>();
        //    modelBuilder.Entity<Dictionary>().HasData(newDict);
        //    //var russianWordForeignWord = new List<Dictionary<string, object>>();
        //    foreach (var word in res)
        //    {
        //        var ossetianWord = new ForeignWord()
        //        {
        //            Id = Guid.NewGuid(),
        //            Word = word.OssetianWord,
        //            DictionaryId = newDict.Id,
        //        };
        //        fWords.Add(ossetianWord);
        //        foreach (var meaning in word.Meanings)
        //        {
        //            foreach (var translation in meaning.Translations)
        //            {
        //                var existingRussianWord = rWords.FirstOrDefault(rw => rw.Word == translation);
        //                if (existingRussianWord != null)
        //                {
        //                    existingRussianWord.ForeignWords.Add(ossetianWord);
        //                    ossetianWord.RussianWords.Add(existingRussianWord);
        //                    //russianWordForeignWord.Add(new Dictionary<string, object>() 
        //                    //{
        //                    //    { "RussianWordId", existingRussianWord.Id }, { "ForeignWordId", ossetianWord.Id }
        //                    //});
        //                }
        //                else
        //                {
        //                    var newRussianWord = new RussianWord()
        //                    {
        //                        Id = Guid.NewGuid(),
        //                        Word = translation,
        //                        ForeignWords = new List<ForeignWord>()
        //                        {
        //                            ossetianWord
        //                        },
        //                    };
        //                    ossetianWord.RussianWords.Add(newRussianWord);
        //                    //russianWordForeignWord.Add(new Dictionary<string, object>()
        //                    //{
        //                    //    { "RussianWordId", newRussianWord.Id }, { "ForeignWordId", ossetianWord.Id }
        //                    //});
        //                    rWords.Add(newRussianWord);
        //                }
        //            }
        //            foreach (var example in meaning.Examples)
        //            {
        //                var newExample = new Example()
        //                {
        //                    Id = Guid.NewGuid(),
        //                    Sentence = example.Item1,
        //                    Translation = example.Item2,
        //                    //ForeignWord = ossetianWord,
        //                    ForeignWordId = ossetianWord.Id
        //                };
        //                examples.Add(newExample);
        //            }
        //        }
        //    }
        //    modelBuilder.Entity<Example>().HasData(examples);
        //    modelBuilder.Entity<ForeignWord>().HasData(fWords);
        //    modelBuilder.Entity<RussianWord>().HasData(rWords);
        //    //modelBuilder.Entity<Dictionary<string, object>>().HasData(russianWordForeignWord);

        //    modelBuilder.Entity<ForeignWord>(b =>
        //    {
        //        b.HasMany(fw => fw.RussianWords)
        //        .WithMany(rw => rw.ForeignWords)
        //        .UsingEntity<ForeignWordsRussianWords>(
        //            russianWord => russianWord.HasOne(rw => rw.RussianWord)
        //                .WithMany(rw => rw.ForeignWordsRussianWords)
        //                .HasForeignKey(rw => rw.RussianWordId),
        //            foreignWord => foreignWord.HasOne(rw => rw.ForeignWord)
        //                .WithMany(fw => fw.ForeignWordsRussianWords)
        //                .HasForeignKey(rw => rw.ForeignWordId)
        //        );
        //        b.HasData(rWords);
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
