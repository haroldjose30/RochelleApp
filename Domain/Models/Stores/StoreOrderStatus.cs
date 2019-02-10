
using Domain.Core.Models;
using Newtonsoft.Json;

namespace Domain.Store
{
    public class StoreOrderStatus:Entity
    {
      
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public int Sequence { get; set; }


        public StoreOrderStatus(string name, string description, int sequence,string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            Name = name;
            Description = description;
            Sequence = sequence;
        }

    }


    //exemplos default:
    // - Cancelado
    // - Pendente
    // - Solicitado
    // - Aprovado
    // - Enviado
    // - Entregue
    // - Recebido
    // - Finalizado

}
