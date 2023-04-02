using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion
{
    class Paciente:Persona
    {
        int telefono;
        int obraSocial;
        double monto;

        public Paciente():base()
        {
            this.telefono = 0;
            this.obraSocial = 0;
            this.monto = 0;
        }

        public Paciente(int telefono, int obraSocial,string nombre,string apellido,bool sexo,DateTime fechaNac,int dni,double monto):base (nombre,apellido,sexo,dni,fechaNac)
        {
            this.telefono = telefono;
            this.obraSocial = obraSocial;
            this.monto = monto;
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

        public int pObraSocial
        {
            get
            {
                return obraSocial;
            }

            set
            {
                obraSocial = value;
            }
        }

        public string toStringObraSocial()

        {
            if (obraSocial == 1)
            {
                monto = 750;
                return "particular" + "\n" + "consulta:" + monto;
            }
            else
                     if (obraSocial == 2)
            {
                monto = 250;
                return "apross" + "\n" + "consulta:" + monto;
            }
            else
                  if (obraSocial == 3)
            {
                monto = 100;
                return "pami" + "\n" + "consulta:" + monto;
            }
            else
            {
                monto = 300;
                return "ospid" + "\n" + "consulta:" + monto;
            }
        }
        public string toStringPaciente()
        {
            return toStringPersona()+"\n"+ Convert.ToString( "Teléfono:"+telefono +"\n"+"Obra social:"+ obraSocial +"\n"+"Monto:"+ monto);
        }

    }
}
