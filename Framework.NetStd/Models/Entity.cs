namespace Framework.NetStd.Models
{
    public class Entity
    {
        public Entity()
        {
            Id = string.Empty;
            CreatedDate = string.Empty;
            CreatedBy = string.Empty;
            ModifiedDate = string.Empty;
            ModifiedBy = string.Empty;
            Deleted = false;
        }

        public string Id { get; set; } 
        public string CreatedDate { get; set; } 
        public string CreatedBy { get; set; } 
        public string ModifiedDate { get; set; } 
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; } 
    }
}