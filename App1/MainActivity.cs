using Android.App;
using Android.OS;
using SALLab02;

namespace AndroidApp
{
    [Activity(Label = "Laboratorio 02", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            Validate();
        }

        private async void Validate()
        {
            var serviceClient = new ServiceClient();
            const string email = "@live.com";
            const string password = "@";
            var deviceId = DeviceId;
            var result = await serviceClient.ValidateAsync(email, password, deviceId);
            ShowAlertDialog(result);
        }

        private void ShowAlertDialog(ResultInfo result)
        {
            var builder = new AlertDialog.Builder(this);
            var alertDialog = builder.Create();
            alertDialog.SetTitle("Verification Result");
            alertDialog.SetIcon(Resource.Drawable.Icon);
            alertDialog.SetMessage($"{result.Status} \n {result.Fullname} \n {result.Token} ");
            alertDialog.SetButton("Ok", (s, e) => { });
            alertDialog.Show();
        }

        private string DeviceId
        {
            get
            {
                return Android.Provider.Settings.Secure.GetString(ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId);
            }
        }
    }
}

