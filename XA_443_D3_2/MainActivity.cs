using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace XA_433_D3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            

            var login = FindViewById<Button>(Resource.Id.login);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var close = FindViewById<Button>(Resource.Id.close);

            login.Click += delegate
            {
                

                if (!string.IsNullOrEmpty(username.Text) && !string.IsNullOrWhiteSpace(password.Text))
                {
                   
                    if (username.Text == "yaser" && password.Text == "123")
                    {
                        Intent intent = new Intent(this, typeof(SecondActivity));
                        intent.PutExtra("username", username.Text);
                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, " UserName or Password is wrong!!!!", ToastLength.Long).Show();
                    }
                }
                else
                {
                    // Toast message to display the error!!! SHORT (short time) - Last forabout 2 seconds
                    Toast.MakeText(this, " Is Empty ", ToastLength.Short).Show();
                }
            };

            clear.Click += delegate
            {
                username.Text = "";
                password.Text = string.Empty;
            };
            close.Click += delegate
            {
                System.Environment.Exit(0);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}