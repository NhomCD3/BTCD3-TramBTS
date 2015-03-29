using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTramBTS
{
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ThongkeMayno frm = new ThongkeMayno();
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tabBTS.TabPages[2].Controls.Add(frm);
            ThongtinBTS frm2 = new ThongtinBTS();
            frm2.TopLevel = false;
            frm2.Visible = true;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            tabBTS.TabPages[0].Controls.Add(frm2);
            ThongtinMaynoForm frm3 = new ThongtinMaynoForm();
            frm3.TopLevel = false;
            frm3.Visible = true;
            frm3.FormBorderStyle = FormBorderStyle.None;
            frm3.Dock = DockStyle.Fill;
            ThongtinMaynoForm.myDelegate = new MyDelegate(frm2.UpdateSoLanViPham);
            tabBTS.TabPages[1].Controls.Add(frm3);

            Form1 frm4 = new Form1();
            frm4.TopLevel = false;
            frm4.Visible = true;
            frm4.FormBorderStyle = FormBorderStyle.None;
            frm4.Dock = DockStyle.Fill;
            //ThongtinMaynoForm.myDelegate = new MyDelegate(frm2.UpdateSoLanViPham);
            tabBTS.TabPages[3].Controls.Add(frm4);
        }

        private void tabBTS_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int index = tabBTS.SelectedIndex;
            if (index == 1)
            {
                ThongtinMaynoForm form = (ThongtinMaynoForm)tabBTS.TabPages[1].Controls[0];
                form.Init();
            }
        }

        

        
    }
}
