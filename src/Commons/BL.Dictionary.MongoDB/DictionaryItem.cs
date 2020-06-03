
namespace BL.Dictionary
{
    public class DictionaryItemKV
    {

        public string K { get; set; }
        public string V { get; set; }
    }
    public class DictionaryItem : DictionaryItemKV
    {
        public DictionaryItem()
        {

        }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Order { get; set; }
        public string Desc { get; set; }
    }
}
