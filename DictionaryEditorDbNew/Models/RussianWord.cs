namespace DictionaryEditorDbNew.Models
{
    public class RussianWord
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public List<ForeignWord> ForeignWords { get; set; } 
        //public List<Guid> ForeignWordsId { get; set; }
        //public List<ForeignWordsRussianWords> ForeignWordsRussianWords { get; set; }
    }
}
