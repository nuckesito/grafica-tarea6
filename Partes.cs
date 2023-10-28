using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_grafica
{
    public class Parte
    {
        private Punto centro { get; set; }
        private List<Poligono> Lista { get; set; }
        public Punto centroParte { get { return centro; } set { centro = value; } }
        public List<Poligono> ListaPoligonos { get { return Lista; } set { Lista = value; } }
        
        public Parte() 
        { 
            Lista = new List<Poligono>();
            centro = new Punto();
        }
        public Parte(float x, float y, float z)
        {
            Lista = new List<Poligono>();
            centro = new Punto(x, y, z);
        }
        public Parte(Parte p1) 
        {
            Lista = new List<Poligono>();
            centro = new Punto(p1.centro);
            for (int i = 0; i < p1.Lista.Count; i++) 
            {
                Lista.Add(new Poligono(p1.Lista[i], p1.Lista[i].Color));
            }
        }
        public void Adicionar(Poligono poligono)
        {
            poligono.setCentro(
                this.centro.x + poligono.centroPoligono.x,                           
                this.centro.y + poligono.centroPoligono.y,
                this.centro.z + poligono.centroPoligono.z);
            Lista.Add(poligono);
        }
        public void Dibujar() 
        {
            for (int i = 0; i < Lista.Count; i++) 
            {
                Lista.ElementAt(i).Dibujar();
            }
        }
        public void Eliminar(int i)
        {
            Lista.RemoveAt(i);
        }
        public Poligono GetPoligono(int i)
        {
            return Lista.ElementAt(i);
        }
        public void setCentro(float x, float y, float z)
        {
            Punto aux=new Punto(x-this.centro.x,y-this.centro.y,z-this.centro.z);
            centro.x = x;
            centro.y = y;
            centro.z = z;
            foreach (Poligono valor in Lista)
            {
                valor.setCentro(
                    valor.centroPoligono.x + aux.x,
                    valor.centroPoligono.y + aux.y,
                    valor.centroPoligono.z + aux.z);
            }
        }
        public void Trasladar(float x, float y, float z)
        {
            foreach (Poligono poligono in Lista)
            {
                poligono.Trasladar(x, y, z);
            }
        }
        public void Escalar(float e)
        {
            foreach (Poligono poligono in Lista)
            {
                poligono.Escalar(e);
            }
        }
        public void Rotar(float angulo, float x, float y, float z, Punto p)
        {
            foreach (Poligono poligono in Lista)
            {
                poligono.setCentro(p);
                poligono.Rotar(angulo, x, y, z, p);
            }
        }
        public Punto getDifCentro() 
        {
            float[] minMax = getMinMax();
            Punto p = new Punto(minMax[0] - minMax[3], minMax[1] - minMax[4], minMax[2] - minMax[5]);
            return p*0.5f;
        }
        public float[] getMinMax()
        {
            float[] minMax = new float[6];
            minMax[0] = minMax[1] = minMax[2] = float.MinValue;//maximos: x,y,z
            minMax[3] = minMax[4] = minMax[5] = float.MaxValue;//minimos: x,y,z
            for (int i = 0; i < Lista.Count; i++)
            {
                float[] minMaxPoligono = Lista[i].getMinMax();
                if (minMaxPoligono[0] > minMax[0])
                {
                    minMax[0] = minMaxPoligono[0];
                }
                if (minMaxPoligono[1] > minMax[1])
                {
                    minMax[1] = minMaxPoligono[1];
                }
                if (minMaxPoligono[2] > minMax[2])
                {
                    minMax[2] = minMaxPoligono[2];
                }
                if (minMaxPoligono[3] < minMax[3])
                {
                    minMax[3] = minMaxPoligono[3];
                }
                if (minMaxPoligono[4] < minMax[4])
                {
                    minMax[4] = minMaxPoligono[4];
                }
                if (minMaxPoligono[5] < minMax[5])
                {
                    minMax[5] = minMaxPoligono[5];
                }
            }   
            return minMax;
        }
        public void mover(float x, float y, float z)
        {
            centro.x += x;
            centro.y += y;
            centro.z += z;
            foreach (Poligono poligono in Lista)
            {
                poligono.Mover(x, y, z);
            }
        }
    }
}
