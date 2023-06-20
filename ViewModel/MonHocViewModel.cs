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
    public class MonHocViewModel: BaseViewModel
    {
        private ObservableCollection<MonHoc> _MonHocList;
        public ObservableCollection<MonHoc> MonHocList { get => _MonHocList; set { _MonHocList = value; OnPropertyChanged(); } }

        private ObservableCollection<GiangVien> _GiangVienList;
        public ObservableCollection<GiangVien> GiangVienList { get => _GiangVienList; set { _GiangVienList = value; OnPropertyChanged(); } }



        private MonHoc _SeletedItem;
        public MonHoc SelectedItem
        {
            get => _SeletedItem;
            set
            {
                _SeletedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {

                    Ma_Mon = SelectedItem.Ma_Mon;
                    TenMon = SelectedItem.TenMon;
                    SoChi = SelectedItem.SoChi;
                    SelectedGiangVien = SelectedItem.GiangVien;                  
                }
            }
        }

        private GiangVien _SelectedGiangVien;
        public GiangVien SelectedGiangVien
        {
            get => _SelectedGiangVien;
            set
            {
                _SelectedGiangVien = value;
                OnPropertyChanged();               
            }
        }

        private int _Ma_Mon;
        public int Ma_Mon { get => _Ma_Mon; set { _Ma_Mon = value; OnPropertyChanged(); } }

        private string _TenMon;
        public string TenMon { get => _TenMon; set { _TenMon = value; OnPropertyChanged(); } }

        private int _SoChi;
        public int SoChi { get => _SoChi; set { _SoChi = value; OnPropertyChanged(); } }

        private int _Ma_GV;
        public int Ma_GV { get => _Ma_GV; set { _Ma_GV = value; OnPropertyChanged(); } }

        public ICommand Button_Them_CMD { get; set; }
        public ICommand Button_Sua_CMD { get; set; }
        public MonHocViewModel()
        {
            MonHocList = new ObservableCollection<MonHoc>(DataProvider.Ins.DB.MonHocs);
            GiangVienList = new ObservableCollection<GiangVien>(DataProvider.Ins.DB.GiangViens);

            Button_Them_CMD = new RelayCommand<object>
            (
                (p) => 
                {
                    if (string.IsNullOrEmpty(Ma_Mon.ToString())) return false;                   

                    var displayList = DataProvider.Ins.DB.MonHocs.Where(x => x.Ma_Mon == Ma_Mon);
                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    if (SelectedGiangVien == null) return false;

                    return true;

                }, 
                (p) =>
                {
                    var MonHoc = new MonHoc()
                    {
                        Ma_Mon = Ma_Mon,
                        TenMon = TenMon,
                        SoChi = SoChi,
                        Ma_GV = SelectedGiangVien.Ma_GV                       
                    };
                    
                    DataProvider.Ins.DB.MonHocs.Add(MonHoc);
                    DataProvider.Ins.DB.SaveChanges();

                    MonHocList.Add(MonHoc);
                }
            );

            Button_Sua_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null)
                        return false;

                    if (SelectedGiangVien == null) return false;

                    var displayList = DataProvider.Ins.DB.MonHocs.Where(x => x.Ma_Mon == SelectedItem.Ma_Mon);

                    if (displayList != null && displayList.Count() != 0)
                        return true;

                    return false;
                },
                (p) =>
                {              
                    var MonHoc = DataProvider.Ins.DB.MonHocs.Where(x => x.Ma_Mon == SelectedItem.Ma_Mon).SingleOrDefault();
                    int Ma = MonHoc.Ma_Mon;
                    if (Ma_Mon == Ma)
                    {
                        MonHoc.Ma_Mon = Ma_Mon;
                        MonHoc.TenMon = TenMon;
                        MonHoc.SoChi = SoChi;
                        MonHoc.Ma_GV = SelectedGiangVien.Ma_GV;                       
                    }
                    else MessageBox.Show("Không thể thay đổi mã môn học");
                    DataProvider.Ins.DB.SaveChanges();
                }
            );
        }
    }
}