using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.UI.WinForms.ViewModels;

namespace ppedv.Personenverwaltung.UI.WinForms.Views
{
    public partial class MitarbeiterView : UserControl
    {
        MitarbeiterViewModel viewModel;

        BindingSource bindingSource = new BindingSource();

        public MitarbeiterView()
        {
            InitializeComponent();

            Load += MitarbeiterView_Load;


        }

        private void MitarbeiterView_Load(object? sender, EventArgs e)
        {
            viewModel = new MitarbeiterViewModel();
            bindingSource.DataSource = viewModel.MitarbeiterList;
            dataGridView1.DataSource = bindingSource;

            bindingSource.CurrentChanged += BindingSource_CurrentChanged;
            nameTextBox.DataBindings.Add("Text", bindingSource, nameof(Mitarbeiter.Name));
            berufTextBox.DataBindings.Add("Text", bindingSource, nameof(Mitarbeiter.Beruf));


            gebDatumDateTimePicker.DataBindings.Add("Value", viewModel, nameof(MitarbeiterViewModel.GebDatum), true);

            alterLabel.DataBindings.Add("Text", viewModel, nameof(MitarbeiterViewModel.Alter));
            viewModel.LoadAll();
        }

        private void BindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Mitarbeiter m)
                viewModel.SelectedMitarbeiter = m;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            viewModel.UserWantsToSave();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            viewModel.UserWantsToAddNew();
        }
    }
}
