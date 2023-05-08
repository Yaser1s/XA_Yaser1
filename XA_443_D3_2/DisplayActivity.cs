using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XA_433_D3
{
    [Activity(Label = "DisplayActivity")]
    public class DisplayActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_display);

            var logout = FindViewById<Button>(Resource.Id.logout);
            var close = FindViewById<Button>(Resource.Id.close);


            logout.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            close.Click += delegate
            {
                System.Environment.Exit(0);
            };
        }
    }
}