package com.example.pingpong;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;
import android.content.res.Configuration;
import android.os.Bundle;

import java.util.Locale;

import com.android.volley.RequestQueue;
import com.android.volley.toolbox.Volley;

/**
 * The Main Activity contains 2 buttons :
 * - Create & Play a New Game
 * - Go to History of Games
 */
public class MainActivity extends AppCompatActivity {

    Context context;
    Resources resources;
    TextView title;

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
            }else if (String.valueOf(v.getTag()).equals("fr")) {
                setLocale(MainActivity.this,"fr");
                finish();
                startActivity(getIntent());
            }else if (String.valueOf(v.getTag()).equals("en")) {
                setLocale(MainActivity.this,"en");
                finish();
                startActivity(getIntent());
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

        Button btnFr = (Button)findViewById(R.id.btnFr);
        btnFr.setOnClickListener(onClickListener);

        Button btnEnglish = (Button)findViewById(R.id.btnEnglish);
        btnEnglish.setOnClickListener(onClickListener);

        title = (TextView)findViewById(R.id.TextView01);
    }

    public static void setLocale(Activity activity, String languageCode) {
        Locale locale = new Locale(languageCode);
        Locale.setDefault(locale);
        Resources resources = activity.getResources();
        Configuration config = resources.getConfiguration();
        config.setLocale(locale);
        resources.updateConfiguration(config, resources.getDisplayMetrics());
    }
}