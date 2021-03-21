package com.example.pingpong;

import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentTransaction;

import java.util.ArrayList;
import java.util.List;

/**
 * Activity empty for the 2 fragments ListGames (default) & Statistics
 */
public class History extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_history);
        getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new ListGamesFragment()).commit();
    }
}