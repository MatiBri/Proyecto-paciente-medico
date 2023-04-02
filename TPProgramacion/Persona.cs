using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion
{
    class Persona
    {
        string nombre;
        string apellido;
        bool sexo;
        int dni;
        DateTime fechaNac;

        public Persona(string nombre, string apellido, bool sexo, int dni, DateTime fechaNac)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.dni = dni;
            this.fechaNac = fechaNac;
        }
        public Persona()
        {
            this.nombre = "";
            this.apellido = "";
            this.sexo = false;
            this.dni = 0;
            this.fechaNac = DateTime.Today;
        }

        public string pNombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string pApellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public bool pSexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public int pDni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }
        public string toStringSexo()
        {
            if (sexo == true) 
                return "Masculino";
            else
                return "Femenino";
        }
        public DateTime pFechaNac
        {
            get
            {
                return fechaNac;
            }

            set
            {
                fechaNac = value;
            }
        }
        public string toStringPersona()
        {
            return "Nombre:"+nombre + "\n"+"Apellido:"+apellido +"\n"+"Sexo:"+ sexo +"\n"+"DNI:"+ dni +"\n"+"Fecha de nacimiento:"+ fechaNac;
        }
    }
}
