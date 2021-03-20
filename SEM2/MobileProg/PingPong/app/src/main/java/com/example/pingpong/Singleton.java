package com.example.pingpong;

public class Singleton {
    private static Singleton uniqueInstance;

    private String player1, player2;
    private boolean sets, firstService;
    private int pointNumber, totalPoints;

    public int getTotalPoints() {
        return totalPoints;
    }

    public void setTotalPoints(int totalPoints) {
        this.totalPoints = totalPoints;
    }

    public boolean isStarted() {
        return isStarted;
    }

    public void setStarted(boolean started) {
        isStarted = started;
    }

    private boolean isStarted;

    public int getPointNumber() {
        return pointNumber;
    }

    public void setPointNumber(int pointNumber) {
        this.pointNumber = pointNumber;
    }

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

    Singleton(){

    }

    public void reset (){
        this.isStarted = false;
        this.player1 ="";
        this.player2 ="";
        this.sets = true;
        this.firstService =true;
        this.totalPoints = 0;
        this.pointNumber = 1;
    }

    public static Singleton getInstance() {
        if (uniqueInstance == null)
            uniqueInstance = new Singleton();
        return uniqueInstance;
    }


}
