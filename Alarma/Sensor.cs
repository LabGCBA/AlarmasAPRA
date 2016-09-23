using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace Alarma
{ 
    public class Sensor
    {
        private System.Timers.Timer enviador = new System.Timers.Timer(60000 * 5);
        private System.Timers.Timer alarmador = new System.Timers.Timer(60000);
        private Label lbl;
        private Label lbl2;
        private Button button;
        private Form1 form;

        private void alarmar(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.form.addLog("Agregada medición para eliminar");
        }
        protected void onClick(object sender, EventArgs e)
        {
            switch (lbl2.Text)
            {
                case "Running":
                    lbl2.Text = "Stopped";
                    alarmador.Start();
                    alarmar(null, null);
                    lbl2.ForeColor = Color.Red;
                    break;
                case "Stopped":
                    lbl2.Text = "Running";
                    alarmador.Stop();
                    enviador.Start();
                    lbl2.ForeColor = Color.Green;
                    break;
            }
            
        }
        public Sensor(int top, string line, Form1 form1)
        {
            this.form = form1;
            lbl = new Label();
            lbl.Left = 30;
            lbl.Top = top;
            lbl.Text = line;
            lbl2 = new Label();
            lbl2.Left = 135;
            lbl2.Margin = new Padding(0, 0, 0, 0);
            lbl2.Top = top;
            lbl2.Text = "Running";
            lbl2.ForeColor = Color.Green;
            button = new Button();
            button.Left = 235;
            button.Top = top;
            button.ForeColor = Color.Red;
            button.Text = "Alarma";
            button.Click += new EventHandler(onClick);
            alarmador.Elapsed += alarmar;
            form.Controls.Add(lbl);
            form.Controls.Add(lbl2);
            form.Controls.Add(button);
        }
    }
}