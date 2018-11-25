using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android;

namespace RochelleApp.Fragments
{
    public class Infopager4 : Fragment
    {
        public Infopager4() { }

        public static Infopager4 newInstance(String question, String answer)
        {
            Infopager4 fragment = new Infopager4();
            return fragment;
        }

        public override View OnCreateView(
            LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Infopager4, container, false);
            //TextView questionBox = (TextView)view.FindViewById(Resource.Id.flash_card_question);
            return view;
        }
    }
}