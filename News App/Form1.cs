using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace News_App
{
    public partial class NewsApp : Form
    {
        public NewsApp()
        {
            InitializeComponent();
        }

        static public async Task<Root> NewsInformation(int n)
        {
            int day = DateTime.Today.Day;
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;
            HttpClient httpClient = new HttpClient();
            var NewsString = httpClient.GetAsync($"http://newsapi.org/v2/everything?q=bitcoin&from={year}-{month}-{day}&sortBy=publishedAt&apiKey=a328d18fddb14ea1938c4a37ab650ee3").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var root = JsonConvert.DeserializeObject<Root>(NewsString);
            Root Roots = new Root { Rauthor = root.articles[n - 1].author, Rtitle = root.articles[n - 1].title, Rdescription = root.articles[n - 1].description, RurlToImage = root.articles[n - 1].urlToImage, RpublishedAt = root.articles[n - 1].publishedAt, Rname = root.articles[n - 1].source.name };
            return Roots;
        }


        public void NewsForm(GroupBox newsbox, Label title, Label author, Label time, Label description, int n)
        {
            newsbox.Text = NewsInformation(n).Result.Rname;
            title.Text = NewsInformation(n).Result.Rtitle;
            author.Text = NewsInformation(n).Result.Rauthor;
            time.Text = NewsInformation(n).Result.RpublishedAt.ToString();
            description.Text = NewsInformation(n).Result.Rdescription;
        }
        private void NewsApp_Load(object sender, EventArgs e)
        {

            NewsIcon_Click(null, null);
        }

        private void NewsIcon_Click(object sender, EventArgs e)
        {


            NewsForm(NewsBox1, Title1, Author1, Time1, Description1, 1);
            NewsForm(NewsBox2, Title2, Author2, Time2, Description2, 2);
            NewsForm(NewsBox3, Title3, Author3, Time3, Description3, 3);
            NewsForm(NewsBox4, Title4, Author4, Time4, Description4, 4);
            NewsForm(NewsBox5, Title5, Author5, Time5, Description5, 5);



        }
    }
}
