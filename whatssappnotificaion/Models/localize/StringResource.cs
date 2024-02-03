using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace whatssappnotificaion.Models.localize
{
    public class StringResource
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Language))]
        public int LangaugeId { get; set; }
        public string key { get; set; }
        public string Value { get; set; }
        public virtual Language Language { get; set; }
    }
}
