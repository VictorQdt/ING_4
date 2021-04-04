package com.example.pingpong;

import android.database.Cursor;
import android.graphics.Typeface;
import android.os.AsyncTask;
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

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

/**
 * A simple {@link Fragment} subclass.
 */
public class ListGamesFragment extends Fragment {

    ListView listViewGames;
    MySQLiteGameHelper mySQLiteGameHelper;
    RequestQueue requestQueue;


    public ListGamesFragment() {
        // Required empty public constructor
    }

    /**
     * Function to retrieve data from the database to generate the clickable list of the past matches
     */

    public void getListContent(){

        StringRequest postRequest = new StringRequest(Request.Method.POST, "http://192.168.33.10/dbconfig.php",
                new Response.Listener<String>()
                {
                    @Override
                    public void onResponse(String response) {
                        // response
                        try {
                            JSONArray jsonObject = new JSONArray(response);
                            ArrayList<String> theList = new ArrayList<>();
                            for (int i = 0; i<jsonObject.length(); i++){
                                JSONObject actual = jsonObject.getJSONObject(i);
                                Date date = new Date(Long.parseLong(actual.getString("timestamp"))*1000L);
                                SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");
                                String strDate = simpleDateFormat.format(date);
                                String listTag = strDate + "     " + actual.getString("player1") + "     " + actual.getString("player2");
                                theList.add(listTag); // 1 = column number
                                ListAdapter listAdapter;
                                listAdapter= new ArrayAdapter<>(getContext(), android.R.layout.simple_list_item_1, theList);
                                listViewGames.setAdapter(listAdapter);
                                listViewGames.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                                    /**
                                     * create a bundle for each clickable element with the data of the associated match and replace the fragement with
                                     * the gamestat fragment
                                     * @param adapterView
                                     * @param view
                                     * @param positionView
                                     * @param rowId
                                     */
                                    @Override
                                    public void onItemClick(AdapterView<?> adapterView, View view, int positionView, long rowId) {
                                        //Toast.makeText(History.this, "Position item : " + listAdapter.getItem(i) , Toast.LENGTH_SHORT).show();
                                        try {
                                            JSONObject actual2 = jsonObject.getJSONObject((int) rowId);
                                            Bundle bundle = new Bundle();
                                            try {
                                                bundle.putString("player1",actual2.getString("player1"));
                                                bundle.putString("player2",actual2.getString("player2"));
                                                bundle.putString("winner", actual2.getString("winner"));
                                                bundle.putShort("player1points",Short.parseShort(actual2.getString("player1points")));
                                                bundle.putShort("player2points",Short.parseShort(actual2.getString("player2points")));
                                                bundle.putShort("player1WinningShots",Short.parseShort(actual2.getString("player1WinningShots")));
                                                bundle.putShort("player2WinningShots",Short.parseShort(actual2.getString("player2WinningShots")));
                                                bundle.putShort("player1Aces",Short.parseShort(actual2.getString("player1Aces")));
                                                bundle.putShort("player2Aces",Short.parseShort(actual2.getString("player2Aces")));
                                                bundle.putShort("player1DirectFaults",Short.parseShort(actual2.getString("player1DirectFaults")));
                                                bundle.putShort("player2DirectFaults",Short.parseShort(actual2.getString("player2DirectFaults")));
                                                bundle.putShort("player1WinningReturns",Short.parseShort(actual2.getString("player1WinningReturns")));
                                                bundle.putShort("player2WinningReturns",Short.parseShort(actual2.getString("player2WinningReturns")));
                                            } catch (JSONException e) {
                                                e.printStackTrace();
                                            }
                                            Fragment statsGame = new GameStatFragment();
                                            statsGame.setArguments(bundle);
                                            FragmentTransaction fragmentTransaction = getActivity()
                                                    .getSupportFragmentManager().beginTransaction();
                                            fragmentTransaction.replace(R.id.fragment_container, statsGame);
                                            fragmentTransaction.commit();
                                        } catch (JSONException e) {
                                            e.printStackTrace();
                                        }

                                    }
                                });
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                },
                new Response.ErrorListener()
                {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // error
                        System.out.println("lalal2" + error.getMessage());
                    }
                }
        ){
            @Override
            protected Map<String, String> getParams()
            {
                Map<String, String>  params = new HashMap<String, String>();
                params.put("key", "1");
                return params;
            }
        };

        requestQueue.add(postRequest);

    }

    /**
     * Async Task to retrieve the data from the database
     */
    private class FillList extends AsyncTask<Void, Void, Void> {

       @Override
       protected Void doInBackground(Void... voids) {
           getListContent();
           return null;
       }
   }

    /**
     * Function to create the list of games with the local database
     */
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
                   /**
                    * create a bundle for each clickable element with the data of the associated match and replace the fragement with
                    * the gamestat fragment
                    * @param adapterView
                    * @param view
                    * @param positionView
                    * @param rowId
                    */
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
        requestQueue = MainActivity.requestQueue;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View newListGames = inflater.inflate(R.layout.fragment_list_games, container, false);
        Typeface type = Typeface.createFromAsset(getActivity().getAssets(),"fonts/2.ttf");
        listViewGames = (ListView) newListGames.findViewById(R.id.listViewGames);
        new FillList().execute();
        return newListGames;
    }
}