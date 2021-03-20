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

        gameInfos = (TextView) findViewById(R.id.gameInfos);
        mySQLiteGameHelper = new MySQLiteGameHelper(this);

        mySQLiteGameHelper.createGame(1, "Quidet", "Tété", 2, 0);
        mySQLiteGameHelper.createGame(2, "zob", "zoulou", 3, 1);
        mySQLiteGameHelper.createGame(3, "olala", "zola", 2, 1);


        mySQLiteGameHelper.close();
    }
}