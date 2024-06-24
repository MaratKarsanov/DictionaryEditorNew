using System.ComponentModel.DataAnnotations;

namespace DictionaryEditorNew.Models
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
    }
}
