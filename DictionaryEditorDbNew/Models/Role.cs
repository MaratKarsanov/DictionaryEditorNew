using System.ComponentModel.DataAnnotations;

namespace DictionaryEditorDbNew.Models
{
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}