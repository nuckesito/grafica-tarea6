using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_grafica.Extras
{
    public static class Utilidades
    {

        public static void Guardar<T>(T objeto, string f)
        {
            string s = JsonConvert.SerializeObject(objeto);
            TextWriter Archivo = new StreamWriter($"{f}");
            Archivo.Write(s);
            Archivo.Close();
        }

        public static T Cargar<T>(string f)
        {
            T objeto = default(T);
            TextReader Leer = new StreamReader($"{f}");
            string s = Leer.ReadToEnd();
            objeto = JsonConvert.DeserializeObject<T>(s);
            Console.WriteLine(objeto);

            Leer.Close();
            return objeto;
        }

        public static T Cargar<T>()
        {
            T objeto = default(T);

            // Crea un OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Establece el título del cuadro de diálogo
            openFileDialog.Title = "Seleccionar archivo JSON";

            // Establece el filtro para mostrar solo archivos JSON
            openFileDialog.Filter = "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*";

            // Opcional: Establece una ubicación inicial predeterminada
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Muestra el cuadro de diálogo
            DialogResult result = openFileDialog.ShowDialog();

            // Comprueba si el usuario hizo clic en "Abrir"
            if (result == DialogResult.OK)
            {
                // Obtiene la ruta completa del archivo seleccionado por el usuario
                string rutaArchivo = openFileDialog.FileName;

                // Intenta cargar el contenido del archivo JSON
                try
                {
                    using (TextReader leer = new StreamReader(rutaArchivo))
                    {
                        string s = leer.ReadToEnd();
                        objeto = JsonConvert.DeserializeObject<T>(s);
                    }
                    Console.WriteLine(objeto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar el archivo: " + ex.Message);
                }
            }

            return objeto;
        }

        public static void Guardar<T>(T objeto)
        {
            // Crea un objeto de diálogo de guardado de archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Guardar archivo";

            // Establece el filtro de archivos para el tipo de formato deseado
            saveFileDialog.Filter = "Archivos JSON (*.json)|*.json|Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";

            // Muestra el cuadro de diálogo y espera a que el usuario seleccione la ubicación y el formato del archivo
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                Console.WriteLine($"Archivo guardado en: {rutaArchivo}");

                // Serializa y guarda el objeto en el archivo seleccionado
                try
                {
                    string contenido = JsonConvert.SerializeObject(objeto);

                    // Verifica la extensión seleccionada y guarda el archivo en el formato correspondiente
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1: // JSON
                            File.WriteAllText(rutaArchivo, contenido);
                            Console.WriteLine("Objeto guardado en formato JSON.");
                            break;

                        case 2: // XML (puedes adaptar esto para XML si lo necesitas)
                                // Implementa la lógica de serialización a XML aquí
                                // Puedes usar XmlSerializer u otras opciones para serializar a XML
                            Console.WriteLine("Objeto guardado en formato XML (debes implementar esto).");
                            break;

                        default:
                            Console.WriteLine("Formato de archivo no admitido.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar el objeto: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No se guardó el archivo.");
            }
        }
    }
}
