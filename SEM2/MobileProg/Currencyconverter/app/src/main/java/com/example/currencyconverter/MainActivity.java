package com.example.currencyconverter;

import android.os.Bundle;

import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.view.View;

import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    EditText text;

    public void myClickHandler(View view) {
        switch (view.getId()) {
            case R.id.button:
                RadioButton euroButton = (RadioButton) findViewById(R.id.radio0);
                RadioButton dollarButton = (RadioButton) findViewById(R.id.radio1);
                if (text.getText().length() == 0) {
                    Toast.makeText(this, "please enter valid number", Toast.LENGTH_LONG).show();
                    return;
                }

                float inputValue = Float.parseFloat(text.getText().toString());
                if (euroButton.isChecked()) {
                    text.setText(String.valueOf(convertDollarToEuro(inputValue)));
                    euroButton.setChecked(false);
                    dollarButton.setChecked(true);
                } else {
                    text.setText(String.valueOf(convertEuroToDollar(inputValue)));
                    dollarButton.setChecked(false);
                    euroButton.setChecked(true);
                }
                break;
            case R.id.default_activity_button:
                break;
        }
    }

    //Convert dollar to euro
    private float convertDollarToEuro(float dollar) {
        return (float) (dollar / 1.1669);
    }

    //Convert euro to dollar
    private float convertEuroToDollar(float euro) {
        return (float) (euro * 1.1669);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        text = (EditText) findViewById(R.id.editText1);

        FloatingActionButton fab = findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}