using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.Base;
using XamarinApis.Models;

namespace XamarinApis.ViewModels
{
    public class DoctorDetailsViewModel: ViewModelBase
    {
        private Doctor _Doctor;

        public Doctor Doctor
        {
            get { return this._Doctor; }
            set
            {
                this._Doctor = value;
                OnPropertyChanged("Doctor");
            }
        }
    }
}
