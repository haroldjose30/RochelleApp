using System;
using System.Reflection;
using FluentValidation.Results;

namespace Domain.Core.Models
{

    public abstract class Entity
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

        public string Id
        {
            get { return this.Id; }
            protected set
            {
                //if id is empyty, get new id automaticaly
                if (String.IsNullOrWhiteSpace(value))
                    value = this.GetNewId();

                this.Id = value;

            }
        }

        public string CreatedBy { get; protected set; } = String.Empty;

        public string CreatedDate
        {
            get { return this.CreatedDate; }
            protected set
            {
                //if id is empyty, get new id automaticaly
                if (String.IsNullOrWhiteSpace(value))
                    value = this.GetDateTimeStr();

                this.Id = value;

            }
        }


        public string ModifiedBy { get; private set; } = String.Empty;

        public string ModifiedDate
        {
            get { return this.ModifiedDate; }
            private set
            {
                //if id is empyty, get new id automaticaly
                if (String.IsNullOrWhiteSpace(value))
                    value = this.GetDateTimeStr();

                this.Id = value;

            }
        }

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

    /*
    public class Entity
    {

        public bool IsValid { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate(AbstractValidator<Entity> validator)   
        {
            ValidationResult = validator.Validate(this);
            return IsValid = ValidationResult.IsValid;
        }



        //[JsonProperty]
        //public string Id { get; private set; } = string.Empty;

        [JsonProperty]
        public string Id
        {
            get { return this.Id; }
            private set 
            {
                //if id is empyty, get new id automaticaly
                if (String.IsNullOrWhiteSpace(value))
                    value = this.GetNewId();

                this.Id = value; 
            
            }
        }


        //[JsonProperty]
        //public string CreatedDate { get; private set; } = string.Empty;

        [JsonProperty]
        public string CreatedDate
        {
            get { return this.CreatedDate; }
            private set
            {
                //if id is empyty, get new id automaticaly
                if (String.IsNullOrWhiteSpace(value))
                    value = this.GetDateTimeStr();

                this.Id = value;

            }
        }


        //[JsonProperty]
        public string CreatedBy { get; private set; } = String.Empty;
        //[JsonProperty]
        //public string ModifiedDate { get; private set; } 

        [JsonProperty]
        public string ModifiedDate
        {
            get { return this.ModifiedDate; }
            private set
            {
                //if id is empyty, get new id automaticaly
                if (String.IsNullOrWhiteSpace(value))
                    value = this.GetDateTimeStr();

                this.Id = value;

            }
        }

        [JsonProperty]
        public string ModifiedBy { get; private set; } = String.Empty;

        [JsonProperty]
        public bool Deleted { get; private set; } = false;


        public Entity(string id, string createdBy)
        {
            this.CreatedDate = GetDateTimeStr();
            this.CreatedBy = createdBy;
            this.ModifiedDate = CreatedDate;
            this.ModifiedBy = createdBy;
            this.Deleted = false;
            this.Id = id;

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



    }*/
}