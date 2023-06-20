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
    public class SinhVienViewModel : BaseViewModel
    {
        private ObservableCollection<SinhVien> _SinhVienList;
        public ObservableCollection<SinhVien> SinhVienList { get => _SinhVienList; set { _SinhVienList = value; OnPropertyChanged(); } }
        
        private ObservableCollection<LopSH> _LopSHList;
        public ObservableCollection<LopSH> LopSHList { get => _LopSHList; set { _LopSHList = value; OnPropertyChanged(); } }

        private SinhVien _SeletedItem;
        public SinhVien SelectedItem
        {
            get => _SeletedItem;
            set
            {
                _SeletedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Ma_SV = SelectedItem.Ma_SV;
                    HoTen = SelectedItem.HoTen;
                    GioiTinh = SelectedItem.GioiTinh;
                    NgaySinh = SelectedItem.NgaySinh;
                    DiaChi = SelectedItem.DiaChi;
                    SDT = SelectedItem.SDT;
                    Email = SelectedItem.Email;
                    SelectedLopSH = SelectedItem.LopSH;                    
                }
            }
        }

        private LopSH _SelectedLopSH;
        public LopSH SelectedLopSH
        {
            get => _SelectedLopSH;
            set
            {
                _SelectedLopSH = value;
                OnPropertyChanged();
            }
        }

        private int _Ma_SV;
        public int Ma_SV { get => _Ma_SV; set { _Ma_SV = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }

        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _Ma_Lop;
        public string Ma_Lop { get => _Ma_Lop; set { _Ma_Lop = value; OnPropertyChanged(); } }

        public ICommand Button_Them_CMD { get; set; }
        public ICommand Button_Sua_CMD { get; set; }
        public SinhVienViewModel()
        {
            SinhVienList = new ObservableCollection<SinhVien>(DataProvider.Ins.DB.SinhViens);
            LopSHList = new ObservableCollection<LopSH>(DataProvider.Ins.DB.LopSHes);

            Button_Them_CMD = new RelayCommand<object>
            (
                (p) => 
                {
                    if (string.IsNullOrEmpty(Ma_SV.ToString())) return false;
                    if (SelectedLopSH == null) return false;

                    var displayList = DataProvider.Ins.DB.SinhViens.Where(x => x.Ma_SV == Ma_SV);
                    if (displayList == null || displayList.Count() != 0) return false;                                      

                    return true;
                },
                (p) =>
                {
                    var SinhVien = new SinhVien()
                    {
                        Ma_SV = Ma_SV,
                        HoTen = HoTen,
                        GioiTinh = GioiTinh,
                        NgaySinh = (DateTime)NgaySinh,
                        DiaChi = DiaChi,
                        SDT = SDT,
                        Email = Email,
                        Ma_Lop = SelectedLopSH.Ma_Lop
                    };

                    DataProvider.Ins.DB.SinhViens.Add(SinhVien);
                    DataProvider.Ins.DB.SaveChanges();

                    SinhVienList.Add(SinhVien);
                }
            );

            Button_Sua_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null)  return false;
                    if (SelectedLopSH == null) return false;

                    var displayList = DataProvider.Ins.DB.SinhViens.Where(x => x.Ma_SV == SelectedItem.Ma_SV);
                    if (displayList != null && displayList.Count() != 0) return true;

                    return false;
                },
                (p) =>
                {
                    var SinhVien = DataProvider.Ins.DB.SinhViens.Where(x => x.Ma_SV == SelectedItem.Ma_SV).SingleOrDefault();
                    int Ma = SinhVien.Ma_SV;
                    if (Ma_SV == Ma)
                    {
                        SinhVien.Ma_SV = Ma_SV;
                        SinhVien.HoTen = HoTen;
                        SinhVien.GioiTinh = GioiTinh;
                        SinhVien.NgaySinh = NgaySinh;
                        SinhVien.DiaChi = DiaChi;
                        SinhVien.SDT = SDT;
                        SinhVien.Email = Email;
                        SinhVien.Ma_Lop = SelectedLopSH.Ma_Lop;
                    }
                    else MessageBox.Show("Không thể thay đổi mã sinh viên");
                    DataProvider.Ins.DB.SaveChanges();
                }
            );
        }
    }
}
