using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Framework.NetStd.Models
{



    public class Entity
    {
        [JsonProperty]
        public string Id { get; protected set; } = string.Empty;
        [JsonProperty]
        public string CreatedDate { get; protected set; } = string.Empty;
        [JsonProperty]
        public string CreatedBy { get; protected set; } = string.Empty;
        [JsonProperty]
        public string ModifiedDate { get; protected set; } = string.Empty;
        [JsonProperty]
        public string ModifiedBy { get; protected set; } = string.Empty;
        [JsonProperty]
        public bool Deleted { get; protected set; } = false;

        public Entity(string id, string createdBy)
        {
            this.CreatedDate = GetDateTimeStr();
            this.CreatedBy = createdBy;
            this.ModifiedDate = CreatedDate;
            this.ModifiedBy = createdBy;
            this.Deleted = false;

            //if id is empyty, get new id automaticaly
            if (String.IsNullOrWhiteSpace(id))
                id = this.GetNewId();

            this.Id = id;

        }

        public virtual void Update(string cUser)
        {

            if (this.Deleted)
                throw new Exception("nao é permitido alterar um registro deletado");

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = cUser;
        }

        public virtual void Delete(string cUser)
        {

            if (this.Deleted)
                throw new Exception("nao é permitido excluir um registro já deletado");

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = cUser;
            this.Deleted = true;
        }

        protected virtual string GetNewId()
        {
            var cDateId = DateTime.Now.ToUniversalTime().ToString("yyMMddHHmmssfff");
            return cDateId + this.CreatedBy;
        }

        protected string GetDateTimeStr()
        {
            return DateTime.Now.ToUniversalTime().ToString("yyyyMMdd HH:mm:ss");
        }


        //remove all ForeingKey/EntityBase property from object, using reflexions
        public void RemoveEntityBaseProperty()
        {

            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();
            //var propertiesEntitybase = properties.Where(p => p.PropertyType?.BaseType == typeof(EntityBase));

            foreach (PropertyInfo property in properties)
            {
                if (
                        property.PropertyType.BaseType == typeof(Entity) ||
                        property.PropertyType.BaseType.Name.Equals("EntityWithCompany") ||
                        property.PropertyType.Namespace.Equals("System.Collections.Generic")
                    )
                {
                    EntityReflexion.SetPrivatePropertyValue<Entity>(this, property.Name, null);
                    continue;
                }

            }



        }



    }
}