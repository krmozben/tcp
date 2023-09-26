using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        string serverIP = "127.0.0.1";
        int serverPort = 12345;

        TcpClient client = new TcpClient();
        client.Connect(serverIP, serverPort);

        NetworkStream stream = client.GetStream();

        var text = "aa";
        byte[] data = Encoding.ASCII.GetBytes(text);
        stream.Write(data, 0, data.Length);

        Task.Run(() =>
        {
            dinle(stream);
        });

        Console.Read();
    }
    static Task dinle(NetworkStream stream)
    {
        while (true)
        {
                byte[] responseData = new byte[1024];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);
                Console.WriteLine($"Alınan yanıt: {responseMessage}");
         
        }
    }
}
