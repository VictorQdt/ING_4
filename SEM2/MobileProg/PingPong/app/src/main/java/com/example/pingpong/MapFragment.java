
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
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
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
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

import java.util.List;
import java.util.Locale;

public class MapFragment extends Fragment {

    //private GoogleMap mMap;
    //private LocationManager locationManager;
    //private String provider;

    private TextView tv_longitude, tv_latitude;
    private FusedLocationProviderClient locClient;
    private SupportMapFragment supportMapFragment;

    /**
     * private boolean geoLocPermit = false;
     * private boolean geoLocRequest = false;
     * private final int PERMISSION_REQUEST_LOC = 0;
     * private final int GPS_REQUEST_CODE = 1;
     **/

    Geocoder geocoder;
    List<Address> addresses;

    /**
    // Here 1 represent max location result to returned, by documents it recommended 1 to 5
    addresses = geocoder.getFromLocation(tv_longitude, tv_latitude, 1);
    String address = addresses.get(0).getAddressLine(0); // If any additional address line present than only, check with max available address lines by getMaxAddressLineIndex()
    String city = addresses.get(0).getLocality();
    String state = addresses.get(0).getAdminArea();
    String country = addresses.get(0).getCountryName();
    String postalCode = addresses.get(0).getPostalCode();
    String knownName = addresses.get(0).getFeatureName(); // Only if available else return NULL
     **/


    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        //Initialize view
        View map_view = inflater.inflate(R.layout.fragment_map, container, false);

        //Initialize fields
        Button btn_loc = (Button) map_view.findViewById(R.id.btn_getLoc);
        tv_longitude = (TextView) map_view.findViewById(R.id.tv_long);
        tv_latitude = (TextView) map_view.findViewById(R.id.tv_lat);
        geocoder = new Geocoder(getContext(), Locale.getDefault());



        //Initialize location Client
        locClient = LocationServices.getFusedLocationProviderClient(getActivity());

        //Initialize fragment map
        supportMapFragment = (SupportMapFragment) getChildFragmentManager().findFragmentById(R.id.google_map);

        // Button Location Listener
        btn_loc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Check condition
                if (ContextCompat.checkSelfPermission(getActivity()
                        , Manifest.permission.ACCESS_FINE_LOCATION)
                        == PackageManager.PERMISSION_GRANTED &&
                        ContextCompat.checkSelfPermission(getActivity()
                                , Manifest.permission.ACCESS_COARSE_LOCATION)
                                == PackageManager.PERMISSION_GRANTED) {
                    // When permission is granted : call method
                    getCurrentLocation();
                } else {
                    // When permission is not granted
                    // Request permission
                    requestPermissions(new String[]{Manifest.permission.ACCESS_FINE_LOCATION
                            , Manifest.permission.ACCESS_COARSE_LOCATION}, 100);
                }
            }
        });

        //Asynchchronous map
        supportMapFragment.getMapAsync(new OnMapReadyCallback() {
            @Override
            public void onMapReady(GoogleMap mMap) {
                //When map is charged
                mMap.setOnMapClickListener(latLng -> {
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
                });
            }
        });

        //Return view
        return map_view;
    }

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

    @SuppressLint("MissingPermission")
    private void getCurrentLocation() {
        // Initialize location manager
        LocationManager locationManager = (LocationManager) getActivity().getSystemService(Context.LOCATION_SERVICE);

        // Check conditions
        if (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)
                || locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER)) {
            // When Location service is enabled : get last location
            locClient.getLastLocation().addOnCompleteListener(new OnCompleteListener<Location>() {
                @Override
                public void onComplete(@NonNull Task<Location> task) {
                    // Initialize location
                    Location loc = task.getResult();
                    // Check conditions
                    if (loc != null) {
                        // Loc is not null then fix latitude and longitude
                        tv_longitude.setText(String.valueOf(loc.getLongitude()));
                        tv_latitude.setText(String.valueOf(loc.getLatitude()));
                    } else {
                        // If location result is null
                        // Initialize loc request
                        LocationRequest locationRequest = new LocationRequest()
                                .setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY)
                                .setInterval(10000)
                                .setFastestInterval(1000)
                                .setNumUpdates(1);

                        // Initialize location callback
                        LocationCallback locationCallback = new LocationCallback() {
                            @Override
                            public void onLocationResult(LocationResult locationResult) {
                                // Initialize location
                                Location loc1 = locationResult.getLastLocation();
                                //Set longitude & latitude
                                tv_longitude.setText(String.valueOf(loc.getLongitude()));
                                tv_latitude.setText(String.valueOf(loc.getLatitude()));
                            }
                        };
                        // Request location updates
                        locClient.requestLocationUpdates(locationRequest, locationCallback, Looper.myLooper());
                    }
                }
            });
        } else {
            // When location service is not enabled
            // Open location setting
            startActivity(new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS)
                    .setFlags(Intent.FLAG_ACTIVITY_NEW_TASK));
        }
    }
}