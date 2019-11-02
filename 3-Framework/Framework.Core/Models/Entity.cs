using System;
using System.Reflection;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Framework.Core.Models
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
       
        
        protected ValidationResult _ValidationResult { get; set; } = new ValidationResult();

        public ValidationResult ValidationResult()
        {
            return _ValidationResult;
        }

        public virtual bool Create(string id, string createdBy, string createdDate)
        {
            if (string.IsNullOrWhiteSpace(createdDate))
                this.CreatedDate = GetDateTimeStr();
            else
                this.CreatedDate = createdDate;

                this.ModifiedDate = this.CreatedDate;
         
           
            this.Deleted = false;
            this.CreatedBy = createdBy;
            this.ModifiedDate = CreatedDate;
            this.ModifiedBy = createdBy;

            //if id is empyty, get new id automaticaly
            if (string.IsNullOrWhiteSpace(id))
                id = this.GetNewId();

            this.Id = id;


            return true;

        }

        public Entity()
        {

        }

        public virtual bool Update(string cUser)
        {

            if (this.Deleted)
            {
                string cMsg = "nao é permitido alterar um registro deletado";
                _ValidationResult.Errors.Add(new ValidationFailure("Entity.Update", cMsg));
                return false;
                //throw new Exception(cMsg);
            }

               

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = cUser;
            return true;
        }

        public virtual bool Delete(string cUser)
        {

            if (this.Deleted)
            {
                string cMsg = "nao é permitido excluir um registro já deletado";
                _ValidationResult.Errors.Add(new ValidationFailure("Entity.Update", cMsg));
                return false;
                //throw new Exception(cMsg);
            }
        

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = cUser;
            this.Deleted = true;
            return true;
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


    /*
    public class Entity
    {
        protected Entity(string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted)
        {
            Id = id;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ModifiedBy = modifiedBy;
            ModifiedDate = modifiedDate;
            Deleted = deleted;
            ValidationResult = new ValidationResult();

        }

        public ValidationResult ValidationResult { get; protected set; }


        public string Id { get; protected set; }

        public string CreatedBy { get; protected set; }
        public string CreatedDate { get; protected set; }

        public string ModifiedBy { get; protected set; }
        public string ModifiedDate { get; protected set; }
        public bool Deleted { get; protected set; } = false;

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


        public virtual void Update(string modifiedBy)
        {

            if (this.Deleted)
            {
                ValidationFailure oValidationFailure = new ValidationFailure("Deleted", "nao é permitido alterar um registro deletado.");
                ValidationResult.Errors.Add(oValidationFailure);
                return;
            }

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = modifiedBy;
        }

        public virtual void Delete(string deletedBy)
        {

            if (this.Deleted)
            {
                ValidationFailure oValidationFailure = new ValidationFailure("Deleted", "nao é permitido excluir um registro já deletado.");
                ValidationResult.Errors.Add(oValidationFailure);
                return;
            }

            this.ModifiedDate = GetDateTimeStr();
            this.ModifiedBy = deletedBy;
            this.Deleted = true;
        }

        #region Equinox

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

        #endregion
    }
    */

}