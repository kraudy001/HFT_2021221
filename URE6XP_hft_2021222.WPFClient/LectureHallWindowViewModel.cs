using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.WPFClient;

namespace URE6XP_hft_2021222.WPFClient
{
    public class LectureHallWindowViewModel: ObservableRecipient
    {
        public RestCollection<LectureHall> lectureHall { get; set; }

        private LectureHall SelectedLectureHall;

        public LectureHall Selected
        {
            get { return SelectedLectureHall; }
            set
            {
                if (value != null)
                {
                    SelectedLectureHall = new LectureHall
                    {
                        Capacity = value.Capacity,
                        Presentations = value.Presentations,
                        RoomNumber = value.RoomNumber,
                    };
                    OnPropertyChanged();
                    (DeleteLectureHall as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateLectureHall { get; set;}
        public ICommand UpdateLectureHall { get; set;}
        public ICommand DeleteLectureHall { get; set;}

        public LectureHallWindowViewModel()
        {
            lectureHall = new RestCollection<LectureHall>("http://localhost:60173/", "lectureHall", "hub");

            CreateLectureHall = new RelayCommand(() =>
            {
                lectureHall.Add(new LectureHall()
                {
                    Capacity = SelectedLectureHall.Capacity,
                    Presentations = SelectedLectureHall.Presentations,
                    RoomNumber = SelectedLectureHall.RoomNumber,
                });
            });
            DeleteLectureHall = new RelayCommand(() =>
            {
                lectureHall.Delete(SelectedLectureHall.RoomNumber);
            }, () =>
            {
                return SelectedLectureHall != null;
            });
            UpdateLectureHall = new RelayCommand(() =>
            {
                lectureHall.Update(SelectedLectureHall);
            });
            SelectedLectureHall = new LectureHall();
        }

    }
}
