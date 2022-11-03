namespace RgpWeb.Models
{
    public class OwnerPropertyViewModel
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public IEnumerable<Property> Properties { get; set; }
    }
}
