using System;

namespace Inventario_Ferreteria.Models
{
    public class Pedido
    {
        #region VARIAGLES DE LA BD

        public string IdPedido { get; set; }
        public string Fecha { get; set; }
        public string Codigo { get; set; }
        public string Estatus { get; set; }
        public string Comprador { get; set; }
        public string Autoriza { get; set; }
        public string Justificacion { get; set; }

        #endregion

        #region VARIABLES ADICIONALES

        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }

        #endregion
    }
}
