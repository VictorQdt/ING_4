package com.example.antoinecopiecolle;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class Combat extends AppCompatActivity {

    //Pour passer les données jusqu'à Map, pour y créer la SQLite
    public static final String VAINQUEUR = "com.example.antoinecopiecolle.extra.VAINQUEUR";
    public static final String TYPE_DE_VICTOIRE = "com.example.antoinecopiecolle.extra.TYPE_DE_VICTOIRE";

    public static final String NBR_RED_JAB = "com.example.antoinecopiecolle.extra.NBR_RED_JAB";
    public static final String NBR_RED_UPPERCUT = "com.example.antoinecopiecolle.extra.NBR_RED_UPPERCUT";
    public static final String NBR_RED_KICK = "com.example.antoinecopiecolle.extra.NBR_RED_KICK";
    public static final String NBR_RED_TACKLE = "com.example.antoinecopiecolle.extra.NBR_RED_TACKLE";
    public static final String NBR_RED_IMMO = "com.example.antoinecopiecolle.extra.NBR_RED_IMMO";

    public static final String NBR_BLUE_JAB = "com.example.antoinecopiecolle.extra.NBR_BLUE_JAB";
    public static final String NBR_BLUE_UPPERCUT = "com.example.antoinecopiecolle.extra.NBR_BLUE_UPPERCUT";
    public static final String NBR_BLUE_KICK = "com.example.antoinecopiecolle.extra.NBR_BLUE_KICK";
    public static final String NBR_BLUE_TACKLE = "com.example.antoinecopiecolle.extra.NBR_BLUE_TACKLE";
    public static final String NBR_BLUE_IMMO = "com.example.antoinecopiecolle.extra.NBR_BLUE_IMMO";

    TextView nom_combattant_un;
    TextView nom_combattant_deux;
    //Les dernieres actions "sauvegardées"
    ImageView action_tmp_one;
    ImageView action_tmp_two;
    ImageView action_tmp_three;
    ImageView action_tmp_four;
    ImageView action_tmp_five;
    ImageView action_tmp_six;
    //Les boutons
    Button red_jab_btn;
    Button red_uppercut_btn;
    Button red_kick_btn;
    Button red_tackle_btn;
    Button red_immo_btn;
    Button blue_jab_btn;
    Button blue_uppercut_btn;
    Button blue_kick_btn;
    Button blue_tackle_btn;
    Button blue_immo_btn;

    //Les compteurs d'actions pour la bdd SQLight
    int nbr_red_jab = 0;
    int nbr_red_uppercut = 0;
    int nbr_red_kick = 0;
    int nbr_red_tackle = 0;
    int nbr_red_immo = 0;

    int nbr_blue_jab = 0;
    int nbr_blue_uppercut = 0;
    int nbr_blue_kick = 0;
    int nbr_blue_tackle = 0;
    int nbr_blue_immo = 0;

    String nbr_rounds = "undefined";
    String categorie_poids = "undefined";

    String vainqueur = "undefined";
    String type_de_victoire = "undefined";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_combat);

        nom_combattant_un = (TextView) findViewById(R.id.textview_comattant_un);
        nom_combattant_deux = (TextView) findViewById(R.id.textview_comattant_deux);
        action_tmp_one = (ImageView) findViewById(R.id.action_tmp_one);
        action_tmp_two = (ImageView) findViewById(R.id.action_tmp_two);
        action_tmp_three = (ImageView) findViewById(R.id.action_tmp_three);
        action_tmp_four = (ImageView) findViewById(R.id.action_tmp_four);
        action_tmp_five = (ImageView) findViewById(R.id.action_tmp_five);
        action_tmp_six = (ImageView) findViewById(R.id.action_tmp_six);
        red_jab_btn = (Button) findViewById(R.id.jab_un_btn);
        red_uppercut_btn = (Button) findViewById(R.id.uppercut_un_btn);
        red_kick_btn = (Button) findViewById(R.id.kick_un_btn);
        red_tackle_btn = (Button) findViewById(R.id.tackle_un_btn);
        red_immo_btn = (Button) findViewById(R.id.immobilisation_un_btn);
        blue_jab_btn = (Button) findViewById(R.id.jab_deux_btn);
        blue_uppercut_btn = (Button) findViewById(R.id.uppercut_deux_btn);
        blue_kick_btn = (Button) findViewById(R.id.kick_deux_btn);
        blue_tackle_btn = (Button) findViewById(R.id.tackle_deux_btn);
        blue_immo_btn = (Button) findViewById(R.id.immobilisation_deux_btn);

        //Récupération des noms des combattants via Intent
        Intent intent = getIntent();
        nom_combattant_un.setText(intent.getStringExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_UN));
        nom_combattant_deux.setText(intent.getStringExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_DEUX));

        nbr_rounds = intent.getStringExtra(com.example.antoinecopiecolle.Preparation.NOMBRE_DE_ROUNDS);
        categorie_poids = intent.getStringExtra(com.example.antoinecopiecolle.Preparation.CATEGORIE_POIDS);

    }

    //Quand on clique sur n'importe lequel des 12 boutons d'action
    public void onActionBtnClicked(View view) {
        //On transfère les images un rang vers la gauche
        action_tmp_one.setImageDrawable(action_tmp_two.getDrawable());
        action_tmp_two.setImageDrawable(action_tmp_three.getDrawable());
        action_tmp_three.setImageDrawable(action_tmp_four.getDrawable());
        action_tmp_four.setImageDrawable(action_tmp_five.getDrawable());
        action_tmp_five.setImageDrawable(action_tmp_six.getDrawable());
        //Le sixième prend le bon icon en fonction du bouton cliqué
        switch (view.getTag().toString()) {
            case "jab_un_btn":
                action_tmp_six.setImageResource(R.drawable.red_jab);
                nbr_red_jab++;
                break;
            case "jab_deux_btn":
                action_tmp_six.setImageResource(R.drawable.blue_jab);
                nbr_blue_jab++;
                break;
            case "uppercut_un_btn":
                action_tmp_six.setImageResource(R.drawable.red_upper);
                nbr_red_uppercut++;
                break;
            case "uppercut_deux_btn":
                action_tmp_six.setImageResource(R.drawable.blue_upper);
                nbr_blue_uppercut++;
                break;
            case "kick_un_btn":
                action_tmp_six.setImageResource(R.drawable.red_kick);
                nbr_red_kick++;
                break;
            case "kick_deux_btn":
                action_tmp_six.setImageResource(R.drawable.blue_kick);
                nbr_blue_kick++;
                break;
            case "tackle_un_btn":
                action_tmp_six.setImageResource(R.drawable.red_tackle);
                nbr_red_tackle++;
                break;
            case "tackle_deux_btn":
                action_tmp_six.setImageResource(R.drawable.blue_tackle);
                nbr_blue_tackle++;
                break;
            case "immobilisation_un_btn":
                action_tmp_six.setImageResource(R.drawable.red_immobilisation);
                nbr_red_immo++;
                break;
            case "immobilisation_deux_btn":
                action_tmp_six.setImageResource(R.drawable.blue_immobilisation);
                nbr_blue_immo++;
                break;
            default:
                Toast.makeText(this, "erreur : tag = " + view.getTag().toString(), Toast.LENGTH_SHORT).show();
        }
    }

    /**
     * Afficher le menu
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_combat, menu);
        return true;
    }

    /**
     * Quand on selectionne l'option du menu
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        Intent intent_vers_photo = new Intent(this, Camera.class);

        intent_vers_photo.putExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_UN, nom_combattant_un.getText().toString());
        intent_vers_photo.putExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_DEUX, nom_combattant_deux.getText().toString());

        intent_vers_photo.putExtra(com.example.antoinecopiecolle.Preparation.NOMBRE_DE_ROUNDS, nbr_rounds);
        intent_vers_photo.putExtra(com.example.antoinecopiecolle.Preparation.CATEGORIE_POIDS, categorie_poids);

        intent_vers_photo.putExtra(NBR_RED_JAB, String.valueOf(nbr_red_jab));
        intent_vers_photo.putExtra(NBR_RED_UPPERCUT, String.valueOf(nbr_red_uppercut));
        intent_vers_photo.putExtra(NBR_RED_KICK, String.valueOf(nbr_red_kick));
        intent_vers_photo.putExtra(NBR_RED_TACKLE, String.valueOf(nbr_red_tackle));
        intent_vers_photo.putExtra(NBR_RED_IMMO, String.valueOf(nbr_red_immo));

        intent_vers_photo.putExtra(NBR_BLUE_JAB, String.valueOf(nbr_blue_jab));
        intent_vers_photo.putExtra(NBR_BLUE_UPPERCUT, String.valueOf(nbr_blue_uppercut));
        intent_vers_photo.putExtra(NBR_BLUE_KICK, String.valueOf(nbr_blue_kick));
        intent_vers_photo.putExtra(NBR_BLUE_TACKLE, String.valueOf(nbr_blue_tackle));
        intent_vers_photo.putExtra(NBR_BLUE_IMMO, String.valueOf(nbr_blue_immo));

        //Pour chaque cas, on stoque le vainqueur et le type de victoire pour la bdd SQLight
        switch (item.getItemId()){
            case R.id.vic_one_ko :
                vainqueur = nom_combattant_un.getText().toString();
                type_de_victoire = "K.O.";
                intent_vers_photo.putExtra(VAINQUEUR, vainqueur);
                intent_vers_photo.putExtra(TYPE_DE_VICTOIRE, type_de_victoire);
                Toast.makeText(this, nom_combattant_un.getText().toString() + " - Victoire Par K.O.", Toast.LENGTH_SHORT).show();
                startActivity(intent_vers_photo);
                return true;
            case R.id.vic_one_tko :
                vainqueur = nom_combattant_un.getText().toString();
                type_de_victoire = "T.K.O.";
                intent_vers_photo.putExtra(VAINQUEUR, vainqueur);
                intent_vers_photo.putExtra(TYPE_DE_VICTOIRE, type_de_victoire);
                Toast.makeText(this, nom_combattant_un.getText().toString() + " - Victoire Par T.K.O.", Toast.LENGTH_SHORT).show();
                startActivity(intent_vers_photo);
                return true;
            case R.id.vic_one_soumission :
                vainqueur = nom_combattant_un.getText().toString();
                type_de_victoire = "Soumission";
                intent_vers_photo.putExtra(VAINQUEUR, vainqueur);
                intent_vers_photo.putExtra(TYPE_DE_VICTOIRE, type_de_victoire);
                Toast.makeText(this, nom_combattant_un.getText().toString() + " - Victoire Par Soumission", Toast.LENGTH_SHORT).show();
                startActivity(intent_vers_photo);
                return true;
            case R.id.vic_two_ko :
                vainqueur = nom_combattant_deux.getText().toString();
                type_de_victoire = "K.O.";
                intent_vers_photo.putExtra(VAINQUEUR, vainqueur);
                intent_vers_photo.putExtra(TYPE_DE_VICTOIRE, type_de_victoire);
                Toast.makeText(this, nom_combattant_deux.getText().toString() + " - Victoire Par K.O.", Toast.LENGTH_SHORT).show();
                startActivity(intent_vers_photo);
                return true;
            case R.id.vic_two_tko :
                vainqueur = nom_combattant_deux.getText().toString();
                type_de_victoire = "T.K.O.";
                intent_vers_photo.putExtra(VAINQUEUR, vainqueur);
                intent_vers_photo.putExtra(TYPE_DE_VICTOIRE, type_de_victoire);
                Toast.makeText(this, nom_combattant_deux.getText().toString() + " - Victoire Par T.K.O.", Toast.LENGTH_SHORT).show();
                startActivity(intent_vers_photo);
                return true;
            case R.id.vic_two_soumission :
                vainqueur = nom_combattant_deux.getText().toString();
                type_de_victoire = "Soumission";
                intent_vers_photo.putExtra(VAINQUEUR, vainqueur);
                intent_vers_photo.putExtra(TYPE_DE_VICTOIRE, type_de_victoire);
                Toast.makeText(this, nom_combattant_deux.getText().toString() + " - Victoire Par Soumission", Toast.LENGTH_SHORT).show();
                startActivity(intent_vers_photo);
                return true;

            default :
                return super.onOptionsItemSelected(item);
        }

    }
}
