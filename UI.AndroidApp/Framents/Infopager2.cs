using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android;

namespace RochelleApp.Fragments
{
    public class Infopager2 : Fragment
    {
 //       public Infopager2() { }

        public static Infopager2 newInstance()
        {
            Infopager2 fragment = new Infopager2();
            return fragment;
        }

        public override View OnCreateView(
            LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Infopager2, container, false);
            //TextView questionBox = (TextView)view.FindViewById(Resource.Id.flash_card_question);
            return view;
        }
    }
}