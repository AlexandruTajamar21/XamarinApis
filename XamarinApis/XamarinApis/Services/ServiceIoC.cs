using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.ViewModels;

namespace XamarinApis.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //REGISTRAMOS TODO LO QUE VAYAMOS A INYECTAR
            builder.RegisterType<ServiceApiDoctores>();
            builder.RegisterType<DoctoresListViewModel>();
            this.container = builder.Build();
        }

        //CREAMOS LAS PROPIEDADES PARA RECUPERAR LOS VIEWMODELS 
        //DENTRO DE LAS VISTAS
        public DoctoresListViewModel DoctoresListViewModel
        {
            get
            {
                return this.container.Resolve<DoctoresListViewModel>();
            }
        }
    }
}
