using QLSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLSV.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }

        private string _UserName;
        public string UserName { get=>_UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get=>_Password; set { _Password = value; OnPropertyChanged(); } }



        public ICommand Button_Login_CMD { get; set; }
        public ICommand txt_Password_CMD { get; set; }




        public LoginViewModel()
        {
            Button_Login_CMD = new RelayCommand<Window> ((p) => { return true; }, (p) => { Login(p); });            
            txt_Password_CMD = new RelayCommand<PasswordBox> ((p) => { return true; }, (p) => { Password = p.Password; });            
        }
        void Login(Window p)
        {
            if (p == null) return;

            
            var Search_Acc = DataProvider.Ins.DB.DangNhaps.Where(x => x.TaiKhoan == UserName && x.MatKhau == Password).Count();

            if (Search_Acc > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Tài khoản hoặc mật khẩu chưa đúng!");
            }                      
        }
    }
}
