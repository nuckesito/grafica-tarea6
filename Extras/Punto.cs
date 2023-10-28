using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_grafica
{
   
    public class Punto
    {
        //atributos
        private float ejeX { get; set; }
        private float ejeY { get; set; }
        private float ejeZ { get; set; }
        //properties
        public float x { get { return ejeX; } set { ejeX = value; } }
        public float y { get { return ejeY; } set { ejeY = value; } }
        public float z { get { return ejeZ; } set { ejeZ = value; } }
       

        //contructor con parametros---------------------------------------------------------
        public Punto(float x, float y, float z)
        {
            this.ejeX = x;
            this.ejeY = y;
            this.ejeZ = z;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public Punto(): this(0, 0, 0) { }
        //-----------------------------------------------------------------------------------------------------------------
        //Contructor copia
        public Punto(Punto p)
        {
            this.ejeX = p.ejeX;
            this.ejeY = p.ejeY;
            this.ejeZ = p.ejeZ;
        }
        //-----------------------------------------------------------------------------------------------------------------
        //Contructor con el mismo valor inicial 
        public Punto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public Vector3 ToVector3() 
        { 
            return new Vector3(this.ejeX, this.ejeY, this.ejeZ); 
        }

        public Vector4 ToVector4()
        {
            return new Vector4(this.ejeX, this.ejeY, this.ejeZ, 1);
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void acumular(Punto p)
        {
            this.ejeX += p.x; 
            this.ejeY += p.y;
            this.ejeZ += p.z;
        }
        public void acumular(float x, float y, float z)
        {
            this.ejeX += x;
            this.ejeY += y;
            this.ejeZ += z;
        }
        public void multiplicar(float x, float y, float z)
        {
            this.ejeX *= x;
            this.ejeY *= y;
            this.ejeZ *= z;
        }
        public void setPunto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }
        public void setPunto(float x,float y,float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void setPunto(Punto p)
        {
            this.x = p.x;
            this.y = p.y;
            this.z = p.z;
        }


        public Punto distancia(Punto punto) 
        {
            return new Punto(punto.ejeX - this.ejeX, punto.ejeY - this.ejeY, punto.ejeZ - this.ejeZ);
        }

        public Punto distancia(float x, float y, float z)
        {
            return new Punto(x - this.ejeX, y - this.ejeY, z - this.ejeZ);
        }
        //-----------------------------------------------------------------------------------------------------------------
        public static Punto operator +(Punto p1, Punto p2)
        {
            return new Punto(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
        }

        public static Punto operator -(Punto p1, Punto p2)
        {
            return new Punto(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }
        public static Punto operator +(Punto p, float a)
        {
            return new Punto(a + p.x, a + p.y, a + p.z);
        }

        public static Punto operator *(Punto p, float escalar)
        {
            return new Punto(p.x * escalar, p.y * escalar, p.z * escalar);
        }
        public static Punto operator *(Punto p, Punto p1)
        {
            return new Punto(p.x * p1.x, p.y * p1.y, p.z * p1.z);
        }
        public static Punto operator *(float escalar, Punto p)
        {
            return p * escalar;
        }
        

        public static Punto operator /(Punto p, float divisor)
        {
            if (divisor != 0)
            {
                return new Punto(p.x / divisor, p.y / divisor, p.z / divisor);
            }
            else
            {
                throw new ArgumentException("Divisor no puede ser cero.");
            }
        }


        //---------------------------------------------------------------------------------------------
        public bool compareTo(Punto a)
        {
            return (this.ejeX == a.ejeX && this.ejeY == a.ejeY && this.ejeZ == a.ejeZ);
        }
        public override string ToString() => $"({ejeX}|{ejeY}|{ejeZ})";
        


    }
}
