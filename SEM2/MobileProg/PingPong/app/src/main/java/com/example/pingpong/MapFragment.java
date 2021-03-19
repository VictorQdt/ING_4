
package com.example.pingpong;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.provider.Settings;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;
import androidx.fragment.app.Fragment;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.material.snackbar.Snackbar;

import java.util.Objects;

public class MapFragment extends Fragment implements OnMapReadyCallback, LocationListener {

    private GoogleMap mMap;
    private LocationManager locationManager;
    private String provider;

    private TextView longitude, latitude;

    private boolean geoLocPermit = false;
    private boolean geoLocRequest = false;
    private final int PERMISSION_REQUEST_LOC = 0;
    private final int GPS_REQUEST_CODE = 1;


    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        //Initialize view
        View map_view = inflater.inflate(R.layout.fragment_map, container, false);

        //Initialize fields
        //txt_coord = (TextView) getActivity().findViewById(R.id.txt_coord);
        longitude = (TextView) getActivity().findViewById(R.id.tv_long);
        longitude = (TextView) getActivity().findViewById(R.id.tv_lat);

        // locate your position
        // Get the location manager
        locationManager = (LocationManager) getActivity().getSystemService(Context.LOCATION_SERVICE);
        provider = LocationManager.GPS_PROVIDER;

        //Initialize fragment map
        SupportMapFragment supportMapFragment = (SupportMapFragment) getChildFragmentManager().findFragmentById(R.id.google_map);
        supportMapFragment.getMapAsync(this);

        /**
        //Asynchchronous map
        supportMapFragment.getMapAsync(new OnMapReadyCallback() {
            @Override
            public void onMapReady(GoogleMap mMap) {
                //When map is charged
                mMap.setOnMapClickListener(new GoogleMap.OnMapClickListener() {
                    @Override
                    public void onMapClick(LatLng latLng) {
                        // When clicking on map
                        // Initialize options marker
                        MarkerOptions markerOptions = new MarkerOptions();
                        // Position marker
                        markerOptions.position(latLng);
                        // Titre du marker
                        markerOptions.title(latLng.latitude + " : " + latLng.longitude);
                        // Clear marker
                        mMap.clear();
                        // Zoom
                        mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng, 10));
                        // Add marker
                        mMap.addMarker(markerOptions);
                    }
                });
            }
        });**/

        //Return view
        return map_view;
    }

    /**
     * Manipulates the map once available.
     * This callback is triggered when the map is ready to be used.
     * This is where we can add markers or lines, add listeners or move the camera. In this case,
     * we just add a marker near Sydney, Australia.
     * If Google Play services is not installed on the device, the user will be prompted to install
     * it inside the SupportMapFragment. This method will only be triggered once the user has
     * installed Google Play services and returned to the app.
     */
    @SuppressLint("DefaultLocale")
    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;

        // Add a marker in the last known location and move the camera
        if (locationManager != null) {
            @SuppressLint("MissingPermission") Location l = locationManager.getLastKnownLocation(provider);

            if (l != null) {
                LatLng coord = new LatLng(l.getLatitude(), l.getLongitude());
                mMap.addMarker(new MarkerOptions().position(coord).title("Last position"));
                mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(coord, 15));

                longitude.setText(String.format("Longitude %s", l.getLongitude()));
                latitude.setText(String.format("Latitude %s", l.getLatitude()));
            }
        }
    }

    @Override
    public void onLocationChanged(Location location) {

        Toast.makeText(getContext(), "Location update", Toast.LENGTH_LONG);
        int lat = (int) location.getLatitude();
        int lng = (int) location.getLongitude();
        LatLng coord = new LatLng(lat, lng);

        // show the location coordinates in the textview
        //txt_coord.setText(String.format("Latitude = %d\nLongitude =%d", lat, lng));
        longitude.setText(lat);
        latitude.setText(lng);

        // add a marker on the map && zoom in
        mMap.addMarker(new MarkerOptions().position(new LatLng(lat, lng)));
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(coord, 15));
    }

    @Override
    public void onStatusChanged(String provider, int status, Bundle extras) {
        // TODO Auto-generated method stub

    }

    @Override
    public void onProviderEnabled(String provider) {
        Toast.makeText(getContext(), "Enabled new provider " + provider,
                Toast.LENGTH_SHORT).show();

    }

    @Override
    public void onProviderDisabled(String provider) {
        Toast.makeText(getContext(), "Disabled provider " + provider,
                Toast.LENGTH_SHORT).show();

        // enable it again !
        //Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
        //startActivityForResult(intent, GPS_REQUEST_CODE);
    }

    @Override
    public void onResume() {
        super.onResume();

        if (geoLocPermit || ActivityCompat.checkSelfPermission(Objects.requireNonNull(getContext()),
                Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED &&
                ActivityCompat.checkSelfPermission(getContext(),
                        Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED) {


            // if GPS is not enabled, ask the use to enable it
            if (!locationManager.isProviderEnabled(provider)) {
                Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                startActivityForResult(intent, GPS_REQUEST_CODE);
            } else
                requestLocationUpdates();

            return;
        }

        if (!geoLocRequest) {// if it ever resumes and we've already requested the permits, we won't ask twice
            geoLocRequest = true;
            // ask for permissions; this is asynchronous
            ActivityCompat.requestPermissions(Objects.requireNonNull(getActivity()), new String[]{Manifest.permission.ACCESS_FINE_LOCATION,
                    Manifest.permission.ACCESS_COARSE_LOCATION}, PERMISSION_REQUEST_LOC);
        }
    }


    @SuppressLint("MissingPermission")
    private void requestLocationUpdates() {
        Toast.makeText(getContext(), "Request location updates", Toast.LENGTH_LONG).show();
        locationManager.requestLocationUpdates(provider, 400, 1, this);
    }


    @SuppressLint("MissingPermission")
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == GPS_REQUEST_CODE && resultCode == 0) {
            //String provider = Settings.Secure.getString(getContentResolver(), Settings.Secure.LOCATION_PROVIDERS_ALLOWED);
            if (provider != null) {
                Log.v("GPS", " Location providers: " + provider);
                //Start searching for location and update the location text when update available.
                requestLocationUpdates();
            } else {
                Objects.requireNonNull(getActivity()).finish();
            }
        }
    }



    /* Remove the locationlistener updates when Activity is paused */

    @Override
    public void onPause() {
        super.onPause();

        if (geoLocPermit)
            locationManager.removeUpdates(this);
        return;
    }


    @SuppressLint("MissingPermission")
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions,
                                           @NonNull int[] grantResults) {

        if (requestCode == PERMISSION_REQUEST_LOC) {
            // Request for geolocation permit
            if (grantResults.length == 2 && grantResults[0] == PackageManager.PERMISSION_GRANTED
                    && grantResults[1] == PackageManager.PERMISSION_GRANTED) {
                // Permission has been granted. Request location updates
                Snackbar.make(getActivity().getWindow().getDecorView(), R.string.locate_string,
                        Snackbar.LENGTH_SHORT)
                        .show();

                geoLocPermit = true;
                requestLocationUpdates();

            } else
                // Permission request was denied. quit the activity
                Objects.requireNonNull(getActivity()).finish();

        }
        // END_INCLUDE(onRequestPermissionsResult)
    }

}
