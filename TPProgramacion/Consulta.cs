using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion
{
    class Consulta
    {
        DateTime fecha;
        double monto;
        bool consulta;
        Paciente x;

        public Consulta(DateTime fecha, double monto, bool consulta,Paciente x)
        {
            this.fecha = fecha;
            this.monto = monto;
            this.consulta = consulta;
            this.x = x;
        }
        public Consulta()
            
        {
            this.fecha = DateTime.Today;
            this.monto = 0;
            this.consulta = false;
            this.x = null;
        }

        public DateTime pFecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public double pMonto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public bool pConsulta
        {
            get
            {
                return consulta;
            }

            set
            {
                consulta = value;
            }
        }

        internal Paciente pX
        {
            get
            {
                return x;
            }
          set
            {
                x = value;
            }
        }
        public string toStringConsulta()
        {
            return fecha + Convert.ToString( monto) + consulta + x.toStringPaciente();
        }
        public string toStringTipoConsulta()
        {
            if (consulta == true)
                return "Paciente del profesional";
            else
                return "1ª vez";

                }
        public double toStringAdicion()
        { if (consulta == true)
                return monto= (monto + 5 * monto/100);
            else
                return monto;

        }
    }
}
