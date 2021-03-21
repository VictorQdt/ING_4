package com.example.pingpong;

import android.database.Cursor;
import android.graphics.Typeface;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

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

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

/**
 * A simple {@link Fragment} subclass.
 */
public class ListGamesFragment extends Fragment {

    // Form
    EditText addItem;
    Button btnAddItem;
    Calendar cal = Calendar.getInstance();

    // List
    ListView listViewGames;

    //Db
    MySQLiteGameHelper mySQLiteGameHelper;



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
       if (data.moveToFirst()){
           do {
               Date date = new Date(data.getLong(0)*1000L);
               System.out.println(data);
               SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");
               String strDate = simpleDateFormat.format(date);
               String listTag = strDate + "     " + data.getString(1) + " - " + data.getString(2);
               theList.add(listTag); // 1 = column number
               ListAdapter listAdapter;
               listAdapter= new ArrayAdapter<>(getContext(), android.R.layout.simple_list_item_1, theList);
               listViewGames.setAdapter(listAdapter);
               // Listener of the list og games
               listViewGames.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                   @Override
                   public void onItemClick(AdapterView<?> adapterView, View view, int positionView, long rowId) {
                       //Toast.makeText(History.this, "Position item : " + listAdapter.getItem(i) , Toast.LENGTH_SHORT).show();
                       data.moveToPosition((int)rowId);
                       Bundle bundle = new Bundle();
                       bundle.putString("player1",data.getString(1));
                       bundle.putString("player2",data.getString(2));
                       bundle.putString("winner", data.getString(3));
                       bundle.putShort("player1points",data.getShort(5));
                       bundle.putShort("player2points",data.getShort(6));
                       bundle.putShort("player1WinningShots",data.getShort(9));
                       bundle.putShort("player2WinningShots",data.getShort(10));
                       bundle.putShort("player1Aces",data.getShort(11));
                       bundle.putShort("player2Aces",data.getShort(12));
                       bundle.putShort("player1DirectFaults",data.getShort(13));
                       bundle.putShort("player2DirectFaults",data.getShort(14));
                       bundle.putShort("player1WinningReturns",data.getShort(15));
                       bundle.putShort("player2WinningReturns",data.getShort(16));
                       Fragment statsGame = new GameStatFragment();
                       statsGame.setArguments(bundle);
                       FragmentTransaction fragmentTransaction = getActivity()
                               .getSupportFragmentManager().beginTransaction();
                       fragmentTransaction.replace(R.id.fragment_container, statsGame);
                       fragmentTransaction.commit();
                   }
               });
           } while (data.moveToNext());
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
        System.out.println("allaal");

        // Inflate the layout for this fragment
        View newListGames = inflater.inflate(R.layout.fragment_list_games, container, false);
        Typeface type = Typeface.createFromAsset(getActivity().getAssets(),"fonts/2.ttf");
        addItem = (EditText) newListGames.findViewById(R.id.addItem);
        btnAddItem = (Button) newListGames.findViewById(R.id.btnAddItem);
        listViewGames = (ListView) newListGames.findViewById(R.id.listViewGames);
        addDataList();
        return newListGames;
    }
}