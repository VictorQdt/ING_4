package com.example.pingpong;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.RequestQueue;
import com.android.volley.toolbox.Volley;

/**
 * The Main Activity contains 2 buttons :
 * - Create & Play a New Game
 * - Go to History of Games
 */
public class MainActivity extends AppCompatActivity {

    /**
     * Listener for the choice of the button
     */
    static RequestQueue requestQueue;
    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            if(String.valueOf(v.getTag()).equals("newGameTag")){
                Singleton.getInstance().reset();
                Intent i = new Intent(MainActivity.this,HomeActivity.class);
                startActivity(i);
            }else if (String.valueOf(v.getTag()).equals("historyTag")){
                Intent i = new Intent(MainActivity.this, History.class);
                startActivity(i);
            }
        }
    };

    /**
     * Creation of the layout
     * @param savedInstanceState
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        requestQueue = Volley.newRequestQueue(this);
        Button btn_newGame = (Button)findViewById(R.id.btn_newGame);
        btn_newGame.setOnClickListener(onClickListener);

        Button btn_history = (Button)findViewById(R.id.btn_history);
        btn_history.setOnClickListener(onClickListener);
    }
}