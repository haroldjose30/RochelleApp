

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{

    public class CompanyVM : EntityVM
    {
        [Required(ErrorMessage = "Informe o nome da empresa")]
        [DisplayName("Nome da Empresa")]
        public string CompanyName { get; set; }
        [DisplayName("Nome Fantasia")]
        public string FantasyName { get; set; }
        [DisplayName("Numero de Registro")]
        public string CorporateNumber { get; set; }

    }



    public class EntityVM
    {
        [DisplayName("Código")]
        [Key]
        public string Id { get; set; } = string.Empty;
        /*
        public string CreatedDate { get;  set; } = string.Empty;
        public string CreatedBy { get;  set; } = string.Empty;
        public string ModifiedDate { get;  set; } = string.Empty;
        public string ModifiedBy { get;  set; } = string.Empty;
        public bool Deleted { get;  set; } = false;
        */

    }

}
