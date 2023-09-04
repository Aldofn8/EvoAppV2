namespace EvoApp.DTO
{
    public class MyArticleListDto
    {
        public int ArticleId { get; set; }
        public string? ArticleNombre { get; set; }
        public decimal? ArticlePrecio { get; set; }
        public int? DetailId { get; set; }
        public int? ContractId { get; set; }
        public DateTime? DetailCreateDate { get; set; }
        public bool? DetailUpdateDate { get; set; }
        public int? DetailEnabled { get; set; }
        public int? DetailDeleted { get; set; }
        public string? DetailCreatedBy { get; set; }
    }
}
