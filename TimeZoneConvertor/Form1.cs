using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeZoneConvertor
{
    public partial class Form1 : Form
    {
        int offset;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dateTimePicker1.Value;            
            dateTimePicker2.Value = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
            dateTimePicker3.Value = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            dateTimePicker4.Value = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.CreateCustomTimeZone(offset.ToString(), new TimeSpan(offset, 0, 0), "UTC " + offset, "UTC " + offset));
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dateTimePicker2.Value;
            DateTime localTime = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"), TimeZoneInfo.Local);
            dateTimePicker1.Value = localTime;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dateTimePicker3.Value;
            DateTime localTime = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
            dateTimePicker1.Value = localTime;
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dateTimePicker4.Value;
            DateTime localTime = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.CreateCustomTimeZone(offset.ToString(), new TimeSpan(offset, 0, 0), "UTC " + offset, "UTC " + offset), TimeZoneInfo.Local);
            dateTimePicker1.Value = localTime;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            offset = int.Parse(comboBox1.Text);
        }
    }
}
