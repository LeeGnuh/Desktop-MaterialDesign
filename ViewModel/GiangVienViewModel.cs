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
    public class GiangVienViewModel : BaseViewModel
    {
        private ObservableCollection<GiangVien> _GiangVienList;
        public ObservableCollection<GiangVien> GiangVienList { get => _GiangVienList; set { _GiangVienList = value; OnPropertyChanged(); } }

        private GiangVien _SeletedItem;
        public GiangVien SelectedItem
        {
            get => _SeletedItem;
            set
            {
                _SeletedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Ma_GV = SelectedItem.Ma_GV;
                    HoTen = SelectedItem.HoTen;
                    GioiTinh = SelectedItem.GioiTinh;
                    NgaySinh = SelectedItem.NgaySinh;
                    DiaChi = SelectedItem.DiaChi;
                    SDT = SelectedItem.SDT;
                    Email = SelectedItem.Email;
                }
            }
        }

        private int _Ma_GV;
        public int Ma_GV { get => _Ma_GV; set { _Ma_GV = value; OnPropertyChanged(); } }

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

        public ICommand Button_Them_CMD { get; set; }
        public ICommand Button_Sua_CMD { get; set; }
        public GiangVienViewModel()
        {
            GiangVienList = new ObservableCollection<GiangVien>(DataProvider.Ins.DB.GiangViens);

            Button_Them_CMD = new RelayCommand<object>
            (
                (p) => 
                {
                    if (string.IsNullOrEmpty(Ma_GV.ToString())) return false;                   

                    var displayList = DataProvider.Ins.DB.GiangViens.Where(x => x.Ma_GV == Ma_GV);
                    if (displayList == null || displayList.Count() != 0)
                        return false;
                    return true;

                }, 
                (p) =>
                {                   
                    var GiangVien = new GiangVien()
                    {                       
                        Ma_GV = Ma_GV,
                        HoTen = HoTen,
                        GioiTinh = GioiTinh, 
                        NgaySinh = (DateTime)NgaySinh, 
                        DiaChi = DiaChi, 
                        SDT = SDT, 
                        Email = Email
                    };
                    
                    DataProvider.Ins.DB.GiangViens.Add(GiangVien);
                    DataProvider.Ins.DB.SaveChanges();

                    GiangVienList.Add(GiangVien);
                }
            );

            Button_Sua_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null)
                        return false;

                    var displayList = DataProvider.Ins.DB.GiangViens.Where(x => x.Ma_GV == SelectedItem.Ma_GV);

                    if (displayList != null && displayList.Count() != 0)
                        return true;

                    return false;
                },
                (p) =>
                {              
                    var GiangVien = DataProvider.Ins.DB.GiangViens.Where(x => x.Ma_GV == SelectedItem.Ma_GV).SingleOrDefault();
                    int Ma = GiangVien.Ma_GV;
                    if (Ma_GV == Ma)
                    {
                        GiangVien.Ma_GV = Ma_GV;
                        GiangVien.HoTen = HoTen;
                        GiangVien.GioiTinh = GioiTinh;
                        GiangVien.NgaySinh = NgaySinh;
                        GiangVien.DiaChi = DiaChi;
                        GiangVien.SDT = SDT;
                        GiangVien.Email = Email;
                    }
                    else MessageBox.Show("Không thể thay đổi mã giáo viên");
                    DataProvider.Ins.DB.SaveChanges();
                }
            );
        }
    }
}
