using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RochelleApp.Activitys
{
    [Activity(Label = "SignupActivity")]
    public class SignupActivity : Activity
    {
        TextView signin1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Signup);


            signin1 = (TextView)FindViewById(Resource.Id.signin1);

            signin1.Click += (sender, e) =>
            {

                var it = new Intent(this, typeof(LoginActivity));
                this.StartActivity(it);

            };
        }
    }
}

