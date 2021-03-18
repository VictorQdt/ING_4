package com.example.antoinecopiecolle;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.ItemTouchHelper;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

public class Historique extends AppCompatActivity {

    public static final String ID_DU_MATCH_SELECTIONNE = "com.example.antoinecopiecolle.extra.ID_DU_MATCH_SELECTIONNE";

    private SQLiteDatabase database;
    private MatchAdapter adapter;
    RecyclerView recyclerView;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_historique);

        final com.example.antoinecopiecolle.MatchDBHelper dbHelper = new com.example.antoinecopiecolle.MatchDBHelper(this);
        database = dbHelper.getWritableDatabase();

        recyclerView = findViewById(R.id.recycleView);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        adapter = new MatchAdapter(this, getAllItems());
        recyclerView.setAdapter(adapter);

        new ItemTouchHelper(new ItemTouchHelper.SimpleCallback(0, ItemTouchHelper.LEFT | ItemTouchHelper.RIGHT) {
            @Override
            public boolean onMove(@NonNull RecyclerView recyclerView, @NonNull RecyclerView.ViewHolder viewHolder, @NonNull RecyclerView.ViewHolder target) {
                return false;
            }

            @Override
            public void onSwiped(@NonNull RecyclerView.ViewHolder viewHolder, int direction) {
                removeItem((long) viewHolder.itemView.getTag());
            }
        }).attachToRecyclerView(recyclerView);

        //Gère le click sur le recycle view, le setOnClick n'existe pas, on l'a donc créé manuellement dans MatchAdapter
        adapter.setOnItemClickListener(new MatchAdapter.OnItemClickListener() {
            @Override
            public void onItemClick(int position, RecyclerView.ViewHolder viewHolder) {
                Intent intent_details = new Intent(com.example.antoinecopiecolle.Historique.this, com.example.antoinecopiecolle.DetailsMatch.class);
                //database.rawQuery("SELECT * FROM matchList WHERE " + MatchContract.MatchEntry._ID + " = " + viewHolder.itemView.getTag(),null);
                intent_details.putExtra(ID_DU_MATCH_SELECTIONNE, viewHolder.itemView.getTag().toString());
                startActivity(intent_details);
            }
        });

    }

    private void removeItem(long id){
        database.delete(MatchContract.MatchEntry.TABLE_NAME, MatchContract.MatchEntry._ID + "=" + id, null);
        adapter.swapCursor(getAllItems());
    }

    //Trie les matchs pour les afficher du plus récent au plus ancien
    public Cursor getAllItems(){
        return database.query(
                MatchContract.MatchEntry.TABLE_NAME,
                null,
                null,
                null,
                null,
                null,
                MatchContract.MatchEntry.COLUMN_TIMESTAMP + " DESC"
        );
    }
}













