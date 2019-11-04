using System;
using System.Reflection;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Framework.Core.Models
{
    public abstract class Entity
    {
        
        [JsonProperty]
        public Guid Id { get; protected set; }
        [JsonProperty]
        public string CreatedDate { get; protected set; } 
        [JsonProperty]
        public string CreatedBy { get; protected set; }
        [JsonProperty]
        public string ModifiedDate { get; protected set; }
        [JsonProperty]
        public string ModifiedBy { get; protected set; }
        [JsonProperty]
        public bool Deleted { get; protected set; } 
       
        
        protected ValidationResult ValidationResult { get; set; } = new ValidationResult();

        
        
        public Entity()
        {

        }
        
        public ValidationResult GetValidationResult()
        {
            return ValidationResult;
        }
        
        
        
        protected internal virtual bool Create(string by,Guid id = default)
        {
            this.CreatedDate =  GetDateTimeStr();
            this.ModifiedDate = this.CreatedDate;
            this.Deleted = false;
            this.CreatedBy = by;
            this.ModifiedDate = CreatedDate;
            this.ModifiedBy = by;

            //if id is empty, get new id automaticaly
            if (id == default)
                id = Guid.NewGuid();

            this.Id = id;


            return true;

        }


        protected internal virtual bool Update(string by)
        {

            if (this.Deleted)
            {
                string cMsg = "nao é permitido alterar um registro deletado";
                ValidationResult.Errors.Add(new ValidationFailure("Entity.Update", cMsg));
                return false;
                //throw new Exception(cMsg);
            }

               

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = by;
            return true;
        }

        public virtual bool Delete(string by)
        {

            if (this.Deleted)
            {
                string cMsg = "nao é permitido excluir um registro já deletado";
                ValidationResult.Errors.Add(new ValidationFailure("Entity.Update", cMsg));
                return false;
                //throw new Exception(cMsg);
            }
        

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = by;
            this.Deleted = true;
            return true;
        }

        protected string GetDateTimeStr()
        {
            return DateTimeOffset.Now.ToUniversalTime().ToString("yyyyMMdd HH:mm:ss");
        }


        //remove all ForeingKey/EntityBase property from object, using reflexions
        public void RemoveEntityBaseProperty()
        {

            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();
            //var propertiesEntitybase = properties.Where(p => p.PropertyType?.BaseType == typeof(EntityBase));

            foreach (PropertyInfo property in properties)
            {
                    
                if (property.PropertyType.Namespace == null || property.PropertyType.BaseType == null)
                    continue;

                if (property.PropertyType.BaseType != typeof(Entity) &&
                    !property.PropertyType.BaseType.Name.Equals("EntityWithCompany") &&
                    !property.PropertyType.Namespace.Equals("System.Collections.Generic")) 
                    continue;
                
                EntityReflexion.SetPrivatePropertyValue<Entity>(this, property.Name, null);

            }
        }
    }
}