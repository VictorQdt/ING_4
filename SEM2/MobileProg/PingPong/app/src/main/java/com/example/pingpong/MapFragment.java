package com.example.pingpong;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

public class MapFragment extends Fragment {

    //private GoogleMap mMap;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        //Initialiser la vue
        View map_view = inflater.inflate(R.layout.fragment_map, container, false);

        //Initialiser le fragment map
        SupportMapFragment supportMapFragment = (SupportMapFragment) getChildFragmentManager().findFragmentById(R.id.google_map);

        //Asynch map
        supportMapFragment.getMapAsync(new OnMapReadyCallback() {
            @Override
            public void onMapReady(GoogleMap googleMap) {
                //Quand la map est chargée
                googleMap.setOnMapClickListener(new GoogleMap.OnMapClickListener() {
                    @Override
                    public void onMapClick(LatLng latLng) {
                        // Quand on clique sur la map
                        // Initialiser options marker
                        MarkerOptions markerOptions = new MarkerOptions();
                        // Positionner le marker
                        markerOptions.position(latLng);
                        // Titre du marker
                        markerOptions.title(latLng.latitude + " : " + latLng.longitude);
                        // Enlever le marker
                        googleMap.clear();
                        // Zoom
                        googleMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng, 10));
                        // Ajouter le marker sur la map
                        googleMap.addMarker(markerOptions);
                    }
                });
            }
        });

        //Retourner la vue
        return map_view;
    }
}
