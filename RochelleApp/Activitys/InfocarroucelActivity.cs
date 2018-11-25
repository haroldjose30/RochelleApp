using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.OS;
using RochelleApp.Fragments;

namespace RochelleApp.Activitys
{
    [Android.App.Activity(Label = "InfocarroucelActivity")]
    public class InfocarroucelActivity : FragmentActivity
    {
        private ViewPager viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Infocarroucel);

            viewPager = (ViewPager)FindViewById(Resource.Id.viewpager);

            Infopager1 tab1 = new Infopager1();
            ViewpagerAdapter adapter = new ViewpagerAdapter(SupportFragmentManager, tab1);
            viewPager.Adapter = adapter;

        }
    }


    public class ViewpagerAdapter : FragmentPagerAdapter
    {
        public ViewpagerAdapter(Android.Support.V4.App.FragmentManager fm, Fragment _ViewPager)
            : base(fm)
        {

        }

        public override int Count
        {

            get { return 4; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    Infopager1 tab1 = new Infopager1();
                    return tab1;
                case 1:
                    Infopager2 tab2 = new Infopager2();
                    return tab2;
                case 2:
                    Infopager3 tab3 = new Infopager3();
                    return tab3;
                case 3:
                    Infopager4 tab4 = new Infopager4();
                    return tab4;

                default:
                    Infopager1 tab = new Infopager1();
                    return tab;

            }
        }
    }


}
