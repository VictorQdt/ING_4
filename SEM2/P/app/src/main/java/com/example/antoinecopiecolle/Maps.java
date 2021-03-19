package com.example.antoinecopiecolle;

import android.Manifest;
import android.content.ContentValues;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.sqlite.SQLiteDatabase;
import android.location.Location;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

/**
 * Created by User on 10/2/2017.
 */

public class Maps extends AppCompatActivity implements OnMapReadyCallback {

    private SQLiteDatabase database;

    String currentLatitude;
    String currentLongitude;

    Intent intent;

    @Override
    public void onMapReady(GoogleMap googleMap) {
        Toast.makeText(this, "Map is Ready", Toast.LENGTH_SHORT).show();
        Log.d(TAG, "onMapReady: map is ready");
        mMap = googleMap;

        if (mLocationPermissionsGranted) {
            getDeviceLocation();

            if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION)
                    != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this,
                    Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
                return;
            }
            mMap.setMyLocationEnabled(true);
            mMap.getUiSettings().setMyLocationButtonEnabled(false);

        }
    }

    private static final String TAG = "Map";

    private static final String FINE_LOCATION = Manifest.permission.ACCESS_FINE_LOCATION;
    private static final String COURSE_LOCATION = Manifest.permission.ACCESS_COARSE_LOCATION;
    private static final int LOCATION_PERMISSION_REQUEST_CODE = 1234;
    private static final float DEFAULT_ZOOM = 15f;

    //vars
    private Boolean mLocationPermissionsGranted = false;
    private GoogleMap mMap;
    private FusedLocationProviderClient mFusedLocationProviderClient;

    /**
     * Afficher le menu
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_map, menu);
        return true;
    }

    /**
     * Quand on selectionne l'option du menu
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.menu_map:
                //Ici il faudra enregistrer la latitude et la longitude dans la bdd interne SQL Light
                Intent intent_retour = new Intent(this, MainActivity.class);
                addAllInSQLiteDb();
                startActivity(intent_retour);
                Toast.makeText(this, R.string.match_done, Toast.LENGTH_SHORT).show();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);

        MatchDBHelper dbHelper = new MatchDBHelper(this);
        database = dbHelper.getWritableDatabase();

        intent = getIntent();

        getLocationPermission();
    }

    private void getDeviceLocation() {
        Log.d(TAG, "getDeviceLocation: getting the devices current location");

        mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(this);

        try {
            if (mLocationPermissionsGranted) {

                final Task location = mFusedLocationProviderClient.getLastLocation();
                location.addOnCompleteListener(new OnCompleteListener() {
                    @Override
                    public void onComplete(@NonNull Task task) {
                        if (task.isSuccessful()) {
                            Log.d(TAG, "onComplete: found location!");
                            Location currentLocation = (Location) task.getResult();
                            currentLatitude = String.valueOf(currentLocation.getLatitude());
                            currentLongitude = String.valueOf(currentLocation.getLongitude());

                            moveCamera(new LatLng(currentLocation.getLatitude(), currentLocation.getLongitude()),
                                    DEFAULT_ZOOM);

                        } else {
                            Log.d(TAG, "onComplete: current location is null");
                            Toast.makeText(com.example.antoinecopiecolle.Maps.this, "unable to get current location", Toast.LENGTH_SHORT).show();
                        }
                    }
                });
            }
        } catch (SecurityException e) {
            Log.e(TAG, "getDeviceLocation: SecurityException: " + e.getMessage());
        }
    }

    private void moveCamera(LatLng latLng, float zoom) {
        Log.d(TAG, "moveCamera: moving the camera to: lat: " + latLng.latitude + ", lng: " + latLng.longitude);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(latLng, zoom));
    }

    private void initMap() {
        Log.d(TAG, "initMap: initializing map");
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.google_map);

        mapFragment.getMapAsync(com.example.antoinecopiecolle.Maps.this);
    }

    private void getLocationPermission() {
        Log.d(TAG, "getLocationPermission: getting location permissions");
        String[] permissions = {Manifest.permission.ACCESS_FINE_LOCATION,
                Manifest.permission.ACCESS_COARSE_LOCATION};

        if (ContextCompat.checkSelfPermission(this.getApplicationContext(),
                FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            if (ContextCompat.checkSelfPermission(this.getApplicationContext(),
                    COURSE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
                mLocationPermissionsGranted = true;
                initMap();
            } else {
                ActivityCompat.requestPermissions(this,
                        permissions,
                        LOCATION_PERMISSION_REQUEST_CODE);
            }
        } else {
            ActivityCompat.requestPermissions(this,
                    permissions,
                    LOCATION_PERMISSION_REQUEST_CODE);
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        Log.d(TAG, "onRequestPermissionsResult: called.");
        mLocationPermissionsGranted = false;

        switch (requestCode) {
            case LOCATION_PERMISSION_REQUEST_CODE: {
                if (grantResults.length > 0) {
                    for (int i = 0; i < grantResults.length; i++) {
                        if (grantResults[i] != PackageManager.PERMISSION_GRANTED) {
                            mLocationPermissionsGranted = false;
                            Log.d(TAG, "onRequestPermissionsResult: permission failed");
                            return;
                        }
                    }
                    Log.d(TAG, "onRequestPermissionsResult: permission granted");
                    mLocationPermissionsGranted = true;
                    //initialize our map
                    initMap();
                }
            }
        }
    }

    private void addAllInSQLiteDb() {
        ContentValues contentValues = new ContentValues();
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_FIGHTER_ONE, intent.getStringExtra(Preparation.NOM_COMBATTANT_UN));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_FIGHTER_TWO, intent.getStringExtra(Preparation.NOM_COMBATTANT_DEUX));

        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_ROUNDS, intent.getStringExtra(Preparation.NOMBRE_DE_ROUNDS));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_CATEGORIE_POIDS, intent.getStringExtra(Preparation.CATEGORIE_POIDS));

        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_VAINQUEUR, intent.getStringExtra(Combat.VAINQUEUR));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_TYPE_VICTOIRE, intent.getStringExtra(Combat.TYPE_DE_VICTOIRE));

        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_RED_JAB, intent.getStringExtra(Combat.NBR_RED_JAB));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_RED_UPPERCUT, intent.getStringExtra(Combat.NBR_RED_UPPERCUT));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_RED_KICK, intent.getStringExtra(Combat.NBR_RED_KICK));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_RED_TACKLE, intent.getStringExtra(Combat.NBR_RED_TACKLE));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_RED_IMMO, intent.getStringExtra(Combat.NBR_RED_IMMO));

        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_BLUE_JAB, intent.getStringExtra(Combat.NBR_BLUE_JAB));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_BLUE_UPPERCUT, intent.getStringExtra(Combat.NBR_BLUE_UPPERCUT));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_BLUE_KICK, intent.getStringExtra(Combat.NBR_BLUE_KICK));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_BLUE_TACKLE, intent.getStringExtra(Combat.NBR_BLUE_TACKLE));
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_BLUE_IMMO, intent.getStringExtra(Combat.NBR_BLUE_IMMO));

        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_LONGITUDE, currentLongitude);
        contentValues.put(MatchContract.MatchEntry.COLUMN_NAME_LATITUDE, currentLatitude);

        contentValues.put(MatchContract.MatchEntry.IMAGE, intent.getByteArrayExtra(Camera.PHOTO));


        database.insert(MatchContract.MatchEntry.TABLE_NAME, null, contentValues);
    }

}