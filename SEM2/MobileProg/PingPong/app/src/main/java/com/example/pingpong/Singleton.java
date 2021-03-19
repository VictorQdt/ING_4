package com.example.pingpong;

public class Singleton {
    private static Singleton uniqueInstance;

    private String player1, player2;

    public boolean isSets() {
        return sets;
    }

    public void setSets(boolean sets) {
        this.sets = sets;
    }

    public boolean isFirstService() {
        return firstService;
    }

    public void setFirstService(boolean firstService) {
        this.firstService = firstService;
    }

    private boolean sets, firstService;

    public String getPlayer1() {
        return player1;
    }

    public void setPlayer1(String player1) {
        this.player1 = player1;
    }

    public String getPlayer2() {
        return player2;
    }

    public void setPlayer2(String player2) {
        this.player2 = player2;
    }

    private Singleton(){

    }

    public static Singleton getInstance() {
        if (uniqueInstance == null)
            uniqueInstance = new Singleton();
        return uniqueInstance;
    }


}
