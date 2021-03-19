package com.example.antoinecopiecolle;

import android.provider.BaseColumns;

public class MatchContract {

    private MatchContract(){}

    public static final class MatchEntry implements BaseColumns{
        //Nom de toute la table
        public static final String TABLE_NAME = "matchList";
        //Nom des colonnes
        public static final String COLUMN_NAME_FIGHTER_ONE = "fighterOne";
        public static final String COLUMN_NAME_FIGHTER_TWO = "fighterTwo";
        public static final String COLUMN_NAME_CATEGORIE_POIDS = "categoriePoids";
        public static final String COLUMN_NAME_ROUNDS = "rounds";
        public static final String COLUMN_NAME_LATITUDE = "latitude";
        public static final String COLUMN_NAME_LONGITUDE = "longitude";
        public static final String COLUMN_NAME_RED_JAB = "redJab";
        public static final String COLUMN_NAME_RED_UPPERCUT = "redUppercut";
        public static final String COLUMN_NAME_RED_KICK = "redKick";
        public static final String COLUMN_NAME_RED_TACKLE = "redTackle";
        public static final String COLUMN_NAME_RED_IMMO = "redImmo";
        public static final String COLUMN_NAME_BLUE_JAB = "blueJab";
        public static final String COLUMN_NAME_BLUE_UPPERCUT = "blueUppercut";
        public static final String COLUMN_NAME_BLUE_KICK = "blueKick";
        public static final String COLUMN_NAME_BLUE_TACKLE = "blueTackle";
        public static final String COLUMN_NAME_BLUE_IMMO = "blueImmo";
        public static final String COLUMN_NAME_VAINQUEUR = "vainqueur";
        public static final String COLUMN_NAME_TYPE_VICTOIRE = "typeVictoire";
        public static final String IMAGE = "image";

        public static final String COLUMN_TIMESTAMP = "timestamp";


    }
}
