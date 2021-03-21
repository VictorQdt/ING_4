package com.example.pingpong;

import android.content.ContentValues;
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

    private static final String DATABASE_NAME = "Jack.db";
    private static final int DATABASE_VERSION = 1;
    private static final String TABLE_NAME = "ppGame";

    /**
     * Constructor
     *
     * @param context
     */
    public MySQLiteGameHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    /**
     * Creates the table ppGame
     *
     * @param sqLiteDatabase
     */
    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {

        String strSql = "create table ppGame ("
                + "timestamp INTEGER PRIMARY KEY AUTOINCREMENT,"
                + " player1 TEXT NOT NULL,"
                + " player2 TEXT NOT NULL,"
                + " winner TEXT NOT NULL,"
                + " nbOfSets SHORT NOT NULL,"
                + " player1points SHORT NOT NULL,"
                + " player2points SHORT NOT NULL,"
                + " player1WonSets SHORT NOT NULL,"
                + " player2WonSets SHORT NOT NULL,"
                + " player1WinningShots SHORT NOT NULL,"
                + " player2WinningShots SHORT NOT NULL,"
                + " player1Aces SHORT NOT NULL,"
                + " player2Aces SHORT NOT NULL,"
                + " player1DirectFaults SHORT NOT NULL,"
                + " player2DirectFaults SHORT NOT NULL,"
                + " player1WinningReturns SHORT NOT NULL,"
                + " player2WinningReturns SHORT NOT NULL"
                + ")";
        sqLiteDatabase.execSQL( strSql );
        Log.i("DATABASE", "onCreate invoked");
    }

    /**
     * Drops the table
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

    /**
     * Inserts in the table the informations of a match
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
        player1 = player1.replace("'", "''");
        player2= player2.replace("'", "''");
        String strSQL = "insert into ppGame (timestamp, player1, player2, winner, nbOfSets, player1points, player2points, player1WonSets, player2WonSets,player1WinningShots, player2WinningShots, player1Aces, player2Aces, player1DirectFaults, player2DirectFaults, player1WinningReturns, player2WinningReturns ) values ( "
                + timestamp + ", '" + player1 + "','" + player2 + "', '" + winner + "', " + nbOfSets + "," + player1points + "," + player2points + "," + player1WonSets + "," + player2WonSets
                + "," + player1WinningShots + "," + player2WinningShots + "," + player1Aces + "," + player2Aces + "," + player1DirectFaults + "," + player2DirectFaults + "," + player1WinningReturns
                + "," + player2WinningReturns+ ")";
        this.getWritableDatabase().execSQL( strSQL );
        Log.i("DATABASE", "startGame invoked");
    }

    /**
     * Retrieve the data from the table ppGame
     * @return
     */
    public Cursor getListContents(){
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor data = db.rawQuery("SELECT * FROM " + TABLE_NAME, null);
        return data;
    }
}
