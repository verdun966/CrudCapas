using System.Data;
using DatosAcceso.Entidades;
using Cannont.Atributos;

namespace Dominio.Crud
{
    public class CPersona
    {
        Persona persona = new Persona();

        public DataTable Mostrar()
        {
            DataTable td = new DataTable();
            td = persona.Mostrar();
            return td;
        }

        public DataTable Buscar(string Buscar)
        {
            DataTable td = new DataTable();
            td = persona.Buscar(Buscar);
            return td;
        }

        public void Insertar(AtributosPersons obj)
        {
            persona.Insertar(obj);
        }

        public void Modificar(AtributosPersons obj)
        {
            persona.Modificar(obj);
        }

        public void Eliminar(AtributosPersons obj)
        {
            persona.Eliminar(obj);
        }
    }
}
