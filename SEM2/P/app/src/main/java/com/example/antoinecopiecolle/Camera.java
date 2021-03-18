package com.example.antoinecopiecolle;

import android.Manifest;
import android.content.ContentValues;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.io.ByteArrayOutputStream;

public class Camera extends AppCompatActivity {

    public static final String PHOTO = "com.example.antoinecopiecolle.extra.PHOTO";

    private static final int PERMISSION_CODE = 1000;
    private static final int IMAGE_CAPTURE_CODE = 1001;
    private static final int PICK_IMAGE = 100;

    Button btn_take_photo;
    Button btn_choose_photo;
    ImageView la_photo;

    Uri image_uri;

    Intent intent;
    byte[] img;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_camera);

        btn_take_photo = (Button) findViewById(R.id.btn_take_photo);
        btn_choose_photo = (Button) findViewById(R.id.btn_choose_photo);
        la_photo = (ImageView) findViewById(R.id.la_photo);

        intent = getIntent();


        btn_take_photo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //if system os is >= marshmallow, request runtime permission
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                    if (checkSelfPermission(Manifest.permission.CAMERA) == PackageManager.PERMISSION_DENIED ||
                            checkSelfPermission(Manifest.permission.WRITE_EXTERNAL_STORAGE) ==
                                    PackageManager.PERMISSION_DENIED) {
                        //permission not enabled, request it
                        String[] permission = {Manifest.permission.CAMERA, Manifest.permission.WRITE_EXTERNAL_STORAGE};
                        //show popup to request permission
                        requestPermissions(permission, PERMISSION_CODE);
                    } else {
                        //permission already granted
                        openCamera();
                    }
                } else {
                    //system os < marshmallow
                }
            }


        });

        btn_choose_photo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openGallery();
            }
        });
    }

    /**
     * Afficher le menu
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_camera, menu);
        return true;
    }

    /**
     * Quand on selectionne l'option du menu
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.menu_camera:
                //Ici il faudra enregistrer la photo dan la bdd interne SQL Light
                Intent intent_vers_Map = new Intent(this, com.example.antoinecopiecolle.Maps.class);

                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_UN, intent.getStringExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_UN));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_DEUX, intent.getStringExtra(com.example.antoinecopiecolle.Preparation.NOM_COMBATTANT_DEUX));

                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Preparation.NOMBRE_DE_ROUNDS, intent.getStringExtra(com.example.antoinecopiecolle.Preparation.NOMBRE_DE_ROUNDS));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Preparation.CATEGORIE_POIDS, intent.getStringExtra(com.example.antoinecopiecolle.Preparation.CATEGORIE_POIDS));

                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.VAINQUEUR, intent.getStringExtra(com.example.antoinecopiecolle.Combat.VAINQUEUR));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.TYPE_DE_VICTOIRE, intent.getStringExtra(com.example.antoinecopiecolle.Combat.TYPE_DE_VICTOIRE));

                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_RED_JAB, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_RED_JAB));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_RED_UPPERCUT, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_RED_UPPERCUT));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_RED_KICK, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_RED_KICK));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_RED_TACKLE, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_RED_TACKLE));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_RED_IMMO, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_RED_IMMO));

                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_JAB, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_JAB));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_UPPERCUT, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_UPPERCUT));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_KICK, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_KICK));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_TACKLE, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_TACKLE));
                intent_vers_Map.putExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_IMMO, intent.getStringExtra(com.example.antoinecopiecolle.Combat.NBR_BLUE_IMMO));

                intent_vers_Map.putExtra(PHOTO, img);

                startActivity(intent_vers_Map);
                Toast.makeText(this, "Photo sauvegardée - Localisation en cours", Toast.LENGTH_SHORT).show();
                return true;

            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private void openGallery() {
        Intent gallery = new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.INTERNAL_CONTENT_URI);
        startActivityForResult(gallery, PICK_IMAGE);
    }

    private void openCamera() {
        ContentValues values = new ContentValues();
        values.put(MediaStore.Images.Media.TITLE, "New Picture");
        values.put(MediaStore.Images.Media.DESCRIPTION, "From the camera");
        image_uri = getContentResolver().insert(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, values);
        //Camera intent
        Intent cameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        cameraIntent.putExtra(MediaStore.EXTRA_OUTPUT, image_uri);
        startActivityForResult(cameraIntent, IMAGE_CAPTURE_CODE);
    }

    //handling permission result
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        /**super.onRequestPermissionsResult(requestCode, permissions, grantResults);*/
        //Cette méthode est appelée quand l'utilisateur clique Autoriser ou Refuser depuis le popup de demande de permission
        switch (requestCode) {
            case PERMISSION_CODE: {
                if (grantResults.length > 0 && grantResults[0] ==
                        PackageManager.PERMISSION_GRANTED) {
                    //permission from popup was granted
                    openCamera();
                } else {
                    //permission from popup was denied
                    Toast.makeText(com.example.antoinecopiecolle.Camera.this, "Permission denied...", Toast.LENGTH_SHORT).show();
                }
            }
        }
    }


    //Set l'ImageView avec la photo prise par la camera
    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        img = new byte[0];

        //là, on choisi l'image qu'on veut set à partir de la gallerie
        if (resultCode == RESULT_OK && requestCode == PICK_IMAGE) {
            image_uri = data.getData();
            la_photo.setImageURI(image_uri);
            Bitmap b = ((BitmapDrawable) la_photo.getDrawable()).getBitmap();
            ByteArrayOutputStream bos = new ByteArrayOutputStream();
            b.compress(Bitmap.CompressFormat.JPEG, 25, bos);
            img = bos.toByteArray();
        }
    }
}












