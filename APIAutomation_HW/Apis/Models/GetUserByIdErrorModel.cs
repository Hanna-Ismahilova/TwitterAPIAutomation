namespace APIAutomation_HW.Apis.Models
{
    public class GetUserByIdErrorModel
    {
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Resource_type { get; set; }
        public string Resource_id { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}