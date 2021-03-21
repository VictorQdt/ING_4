package com.example.pingpong;

import android.annotation.SuppressLint;
import android.graphics.Typeface;
import android.os.AsyncTask;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import android.graphics.Color;
import android.os.Bundle;

import com.github.mikephil.charting.charts.BarChart;
import com.github.mikephil.charting.components.XAxis;
import com.github.mikephil.charting.data.BarData;
import com.github.mikephil.charting.data.BarDataSet;
import com.github.mikephil.charting.data.BarEntry;
import com.github.mikephil.charting.utils.ColorTemplate;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class GameStatFragment extends Fragment {

    private TextView idGame, pct_winning_shotsP1, pct_winning_returnsP1, pct_direct_faultsP1, pct_acesP1, TOTAL_win_pointsP1, pct_winning_shotsP2, pct_winning_returnsP2, pct_direct_faultsP2, pct_acesP2, TOTAL_win_pointsP2, stats_WinnerName, stats_Nameplayer1, stats_Nameplayer2;
    private BarChart chart;
    private TableLayout tableLayout;
    int[] color = new int[]{Color.RED, Color.CYAN, Color.BLUE};

    private String player1, player2, winner;
    private short player1points, player2points, player1WinningShots, player2WinningShots,
    player1Aces, player2Aces, player1DirectFaults, player2DirectFaults, player1WinningReturns, player2WinningReturns;
    public GameStatFragment(){ }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        player1 = getArguments().getString("player1");
        player2 = getArguments().getString("player2");
        winner = getArguments().getString("winner");
        player1points = getArguments().getShort("player1points");
        player2points = getArguments().getShort("player2points");
        player1WinningShots = getArguments().getShort("player1WinningShots");
        player2WinningShots = getArguments().getShort("player2WinningShots");
        player1Aces = getArguments().getShort("player1Aces");
        player2Aces = getArguments().getShort("player2Aces");
        player1DirectFaults = getArguments().getShort("player1DirectFaults");
        player2DirectFaults = getArguments().getShort("player2DirectFaults");
        player1WinningReturns= getArguments().getShort("player1WinningReturns");
        player2WinningReturns = getArguments().getShort("player2WinningReturns");
        CalculationTask calculation = new CalculationTask(player1points,player2points,player1WinningShots,player2WinningShots,player1Aces,player2Aces,player1DirectFaults,player2DirectFaults,player1WinningReturns,player2WinningReturns);
        ArrayList<Short> list = new ArrayList<Short>();
        calculation.execute();
    }

    @SuppressLint("WrongViewCast")
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        //Initialize view
        View view_stats = inflater.inflate(R.layout.fragment_game_stat, container, false);

        //Typeface font = Typeface.createFromAsset(getActivity().getAssets(), "fonts/ProductSans.ttf");
        idGame = (TextView) view_stats.findViewById(R.id.id_STATS);
        tableLayout = (TableLayout) view_stats.findViewById(R.id.tableLayout);
        chart = (BarChart) view_stats.findViewById(R.id.chart);
        pct_winning_shotsP1 = (TextView)view_stats.findViewById(R.id.pct_winning_shotsP1);
        pct_winning_shotsP2 = (TextView)view_stats.findViewById(R.id.pct_winning_shotsP2);
        pct_winning_returnsP1 = (TextView)view_stats.findViewById(R.id.pct_winning_returnsP1);
        pct_winning_returnsP2 = (TextView)view_stats.findViewById(R.id.pct_winning_returnsP2);
        pct_direct_faultsP1 = (TextView)view_stats.findViewById(R.id.pct_direct_faultsP1);
        pct_direct_faultsP2 = (TextView)view_stats.findViewById(R.id.pct_direct_faultsP2);
        pct_acesP1 = (TextView)view_stats.findViewById(R.id.pct_acesP1);
        pct_acesP2 = (TextView)view_stats.findViewById(R.id.pct_acesP2);
        TOTAL_win_pointsP1 = (TextView)view_stats.findViewById(R.id.TOTAL_win_pointsP1);
        TOTAL_win_pointsP2 = (TextView)view_stats.findViewById(R.id.TOTAL_win_pointsP2);
        stats_Nameplayer1 = (TextView)view_stats.findViewById(R.id.stats_Nameplayer1);
        stats_Nameplayer2 = (TextView)view_stats.findViewById(R.id.stats_Nameplayer2);
        stats_WinnerName = (TextView)view_stats.findViewById(R.id.stats_WinnerName);

        BarDataSet barDataSet = new BarDataSet(data(), "bar set");
        barDataSet.setColors(color);

        BarData barData = new BarData(barDataSet);
        chart.setData(barData);
        // Inflate the layout for this fragment
        return view_stats;
    }

    private ArrayList<BarEntry> data() {
        ArrayList<BarEntry> dataVal = new ArrayList<>();
        dataVal.add(new BarEntry(0, new float[]{2,5.5f,4}));
        dataVal.add(new BarEntry(1, new float[]{3,4.5f,7}));
        dataVal.add(new BarEntry(2, new float[]{4,8.5f,2}));
        return dataVal;
    }

    private class CalculationTask extends AsyncTask<Short, Void, ArrayList<Short>>{

        short player1points, player2points, player1WinningShots, player2WinningShots, player1Aces, player2Aces, player1DirectFaults, player2DirectFaults, player1WinningReturns, player2WinningReturns;
        ArrayList<Short> list;
        public CalculationTask(short player1points, short player2points, short player1WinningShots, short player2WinningShots,
        short player1Aces, short player2Aces, short player1DirectFaults, short player2DirectFaults, short player1WinningReturns, short player2WinningReturns){
            this.player1points =player1points;
            this.player2points = player2points;
            this.player1WinningShots = player1WinningShots;
            this.player2WinningShots =player2WinningShots;
            this.player1Aces = player1Aces;
            this.player2Aces = player2Aces;
            this.player1DirectFaults = player1DirectFaults;
            this.player2DirectFaults = player2DirectFaults;
            this.player1WinningReturns = player1WinningReturns;
            this.player2WinningReturns = player2WinningReturns;
        };

        @Override
        protected ArrayList<Short> doInBackground(Short... shorts) {
            ArrayList<Short> list2 = new ArrayList<>();
            list2.add((short) (player1WinningShots*100/player1points));
            list2.add((short) (player1WinningReturns*100/player1points));
            list2.add((short) (player1DirectFaults*100/player1points));
            list2.add((short) (player1Aces*100/player1points));
            list2.add((short) (player2WinningShots*100/player1points));
            list2.add((short) (player2WinningReturns*100/player1points));
            list2.add((short) (player2DirectFaults*100/player1points));
            list2.add((short) (player2Aces*100/player1points));
            this.list = list2;
            return list2;
        }

        @Override
        protected void onPostExecute(ArrayList<Short> shorts) {
            super.onPostExecute(list);
            pct_winning_shotsP1.setText(list.get(0).toString());
            pct_winning_returnsP1.setText(list.get(1).toString());
            pct_direct_faultsP1.setText(list.get(2).toString());
            pct_acesP1.setText(shorts.get(3).toString());
            TOTAL_win_pointsP1.setText(String.valueOf(player1points));
            pct_winning_shotsP2.setText(list.get(4).toString());
            pct_winning_returnsP2.setText(list.get(5).toString());
            pct_direct_faultsP2.setText(list.get(6).toString());
            pct_acesP2.setText(list.get(7).toString());
            TOTAL_win_pointsP2.setText(String.valueOf(player2points));
            stats_WinnerName.setText(winner);
            stats_Nameplayer1.setText(player1);
            stats_Nameplayer2.setText(player2);
        }

    }

}