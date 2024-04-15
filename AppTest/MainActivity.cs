using Android;
using Android.App;
using Android.Content.PM;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using Com.Xreader.Helper;
using Google.Android.Material.Snackbar;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using static Android.Graphics.ColorSpace;

namespace AppTest
{



    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            XreaderHelper mxreaderHelper = new XreaderHelper();
            string nameid = "orca50-Rodinbell";


            Button btn_create = FindViewById<Button>(Resource.Id.btn_create);
            btn_create.Click += (s, e) =>
            {
                var res = mxreaderHelper.CreateReaderHub(nameid);
                Console.WriteLine("debug == " + res);
 
            };

            Button btn_connect = FindViewById<Button>(Resource.Id.btn_connect);
            btn_connect.Click += (s, e) =>
            {
                JObject jobj = new JObject
                {
                    {"method", "connectDevice"},
                };

                string connectstr = jobj.ToString();
                Console.WriteLine("debug == " + connectstr);
                var res = mxreaderHelper.CallReaderHubUhf(nameid, connectstr);
 
                Console.WriteLine("debug == " + res);



            };

            Button btn_getFirm = FindViewById<Button>(Resource.Id.btn_getFirm);
            btn_getFirm.Click += (s, e) =>
            {
                JObject jobj = new JObject
                {
                    {"method", "getFirmwareVersion"},
                };

                string getfirmstr = jobj.ToString();
                Console.WriteLine("debug == " + getfirmstr);
                var res = mxreaderHelper.CallReaderHubUhf(nameid, getfirmstr);

                Console.WriteLine("debug == " + res);
            };

            Button btn_inventory = FindViewById<Button>(Resource.Id.btn_inventory);
            btn_inventory.Click += (s, e) =>
            {
                JObject jobj = new JObject
                {
                    {"method", "customInventory"},
                };

                string inventorystr = jobj.ToString();
                Console.WriteLine("debug == " + inventorystr);
                var res = mxreaderHelper.CallReaderHubUhf(nameid, inventorystr);

                Console.WriteLine("debug == " + res);
            };

            Button btn_close = FindViewById<Button>(Resource.Id.btn_close);
            btn_close.Click += (s, e) =>
            {
                mxreaderHelper.DestroyReaderHub(nameid);

            };

        }

    }
}