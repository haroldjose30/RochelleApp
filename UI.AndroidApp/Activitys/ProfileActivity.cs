
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RochelleApp.Activitys
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity
    {
        TextView ProfileBtnIndicar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Profile);


            ProfileBtnIndicar = (TextView)FindViewById(Resource.Id.ProfileBtnIndicar);
            ProfileBtnIndicar.Click += (sender, e) => {
                var it = new Intent(this, typeof(ShareActivity));
                this.StartActivity(it);
            };

        }
    }
}
