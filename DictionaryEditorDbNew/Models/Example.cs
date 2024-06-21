using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDbNew.Models
{
    public class Example
    {
        public Guid Id { get; set; }
        public string? Sentence { get; set; }    
        public string? Translation { get; set; }

        public ForeignWord ForeignWord { get; set; }

    }
}
