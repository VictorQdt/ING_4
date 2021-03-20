package com.example.pingpong;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.Switch;
import android.widget.TextView;

public class NewPoint extends Fragment {

    TextView actualPlayer;
    Button nextButton;
    Switch ace, winningReturn;
    RadioButton player1, player2, direct, fault;

    Integer actualPoint = Singleton.getInstance().getPointNumber();

    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {

            if(actualPoint != 4) Singleton.getInstance().setPointNumber(actualPoint+1);
            else Singleton.getInstance().setPointNumber(1);
            Singleton.getInstance().setTotalPoints(Singleton.getInstance().getTotalPoints() + 1);
            FragmentTransaction fragmentTransaction = getActivity()
                    .getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.fragment_container, new NewPoint());
            fragmentTransaction.commit();
        }
    };

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
        nextButton = (Button) v.findViewById(R.id.buttonNext);
        nextButton.setOnClickListener(onClickListener);
        actualPlayer = (TextView) v.findViewById(R.id.actualPlayer);

        // Inflate the layout for this fragment
        if(Singleton.getInstance().getTotalPoints() < 21){
            if(Singleton.getInstance().isFirstService()){
                if(actualPoint == 1 || actualPoint == 2) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
                else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
            }
            else {
                if(actualPoint == 1 || actualPoint == 2) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
                else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
            }
        }else {
            if(Singleton.getInstance().isFirstService()){
                if(actualPoint%2 == 0) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
                else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
            }
            else {
                if(actualPoint%2 != 0) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
                else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
            }
        }

        return v;
    }
}