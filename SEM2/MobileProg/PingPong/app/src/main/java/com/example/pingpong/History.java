package com.example.pingpong;

import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.List;

public class History extends AppCompatActivity {

    // Form
    private EditText addItem;
    private Button btnAddItem;

    // List
    private ListView listViewGames;

    //Db
    private MySQLiteGameHelper mySQLiteGameHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_history);

        addItem = (EditText) findViewById(R.id.addItem);
        btnAddItem = (Button) findViewById(R.id.btnAddItem);
        listViewGames = (ListView) findViewById(R.id.listViewGames);
        mySQLiteGameHelper = new MySQLiteGameHelper(this);

        btnAddItem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String newEntry = addItem.getText().toString();
                if (addItem.length() != 0) {
                    // Add the item into the DB
                    addDataDB(newEntry);
                    addItem.setText("");
                    // Add the item into the list :
                    addDataList();
                } else {
                    Toast.makeText(History.this, "You must put something in the text field!", Toast.LENGTH_LONG).show();
                }
            }
        });
        //mySQLiteGameHelper.close();
    }

    /**
     *
     * @param newEntry
     * Populate the DataBase with the newEntry
     */
    private void addDataDB(String newEntry) {
        boolean insertData = mySQLiteGameHelper.addData(newEntry);

        if (insertData == true) {
            Toast.makeText(this, "Data Successfully Inserted!", Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(this, "Something went wrong :(.", Toast.LENGTH_LONG).show();
        }
    }

    /**
     * Populate an ArrayList<String> from the database and then view it
     */
    private void addDataList() {
        ArrayList<String> theList = new ArrayList<>();
        Cursor data = mySQLiteGameHelper.getListContents();
        if (data.getCount() == 0) {
            Toast.makeText(History.this, "There are no contents in this list!", Toast.LENGTH_LONG).show();
        } else {
            while (data.moveToNext()) {
                theList.add(data.getString(1)); // 1 = column number
                ListAdapter listAdapter = new ArrayAdapter<>(getApplicationContext(), android.R.layout.simple_list_item_1, theList);
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
    }
}