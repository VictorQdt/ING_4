package com.example.pingpong;

import android.annotation.SuppressLint;
import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;


import com.android.volley.RequestQueue;
import com.android.volley.toolbox.Volley;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GoogleApiAvailability;
import com.google.android.material.bottomnavigation.BottomNavigationView;

import static com.example.pingpong.R.id.nav_home;
import static com.example.pingpong.R.id.nav_map;
import static com.example.pingpong.R.id.nav_photo;

/**
 * Home Activity contains :
 * - An empty Fragment container
 * - A bottom navigation bar with different option (Game / Map / Photo)
 */
public class HomeActivity extends AppCompatActivity {

    /**
     * Listener of the bottom navigation bar
     * When choosing an option, a new Fragment is created
     */

    private static final String TAG = "HomeActivity";
    private static final int ERROR_DIALOG_REQUEST = 9001;


    private final BottomNavigationView.OnNavigationItemSelectedListener navListener =
            new BottomNavigationView.OnNavigationItemSelectedListener() {
                @SuppressLint("ResourceType")
                @Override
                public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                    Fragment selectedFragment = null;
                    //Create the fragments
                    switch (item.getItemId()) {
                        case nav_home:
                            if (!Singleton.getInstance().isStarted()) {
                                Intent intent = getIntent();
                                finish();
                                startActivity(intent);
                            } else if (Singleton.getInstance().getWinnersName() != "") {
                                getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new EndGameFragment()).commit();
                            } else {
                                getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new NewPoint()).commit();
                            }
                            break;
                        case nav_map:
                            if(isServicesOK()){
                                Intent i = new Intent(HomeActivity.this, MapActivity.class);
                                startActivity(i);
                            } else {
                                Log.d(TAG, "nav_map : access denied");
                            }
                            break;
                        case nav_photo:
                            selectedFragment = new PhotoFragment();
                            //Show the fragment selected
                            getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, selectedFragment).commit();
                            break;
                    }
                    //Return a true boolean because we selected an item (the fragment)
                    return true;
                }
            };

    /**
     * Create the Layout of activity
     * Inflates the New Match Layout
     *
     * @param savedInstanceState
     */
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        BottomNavigationView bottomNav = findViewById(R.id.bottom_navigation_view);
        bottomNav.setOnNavigationItemSelectedListener(navListener);
        getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new NewMatchFragment()).commit();

    }

    /**
     * Check services if option Map is choosen by the user
     * @return
     */
    public boolean isServicesOK(){
        Log.d(TAG, "isServicesOK : checking google services version");
        int available = GoogleApiAvailability.getInstance().isGooglePlayServicesAvailable(HomeActivity.this);
        if (available == ConnectionResult.SUCCESS){
            //everything is fine and the user can make map request
            Log.d(TAG,"isServicesOK: Google Play services is working");
            return true;
        } else if (GoogleApiAvailability.getInstance().isUserResolvableError(available)){
            // an error occured but we can resolve it
            Log.d(TAG,"isServicesOK: an error occured but we can resolve it");
            Dialog dialog = GoogleApiAvailability.getInstance().getErrorDialog(HomeActivity.this, available, ERROR_DIALOG_REQUEST);
            dialog.show();
        } else {
            Toast.makeText(this, "Map request not available", Toast.LENGTH_SHORT).show();
        }
        return false;
    }
}
