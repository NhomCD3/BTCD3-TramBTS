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
    public partial class ThongtinBTS : Form
    {
        TramContext tramContext;
        GenericRepository<Tram> tramRepo;
        public ThongtinBTS()
        {
            InitializeComponent();
            btnSua.Enabled = btnXoa.Enabled = false;
            tramContext = new TramContext();
            tramRepo = new GenericRepository<Tram>(tramContext);// chứa insert, update,delete.
            this.cmbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            btnSearch.Enabled = false;            
            UpdateList();
        }
        void UpdateList()
        {
            listView.Items.Clear();
            var list = tramRepo.Get(); //s => s.Hang == "vina"
            int i = 0;
            foreach (var bts in list)
            {
                ListViewItem item = new ListViewItem(bts.TenTram, i++);
                item.SubItems.Add(bts.TramId.ToString());
                item.SubItems.Add(bts.DiaChi);
                item.SubItems.Add(bts.Hang);
                item.SubItems.Add(bts.NamXayDung.ToString());
                item.SubItems.Add(bts.SoLanViPham.ToString());
                item.SubItems.Add(bts.QuangDuong.ToString());
                item.SubItems.Add(bts.GiaThue.ToString());
                listView.Items.Add(item);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "" && txtDiaChi.Text != "" && txtGiaThue.Text != "" && txtQuangDuong.Text != "" && cmbHang.Text != "" && cmbNam.Text != "")
            {
                string ten = this.txtTen.Text;
                string ma = this.txtMa.Text;
                string dc = this.txtDiaChi.Text;
                string hang = this.cmbHang.Text;
                string vp = "0";
                int nam = Int32.Parse(cmbNam.Text);
                float qd;
                try
                {
                    qd = Single.Parse(txtQuangDuong.Text);
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Quãng đường không hợp lệ !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int gia;
                try
                {
                    gia = Int32.Parse(txtGiaThue.Text);
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Giá thuê không hợp lệ !","Thông tin",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                Tram tram = new Tram();
                tram.TramId = ma;
                tram.TenTram = ten;
                tram.Hang = hang;
                tram.DiaChi = dc;
                tram.GiaThue = gia;
                tram.NamXayDung = nam;
                tram.QuangDuong = qd;
                tram.SoLanViPham = 0;
                try
                {
                    tramRepo.Insert(tram);
                    tramRepo.Save();
                }
                catch (Exception ex)
                {
                    tramRepo.Delete(tram);
                    MessageBox.Show("Error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //tramRepo.Save();
                UpdateList();
            }
            else
            {
                MessageBox.Show("Lỗi, vui lòng nhập giá trị vào các textbox", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection SelectedList;
            SelectedList = listView.SelectedItems;
            try
            {
                foreach (ListViewItem item in SelectedList)
                {
                    string ma = item.SubItems[1].Text;
                    tramRepo.Delete(ma);
                }
                tramRepo.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtGiaThue.Text = "";
            txtMa.Text = "";
            txtQuangDuong.Text = "";
            txtTen.Text = "";
            cmbHang.SelectedIndex=-1;
            cmbNam.SelectedIndex=-1;
            txtDiaChi.Enabled = true;
            txtGiaThue.Enabled = true;
            txtMa.Enabled = true;
            txtQuangDuong.Enabled = true;
            txtTen.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Tram tram = tramRepo.GetByID(txtMa.Text);
            tram.TenTram = txtTen.Text;
            tram.DiaChi = txtDiaChi.Text;
            tram.Hang = cmbHang.Text;
            tram.NamXayDung = Int32.Parse(cmbNam.Text);
            try
            {
                tram.QuangDuong = Single.Parse(txtQuangDuong.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Quãng đường không hợp lệ !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                tram.GiaThue = Int32.Parse(txtGiaThue.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Giá thuê không hợp lệ","Thông tin", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            try
            {
                tramRepo.Update(tram);
                tramRepo.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "" && cmbSearch.Text != "")
            {
                listView.SelectedItems.Clear();
                string chuoi = cmbSearch.Text;
                if (chuoi.Equals("Tên Trạm"))
                {
                    tomau(0);
                }
                else if (chuoi.Equals("Mã Trạm"))
                {
                    tomau(1);
                }
                else if (chuoi.Equals("Địa Chỉ"))
                {
                    tomau(2);
                }
                else if (chuoi.Equals("Hãng"))
                {
                    tomau(3);
                }
                else if (chuoi.Equals("Năm"))
                {
                    tomau(4);
                }
                else if (chuoi.Equals("Vi phạm"))
                {
                    tomau(5);
                }
                else if (chuoi.Equals("Quãng đường"))
                {
                    tomau(6);
                }
                else if (chuoi.Equals("Giá thuê"))
                {
                    tomau(7);
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập từ khóa cần tìm kiếm", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void tomau(int j)
        {
            for (int i = 0; i < listView.Items.Count; i++)
            {
                if (listView.Items[i].SubItems[j].Text.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    listView.Items[i].Selected = true;
                    listView.Items[i].BackColor = Color.Cyan;
                }
                else
                {
                    listView.Items[i].Selected = false;
                    listView.Items[i].BackColor = Color.White;
                }
            }
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection SelectedList;
            SelectedList = listView.SelectedItems;
            if(SelectedList.Count==0)
            {
                btnReset_Click(null, null);
            }
            else
            {
                btnSua.Enabled = btnXoa.Enabled = true;
                btnThem.Enabled = false;
            }
            
            foreach (ListViewItem item in SelectedList)
            {
                string ten = item.SubItems[0].Text;
                string ma = item.SubItems[1].Text;
                string dc = item.SubItems[2].Text;
                string hang = item.SubItems[3].Text;
                string nam = item.SubItems[4].Text;
                string vp = item.SubItems[5].Text;
                string qd = item.SubItems[6].Text;
                string gia = item.SubItems[7].Text;
                txtTen.Text = ten;
                txtMa.Text = ma;
                txtDiaChi.Text = dc;
                cmbHang.Text = hang;
                cmbNam.Text = nam;
                txtQuangDuong.Text = qd;
                txtGiaThue.Text = gia;
                txtMa.Enabled = false;
            }
        }

        private void txtGiaThue_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtGiaThue.Text, @"[^0-9]+$"))
            {
                MessageBox.Show("Please enter only numbers.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaThue.Text = txtGiaThue.Text.Remove(txtGiaThue.Text.Length - 1);
                txtGiaThue.Select(txtGiaThue.Text.Length, 0);
            }
        }

        private void txtQuangDuong_TextChanged(object sender, EventArgs e)
        {
            if (txtQuangDuong.Text.Length != 0)
            {
                try
                {
                    float x = Single.Parse(txtQuangDuong.Text);
                    if (x < 0)
                    {
                        MessageBox.Show("Nhập số không âm", "Error");
                        txtQuangDuong.Text = txtQuangDuong.Text.Remove(0);
                        txtQuangDuong.Select(txtQuangDuong.Text.Length, 0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error");
                    txtQuangDuong.Text = txtQuangDuong.Text.Remove(txtQuangDuong.Text.Length - 1);
                    txtQuangDuong.Select(txtQuangDuong.Text.Length, 0);
                }
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            txtMa.MaxLength = 50;
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMa.Text, @"[^a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã không được chứa kí tự đặc biệt!", "Error");
                txtMa.Text = txtMa.Text.Remove(txtMa.Text.Length - 1);
                txtMa.Select(txtMa.Text.Length, 0);
            }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            txtTen.MaxLength = 50;
        }

        public void UpdateSoLanViPham(string tramId)
        {
            Tram tram = tramRepo.GetByID(tramId);
            var query = from s in tramContext.ChayMayNo
                        where s.TramId == tramId && s.SoLanViPham == 1
                        select s;
            int soLanViPham = query.Count();
            tram.SoLanViPham = soLanViPham;
            try
            {
                tramRepo.Update(tram);
                tramRepo.Save();
                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                btnSearch.Enabled = true;
            }
            else { btnSearch.Enabled = false; }
        }
    }
}
