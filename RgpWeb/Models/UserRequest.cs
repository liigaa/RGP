namespace RgpWeb.Models
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public float LandArea { get; set; }

        public UserRequest(int id, string userName, float landArea)
        {
            Id = id;
            UserName = userName;
            LandArea = landArea;
        }
    }
}
