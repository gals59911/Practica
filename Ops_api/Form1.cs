using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Server;
using Opc.UaFx.Client;
using EasyModbus;

namespace Ops_api
{
    public partial class Form1 : Form
    {
        ModbusClient modbusClient;
        ModbusServer modbusServer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string opcurl = textBox1.Text;
            var tagname = textBox2.Text;
            var client = new OpcClient(opcurl);
            client.Connect();
            var tagdata = client.ReadNode(tagname);
            string type = "System." + tagdata.DataType.ToString();
            var data = textBox3.Text;
            object value = Convert.ChangeType(data, Type.GetType(type));
            client.WriteNode(tagname, value);

            client.Disconnect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string opcurl = textBox1.Text;
            var tagname = textBox4.Text;
            var client = new OpcClient(opcurl);
            client.Connect();
            var tagdata = client.ReadNode(tagname);
            textBox5.Text = tagdata.Value.ToString();
            var type = tagdata.DataType;
            textBox6.Text = type.ToString();
            client.Disconnect();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                modbusClient = new ModbusClient(textBox7.Text, 502);
                modbusClient.Connect();
                label9.Text = "Connection";
            }
            catch (Exception ex)
            {
                label9.Text = ex.ToString();
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            modbusClient.Disconnect();
            label9.Text = "No connection";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int adres = int.Parse(textBox8.Text);
            modbusServer = new ModbusServer();

            if (comboBox1.Text == "Coil status")
            {
                bool val = false;
                if (textBox9.Text == "1" || textBox9.Text == "true")
                {
                    val = true;
                }
                modbusClient.WriteSingleCoil(adres, val);
            }
            else if (comboBox1.Text == "Holding register ")
            {
                short val = short.Parse(textBox9.Text);
                modbusClient.WriteSingleRegister(adres, val);


            }
        }
    }
}
