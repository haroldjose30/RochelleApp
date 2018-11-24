using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using RochelleApp.Activitys;
using Android.Webkit;
using Android.Runtime;

namespace RochelleApp
{
    [Activity(Label = "Rochelle App", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        TextView MainBtnAcessar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);


            var webView = FindViewById<WebView>(Resource.Id.webView1);
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new HybridWebViewClient());
            // Render the view from the type generated from RazorView.cshtml  
            webView.LoadUrl("http://www.google.co.in");


            MainBtnAcessar = (TextView)FindViewById(Resource.Id.MainBtnAcessar);

            MainBtnAcessar.Click += (sender, e) => {
                var it = new Intent(this, typeof(LoginActivity));
                this.StartActivity(it);
            };
           
        }
    }



    public class HybridWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {

            view.LoadUrl(url);
            return true;
        }
        public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);
        }
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
        }
        public override void OnReceivedError(WebView view, [GeneratedEnum] ClientError errorCode, string description, string failingUrl)
        {
            base.OnReceivedError(view, errorCode, description, failingUrl);
        }




    }


}
