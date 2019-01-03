using Framework.NetStd.Models;

namespace Domain.Store
{
    public class StoreOrderStatus:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
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