using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;

namespace CC.Yi.Common
{
    public class EmailHelper
    {
        public static bool sendMail(string subject, string body, string toMail)
        {
            try
            {

                string fromMail = "454313500@qq.com";
                string pwdMail = "yvjioburildgbhdf";
                MailMessage message = new MailMessage();
                //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
                System.Net.Mail.MailAddress fromAddr = new System.Net.Mail.MailAddress(fromMail, "江西服装学院论坛");
                message.From = fromAddr;

                //设置收件人,可添加多个,添加方法与下面的一样
                message.To.Add(toMail);


                //设置邮件标题
                message.Subject = subject;

                //设置邮件内容
                message.Body = body;

                //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.qq.com", 25)
                    ;
                //设置发送人的邮箱账号和密码，POP3/SMTP服务要开启, 密码要是POP3/SMTP等服务的授权码
                client.Credentials = new System.Net.NetworkCredential(fromMail, pwdMail);//vtirsfsthwuadjfe  fhszmpegwoqnecja

                //启用ssl,也就是安全发送
                client.EnableSsl = true;

                //发送邮件
                client.Send(message);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static void 接受邮件()
        {
            using (TcpClient client = new TcpClient("pop.qq.com", 110))
            using (NetworkStream n = client.GetStream())
            {
                GetEmail.ReadLine(n);                                // Read the welcome message.
                GetEmail.SendCommand(n, "USER 1040079213@qq.com");
                GetEmail.SendCommand(n, "PASS odfaizoqdiupbfgi");
                GetEmail.SendCommand(n, "LIST");                     // Retrieve message IDs
                List<int> messageIDs = new List<int>();
                while (true)
                {
                    string line = GetEmail.ReadLine(n);                // e.g.,  "11876"
                    if (line == ".") break;
                    messageIDs.Add(int.Parse(line.Split(' ')[0]));   // Message ID
                }
                foreach (int id in messageIDs)          // Retrieve each message.
                {
                    GetEmail.SendCommand(n, "RETR " + id);
                    string randomFile = Guid.NewGuid().ToString() + ".eml";
                    using (StreamWriter writer = File.CreateText(randomFile))
                        while (true)
                        {
                            string line = GetEmail.ReadLine(n);        // Read next line of message.
                            if (line == ".") break;            // Single dot = end of message.
                            if (line == "..") line = ".";      // "Escape out" double dot.
                            writer.WriteLine(line);           // Write to output file.
                        }
                    GetEmail.SendCommand(n, "DELE " + id);        // Delete message off server.
                }
                GetEmail.SendCommand(n, "QUIT");
            }
        }
    }
    //接受邮件pop
    public class GetEmail
    {
        public static void SendCommand(Stream stream, string line)
        {
            byte[] data = Encoding.UTF8.GetBytes(line + "\r\n");
            stream.Write(data, 0, data.Length);
            string response = ReadLine(stream);
            if (!response.StartsWith("+OK"))
                throw new Exception("POP Error: " + response);
        }
        public static string ReadLine(Stream s)
        {
            List<byte> lineBuffer = new List<byte>();
            while (true)
            {
                int b = s.ReadByte();
                if (b == 10 || b < 0) break;
                if (b != 13) lineBuffer.Add((byte)b);
            }
            return Encoding.UTF8.GetString(lineBuffer.ToArray());
        }
    }
}

