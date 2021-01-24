package com.example.threadcalculator;

import android.os.AsyncTask;
import android.os.Bundle;

import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.os.Handler;
import android.view.View;

import android.view.Menu;
import android.view.MenuItem;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    Button button0, button1, button2, button3, button4, button5, button6,
            button7, button8, button9;
    Button buttonAdd, buttonSub, buttonMul, buttonDivided, buttonEqual;
    TextView operationView, resultView;
    String my_operation = "";
    LinearLayout linearLayout;
    private Handler handler;
    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            if ((my_operation.length() < 3) || (String.valueOf(view.getTag()).equals("="))) {
                if (!(String.valueOf(view.getTag()).equals("="))) {
                    operationView = (TextView) findViewById(R.id.operationView);
                    my_operation = my_operation.concat(String.valueOf(view.getTag()));
                    operationView.setText(my_operation);
                } else {
                    /*Runnable runnable = new Runnable() {          Method using threads and handlers
                        @Override
                        public void run() {
                            String result = calculation(my_operation);
                            handler.post(new Runnable() {
                                @Override
                                public void run() {
                                    resultView = (TextView) findViewById(R.id.resultView);
                                    resultView.setText(result);
                                }
                            });
                        }
                    };
                    new Thread(runnable).start();*/
                    new Calculation().execute(my_operation); // Method using AsyncTask
                }
            }
        }
    };

    public class Calculation extends AsyncTask<String, Void, String> {
        View view;
        String result;
        @Override
        protected String doInBackground(String... strings) {
            result = calculation(strings[0]);
            return result;
        }

        @Override
        protected void onPostExecute(String s) {
            resultView = (TextView) findViewById(R.id.resultView);
            resultView.setText(result);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        button0 = (Button) findViewById(R.id.button0);
        button0.setOnClickListener(onClickListener);

        button1 = (Button) findViewById(R.id.button1);
        button1.setOnClickListener(onClickListener);

        button2 = (Button) findViewById(R.id.button2);
        button2.setOnClickListener(onClickListener);

        button3 = (Button) findViewById(R.id.button3);
        button3.setOnClickListener(onClickListener);

        button4 = (Button) findViewById(R.id.button4);
        button4.setOnClickListener(onClickListener);

        button5 = (Button) findViewById(R.id.button5);
        button5.setOnClickListener(onClickListener);

        button6 = (Button) findViewById(R.id.button6);
        button6.setOnClickListener(onClickListener);

        button7 = (Button) findViewById(R.id.button7);
        button7.setOnClickListener(onClickListener);

        button8 = (Button) findViewById(R.id.button8);
        button8.setOnClickListener(onClickListener);

        button9 = (Button) findViewById(R.id.button9);
        button9.setOnClickListener(onClickListener);

        buttonAdd = (Button) findViewById(R.id.buttonAdd);
        buttonAdd.setOnClickListener(onClickListener);

        buttonSub = (Button) findViewById(R.id.buttonSub);
        buttonSub.setOnClickListener(onClickListener);

        buttonMul = (Button) findViewById(R.id.buttonMul);
        buttonMul.setOnClickListener(onClickListener);

        buttonDivided = (Button) findViewById(R.id.buttonDivided);
        buttonDivided.setOnClickListener(onClickListener);

        //buttonEqual = (Button) findViewById(R.id.buttonEqual);
        //buttonEqual.setOnClickListener(onClickListener);

        linearLayout = (LinearLayout) findViewById(R.id.equalButtonLayout);
        Button buttonEqual = new Button(this);
        buttonEqual.setText("=");
        buttonEqual.setTag("=");
        buttonEqual.setLayoutParams(new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MATCH_PARENT,
                ViewGroup.LayoutParams.MATCH_PARENT));
        buttonEqual.setOnClickListener(onClickListener);
        if (linearLayout != null){
            linearLayout.addView(buttonEqual);
        }
        handler = new Handler();
    }

    public String calculation(String operation){
        float result = 0;
        float value_a, value_b;
        value_a = Character.getNumericValue(operation.charAt(0));
        char choice_op = operation.charAt(1);
        value_b = Character.getNumericValue(operation.charAt(2));
        switch (choice_op){
            case'+':
                result = (value_a + value_b);
                break;
            case'-':
                result = (value_a - value_b);
                break;
            case'/':
                result = (value_a / value_b);
                break;
            case'*':
                result = (value_a * value_b);
                break;
            default :
                result = 0;
                break;
        }
        return Float.toString(result);
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

