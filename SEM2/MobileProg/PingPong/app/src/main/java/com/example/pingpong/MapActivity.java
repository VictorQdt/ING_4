package com.example.pingpong;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import android.Manifest;
import android.app.Activity;
import android.app.Dialog;
import android.content.pm.PackageManager;
import android.location.Location;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GoogleApiAvailability;
import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

public class MapActivity extends AppCompatActivity implements OnMapReadyCallback {

    private static final String TAG = "MapActivity";

    private static final String FINE_LOCATION = Manifest.permission.ACCESS_FINE_LOCATION;
    private static final String COARSE_LOCATION = Manifest.permission.ACCESS_COARSE_LOCATION;
    private static final int LOCATION_PERMISSION_REQUEST_CODE = 1234;
    private static final float DEFAULT_ZOOM = 15f;
    //vars
    private Boolean mLocPermissionsGranted = false;
    private GoogleMap mMap;
    private FusedLocationProviderClient mfusedLocationProviderClient;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_map);

        //check for location permissions
        getLocPermissions();
    }

    /**
     * Get the current location of the device and place the focus on it
     */

    private void getMyLoc() {
        Log.d(TAG, "getMyLoc : getting the device location");
        mfusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(this);
        try {
            if (mLocPermissionsGranted) {
                Task location = mfusedLocationProviderClient.getLastLocation();
                System.out.println(location);
                location.addOnCompleteListener(new OnCompleteListener() {
                    @Override
                    public void onComplete(@NonNull Task task) {
                        if (task.isSuccessful()) {
                            Log.d(TAG, "onComplete : found location");
                            Location currentLoc = (Location) task.getResult();
                            //moving the camera
                            moveCamera(new LatLng(currentLoc.getLatitude(), currentLoc.getLongitude()), DEFAULT_ZOOM);
                        } else {
                            Log.d(TAG, "onComplete : current loc is null");
                            Toast.makeText(MapActivity.this, "unable to get current loc", Toast.LENGTH_SHORT).show();
                        }
                    }
                });
            }
        } catch (SecurityException e) {
            Log.e(TAG, "getMyLoc: security exception" + e.getMessage());
        }
    }

    /**
     * Method for moving the camera on the current location
     *
     * @param latLng
     * @param zoom
     */
    private void moveCamera(LatLng latLng, float zoom) {
        Log.d(TAG, "moveCamera: moving camera to lat " + latLng.latitude + "long :" + latLng.longitude);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(latLng, zoom));
    }

    /**
     * Initialize the googleMap
     */
    private void initMap() {
        Log.d(TAG, "initMap: initializing map");
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.google_map);
        mapFragment.getMapAsync(MapActivity.this);
    }

    /**
     * Callback onMapReady
     *
     * @param googleMap
     */
    @Override
    public void onMapReady(GoogleMap googleMap) {
        Toast.makeText(this, "Map is ready", Toast.LENGTH_SHORT).show();
        Log.d(TAG, "onMapReady: map is ready");
        mMap = googleMap;

        // Location is granted : display the current Loc on the map
        if (mLocPermissionsGranted) {
            getMyLoc();
            /**
             if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION)
             != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this,
             Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
             return;
             }
             mMap.setMyLocationEnabled(true);**/
        }
    }

    /**
     * Explicitely check permissions
     */
    private void getLocPermissions() {
        Log.d(TAG, "getLocPerm : getting loc permissions");
        String[] permissions = {Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.ACCESS_COARSE_LOCATION};
        if (ContextCompat.checkSelfPermission(this.getApplicationContext(), FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            if (ContextCompat.checkSelfPermission(this.getApplicationContext(), COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
                mLocPermissionsGranted = true;
                initMap();
            } else {
                ActivityCompat.requestPermissions(this, permissions, LOCATION_PERMISSION_REQUEST_CODE);
            }
        } else {
            ActivityCompat.requestPermissions(this, permissions, LOCATION_PERMISSION_REQUEST_CODE);
        }
    }

    /**
     * Callback Permission Request
     *
     * @param requestCode
     * @param permissions
     * @param grantResults
     */
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        Log.d(TAG, "onRequestPermissionsresults: called");
        mLocPermissionsGranted = false;

        switch (requestCode) {
            case LOCATION_PERMISSION_REQUEST_CODE:
                if (grantResults.length > 0) {
                    for (int i = 0; i < grantResults.length; i++) {
                        if (grantResults[i] != PackageManager.PERMISSION_GRANTED) {
                            //permission failed
                            mLocPermissionsGranted = false;
                            return;
                        }
                    }
                    //permissions succeed
                    mLocPermissionsGranted = true;
                    //initialize the map
                    initMap();
                }
        }
    }
}