using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android;
using RochelleApp.Activitys;
using Android.Content;

namespace RochelleApp.Fragments
{
    public class home : Fragment
    {

        public static home newInstance()
        {
            home fragment = new home();
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.HomeFragment, container, false);
            TextView HomeBtnMaisInformacao = (TextView)view.FindViewById(Resource.Id.HomeBtnMaisInformacao);
            HomeBtnMaisInformacao.Click += (sender, e) => 
            {
                var oInfocarroucelActivity = new Intent(MainActivity.Instance, typeof(InfocarroucelActivity));
                this.StartActivity(oInfocarroucelActivity);
            };


            return view;
        }
    }
}