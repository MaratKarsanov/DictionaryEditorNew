using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDbNew.Models
{
    public class RussianWord
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public List<ForeignWord> ForeignWords { get; set; } 
    }
}
