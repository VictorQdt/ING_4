package com.example.pingpong;

import android.graphics.Typeface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import com.google.android.material.textfield.TextInputEditText;

public class HomeFragment extends Fragment {

    private TextView newMatch, player1, player2, nbOfSets, firstServ;
    Button start;
    private EditText name1, name2;
    private RadioButton sets, service;
    private String namePlayer1, namePlayer2;
    private boolean firstService, nbSets;


    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Singleton.getInstance().setPlayer1(name1.getText().toString());
            Singleton.getInstance().setPlayer2(name2.getText().toString());
            Singleton.getInstance().setSets(sets.isChecked());
            Singleton.getInstance().setFirstService(service.isChecked());
            FragmentTransaction fragmentTransaction = getActivity()
                    .getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.fragment_container, new PhotoFragment());
            fragmentTransaction.commit();
        }
    };

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        View newMatchView = inflater.inflate(R.layout.fragment_home, container, false);
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
        name1 = (EditText) newMatchView.findViewById(R.id.editTextTextPersonName);
        name2 = (EditText) newMatchView.findViewById(R.id.editTextTextPersonName2);
        start.setOnClickListener(onClickListener);
        return newMatchView;
    }
}
