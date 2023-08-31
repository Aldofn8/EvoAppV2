namespace EvoApp.Models
{
    public class Details
    {
        public int id { get; set; }
        public int ContractId { get; set; }
        public int ArticleId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? UpdateDate { get; set; }
        public int Enabled { get; set; }
        public int Deleted { get; set; }
        public string? CreatedBy { get; set; }
    }
}
