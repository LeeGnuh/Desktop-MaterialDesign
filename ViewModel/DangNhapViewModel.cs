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
    public class DangNhapViewModel : BaseViewModel
    {
        private ObservableCollection<DangNhap> _DangNhapList;
        public ObservableCollection<DangNhap> DangNhapList { get => _DangNhapList; set { _DangNhapList = value; OnPropertyChanged(); } }

        private DangNhap _SeletedItem;
        public DangNhap SelectedItem
        {
            get => _SeletedItem;
            set
            {
                _SeletedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Ten = SelectedItem.Ten;
                    TaiKhoan = SelectedItem.TaiKhoan;
                    MatKhau = SelectedItem.MatKhau;
                    Cap_TK = SelectedItem.Cap_TK;
                }
            }
        }
       
        private string _Ten;
        public string Ten { get => _Ten; set { _Ten = value; OnPropertyChanged(); } }

        private string _TaiKhoan;
        public string TaiKhoan { get => _TaiKhoan; set { _TaiKhoan = value; OnPropertyChanged(); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }

        public Nullable<bool> _Cap_TK;
        public Nullable<bool> Cap_TK { get => _Cap_TK; set { _Cap_TK = value; OnPropertyChanged(); } }

        public ICommand Button_Them_CMD { get; set; }
        public ICommand Button_Sua_CMD { get; set; }
        public ICommand Button_Xoa_CMD { get; set; }
        public DangNhapViewModel()
        {
            DangNhapList = new ObservableCollection<DangNhap>(DataProvider.Ins.DB.DangNhaps);

            Button_Them_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (string.IsNullOrEmpty(Ten)) return false;

                    var displayList = DataProvider.Ins.DB.DangNhaps.Where(x => x.Ten == Ten);
                    if (displayList == null || displayList.Count() != 0)
                        return false;
                    return true;

                },
                (p) =>
                {
                    var DangNhap = new DangNhap()
                    {
                        Ten = Ten,
                        TaiKhoan = TaiKhoan,
                        MatKhau = MatKhau,
                        Cap_TK = Cap_TK
                    };

                    DataProvider.Ins.DB.DangNhaps.Add(DangNhap);
                    DataProvider.Ins.DB.SaveChanges();

                    DangNhapList.Add(DangNhap);
                }
            );

            Button_Sua_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.DangNhaps.Where(x => x.Ten == SelectedItem.Ten);

                    if (displayList != null && displayList.Count() != 0)
                        return true;

                    return false;
                },
                (p) =>
                {
                    var DangNhap = DataProvider.Ins.DB.DangNhaps.Where(x => x.Ten == SelectedItem.Ten).SingleOrDefault();
                    string T = DangNhap.Ten;
                    string TK = DangNhap.TaiKhoan;
                    if (T == Ten && TK == TaiKhoan)
                    {
                        DangNhap.Ten = Ten;
                        DangNhap.TaiKhoan = TaiKhoan;
                        DangNhap.MatKhau = MatKhau;
                        DangNhap.Cap_TK = Cap_TK;
                    }
                    else MessageBox.Show("Không thể thay đổi tài khoản hoặc tên của tài khoản");
                    DataProvider.Ins.DB.SaveChanges();
                }
            );

            Button_Xoa_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null)
                        return false;

                    return true; 
                },
                (p) =>
                {
                    DataProvider.Ins.DB.DangNhaps.Remove(SelectedItem);
                    DataProvider.Ins.DB.SaveChanges();

                    DangNhapList.Remove(SelectedItem);
                }
            );
        }
    }
}
