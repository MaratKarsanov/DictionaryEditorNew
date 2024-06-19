using System.ComponentModel.DataAnnotations;

namespace DictionaryEditorNew.Areas.Admin.Models
{
    public class EditUserDataViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }
    }
}
