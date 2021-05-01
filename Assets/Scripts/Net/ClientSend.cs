using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    public static void SendTCPData(Packet packet)
    {
        packet.WriteLength();
        Client.instance.tcp.SendData(packet);
    }
    public static void SendUDPData(Packet packet)
    {
        packet.WriteLength();
        Client.instance.udp.SendData(packet);
    }
    #region Packets
    public static void WelcomeReceived()
    {
        using(Packet packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            packet.Write(Client.instance.myId);
            packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(packet);
        }
    }

    public static void PlayerMovement(float[] input, bool teleport = false)
    {
        using (Packet packet = new Packet((int)ClientPackets.playerMovement))
        {
            packet.Write(2); //1 = x, 2 = y, 3 = speed
            foreach(var item in input)
            {
                packet.Write(item); //x, y
            }
            packet.Write(GameManager.players[Client.instance.myId].transform.rotation); //rotation
            if (teleport)
            {
                packet.Write(1); 
            }

            SendUDPData(packet);
        }
    }
    #endregion
}
