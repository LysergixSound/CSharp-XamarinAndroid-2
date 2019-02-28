Android Development mit C# Xamarin Tutorial #2: Fragment Navigation
===================================================================

Schritt 1: Projekt erstellen
============================
Zu Beginn öffnen wir Visual Studio und erstellen ein neues Projekt.
Als Projekt wählen wir Visual C# => Android => Android-App (Xamarin)

![alt text](https://github.com/LysergixSound/CSharp-XamarinAndroid-2/blob/master/Images/projectCreate.png)

Anschließend wählen wir im Fenster danach Registerkarten-App aus

![alt text](https://github.com/LysergixSound/CSharp-XamarinAndroid-2/blob/master/Images/projectCreateStyle.png)

Kurze Erklärung:
================
Unser erstelltes Projekt sollte nun folgende Hierarchie haben

![alt text](https://github.com/LysergixSound/CSharp-XamarinAndroid-2/blob/master/Images/projectHierarchie.png)

Die interessantesten Datein und Ordner zum Anfang sind für uns:
1. \MainActivity.cs
   * Diese Datei enthählt die Logik für unsere MainActivity, sozusagen unser Start Fenster
2. \Resources\layout
   * Dieser Ordner enthählt unsere designten Layouts die wir anzeigen können zu sehen ist auch die Datei activity_main.axml die unser grafisches Layout für MainActivity.cs in XML Form beinhaltet.
3. \Resources\menu\navigation.xml
   * Da wir uns für eine Registerkarten-App entschieden haben, wird in unserer App eine untere Navigationsleiste angezeigt. In dieser Datei können wir die angezeigten Menü Items in XML Form definieren
4. \Resources\values\strings.xml
   * Hier können wir Strings, also Texte, definieren, die wir später im Code und im XML wie Variablen abrufen können. 

MainActivity Code erklärt:


Schritt 2: Navigationsleiste anpassen:
======================================
In diesem Schritt passen wir unsere Menü Items an.
öffnet Resources\menu\navigation.xml und ändert den Code wie folgt ab.

```xml
<?xml version="1.0" encoding="utf-8"?>
<menu xmlns:android="http://schemas.android.com/apk/res/android">
  <item
    android:id="@+id/navigation_home"
    android:icon="@drawable/ic_home_black_24dp"
    android:title="@string/title_home" />

  <item
    android:id="@+id/navigation_settings"
    android:icon="@drawable/ic_dashboard_black_24dp"
    android:title="@string/title_settings" />

</menu>
```

Jetzt haben wir zwei Menü Items erstellt.
1. android:id
   * Gibt die ID an. Mit dieser können wir später im Code auf unser Layout Objekt zugreifen / z.B. FindViewByID<TextView>(Resource.Id.textView1)
2. android:icon
   * verweist auf eine Bilddatei im drawable Ordner (Resource.Id.textView1)
3. android:title
   * Hier kann man den Text festlegen. In diesem Fall verweisen wir auf einen festgelegten String in der Resource\values\strings.xml Datei


Danach müssen wir die Resource\values\strings.xml Datei bearbeiten damit sie wie folgt aussieht:

```xml
<resources>
  <string name="app_name">FirstApp</string>
  <string name="title_home">Übersicht</string>
  <string name="title_settings">Einstellungen</string>
</resources>
```

Schritt 3: Fragmente (Seiten) erstellen
=======================================
Als nächstes erstellen wir uns Fragmente die unsere Seiten, zwischen denen wir navigieren können, festlegen.
Dazu erstellen wir 2 Android-Layout Dateien im Resource\layout Ordner
  1. fragment_home.axml
  2. fragment_settings.axml

![alt text](https://github.com/LysergixSound/CSharp-XamarinAndroid-2/blob/master/Images/projectFragmentCreate.png)

Beide Layouts beinhalten nur einen Button. Die Datei sieht wie folgt aus:

1. fragment_home.axml
      ```xml
      <?xml version="1.0" encoding="utf-8"?>
      <LinearLayout
      	xmlns:android="http://schemas.android.com/apk/res/android"
      	android:orientation="vertical"
      	android:layout_width="match_parent"
      	android:layout_height="match_parent"
      	android:padding="20dp"
      	android:gravity="center">
      	<Button
      		android:text="Übersicht"
      		android:layout_width="match_parent"
      		android:layout_height="wrap_content"
      		android:minWidth="25px"
      		android:minHeight="25px"
      		android:id="@+id/buttonHome" />

      </LinearLayout>
      ```
      
2. fragment_settings.axml
      ```xml
      <?xml version="1.0" encoding="utf-8"?>
      <LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
          android:orientation="vertical"
          android:layout_width="match_parent"
          android:layout_height="match_parent"
      	android:padding="20dp"
      	android:gravity="center">
      	<Button
      		android:text="Einstellungen"
      		android:layout_width="match_parent"
      		android:layout_height="wrap_content"
      		android:minWidth="25px"
      		android:minHeight="25px"
      		android:id="@+id/buttonSettings" />

      </LinearLayout>
      ```

Wir haben jetzt 2 Layouts designt die jeweils einen Button enthalten. Die Buttons haben wir buttonSettings und buttonHome genannt.
Nun erstellen wir unsere Code Datein für die Fragmente. Dazu erstellen wir direkt in userem Projekt 2 Fragmente:
 1. FragmentHome.cs
 2. FragmentSettings.cs

![alt text](https://github.com/LysergixSound/CSharp-XamarinAndroid-2/blob/master/Images/projectFragmentCreateCode.png)

Den Code der Dateien ändern wir wie folgt ab:
 1. FragmentHome.cs
      ```cs
      using Android.OS;
      using Android.Views;

      namespace FirstApp
      {
          public class FragmentHome : Android.Support.V4.App.Fragment
          {
              public override void OnCreate(Bundle savedInstanceState)
              {
                  base.OnCreate(savedInstanceState);

                  // Create your fragment here
              }

              public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
              {
                  // Use this to return your custom view for this Fragment
                  // Diese Zeile weißt dem Fragment unser erstelltes Layout zu
                  // Resource.Layout.fragment_home
                  return inflater.Inflate(Resource.Layout.fragment_home, container, false);   
              }
          }
      }
      ```
      
 2. FragmentSettings.cs

      ```cs
      using Android.OS;
      using Android.Views;

      namespace FirstApp
      {
          public class FragmentSettings : Android.Support.V4.App.Fragment
          {
              public override void OnCreate(Bundle savedInstanceState)
              {
                  base.OnCreate(savedInstanceState);

                  // Create your fragment here
              }

              public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
              {
                  // Use this to return your custom view for this Fragment
                  // Diese Zeile weißt dem Fragment unser erstelltes Layout zu
                  // Resource.Layout.fragment_settings
                  return inflater.Inflate(Resource.Layout.fragment_settings, container, false);
              }
          }
      }
      ```


Schritt 4: Unsere erstellten Fragmente der MainActivity zuweisen
================================================================

Dies ist der letzte Schritt. Wir müssen unsere Fragmente jetzt der MainActivity zuweisen, sodass wir zwischen ihnen navigieren können.
Außerdem müssen wir unsere Resource\layout\activity_main.axml anpassen, damit sie unsere Fragmente anzeigen kann.

Wir öffnen Resource\layout\activity_main.axml und fügen ein FrameLayout ein. Diesem FrameLayout können wir dann unsere Fragmente zuweisen
Der Code sieht wie folgt aus:
  
  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <RelativeLayout xmlns:android="http://schemas.android.com/apk/res/android"
      xmlns:app="http://schemas.android.com/apk/res-auto"
      xmlns:tools="http://schemas.android.com/tools"
      android:id="@+id/container"
      android:layout_width="match_parent"
      android:layout_height="match_parent">

      <FrameLayout
      		android:id="@+id/content_frame"
      		android:layout_width="match_parent"
      		android:layout_height="match_parent"
      		android:layout_above="@+id/navigation" />

      <android.support.design.widget.BottomNavigationView
          android:id="@+id/navigation"
          android:layout_width="wrap_content"
          android:layout_height="wrap_content"
          android:layout_marginEnd="0dp"
          android:layout_marginStart="0dp"
          android:background="?android:attr/windowBackground"
          android:layout_alignParentBottom="true"
          app:menu="@menu/navigation" />

  </RelativeLayout>
  ```
  
Unser FrameLayout haben wir content_frame genannt.
In unserer \MainActivity.cs erstellen wir nun eine Liste mit unseren Fragmenten und laden diese dann in unser content_frame
Der Code sieht wie folgt aus:

        ```cs
        // Liste unserer Fragmente definieren
        List<Android.Support.V4.App.Fragment> fragments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // unser Layout \Resource\layout\activity_main.axml laden
            SetContentView(Resource.Layout.activity_main);


            fragments = new List<Android.Support.V4.App.Fragment>();  // Liste erstellen
            fragments.Add(new FragmentHome());                        // FragmentHome hinzufügen
            fragments.Add(new FragmentSettings());                    // FragmentSettings hinzufügen

            // Lade start Fragment (In unserem Fall FragmentHome)
            SupportFragmentManager.BeginTransaction()
                                    .Replace(Resource.Id.content_frame, fragments[0])
                                    .Commit();

            // Unter Navigationsleiste holen und Click Event Handler setzen
            // event Methode public bool OnNavigationItemSelected(IMenuItem item)
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                // Navigationsitem Home (Übersicht) wurde gedrückt
                case Resource.Id.navigation_home:
                    // Lade Übersichtsfragment
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragments[0])
                                            .Commit();
                    return true;

                // Navigationsitem Settings (Einstellungen) wurde gedrückt
                case Resource.Id.navigation_settings:
                    // Lade Einstellungsfragment
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragments[1])
                                            .Commit();
                    return true;
            }
            return false;
        }
        ```
        
Das wars auch. Wir haben nun eine App mit 2 Seiten zwischen denen wir mittels einer BottemNavigationBar navigieren können.
