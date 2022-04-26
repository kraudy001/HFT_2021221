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
    internal class PresentationWindowViewModel : ObservableObject
    {
        public RestCollection<Presentation> Presentation { get; set; }
        public Presentation SelectedPresentation;
        public Presentation Selected
        {
            get { return SelectedPresentation; }
            set
            {
                if(value != null)
                {
                    SelectedPresentation = new Presentation()
                    {
                        InstrctoreNeptunId = value.InstrctoreNeptunId,
                        PresentationName = value.PresentationName,
                        Instructor = value.Instructor,
                        LectureHall = value.LectureHall,
                        RoomNumber = value.RoomNumber,
                    };
                }
                OnPropertyChanged();
                (DeletePresentationCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreatePresentationCommand { get; set; }
        public ICommand DeletePresentationCommand { get; set; }
        public ICommand UpdatePresentationCommand { get; set; }

        public PresentationWindowViewModel()
        {
            Presentation = new RestCollection<Presentation>("http://localhost:60173/", "presentation", "hub");

            CreatePresentationCommand = new RelayCommand(() =>
            {
                Presentation.Add(new Presentation()
                {
                    InstrctoreNeptunId = SelectedPresentation.InstrctoreNeptunId,
                    PresentationName = SelectedPresentation.PresentationName,
                    Instructor = SelectedPresentation.Instructor,
                    LectureHall = SelectedPresentation.LectureHall,
                    RoomNumber = SelectedPresentation.RoomNumber,
                });
            });

            DeletePresentationCommand = new RelayCommand(() =>
            {
                Presentation.Delete(SelectedPresentation.PresentationName);
            }, () =>
            {
                return SelectedPresentation != null;
            });

            UpdatePresentationCommand = new RelayCommand(() =>
            {
                Presentation?.Update(SelectedPresentation);
            });

            SelectedPresentation = new Presentation();
        }
    }
}
