using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Webkit;
using Android.Widget;

namespace webnew
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        WebView webView;
        EditText txtUrl;
        Button btnLoad;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            webView = FindViewById<WebView>(Resource.Id.webView1);
            txtUrl = FindViewById<EditText>(Resource.Id.txtUrl);
            btnLoad = FindViewById<Button>(Resource.Id.btnload);
            webView.SetWebViewClient(new ExtendWebViewClient());

            WebSettings webSettings = webView.Settings;
            webSettings.JavaScriptEnabled = true;
            btnLoad.Click += (s, e) =>
                webView.LoadUrl(txtUrl.Text);


        }
        internal class ExtendWebViewClient : WebViewClient
        {

            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;

            }

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}