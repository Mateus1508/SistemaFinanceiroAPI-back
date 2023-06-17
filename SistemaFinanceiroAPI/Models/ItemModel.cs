using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace SistemaFinanceiroAPI.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório!")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório!")]
        public int Value { get; set; }
        
        [Required(ErrorMessage = "A data é obrigatória!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Date { get; set; }
        
        [Required(ErrorMessage = "A categoria deve ser informada!")]
        public int CategoryId { get; set; }
        
        [JsonIgnore]
        public CategoryModel? Categories { get; set; }

    }
}
