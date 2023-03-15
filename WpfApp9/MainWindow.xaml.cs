using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp9
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static HttpClient httpClient = new HttpClient();
        public static User user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
            var content = new userData { SurName = FamTb.Text, Name = NameTb.Text, MidleName = OtchTb.Text, Phone = PhoneTb.Text, Email = EmailTb.Text, Comment = CommentTb.Text, Organization = Convert.ToInt32(OrgTb.Text), SeriaPasport = Convert.ToInt32(SeriyaTb.Text), NomerPasport = Convert.ToInt32(NumberTb.Text), Birthday = (DateTime)DatePc.SelectedDate };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.PostAsync($"http://localhost:54872/api/postnewclients?surname={NameTb.Text}&name={FamTb.Text}&midleName={OtchTb.Text}&phone={PhoneTb.Text}&email={EmailTb.Text}&organizationId={Convert.ToInt32(OrgTb.Text)}&comment={CommentTb.Text}&dataBirthday={(DateTime)DatePc.SelectedDate}&seriyaPasport={Convert.ToInt32(SeriyaTb.Text)}&numberPasport={Convert.ToInt32(NumberTb.Text)}", httpContent);
            if (message.IsSuccessStatusCode)
            {
               
                MessageBox.Show("Мудак добавлен!");
            }


        }
        public class userData
        {
            public string SurName { get; set; }
            public string Name { get; set; }
            public string MidleName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Comment { get; set; }
            public int Organization { get; set; }
            public int SeriaPasport { get; set; }
            public int NomerPasport { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}
