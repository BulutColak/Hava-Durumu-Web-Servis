using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Web_Service1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ServiceReference1.GlobalWeatherSoapClient HavaDurumu = new ServiceReference1.GlobalWeatherSoapClient();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(HavaDurumu.GetCitiesByCountry("Turkey"));
            XmlNodeList Nodelar = xml.SelectNodes("NewDataSet/Table/City");
            foreach (XmlNode item in Nodelar)
            {
                comboBox1.Items.Add(item.InnerText);
                //InnerText özelliği ile o anki node ın içindeki yazan değeri alır.
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceReference1.GlobalWeatherSoapClient HavaDurumu = new ServiceReference1.GlobalWeatherSoapClient();
            listBox1.Items.Clear();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(HavaDurumu.GetWeather(comboBox1.Text, "Turkey"));
            listBox1.Items.Add("Tarih-Zaman : " + xml.SelectSingleNode("CurrentWeather/Time").InnerText);
            listBox1.Items.Add("Rüzgar : " + xml.SelectSingleNode("CurrentWeather/Wind").InnerText);
            listBox1.Items.Add("Sıcaklık : " + xml.SelectSingleNode("CurrentWeather/Temperature").InnerText);
        
         }
    }
}
