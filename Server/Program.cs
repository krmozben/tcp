using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static string text;
    static void Main()
    {
        // Sunucunun IP adresi ve port numarası
        string serverIP = "127.0.0.1";
        int serverPort = 12345;

        TcpListener server = new TcpListener(IPAddress.Parse(serverIP), serverPort);
        server.Start();

        Console.WriteLine($"Sunucu {serverIP}:{serverPort} üzerinde dinleniyor...");

        TcpClient client = server.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        byte[] data = new byte[1024];
        int bytesRead = stream.Read(data, 0, data.Length);
        string message = Encoding.ASCII.GetString(data, 0, bytesRead);
        Console.WriteLine($"Alınan veri: {message}");

        while (true)
        {
            var text = Console.ReadLine();

            string responseMessage = $"{message} => {text}";
            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
            stream.Write(responseData, 0, responseData.Length);
        }

        stream.Close();
        client.Close();
        server.Stop();

        Console.Read();
    }
}
