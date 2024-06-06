using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Net;

namespace Witsml_api
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog.Filter = "XML files(.xml)|.xml";
                saveFileDialog.Title = "Save an XML File";
                string filePath = saveFileDialog.FileName;
                XmlDocument xmlDoc = new XmlDocument();

                XmlElement witsmlElement = xmlDoc.CreateElement("WITSML");
                witsmlElement.SetAttribute("version", "2.0");
                witsmlElement.SetAttribute("xmlns", "http://www.witsml.org/schemas/1series");
                witsmlElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                xmlDoc.AppendChild(witsmlElement);

                XmlElement well1Element = xmlDoc.CreateElement("well");
                XmlElement name = xmlDoc.CreateElement("name");
                name.InnerText = textBox1.Text;
                well1Element.AppendChild(name);
                XmlElement field = xmlDoc.CreateElement("field");
                field.InnerText = textBox2.Text;
                well1Element.AppendChild(field);
                XmlElement country = xmlDoc.CreateElement("country");
                country.InnerText = textBox3.Text;
                well1Element.AppendChild(country);
                witsmlElement.AppendChild(well1Element);

                xmlDoc.Save(filePath);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filepath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog.FileName;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(Data.email);
                mail.To.Add(textBox4.Text);
                mail.Subject = "WITSML File";
                mail.Body = "Please find attached the WITSML file.";

                Attachment attachment = new Attachment(filepath);
                mail.Attachments.Add(attachment);

                SmtpClient smtpClient = new SmtpClient("smtp.mail.ru");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(Data.email, Data.password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

            }

        }
    }
}
