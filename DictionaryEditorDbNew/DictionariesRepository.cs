using DictionaryEditorDbNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDbNew
{
    public class DictionariesRepository
    {
        private readonly DatabaseContext databaseContext;
        public DictionariesRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void AddDict(Dictionary newDict)
        {
           // Dictionary newDict = new Dictionary() { Id = Guid.NewGuid(), Name = name };
            databaseContext.Dictionaries.Add(newDict);
            databaseContext.SaveChanges();
        }
    }
}
    