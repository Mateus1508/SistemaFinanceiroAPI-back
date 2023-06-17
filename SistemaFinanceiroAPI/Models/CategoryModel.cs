using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "O título é obrigatório.")]
        public string? Title { get; set; }
        
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string? Color { get; set; }
        
        [Required(ErrorMessage = "O título é obrigatório.")]
        public bool? Expense { get; set; }

        [JsonIgnore]
        public ICollection<ItemModel>? Items { get; set; }
    }
}
