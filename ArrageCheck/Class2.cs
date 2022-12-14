using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrageCheck
{
    class Materiales
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string unidades { get; set; }
        public ObjectId id { get; set; }
        public Materiales() { }

        public Materiales(string accion, string fecha)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.estado = estado;
            this.unidades = unidades;

        }
        public Materiales(string accion, string fecha, ObjectId id)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.estado = estado;
            this.unidades = unidades;
            this.id = id;
        }
    }
}
