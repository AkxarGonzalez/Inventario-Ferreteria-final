using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Ferreteria.Models
{
    public class Inventario
    {
        public int Lid { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Fecha { get; set; }
        public string Movimiento { get; set; }
        public string Solicitante { get; set; }
    }
}
