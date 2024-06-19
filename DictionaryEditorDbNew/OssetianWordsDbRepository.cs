using DictionaryEditorDbNew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDbNew
{
    public class OssetianWordsDbRepository
    {
        private readonly DatabaseContext databaseContext;
        public OssetianWordsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<OssetianWord> GetWords()
        {
            //List < OssetianWord > words = new List < OssetianWord >();
            var first500Words = databaseContext.OssetianWords.Include(x => x.Examples).Include(x => x.RussianWords).Include(x => x.Cases)
                                       .OrderBy(w => w.Word) // Опционально, сортировка по Id или другому полю
                                       .Take(500)
                                       .ToList();
            return first500Words;

        }
        public OssetianWord TryGetById(Guid id)
        {
            return databaseContext.OssetianWords.Include(x => x.Examples).Include(x => x.Cases).Include(x => x.RussianWords).FirstOrDefault(x => x.Id == id);
        }
    

        public void AddWord(OssetianWord word)
        {
            databaseContext.OssetianWords.Add(word);
            databaseContext.SaveChanges();
        }
    }
}
