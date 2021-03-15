package com.example.pingpong;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

import com.google.android.material.bottomnavigation.BottomNavigationView;

public class MainActivity extends AppCompatActivity {

    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            if(String.valueOf(v.getTag()).equals("newgame")){
                Intent i = new Intent(MainActivity.this, GameActivity.class);
                startActivity(i);
            }else{
                //nothing for the moment
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