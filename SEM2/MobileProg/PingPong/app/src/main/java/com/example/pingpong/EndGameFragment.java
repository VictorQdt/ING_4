package com.example.pingpong;

import android.location.Geocoder;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import java.util.Locale;

/**
 * A simple {@link Fragment} subclass.
 */
public class EndGameFragment extends Fragment {

    private TextView nameWinner;
    private Button goBackMenu;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        //Initialize view
        View view_endOfGame = inflater.inflate(R.layout.fragment_end_game, container, false);

        //Initialize fields
        nameWinner = (TextView) view_endOfGame.findViewById(R.id.nameWinner);
        goBackMenu = (Button) view_endOfGame.findViewById(R.id.buttonGoBackMenu);

        // Inflate the layout for this fragment
        return view_endOfGame;
    }
}