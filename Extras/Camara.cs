using OpenTK;
using OpenTK.Input;
using System;

namespace Proyecto_grafica
{
    public class Camara
    {
        private Vector3 position;
        private Vector3 front;
        private Vector3 up;

        private float speed;
        private float yaw;
        private float pitch;

        private bool rotatingUp = false;
        private bool rotatingDown = false;

        public Camara(Vector3 initialPosition, Vector3 initialFront, Vector3 initialUp, float cameraSpeed)
        {
            position = initialPosition;
            front = initialFront;
            up = initialUp;
            speed = cameraSpeed;
            yaw = -90.0f; // Empieza mirando hacia adelante
            pitch = 0.0f;
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(position, position + front, up);
        }

        public void Update(FrameEventArgs e)
        {
            var keyboardState = Keyboard.GetState();
            float rotationSpeed = 90.0f; // Velocidad de rotación en grados por segundo
            float deltaTime = (float)e.Time;

            // Movimiento de la cámara
            Vector3 moveFront = speed * front;
            Vector3 moveRight = speed * Vector3.Normalize(Vector3.Cross(front, up));

           

          

            // New code to move camera closer or farther
            if (keyboardState.IsKeyDown(Key.W))
            {
                position += moveFront;
                front.Z -= 3f;
            }

            if (keyboardState.IsKeyDown(Key.S))
            {
                position -= moveFront;
                front.Z += 3f;
            }

            if (keyboardState.IsKeyDown(Key.A))
            {
                position -= moveRight;
                front.X -= 3f;
            }

            if (keyboardState.IsKeyDown(Key.D))
            {
                position += moveRight;
                front.X += 3f;
            }

            // Rotación de la cámara
            if (keyboardState.IsKeyDown(Key.Left))
                yaw += rotationSpeed * deltaTime;

            if (keyboardState.IsKeyDown(Key.Right))
                yaw -= rotationSpeed * deltaTime;

            // Rotación vertical continua hacia arriba (pitch)
            if (keyboardState.IsKeyDown(Key.Up))
            {
                if (!rotatingUp) // Comienza la rotación solo si no se estaba rotando previamente
                    rotatingUp = true;

                pitch -= rotationSpeed * deltaTime;

                //if (pitch > 89.0f)
                //    pitch = 89.0f;
            }
            else
            {
                rotatingUp = false; // Detiene la rotación si la tecla se suelta
            }

            // Rotación vertical continua hacia abajo (pitch)
            if (keyboardState.IsKeyDown(Key.Down))
            {
                if (!rotatingDown) // Comienza la rotación solo si no se estaba rotando previamente
                    rotatingDown = true;

                pitch += rotationSpeed * deltaTime;

                //if (pitch < -89.0f)
                //    pitch = -89.0f;
            }
            else
            {
                rotatingDown = false; // Detiene la rotación si la tecla se suelta
            }



            front.X = (float)(Math.Cos(MathHelper.DegreesToRadians(yaw)) * Math.Cos(MathHelper.DegreesToRadians(pitch)));
            front.Y = (float)(Math.Tan(MathHelper.DegreesToRadians(pitch)));
            //front.Y = (float)(Math.Cos(MathHelper.DegreesToRadians(yaw)) * Math.Cos(MathHelper.DegreesToRadians(pitch)));
            front.Z = (float)(Math.Sin(MathHelper.DegreesToRadians(yaw)) * Math.Cos(MathHelper.DegreesToRadians(pitch)));
            front = Vector3.Normalize(front);


        }

        public Matrix4 GetViewMatrix(Matrix4 axisModelMatrix)
        {
            return axisModelMatrix * Matrix4.LookAt(position, position + front, up);
        }
    }
}
