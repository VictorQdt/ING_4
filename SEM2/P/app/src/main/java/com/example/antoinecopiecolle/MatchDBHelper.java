package com.example.antoinecopiecolle;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class MatchDBHelper extends SQLiteOpenHelper {

    public static final String DATABASE_NAME = "matchList.db";
    public static final int DATABASE_VERSION = 1;

    public MatchDBHelper(@Nullable Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        //Dans ce string hyper long, les espaces ont de l'importance, puisque c'est des requetes SQL
        final String SQL_CREATE_MATCHLIST_TABLE = "CREATE TABLE " +
                MatchContract.MatchEntry.TABLE_NAME + " (" +
                MatchContract.MatchEntry._ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                MatchContract.MatchEntry.COLUMN_NAME_FIGHTER_ONE + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_FIGHTER_TWO + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_CATEGORIE_POIDS + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_ROUNDS + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_LATITUDE + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_LONGITUDE + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_RED_JAB + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_RED_UPPERCUT + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_RED_KICK + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_RED_TACKLE + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_RED_IMMO + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_BLUE_JAB + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_BLUE_UPPERCUT + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_BLUE_KICK + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_BLUE_TACKLE + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_BLUE_IMMO + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_VAINQUEUR + " TEXT, " +
                MatchContract.MatchEntry.COLUMN_NAME_TYPE_VICTOIRE + " TEXT, " +
                MatchContract.MatchEntry.IMAGE + " BLOB, " +
                MatchContract.MatchEntry.COLUMN_TIMESTAMP + " TIMESTAMP DEFAULT CURRENT_TIMESTAMP" +
                ");";

        sqLiteDatabase.execSQL(SQL_CREATE_MATCHLIST_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int oldVersion, int newVersion) {
        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + MatchContract.MatchEntry.TABLE_NAME);
        onCreate(sqLiteDatabase);
    }

   public Cursor getInformationsNeeded(String id){
        SQLiteDatabase db = this.getWritableDatabase();
        String query = "SELECT * FROM matchList WHERE _ID = '" + id + "'";
        Cursor cursor = db.rawQuery(query, null);
        return cursor;
    }
}
