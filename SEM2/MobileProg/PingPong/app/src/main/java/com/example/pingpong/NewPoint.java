package com.example.pingpong;

import android.os.AsyncTask;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.os.Handler;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.Switch;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Fragment NewPoint for register every point of the match
 */
public class NewPoint extends Fragment {

    //properties
    TextView actualPlayer;
    Button nextButton;
    Switch ace, winningReturn;
    RadioButton player1, player2, direct, fault;
    private Handler handler;

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

            } else if (Singleton.getInstance().getPlayer2ActualSet() == 11 && Singleton.getInstance().getPlayer1ActualSet() <= 9){

                Singleton.getInstance().setPlayer2WonSets((short) (Singleton.getInstance().getPlayer2WonSets() + 1));
                Singleton.getInstance().setPlayer2ActualSet(0);
                Singleton.getInstance().setPlayer1ActualSet(0);
                // redémarrer les services
                Singleton.getInstance().setPointNumber((short) 1);

            }

            // égalité
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
            // Ici on truque le jeu avec 1 set pour gagner pour le player 1
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
        handler = new Handler();
        super.onCreate(savedInstanceState);

    }

    /**
     * Pushes to the database all the data about the match. To do so, it retrieves the data from the Singleton
     */
    private void victory(){
        short nbOfSets;
        if(Singleton.getInstance().isSets()) nbOfSets = 4;
        else nbOfSets = 3;
        createGame(Singleton.getInstance().getTimestamp(), Singleton.getInstance().getPlayer1(),Singleton.getInstance().getPlayer2(),Singleton.getInstance().getWinnersName(),nbOfSets,Singleton.getInstance().getPlayer1Points(),
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
        if((Singleton.getInstance().getPlayer1ActualSet() + Singleton.getInstance().getPlayer2ActualSet()) < 21){ // somme < 21 donc 2 services chacun (pas d'égalité)
            if(Singleton.getInstance().isFirstService()){
                if(actualPoint == 1 || actualPoint == 2) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
                else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
            }
            else {
                if(actualPoint == 1 || actualPoint == 2) actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer2());
                else actualPlayer.setText("Service : " + Singleton.getInstance().getPlayer1());
            }
        }else { // 1 service chacun
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


    /**
     * Inserts in the table the informations of a match using a post request to our distant database
     * @param timestamp
     * @param player1
     * @param player2
     * @param winner
     * @param nbOfSets
     * @param player1points
     * @param player2points
     * @param player1WonSets
     * @param player2WonSets
     * @param player1WinningShots
     * @param player2WinningShots
     * @param player1Aces
     * @param player2Aces
     * @param player1DirectFaults
     * @param player2DirectFaults
     * @param player1WinningReturns
     * @param player2WinningReturns
     */
    public void createGame(Long timestamp, String player1, String player2, String winner,Short  nbOfSets, Short player1points, Short player2points,
                           Short player1WonSets, Short player2WonSets, Short player1WinningShots, Short player2WinningShots, Short player1Aces,
                           Short player2Aces, Short player1DirectFaults, Short player2DirectFaults, Short player1WinningReturns, Short player2WinningReturns) {
        MySQLiteGameHelper db = new MySQLiteGameHelper(getContext());
        String finalPlayer = player2;
        String finalPlayer1 = player1;
        StringRequest postRequest = new StringRequest(Request.Method.POST, "http://192.168.33.10/dbconfig.php",
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response
                        System.out.println(response);
                    }
                },
                new Response.ErrorListener()
                {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // error
                        System.out.println("lala" + error.getMessage());
                    }
                }
        ){
            @Override
            protected Map<String, String> getParams()
            {
                Map<String, String>  params = new HashMap<String, String>();
                params.put("timestamp",timestamp.toString());
                params.put("player1", finalPlayer1);
                params.put("player2", finalPlayer);
                params.put("winner", winner);
                params.put("nbOfSets", String.valueOf(nbOfSets));
                params.put("player1points", String.valueOf(player1points));
                params.put("player2points", String.valueOf(player2points));
                params.put("player1WonSets", String.valueOf(player1WonSets));
                params.put("player2WonSets", String.valueOf(player2WonSets));
                params.put("player1WinningShots", String.valueOf(player1WinningShots));
                params.put("player2WinningShots", String.valueOf(player2WinningShots));
                params.put("player1Aces", String.valueOf(player1Aces));
                params.put("player2Aces", String.valueOf(player2Aces));
                params.put("player1DirectFaults", String.valueOf(player1DirectFaults));
                params.put("player2DirectFaults", String.valueOf(player2DirectFaults));
                params.put("player1WinningReturns", String.valueOf(player1WinningReturns));
                params.put("player2WinningReturns", String.valueOf(player2WinningReturns));
                params.put("key", "0");
                return params;
            }
        };

        /**
         * Runnable to execute the database operations in a different thread
         */
        Runnable runnable = new Runnable() {          //Method using threads and handlers
            @Override
            public void run() {

                handler.post(new Runnable() {
                    @Override
                    public void run() {

                        db.createGame(timestamp, player1, player2,  winner,  nbOfSets, player1points,  player2points,
                                player1WonSets, player2WonSets,  player1WinningShots, player2WinningShots,  player1Aces,
                                 player2Aces,  player1DirectFaults,  player2DirectFaults, player1WinningReturns, player2WinningReturns);
                        MainActivity.requestQueue.add(postRequest);
                    }
                });
            }
        };
        new Thread(runnable).start();


    }

}