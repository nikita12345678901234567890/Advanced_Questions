using System.Net;
using System.Net.Sockets;
using System.Text;
namespace UDP_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();

            byte[] sendBytes = Convert.FromHexString("2A01");
            udpClient.Send(sendBytes, sendBytes.Length, "127.0.0.1", 1181);
        }
    }
}