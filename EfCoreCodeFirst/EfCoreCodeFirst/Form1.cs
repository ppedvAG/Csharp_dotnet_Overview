using EfCoreCodeFirst.Data;
using EfCoreCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EfCoreCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is IEnumerable<Abteilung> abts)
            {
                e.Value = string.Join(", ", abts.Select(x => x.Bezeichnung));
            }
        }

        EfContext con = new EfContext();

        private void button1_Click(object sender, EventArgs e)
        {
            //linq query expression
            var query = from m in con.Mitarbeiter.Include(x => x.Abteilungen).Include(x => x.Kunden)
                        where m.Name.StartsWith("F")
                        orderby m.GebDatum.Month, m.Name
                        select m;


            dataGridView1.DataSource = query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //linq lambda
            //include == eager loading

            var query = con.Mitarbeiter.Include(x => x.Abteilungen)
                                                      .Include(x => x.Kunden)
                                                      .Where(m => m.Name.StartsWith("F"))
                                                      .OrderBy(x => x.GebDatum.Month)
                                                      .ThenBy(x => x.Name);

            dataGridView1.DataSource = query.ToList();

            MessageBox.Show(query.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Name = $"Fred #{i:000}",
                    GebDatum = DateTime.Now.AddYears(-30).AddDays(i * 17),
                    Beruf = "Macht dinge"
                };

                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);
                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                con.Mitarbeiter.Add(m);
            }
            con.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.SaveChanges();
            con = new EfContext();
            button1_Click(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Database.ExecuteSqlRaw("");
        }
    }
}