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
    private static final String TABLE_NAME = "JackyTable";
    private static final String COL1 = "ID";
    private static final String COL2 = "ITEM1";

    /**
     * Constructor
     *
     * @param context
     */
    public MySQLiteGameHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    /**
     * Changed in BDD
     *
     * @param sqLiteDatabase
     */
    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String createTable = "CREATE TABLE " + TABLE_NAME +
                " (ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                " ITEM1 TEXT)";
        sqLiteDatabase.execSQL(createTable);
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

    /**
    public void createGame(Integer idGame, String player1, String player2, Integer nbOfSets, Integer firstServ ) {
        player1 = player1.replace("'", "''");
        player2= player2.replace("'", "''");
        String strSQL = "insert into ppGame (idGame, player1, player2, nbOfSets, firstServ) values ( '"
                + idGame + ", " + player1 + "','" + player2 + "', " + nbOfSets + "," + firstServ + ")";
        this.getWritableDatabase().execSQL( strSQL );
        Log.i("DATABASE", "startGame invoked");
    }**/

    public boolean addData(String item1) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(COL2, item1);

        long result = db.insert(TABLE_NAME, null, contentValues);

        //if date as inserted incorrectly it will return -1
        if (result == -1) {
            return false;
        } else {
            return true;
        }
    }

    public Cursor getListContents(){
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor data = db.rawQuery("SELECT * FROM " + TABLE_NAME, null);
        return data;
    }
}
