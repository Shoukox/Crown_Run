using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace gameserver
{
    class ServerHandler
    {
        public static void WelcomeReceived(int fromClient, Packet packet)
        {
            int clientIdCheck = packet.ReadInt();
            string username = packet.ReadString();

            if(fromClient != clientIdCheck)
            {
                Console.WriteLine($"Player \"{username}\" (ID: {fromClient}) has assumed to wrong client ID ({clientIdCheck})!");
            }

            Server.clients[fromClient].SendIntoGame(username);
        }

        public static void PlayerMovement(int fromClient, Packet packet)
        {
            float[] axis = new float[packet.ReadInt()];
            for (int i = 0; i<=axis.Length-1; i++)
            {
                axis[i] = packet.ReadFloat();
            }
            float speed = packet.ReadFloat();
            Quaternion rotation = packet.ReadQuaternion();
            int arg = -1;
            Console.WriteLine(packet.UnreadLength());
            if (packet.UnreadLength() >= 4)
                arg = packet.ReadInt();

            Server.clients[fromClient].player.SetInput(axis, rotation, speed, arg == 1 ? true : false);
        }
    }
}
