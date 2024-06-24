using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDbNew.Models
{

    public class ForeignWord
    {
        public Guid Id { get; set; }
        public string? Word { get; set; }
        public Dictionary Dictionary {  get; set; }
        public List<RussianWord> RussianWords { get; set; } = new List<RussianWord>();
        public List<Example> Examples { get; set; } = new List<Example>();

    }
}
