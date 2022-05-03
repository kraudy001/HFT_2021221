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
    class InstructorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Instructor> Instructor { get; set; }

        private Instructor SelectedInstructor;
        public Instructor Selected
        {
            get { return SelectedInstructor; }
            set 
            { 
                if(value != null)
                {
                    SelectedInstructor = new Instructor()
                    {
                        Name = value.Name,
                        NeptunId = value.NeptunId,
                        Presentations = value.Presentations,
                    };
                }
                OnPropertyChanged();
                (DeleteInstructorCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateInstructorCommand { get; set; }
        public ICommand DeleteInstructorCommand { get; set; }
        public ICommand UpdateInstructorCommand { get; set; }

        public InstructorWindowViewModel()
        {
            Instructor = new RestCollection<Instructor>("http://localhost:60173/", "instructor", "hub");

            CreateInstructorCommand = new RelayCommand(() =>
            {
                Instructor.Add(new Instructor() 
                { 
                    Name = SelectedInstructor.Name, 
                    NeptunId = SelectedInstructor.NeptunId, 
                    Presentations = SelectedInstructor.Presentations
                });
            });
            DeleteInstructorCommand = new RelayCommand(() =>
            {
                Instructor.Delete(SelectedInstructor.NeptunId);
            }, 
            () =>
            {
                return SelectedInstructor != null;
            });
            UpdateInstructorCommand = new RelayCommand(() => 
            {
                Instructor.Update(SelectedInstructor);
            });
            SelectedInstructor = new Instructor();
        }
    }
}
