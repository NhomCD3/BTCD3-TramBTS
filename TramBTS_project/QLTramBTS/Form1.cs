using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTramBTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setupData_reset();
            this.Load += Form1_Load;
        }
        private bool isInit = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            isInit = true;
        }

        // thay doi combobox ngay
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void setupData_reset()
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            ComboboxItem itemall1 = new ComboboxItem();
            itemall1.Text = "All";
            itemall1.Value = "All";
            comboBox1.Items.Add(itemall1);
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add(itemall1);
            comboBox2.SelectedIndex = 0;
            comboBox3.Items.Add(itemall1);
            comboBox3.SelectedIndex = 0;
            comboBox5.Items.Add(itemall1);
            comboBox5.SelectedIndex = 0;
            for (int i = 1; i <= 30; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = "Ngay " + i;
                item.Value = i;
                comboBox1.Items.Add(item);
            }
            for (int i = 1; i <= 12; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = "Thang " + i;
                item.Value = i;
                comboBox2.Items.Add(item);
            }
            for (int i = 1; i <= 4; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = "Qui " + i;
                item.Value = i;
                comboBox3.Items.Add(item);
            }

            for (int i = 2005; i <= 2015; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = "Nam " + i;
                item.Value = i;
                comboBox4.Items.Add(item);
            }
            comboBox4.SelectedIndex = 0;
            // setup data cho tram

            TramContext tramContext = new TramContext();
            var querytram = from st in tramContext.Tram
                            select st;
            foreach (var tram in querytram)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = tram.TenTram;
                item.Value = tram.TramId;
                comboBox5.Items.Add(item);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool checkValidateInput()
        {
            string gia_dau = giadau.Text;
            string he_so = heso.Text;
            string gia_xang = giaxang.Text;
            if (gia_dau == "" || he_so == "" || gia_xang == "")
            {
                return false;
            }
            float f;
            if (float.TryParse(gia_dau, out f) && float.TryParse(he_so, out f) && float.TryParse(gia_xang, out f))
            {
                return true;
            }
            return false;
        }
        class ItemTram
        {
            public ItemTram(string name, string tiendau, string tienxangxe, string diachi, float quangduong)
            {
                this.Name = name;
                this.TienDau = tiendau;
                this.TienXangXe = tienxangxe;
                this.DiaChi = diachi;
                this.QuangDuong = quangduong;
            }
            public string Name { set; get; }
            public string TienDau { set; get; }
            public string TienXangXe { set; get; }
            public string DiaChi { set; get; }
            public float QuangDuong { set; get; }
        }
        private void addOrUpdateItem(string name, string tiendau, string tienxang, string diachi, float quangduong)
        {
            bool isExit = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    isExit = true;
                    int combine = int.Parse(items[i].TienDau) + int.Parse(tiendau);
                    int combine_1 = int.Parse(items[i].TienXangXe) + int.Parse(tienxang);
                    items[i].TienDau = "" + combine;
                    items[i].TienXangXe = "" + combine_1;
                }
            }
            if (!isExit)
            {
                items.Add(new ItemTram(name, tiendau, tienxang, diachi, quangduong));
            }
        }
        private List<ItemTram> items = new List<ItemTram>();
        private void tinhGiaDauChayMayNo(IQueryable<ChayMayNo> L2EQuery)
        {
            this.items.Clear();
            this.listView1.Items.Clear();
            TramContext tramContext = new TramContext();
            float tg = 0;
            float totalKm = 0;
            foreach (var item in L2EQuery)
            {
                Debug.Write("|" + item.NgayGioChayMayNo);
                tg += item.SoGioChayMayNo;
                var ss = from st in tramContext.Tram
                         where st.TramId == item.TramId
                         select st;
                var tram = ss.FirstOrDefault<Tram>();
                string giax = int.Parse(giaxang.Text) * tram.QuangDuong + "";
                string giad = int.Parse(giadau.Text) * (item.SoGioChayMayNo * int.Parse(heso.Text)) + "";
                this.addOrUpdateItem(tram.TenTram, giad, giax, tram.DiaChi, tram.QuangDuong);
                totalKm += tram.QuangDuong;
            }
            tb_tienxang.Text = int.Parse(giaxang.Text) * totalKm + "";
            float tien = float.Parse(giadau.Text) * (tg * float.Parse(heso.Text));
            tienmayno.Text = "" + tien;

            foreach (var item in items)
            {
                ListViewItem itm;
                //add items to ListView
                string[] arr = new string[6];
                arr[0] = item.Name;
                arr[1] = item.TienDau;
                arr[2] = item.TienXangXe;
                arr[3] = (int.Parse(item.TienDau) + int.Parse(item.TienXangXe)) + "";
                arr[4] = item.DiaChi;
                arr[5] = item.QuangDuong + "";
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkValidateInput())
            {
                MessageBox.Show("Nhập dữ liệu không đúng");
                return;
            }

            TramContext tramContext = new TramContext();
            string day = ((ComboboxItem)comboBox1.SelectedItem == null) ? "All" : ((ComboboxItem)comboBox1.SelectedItem).Value.ToString();
            string month = ((ComboboxItem)comboBox2.SelectedItem == null) ? "All" : ((ComboboxItem)comboBox2.SelectedItem).Value.ToString();
            //string year = comboBox4.Items[comboBox4.SelectedIndex].ToString();
            string year = ((ComboboxItem)comboBox4.SelectedItem).Value.ToString();
            string quarter = ((ComboboxItem)comboBox3.SelectedItem == null) ? "All" : ((ComboboxItem)comboBox3.SelectedItem).Value.ToString();
            string tram = ((ComboboxItem)comboBox5.SelectedItem == null) ? "All" : ((ComboboxItem)comboBox5.SelectedItem).Value.ToString();

            int year_num = int.Parse(year);


            if (day == "All" && month == "All" && quarter != "All" && tram == "All")
            {
                int quar_num = int.Parse(quarter);
                DateTime startTime = getStartDistanceTimeByQuarter(quar_num, year_num);
                DateTime endTime = getLastDistanceTimeByQuarter(quar_num, year_num);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo >= startTime && st.NgayGioChayMayNo <= endTime
                               select st;
                tinhGiaDauChayMayNo(L2EQuery);
            }
            else if (day == "All" && month == "All" && quarter != "All" && tram != "All")
            {
                int quar_num = int.Parse(quarter);
                DateTime startTime = getStartDistanceTimeByQuarter(quar_num, year_num);
                DateTime endTime = getLastDistanceTimeByQuarter(quar_num, year_num);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo >= startTime && st.NgayGioChayMayNo <= endTime && st.TramId == tram
                               select st;
                tinhGiaDauChayMayNo(L2EQuery);
            }
            else if (day == "All" && month == "All" && tram == "All")
            {
                string date = "1/1/" + year;
                DateTime dt_zero = Convert.ToDateTime(date);
                DateTime dtAddOneYear = dt_zero.AddYears(1);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo >= dt_zero && st.NgayGioChayMayNo <= dtAddOneYear
                               select st;
                tinhGiaDauChayMayNo(L2EQuery);
            }
            else if (day == "All" && month == "All" && tram != "All")
            {

                string date = "1/1/" + year;
                DateTime dt_zero = Convert.ToDateTime(date);
                DateTime dtAddOneYear = dt_zero.AddYears(1);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo >= dt_zero && st.NgayGioChayMayNo <= dtAddOneYear && st.TramId == tram
                               select st;
                tinhGiaDauChayMayNo(L2EQuery);
            }
            else if (day == "All" && tram == "All")
            {
                string date = month + "/1" + "/" + year;
                DateTime dt_zero = Convert.ToDateTime(date);
                DateTime dtAddOneMonth = dt_zero.AddMonths(1);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo >= dt_zero && st.NgayGioChayMayNo <= dtAddOneMonth
                               select st;

                tinhGiaDauChayMayNo(L2EQuery);
            }
            else if (day == "All" && tram != "All")
            {
                string date = month + "/1" + "/" + year;
                DateTime dt_zero = Convert.ToDateTime(date);
                DateTime dtAddOneMonth = dt_zero.AddMonths(1);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo >= dt_zero && st.NgayGioChayMayNo <= dtAddOneMonth && st.TramId == tram
                               select st;

                tinhGiaDauChayMayNo(L2EQuery);
            }
            else if (tram == "All")
            {
                string date = month + "/" + day + "/" + year;
                DateTime dt = Convert.ToDateTime(date);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo == dt
                               select st;
            }
            else if (tram != "All")
            {
                string date = month + "/" + day + "/" + year;
                DateTime dt = Convert.ToDateTime(date);
                var L2EQuery = from st in tramContext.ChayMayNo
                               where st.NgayGioChayMayNo == dt && st.TramId == tram
                               select st;
            }



        }
        private DateTime getStartDistanceTimeByQuarter(int quarter, int year)
        {
            DateTime time;
            switch (quarter)
            {
                case 1:
                    time = new DateTime(year, 1, 1, 0, 0, 0); break;
                case 2:
                    time = new DateTime(year, 4, 1, 0, 0, 0); break;
                case 3:
                    time = new DateTime(year, 7, 1, 0, 0, 0); break;
                default:
                    time = new DateTime(year, 10, 1, 0, 0, 0); break;
            }
            return time;
        }
        private DateTime getLastDistanceTimeByQuarter(int quarter, int year)
        {
            DateTime time;
            switch (quarter)
            {
                case 1:
                    time = new DateTime(year, 3, 31, 0, 0, 0); break;
                case 2:
                    time = new DateTime(year, 6, 30, 0, 0, 0); break;
                case 3:
                    time = new DateTime(year, 9, 30, 0, 0, 0); break;
                default:
                    time = new DateTime(year, 12, 31, 0, 0, 0); break;
            }
            return time;
        }
        private void setQuarterAgain(int qui, bool isFull = false)
        {
            if (isFull)
            {
                comboBox3.Items.Clear();
                ComboboxItem item_all = new ComboboxItem();
                item_all.Text = "All";
                item_all.Value = "All";
                comboBox3.Items.Add(item_all);
                for (int i = 1; i <= 4; i++)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = "Qui " + i;
                    item.Value = i;
                    comboBox3.Items.Add(item);
                }
            }
            else
            {
                comboBox3.Items.Clear();

                ComboboxItem item1 = new ComboboxItem();
                item1.Text = "All";
                item1.Value = "All";
                comboBox3.Items.Add(item1);

                ComboboxItem item = new ComboboxItem();
                item.Text = "Qui " + qui;
                item.Value = qui;
                comboBox3.Items.Add(item);
            }

        }
        private void setLimitDayAgain(int month)
        {
            int count_day_limit = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    count_day_limit = 31; break;
                case 2:
                    count_day_limit = 29; break;
                default: count_day_limit = 30; break;
            }

            comboBox1.Items.Clear();
            for (int i = 1; i <= count_day_limit; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = "Ngay " + i;
                item.Value = i;
                comboBox1.Items.Add(item);
            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInit) return;
            string month = ((ComboboxItem)comboBox2.SelectedItem).Value.ToString();
            if (month != "All")
            {
                int month_num = int.Parse(month);
                setLimitDayAgain(month_num);
                switch (month_num)
                {
                    case 1:
                    case 2:
                    case 3:
                        setQuarterAgain(1); break;
                    case 4:
                    case 5:
                    case 6:
                        setQuarterAgain(2); break;
                    case 7:
                    case 8:
                    case 9:
                        setQuarterAgain(3); break;
                    default:
                        setQuarterAgain(4); break;

                }
            }
            else
            {
                setQuarterAgain(0, true);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
