using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAndriodClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public IList<AllPersonInformation> datagrids { get; set; }
        public Page2()
        {
            InitializeComponent();

            try
            {
                var wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/json");
                String Url = "http://192.168.43.21:45455/Service1.svc/GetAllPersonInformationList";
                var resJson = wc.DownloadString(Url);
                var jsonresult = JsonConvert.DeserializeObject<Objec2>(resJson);
                datagrids = new List<AllPersonInformation>();
                for (int i = 0; i < jsonresult.GetAllPersonInformationListResult.FirstName.Count; i++)
                {
                    datagrids.Add(new AllPersonInformation()
                        {
                            Id = jsonresult.GetAllPersonInformationListResult.Id[i],
                            FirstName = jsonresult.GetAllPersonInformationListResult.FirstName[i],
                            MiddleName = jsonresult.GetAllPersonInformationListResult.MiddleName[i],
                            LastName = jsonresult.GetAllPersonInformationListResult.LastName[i]
                        }
                       );
                }

                BindingContext = this;
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Information System", ex.Message, "ok");
            }




        }
        public class Card
        { 
            public string PlanName { get; set; }
            public string Charges { get; set; }
            public string TotalDays { get; set; }
            public string DaysInWeek { get; set; }
        }
    }
}

