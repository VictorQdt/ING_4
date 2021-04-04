package com.example.pingpong;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.Looper;
import android.provider.Settings;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.EditorInfo;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationCallback;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationResult;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

/**
 * Display map inside a fragment
 */
public class MapFragment extends Fragment {

    private static final String TAG = "MapActivity";
    private static final float DEFAULT_ZOOM = 15f;

    //Properties
    private TextView tv_longitude, tv_latitude;
    private FusedLocationProviderClient locClient;
    private SupportMapFragment supportMapFragment;
    private FusedLocationProviderClient mFusedLocationProviderClient;

    private GoogleMap mMap;
    private Geocoder geocoder;

    //widgets
    private EditText mSearchText;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        //Initialize view
        View map_view = inflater.inflate(R.layout.fragment_map, container, false);

        //Initialize fields
        geocoder = new Geocoder(getContext(), Locale.getDefault());
        mSearchText = (EditText) getActivity().findViewById(R.id.input_search);

        //Initialize location Client
        locClient = LocationServices.getFusedLocationProviderClient(getActivity());

        //Initialize fragment map
        supportMapFragment = (SupportMapFragment) getChildFragmentManager().findFragmentById(R.id.google_map);

        //Return view
        return map_view;
    }

    /**
     * Callback for the result from requesting permissions.
     * This method is invoked for every call on requestPermissions(String[], int).
     * @param requestCode
     * @param permissions
     * @param grantResults
     */
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        // Check conditions
        if (requestCode == 100 && (grantResults.length > 0) &&
                (grantResults[0] + grantResults[1] == PackageManager.PERMISSION_GRANTED)) {
            // Request for geolocation permit
            getCurrentLocation();
        } else {
            // Permission request was denied. quit the activity
            Toast.makeText(getActivity(), "Permission denied", Toast.LENGTH_SHORT).show();
        }
        // END_INCLUDE(onRequestPermissionsResult)
    }

    /**
     * Get the current location of the android device
     */
    @SuppressLint("MissingPermission")
    private void getCurrentLocation() {
        // Initialize location manager : provide the access to the system location service
        LocationManager locationManager = (LocationManager) getActivity().getSystemService(Context.LOCATION_SERVICE);
        mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(getActivity());

        // Check conditions GPS & Network
        if (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)
                || locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER)) {
            // When Location service is enabled : get last location
            final Task location = mFusedLocationProviderClient.getLastLocation();
            location.addOnCompleteListener(new OnCompleteListener<Location>() {
                @Override
                public void onComplete(@NonNull Task<Location> task) {
                    if (task.isSuccessful()) {
                        Log.d(TAG, "onComplete : found location");
                        Location currentLoc = (Location) task.getResult();
                        //moving the camera
                        moveCamera(new LatLng(currentLoc.getLatitude(), currentLoc.getLongitude()), DEFAULT_ZOOM, "My Location");
                    } else {
                        Log.d(TAG, "onComplete : current loc is null");
                        Toast.makeText(getActivity(), "unable to get current loc", Toast.LENGTH_SHORT).show();
                    }
                }
            });
        } else {
            // When location service is not enabled : open location setting
            startActivity(new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS)
                    .setFlags(Intent.FLAG_ACTIVITY_NEW_TASK));
        }
    }

    /**
     * Method for moving the camera on the current location
     *
     * @param latLng
     * @param zoom
     */
    private void moveCamera(LatLng latLng, float zoom, String title) {
        Log.d(TAG, "moveCamera: moving camera to lat " + latLng.latitude + "long :" + latLng.longitude);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(latLng, zoom));

        if(!title.equals("My Location")){
            MarkerOptions options = new MarkerOptions().position(latLng).title(title);
            mMap.addMarker(options);
        }
        hideKeyboard();
    }

    /**
     * Listener for the Search Bar
     */
    private void init(){
        Log.d(TAG,"init: initializing");
        mSearchText.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView textView, int i, KeyEvent keyEvent) {
                if(i == EditorInfo.IME_ACTION_SEARCH
                        || i == EditorInfo.IME_ACTION_DONE
                        || keyEvent.getAction() == KeyEvent.ACTION_DOWN
                        || keyEvent.getAction() == KeyEvent.KEYCODE_ENTER){
                    //execute our method for searching
                    geoLocate();
                }
                return false;
            }
        });
        hideKeyboard();
    }

    /**
     * Geolocate the search string
     */
    private void geoLocate(){
        Log.d(TAG,"geoLocate: geoLocating");

        String searchString = mSearchText.getText().toString();

        Geocoder geocoder = new Geocoder(getActivity());
        List<Address> list = new ArrayList<>();
        try{
            list = geocoder.getFromLocationName(searchString, 1);
        } catch (IOException e) {
            Log.d(TAG,"geoLocate: IOException " + e.getMessage());
        }
        if(list.size() > 0) {
            Address address = list.get(0);
            Log.d(TAG,"geoLocate: found a location " + address.toString());

            moveCamera(new LatLng(address.getLatitude(), address.getLongitude()), DEFAULT_ZOOM, address.getAddressLine(0));
        }
    }

    /**
     * Hide the Keyboard
     */
    private void hideKeyboard(){
        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
    }
}
