using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Framework.NetStd.Models
{



    public class Entity
    {



        [JsonProperty]
        public string Id { get; private set; } = string.Empty;
        [JsonProperty]
        public string CreatedDate { get; private set; } = string.Empty;
        [JsonProperty]
        public string CreatedBy { get; private set; } = string.Empty;
        [JsonProperty]
        public string ModifiedDate { get; private set; } = string.Empty;
        [JsonProperty]
        public string ModifiedBy { get; private set; } = string.Empty;
        [JsonProperty]
        public bool Deleted { get; private set; } = false;

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
            var cDateId =  DateTime.Now.ToUniversalTime().ToString("yyMMddHHmmssfff");
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
                if (property.PropertyType.BaseType == typeof(Entity))
                {
                    Console.WriteLine($"EntityBase={property.Name}=null");
                    property.SetValue(this, null);
                    continue;
                }

                if (property.PropertyType.BaseType.Name.Equals("EntityWithCompany"))
                //if (property.PropertyType.BaseType == typeof(EntityWithCompany))
                {
                    Console.WriteLine($"EntityBaseCompany={property.Name}=null");
                    property.SetValue(this, null);
                    continue;
                }


                if (property.PropertyType.Namespace.Equals("System.Collections.Generic"))
                {
                    Console.WriteLine($"System.Collections.Generic={property.Name}=null");
                    property.SetValue(this, null);
                    continue;
                }
            }


        }


    }
}