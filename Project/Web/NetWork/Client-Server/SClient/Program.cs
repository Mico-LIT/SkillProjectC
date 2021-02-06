using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SClient
{
    class Program
    {
        static int port = 8080;
        static void Main(string[] args)
        {
            ///sendmess();
            sendFile();
        }

        private static void sendFile()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(iPEndPoint);
            try
            {
            byte[] file = File.ReadAllBytes(@"C:\Users\миша\Desktop\D12.txt");
                ///отправка
            socket.Send(file);

            ///ответ
            StringBuilder str = new StringBuilder();
            byte[] bytemess = new byte[256];
            do
            {
               int bytes = socket.Receive(bytemess);
                Console.WriteLine(Encoding.Unicode.GetString(bytemess,0, bytes));

            } while (socket.Available>0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                socket.Close();
            }
        }

        private static void sendmess()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(iPEndPoint);
            Console.WriteLine("Mess :");

            /// Отправка на сервер
            byte[] bytestr = Encoding.Unicode.GetBytes(Console.ReadLine());
            socket.Send(bytestr);

            /// Прием от сервера
            byte[] data = new byte[256];
            int bytes = 0;

            do
            {
                bytes = socket.Receive(data);
                Console.WriteLine(Encoding.Unicode.GetString(data, 0, bytes));
            } while (socket.Available > 0);


            Console.Read();
        }
    }
}
