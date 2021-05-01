using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace gameserver
{
    class Player
    {
        public int id;
        public string username;

        public Vector2 position;
        public Quaternion rotation;

        private float moveSpeed = 35f;
        private float[] axis;
        private bool teleport = false;

        public void Update()
        {
            Vector2 inputDirection = new Vector2(axis[0], axis[1]);

            axis = new float[2];
            if (teleport)
            {
                teleport = false;
                Teleport(inputDirection);
            }
            else
            {
                Move(inputDirection);
            }
        }

        private void Move(Vector2 inputDirection)
        {
            Vector2 vector = inputDirection * moveSpeed;
            position += vector;

            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }

        private void Teleport(Vector2 destination)
        {
            position = destination;
            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }

        public Player(int id, string username, Vector2 spawnPosition)
        {
            this.id = id;
            this.username = username;
            this.position = spawnPosition;
            rotation = Quaternion.Identity;

            axis = new float[2];
        }

        public void SetInput(float[] axis, Quaternion rotation, float speed, bool teleport = false)
        {
            this.axis = axis;
            this.teleport = teleport;
            this.rotation = rotation;
            this.moveSpeed = speed / Constants.TICKS_PER_SECOND;
        }
    }
}
