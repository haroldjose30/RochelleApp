namespace RochelleShared.Models
{
    public class EntityBase
    {
        public string Id { get; set; }
        public string InsertedDate { get; set; }
        public string InsertedUser { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public string DeletedDate { get; set; }
        public string DeletedUser { get; set; }
    }
}