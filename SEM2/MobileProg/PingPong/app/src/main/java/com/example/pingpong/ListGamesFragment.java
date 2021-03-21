package com.example.pingpong;

import android.database.Cursor;
import android.graphics.Typeface;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

/**
 * A simple {@link Fragment} subclass.
 */
public class ListGamesFragment extends Fragment {

    // Form
    private EditText addItem;
    private Button btnAddItem;

    // List
    private ListView listViewGames;

    //Db
    private MySQLiteGameHelper mySQLiteGameHelper;



    private View.OnClickListener onClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {

        }
    };

    public ListGamesFragment() {
        // Required empty public constructor
    }

    private void addDataList() {
        ArrayList<String> theList = new ArrayList<>();
        Cursor data = mySQLiteGameHelper.getListContents();
            while (data.moveToNext()) {
                theList.add(data.getString(1)); // 1 = column number
                ListAdapter listAdapter = new ArrayAdapter<>(getContext(), android.R.layout.simple_list_item_1, theList);
                listViewGames.setAdapter(listAdapter);
                // Listener of the list og games
                listViewGames.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                        //Toast.makeText(History.this, "Position item : " + listAdapter.getItem(i) , Toast.LENGTH_SHORT).show();

                    }
                });
            }
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mySQLiteGameHelper = new MySQLiteGameHelper(getContext());
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View newListGames = inflater.inflate(R.layout.fragment_list_games, container, false);
        Typeface type = Typeface.createFromAsset(getActivity().getAssets(),"fonts/2.ttf");
        addItem = (EditText) newListGames.findViewById(R.id.addItem);
        btnAddItem = (Button) newListGames.findViewById(R.id.btnAddItem);
        listViewGames = (ListView) newListGames.findViewById(R.id.listViewGames);

        return newListGames;
    }
}