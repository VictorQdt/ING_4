package com.example.pingpong;

import android.content.Intent;
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
 * Fragment only displayed when the game is over
 */
public class EndGameFragment extends Fragment {

    //properties
    private TextView nameWinner;
    private Button goBackMenu;

    /**
     * Listener of the button GobackMenu (all data is reset for starting a new game)
     */
    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Singleton.getInstance().reset();
            Intent intent = new Intent();
            intent.setClass(getActivity(), MainActivity.class);
            getActivity().startActivity(intent);
        }
    };

    /**
     * View of the fragment (set the winner's name though the Singleton)
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return
     */
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        //Initialize view
        View view_endOfGame = inflater.inflate(R.layout.fragment_end_game, container, false);

        //Initialize fields
        nameWinner = (TextView) view_endOfGame.findViewById(R.id.nameWinner);
        nameWinner.setText(Singleton.getInstance().getWinnersName());
        goBackMenu = (Button) view_endOfGame.findViewById(R.id.buttonGoBackMenu);
        goBackMenu.setOnClickListener(onClickListener);

        // Inflate the layout for this fragment
        return view_endOfGame;
    }
}