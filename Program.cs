using Newtonsoft.Json;
using OpenTK.Graphics;
using Proyecto_grafica;
using Proyecto_grafica.Extras;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_grafica
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Game juego = new Game(1280, 720, "Demo OpenTK");
            juego.Run(60);
        }
    }
}
