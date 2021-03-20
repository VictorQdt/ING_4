package com.example.pingpong;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

public class NewPoint extends Fragment {

    TextView actualPlayer;
    Button nextButton;
    Integer actualPoint = Singleton.getInstance().getPointNumber();

    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {

            if(actualPoint != 3) Singleton.getInstance().setPointNumber(actualPoint+1);
            else Singleton.getInstance().setPointNumber(0);
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
        if(Singleton.getInstance().isFirstService()){
            if(actualPoint == 0 || actualPoint == 1) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
            else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
        }
        else {
            if(actualPoint == 0 || actualPoint == 1) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
            else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
        }

        return v;
    }
}