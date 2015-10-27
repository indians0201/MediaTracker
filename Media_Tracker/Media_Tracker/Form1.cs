using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Media_Tracker
{
	public partial class Form1 : Form
	{
		public string _path = "shows.xml";
		XmlDocument xDoc = new XmlDocument();


		public Form1()
		{
			InitializeComponent();
			// TODO: read from the xml and add items to listbox
			// ... also update from listboxes to something nicer looking
			//
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (File.Exists(_path))
			{
				try
				{
					if (textBox1.Text != null || textBox1.Text != "" || textBox1.Text != " ")
					{
						// Add the title the user enters into listbox
						listBox1.Items.Add(textBox1.Text);

						// TODO: add the title (and other info later) to the xml
					}
					else
					{
						MessageBox.Show("You must enter valid text");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			else
			{
				/// <summary>
				/// Generates the xml file with the
				/// needed nodes if it doesn't exist
				/// </summary>
				XmlTextWriter xWriter = new XmlTextWriter(_path, Encoding.UTF8);
				xWriter.Formatting = Formatting.Indented;
				xWriter.WriteStartElement("Type");
				xWriter.WriteStartElement("Shows");
				xWriter.WriteStartElement("Title");
				xWriter.WriteEndElement();
				xWriter.WriteEndElement();
				xWriter.WriteStartElement("Episodes");
				xWriter.WriteStartElement("Current_Episode");
				xWriter.WriteEndElement();
				xWriter.WriteStartElement("Total_Episodes");
				xWriter.WriteEndElement();
				xWriter.WriteEndElement();
				xWriter.WriteStartElement("Seasons");
				xWriter.WriteStartElement("Current_Season");
				xWriter.WriteEndElement();
				xWriter.WriteStartElement("Total_Seasons");
				xWriter.WriteEndElement();
				xWriter.WriteEndElement();
				xWriter.WriteEndElement();
				xWriter.Close();
			}
		}
	}
}
