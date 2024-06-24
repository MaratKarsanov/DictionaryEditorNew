namespace DictionaryEditorDbNew.Models
{
    public class ForeignWordsRussianWords
    {
        public ForeignWord ForeignWord { get; set; }
        public Guid ForeignWordId { get; set; }
        public RussianWord RussianWord { get; set; }
        public Guid RussianWordId { get; set; }
    }
}
