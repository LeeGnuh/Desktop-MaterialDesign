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
    public class LopSHViewModel : BaseViewModel
    {
        private ObservableCollection<LopSH> _LopSHList;
        public ObservableCollection<LopSH> LopSHList { get => _LopSHList; set { _LopSHList = value; OnPropertyChanged(); } }

        private ObservableCollection<GiangVien> _GiangVienList;
        public ObservableCollection<GiangVien> GiangVienList { get => _GiangVienList; set { _GiangVienList = value; OnPropertyChanged(); } }



        private LopSH _SeletedItem;
        public LopSH SelectedItem
        {
            get => _SeletedItem;
            set
            {
                _SeletedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Ma_Lop = SelectedItem.Ma_Lop;
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

        private string _Ma_Lop;
        public string Ma_Lop { get => _Ma_Lop; set { _Ma_Lop = value; OnPropertyChanged(); } }

        private int _Ma_GV;
        public int Ma_GV { get => _Ma_GV; set { _Ma_GV = value; OnPropertyChanged(); } }

        public ICommand Button_Them_CMD { get; set; }
        public ICommand Button_Sua_CMD { get; set; }
        public LopSHViewModel()
        {
            LopSHList = new ObservableCollection<LopSH>(DataProvider.Ins.DB.LopSHes);
            GiangVienList = new ObservableCollection<GiangVien>(DataProvider.Ins.DB.GiangViens);

            Button_Them_CMD = new RelayCommand<object>
            (
                (p) => 
                {
                    if (string.IsNullOrEmpty(Ma_Lop)) return false;                   

                    var displayList = DataProvider.Ins.DB.LopSHes.Where(x => x.Ma_Lop == Ma_Lop);

                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    if (SelectedGiangVien == null) return false;

                    return true;

                }, 
                (p) =>
                {
                    var LopSH = new LopSH()
                    {
                        Ma_Lop = Ma_Lop,
                        Ma_GV = SelectedGiangVien.Ma_GV                       
                    };
                    
                    DataProvider.Ins.DB.LopSHes.Add(LopSH);
                    DataProvider.Ins.DB.SaveChanges();

                    LopSHList.Add(LopSH);
                }
            );

            Button_Sua_CMD = new RelayCommand<object>
            (
                (p) =>
                {
                    if (SelectedItem == null)
                        return false;

                    if (SelectedGiangVien == null) return false;

                    var displayList = DataProvider.Ins.DB.LopSHes.Where(x => x.Ma_Lop == SelectedItem.Ma_Lop);

                    if (displayList != null && displayList.Count() != 0)
                        return true;

                    return false;
                },
                (p) =>
                {              
                    var LopSH = DataProvider.Ins.DB.LopSHes.Where(x => x.Ma_Lop == SelectedItem.Ma_Lop).SingleOrDefault();
                    string Ma = LopSH.Ma_Lop;
                    if (Ma_Lop == Ma)
                    {
                        LopSH.Ma_Lop = Ma_Lop;
                        LopSH.Ma_GV = SelectedGiangVien.Ma_GV;                       
                    }
                    else MessageBox.Show("Không thể thay đổi mã lớp");
                    DataProvider.Ins.DB.SaveChanges();
                }
            );
        }
    }
}