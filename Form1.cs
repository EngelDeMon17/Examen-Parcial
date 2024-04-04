using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Parcial
{
    public partial class Form1 : Form
    {
        List<Taller> tallers = new List<Taller>();
        List<Alumno> alumnos = new List<Alumno>();
        List<Inscripcion> inscripcions = new List<Inscripcion>();
        BindingList<Dato> datos = new BindingList<Dato>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Alumnos.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Alumno alumno = new Alumno();
                alumno.Dpi = Convert.ToInt32(reader.ReadLine());
                alumno.Nombre = reader.ReadLine();
                alumno.Direccion = reader.ReadLine();
                

                alumnos.Add(alumno);
            }

            reader.Close();

            comboBoxEstudiantes.DisplayMember = "Nombre";
            comboBoxEstudiantes.ValueMember = "Dpi";
            comboBoxEstudiantes.DataSource = alumnos;
            comboBoxEstudiantes.Refresh();

           
           Taller();
        }

        private void Taller()
        {
            string fileNombre = "taller.txt";

            FileStream streams = new FileStream(fileNombre, FileMode.Open, FileAccess.Read);
            StreamReader readers = new StreamReader(streams);

            while (readers.Peek() > -1)
            {
                Taller taller = new Taller();
                taller.CodigoTaller = Convert.ToInt16(readers.ReadLine());
                taller.NombreTaller = readers.ReadLine();
                taller.CostoTaller = Convert.ToInt16(readers.ReadLine());


                tallers.Add(taller);
            }

            readers.Close();

            comboBoxTaller.DisplayMember = "NombreTaller";
            comboBoxTaller.ValueMember = "CodigoTaller";
            comboBoxTaller.DataSource = tallers;
            comboBoxTaller.Refresh();

        }

        private void GuardarInscripcion()
        {

            FileStream stream = new FileStream("Inscripciones.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var inscripcion in inscripcions)
            {
                writer.WriteLine(inscripcion.DpiEstudiante);
                writer.WriteLine(inscripcion.CodigoTaller);
                writer.WriteLine(inscripcion.FechaInscripcion);
            }

            writer.Close();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.DpiEstudiante = Convert.ToInt32(comboBoxEstudiantes.SelectedValue);
            inscripcion.CodigoTaller =  Convert.ToInt16(comboBoxTaller.SelectedValue);
            inscripcion.FechaInscripcion = DateTime.Now;

            inscripcions.Add(inscripcion);

            GuardarInscripcion();

        }
         
        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            foreach (var alumno in alumnos)
            {
                foreach (var taller in tallers)
                {
                     foreach (var inscripcion in inscripcions)
                        {
                        if (inscripcion.DpiEstudiante == alumno.Dpi && inscripcion.CodigoTaller == taller.CodigoTaller)
                        {
                            Dato dato = new Dato();
                            dato.NombreEstudiante = alumno.Nombre;
                            dato.NombreTaller = taller.NombreTaller;


                            datos.Add(dato);
                        }
                    }
                }
            }
                

            dataGridViewDatos.DataSource = null;
            dataGridViewDatos.DataSource = datos;
            dataGridViewDatos.Refresh();
        }
    }
    
}
