using System.Diagnostics.Tracing;
using System.IO;
using System.Net.Http;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static int port = 8080;
        static void Main(string[] args)
        {
            ///Mess();
            file();
        }

        private static void file()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(iPEndPoint);
            socket.Listen(2);

            while (true)
            {
                Socket handler = socket.Accept();
                byte[] data = new byte[256];
                do
                {
                    handler.Receive(data);

                } while (handler.Available > 0);
                    File.WriteAllBytes("123.txt", data);
                Console.WriteLine("ok");
            }

        }

        private static void Mess()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(iPEndPoint);
            socket.Listen(10);
            Console.WriteLine("Сервер запущен!");
            while (true)
            {
                Socket handler = socket.Accept();// получаем сообщение
                StringBuilder strb = new StringBuilder();
                int bytes = 0;
                byte[] data = new byte[256];


                do
                {
                    bytes = handler.Receive(data);
                    strb.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    Console.WriteLine($"{DateTime.UtcNow.ToShortTimeString()} : {strb.ToString()}");

                } while (socket.Available > 0);


                string sendmes = "ответ от сервера";
                handler.Send(Encoding.Unicode.GetBytes(sendmes));
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();


            }
        }
    }
}
