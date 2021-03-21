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
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

import java.util.List;
import java.util.Locale;

/**
 * Display map inside a fragment
 */
public class MapFragment extends Fragment {

    //Properties
    private TextView tv_longitude, tv_latitude;
    private FusedLocationProviderClient locClient;
    private SupportMapFragment supportMapFragment;

    GoogleMap mMap;
    Geocoder geocoder;

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
                if (ContextCompat.checkSelfPermission(getActivity(), Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED
                        && ContextCompat.checkSelfPermission(getActivity(), Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
                    // When permission is granted : call method
                    getCurrentLocation();
                } else {
                    // When permission is not granted : request permission
                    requestPermissions(new String[]{Manifest.permission.ACCESS_FINE_LOCATION
                            , Manifest.permission.ACCESS_COARSE_LOCATION}, 100);
                }
            }
        });
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
     * Get the current locationof the android device
     */
    @SuppressLint("MissingPermission")
    private void getCurrentLocation() {
        // Initialize location manager : provide the access to the system location service
        LocationManager locationManager = (LocationManager) getActivity().getSystemService(Context.LOCATION_SERVICE);

        // Check conditions GPS & Network
        if (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)
                || locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER)) {
            // When Location service is enabled : get last location
            locClient.getLastLocation().addOnCompleteListener(new OnCompleteListener<Location>() {
                @Override
                public void onComplete(@NonNull Task<Location> task) {
                    // Initialize location
                    Location currentLoc = task.getResult();
                    // Check conditions
                    if (currentLoc != null) {
                        // Loc is not null then fix latitude and longitude
                        tv_longitude.setText(String.valueOf(currentLoc.getLongitude()));
                        tv_latitude.setText(String.valueOf(currentLoc.getLatitude()));

                        /**
                        LatLng coord = new LatLng(currentLoc.getLatitude(), currentLoc.getLongitude());
                        mMap.addMarker(new MarkerOptions().position(coord).title("Last position"));
                        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(coord, 15));**/

                    } else {
                        Toast.makeText(getContext(), "unable to get current location", Toast.LENGTH_SHORT).show();
                    }
                }
            });
        } else {
            // When location service is not enabled : open location setting
            startActivity(new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS)
                    .setFlags(Intent.FLAG_ACTIVITY_NEW_TASK));
        }
    }

}