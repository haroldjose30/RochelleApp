namespace RochelleShared.Models
{
    public class StoreOrderItem:EntityBaseCompany
    {
        public StoreProduct Product { get; set; }
        public double Quantity { get; set; }
        public double ValuePoint { get; set; }
    }
}