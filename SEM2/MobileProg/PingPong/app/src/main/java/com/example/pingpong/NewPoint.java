package com.example.pingpong;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

public class NewPoint extends Fragment {

    TextView actualPlayer;

    public NewPoint() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_new_point, container, false);
        // Inflate the layout for this fragment
        if(Singleton.getInstance().getPointNumber() == 0 || Singleton.getInstance().getPointNumber() == 1){
            actualPlayer = (TextView) v.findViewById(R.id.actualPlayer);
            actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
        }
        return v;
    }
}