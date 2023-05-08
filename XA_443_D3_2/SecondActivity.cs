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
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_second);

            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            var website = FindViewById<EditText>(Resource.Id.website);


            var call = FindViewById<Button>(Resource.Id.call);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var web = FindViewById<Button>(Resource.Id.web);
            var map = FindViewById<Button>(Resource.Id.map);
            var next = FindViewById<Button>(Resource.Id.next);
            var logout = FindViewById<Button>(Resource.Id.logout);

            TextView name = FindViewById<TextView>(Resource.Id.name);


            String u = Intent.GetStringExtra("username");

            name.Text = "@" + u;

            call.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(mobile.Text) || !string.IsNullOrEmpty(mobile.Text))
                {
                    try
                {
                    var uri = Android.Net.Uri.Parse("tel:" + mobile);
                    var i = new Intent(Intent.ActionDial, uri);
                    StartActivity(i);
                }
                catch (Exception ex)
                {
                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " Enter a Mobile Number ", ToastLength.Long).Show();
                }
            };

            map.Click += delegate
            {
                var latitude = mobile.Text;
                var longitude = website.Text;

                if (!string.IsNullOrWhiteSpace(latitude) && !string.IsNullOrEmpty(longitude))
                {
                    try
                    {
                        var geoUri = Android.Net.Uri.Parse("geo:latitude,longitude");
                        var mapIntent = new Intent(Intent.ActionView, geoUri);
                        StartActivity(mapIntent);
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                }
                else
                    Toast.MakeText(this, " Enter a latitude or longitude for location!!! ", ToastLength.Long).Show();
            };

            web.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(website.Text) || !string.IsNullOrEmpty(website.Text))
                {
                    try
                    {
                        var url = Android.Net.Uri.Parse("http://"+website.Text);
                        var i = new Intent(Intent.ActionView, url);
                        StartActivity(i);
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                }
                else
                    Toast.MakeText(this, " Enter a website url !!! ", ToastLength.Long).Show();
            };


            clear.Click += delegate
            {
                mobile.Text = "";
                website.Text = string.Empty;
            };

            logout.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
            next.Click += delegate
            {
                Intent intent = new Intent(this, typeof(DisplayActivity));
                StartActivity(intent);
            };
        }
    }
}