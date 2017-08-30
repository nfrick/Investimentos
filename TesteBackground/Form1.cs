using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteBackground {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private System.Threading.Timer gpuUpdateTimer;
        private System.Threading.Timer cpuUpdateTimer;

        private List<HoraNew> Horas = new List<HoraNew>();

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            Horas.Add(new TesteBackground.HoraNew(1, DateTime.Now.ToString("mm:ss")));
            Horas.Add(new TesteBackground.HoraNew(2, DateTime.Now.ToString("mm:ss")));
            cHoraBindingSource.DataSource = Horas;

            if (!DesignMode) {
                gpuUpdateTimer = new System.Threading.Timer(UpdateGpuView, null, 0, 5000);
                cpuUpdateTimer = new System.Threading.Timer(UpdateCpuView, null, 0, 1000);
            }
        }

        private string Label1SetText {
            set {
                if (InvokeRequired) {
                    BeginInvoke(new Action(() => {
                        label1.Text = value;
                        cHoraBindingSource.ResetBindings(false);
                        //dataGridView1.Refresh();
                        }), null);
                }
            }
        }

        private string Label2SetText {
            set {
                if (InvokeRequired) {
                    BeginInvoke(new Action(() => {
                        label2.Text = value;
                        cHoraBindingSource.ResetBindings(false);
                    }), null);
                }
            }
        }

        private void UpdateCpuView(object state) {
            // do your stuff here
            var h = Horas.ElementAt(0);
            Horas.ElementAt(0).hora = DateTime.Now.ToString("mm:ss");
            // do not access control directly, use BeginInvoke!
            Label2SetText = DateTime.Now.ToString("mm:ss"); // whatever
    }

        private void UpdateGpuView(object state) {
            // do your stuff here
            var h = Horas.ElementAt(1);
            Horas.ElementAt(1).hora = DateTime.Now.ToString("mm:ss");
            // do not access control directly, use BeginInvoke!
            Label1SetText = DateTime.Now.ToString("mm:ss");  // whatever
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e) {
            gpuUpdateTimer.Change(0, trackBar1.Value * 1000);
        }

        //protected override void Dispose(bool disposing) {
        //    if (disposing) {
        //        if (gpuUpdateTimer != null) {
        //            gpuUpdateTimer.Dispose();
        //        }
        //        if (cpuUpdateTimer != null) {
        //            cpuUpdateTimer.Dispose();
        //        }
        //    }

        //    base.Dispose(disposing);
        //}
    }
}
