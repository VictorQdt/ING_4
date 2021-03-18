package com.example.antoinecopiecolle;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class DetailsMatch extends AppCompatActivity {

    private SQLiteDatabase database;

    TextView title;

    Uri img;

    TextView vainqueur;
    TextView typeVictoire;

    TextView nombreRounds;
    TextView categoriePoids;

    TextView nbr_red_jab;
    TextView nbr_red_uppercut;
    TextView nbr_red_kick;
    TextView nbr_red_tackle;
    TextView nbr_red_immobilisation;

    TextView nbr_blue_jab;
    TextView nbr_blue_uppercut;
    TextView nbr_blue_kick;
    TextView nbr_blue_tackle;
    TextView nbr_blue_immobilisation;

    TextView latitude;
    TextView longitude;

    ImageView imageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_details_match);

        title = (TextView) findViewById(R.id.details_title);
        vainqueur = (TextView) findViewById(R.id.details_vainqueur);
        typeVictoire = (TextView) findViewById(R.id.details_typeVictoire);
        nombreRounds = (TextView) findViewById(R.id.details_nbr_round);
        categoriePoids = (TextView) findViewById(R.id.details_categoriePoids);
        nbr_red_jab = (TextView) findViewById(R.id.details_nbr_red_jab);
        nbr_red_uppercut = (TextView) findViewById(R.id.details_nbr_red_upper);
        nbr_red_kick = (TextView) findViewById(R.id.details_nbr_red_kick);
        nbr_red_tackle = (TextView) findViewById(R.id.details_nbr_red_tackle);
        nbr_red_immobilisation = (TextView) findViewById(R.id.details_nbr_red_immo);
        nbr_blue_jab = (TextView) findViewById(R.id.details_nbr_blue_jab);
        nbr_blue_uppercut = (TextView) findViewById(R.id.details_nbr_blue_upper);
        nbr_blue_kick = (TextView) findViewById(R.id.details_nbr_blue_kick);
        nbr_blue_tackle = (TextView) findViewById(R.id.details_nbr_blue_tackle);
        nbr_blue_immobilisation = (TextView) findViewById(R.id.details_nbr_blue_immo);
        latitude = (TextView) findViewById(R.id.details_latitude);
        longitude = (TextView) findViewById(R.id.details_longitude);
        imageView = (ImageView) findViewById(R.id.details_img);

        com.example.antoinecopiecolle.MatchDBHelper dbHelper = new com.example.antoinecopiecolle.MatchDBHelper(this);
        database = dbHelper.getWritableDatabase();

        Intent intent = getIntent();
        Cursor cursor = dbHelper.getInformationsNeeded(intent.getStringExtra(Historique.ID_DU_MATCH_SELECTIONNE));

        while(cursor.moveToNext()) {

            /*
            1 : fighterOne
            2 : fighterTwo
            3 : catPoids
            4 : round
            5 : latitude
            6 : longitude
            7 : red jab
            8 : red uppercut
            9 : red kick
            10 : red tackle
            11 : red immo
            12 : blue jab
            13 : blue uppercut
            14 : blue kick
            15 : blue tackle
            16 : blue immo
            17 : vainqueur
            18 : typeVictoire
            19 : image
             */

            title.setText(cursor.getString(1) + " VS " + cursor.getString(2));

            if(cursor.getBlob(19) != null){
                Bitmap bitmap_issue_du_tableau_de_bytes = BitmapFactory.decodeByteArray(cursor.getBlob(19), 0, cursor.getBlob(19).length);
                imageView.setImageBitmap(bitmap_issue_du_tableau_de_bytes);
            }
            else if(cursor.getBlob(19) == null){
               imageView.setImageResource(R.mipmap.ic_launcher_mma);
            }

            vainqueur.setText(cursor.getString(17));
            typeVictoire.setText(cursor.getString(18));

            nombreRounds.setText(cursor.getString(4));
            categoriePoids.setText(cursor.getString(3));

            nbr_red_jab.setText(cursor.getString(7));
            nbr_red_uppercut.setText(cursor.getString(8));
            nbr_red_kick.setText(cursor.getString(9));
            nbr_red_tackle.setText(cursor.getString(10));
            nbr_red_immobilisation.setText(cursor.getString(11));

            nbr_blue_jab.setText(cursor.getString(12));
            nbr_blue_uppercut.setText(cursor.getString(13));
            nbr_blue_kick.setText(cursor.getString(14));
            nbr_blue_tackle.setText(cursor.getString(15));
            nbr_blue_immobilisation.setText(cursor.getString(16));

            latitude.setText(cursor.getString(5));
            longitude.setText(cursor.getString(6));
        }
    }
}
