namespace RgpWeb.Models
{
    public class UnitViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public IEnumerable<UnitListModel> UnitList { get; set; }
    }
}
