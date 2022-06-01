using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;
using XamarinApis.Views;

namespace XamarinApis.ViewModels
{
    public class DoctoresListViewModel: ViewModelBase
    {
        private ServiceApiDoctores service;

        public DoctoresListViewModel(ServiceApiDoctores service)
        {
            this.service = service;
        }

        private ObservableCollection<Doctor> _Doctores;

        public ObservableCollection<Doctor> Doctores
        {
            get { return this._Doctores; }
            set
            {
                this._Doctores = value;
                OnPropertyChanged("Doctores");
            }
        }

        public Command MostrarDoctores
        {
            get
            {
                return new Command(async () =>
                {
                    List<Doctor> data =
                    await this.service.GetDoctoressAsync();
                    this.Doctores =
                    new ObservableCollection<Doctor>(data);
                });
            }
        }

        public Command ShowDoctor
        {
            get
            {
                return new Command(async(idDoctor) =>
                {
                    Doctor doctor = await this.service.FindDoctorAsync((int)idDoctor);
                    DoctorDetailsView view = new DoctorDetailsView();
                    DoctorDetailsViewModel viewmodel = new DoctorDetailsViewModel();
                    viewmodel.Doctor = doctor;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
