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

            if(player1.isChecked()){
                Singleton.getInstance().setPlayer1ActualSet(Singleton.getInstance().getPlayer1ActualSet() + 1);
                Singleton.getInstance().setPlayer1Points(Singleton.getInstance().getPlayer1Points()+1);
                if (ace.isChecked()){
                    Singleton.getInstance().setPlayer1Aces(Singleton.getInstance().getPlayer1Aces()+ 1);
                }
                if (winningReturn.isChecked()){
                    Singleton.getInstance().setPlayer1WinningReturns(Singleton.getInstance().getPlayer1WinningReturns()+ 1);
                }
                if (direct.isChecked()){
                    Singleton.getInstance().setPlayer1WinningShots(Singleton.getInstance().getPlayer1WinningShots()+ 1);
                }
                if (fault.isChecked()){
                    Singleton.getInstance().setPlayer2DirectFaults(Singleton.getInstance().getPlayer2DirectFaults()+ 1);
                }
            }

            if(player2.isChecked()){
                Singleton.getInstance().setPlayer2ActualSet(Singleton.getInstance().getPlayer2ActualSet() + 1);
                Singleton.getInstance().setPlayer2Points(Singleton.getInstance().getPlayer2Points()+1);
                if (ace.isChecked()){
                    Singleton.getInstance().setPlayer2Aces(Singleton.getInstance().getPlayer2Aces()+ 1);
                }
                if (winningReturn.isChecked()){
                    Singleton.getInstance().setPlayer2WinningReturns(Singleton.getInstance().getPlayer2WinningReturns()+ 1);
                }
                if (direct.isChecked()){
                    Singleton.getInstance().setPlayer2WinningShots(Singleton.getInstance().getPlayer2WinningShots()+ 1);
                }
                if (fault.isChecked()){
                    Singleton.getInstance().setPlayer1DirectFaults(Singleton.getInstance().getPlayer1DirectFaults()+ 1);
                }
            }

            if(Singleton.getInstance().getPlayer1ActualSet() == 11 && Singleton.getInstance().getPlayer2ActualSet() <= 9) {

                Singleton.getInstance().setPlayer1WonSets(Singleton.getInstance().getPlayer1WonSets() + 1);
                Singleton.getInstance().setPlayer2ActualSet(0);
                Singleton.getInstance().setPlayer1ActualSet(0);
                Singleton.getInstance().setPointNumber(1);


            } else if (Singleton.getInstance().getPlayer2ActualSet() == 11 && Singleton.getInstance().getPlayer1ActualSet() <= 9){

                Singleton.getInstance().setPlayer2WonSets(Singleton.getInstance().getPlayer2WonSets() + 1);
                Singleton.getInstance().setPlayer2ActualSet(0);
                Singleton.getInstance().setPlayer1ActualSet(0);
                Singleton.getInstance().setPointNumber(1);

            }

            if(Singleton.getInstance().getPlayer1ActualSet() >= 10 && Singleton.getInstance().getPlayer2ActualSet() >= 10){
                if (Singleton.getInstance().getPlayer1ActualSet() == Singleton.getInstance().getPlayer2ActualSet() + 2){
                    Singleton.getInstance().setPlayer1WonSets(Singleton.getInstance().getPlayer1WonSets() + 1);
                    Singleton.getInstance().setPlayer2ActualSet(0);
                    Singleton.getInstance().setPlayer1ActualSet(0);
                    Singleton.getInstance().setPointNumber(1);
                }
                if (Singleton.getInstance().getPlayer2ActualSet() == Singleton.getInstance().getPlayer1ActualSet() + 2){
                    Singleton.getInstance().setPlayer2WonSets(Singleton.getInstance().getPlayer2WonSets() + 1);
                    Singleton.getInstance().setPlayer2ActualSet(0);
                    Singleton.getInstance().setPlayer1ActualSet(0);
                    Singleton.getInstance().setPointNumber(1);
                }
            }

            if(Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer1WonSets() == 4){
                //Code de victoire joueur 1
            }else if (!Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer1WonSets() == 3){
                //Code de victoire joueur 1
            }else if (Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer2WonSets() == 4){
                //Code de victoire joueur 2
            }else if (!Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer2WonSets() == 3){
                //Code de victoire joueur 2
            }

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
        ace = (Switch) v.findViewById(R.id.switchAce);
        winningReturn = (Switch) v.findViewById(R.id.switchWinningReturn);
        player1 = (RadioButton) v.findViewById(R.id.radioPlayer1);
        player2 = (RadioButton) v.findViewById(R.id.radioPlayer2);
        direct = (RadioButton) v.findViewById(R.id.radioDirect);
        fault = (RadioButton) v.findViewById(R.id.radioFault);
        player1.setText(Singleton.getInstance().getPlayer1());
        player2.setText(Singleton.getInstance().getPlayer2());
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