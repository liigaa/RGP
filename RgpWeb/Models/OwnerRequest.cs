namespace RgpWeb.Models
{
    public class OwnerRequest
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public double LandArea { get; set; }

        public OwnerRequest(int id, string ownerName, double landArea)
        {
            Id = id;
            OwnerName = ownerName;
            LandArea = landArea;
        }
    }
}
