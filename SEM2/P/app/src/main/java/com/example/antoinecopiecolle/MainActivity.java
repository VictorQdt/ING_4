package com.example.antoinecopiecolle;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;


public class MainActivity extends AppCompatActivity {

    Button new_match_btn;
    Button match_precedents_btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        new_match_btn = (Button) findViewById(R.id.new_fight);
        match_precedents_btn = (Button) findViewById(R.id.previous_fights);

        new_match_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openPreparatifs();
            }
        });
        match_precedents_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openHistorique();
            }
        });
    }

    public void openPreparatifs() {
        Intent intent_new_fight = new Intent(this, com.example.antoinecopiecolle.Preparation.class);
        startActivity(intent_new_fight);
        Toast.makeText(com.example.antoinecopiecolle.MainActivity.this, "Nouveau Combat !", Toast.LENGTH_SHORT).show();
    }

    public void openHistorique() {
        Intent intent_historique = new Intent(this, Historique.class);
        startActivity(intent_historique);
        Toast.makeText(com.example.antoinecopiecolle.MainActivity.this, "Archive", Toast.LENGTH_SHORT).show();
    }
}
