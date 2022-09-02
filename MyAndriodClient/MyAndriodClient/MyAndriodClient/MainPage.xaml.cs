using ProductInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyDll;
using Nancy.Json;
using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using System.Data;
using System.Collections.ObjectModel;

namespace MyAndriodClient
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Event(object sender, EventArgs e)
        {
            try
            {
                String UserName = UserNameText.Text;
                String PassWord = PasswordText.Text;
                
                var wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/json");
                String Url = "http://192.168.43.21:45455/Service1.svc/Login" + "/" + UserName + "/" + PassWord;
                var resJson = wc.DownloadString(Url);
                JavaScriptSerializer ser = new JavaScriptSerializer();

                var jsonresult = JsonConvert.DeserializeObject<RootObject>(resJson);
                var obj = jsonresult.LoginResult;
                if (obj.ResponseCode == "1")
                {
                    Application.Current.MainPage.DisplayAlert("Information System", obj.ResponseMessage, "ok");
                    Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Information System", obj.ResponseMessage, "ok");
                    UserNameText.Text = "";
                    PasswordText.Text = "";
                }
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Information System", ex.Message, "ok");
            }           
        }
    }
}
