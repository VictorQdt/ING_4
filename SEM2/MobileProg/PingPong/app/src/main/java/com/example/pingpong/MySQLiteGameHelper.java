package com.example.pingpong;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import androidx.annotation.Nullable;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class MySQLiteGameHelper extends SQLiteOpenHelper {

    private static final String DATABASE_NAME = "Game.db";
    private static final int DATABASE_VERSION = 1;

    /**
     * Constructor
     *
     * @param context
     */
    public MySQLiteGameHelper(@Nullable Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    /**
     * Changed in BDD
     *
     * @param sqLiteDatabase
     */
    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String strSql = "create table ppGame ("
                + " idGame TEXT PRIMARY KEY AUTOINCREMENT,"
                + " player1 TEXT NOT NULL,"
                + " player2 TEXT NOT NULL,"
                + " nbOfSets INTEGER NOT NULL,"
                + " firstServ INTEGER NOT NULL"
                + ")";
        sqLiteDatabase.execSQL( strSql );
        Log.i("DATABASE", "onCreate invoked");
    }

    /**
     * Changed in Version
     *
     * @param sqLiteDatabase
     * @param i
     * @param i1
     */
    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        String strSQL = "drop table ppGame";
        sqLiteDatabase.execSQL( strSQL );
        this.onCreate(sqLiteDatabase);
        Log.i("DATABASE", "onCreate invoked");
    }

    public void createGame(Integer idGame, String player1, String player2, Integer nbOfSets, Integer firstServ ) {
        player1 = player1.replace("'", "''");
        player2= player2.replace("'", "''");
        String strSQL = "insert into ppGame (idGame, player1, player2, nbOfSets, firstServ) values ( '"
                + idGame + ", " + player1 + "','" + player2 + "', " + nbOfSets + "," + firstServ + ")";
        this.getWritableDatabase().execSQL( strSQL );
        Log.i("DATABASE", "startGame invoked");
    }

    public List<MySQLiteGameHelper> listGames(){
        List<MySQLiteGameHelper> games = new ArrayList<>();

        String strSQL = "select * from ppGame";
        Cursor cursor = this.getReadableDatabase().rawQuery(strSQL, null);
        cursor.moveToNext();
        while (!cursor.isAfterLast()){
            //History game = new
        }
        return games;
    }
}
