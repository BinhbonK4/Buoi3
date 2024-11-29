using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Tạo ListView với 3 cột: First Name, Last Name, Phone
            lvNhanVien.View = View.Details;
            lvNhanVien.FullRowSelect = true;
            lvNhanVien.GridLines = true;

            // Thêm cột vào ListView
            lvNhanVien.Columns.Add("First Name", 150);
            lvNhanVien.Columns.Add("Last Name", 150);
            lvNhanVien.Columns.Add("Phone", 120);

            // Hiển thị thông tin được chọn
            lvNhanVien.SelectedIndexChanged += lvNhanVien_SelectedIndexChanged;

        }

        private bool KiemTRaThongTinNhap()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTRaThongTinNhap()) return;

            // Thêm một dòng mới vào ListView
            ListViewItem item = new ListViewItem(txtFirstName.Text); // First Name
            item.SubItems.Add(txtLastName.Text); // Last Name
            item.SubItems.Add(txtPhone.Text); // Phone

            lvNhanVien.Items.Add(item);

            // Xóa trống các textbox sau khi thêm
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                // Xóa dòng được chọn
                lvNhanVien.Items.Remove(lvNhanVien.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                if (!KiemTRaThongTinNhap()) return;

                // Lấy dòng được chọn
                ListViewItem selectedItem = lvNhanVien.SelectedItems[0];

                // Cập nhật dữ liệu cho dòng được chọn
                selectedItem.Text = txtFirstName.Text; // First Name
                selectedItem.SubItems[1].Text = txtLastName.Text; // Last Name
                selectedItem.SubItems[2].Text = txtPhone.Text; // Phone

                // Xóa trống các textbox sau khi sửa
                txtFirstName.Clear();
                txtLastName.Clear();
                txtPhone.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng được chọn
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvNhanVien.SelectedItems[0];
                txtFirstName.Text = selectedItem.Text; // First Name
                txtLastName.Text = selectedItem.SubItems[1].Text; // Last Name
                txtPhone.Text = selectedItem.SubItems[2].Text; // Phone
            }
        }
    }
}
