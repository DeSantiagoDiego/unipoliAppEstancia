using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArrageCheck
{
    class Admins
    {
        
        public string name {get; set;}
        public string contraseña { get; set; }
        public string correo { get; set; }
        public ObjectId id { get; set; }
        public Admins() { }

        public Admins(string accion, string fecha)
        {
            this.name = name;
            this.correo = correo;
            this.contraseña = contraseña;

        }
        public Admins(string accion, string fecha,ObjectId id)
        {
            this.name = name;
            this.correo = correo;
            this.contraseña = contraseña;
            this.id = id;
        }

    }
}
