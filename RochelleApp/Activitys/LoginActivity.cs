using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RochelleApp.Activitys
{
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
}
