using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        // Sunucunun IP adresi ve port numarası
        string serverIP = "127.0.0.1";
        int serverPort = 12345;

        TcpClient client = new TcpClient();
        client.Connect(serverIP, serverPort);

        NetworkStream stream = client.GetStream();

        //string message = "Merhaba, TCP Sunucusu!";
        //byte[] data = Encoding.ASCII.GetBytes(message);
        //stream.Write(data, 0, data.Length);


        var text = "aa";
        byte[] data = Encoding.ASCII.GetBytes(text);
        stream.Write(data, 0, data.Length);

        Task.Run(() =>
        {
            dinle(stream);
        });



        //stream.Close();
        //client.Close();

        Console.Read();

    }
    static Task oku(NetworkStream stream)
    {
        while (true)
        {
            
            
         
        }

    }
    static Task dinle(NetworkStream stream)
    {
        while (true)
        {
           
                // Yanıtı al
                byte[] responseData = new byte[1024];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);
                Console.WriteLine($"Alınan yanıt: {responseMessage}");
         
        }

    }
}
