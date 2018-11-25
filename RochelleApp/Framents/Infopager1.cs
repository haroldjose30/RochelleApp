using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android;

namespace RochelleApp.Fragments
{
    public class Infopager1 : Fragment
    {
        public Infopager1() { }

        public static Infopager1 newInstance(String question, String answer)
        {
            Infopager1 fragment = new Infopager1();
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Infopager1, container, false);
            //TextView questionBox = (TextView)view.FindViewById(Resource.Id.flash_card_question);
            return view;
        }
    }
}