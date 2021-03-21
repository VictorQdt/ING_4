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

public class History extends AppCompatActivity {

    // Form
    private EditText addItem;
    private Button btnAddItem;

    // List
    private ListView listViewGames;

    //Db
    private MySQLiteGameHelper mySQLiteGameHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_history);
        //getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new ListGamesFragment()).commit();
        getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, new GameStatFragment()).commit();
    }
}