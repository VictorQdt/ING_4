package com.example.pingpong;

import android.os.Bundle;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.List;

public class History extends AppCompatActivity {

    private TextView gameInfos;
    private MySQLiteGameHelper mySQLiteGameHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_history);

    }
}