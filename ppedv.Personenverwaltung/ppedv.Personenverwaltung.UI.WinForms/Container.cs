using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ppedv.Personenverwaltung.Data.EfCore;
using ppedv.Personenverwaltung.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.UI.WinForms
{
    internal class Container
    {
        private static Container _container;

        public static Container Instance
        {
            get
            {
                if (_container == null)
                    _container = new Container();
                return _container;
            }
        }


        public WindsorContainer WindsorContainer { get; set; } = new WindsorContainer();



        private Container()
        {
            WindsorContainer.Register(Component.For<IRepository>().ImplementedBy<EfRepository>());
        }
    }
}
