package com.example.project;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import java.io.Console;

public class MainActivity extends AppCompatActivity {

    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            if(String.valueOf(v.getTag()).equals("newgame")){
                Intent i = new Intent(MainActivity.this, NewGameActivity.class);
                startActivity(i);
            }else{
            }
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button btn_newGame = (Button)findViewById(R.id.btn_newGame);
        btn_newGame.setOnClickListener(onClickListener);

        Button btn_history = (Button)findViewById(R.id.btn_history);
        btn_history.setOnClickListener(onClickListener);
    }
}