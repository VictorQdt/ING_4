package com.example.antoinecopiecolle;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class Preparation extends AppCompatActivity implements AdapterView.OnItemSelectedListener {

    public static final String NOM_COMBATTANT_UN = "com.example.antoinecopiecolle.extra.NOM_COMBATTANT_UN";
    public static final String NOM_COMBATTANT_DEUX = "com.example.antoinecopiecolle.extra.NOM_COMBATTANT_DEUX";

    public static final String NOMBRE_DE_ROUNDS = "com.example.antoinecopiecolle.extra.NOMBRE_DE_ROUNDS";
    public static final String CATEGORIE_POIDS = "com.example.antoinecopiecolle.extra.CATEGORIE_POIDS";

    EditText fighter_one;
    EditText fighter_two;
    String type_de_poids = "";
    String nombre_de_rounds = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_preparatifs);

        //Déclaration des Views + affiliation
        fighter_one = (EditText) findViewById(R.id.edit_fighter1);
        fighter_two = (EditText) findViewById(R.id.edit_fighter2);

        //SPINNER
        //déclaration des spinner
        Spinner spinner_fight_type = findViewById(R.id.spinner_fight_type);
        Spinner spinner_weight_type = findViewById(R.id.spinner_weight_type);
        //Remplissage du spinner fight avec l'array qui se trouve dans string.xml
        ArrayAdapter<CharSequence> adapter_fight = ArrayAdapter.createFromResource(this, R.array.fight_type, android.R.layout.simple_spinner_item);
        adapter_fight.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner_fight_type.setAdapter(adapter_fight);
        spinner_fight_type.setOnItemSelectedListener(this);
        //Remplissage du spinner weight
        ArrayAdapter<CharSequence> adapter_weight = ArrayAdapter.createFromResource(this, R.array.weight_type, android.R.layout.simple_spinner_item);
        adapter_weight.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner_weight_type.setAdapter(adapter_weight);
        spinner_weight_type.setOnItemSelectedListener(this);

    }

    /**
     * Afficher le menu
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_preparatifs, menu);
        return true;
    }

    /**
     * Quand on selectionne l'option du menu
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.menu_preparation:
                Intent intent_combat = new Intent(this, Combat.class);
                intent_combat.putExtra(NOM_COMBATTANT_UN, fighter_one.getText().toString());
                intent_combat.putExtra(NOM_COMBATTANT_DEUX, fighter_two.getText().toString());
                intent_combat.putExtra(NOMBRE_DE_ROUNDS, nombre_de_rounds);
                intent_combat.putExtra(CATEGORIE_POIDS, type_de_poids);
                Toast.makeText(this, "FIGHT !", Toast.LENGTH_SHORT).show();
                startActivity(intent_combat);
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    /**
     * Quand on selectionne une option de spinner
     */
    @Override
    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {

        switch (adapterView.getTag().toString()) {
            case "poids":
                //Le remplissage de la variable pour la bdd SQLight
                type_de_poids = adapterView.getItemAtPosition(i).toString();
                //Le Toast
                Toast.makeText(adapterView.getContext(), type_de_poids, Toast.LENGTH_SHORT).show();
                break;
            case "rounds":
                nombre_de_rounds = adapterView.getItemAtPosition(i).toString();
                Toast.makeText(adapterView.getContext(), nombre_de_rounds, Toast.LENGTH_SHORT).show();
                break;
            default:
                Toast.makeText(adapterView.getContext(), "No match for spinner tag : " + adapterView.getTag().toString(), Toast.LENGTH_SHORT).show();
        }
    }

    /**
     * Quand rien n'est sélcetionné (concernant le spinner) -- fonction obligatoire pour
     * l'implements AdapterView.OnItemSelectedListener
     */
    @Override
    public void onNothingSelected(AdapterView<?> adapterView) {

    }

}
