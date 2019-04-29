
using Framework.Core.Models;
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
