using System.ComponentModel.DataAnnotations;

namespace DictionaryEditorDbNew.Models
{
    public class Example
    {
        [Key]
        public Guid Id { get; set; }
        public string? Sentence { get; set; }    
        public string? Translation { get; set; }
        public Guid ForeignWordId { get; set; }
        public ForeignWord ForeignWord { get; set; }
    }
}
