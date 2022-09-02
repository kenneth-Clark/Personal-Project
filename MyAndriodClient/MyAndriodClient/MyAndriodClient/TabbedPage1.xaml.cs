using Nancy.Json;
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
    public partial class TabbedPage1 : TabbedPage
    {
        public IList<AllPersonInformation> datagrids { get; set; }
        public TabbedPage1()
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

        private void Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                String FirstName = TextFirstName.Text;
                String MiddleName = TextMiddleName.Text;
                String LastName = TextLastName.Text;

                var CheckResult = ParameterCheck(FirstName, MiddleName, LastName);
                if (CheckResult.ResponseCode == "1")
                {
                    var wc = new WebClient();
                    wc.Headers.Add("Content-Type", "application/json");
                    String Url = "http://192.168.43.21:45455/Service1.svc/GetData" + "/" + FirstName + "/" + MiddleName + "/" + LastName;
                    var resJson = wc.DownloadString(Url);
                    JavaScriptSerializer ser = new JavaScriptSerializer();

                    var jsonresult = JsonConvert.DeserializeObject<RootObject>(resJson);
                    var obj = jsonresult.GetDataResult;
                    Application.Current.MainPage.DisplayAlert("Information System", obj.ResponseMessage, "ok");
                    ClearText();
                    Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Information System", CheckResult.ResponseMessage, "ok");
                }
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Information System", ex.Message, "ok");
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            TextFirstName.Text = "";
            TextMiddleName.Text = "";
            TextLastName.Text = "";
        }
        private void SearhId_Event(object sender, EventArgs e)
        {

            try
            {
                String Id = SearchTextId.Text;
                if (Id == null || Id == "")
                {
                    Application.Current.MainPage.DisplayAlert("Information System", "Please Input ID", "ok");
                }
                else
                {
                    if (int.TryParse(Id, out int value))
                    {

                        var wc = new WebClient();
                        wc.Headers.Add("Content-Type", "application/json");
                        String Url = "http://192.168.43.21:45455/Service1.svc/SearcInformationById" + "/" + Id;
                        var resJson = wc.DownloadString(Url);
                        JavaScriptSerializer ser = new JavaScriptSerializer();

                        var jsonresult = JsonConvert.DeserializeObject<Objec2>(resJson);
                        if (jsonresult.SearcInformationByIdResult.ResponseCode == "1")
                        {
                            SearchTextId.IsEnabled = false;
                            SearchIdButton.IsEnabled = false;
                            UpdateButton.IsEnabled = true;
                            DeleteButton.IsEnabled = true;

                            SearchTextFirstName.Text = jsonresult.SearcInformationByIdResult.FirstName;
                            SearchTextMiddleName.Text = jsonresult.SearcInformationByIdResult.MiddleName;
                            SearchTextLastName.Text = jsonresult.SearcInformationByIdResult.LastName;
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Information System", jsonresult.SearcInformationByIdResult.ResponseMessage, "ok");
                        }

                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Information System", "Please Input Valid Id", "ok");
                    }

                    
                }

            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Information System", ex.Message, "ok");
            }

        }
        private void Update_Event(object sender, EventArgs e)
        {
            if (UpdateButton.Text == "UPDATE")
            {
                UpdateButton.Text = "SAVE";
                DeleteButton.IsEnabled = false;
                SearchTextFirstName.IsEnabled = true;
                SearchTextMiddleName.IsEnabled = true;
                SearchTextLastName.IsEnabled = true;
            }            
            else
            {
                var x = ParameterCheck(SearchTextFirstName.Text, SearchTextMiddleName.Text, SearchTextLastName.Text);
                if (x.ResponseCode == "1")
                {

                    try
                    {
                        String FirstName = SearchTextFirstName.Text;
                        String MiddleName = SearchTextMiddleName.Text;
                        String LastName = SearchTextLastName.Text;

                        var CheckResult = ParameterCheck(FirstName, MiddleName, LastName);
                        if (CheckResult.ResponseCode == "1")
                        {
                            var wc = new WebClient();
                            wc.Headers.Add("Content-Type", "application/json");
                            String Url = "http://192.168.43.21:45455/Service1.svc/UpdateData" + "/" + FirstName + "/" + MiddleName + "/" + LastName +"/"+ SearchTextId.Text;
                            var resJson = wc.DownloadString(Url);
                            JavaScriptSerializer ser = new JavaScriptSerializer();
                            var jsonresult = JsonConvert.DeserializeObject<RootObject3>(resJson);
                            var obj = jsonresult.UpdateDataResult;
                            if (obj.ResponseCode == "1")
                            {
                                //resetProperties();
                                Application.Current.MainPage.DisplayAlert("Information System", obj.ResponseMessage, "ok");
                                Application.Current.MainPage = new NavigationPage(new TabbedPage1());

                            }
                            else
                            {
                                Application.Current.MainPage.DisplayAlert("Information System", obj.ResponseMessage, "ok");
                            }
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Information System", CheckResult.ResponseMessage, "ok");
                        }
                    }
                    catch (Exception ex)
                    {

                        Application.Current.MainPage.DisplayAlert("Information System", ex.Message, "ok");
                    }
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Information System", x.ResponseMessage, "ok");
                }

            }

        }
        private void resetProperties()
        {
            SearchTextId.IsEnabled = true;
            SearchIdButton.IsEnabled = true;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            SearchTextFirstName.IsEnabled = false;
            SearchTextMiddleName.IsEnabled = false;
            SearchTextLastName.IsEnabled = false;
            SearchTextId.Text = "";
            SearchTextFirstName.Text = "";
            SearchTextMiddleName.Text = "";
            SearchTextLastName.Text = "";

        }
        private void Cancel_Event(object sender, EventArgs e)
        {
            resetProperties();
        }
        private async Task Delete_EventAsync(object sender, EventArgs e)
        {
            try
            {
                bool answer = await DisplayAlert("Information System", "Are you sure you want to Delete this Information?", "Yes", "No");

                if (answer == true)
                {

                    var wc = new WebClient();
                    wc.Headers.Add("Content-Type", "application/json");
                    String Url = "http://192.168.43.21:45455/Service1.svc/DeleteData" + "/" + SearchTextId.Text;
                    var resJson = wc.DownloadString(Url);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    var jsonresult = JsonConvert.DeserializeObject<RootObject3>(resJson);
                    var obj = jsonresult.DeleteDataResult;
                    if (obj.ResponseCode == "1")
                    {
                        await DisplayAlert("Information System", obj.ResponseMessage, "ok");
                        Application.Current.MainPage = new NavigationPage(new TabbedPage1());

                    }
                    else
                    {
                        await DisplayAlert("Information System", obj.ResponseMessage, "ok");
                    }
                }
                else
                {
                    resetProperties();
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("Information System", ex.Message, "ok");
            }
        }
        public void Delete_Event(object sender, EventArgs e)
        {
            UpdateButton.IsEnabled = false;
            Delete_EventAsync(sender, e);
        }
        private void View_ifnromation(object sender, EventArgs e)
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new Page2());
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Information System", ex.Message, "ok");
            }
        }
        private void ClearText()
        {
            TextFirstName.Text = "";
            TextMiddleName.Text = "";
            TextLastName.Text = "";
        }
        private GetDataResult ParameterCheck(String FirstName, String MiddleName, String LastName)
        {
            var x = new GetDataResult();
            try
            {

                if (FirstName == null || FirstName == "")
                {
                    x.ResponseCode = "er1";
                    x.ResponseMessage = "Please Input Name";
                }
                else if (MiddleName == null || MiddleName == "")
                {
                    x.ResponseCode = "er2";
                    x.ResponseMessage = "Please Input Middle Name";
                }
                else if (LastName == null || LastName == "")
                {
                    x.ResponseCode = "er3";
                    x.ResponseMessage = "Please Input Last Name";
                }
                else
                {
                    x.ResponseCode = "1";
                    x.ResponseMessage = "All Good";
                }
            }
            catch (Exception ex)
            {

                return new GetDataResult { ResponseCode = "0", ResponseMessage = ex.Message };
            }
            return new GetDataResult { ResponseCode = x.ResponseCode, ResponseMessage = x.ResponseMessage };
        }
    }
}
public class GetDataResult
{
    public String ResponseCode { get; set; }
    public String ResponseMessage { get; set; }
}

public class PersonInformation : GetDataResult
{
    public String FirstName;
    public String MiddleName;
    public String LastName;
}

public class RootObject
{
    public GetDataResult GetDataResult { get; set; }
    public LoginResult LoginResult { get; set; }
}
public class LoginResult : GetDataResult
{ 
}
public class RootObject3
{
    public UpdateDataResult UpdateDataResult { get; set; }
    public DeleteDataResult DeleteDataResult { get; set; }
}


public class Objec2

{
    public GetAllPersonInformationResult GetAllPersonInformationResult { get; set; }
    public GetAllPersonInformationListResult GetAllPersonInformationListResult { get; set; }
    public SearcInformationByIdResult SearcInformationByIdResult { get; set; }
}

public class GetAllPersonInformationResult
{
    public List<AllPersonInformation> AllPersonInformation;
    public String ResponseCode { get; set; }
    public String ResponseMessage { get; set; }
}
public class GetAllPersonInformationListResult : GetDataResult
{
    public List<String> Id { get; set; }
    public List<String> FirstName { get; set; }
    public List<String> MiddleName { get; set; }
    public List<String> LastName { get; set; }
}

public class AllPersonInformation
{
    public String Id { get; set; }
    public String FirstName { get; set; }
    public String MiddleName { get; set; }
    public String LastName { get; set; }
}
public class SearcInformationByIdResult : GetDataResult
{
    public String Id { get; set; }
    public String FirstName { get; set; }
    public String MiddleName { get; set; }
    public String LastName { get; set; }
}
public class UpdateDataResult : GetDataResult
{ 
}
public class DeleteDataResult : GetDataResult
{ 
}