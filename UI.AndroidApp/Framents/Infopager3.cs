using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android;

namespace RochelleApp.Fragments
{
    public class Infopager3 : Fragment
    {
        //public Infopager3() { }

        public static Infopager3 newInstance()
        {
            Infopager3 fragment = new Infopager3();
            return fragment;
        }

        public override View OnCreateView(
            LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Infopager3, container, false);
            //TextView questionBox = (TextView)view.FindViewById(Resource.Id.flash_card_question);
            return view;
        }
    }
}