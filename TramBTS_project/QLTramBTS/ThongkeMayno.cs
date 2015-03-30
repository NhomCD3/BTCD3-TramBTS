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
    public partial class ThongkeMayno : Form
    {
        TramContext tramContext;
        GenericRepository<ChayMayNo> MaynoRepo;
        GenericRepository<Tram> TramRepo;
        public ThongkeMayno()
        {
            InitializeComponent();
            Console.WriteLine();
            btnThongke.Enabled = false;
            listView1.Scrollable = true;
            cmbHang.Enabled = cmbNgay.Enabled = cmbThang.Enabled = cmbNam.Enabled = cmbQuy.Enabled = cmbTram.Enabled = txtSolanvipham.Enabled = false;
            btnTim.Enabled = false;
            tramContext = new TramContext();
            MaynoRepo = new GenericRepository<ChayMayNo>(tramContext);
            TramRepo = new GenericRepository<Tram>(tramContext);
            UpdateItem();
            
        }
        //Cap nhat item cho combobox
        void UpdateItem()
        {
            
            cmbTram.Items.Clear();

            //Them item cho combobox ngay
            
            for (int i = 1; i <= 31; i++)
            {
                cmbNgay.Items.Add(i);
            }
            //Them item cho combobox thang
            
            for (int i = 1; i <= 12; i++)
            {
                cmbThang.Items.Add(i);
            }
            //Them item cho combobox nam            
            for (int i = 1950; i <= DateTime.Today.Year; i++)
            {
                cmbNam.Items.Add(i);
            }

            //Them item cho combo box Tram
            
            var listram = TramRepo.Get();
            foreach (var tram in listram)
            {
                cmbTram.Items.Add(tram.TenTram);
            }
        }
        //Cập nhật danh sách thống kê cho tất cả
        void UpdateList()
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno = MaynoRepo.Get();
            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach(var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem(""+i);                
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());
              
                listView1.Items.Add(item);
            }
        }
        //Cập nhật thống kê theo Ngày
        void UpdatelistNgay(DateTime date)
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno = from st in tramContext.ChayMayNo
                            where st.NgayGioChayMayNo.Month.ToString() == date.Month.ToString() && st.NgayGioChayMayNo.Year.ToString() == date.Year.ToString()&&st.NgayGioChayMayNo.Day.ToString()==date.Day.ToString()
                            select st;
            
            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach (var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem("" + i);
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());

                listView1.Items.Add(item);
            }
        }
        //Cap nhat danh sach thong ke theo thang
        void UpdatelistThang(string Thang, string Nam)
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno = from st in tramContext.ChayMayNo
                            where st.NgayGioChayMayNo.Month.ToString()==Thang&&st.NgayGioChayMayNo.Year.ToString()==Nam
                            select st;
            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach (var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem("" + i);
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());

                listView1.Items.Add(item);
            }
        }
        //Cap nhat danh sach thong ke theo nam
        void UpdatelistNam(string Nam)
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno = from st in tramContext.ChayMayNo
                            where st.NgayGioChayMayNo.Year.ToString() == Nam
                            select st;
            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach (var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem("" + i);
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());

                listView1.Items.Add(item);
            }
        }
        //Cap nhat danh sach thong ke theo quy
        void UpdatelistQuy(string Nam,string Quy)
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno=MaynoRepo.Get();
            if (Nam.Equals("Tất cả"))
            {
                if (Quy.Equals("1"))
                {
                     listmayno = from st in tramContext.ChayMayNo
                                    where st.NgayGioChayMayNo.Month >= 1 && st.NgayGioChayMayNo.Month <= 3
                                    select st;
                }
                else
                    if (Quy.Equals("2"))
                    {
                         listmayno = from st in tramContext.ChayMayNo
                                        where st.NgayGioChayMayNo.Month >= 4 && st.NgayGioChayMayNo.Month <= 6
                                        select st;
                    }
                    else
                        if (Quy.Equals("3"))
                        {
                             listmayno = from st in tramContext.ChayMayNo
                                            where st.NgayGioChayMayNo.Month >= 7 && st.NgayGioChayMayNo.Month <= 9
                                            select st;
                        }
                        else
                        {
                             listmayno = from st in tramContext.ChayMayNo
                                            where st.NgayGioChayMayNo.Month >= 10 && st.NgayGioChayMayNo.Month <= 12
                                            select st;
                        }
            }
            else
            {
                if (Quy.Equals("1"))
                {
                     listmayno = from st in tramContext.ChayMayNo
                                    where st.NgayGioChayMayNo.Month >= 1 && st.NgayGioChayMayNo.Month <= 3 && st.NgayGioChayMayNo.Year.ToString()==Nam
                                    select st;
                }
                else
                    if (Quy.Equals("2"))
                    {
                         listmayno = from st in tramContext.ChayMayNo
                                        where st.NgayGioChayMayNo.Month >= 4 && st.NgayGioChayMayNo.Month <= 6 && st.NgayGioChayMayNo.Year.ToString() == Nam
                                        select st;
                    }
                    else
                        if (Quy.Equals("3"))
                        {
                             listmayno = from st in tramContext.ChayMayNo
                                            where st.NgayGioChayMayNo.Month >= 7 && st.NgayGioChayMayNo.Month <= 9 && st.NgayGioChayMayNo.Year.ToString() == Nam
                                            select st;
                        }
                        else
                        {
                             listmayno = from st in tramContext.ChayMayNo
                                            where st.NgayGioChayMayNo.Month >= 10 && st.NgayGioChayMayNo.Month <= 12 && st.NgayGioChayMayNo.Year.ToString() == Nam
                                            select st;
                        }
            }
            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach (var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem("" + i);
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());

                listView1.Items.Add(item);
            }
        }     
        
        //Cap nhat danh sach thong ke theo hang

        void UpdatelistHang(string Hang)
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno = from s in tramContext.ChayMayNo
                        join sa in tramContext.Tram on s.TramId equals sa.TramId
                        where sa.Hang == Hang
                        select s;
            
            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach (var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem("" + i);
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());

                listView1.Items.Add(item);
            }
        }
        //Cap nhat danh sach thong ke theo Tram

        void UpdatelistTram(string Tram)
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno = from s in tramContext.ChayMayNo
                            join sa in tramContext.Tram on s.TramId equals sa.TramId
                            where sa.TenTram == Tram
                            select s;

            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach (var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem("" + i);
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());

                listView1.Items.Add(item);
            }
        }
        //Cap nhat danh sach thong ke theo so vi pham
        void UpdatelistVipham(string Vipham)
        {
            listView1.Items.Clear();
            int i = 0;
            var listmayno = from st in tramContext.ChayMayNo
                            where st.SoLanViPham.ToString() == Vipham
                            select st;
            var listtram = TramRepo.Get();
            string Tentram = null;
            string Tenhang = null;
            foreach (var mayno in listmayno)
            {
                foreach (var tram in listtram)
                {
                    if (mayno.TramId == tram.TramId)
                    {
                        Tentram = tram.TenTram;
                        Tenhang = tram.Hang;
                        break;
                    }
                }
                i++;
                ListViewItem item = new ListViewItem("" + i);
                item.SubItems.Add(mayno.TramId.ToString());
                item.SubItems.Add(Tentram);
                item.SubItems.Add(Tenhang);
                item.SubItems.Add(mayno.NgayGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoGioChayMayNo.ToString());
                item.SubItems.Add(mayno.SoLanViPham.ToString());

                listView1.Items.Add(item);
            }
        }
        //Thong ke theo yeu cau
        private void btnThongke_Click(object sender, EventArgs e)
        {
           
            
                if (!cmbNgay.Text.Equals("") && !cmbThang.Text.Equals("") && !cmbNam.Text.Equals("") && rdbNgay.Checked)
                {
                    string ngay = cmbNgay.Text + "/" + cmbThang.Text + "/" + cmbNam.Text;
                    DateTime date; //=DateTime.Today;
                    try
                    {

                        //date = Convert.ToDateTime(ngay, "dd/MM/yyyy");
                        date = new DateTime(Int32.Parse(cmbNam.Text), Int32.Parse(cmbThang.Text), Int32.Parse(cmbNgay.Text));
                        UpdatelistNgay(date);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi định dạng ngày","ERROR");
                    }
                    
                }
                else
                    if (!cmbThang.Text.Equals("") && !cmbNam.Text.Equals("")&&rdbThang.Checked)
                    {
                        UpdatelistThang(cmbThang.Text, cmbNam.Text);
                    }
                    else
                        if (!cmbNam.Text.Equals("")&&rdbNam.Checked)
                        {
                            UpdatelistNam(cmbNam.Text);
                        }                        
            
            else
                if(!cmbQuy.Text.Equals("")&&!cmbNam.Text.Equals("")&&rdbQuy.Checked)
                {
                   
                    UpdatelistQuy(cmbNam.Text,cmbQuy.Text);
                }
            else
                    if(!cmbHang.Text.Equals("")&&rdbHang.Checked)
                    {
                        UpdatelistHang(cmbHang.Text);
                    }
                    else
                        if (!cmbTram.Text.Equals("") && rdbTram.Checked)
                        {
                            UpdatelistTram(cmbTram.Text);
                        }
                        else
                            if (!txtSolanvipham.Text.Equals("")&&rdbVipham.Checked)
                            {
                                UpdatelistVipham(txtSolanvipham.Text);
                            }

        }
        //Cap nhat item
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateItem();
        }
        //Thong ke tat ca
        private void btnThongkeAll_Click(object sender, EventArgs e)
        {
            UpdateList();            
        }
        //Ham to mau
        void Tomau(int iditem)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
                if (listView1.Items[i].SubItems[iditem].Text.ToLower().Contains(txtTim.Text.ToLower()))
                {
                    listView1.Items[i].Selected = true;
                    listView1.Items[i].BackColor = Color.CornflowerBlue;
                }
                else
                {
                    listView1.Items[i].Selected = false;
                    listView1.Items[i].BackColor = Color.White;
                }
        }
        //button tim
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!txtTim.Text.Equals("") && !cmbTim.Text.Equals(""))
            {
                if (cmbTim.Text.Equals("Tên trạm"))
                {
                    Tomau(2);
                }
                else
                    if (cmbTim.Text.Equals("Mã trạm"))
                    {
                        Tomau(1);
                    }
                else
                        if (cmbTim.Text.Equals("Hãng"))
                        {
                            Tomau(3);
                        }
                else
                            if (cmbTim.Text.Equals("Ngày"))
                            {
                                for (int i = 0; i < listView1.Items.Count; i++)
                                    if (Convert.ToDateTime(listView1.Items[i].SubItems[4].Text)==Convert.ToDateTime(txtTim.Text))
                                    {
                                        listView1.Items[i].Selected = true;
                                        listView1.Items[i].BackColor = Color.CornflowerBlue;
                                    }
                                    else
                                    {
                                        listView1.Items[i].Selected = false;
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                            }
                else
                                if (cmbTim.Text.Equals("Số lần vi phạm"))
                                {
                                    Tomau(6);
                                }
                
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text.Equals("")||cmbTim.Text.Equals(""))
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Selected = false;
                    listView1.Items[i].BackColor = Color.White;
                }
                btnTim.Enabled = false;

            }
            else
                btnTim.Enabled = true;
        }

        private void cmbTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTim.Text.Equals("") || txtTim.Text.Equals(""))
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Selected = false;
                    listView1.Items[i].BackColor = Color.White;
                }
                btnTim.Enabled = false;

            }
            else
                btnTim.Enabled = true;
        }

        private void cmbHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!cmbHang.Text.Equals("")&&rdbHang.Checked)
            {
                btnThongke.Enabled=true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        private void cmbTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbTram.Text.Equals("")&&rdbTram.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        private void cmbNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbNgay.Text.Equals("") && !cmbThang.Text.Equals("") && !cmbNam.Text.Equals("")&&rdbNgay.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
            
        }

        private void rdbNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (!cmbNgay.Text.Equals("") && !cmbThang.Text.Equals("") && !cmbNam.Text.Equals("") && rdbNgay.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
            if(rdbNgay.Checked)
            {
                cmbNgay.Enabled = cmbThang.Enabled = cmbNam.Enabled = true;
                cmbQuy.Enabled = cmbHang.Enabled = cmbTram.Enabled = txtSolanvipham.Enabled = false;
            }
        }

        private void rdbThang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbThang.Checked)
            {
                cmbThang.Enabled = cmbNam.Enabled = true;
                cmbNgay.Enabled = cmbQuy.Enabled = cmbHang.Enabled = cmbTram.Enabled = txtSolanvipham.Enabled = false;
            }
            if (!cmbThang.Text.Equals("") && !cmbNam.Text.Equals("") && rdbThang.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        private void rdbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNam.Checked)
            {
                 cmbNam.Enabled = true;
                 cmbNgay.Enabled = cmbThang.Enabled = cmbQuy.Enabled = cmbHang.Enabled = cmbTram.Enabled = txtSolanvipham.Enabled = false;
            }
            if (!cmbNam.Text.Equals("") && rdbNam.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        private void rdbQuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbQuy.Checked)
            {
                cmbQuy.Enabled = cmbNam.Enabled = true;
                cmbNgay.Enabled = cmbThang.Enabled = cmbHang.Enabled = cmbTram.Enabled = txtSolanvipham.Enabled = false;
            }
            if (!cmbNam.Text.Equals("") && !cmbQuy.Text.Equals("") && rdbQuy.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        private void rdbHang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbHang.Checked)
            {
                cmbHang.Enabled = true;
                cmbNgay.Enabled = cmbThang.Enabled = cmbQuy.Enabled = cmbNam.Enabled = cmbTram.Enabled = txtSolanvipham.Enabled = false;
            }
            if (!cmbHang.Text.Equals("") && rdbHang.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        private void rdbTram_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTram.Checked)
            {
                cmbTram.Enabled = true;
                cmbNgay.Enabled = cmbThang.Enabled = cmbQuy.Enabled = cmbNam.Enabled = cmbHang.Enabled = txtSolanvipham.Enabled = false;
            }
            if (!cmbTram.Text.Equals("") && rdbTram.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        private void rdbVipham_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVipham.Checked)
            {
                txtSolanvipham.Enabled = true;
                cmbNgay.Enabled = cmbThang.Enabled = cmbQuy.Enabled = cmbNam.Enabled = cmbTram.Enabled = cmbHang.Enabled = false;
            }
        }

        private void txtSolanvipham_TextChanged(object sender, EventArgs e)
        {
            if (!txtSolanvipham.Text.Equals("") && rdbVipham.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtSolanvipham.Text, "[^0-9]"))
            {
                MessageBox.Show("Chỉ cho phép nhập số.");
                txtSolanvipham.Text = txtSolanvipham.Text.Remove(txtSolanvipham.Text.Length - 1);
                txtSolanvipham.Select(txtSolanvipham.Text.Length, 0);
            }
        }

       
        private void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbThang.Text.Equals("") && !cmbNam.Text.Equals("") && rdbThang.Checked)
            {
                btnThongke.Enabled = true;
                
            }
            else
            {
                if (!cmbNgay.Text.Equals("") && !cmbThang.Text.Equals("") && !cmbNam.Text.Equals("") && rdbNgay.Checked)
                {
                    btnThongke.Enabled = true;
                    
                }
                else
                {
                    btnThongke.Enabled = false;
                    
                }
            }
        }

        private void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbNam.Text.Equals("") && rdbNam.Checked)
            {
                btnThongke.Enabled = true;
                
            }
            else
            {
                if (!cmbNgay.Text.Equals("") && !cmbThang.Text.Equals("") && !cmbNam.Text.Equals("") && rdbNgay.Checked)
                {
                    btnThongke.Enabled = true;
                    
                }
                else

                    if (!cmbThang.Text.Equals("") && !cmbNam.Text.Equals("") && rdbThang.Checked)
                    {
                        btnThongke.Enabled = true;
                        
                    }
                    else

                        if (!cmbQuy.Text.Equals("") && !cmbNam.Text.Equals("") && rdbQuy.Checked)
                        {
                            btnThongke.Enabled = true;
                            
                        }
                        else
                        {
                            btnThongke.Enabled = false;
                            
                        }
            }

        }

        private void cmbQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbNam.Text.Equals("") &&!cmbQuy.Text.Equals("")&& rdbQuy.Checked)
            {
                btnThongke.Enabled = true;
            }
            else
            {
                btnThongke.Enabled = false;
            }
        }

        

        

        
 
    }
}
