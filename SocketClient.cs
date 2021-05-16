using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Socket Web類
using System.Net;
using System.Net.Sockets;
using System.Threading;
//Net Http
using System.Net.Http;
using System.Net.Http.Headers;

namespace SocketClient
{
    public class SocketClient
    {
        private static byte[] result = new byte[1024];
        public void SocketRun(int id)
        {
            //設定伺服器IP地址
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 8885)); //配置伺服器IP與埠
                Console.WriteLine("連線伺服器成功");
            }
            catch
            {
                Console.WriteLine("連線伺服器失敗，請按回車鍵退出！");
                Console.ReadLine();
                return;
            }
            //通過clientSocket接收資料
            int receiveLength = clientSocket.Receive(result);
            Console.WriteLine("接收伺服器訊息：{0}", Encoding.ASCII.GetString(result, 0, receiveLength));
            //通過 clientSocket 傳送資料
            //for (int i = 0; i < 5; i++)
            //{
                try
                {
                    //Thread.Sleep(1000);    //等待1秒鐘
                    string sendMessage = "client send Message " + DateTime.Now+",ID = "+ id;
                    //送出id
                    clientSocket.Send(Encoding.ASCII.GetBytes(id.ToString()));
                    //Console.WriteLine("向伺服器傳送訊息：{0}" + sendMessage);
                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    //break;
                }
            //}
            //Console.WriteLine("傳送完畢，按回車鍵退出");
            //Console.ReadLine();
        }
    }
}
