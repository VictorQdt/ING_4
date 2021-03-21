package com.example.pingpong;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import android.graphics.Typeface;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.FragmentTransaction;

import java.util.Calendar;

/**
 * Fragment for creating a new Game
 */
public class NewMatchFragment extends Fragment {

    //properties
    private TextView newMatch, player1, player2, nbOfSets, firstServ;
    Button start;
    private EditText name1, name2;
    private RadioButton sets, service;

    /**
     * Listener for all properties when creating a game
     */
    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {

            Singleton.getInstance().setPlayer1(name1.getText().toString());
            Singleton.getInstance().setPlayer2(name2.getText().toString());
            Singleton.getInstance().setSets(sets.isChecked());
            Singleton.getInstance().setFirstService(service.isChecked());
            Singleton.getInstance().setPointNumber((short) 1);
            Singleton.getInstance().setStarted(true);
            //String p1 = Singleton.getInstance().getPlayer1();
            //String p2 = Singleton.getInstance().getPlayer2();
            Singleton.getInstance().setTimestamp(System.currentTimeMillis()/1000);

            FragmentTransaction fragmentTransaction = getActivity()
                    .getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.fragment_container, new NewPoint());
            fragmentTransaction.commit();
        }
    };

    /**
     * View of the fragment NewGame
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return
     */
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        View newMatchView = inflater.inflate(R.layout.fragment_new_match, container, false);
        Typeface type = Typeface.createFromAsset(getActivity().getAssets(),"fonts/2.ttf");
        newMatch = (TextView) newMatchView.findViewById(R.id.newMatch);
        newMatch.setTypeface(type);
        player1 = (TextView) newMatchView.findViewById(R.id.player1);
        player1.setTypeface(type);
        player2 = (TextView) newMatchView.findViewById(R.id.player2);
        player2.setTypeface(type);
        nbOfSets = (TextView) newMatchView.findViewById(R.id.nbOfSets);
        nbOfSets.setTypeface(type);
        firstServ = (TextView) newMatchView.findViewById(R.id.firstServ);
        firstServ.setTypeface(type);
        start = (Button) newMatchView.findViewById(R.id.submit);
        start.setTypeface(type);
        sets = (RadioButton) newMatchView.findViewById(R.id.sets4);
        service = (RadioButton) newMatchView.findViewById(R.id.player1Serv);
        name1 = (EditText) newMatchView.findViewById(R.id.editTextTextPersonName1);
        name2 = (EditText) newMatchView.findViewById(R.id.editTextTextPersonName2);
        start.setOnClickListener(onClickListener);
        return newMatchView;
    }
}