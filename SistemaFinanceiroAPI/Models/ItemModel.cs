namespace SistemaFinanceiroAPI.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel? Categories { get; set; }

    }
}
