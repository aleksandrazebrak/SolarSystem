using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.Enumerations;

namespace SharpGLL
{

    public partial class SharpGLForm : Form
    {
        private float rotation = 0.0f;

        public SharpGLForm()
        {
            InitializeComponent();
            OpenGL gl = openGLControl.OpenGL;
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"F:\Documents\WEMIF\Zima 2018-2019\PA\Grafika3d\Star_Wars.wav");
            sp.PlayLooping();

        }


        float[] mat_specular = { 1.000f, 1.0f, 1.000f, 1.0f };        //kolor plamki światła odbitego

        float[] mat_diffuse = { 1f, 1f, 1f, 1.0f };                   // kolory kul
        float[] mat_diffuse2 = { 0.118f, 0.565f, 1.000f, 1.0f };
        float[] mat_diffuse3 = { 0.545f, 0.271f, 0.075f, 1.0f };
        float[] mat_diffuse4 = { 0.333f, 0.420f, 0.184f, 1.0f };
        float[] mat_diffuse5 = { 1.0f, 0.0f, 0.0f, 1.0f };
        float[] mat_diffuse6 = {0.4f, 0.4f, 0.4f, 1.0f};
       
        float[] mat_shininess = {3.0f};                               // współ. odbicie lustrzanego
        float[] light_position = { 0.0f, 0.0f, 0.0f, 1.0f };          // współrzędne źródla światła X,Y,Z
        float[] light_position2 = { 0.0f, 2.0f, -10.0f, 1.0f };
       
    

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
          
            OpenGL gl = openGLControl.OpenGL;
            

           
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);  // przypisuje wartości domyślne do bufora bitów
            
            
            
            gl.MatrixMode(OpenGL.GL_MODELVIEW);                         // tryb matrycy - startowy
            gl.LoadIdentity();                                          // Zastępuje bieżącą macierz macierzą tożsamości


            gl.PushMatrix();                                            // przesunięcie stosu macierzy
            
            

            IntPtr quadric = gl.NewQuadric();                       // tworzenie obiektu OpenGL
            
            
            


            gl.QuadricOrientation(quadric, 0);              // współrzędne opiektu OpenGL

            gl.ShadeModel(OpenGL.GL_SMOOTH);                // wygładzenie cienia

            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, mat_specular);    // ustawienia materiału
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, mat_shininess);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, mat_diffuse);
            
            
            
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_position2);

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, new float[] { 1.000f, 0.647f, 0.000f, 1.0f });

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            
            
            //slonce
            gl.Sphere(quadric, 5f, 32, 20); //stworzenie kulki

                                  
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_position);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, new float[] { 1.000f, 1.0f, 1.000f, 1.0f });
            
           
            
            //merkury
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, mat_diffuse4);

            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);
            gl.Translate(6f, 0 , 0);

            gl.Sphere(quadric, 0.383f, 16, 20);
                              

            gl.PopMatrix();
            gl.PushMatrix();
            

            //wenus
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, mat_diffuse6);

            gl.Rotate(rotation / 2, 0.0f, 1.0f, 0.0f);
            gl.Translate(9, 0, 0);

            
            gl.Sphere(quadric, 0.950f, 16, 20);
            

            gl.PopMatrix();
            gl.PushMatrix();
            
            
            //ziemia

            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, mat_diffuse2);

            gl.Rotate(rotation / 3, 0.0f, 1.0f, 0.0f);
            gl.Translate(14, 0, 0);

            
            gl.Sphere(quadric, 1.5f, 16, 20);


            gl.PopMatrix();
            gl.PushMatrix();
            
            
            //mars
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, mat_diffuse5);

            gl.Rotate(rotation / 4, 0.0f, 1.0f, 0.0f);
            gl.Translate(19, 0, 0);
            
            
            gl.Sphere(quadric, 1.0f, 16, 20);

            gl.PopMatrix();
            gl.PushMatrix();


            //jowisz
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, mat_diffuse3);

            gl.Rotate(rotation / 6, 0.0f, 1.0f, 0.0f);
            gl.Translate(25, 0, 0);

            
            gl.Sphere(quadric, 2.5f, 16, 20);

            gl.PopMatrix();
            gl.PushMatrix();

            rotation += 6f;
            
        }



        
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            
            OpenGL gl = openGLControl.OpenGL;

          
            gl.ClearColor(0.0f, 0.0f, 0.1f, 0.0f);              //kolor tła

        }

       
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            
            OpenGL gl = openGLControl.OpenGL;

           
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            
            gl.LoadIdentity();

        
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 3000.0);
 
            gl.LookAt(0, 4, -40, 0, 0, 0, 0, 1, 0);             //ustawienie perspektywy

                     
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

       
       
    }
}
