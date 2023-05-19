using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace SistemaFinanceiroAPI.Models
{
    public class CategoryModel
    {

        public CategoryModel()
        {
            Items = new Collection<ItemModel>();
        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Color { get; set; }
        public bool? Expense { get; set; }

        public ICollection<ItemModel>? Items { get; set; }
    }
}
