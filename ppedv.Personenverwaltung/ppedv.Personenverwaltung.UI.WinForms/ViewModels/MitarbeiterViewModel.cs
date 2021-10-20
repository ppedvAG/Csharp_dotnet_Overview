using ppedv.Personenverwaltung.Logic;
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.UI.WinForms.ViewModels
{
    public class MitarbeiterViewModel : INotifyPropertyChanged
    {
        //Core core = new Core(Container.Instance.WindsorContainer.Resolve<IRepository>());
        Core core;
        private Mitarbeiter selectedMitarbeiter;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public BindingList<Mitarbeiter> MitarbeiterList { get; set; } = new BindingList<Mitarbeiter>();

        public Mitarbeiter SelectedMitarbeiter
        {
            get => selectedMitarbeiter;
            set
            {
                selectedMitarbeiter = value;
                OnPropertyChanged(nameof(GebDatum));
                //OnPropertyChanged("");
            }
        }


        public DateTime GebDatum
        {
            get
            {
                if (SelectedMitarbeiter == null || SelectedMitarbeiter.GebDatum.Year < 1900)
                    return new DateTime(2000, 1, 1);


                return SelectedMitarbeiter.GebDatum;
            }
            set { SelectedMitarbeiter.GebDatum = value; }
        }

        Random random = new Random();
        public string Alter
        {
            get { return random.Next().ToString(); }

        }

        public MitarbeiterViewModel()
        {

        }



        internal void LoadAll()
        {
            if (core == null)
                core = new Core(Container.Instance.WindsorContainer.Resolve<IRepository>());
            MitarbeiterList.Clear();

            foreach (var m in core.Repository.Query<Mitarbeiter>())
            {
                MitarbeiterList.Add(m);
            }
        }

        internal void UserWantsToSave()
        {
            core.Repository.SaveAll();
        }

        internal void UserWantsToAddNew()
        {
            var m = new Mitarbeiter() { Name = "NEU", GebDatum = DateTime.Now };
            core.Repository.Add(m);
            MitarbeiterList.Add(m);

        }
    }
}
