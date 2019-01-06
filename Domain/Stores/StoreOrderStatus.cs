using Framework.NetStd.Models;
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

        public StoreOrderStatus(string id, string createdBy, string name, string description, int sequence) : base(id, createdBy)
        {
            Name = name;
            Description = description;
            Sequence = sequence;
        }

        public static StoreOrderStatus CreateNew(string createdBy, string name, string description, int sequence)
        {
            StoreOrderStatus oStoreOrderStatus = new StoreOrderStatus(string.Empty, createdBy, name, description, sequence);
            return oStoreOrderStatus;
        }
    }


    /*exemplos default:
     - Cancelado
     - Pendente
     - Solicitado
     - Aprovado
     - Enviado
     - Entregue
     - Recebido
     - Finalizado
    */

}