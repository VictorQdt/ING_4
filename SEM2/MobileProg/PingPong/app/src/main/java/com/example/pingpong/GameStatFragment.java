package com.example.pingpong;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

/**
 * A simple {@link Fragment} subclass.
 */
public class GameStatFragment extends Fragment {

    private TextView idGame;

    public GameStatFragment(){

    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        //Initialize view
        View view_stats = inflater.inflate(R.layout.fragment_game_stat, container, false);

        //Initialize fields
        idGame = (TextView) view_stats.findViewById(R.id.nameWinner);

        // Inflate the layout for this fragment
        return view_stats;
    }
}