using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using RochelleApp.Activitys;
using Android.Webkit;
using Android.Runtime;
using Android.Net;
using System.IO;
using RochelleApp.Fragments;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace RochelleApp
{
    [Activity(Label = "Rochelle App", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity//Activity
    {
        BottomNavigationView bottomNavigation;
        internal static MainActivity Instance { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

          


            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            // Load the first fragment on creation
            LoadFragment(Resource.Id.menu_home);


        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }


        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = home.newInstance();
                    break;
                case Resource.Id.menu_audio:
                    fragment = LoginActivity.newInstance();
                    break;
                case Resource.Id.menu_video:
                    fragment = web.newInstance();
                    break;
                default:
                    fragment = home.newInstance();
                    break;
            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }
    }



    public class HybridWebViewClient : WebViewClient
    {
        internal static MainActivity Instance { get; private set; }

        public HybridWebViewClient(MainActivity instance)
        {
            Instance = instance;
        }


        [System.Obsolete("obsoleto")]
        [Android.Runtime.Register("shouldOverrideUrlLoading", "(Landroid/webkit/WebView;Ljava/lang/String;)Z", "GetShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String_Handler")]
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {

            view.LoadUrl(url);
            return true;
        }

        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            Uri url = request.Url;
            view.LoadUrl(url.ToString());
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

        [System.Obsolete("obsoleto")]
        public override void OnReceivedError(WebView view, [GeneratedEnum] ClientError errorCode, string description, string failingUrl)
        {
            var assetManager = Instance.Assets;
            using (var streamReader = new StreamReader(assetManager.Open("ErroHtml.html")))
            {
                var html = streamReader.ReadToEnd();
                view.LoadData(html,"text/html", "utf-8"); 
            }

            base.OnReceivedError(view, errorCode, description, failingUrl);
        }




    }


}
