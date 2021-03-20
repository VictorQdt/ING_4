package com.example.pingpong;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    public String  namePlayer1;

    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {

            if(String.valueOf(v.getTag()).equals("newgame")){
                Singleton.getInstance().reset();
                Intent i = new Intent(MainActivity.this,HomeFragment.class);
                startActivity(i);
            }else if (String.valueOf(v.getTag()).equals("historyTag")){
                Intent i = new Intent(MainActivity.this, History.class);
                startActivity(i);
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