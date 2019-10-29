using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.OS;
using RochelleApp.Fragments;
using Me.Relex;

namespace RochelleApp.Activitys
{
    [Android.App.Activity(Label = "InfocarroucelActivity")]
    public class InfocarroucelActivity : FragmentActivity
    {
        private ViewPager viewPager;
        private CircleIndicator circleIndicator;
        private ViewpagerAdapter viewpagerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Infocarroucel);

            viewPager = (ViewPager)FindViewById(Resource.Id.viewpager);
            circleIndicator = (CircleIndicator)FindViewById(Resource.Id.circleindicator);

            Infopager1 tab1 = new Infopager1();
            viewpagerAdapter = new ViewpagerAdapter(SupportFragmentManager, tab1);
            viewPager.Adapter = viewpagerAdapter;
            circleIndicator.SetViewPager(viewPager);
            viewpagerAdapter.RegisterDataSetObserver(circleIndicator.GetDataSetObserver());


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
                    Infopager1 tab1 = Infopager1.newInstance();
                    return tab1;
                case 1:
                    Infopager2 tab2 = Infopager2.newInstance();
                    return tab2;
                case 2:
                    Infopager3 tab3 = Infopager3.newInstance();
                    return tab3;
                case 3:
                    Infopager4 tab4 = Infopager4.newInstance();
                    return tab4;

                default:
                    Infopager1 tab = Infopager1.newInstance();
                    return tab;

            }
        }
    }


}
