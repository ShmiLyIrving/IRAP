using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace IRAP.Global
{
    public class EMailClient
    {
        private string from;
        private string[] to;
        private string[] cc;
        private string subject;
        private string body;
        private string pwd;
        private string host;
        private bool isBodyHtml;
        private string[] attachments;

        /// <summary>
        /// 发送者
        /// </summary>
        public string From
        {
            get { return from; }
            set { from = value; }
        }

        /// <summary>
        /// 收件人
        /// </summary>
        public string[] To
        {
            get { return to; }
            set { to = value; }
        }

        /// <summary>
        /// 抄送者
        /// </summary>
        public string[] CC
        {
            get { return cc; }
            set { cc = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// 正文
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        /// <summary>
        /// 发件人密码
        /// </summary>
        public string PWD
        {
            get { return pwd; }
            set { pwd = value; }
        }

        /// <summary>
        /// SMTP邮件服务器
        /// </summary>
        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        /// <summary>
        /// 正文是否是 HTML 格式
        /// </summary>
        public bool IsBodyHtml
        {
            get { return isBodyHtml; }
            set { isBodyHtml = value; }
        }

        /// <summary>
        /// 附件
        /// </summary>
        public string[] Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }

        public bool Send()
        {
            // 使用指定的邮件地址初始化 MailAddress 实例
            MailAddress mAddr = new MailAddress(from);
            // 初始化 MailMEssage 实例
            MailMessage mail = new MailMessage();

            // 向收件人地址集合添加邮件地址
            if (to != null)
            {
                for (int i = 0; i < to.Length; i++)
                {
                    mail.To.Add(to[i].ToString());
                }
            }

            // 向抄送人地址集合添加邮件地址
            if (cc != null)
            {
                for (int i = 0; i < cc.Length; i++)
                {
                    mail.CC.Add(cc[i].ToString());
                }
            }

            // 发件人地址
            mail.From = mAddr;

            // 电子邮件的标题
            mail.Subject = subject;
            //电子邮件的主题内容使用的编码
            mail.SubjectEncoding = Encoding.UTF8;

            // 电子邮件的正文
            mail.Body = body;
            // 电子邮件正文的编码
            mail.BodyEncoding = Encoding.Default;

            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = isBodyHtml;

            // 在有附件的情况下添加附件
            try
            {
                if (attachments != null && attachments.Length > 0)
                {
                    Attachment attachment = null;
                    foreach (string file in attachments)
                    {
                        attachment = new Attachment(file);
                        mail.Attachments.Add(attachment);
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("在添加附件时发生错误：" + error.Message);
            }

            SmtpClient smtp = new SmtpClient();
            // 指定发件人的邮件地址和密码以验证发件人身份
            smtp.Credentials = new System.Net.NetworkCredential(from, pwd);

            // 设置 SMTP 邮件服务器
            smtp.Host = host;

            try
            {
                // 将邮件发送到 SMTP 邮件服务器
                smtp.Send(mail);
                return true;
            }
            catch (System.Net.Mail.SmtpException error)
            {
                throw new Exception("在发送邮件时发生错误：" + error.Message);
            }
        }
    }
}
