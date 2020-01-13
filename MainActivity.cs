using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Views;

namespace DynamicAdapter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button addButton;
        ListView listContact;
        ArrayAdapter<String> adapter;
        int clickCounter = 0;

        public List<string> ContactsNames = new List<string>() {"oi","tchau" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            addButton = FindViewById<Button>(Resource.Id.addButton);
            listContact = FindViewById<ListView>(Resource.Id.listView);

            addButton.Click += AddButton_Click;

            adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, ContactsNames);
            listContact.Adapter = adapter;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ContactsNames.Add("Clicked : " + clickCounter);
            adapter.Add("Clicked : " + clickCounter);
            adapter.NotifyDataSetChanged();
            Toast.MakeText(this, ContactsNames[clickCounter+2], ToastLength.Long).Show();
            clickCounter++;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}