using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace SistemaFinanceiroAPI.Models
{
    public class CategoryModel
    {

        public CategoryModel()
        {
            Items = new Collection<ItemModel>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Color { get; set; }
        public bool? Expense { get; set; }

        [JsonIgnore]
        public ICollection<ItemModel>? Items { get; set; }
    }
}
