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

/**
 * Fragment NewPoint for register every point of the match
 */
public class NewPoint extends Fragment {

    //properties
    TextView actualPlayer;
    Button nextButton;
    Switch ace, winningReturn;
    RadioButton player1, player2, direct, fault;

    short actualPoint = Singleton.getInstance().getPointNumber();
    /**
     * The onclick listener of the button that adds the points to the Singleton.
     * It checks every time if a set has been won or if it was the last point of the game.
     * If so, it calls the victory function.
     * It also handles the view of who is serving.
     */
    View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {

            if(actualPoint != 4) Singleton.getInstance().setPointNumber((short) (actualPoint+1));
            else Singleton.getInstance().setPointNumber((short) 1);
            Singleton.getInstance().setTotalPoints((short) (Singleton.getInstance().getTotalPoints() + 1));

            if(player1.isChecked()){
                Singleton.getInstance().setPlayer1ActualSet(Singleton.getInstance().getPlayer1ActualSet() + 1);
                Singleton.getInstance().setPlayer1Points((short) (Singleton.getInstance().getPlayer1Points()+1));
                if (ace.isChecked()){
                    Singleton.getInstance().setPlayer1Aces((short) (Singleton.getInstance().getPlayer1Aces()+ 1));
                }
                if (winningReturn.isChecked()){
                    Singleton.getInstance().setPlayer1WinningReturns((short) (Singleton.getInstance().getPlayer1WinningReturns()+ 1));
                }
                if (direct.isChecked()){
                    Singleton.getInstance().setPlayer1WinningShots((short) (Singleton.getInstance().getPlayer1WinningShots()+ 1));
                }
                if (fault.isChecked()){
                    Singleton.getInstance().setPlayer2DirectFaults((short) (Singleton.getInstance().getPlayer2DirectFaults()+ 1));
                }
            }

            if(player2.isChecked()){
                Singleton.getInstance().setPlayer2ActualSet(Singleton.getInstance().getPlayer2ActualSet() + 1);
                Singleton.getInstance().setPlayer2Points((short) (Singleton.getInstance().getPlayer2Points()+1));
                if (ace.isChecked()){
                    Singleton.getInstance().setPlayer2Aces((short) (Singleton.getInstance().getPlayer2Aces()+ 1));
                }
                if (winningReturn.isChecked()){
                    Singleton.getInstance().setPlayer2WinningReturns((short) (Singleton.getInstance().getPlayer2WinningReturns()+ 1));
                }
                if (direct.isChecked()){
                    Singleton.getInstance().setPlayer2WinningShots((short) (Singleton.getInstance().getPlayer2WinningShots()+ 1));
                }
                if (fault.isChecked()){
                    Singleton.getInstance().setPlayer1DirectFaults((short) (Singleton.getInstance().getPlayer1DirectFaults()+ 1));
                }
            }

            if(Singleton.getInstance().getPlayer1ActualSet() == 11 && Singleton.getInstance().getPlayer2ActualSet() <= 9) {
                Singleton.getInstance().setPlayer1WonSets((short) (Singleton.getInstance().getPlayer1WonSets() + 1));
                Singleton.getInstance().setPlayer2ActualSet(0);
                Singleton.getInstance().setPlayer1ActualSet(0);
                Singleton.getInstance().setPointNumber((short) 1);
                System.out.println("won sets player 1 " + Singleton.getInstance().getPlayer1WonSets());


            } else if (Singleton.getInstance().getPlayer2ActualSet() == 11 && Singleton.getInstance().getPlayer1ActualSet() <= 9){

                Singleton.getInstance().setPlayer2WonSets((short) (Singleton.getInstance().getPlayer2WonSets() + 1));
                Singleton.getInstance().setPlayer2ActualSet(0);
                Singleton.getInstance().setPlayer1ActualSet(0);
                Singleton.getInstance().setPointNumber((short) 1);

            }

            if(Singleton.getInstance().getPlayer1ActualSet() >= 10 && Singleton.getInstance().getPlayer2ActualSet() >= 10){
                if (Singleton.getInstance().getPlayer1ActualSet() == Singleton.getInstance().getPlayer2ActualSet() + 2){
                    Singleton.getInstance().setPlayer1WonSets((short) (Singleton.getInstance().getPlayer1WonSets() + 1));
                    Singleton.getInstance().setPlayer2ActualSet(0);
                    Singleton.getInstance().setPlayer1ActualSet(0);
                    Singleton.getInstance().setPointNumber((short) 1);
                }
                if (Singleton.getInstance().getPlayer2ActualSet() == Singleton.getInstance().getPlayer1ActualSet() + 2){
                    Singleton.getInstance().setPlayer2WonSets((short) (Singleton.getInstance().getPlayer2WonSets() + 1));
                    Singleton.getInstance().setPlayer2ActualSet(0);
                    Singleton.getInstance().setPlayer1ActualSet(0);
                    Singleton.getInstance().setPointNumber((short) 1);
                }
            }

            /**
             * If it is the end of the game, sets the winners name and calls victory
             */
            if(Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer1WonSets() == 1){
                Singleton.getInstance().setWinnersName(Singleton.getInstance().getPlayer1());
                victory();
            }else if (!Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer1WonSets() == 3){
                Singleton.getInstance().setWinnersName(Singleton.getInstance().getPlayer1());
                victory();
            }else if (Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer2WonSets() == 4){
                Singleton.getInstance().setWinnersName(Singleton.getInstance().getPlayer2());
                victory();
            }else if (!Singleton.getInstance().isSets() && Singleton.getInstance().getPlayer2WonSets() == 3){
                Singleton.getInstance().setWinnersName(Singleton.getInstance().getPlayer2());
                victory();
            }else {
                FragmentTransaction fragmentTransaction = getActivity()
                        .getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.fragment_container, new NewPoint());
                fragmentTransaction.commit();
            }
            }

    };

    public NewPoint() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    /**
     * Pushes to the database all the data about the match. To do so, it retrieves the data from the Singleton
     */
    private void victory(){
        short nbOfSets;
        if(Singleton.getInstance().isSets()) nbOfSets = 4;
        else nbOfSets = 3;
        MySQLiteGameHelper db = new MySQLiteGameHelper(getContext());
        db.createGame(Singleton.getInstance().getTimestamp(), Singleton.getInstance().getPlayer1(),Singleton.getInstance().getPlayer2(),Singleton.getInstance().getWinnersName(),nbOfSets,Singleton.getInstance().getPlayer1Points(),
                Singleton.getInstance().getPlayer2Points(), Singleton.getInstance().getPlayer1WonSets(), Singleton.getInstance().getPlayer2WonSets(), Singleton.getInstance().getPlayer1WinningShots(),
                Singleton.getInstance().getPlayer2WinningShots(), Singleton.getInstance().getPlayer1Aces(), Singleton.getInstance().getPlayer2Aces(), Singleton.getInstance().getPlayer1DirectFaults(), Singleton.getInstance().getPlayer2DirectFaults(),
                Singleton.getInstance().getPlayer1WinningReturns(), Singleton.getInstance().getPlayer2WinningReturns());
        FragmentTransaction fragmentTransaction = getActivity()
                .getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fragment_container, new EndGameFragment());
        fragmentTransaction.commit();
        //Singleton.getInstance().reset();
    }

    /**
     * It creates the view and sets the right players name for the service
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return view
     */
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
        if((Singleton.getInstance().getPlayer1ActualSet() + Singleton.getInstance().getPlayer2ActualSet()) < 21){
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