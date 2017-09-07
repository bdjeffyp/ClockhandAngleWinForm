using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClockHandAngle;

namespace ClockhandAngleWinForm
{
    public partial class MainForm : Form
    {
        Clock clock;
        DateTime prevTime;

        public MainForm()
        {
            InitializeComponent();

            clock = new Clock();
            prevTime = dateTimer.Value;
        }

        private void dateTimer_ValueChanged(object sender, EventArgs e)
        {
            // If the value changed, then update the label with the angle
            
            // Ignore the second hand
            if (dateTimer.Value.Second != prevTime.Second)
            {
                prevTime = dateTimer.Value;
                return;
            }
            else
            {
                // Update the previous time held
                prevTime = dateTimer.Value;

                // Update the label with the new angle
                clock.Hour = dateTimer.Value.Hour;
                clock.Minute = dateTimer.Value.Minute;
                string angle = String.Format("{0}", clock.Calculate());
                lblAngle.Text = angle;
            }
        }
    }
}
