using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace FirstApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        List<Android.Support.V4.App.Fragment> fragments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            fragments = new List<Android.Support.V4.App.Fragment>();
            fragments.Add(new FragmentHome());
            fragments.Add(new FragmentSettings());
            // Lade Übersichtsfragment
            SupportFragmentManager.BeginTransaction()
                                    .Replace(Resource.Id.content_frame, fragments[0])
                                    .Commit();

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    // Lade Übersichtsfragment
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragments[0])
                                            .Commit();
                    return true;
                case Resource.Id.navigation_settings:
                    // Lade Einstellungsfragment
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragments[1])
                                            .Commit();
                    return true;
            }
            return false;
        }
    }
}

