package com.example.appareilphoto;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.FileProvider;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

import java.io.File;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class MainActivity extends AppCompatActivity {

    //constante
    private static final int RETOUR_PRENDRE_PHOTO = 1;

    //propriétés
    private Button btnPrendrePhoto;
    private ImageView imgAffichePhoto;
    private String photoPath = null;
    private Button btnEnreg;
    private Bitmap img;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        initActivity();
    }

    //initialisation de l'activity
    private void initActivity(){
        //récupération des objets graphiques
        btnPrendrePhoto = (Button)findViewById(R.id.btnPrendrePhoto);
        imgAffichePhoto = (ImageView)findViewById(R.id.imgAffichePhoto);
        btnEnreg = (Button)findViewById(R.id.btnEnreg);

        //méthode pour gérer les évènements
        createOnClickBtnPrendrePhoto();
        createOnClickBtnEnreg();
    }

    /*
    * évènement clic sur boutton btnPrendrePhoto
    * */
    private void createOnClickBtnPrendrePhoto(){
        btnPrendrePhoto.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                prendrePhoto();
            }
        });
    }

    /**
     * évènement click sur Enrengistrer
     */
    private void createOnClickBtnEnreg() {
        btnEnreg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // enrengistrer la photo
                MediaStore.Images.Media.insertImage(getContentResolver(), img, "mon img", "img");
            }
        });
    }

    /**
     * Accès à l'appareil photo et mémorise dans un fichier temporaire (avec le provider)
     */
    private void prendrePhoto(){
        //creer un intent pour ouvrir une fenetre pour prendre une photo
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        //test pour controler que l'intent peut etre géré
        if(intent.resolveActivity(getPackageManager()) != null){
            //creer un nom de fichier unique qui récupère sous forme de string la date actuelle
            String time = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
            //chemin du directory où sont stockés les photos
            File photoDir = getExternalFilesDir(Environment.DIRECTORY_PICTURES);
            try {
                File photoFile = File.createTempFile("photo"+time, ".jpg", photoDir);
                //Enrengistrer le chemin complet
                photoPath = photoFile.getAbsolutePath();
                // créer l'URI (Context, provider, fichier)
                Uri photoUri = FileProvider.getUriForFile(MainActivity.this,
                        MainActivity.this.getApplicationContext().getPackageName() + ".provider",
                        photoFile);
                // transfert uri vers l'intent pour enrengistrement photo dans fichier temporaire
                intent.putExtra(MediaStore.EXTRA_OUTPUT, photoUri);
                //ouvrir l'activity par rapport à l'intent
                startActivityForResult(intent, RETOUR_PRENDRE_PHOTO);
            } catch (IOException e){
                e.printStackTrace();
            }
        }
    }

    /**
     * retour de l'appel de l'appareil photo (startActivityforResult)
     * @param requestCode = retour prendrePhoto (qui a appelé)
     * @param resultCode = est-ce que il y a bien eu un retour
     * @param data
     */
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        // vérifier le bon code de retour (requestCode) et l'état du retour (resultCode)
        if(requestCode == RETOUR_PRENDRE_PHOTO && resultCode == RESULT_OK){
            //récupérer l'image
            img = BitmapFactory.decodeFile(photoPath);
            //afficher l'image
            imgAffichePhoto.setImageBitmap(img);
        }
    }
}