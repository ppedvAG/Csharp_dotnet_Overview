namespace GoogleBooksClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = "https://www.googleapis.com/books/v1/volumes?q=winforms";

            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            
            var results = System.Text.Json.JsonSerializer.Deserialize<BooksResult>(json);

            dataGridView1.DataSource = results.items.Select(x=>x.volumeInfo).ToList(); 

        }
    }
}