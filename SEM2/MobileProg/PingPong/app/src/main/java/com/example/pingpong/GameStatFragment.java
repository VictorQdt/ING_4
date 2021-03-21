package com.example.pingpong;

import android.annotation.SuppressLint;
import android.graphics.Typeface;
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
import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class GameStatFragment extends Fragment {

    private TextView idGame;
    private BarChart chart;
    private TableLayout tableLayout;
    int[] color = new int[]{Color.RED, Color.CYAN, Color.BLUE};


    public GameStatFragment(){ }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
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



}