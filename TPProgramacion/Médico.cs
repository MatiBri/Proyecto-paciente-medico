using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion
{
    class Médico:Persona
    {
        int matricula;
        int telefono;
        int especialidad;        

        public Médico():base()
        {
            this.matricula = 0;
            this.telefono = 0;
            this.especialidad =0;
        }

        public Médico(int matricula, int telefono, int especialidad,string nombre,string apellido,bool sexo,int dni,DateTime fechaNac):base(nombre,apellido,sexo,dni,fechaNac)
        {
            this.matricula = matricula;
            this.telefono = telefono;
            this.especialidad = especialidad;
        }

        public int pMatricula
        {
            get
            {
                return matricula;
            }

            set
            {
                matricula = value;
            }
        }

        public int pTelefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public int pEspecialidad
        {
            get
            {
                return especialidad;
            }

            set
            {
                especialidad = value;
            }
        }
        public string toStringEspecialidad()
        {
            if (especialidad == 1)
                return "Pediatra";
            else
                if (especialidad == 2)
                return "Clinico";
            else
                if (especialidad == 3)
                return "Traumatólogo";
            else
                return "Cardiólogo";
        }
        public string toStringMedico()
        {
            return Convert.ToString( matricula + telefono + especialidad);
        }
    }
}
