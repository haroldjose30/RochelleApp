using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V4.App;
using Android.Views;

namespace RochelleApp.Activitys
{

    public class LoginActivity : Fragment
    {
        TextView create;
        TextView LoginBtnLogin;

        //public LoginActivity() { }


        public static LoginActivity newInstance()
        {
            LoginActivity fragment = new LoginActivity();
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Login, container, false);

            create = (TextView)view.FindViewById(Resource.Id.create);

            create.Click += (sender, e) => {
                var oSignupActivity = new Intent(MainActivity.Instance, typeof(SignupActivity));
                this.StartActivity(oSignupActivity);

            };


            LoginBtnLogin = (TextView)view.FindViewById(Resource.Id.LoginBtnLogin);

            LoginBtnLogin.Click += (sender, e) => {
                var oProfileActivity = new Intent(MainActivity.Instance, typeof(ProfileActivity));
                this.StartActivity(oProfileActivity);

            };

            return view;
        }
    }


    /*
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        TextView zoo;
        TextView create;
        TextView LoginBtnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            zoo = (TextView)FindViewById(Resource.Id.zoo);

            create = (TextView)FindViewById(Resource.Id.create);

            create.Click += (sender, e) => {
                var oSignupActivity = new Intent(this, typeof(SignupActivity));
                this.StartActivity(oSignupActivity);

            };


            LoginBtnLogin = (TextView)FindViewById(Resource.Id.LoginBtnLogin);

            LoginBtnLogin.Click += (sender, e) => {
                var oProfileActivity = new Intent(this, typeof(ProfileActivity));
                this.StartActivity(oProfileActivity);

            };
        }
    }
    */
}
