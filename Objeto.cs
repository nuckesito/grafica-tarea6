using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_grafica
{
    public class Objeto
    {
        private Punto centro { get; set; }
        private Dictionary<string, Parte> partes { get; set; }
        public Punto centroObjeto { get { return centro; } set { centro = value; } }
        public Dictionary<string, Parte> HashPartes { get { return partes; } set { partes = value; } }
        
        public Objeto()
        {
            partes = new Dictionary<string, Parte>();
            centro = new Punto();
        }
        public Objeto(float x,float y,float z)
        {
            partes = new Dictionary<string, Parte>();
            centro = new Punto(x, y, z);
        }

        public Objeto(Objeto o1)
        {
            partes = new Dictionary<string, Parte>();
            centro = new Punto(o1.centro);
            foreach (KeyValuePair<string, Parte> k in o1.partes)
            {
                partes.Add((k.Key), new Parte((Parte)(k.Value)));
            }
        }
        public Parte GetParte(string nombre)
        {
            return (Parte)this.partes[nombre];
        }
        public void setCentro(float x, float y, float z)
        {   
            Punto aux=new Punto(x-this.centro.x,y-this.centro.y,z-this.centro.z);
            centro.x = x;
            centro.y = y;
            centro.z = z;
            foreach (Parte valor in partes.Values)
            {
                valor.setCentro(
                    valor.centroParte.x + aux.x,
                    valor.centroParte.y + aux.y,
                    valor.centroParte.z + aux.z);
            }
        }
        public Dictionary<string, Parte> getHashTable()
        {
            return partes;
        }
        public void AdicionarParte(string s, Parte p)
        {
            p.setCentro(
                this.centro.x + p.centroParte.x,
                this.centro.y + p.centroParte.y,
                this.centro.z + p.centroParte.z);
            partes.Add(s, p);
        }
        public void EliminarParte(string s)
        {
            partes.Remove(s);
        }
        public void Dibujar()
        {
            foreach (Parte valor in partes.Values)
            {
                valor.Dibujar();
            }
        }
        public void Trasladar(float x, float y, float z)
        {
            foreach (Parte valor in partes.Values)
            {
                valor.Trasladar(x, y, z);
            }
        }
        public void Escalar(float e)
        { 
            foreach (Parte valor in partes.Values)
            {
                valor.Escalar(e);
            }
        }
        public void Rotar(float angulo, float x, float y, float z)
        {
            foreach (Parte valor in partes.Values)
            { 
                valor.Rotar(angulo, x, y, z, this.centro);
            }
        }
        public Punto getCentro() 
        {//Centro del objeto
            Punto centro = new Punto();
            float[] minMax = getMinMax();
            centro.x = (minMax[0] + minMax[3]) * 0.5f;
            centro.y = (minMax[1] + minMax[4]) * 0.5f;
            centro.z = (minMax[2] + minMax[5]) * 0.5f;
            return centro;
        }
        public Punto getDifCentro() 
        {// Distancia entre el origen del objeto y su x,y,z positivo y negativo en su cubo imaginario
            float[] minMax = getMinMax();
            Punto p = new Punto(minMax[0] - minMax[3], minMax[1] - minMax[4], minMax[2] - minMax[5]);
            return p*0.5f;
        }
        public float[] getMinMax() 
        {
            float[] minMax = new float[6];
            minMax[0] = minMax[1] = minMax[2] = float.MinValue;//Maximos: x,y,z
            minMax[3] = minMax[4] = minMax[5] = float.MaxValue;//Minimos: x,y,z
            foreach (Parte valor in partes.Values) 
            {
                float[] minMaxParte = valor.getMinMax();
                if (minMaxParte[0] > minMax[0])
                {
                    minMax[0] = minMaxParte[0];
                }
                if (minMaxParte[1] > minMax[1])
                {
                    minMax[1] = minMaxParte[1];
                }
                if (minMaxParte[2] > minMax[2])
                {
                    minMax[2] = minMaxParte[2];
                }
                if (minMaxParte[3] < minMax[3])
                {
                    minMax[3] = minMaxParte[3];
                }
                if (minMaxParte[4] < minMax[4])
                {
                    minMax[4] = minMaxParte[4];
                }
                if (minMaxParte[5] < minMax[5])
                {
                    minMax[5] = minMaxParte[5];
                }
            }
            return minMax;
        }
    }
}
