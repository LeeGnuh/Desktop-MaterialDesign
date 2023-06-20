using QLSV.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLSV.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand MenuSearch_CMD { get; set; }
        public ICommand MenuSinhVien_CMD { get; set; }
        public ICommand MenuGiangVien_CMD { get; set; }
        public ICommand MenuMonHoc_CMD { get; set; }
        public ICommand MenuTaiKhoan_CMD { get; set; }
        public ICommand MenuLopSH_CMD { get; set; }
        public ICommand LogOut_CMD { get; set; }
 
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>
            ((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null) return;
                p.Hide();
                QLSV.LoginWindow loginWindow = new QLSV.LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null) return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });
            MenuSearch_CMD = new RelayCommand<object>((p) => { return true; }, (p) => { DiemWindow wd = new DiemWindow(); wd.ShowDialog(); });
            MenuSinhVien_CMD = new RelayCommand<object>((p) => { return true; }, (p) => { SinhVienWindow wd = new SinhVienWindow(); wd.ShowDialog(); });
            MenuGiangVien_CMD = new RelayCommand<object>((p) => { return true; }, (p) => { GiangVienWindow wd = new GiangVienWindow(); wd.ShowDialog(); });
            MenuMonHoc_CMD = new RelayCommand<object>((p) => { return true; }, (p) => { MonHocWindow wd = new MonHocWindow(); wd.ShowDialog(); });
            MenuTaiKhoan_CMD = new RelayCommand<object>((p) => { return true; }, (p) => { TaiKhoanWindow wd = new TaiKhoanWindow(); wd.ShowDialog(); });
            MenuLopSH_CMD = new RelayCommand<object>((p) => { return true; }, (p) => { LopSHWindow wd = new LopSHWindow(); wd.ShowDialog(); });
            
            LogOut_CMD = new RelayCommand<Window>
            ((p) => { return true; }, (p) =>
            {
                p.Close();
                               
                QLSV.LoginWindow loginWindow = new QLSV.LoginWindow();
                loginWindow.ShowDialog();
                
            }); 
        }       
    }
}
