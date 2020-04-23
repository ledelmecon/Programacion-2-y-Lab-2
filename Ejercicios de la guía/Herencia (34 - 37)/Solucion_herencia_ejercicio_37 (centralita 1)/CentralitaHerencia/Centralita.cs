﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> listaDeLLamadas;
        protected string razonSocial;

        #region Properties
        public float GananciasPorLocal
        {
            get
            {
                return this.CalcularGanancias(Llamada.TipoLLamada.Local);
            }
        }

        public float GananciasPorProvincial
        {
            get
            {
                return this.CalcularGanancias(Llamada.TipoLLamada.Provincial);
            }
        }

        public float GananciasPorTodas
        {
            get
            {
                return this.CalcularGanancias(Llamada.TipoLLamada.Todas);
            }
        }

        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaDeLLamadas;
            }
        }
        #endregion

        #region Constructores
        public Centralita()
        {
            listaDeLLamadas = new List<Llamada>();
        }
        
        public Centralita(string nombreEmpresa) : this()
        {
            this.razonSocial = nombreEmpresa;
        }
        #endregion

        #region Métodos
        private float CalcularGanancias(Llamada.TipoLLamada tipo)
        {
            float valorRecaudado = default(float);

            //recorro la lista de llamadas
            foreach (Llamada item in this.listaDeLLamadas)
            {
                switch(tipo)//verifico que tipo de llamada es
                {
                    case Llamada.TipoLLamada.Local:

                        if(item is Local)
                        {
                            valorRecaudado += ((Local)item).CostoLlamada;
                        }
                        break;

                    case Llamada.TipoLLamada.Provincial:
                        if(item is Provincial)
                        {
                            valorRecaudado += ((Provincial)item).CostoLlamada;
                        }
                        break;

                    case Llamada.TipoLLamada.Todas:
                        if(item is Local)
                        {
                            valorRecaudado += ((Local)item).CostoLlamada;
                        }
                        //else if(item is Provincial)
                        if(item is Provincial)
                        {
                            valorRecaudado += ((Provincial)item).CostoLlamada;
                        }
                        break;
                }
            }
            return valorRecaudado;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Razon Social: " + this.razonSocial);
            sb.AppendLine("*******************************");
            sb.AppendLine("Ganacia por Local: " + this.GananciasPorLocal);
            sb.AppendLine("Ganacia por Provincial: " + this.GananciasPorProvincial);
            sb.AppendLine("Ganacia Totales: " + this.GananciasPorTodas);
            sb.AppendLine("*******************************");

            sb.AppendLine("Detalle de llamadas realizadas:");
            foreach(Llamada item in this.listaDeLLamadas)
            {
                if(item is Local)
                {
                    sb.AppendLine("Llamadas realizadas Locales: " + ((Local)item).Mostrar());
                }
                //else if(item is Provincial)
                if(item is Provincial)
                {
                    sb.AppendLine("Llamadas realizadas Provinciales: " + ((Provincial)item).Mostrar());
                }
            }

            return sb.ToString();
        }


        public void OrdenarLlamadas()
        {
            this.listaDeLLamadas.Sort(Llamada.OrdenarPorDuracion);
        }
        #endregion
    }
}
