using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskRelease.Utility
{
    public class MailHelper
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailAddress">收件人</param>
        /// <param name="mailTitle">标题</param>
        /// <param name="mailContent">内容</param>
        public static bool SendMail(string mailAddress, string mailTitle, string mailContent)
        {
            string fromAddress = Extensions.GetAppsettingKey("MialAccount");//邮箱地址。
            string fromPass = Extensions.GetAppsettingKey("MailPassword");//密码。
            string mailHost = Extensions.GetAppsettingKey("MailHost");//邮件服务器，如mail.qq.com

            SmtpClient objSmtpClient = new SmtpClient();
            objSmtpClient.Host = mailHost;//邮件服务器地址
            objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//通过网络发送到stmp邮件服务器
            objSmtpClient.Credentials = new System.Net.NetworkCredential(fromAddress, fromPass);//发送方的邮件地址，密码
            //objSmtpClient.EnableSsl = true;//SMTP 服务器要求安全连接需要设置此属性
            MailMessage objMailMessage = new MailMessage(fromAddress, mailAddress);


            //objMailMessage.From = new MailAddress(fromAddress);//发送方地址
            //objMailMessage.To.Add(new MailAddress(mailAddress));//收信人地址
            objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;//邮件编码
            objMailMessage.Subject = mailTitle;//邮件标题
            objMailMessage.Body = mailContent;//邮件内容
            objMailMessage.IsBodyHtml = true;//邮件正文是否为html格式
            objMailMessage.Priority = MailPriority.High;
            try
            {
                objSmtpClient.Send(objMailMessage);
                return true;
            }
            catch (Exception ex)
            {
                ex.WriterLog();
                return false;

            }
        }
        //腾讯QQ邮箱
        //接收服务器：pop.qq.com
        //发送服务器：smtp.qq.com 

        //网易126邮箱
        //接收服务器：pop3.126.com
        //发送服务器：smtp.126.com 

        //网易163免费邮
        //接收服务器：pop.163.com
        //发送服务器：smtp.163.com

        //网易163VIP邮箱
        //接收服务器：pop.vip.163.com
        //发送服务器：smtp.vip.163.com

        //网易188财富邮
        //接收服务器：pop.188.com
        //发送服务器：smtp.188.com

        //网易yeah.net邮箱
        //接收服务器：pop.yeah.net
        //发送服务器：smtp.yeah.net

        //网易netease.com邮箱
        //接收服务器：pop.netease.com
        //发送服务器：smtp.netease.com

        //新浪收费邮箱
        //接收服务器：pop3.vip.sina.com
        //发送服务器：smtp.vip.sina.com

        //新浪免费邮箱
        //接收服务器：pop3.sina.com.cn
        //发送服务器：smtp.sina.com.cn

        //搜狐邮箱
        //接收服务器：pop3.sohu.com
        //发送服务器：smtp.sohu.com

        //21cn快感邮
        //接收服务器：vip.21cn.com
        //发送服务器：vip.21cn.com

        //21cn经济邮
        //接收服务器：pop.163.com
        //发送服务器：smtp.163.com

        //tom邮箱
        //接收服务器：pop.tom.com
        //发送服务器：smtp.tom.com

        //263邮箱
        //接收服务器：263.net
        //发送服务器：smtp.263.net

        //网易163.com邮箱
        //接收服务器：rwypop.china.com
        //发送服务器：rwypop.china.com

        //雅虎邮箱
        //接收服务器：pop.mail.yahoo.com
        //发送服务器：smtp.mail.yahoo.com

        //Gmail邮箱
        //接收服务器：pop.gmail.com
        //发送服务器：smtp.gmail.com

    }
}
