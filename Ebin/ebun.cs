// Released to the public domain. Use, modify and relicense at will.  
// Matthew Ahrens, Nehe.gamedev.net, and OpenTK quickstart example. Credit due wherever Credit is due.  
//WhateverYourGameWindowIsCalled.cs  
using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
namespace OpenTK_NeHe_Solution
{
    class NeHe1 : GameWindow
    {
        private float squareRot;
        /// <summary>Creates a 800x600 window with the specified title.</summary>  
        public NeHe1()
            : base(800, 600, new GraphicsMode(32, 24, 0, 8), "NeHe Tutorial 5: More like 3Dumb.. wait..")
        {
            squareRot = 0.0f;
        }
        /// <summary>Load resources here.</summary>  
        /// <param name="e">Not used.</param>  
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
        }
        /// <summary>  
        /// Called when your window is resized. Set your viewport here. It is also  
        /// a good place to set up your projection matrix (which probably changes  
        /// along when the aspect ratio of your window).  
        /// </summary>  
        /// <param name="e">Not used.</param>  
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }
        /// <summary>  
        /// Called when it is time to setup the next frame. Add you game logic here.  
        /// </summary>  
        /// <param name="e">Contains timing information for framerate independent logic.</param>  
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (Keyboard[Key.Escape])
                Exit();
            if (Keyboard[Key.F] && this.WindowState != WindowState.Fullscreen)
                this.WindowState = WindowState.Fullscreen;
            else if (Keyboard[Key.F] && this.WindowState == WindowState.Fullscreen)
                this.WindowState = WindowState.Normal;
            if (squareRot >= 360)
                squareRot = 0.0f;
            squareRot += 1.5f;
        }
        /// <summary>  
        /// Called when it is time to render the next frame. Add your rendering code here.  
        /// </summary>  
        /// <param name="e">Contains timing information.</param>  
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            //typically starts with  
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //do stuff  
            //GL.LoadIdentity();  
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview); 
            GL.Translate(-1.5f, 0.0f, 6.0f);
            GL.Rotate(squareRot, 1.0f, 1.0, 0.0f); 
            GL.Begin(BeginMode.Quads);
            //face 1  
            GL.Color3(1.0f, 0.5f, 0.5f);
            GL.Vertex3(0.5f, 0.5f, -0.5f);
            GL.Vertex3(-0.5f, 0.5f, -0.5f);
            GL.Vertex3(-0.5f, 0.5f, 0.5f);
            GL.Vertex3(0.5f, 0.5f, 0.5f);
            //face2  
            GL.Color3(Color.MidnightBlue);
            GL.Vertex3(0.5f, -0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, -0.5f);
            GL.Vertex3(0.5f, -0.5f, -0.5f);
            //face3  
            GL.Color3(0.5f, 0.5f, 1.0f);
            GL.Vertex3(0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, 0.5f);
            GL.Vertex3(0.5f, -0.5f, 0.5f);
            //face 4  
            GL.Color3(0.5f, 0.1f, 0.5f);
            GL.Vertex3(0.5f, -0.5f, -0.5f);
            GL.Vertex3(-0.5f, -0.5f, -0.5f);
            GL.Vertex3(-0.5f, 0.5f, -0.5f);
            GL.Vertex3(0.5f, 0.5f, -0.5f);
            //face 5  
            GL.Color3(0.2f, 0.4f, 0.6f);
            GL.Vertex3(-0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, 0.5f, -0.5f);
            GL.Vertex3(-0.5f, -0.5f, -0.5f);
            GL.Vertex3(-0.5f, -0.5f, 0.5f);
            //face 6  
            GL.Color3(0.2f, 0.4f, 0.6f);
            GL.Vertex3(0.5f, 0.5f, 0.5f);
            GL.Vertex3(0.5f, 0.5f, -0.5f);
            GL.Vertex3(0.5f, -0.5f, -0.5f);
            GL.Vertex3(0.5f, -0.5f, 0.5f);
            GL.End();
            //typically ends with  
            SwapBuffers();
        }
    }
}