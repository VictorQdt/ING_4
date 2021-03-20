package com.example.pingpong;

import android.os.Bundle;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class History extends AppCompatActivity {

    private TextView gameInfos;
    private MySQLiteGameHelper mySQLiteGameHelper;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_history);

        /**
        gameInfos = (TextView) findViewById(R.id.gameInfos);
        mySQLiteGameHelper = new MySQLiteGameHelper(this);

        mySQLiteGameHelper.startGame("Quidet", "Tété", 2, 0);
        mySQLiteGameHelper.startGame("zob", "zoulou", 3, 1);

        mySQLiteGameHelper.close();**/
    }
}