using Proyecto_grafica;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_grafica
{
    public class Escenario
    {
        private Punto centro { get; set; }
        private Dictionary<string,Objeto> objetos {  get; set; }
        public Punto centroEscenario { get { return centro; } set { centro = value; } }
        public Dictionary<string,Objeto> HashObjetos { get { return objetos; } set { objetos = value; } }
        
        public Escenario() 
        {
            objetos = new Dictionary<string, Objeto>();
            centro = new Punto();
        }
        public Escenario(float x, float y, float z)
        {
            objetos = new Dictionary<string, Objeto>();
            centro = new Punto(x, y, z);
        }

        public Escenario(Escenario e1) 
        {
            objetos = new Dictionary<string, Objeto>();
            centro = new Punto(e1.centro);
            foreach (KeyValuePair<string,Objeto> k in e1.objetos)
            {
                objetos.Add((k.Key), new Objeto((Objeto)(k.Value)));
            }
        }
        public void AdicionarObjeto(string nombre, Objeto o) 
        {
            o.setCentro(
                this.centro.x + o.centroObjeto.x,
                this.centro.y + o.centroObjeto.y,
                this.centro.z + o.centroObjeto.z);
            objetos.Add(nombre, o);
        }

        public void EliminarObjeto(string nombre) 
        {
            objetos.Remove(nombre);
        }
        public Objeto GetObjeto(string nombre)
        {
            return (Objeto)this.objetos[nombre];
        }
        public void setCentro(float x, float y, float z)
        {
            Punto aux = new Punto(x - this.centro.x, y - this.centro.y, z - this.centro.z);
            this.centro.x = x;
            this.centro.y = y;
            this.centro.z = z;
            foreach (Objeto valor in objetos.Values)
            {
                valor.setCentro(
                    valor.centroObjeto.x + aux.x,
                    valor.centroObjeto.y + aux.y,
                    valor.centroObjeto.z + aux.z);
            }
        }
        public void Dibujar()
        {
            foreach (Objeto valor in objetos.Values)
            {
                valor.Dibujar();
            }
        }
        public void Trasladar(float x, float y, float z)
        {
            foreach (Objeto valor in objetos.Values)
            {
                valor.Trasladar(x, y, z);
            }
        }
        public void Escalar(float e)
        {
            foreach (Objeto valor in objetos.Values)
            {
                valor.Escalar(e);
            }
        }
        public void Rotar(float angulo, float x, float y, float z)
        {
            foreach (Objeto valor in objetos.Values)
            {
                valor.Rotar(angulo, x, y, z);
            }
        }
    }

}
