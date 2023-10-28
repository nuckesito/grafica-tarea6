using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Proyecto_grafica.Extras;
using Proyecto1_01.Extras;
using System;
using System.Drawing;

namespace Proyecto_grafica
{
    public class Game : GameWindow
    {
        Ejes t = new Ejes();
        Camara c;

        Escenario scenario = new Escenario();
        Escenario scenario2;
        Objeto pared;
        Objeto repisa = new Objeto(5, 10.25f, 5);
        Objeto auto = new Objeto(5.75f, 11.25f, 5);

        float i = 0.1f;
        float a = 0.006f;
        float g = 5;
        bool b = false;

        //-----------------------------------------------------------------------------------------------------------------
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            c.Update(e);
            base.OnUpdateFrame(e);

        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {

            GL.ClearColor(Color4.Yellow);
            c= new Camara(new Vector3(0, 0, 3), new Vector3(0, 0, -1), new Vector3(0, 1, 0), 0.08f);


            /////////////ESCENARIO
            //scenario = new Escenario(Utilidades.Cargar<Escenario>("Escenario.txt"));
            //Utilidades.Guardar<Escenario>(scenario);

            //Utilidades.Guardar<Escenario>(scenario, "Escenario.json");


            //scenario.Trasladar("auto", 0, 0, 0);
            
            
            //////////////PARED-----------------------
            ///arriba
            Poligono p1 = new Poligono(Color.Silver);
            p1.setCentro(0, 7.5f, 0);
            p1.Adicionar(-5, 0, -1.5f);
            p1.Adicionar(5, 0, -1.5f);
            p1.Adicionar(5, 0, 1.5f);
            p1.Adicionar(-5, 0, 1.5f);
            ///abajo
            Poligono p2 = new Poligono(Color.Silver);
            p2.setCentro(0, -7.5f, 0);
            p2.Adicionar(-5, 0, -1.5f);
            p2.Adicionar(5, 0, -1.5f);
            p2.Adicionar(5, 0, 1.5f);
            p2.Adicionar(-5, 0, 1.5f);
            //derecha
            Poligono p3 = new Poligono(Color.Silver);
            p3.setCentro(5, 0, 0);
            p3.Adicionar(0, 7.5f, -1.5f);
            p3.Adicionar(0, 7.5f, 1.5f);
            p3.Adicionar(0, -7.5f, 1.5f);
            p3.Adicionar(0, -7.5f, -1.5f);
            //izquierda
            Poligono p4 = new Poligono(Color.Silver);
            p4.setCentro(-5, 0, 0);
            p4.Adicionar(0, 7.5f, -1.5f);
            p4.Adicionar(0, 7.5f, 1.5f);
            p4.Adicionar(0, -7.5f, 1.5f);
            p4.Adicionar(0, -7.5f, -1.5f);
            //frente
            Poligono p5 = new Poligono(Color.Green);
            p5.setCentro(0, 0, 1.5f);
            p5.Adicionar(-5, 7.5f, 0);
            p5.Adicionar(5, 7.5f, 0);
            p5.Adicionar(5, -7.5f, 0);
            p5.Adicionar(-5, -7.5f, 0);
            //atras
            Poligono p6 = new Poligono(Color.Red);
            p6.setCentro(0, 0, -1.5f);
            p6.Adicionar(-5, 7.5f, 0);
            p6.Adicionar(5, 7.5f, 0);
            p6.Adicionar(5, -7.5f, 0);
            p6.Adicionar(-5, -7.5f, 0);

            Parte partepared = new Parte();

            partepared.Adicionar(p1);
            partepared.Adicionar(p2);
            partepared.Adicionar(p3);
            partepared.Adicionar(p4);
            partepared.Adicionar(p5);
            partepared.Adicionar(p6);
            pared = new Objeto(5, 7.5f, 1.5f);
            
            pared.AdicionarParte("pared", partepared);
            
            scenario.AdicionarObjeto("pared", pared);
            /////////////////REPISA------------------------
            Poligono p7 = new Poligono(Color.Blue);
            p7.setCentro(0, 0.25f, 0);
            p7.Adicionar(-5, 0, -2f);
            p7.Adicionar(5, 0, -2f);
            p7.Adicionar(5, 0, 2f);
            p7.Adicionar(-5, 0, 2f);
            ///abajo
            Poligono p8 = new Poligono(Color.Silver);
            p8.setCentro(0, -0.25f, 0);
            p8.Adicionar(-5, 0, -2f);
            p8.Adicionar(5, 0, -2f);
            p8.Adicionar(5, 0, 2f);
            p8.Adicionar(-5, 0, 2f);
            //derecha
            Poligono p9 = new Poligono(Color.Silver);
            p9.setCentro(5, 0, 0);
            p9.Adicionar(0, 0.25f, -2f);
            p9.Adicionar(0, 0.25f, 2f);
            p9.Adicionar(0, -0.25f, 2f);
            p9.Adicionar(0, -0.25f, -2f);
            //izquierda
            Poligono p10 = new Poligono(Color.Silver);
            p10.setCentro(-5, 0, 0);
            p10.Adicionar(0, 0.25f, -2f);
            p10.Adicionar(0, 0.25f, 2f);
            p10.Adicionar(0, -0.25f, 2f);
            p10.Adicionar(0, -0.25f, -2f);
            //frente
            Poligono p11 = new Poligono(Color.Orange);
            p11.setCentro(0, 0, 2);
            p11.Adicionar(-5, 0.25f, 0);
            p11.Adicionar(5, 0.25f, 0);
            p11.Adicionar(5, -0.25f, 0);
            p11.Adicionar(-5, -0.25f, 0);
            //atras
            Poligono p12 = new Poligono(Color.Red);
            p12.setCentro(0, 0, -2);
            p12.Adicionar(-5, 0.25f, 0);
            p12.Adicionar(5, 0.25f, 0);
            p12.Adicionar(5, -0.25f, 0);
            p12.Adicionar(-5, -0.25f, 0);
            Parte parterepisa = new Parte();
            parterepisa.Adicionar(p7);
            parterepisa.Adicionar(p8);
            parterepisa.Adicionar(p9);
            parterepisa.Adicionar(p10);
            parterepisa.Adicionar(p11);
            parterepisa.Adicionar(p12);
            repisa.AdicionarParte("parte", parterepisa);

            repisa.setCentro(5, 10.25f, 5);
            scenario.AdicionarObjeto("repisa", repisa);
            /////////////////////AUTO---------------------
            Parte llanta1 = new Parte();
            Parte llanta2 = new Parte();
            //arriba
            p1 = new Poligono();
            p1.setCentro(0, 0.25f, 0);
            p1.Adicionar(-0.25f, 0, 0.25f);
            p1.Adicionar(0.25f, 0, 0.25f);
            p1.Adicionar(0.25f, 0, -0.25f);
            p1.Adicionar(-0.25f, 0, -0.25f);
            //abajo
            p2 = new Poligono();
            p2.setCentro(0, -0.25f, 0);
            p2.Adicionar(-0.25f, 0, 0.25f);
            p2.Adicionar(0.25f, 0, 0.25f);
            p2.Adicionar(0.25f, 0, -0.25f);
            p2.Adicionar(-0.25f, 0, -0.25f);
            //derecha 
            p3 = new Poligono();
            p3.setCentro(0.25f, 0, 0);
            p3.Adicionar(0, 0.25f, 0.25f);
            p3.Adicionar(0, 0.25f, -0.25f);
            p3.Adicionar(0, -0.25f, -0.25f);
            p3.Adicionar(0, -0.25f, 0.25f);
            //izquierda
            p4 = new Poligono();
            p4.setCentro(-0.25f, 0, 0);
            p4.Adicionar(0, 0.25f, 0.25f);
            p4.Adicionar(0, 0.25f, -0.25f);
            p4.Adicionar(0, -0.25f, -0.25f);
            p4.Adicionar(0, -0.25f, 0.25f);
            //frente
            p5 = new Poligono();
            p5.setCentro(0, 0, 0.25f);
            p5.Adicionar(0.25f, 0.25f, 0);
            p5.Adicionar(-0.25f, 0.25f, 0);
            p5.Adicionar(-0.25f, -0.25f, 0);
            p5.Adicionar(0.25f, -0.25f, 0);
            //atras
            p6 = new Poligono();
            p6.setCentro(0, 0, -0.25f);
            p6.Adicionar(0.25f, 0.25f, 0);
            p6.Adicionar(-0.25f, 0.25f, 0);
            p6.Adicionar(-0.25f, -0.25f, 0);
            p6.Adicionar(0.25f, -0.25f, 0);

            llanta1.Adicionar(p1);
            llanta1.Adicionar(p2);
            llanta1.Adicionar(p3);
            llanta1.Adicionar(p4);
            llanta1.Adicionar(p5);
            llanta1.Adicionar(p6);
            llanta1.setCentro(1, -0.5f, 0.75f);
            auto.AdicionarParte("llanta1", llanta1);


            p7 = new Poligono();
            p7.setCentro(0, 0.25f, 0);
            p7.Adicionar(-0.25f, 0, 0.25f);
            p7.Adicionar(0.25f, 0, 0.25f);
            p7.Adicionar(0.25f, 0, -0.25f);
            p7.Adicionar(-0.25f, 0, -0.25f);
            //abajo
            p8 = new Poligono();
            p8.setCentro(0, -0.25f, 0);
            p8.Adicionar(-0.25f, 0, 0.25f);
            p8.Adicionar(0.25f, 0, 0.25f);
            p8.Adicionar(0.25f, 0, -0.25f);
            p8.Adicionar(-0.25f, 0, -0.25f);
            //derecha 
            p9 = new Poligono();
            p9.setCentro(0.25f, 0, 0);
            p9.Adicionar(0, 0.25f, 0.25f);
            p9.Adicionar(0, 0.25f, -0.25f);
            p9.Adicionar(0, -0.25f, -0.25f);
            p9.Adicionar(0, -0.25f, 0.25f);
            //izquierda
            p10 = new Poligono();
            p10.setCentro(-0.25f, 0, 0);
            p10.Adicionar(0, 0.25f, 0.25f);
            p10.Adicionar(0, 0.25f, -0.25f);
            p10.Adicionar(0, -0.25f, -0.25f);
            p10.Adicionar(0, -0.25f, 0.25f);
            //frente
            p11 = new Poligono();
            p11.setCentro(0, 0, 0.25f);
            p11.Adicionar(0.25f, 0.25f, 0);
            p11.Adicionar(-0.25f, 0.25f, 0);
            p11.Adicionar(-0.25f, -0.25f, 0);
            p11.Adicionar(0.25f, -0.25f, 0);
            //atras
            p12 = new Poligono();
            p12.setCentro(0, 0, -0.25f);
            p12.Adicionar(0.25f, 0.25f, 0);
            p12.Adicionar(-0.25f, 0.25f, 0);
            p12.Adicionar(-0.25f, -0.25f, 0);
            p12.Adicionar(0.25f, -0.25f, 0);


            llanta2.Adicionar(p7);
            llanta2.Adicionar(p8);
            llanta2.Adicionar(p9);
            llanta2.Adicionar(p10);
            llanta2.Adicionar(p11);
            llanta2.Adicionar(p12);

            llanta2.setCentro(1, -0.5f, -0.75f);
            auto.AdicionarParte("llanta2", llanta2);



            Parte llanta3 = new Parte(-1, -0.5f, -0.75f);

            p7 = new Poligono();
            p7.setCentro(0, 0.25f, 0);
            p7.Adicionar(-0.25f, 0, 0.25f);
            p7.Adicionar(0.25f, 0, 0.25f);
            p7.Adicionar(0.25f, 0, -0.25f);
            p7.Adicionar(-0.25f, 0, -0.25f);
            //abajo
            p8 = new Poligono();
            p8.setCentro(0, -0.25f, 0);
            p8.Adicionar(-0.25f, 0, 0.25f);
            p8.Adicionar(0.25f, 0, 0.25f);
            p8.Adicionar(0.25f, 0, -0.25f);
            p8.Adicionar(-0.25f, 0, -0.25f);
            //derecha 
            p9 = new Poligono();
            p9.setCentro(0.25f, 0, 0);
            p9.Adicionar(0, 0.25f, 0.25f);
            p9.Adicionar(0, 0.25f, -0.25f);
            p9.Adicionar(0, -0.25f, -0.25f);
            p9.Adicionar(0, -0.25f, 0.25f);
            //izquierda
            p10 = new Poligono();
            p10.setCentro(-0.25f, 0, 0);
            p10.Adicionar(0, 0.25f, 0.25f);
            p10.Adicionar(0, 0.25f, -0.25f);
            p10.Adicionar(0, -0.25f, -0.25f);
            p10.Adicionar(0, -0.25f, 0.25f);
            //frente
            p11 = new Poligono();
            p11.setCentro(0, 0, 0.25f);
            p11.Adicionar(0.25f, 0.25f, 0);
            p11.Adicionar(-0.25f, 0.25f, 0);
            p11.Adicionar(-0.25f, -0.25f, 0);
            p11.Adicionar(0.25f, -0.25f, 0);
            //atras
            p12 = new Poligono();
            p12.setCentro(0, 0, -0.25f);
            p12.Adicionar(0.25f, 0.25f, 0);
            p12.Adicionar(-0.25f, 0.25f, 0);
            p12.Adicionar(-0.25f, -0.25f, 0);
            p12.Adicionar(0.25f, -0.25f, 0);

            llanta3.Adicionar(p7);
            llanta3.Adicionar(p8);
            llanta3.Adicionar(p9);
            llanta3.Adicionar(p10);
            llanta3.Adicionar(p11);
            llanta3.Adicionar(p12);


            auto.AdicionarParte("llanta3", llanta3);


            Parte llanta4 = new Parte(-1, -0.5f, 0.75f);

            p7 = new Poligono();
            p7.setCentro(0, 0.25f, 0);
            p7.Adicionar(-0.25f, 0, 0.25f);
            p7.Adicionar(0.25f, 0, 0.25f);
            p7.Adicionar(0.25f, 0, -0.25f);
            p7.Adicionar(-0.25f, 0, -0.25f);
            //abajo
            p8 = new Poligono();
            p8.setCentro(0, -0.25f, 0);
            p8.Adicionar(-0.25f, 0, 0.25f);
            p8.Adicionar(0.25f, 0, 0.25f);
            p8.Adicionar(0.25f, 0, -0.25f);
            p8.Adicionar(-0.25f, 0, -0.25f);
            //derecha 
            p9 = new Poligono();
            p9.setCentro(0.25f, 0, 0);
            p9.Adicionar(0, 0.25f, 0.25f);
            p9.Adicionar(0, 0.25f, -0.25f);
            p9.Adicionar(0, -0.25f, -0.25f);
            p9.Adicionar(0, -0.25f, 0.25f);
            //izquierda
            p10 = new Poligono();
            p10.setCentro(-0.25f, 0, 0);
            p10.Adicionar(0, 0.25f, 0.25f);
            p10.Adicionar(0, 0.25f, -0.25f);
            p10.Adicionar(0, -0.25f, -0.25f);
            p10.Adicionar(0, -0.25f, 0.25f);
            //frente
            p11 = new Poligono();
            p11.setCentro(0, 0, 0.25f);
            p11.Adicionar(0.25f, 0.25f, 0);
            p11.Adicionar(-0.25f, 0.25f, 0);
            p11.Adicionar(-0.25f, -0.25f, 0);
            p11.Adicionar(0.25f, -0.25f, 0);
            //atras
            p12 = new Poligono();
            p12.setCentro(0, 0, -0.25f);
            p12.Adicionar(0.25f, 0.25f, 0);
            p12.Adicionar(-0.25f, 0.25f, 0);
            p12.Adicionar(-0.25f, -0.25f, 0);
            p12.Adicionar(0.25f, -0.25f, 0);

            llanta4.Adicionar(p7);
            llanta4.Adicionar(p8);
            llanta4.Adicionar(p9);
            llanta4.Adicionar(p10);
            llanta4.Adicionar(p11);
            llanta4.Adicionar(p12);
            auto.AdicionarParte("llanta4", llanta4);

            Parte puerta1 = new Parte(1,0.25f,1);
            p1=new Poligono(Color.LightBlue);
            p1.Adicionar(-0.75f,0.5f,0);
            p1.Adicionar(-0.5f, 0.5f, 0);
            p1.Adicionar(0, 0, 0);
            p1.Adicionar(-0.75f, 0, 0);
            p2=new Poligono(Color.Green);
            p2.Adicionar(-0.75f, 0, 0);
            p2.Adicionar(0, 0, 0);
            p2.Adicionar(0, -0.5f, 0);
            p2.Adicionar(-0.75f, -0.5f, 0);
            puerta1.Adicionar(p1);
            puerta1.Adicionar(p2);

            Parte puerta2 = new Parte(1,0.25f,-1);
            p3 = new Poligono(Color.LightBlue);
            p3.Adicionar(-0.75f, 0.5f, 0);
            p3.Adicionar(-0.5f, 0.5f, 0);
            p3.Adicionar(0, 0, 0);
            p3.Adicionar(-0.75f, 0, 0);
            p4 = new Poligono(Color.Green);
            p4.Adicionar(-0.75f, 0, 0);
            p4.Adicionar(0, 0, 0);
            p4.Adicionar(0, -0.5f, 0);
            p4.Adicionar(-0.75f, -0.5f, 0);
            puerta2.Adicionar(p3);
            puerta2.Adicionar(p4);

            auto.AdicionarParte("puerta1", puerta1);
            auto.AdicionarParte("puerta2", puerta2);

            Parte maletero = new Parte(-1.25f, 0.25f, 0);
            p1=new Poligono(Color.DeepPink);
            p1.Adicionar(0, 0, 1);
            p1.Adicionar(0, 0, -1);
            p1.Adicionar(-0.5f, 0, -1);
            p1.Adicionar(-0.5f, 0, 1);
            maletero.Adicionar(p1);
            auto.AdicionarParte("maletero", maletero);

            Parte capo = new Parte(1, 0.25f, 0);
            p1 = new Poligono(Color.DeepPink);
            p1.Adicionar(0, 0, 1);
            p1.Adicionar(0, 0, -1);
            p1.Adicionar(0.75f, 0, -1);
            p1.Adicionar(0.75f, 0, 1);
            capo.Adicionar(p1);
            auto.AdicionarParte("capo", capo);

            Parte cuerpo = new Parte(0,0,0);
            //lado derecho
            p5 = new Poligono(Color.Green);
            p5.setCentro(0, 0, 1);
            p5.Adicionar(-1.75f, 0.25f, 0);
            p5.Adicionar(-1.25f, 0.25f, 0);
            p5.Adicionar(-0.75f, 0.75f, 0);
            p5.Adicionar(0.25f, 0.75f, 0);
            p5.Adicionar(0.25f, -0.23f, 0);
            p5.Adicionar(1, -0.23f, 0);
            p5.Adicionar(1, 0.25f, 0);
            p5.Adicionar(1.75f, 0.25f, 0);
            p5.Adicionar(1.75f, -0.25f, 0);
            p5.Adicionar(-1.75f, -0.25f, 0);
            cuerpo.Adicionar(p5);
            //lado izquierdo
            p5 = new Poligono(Color.Green);
            //lado derecho
            p5 = new Poligono(Color.Green);
            p5.setCentro(0, 0, -1);
            p5.Adicionar(-1.75f, 0.25f, 0);
            p5.Adicionar(-1.25f, 0.25f, 0);
            p5.Adicionar(-0.75f, 0.75f, 0);
            p5.Adicionar(0.25f, 0.75f, 0);
            p5.Adicionar(0.25f, -0.23f, 0);
            p5.Adicionar(1, -0.23f, 0);
            p5.Adicionar(1, 0.25f, 0);
            p5.Adicionar(1.75f, 0.25f, 0);
            p5.Adicionar(1.75f, -0.25f, 0);
            p5.Adicionar(-1.75f, -0.25f, 0);
            cuerpo.Adicionar(p5);
            //frente
            p1=new Poligono(Color.Green);
            p1.setCentro(1.75f, 0, 0);
            p1.Adicionar(0, 0.25f, 1);
            p1.Adicionar(0, 0.25f, -1);
            p1.Adicionar(0, -0.25f, -1);
            p1.Adicionar(0, -0.25f, 1);
            cuerpo.Adicionar(p1);
            //atras
            p1 = new Poligono(Color.Green);
            p1.setCentro(-1.75f, 0, 0);
            p1.Adicionar(0, 0.25f, 1);
            p1.Adicionar(0, 0.25f, -1);
            p1.Adicionar(0, -0.25f, -1);
            p1.Adicionar(0, -0.25f, 1);
            cuerpo.Adicionar(p1);
            //arriba
            p1=new Poligono(Color.Black);
            p1.setCentro(-0.125f, 0.75f, 0);
            p1.Adicionar(-0.625f, 0, 1);
            p1.Adicionar(0.625f, 0, 1);
            p1.Adicionar(0.625f, 0, -1);
            p1.Adicionar(-0.625f, 0, -1);
            cuerpo.Adicionar(p1);
            //abajo
            p1=new Poligono(Color.Red);
            p1.setCentro(0,-0.25f, 0);
            p1.Adicionar(-1.75f, 0, 1);
            p1.Adicionar(1.75f, 0, 1);
            p1.Adicionar(1.75f, 0, -1);
            p1.Adicionar(-1.75f, 0, -1);
            cuerpo.Adicionar(p1);

            auto.AdicionarParte("cuerpo", cuerpo);

            Parte parabrisasdelante = new Parte(0.75f, 0.5f, 0);
            p1 = new Poligono(Color.LightBlue);
            p1.Adicionar(-0.25f, 0.25f, 1);
            p1.Adicionar(-0.25f, 0.25f, -1);
            p1.Adicionar(0.25f, -0.25f, -1);
            p1.Adicionar(0.25f, -0.25f, 1);
            parabrisasdelante.Adicionar(p1);
            
            auto.AdicionarParte("parabrisasdelante", parabrisasdelante);
            Parte parabrisasatras = new Parte(-1f, 0.5f, 0);
            p1 = new Poligono(Color.LightBlue);
            p1.Adicionar(0.25f, 0.25f, 1);
            p1.Adicionar(0.25f, 0.25f, -1);
            p1.Adicionar(-0.25f, -0.25f, -1);
            p1.Adicionar(-0.25f, -0.25f, 1);
            parabrisasatras.Adicionar(p1);
            auto.AdicionarParte("parabrisasatras", parabrisasatras);

            scenario.AdicionarObjeto("auto", auto);

            base.OnLoad(e);
            
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //-----------------------
            Matrix4 viewMatrix= c.GetViewMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref viewMatrix);
            //-----------------------
            t.Dibujar();
            i = i + 0.01f;
            scenario.Dibujar();
            //scenario.Dibujar(matrix);


            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 40;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -22.5, 22.5, -d, d);//16:9
                                                //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }
        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case Key.A:
            //        matrix = Matrix4.CreateScale(1 + a * 5);
            //        break;
            //    case Key.B:
            //        matrix = Matrix4.CreateTranslation(i, 0, 0);
            //        break;
            //    case Key.C:
            //        matrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(i * 5));
            //        break;
            //    case Key.D:
            //        if (b) { b = false; }
            //        else { b = true; }
            //        break;
            //}
            //if (b == false)
            //{
            //    i += 0.1f;
            //    a += 0.0006f;
            //}
            //else
            //{
            //    i -= 0.1f;
            //    a -= 0.0006f;
            //}

            switch (e.Key)
            {
                case Key.Number1:
                    scenario.GetObjeto("auto").Trasladar(i-2, 0f, 0f);
                    break;
                case Key.Number2:
                    scenario.GetObjeto("auto").Rotar(20, 0f, 1f, 0f);
                    break;
                case Key.Number3:
                    scenario.GetObjeto("auto").Escalar(1.01f);
                    break;
                case Key.Number4:
                    if (b)
                    {
                        b = false;
                        a = 0.006f;
                        i = 0.1f;
                    }
                    else
                    {
                        b = true;
                        a = -0.006f;
                        i = -0.1f;
                    }
                    g *= -1;
                    break;               

            }
            base.OnKeyDown(e);
        }
    }
}
