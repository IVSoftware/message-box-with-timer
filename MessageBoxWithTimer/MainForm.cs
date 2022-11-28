using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxWithTimer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonHelp.Click += onHelp;
        }

        private async void onHelp(object sender, EventArgs e)
        {
            var owner = new Form { Visible = false };
            // Force the creation of the window handle.
            // Otherwise the BeginInvoke will not work.
            var handle = owner.Handle;
            owner.BeginInvoke((MethodInvoker)delegate 
            {
                MessageBox.Show(owner, text: "Help message", "Timed Message");
            });
            await Task.Delay(TimeSpan.FromSeconds(2));
            owner.Dispose();
        }
    }
}
