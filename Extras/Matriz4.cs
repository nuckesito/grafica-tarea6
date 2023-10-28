using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01.Extras
{
    public class Matriz4
    {
        private float[,] matriz;
        public float[,] Matriz { get { return matriz; } set { matriz = value; } }

        public Matriz4()
        {
            matriz = new float[4, 4];
            for (int i = 0; i < 4; i++)
            {
                matriz[i, i] = 1;
            }
        }

        public float GetElement(int row, int col)
        {
            return matriz[row, col];
        }

        public void SetElement(int row, int col, float value)
        {
            matriz[row, col] = value;
        }
        public Matrix4 toMatriz4() 
        {
            Matrix4 M = new Matrix4();
            for (int i = 0;i < 4;i++) 
            {
                for (int j = 0;j < 4;j++)
                {
                    M[i, j] = matriz[i, j];
                }
            }
            return M;
        }
        public void copy(Matrix4 M) 
        {
            for(int i = 0;i < 4;i++)
            {
                for (int j = 0;j < 4;j++)
                {
                    matriz[i, j] = M[i, j];
                }
            }
        }
        public static Matriz4 operator +(Matriz4 M1, Matriz4 M2)
        {
            Matriz4 M = new Matriz4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0;j < 4;j++)
                {
                    M.matriz[i, j] = M1.matriz[i, j] + M2.matriz[i, j];
                }
            }
            return M;
        }
        public static Matriz4 operator *(Matriz4 M1, Matriz4 M2)
        {
            Matriz4 M = new Matriz4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0;j < 4;j++)
                {
                    for (int k = 0;k < 4;k++)
                    {
                        M.matriz[i, j] += M1.matriz[i, k] * M2.matriz[k, j];
                    }
                }
            }
            return M;
        }
        public static Matriz4 operator *(Matriz4 M1, Matrix4 M2)
        {
            Matriz4 M = new Matriz4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0;j < 4;j++)
                {
                    for (int k = 0;k < 4;k++)
                    {
                        M.matriz[i, j] += M1.matriz[i, k] * M2[k, j];
                    }
                }
            }
            return M;
        }
    }
}
