using System.ComponentModel;

namespace WinFormsIstCool.View
{
    public partial class HalloBinding : UserControl
    {
        BindingSource bs = new BindingSource();

        BindingList<Auto> liste = new BindingList<Auto>();
        public HalloBinding()
        {
            InitializeComponent();

            //daten laden
            liste.Add(new Auto() { Id = 1, Baujahr = DateTime.Now.AddYears(-26), Läuft = true, Modell = "Baudi" });
            liste.Add(new Auto() { Id = 2, Baujahr = DateTime.Now.AddYears(-6), Läuft = !true, Modell = "Baudi 2" });
            liste.Add(new Auto() { Id = 2, Baujahr = DateTime.Now.AddYears(-1), Läuft = true, Modell = "Baudi 3" });

            bs.DataSource = liste;

            listBox1.DataSource = bs;
            listBox1.Format += ListBox1_Format;
            nameTextBox.DataBindings.Add(nameof(TextBox.Text), bs, nameof(Auto.Modell), true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimePicker1.DataBindings.Add(nameof(DateTimePicker.Value), bs, nameof(Auto.Baujahr), true, DataSourceUpdateMode.OnPropertyChanged);
            checkBox1.DataBindings.Add(nameof(CheckBox.Checked), bs, nameof(Auto.Läuft), true, DataSourceUpdateMode.OnPropertyChanged);



            textBox2.DataBindings.Add("Text", textBox1, "Text", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add(nameof(TextBox.BackColor), textBox1, "Text", true, DataSourceUpdateMode.OnPropertyChanged);

            label1.DataBindings.Add("Text", trackBar1, "Value", true);



        }

        private void ListBox1_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Auto a)
            {
                e.Value = $"{a.Modell} [{a.Baujahr:yyyy}]";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liste.Add(new Auto() { Modell = "NEU" });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                //anderer Task
                //liste.Add(new Auto() { Modell = "NEU" });

                for (int i = 0; i < 100; i++)
                {
                    progressBar1.Invoke(() => progressBar1.Value = i);
                    Thread.Sleep(100);
                }
            });

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();

            Task.Run(() =>
            {
                //anderer Task
                //liste.Add(new Auto() { Modell = "NEU" });

                for (int i = 0; i < 100; i++)
                {
                    Task.Factory.StartNew(() =>
                    {
                        progressBar1.Value = i;
                    }, CancellationToken.None, TaskCreationOptions.None, ts);

                    Thread.Sleep(100);
                }
            });
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }
        }

        private Task<long> AlteUndLangsamAsync(string text)
        {
            return Task.Run(() => AlteUndLangsam(text));
        }

        private long AlteUndLangsam(string text)
        {
            Thread.Sleep(3000);
            return text.Length * 1000;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show((await AlteUndLangsamAsync("Hallo")).ToString());
        }
    }
}
