namespace Tacomizer
{
    using Android.App;
    using Android.OS;
    using Android.Widget;
    using System.Threading.Tasks;
    using Tacomizer.Controller;
    using Tacomizer.Model;
    using Button = Android.Widget.Button;

    [Activity(Label = "Tacomizer", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _tacoButton;

        private ImageView _tacoImage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.Main);
            this.WireUI();

            this._tacoButton.Click += delegate { StartActivity(typeof(TacoNameVoteActivity)); };
        }

        private void WireUI()
        {
            this._tacoButton = this.FindViewById<Button>(Resource.Id.tacoButton);
            this._tacoImage = this.FindViewById<ImageView>(Resource.Id.tacoImage);
        }
    }
}