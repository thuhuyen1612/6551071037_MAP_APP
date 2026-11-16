using HotelManagement.DangNhap;

namespace HotelManagement
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            HienThiThongTinNguoiDung();
        }

        private void linkLabel1_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            this.Hide();
            using (var formLogin = new FormDangNhap())
            {
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    HienThiThongTinNguoiDung();
                    ApDungPhanQuyen();
                    HienThiTrangChu();
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button13_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new ThongKe.FormThongKe());
        }

        private void btnTrangChu_Click(object? sender, EventArgs e)
        {
            HienThiTrangChu();
        }

        private void button5_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new TaiKhoan.FormDanhSachTaiKhoan());
        }

        private void button4_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new LoaiPhong.FormDanhSachLoaiPhong());
        }

        private void button7_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new NhanVien.FormDanhSachNhanVien());
        }

        private void button6_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new KhachHang.FormDanhSachKhachHang());
        }

        private void btnQuanLyPhong_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new Phong.FormDanhSachPhong());
        }

        private void button12_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new TienNghi.FormDanhSachTienNghi());
        }

        private void button11_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new DichVu.FormDanhSachDichVu());
        }

        private void btnSoDoPhong_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new SoDoPhong.FormSoDoPhong());
        }

        private void button9_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new DatPhong.FormDanhSachDatPhong());
        }

        private void button10_Click(object? sender, EventArgs e)
        {
            LoadFormCon(new HoaDon.FormDanhSachHoaDon());
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            ApDungPhanQuyen();
            HienThiTrangChu();
        }

        private void ApDungPhanQuyen()
        {
            int quyen = FormDangNhap.CapDoQuyen_DangNhap;
            if (quyen == 1)
            {
                button5.Visible = false;
                button7.Visible = false;
            }
            else if (quyen == 2)
            {
                button5.Visible = false;
                button7.Visible = true;
            }
            else
            {
                button5.Visible = true;
                button7.Visible = true;
            }
        }

        private void HienThiThongTinNguoiDung()
        {
            lblTenNguoiDung.Text = FormDangNhap.TenNV_DangNhap;
            lblTenNguoiDung.Left = (panel2.Width - lblTenNguoiDung.PreferredWidth) / 2;
        }

        private void XoaNoiDungPanelMain()
        {
            foreach (Control c in panelMain.Controls.Cast<Control>().ToList())
            {
                panelMain.Controls.Remove(c);
                c.Dispose();
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            XoaNoiDungPanelMain();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void LoadFormCon(Form formCon)
        {
            XoaNoiDungPanelMain();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void HienThiTrangChu()
        {
            if (panelMain.Controls.Count == 1 && panelMain.Controls[0] is FormTrangChu)
                return;
            LoadUserControl(new FormTrangChu());
        }

        private void HienThiDangPhatTrien(string tenChucNang)
        {
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Text = tenChucNang + Environment.NewLine + "(chức năng đang được xây dựng)",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Italic),
                ForeColor = Color.DarkCyan,
                TextAlign = ContentAlignment.MiddleCenter
            });
        }
    }
}
