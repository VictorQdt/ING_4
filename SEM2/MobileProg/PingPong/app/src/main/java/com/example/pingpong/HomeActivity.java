package com.example.pingpong;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;


import com.google.android.material.bottomnavigation.BottomNavigationView;

import static com.example.pingpong.R.id.nav_home;
import static com.example.pingpong.R.id.nav_map;
import static com.example.pingpong.R.id.nav_photo;

public class HomeActivity extends AppCompatActivity {


    private final BottomNavigationView.OnNavigationItemSelectedListener navListener =
            new BottomNavigationView.OnNavigationItemSelectedListener() {
                @SuppressLint("ResourceType")
                @Override
                public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                    Fragment selectedFragment = null;

                    //Create the fragments
                    switch (item.getItemId()) {
                        case nav_home:
                            if(!Singleton.getInstance().isStarted()) {
                                Intent intent = getIntent();
                                finish();
                                startActivity(intent);
                            }else if (Singleton.getInstance().getWinnersName() != "")  getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new EndGameFragment()).commit();
                            else getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new NewPoint()).commit();
                            break;
                        case nav_map:
                            selectedFragment = new MapFragment();
                            //Show the fragment selected
                            getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, selectedFragment).commit();
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

    protected void onCreate (Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        BottomNavigationView bottomNav = findViewById(R.id.bottom_navigation_view);
        bottomNav.setOnNavigationItemSelectedListener(navListener);
        getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new NewMatchFragment()).commit();

    }
}
