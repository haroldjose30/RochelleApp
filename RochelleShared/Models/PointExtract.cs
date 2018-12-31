using System;
namespace RochelleShared.Models
{
    public class PointExtract:EntityBaseCompany
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string History { get; set; }
        public Customer Customer { get; set; }
        public string Document { get; set; }
        public PointExtractType PointExtractType { get; set; }
        public DateTime? Expiration { get; set; }
    }

    public enum PointExtractType
    {
        Automatic,
        Manual
    }
}
