using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System;
using System.Net;

public class Client : MonoBehaviour
{
    private const int port = 1234;
    private const string server = "127.0.0.1";

    public void SendData()
    {
        try
        {
            SendMessageFromSocket(port);
        }
        catch
        {
        }
    }

    private static void SendMessageFromSocket(int port)
    {
        byte[] bytes1 = new byte[1024];

        IPHostEntry ipHost = Dns.GetHostEntry("127.0.0.1");
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

        Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        // Соединяем сокет с удаленной точкой
        sender.Connect(ipEndPoint);

        /*string[] file = File.ReadAllLines(Application.dataPath + "/Save.txt");
        int message = 0;
        foreach (string str in file)
        {
            message += Convert.ToInt32(str);
        }
        byte[] msg = Encoding.UTF8.GetBytes(Convert.ToString(message));*/
        string message = "hui";
        byte[] msg = Encoding.UTF8.GetBytes(Convert.ToString(message));
        int bytesSent = sender.Send(msg);

        // Получаем ответ от сервера
        //int bytesRec = sender.Receive(bytes1);
        //Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
        /*if (message.IndexOf("<TheEnd>") == -1)
                SendMessageFromSocket(port);*/

        // Освобождаем сокет
        sender.Shutdown(SocketShutdown.Both);
        sender.Close();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
