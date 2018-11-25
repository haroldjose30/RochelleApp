using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android;
using Android.Webkit;
using Android.Content;

namespace RochelleApp.Fragments
{
    public class web : Fragment
    {
        //public web() { }

        private static web fragment;
        public static web newInstance()
        {
            if (fragment==null)
                fragment = new web();

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           

            View view = inflater.Inflate(Resource.Layout.WebFragment, container, false);

            var webView = view.FindViewById<WebView>(Resource.Id.webView1);
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new HybridWebViewClient(MainActivity.Instance));
            // Render the view from the type generated from RazorView.cshtml  
            webView.LoadUrl("https://www.rochellemassinhan.com.br");
           

            return view;
        }
    }
}