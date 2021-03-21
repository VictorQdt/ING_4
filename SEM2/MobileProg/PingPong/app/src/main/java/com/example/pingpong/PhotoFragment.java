package com.example.pingpong;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.content.FileProvider;
import androidx.fragment.app.Fragment;

import java.io.File;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Fragment for taking pictures
 */
public class PhotoFragment extends Fragment {

    //identifies the return result when the result arrives
    private static final int RETOUR_PRENDRE_PHOTO = 1;

    //properties
    private Button btnTakePhoto;
    private ImageView imgDisplayPhoto;
    private Button btnSave;
    private String photoPath = null;
    private Bitmap img;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //initActivity();
        View picture_view = inflater.inflate(R.layout.fragment_photo, container, false);

        //récupération des objets graphiques
        btnTakePhoto = (Button) picture_view.findViewById(R.id.btnTakePicture);
        imgDisplayPhoto = (ImageView) picture_view.findViewById(R.id.imgDisplayPhoto);
        btnSave = (Button) picture_view.findViewById(R.id.btnSave);

        //méthodes pour gérer les events
        createOnClickBtnTakePhoto();
        createOnClickBtnSave();

        return picture_view;
    }

    /**
     * event clic button btnTakePhoto
     * */
    private void createOnClickBtnTakePhoto(){
        btnTakePhoto.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                takePhoto();
            }
        });
    }

    /**
     * Accès à l'appareil photo et mémorise dans un fichier temporaire (avec le provider)
     */
    private void takePhoto(){
        //creer/preparer un intent pour ouvrir une fenetre pour prendre une photo (par la classe MediaStore)
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

        //test pour controler que l'intent peut etre géré par le telephone (il peut prendre des photos)
        if(intent.resolveActivity(getActivity().getPackageManager()) != null) {

            //creer un nom de fichier unique : récupère sous forme de string la date actuelle
            String time = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());

            //chemin du directory où sont stockés les photos (chemin externe dans la gallery)
            File photoDir = getActivity().getExternalFilesDir(Environment.DIRECTORY_PICTURES);
            try {

                //creer un fichier temporaire avec nom + lieu stockage
                File photoFile = File.createTempFile("photo"+time, ".jpg", photoDir);

                //Enrengistrer le chemin complet
                photoPath = photoFile.getAbsolutePath();

                // créer l'URI pour accéder au fichier (Context, provider, fichier)
                Uri photoUri = FileProvider.getUriForFile(
                        getActivity(),
                        PhotoFragment.this.getActivity().getApplicationContext().getPackageName() + ".provider",
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
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        // vérifier le bon code de retour (requestCode) et l'état du retour (resultCode)
        if(requestCode == RETOUR_PRENDRE_PHOTO && resultCode == Activity.RESULT_OK){
            //récupérer l'image
            img = BitmapFactory.decodeFile(photoPath);
            //afficher l'image
            imgDisplayPhoto.setImageBitmap(img);
        }
    }

    /**
     * event click sur Save
     */
    private void createOnClickBtnSave() {
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // enrengistrer la photo
                MediaStore.Images.Media.insertImage(getActivity().getContentResolver(), img, "mon img", "img");
            }
        });
    }
}
