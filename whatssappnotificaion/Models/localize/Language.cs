namespace whatssappnotificaion.Models.localize
{
    public class Language
    {
        public Language()
        {
            stringResources = new HashSet<StringResource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public ICollection<StringResource> stringResources { get; set; }

    }
}
