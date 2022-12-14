using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrageCheck
{
    class Historial
    {
        public ObjectId id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Unidades { get; set; }
        public string Prestador { get; set; }
        public string Prestatario { get; set; }
        public string CelularPrestatario { get; set; }
        public string FechaPrestamo { get; set; }
        public string FechaEntrega { get; set; }
        public string EstadoActual { get; set; }
        
        public Historial() { }

        public Historial(string accion, string fecha)
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
            this.Unidades = Unidades;
            this.Prestador = Prestador;
            this.Prestatario = Prestatario;
            this.CelularPrestatario = CelularPrestatario;
            this.FechaPrestamo = FechaPrestamo;
            this.FechaEntrega = FechaEntrega;
            this.EstadoActual = EstadoActual;
        }
        public Historial(string accion, string fecha, ObjectId id)
        {
            this.id = id;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
            this.Unidades = Unidades;
            this.Prestador = Prestador;
            this.Prestatario = Prestatario;
            this.CelularPrestatario = CelularPrestatario;
            this.FechaPrestamo = FechaPrestamo;
            this.FechaEntrega = FechaEntrega;
            this.EstadoActual = EstadoActual;
            
        }
    }
}
