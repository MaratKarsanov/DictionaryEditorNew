using DictionaryEditorDbNew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDbNew.Repositories
{
    public class OssetianWordsDbRepository
    {
        private readonly DatabaseContext databaseContext;
        public OssetianWordsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<ForeignWord> GetWords()
        {
            //List < OssetianWord > words = new List < OssetianWord >();
            var first500Words = databaseContext.ForeignWords.Include(x => x.Examples).Include(x => x.RussianWords)
                                       .Take(100)
                                       .OrderBy(w => w.Word) // Опционально, сортировка по Id или другому полю
                                       .ToList();
            return first500Words;

        }
        public ForeignWord TryGetById(Guid id)
        {
            return databaseContext.ForeignWords.Include(x => x.Examples).Include(x => x.RussianWords).FirstOrDefault(x => x.Id == id);
        }


        public void AddWord(ForeignWord word)
        {
            databaseContext.ForeignWords.Add(word);
            databaseContext.SaveChanges();
        }
    }
}
