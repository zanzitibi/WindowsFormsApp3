using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace WindowsFormsApp3
{
    
    public partial class Form1 : Form
    {
        List<KecskeClass> kecskek = new List<KecskeClass>();
        public Form1()
        {
            InitializeComponent();
            button1.Click += Start;
            
        }
        async void Start(object s, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:3000/kecskek";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string message = await response.Content.ReadAsStringAsync();
                List<KecskeClass> data = JsonConvert.DeserializeObject<List<KecskeClass>>(message);
                listBox1.Items.Clear();
                foreach (KecskeClass item in data)
                {
                    listBox1.Items.Add($"Kecske neve: {item.nev}, kora: {item.kor}, súlya: {item.suly}, magassága: {item.magas}, neme: {item.nem}");
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }
    }
}
