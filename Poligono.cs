using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Proyecto1_01.Extras;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Proyecto_grafica
{
    public class Poligono
    {
        private Punto centro { get; set; }
        private List<Punto> puntos { get; set; }
        private Color4 color { get; set; }
        private Matrix4 matriz;
        
        public Punto centroPoligono { get { return centro; } set { centro = value; } }
        public Matrix4 Matriz { get { return matriz; } set { matriz = value; } }
        public Color4 Color { get { return color; } set { color = value; } }
        public List<Punto> ListaVertices{ get { return puntos; } set { puntos = value; } }

        public Poligono()
        {
            puntos = new List<Punto>();
            centro = new Punto();
            this.color = new Color4();
            matriz = Matrix4.Identity;
        }

        public Poligono(Color4 color)
        {
            puntos = new List<Punto>();
            centro = new Punto(0,0,0);
            this.color = color;
            matriz = Matrix4.Identity;
        }

        public Poligono(List<Punto> l, Color4 color, float x, float y, float z)
        {
            puntos = new List<Punto>(l);
            centro = new Punto(x, y, z);
            this.color = color;
            matriz = Matrix4.Identity;
        }

        public Poligono(Poligono p, Color4 color) 
        {
            puntos = new List<Punto>();
            centro = new Punto(p.centro);
            this.color = color;
            matriz = p.matriz;
            for (int i = 0; i < p.puntos.Count(); i++) 
            {
                puntos.Add(new Punto(p.puntos[i]));
            }
        }
        public Poligono(Poligono p)
        {
            puntos = new List<Punto>();
            this.centro.x = p.centro.x;
            this.centro.y = p.centro.y;
            this.centro.z = p.centro.z;
            this.color = p.color;
            matriz = p.matriz;
            for (int i = 0; i < p.puntos.Count(); i++)
            {
                puntos.Add(new Punto(p.puntos[i]));
            }
        }
        public Poligono(float x, float y, float z)
        {
            puntos = new List<Punto>();
            centro = new Punto(x, y, z);
            this.color = new Color4();
            matriz = Matrix4.Identity;
        }
        //-----------------------------------------------------------------------------------------
        public void Dibujar()
        {
            //PrimitiveType primitiveType = PrimitiveType.Polygon;
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(color);

            //matriz = matriz * mEscala * mRotacion * mTraslacion;
            for (int i = 0; puntos.Count > i; i++)
            {
                GL.Vertex4((puntos.ElementAt(i) + centroPoligono).ToVector4() * matriz);
            }
            GL.End();
        }
        //public void Dibujar()
        //{
        //    //PrimitiveType primitiveType = PrimitiveType.Polygon;
        //    GL.Begin(PrimitiveType.Polygon);
        //    GL.Color4(color);
        //    for (int i = 0; puntos.Count > i; i++)
        //    {
        //        GL.Vertex4((puntos.ElementAt(i) + centroPoligono).ToVector4()*matriz.toMatriz4());
        //    }
        //    GL.End();
        //}
        public void Trasladar(float x, float y, float z)
        {
            matriz *= Matrix4.CreateTranslation(x, y, z);
        }

        public void Escalar(float e)
        {
            Punto aux = new Punto(centro);
            matriz *= Matrix4.CreateScale(e);

        }
        public void Rotar(float angulo, float x, float y, float z, Punto p)
        {
            Matrix4 m;
            if (x == 1 && y == 0 && z == 0)
                m = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angulo));
            else if (y == 1 && x == 0 && z == 0)
                m = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angulo));
            else if (z == 1 && x == 0 && y == 0)
                m = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angulo));
            else
                m = Matrix4.Identity;
            matriz *= m;
        }
        public void Adicionar(float x,float y,float z) 
        {
            puntos.Add(new Punto(x,y,z));
        }
        public void Eliminar(int i) 
        {
            puntos.RemoveAt(i);
        }
        public Punto GetPunto(int i)
        {
            return puntos.ElementAt(i);
        }
        public void setCentro(float x, float y, float z)
        {
            this.centro.setPunto(x, y, z);
        }
        public void setCentro(Punto p)
        {
            centro.x = p.x;
            centro.y = p.y;
            centro.z = p.z;
        }
        public void Mover(float x, float y, float z)
        {
            centro.x += x;
            centro.y += y;
            centro.z += z;
            foreach (Punto punto in puntos)
            {
                punto.x += x;
                punto.y += y;
                punto.z += z;
            }
        }
        public float[] getMinMax()
        {
            float[] minMax=new float[6];
            minMax[0] = minMax[1] = minMax[2] = float.MinValue;
            minMax[3] = minMax[4] = minMax[5] = float.MaxValue;
            for (int i = 0;i<puntos.Count;i++)
            {
                if (puntos[i].x > minMax[0])
                {
                    minMax[0] = puntos[i].x;
                }
                if (puntos[i].y > minMax[1])
                {
                    minMax[1] = puntos[i].y;
                }
                if (puntos[i].z > minMax[2])
                {
                    minMax[2] = puntos[i].z;
                }
                if (puntos[i].x < minMax[3])
                {
                    minMax[3] = puntos[i].x;
                }
                if (puntos[i].y < minMax[4])
                {
                    minMax[4] = puntos[i].y;
                }
                if (puntos[i].z < minMax[5])
                {
                    minMax[5] = puntos[i].z;
                }
            }
            return minMax;
        }
    }
}
