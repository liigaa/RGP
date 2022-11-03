namespace RgpWeb.Models
{
    public class OwnerRequestModel
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public double LandArea { get; set; }

        public OwnerRequestModel(int id, string ownerName, double landArea)
        {
            Id = id;
            OwnerName = ownerName;
            LandArea = landArea;
        }
    }
}
