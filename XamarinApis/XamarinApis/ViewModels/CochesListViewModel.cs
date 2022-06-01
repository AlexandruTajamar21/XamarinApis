using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModels
{
    public class CochesListViewModel: ViewModelBase
    {
        private ServiceApiCoches service;

        public CochesListViewModel()
        {
            this.service = new ServiceApiCoches();
        }

        private ObservableCollection<Coche> _Coches;

        public ObservableCollection<Coche> Coches
        {
            get { return this._Coches; }
            set {
                this._Coches = value;
                OnPropertyChanged("Coches");
            }
        }

        private async Task LoadCochesAsync()
        {
            List<Coche> cars = await this.service.GetCochesAsync();
            this.Coches =
                new ObservableCollection<Coche>(cars);
        }

        public Command MostrarCoches
        {
            get
            {
                return new Command(async () =>
                {
                    await this.LoadCochesAsync();
                });
            }
        }
    }
}
