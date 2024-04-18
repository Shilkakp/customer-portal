namespace customer_portal.Models
{
    public class Model
    {
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public string modelname { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
