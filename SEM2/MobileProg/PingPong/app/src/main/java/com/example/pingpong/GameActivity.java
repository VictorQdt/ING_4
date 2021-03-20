package com.example.pingpong;

import android.os.Bundle;
import android.view.MenuItem;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import static com.example.pingpong.R.id.nav_home;
import static com.example.pingpong.R.id.nav_map;
import static com.example.pingpong.R.id.nav_photo;

public class GameActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game);

        BottomNavigationView bottomNav = findViewById(R.id.bottom_navigation);
        bottomNav.setOnNavigationItemSelectedListener(navListener);

        //We open the HomeFragment first by default
        getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new HomeFragment()).commit();
    }

    //Bottom Navigation Listener
    private final BottomNavigationView.OnNavigationItemSelectedListener navListener =
            new BottomNavigationView.OnNavigationItemSelectedListener() {
                @Override
                public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                    Fragment selectedFragment = null;

                    //Create the fragments
                    switch (item.getItemId()) {
                        case nav_home:
                            selectedFragment = new HomeFragment();
                            break;
                        case nav_map:
                            selectedFragment = new MapFragment();
                            break;
                        case nav_photo:
                            selectedFragment = new PhotoFragment();
                            break;
                    }

                    //Show the fragment selected
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, selectedFragment).commit();

                    //Return a true boolean because we selected an item (the fragment)
                    return true;
                }
            };
}