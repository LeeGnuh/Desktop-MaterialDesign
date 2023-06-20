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
    public class DiemViewModel : BaseViewModel
    {
        private ObservableCollection<PhieuDiem> _PhieuDiemList;
        public ObservableCollection<PhieuDiem> PhieuDiemList { get => _PhieuDiemList; set { _PhieuDiemList = value; OnPropertyChanged(); } }

        private ObservableCollection<SinhVien> _SinhVienList;
        public ObservableCollection<SinhVien> SinhVienList { get => _SinhVienList; set { _SinhVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<MonHoc> _MonHocList;
        public ObservableCollection<MonHoc> MonHocList { get => _MonHocList; set { _MonHocList = value; OnPropertyChanged(); } }

        private ObservableCollection<GiangVien> _GiangVienList;
        public ObservableCollection<GiangVien> GiangVienList { get => _GiangVienList; set { _GiangVienList = value; OnPropertyChanged(); } }



        private PhieuDiem _SeletedItem;
        public PhieuDiem SelectedItem
        {
            get => _SeletedItem;
            set
            {
                _SeletedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Ma_Phieu = SelectedItem.Ma_Phieu;                   
                    SelectedSinhVien = SelectedItem.SinhVien;
                    SelectedMonHoc = SelectedItem.MonHoc;
                    ChuyenCan = SelectedItem.ChuyenCan;
                    GiuaKy = SelectedItem.GiuaKy;
                    CuoiKy = SelectedItem.CuoiKy;
                    SelectedGiangVien = SelectedItem.GiangVien;
                }
            }
        }

        private SinhVien _SelectedSinhVien;
        public SinhVien SelectedSinhVien
        {
            get => _SelectedSinhVien;
            set
            {
                _SelectedSinhVien = value;
                OnPropertyChanged();
            }
        }

        private MonHoc _SelectedMonHoc;    
        public MonHoc SelectedMonHoc
        {
            get => _SelectedMonHoc;
            set
            {
                _SelectedMonHoc = value;
                OnPropertyChanged();
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
        
        private int _Ma_Phieu;
        public int Ma_Phieu { get => _Ma_Phieu; set { _Ma_Phieu = value; OnPropertyChanged(); } }

        private int _Ma_SV;
        public int Ma_SV { get => _Ma_SV; set { _Ma_SV = value; OnPropertyChanged(); } }

        private int _Ma_Mon;
        public int Ma_Mon { get => _Ma_Mon; set { _Ma_Mon = value; OnPropertyChanged(); } }

        private double? _ChuyenCan;
        public double? ChuyenCan { get => _ChuyenCan; set { _ChuyenCan = value; OnPropertyChanged(); } }

        private double? _GiuaKy;
        public double? GiuaKy { get => _GiuaKy; set { _GiuaKy = value; OnPropertyChanged(); } }

        private double? _CuoiKy;
        public double? CuoiKy { get => _CuoiKy; set { _CuoiKy = value; OnPropertyChanged(); } }

        public ICommand Button_Them_CMD { get; set; }
        public ICommand Button_Sua_CMD { get; set; }
        public ICommand Button_Xoa_CMD { get; set; }
        public DiemViewModel()
        {
            PhieuDiemList = new ObservableCollection<PhieuDiem>(DataProvider.Ins.DB.PhieuDiems);
            SinhVienList = new ObservableCollection<SinhVien>(DataProvider.Ins.DB.SinhViens);
            MonHocList = new ObservableCollection<MonHoc>(DataProvider.Ins.DB.MonHocs);
            GiangVienList = new ObservableCollection<GiangVien>(DataProvider.Ins.DB.GiangViens);

            Button_Them_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (string.IsNullOrEmpty(Ma_Phieu.ToString())) return false;

                    var displayList = DataProvider.Ins.DB.PhieuDiems.Where(x => x.Ma_Phieu == Ma_Phieu);

                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    if (SelectedSinhVien == null || SelectedMonHoc == null) return false;

                    return true;

                },
                (p) =>
                {
                    var PhieuDiem = new PhieuDiem()
                    {
                        Ma_Phieu = Ma_Phieu,                        
                        Ma_SV = SelectedSinhVien.Ma_SV,
                        Ma_Mon = SelectedMonHoc.Ma_Mon,
                        ChuyenCan = ChuyenCan,
                        GiuaKy = GiuaKy,
                        CuoiKy = CuoiKy
                    };

                    DataProvider.Ins.DB.PhieuDiems.Add(PhieuDiem);
                    DataProvider.Ins.DB.SaveChanges();

                    PhieuDiemList.Add(PhieuDiem);
                }
            );

            Button_Sua_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null)
                        return false;

                    if (SelectedSinhVien == null || SelectedMonHoc == null) return false;

                    var displayList = DataProvider.Ins.DB.PhieuDiems.Where(x => x.Ma_Phieu == SelectedItem.Ma_Phieu);

                    if (displayList != null && displayList.Count() != 0)
                        return true;

                    return false;
                },
                (p) =>
                {
                    var PhieuDiem = DataProvider.Ins.DB.PhieuDiems.Where(x => x.Ma_Phieu == SelectedItem.Ma_Phieu).SingleOrDefault();
                    int Ma = PhieuDiem.Ma_Phieu;
                    if (Ma_Phieu == Ma)
                    {
                        Ma_Phieu = Ma_Phieu;                       
                        Ma_SV = SelectedSinhVien.Ma_SV;
                        Ma_Mon = SelectedMonHoc.Ma_Mon;
                        ChuyenCan = ChuyenCan;
                        GiuaKy = GiuaKy;
                        CuoiKy = CuoiKy;
                    }
                    else MessageBox.Show("Không thể thay đổi mã lớp");
                    DataProvider.Ins.DB.SaveChanges();
                }
            );

            Button_Them_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null) return false;
                    return true;
                },
                (p) =>
                {
                    DataProvider.Ins.DB.PhieuDiems.Remove(SelectedItem);
                    DataProvider.Ins.DB.SaveChanges();

                    PhieuDiemList.Remove(SelectedItem);
                }
            );
        }
    }
}