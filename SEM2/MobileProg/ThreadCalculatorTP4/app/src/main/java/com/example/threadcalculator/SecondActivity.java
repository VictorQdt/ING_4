package com.example.threadcalculator;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class SecondActivity extends AppCompatActivity {
    TextView operationView;
    EditText editURL;
    Bundle extras;
    Button submit;
    View.OnClickListener onClickListener = new View.OnClickListener(){

        @Override
        public void onClick(View v) {
            String webpage = editURL.getText().toString();
            Intent intent = new Intent(SecondActivity.this, ThirdActivity.class);
                intent.putExtra("url", webpage);
                startActivity(intent);

        }
    };
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.second_layout);
        super.onCreate(savedInstanceState);
        submit = (Button) findViewById(R.id.submit);
        submit.setOnClickListener(onClickListener);
        extras = getIntent().getExtras();
        editURL = (EditText) findViewById(R.id.editURL);
        operationView = (TextView) findViewById(R.id.operationView);
        operationView.setText(extras.getString("LAST_OPERATION"));

    }
}
