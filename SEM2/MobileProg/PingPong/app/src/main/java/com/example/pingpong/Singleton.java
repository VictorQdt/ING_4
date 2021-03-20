package com.example.pingpong;

public class Singleton {
    private static Singleton uniqueInstance;



    public int getPlayer1WonSets() {
        return player1WonSets;
    }

    public void setPlayer1WonSets(int player1WonSets) {
        this.player1WonSets = player1WonSets;
    }

    public int getPlayer2WonSets() {
        return player2WonSets;
    }

    public void setPlayer2WonSets(int player2WonSets) {
        this.player2WonSets = player2WonSets;
    }

    public int getPlayer1ActualSet() {
        return player1ActualSet;
    }

    public void setPlayer1ActualSet(int player1ActualSet) {
        this.player1ActualSet = player1ActualSet;
    }

    public int getPlayer2ActualSet() {
        return player2ActualSet;
    }

    public void setPlayer2ActualSet(int player2ActualSet) {
        this.player2ActualSet = player2ActualSet;
    }


    public int getPlayer1WinningReturns() {
        return player1WinningReturns;
    }

    public void setPlayer1WinningReturns(int player1WinningReturns) {
        this.player1WinningReturns = player1WinningReturns;
    }

    public int getPlayer2WinningReturns() {
        return player2WinningReturns;
    }

    public void setPlayer2WinningReturns(int player2WinningReturns) {
        this.player2WinningReturns = player2WinningReturns;
    }



    public int getPlayer1Points() {
        return player1Points;
    }

    public void setPlayer1Points(int player1Points) {
        this.player1Points = player1Points;
    }

    public int getPlayer2Points() {
        return player2Points;
    }

    public void setPlayer2Points(int player2Points) {
        this.player2Points = player2Points;
    }

    public int getPlayer1WinningShots() {
        return player1WinningShots;
    }

    public void setPlayer1WinningShots(int player1WinningShots) {
        this.player1WinningShots = player1WinningShots;
    }

    public int getPlayer2WinningShots() {
        return player2WinningShots;
    }

    public void setPlayer2WinningShots(int player2WinningShots) {
        this.player2WinningShots = player2WinningShots;
    }

    public int getPlayer1Aces() {
        return player1Aces;
    }

    public void setPlayer1Aces(int player1Aces) {
        this.player1Aces = player1Aces;
    }

    public int getPlayer2Aces() {
        return player2Aces;
    }

    public void setPlayer2Aces(int player2Aces) {
        this.player2Aces = player2Aces;
    }

    public int getPlayer1DirectFaults() {
        return player1DirectFaults;
    }

    public void setPlayer1DirectFaults(int player1DirectFaults) {
        this.player1DirectFaults = player1DirectFaults;
    }

    public int getPlayer2DirectFaults() {
        return player2DirectFaults;
    }

    public void setPlayer2DirectFaults(int player2DirectFaults) {
        this.player2DirectFaults = player2DirectFaults;
    }


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

    private boolean isStarted;
    private String player1, player2;
    private boolean sets, firstService;
    private int pointNumber;
    private int totalPoints;
    private int player1Points;
    private int player2Points;
    private int player1WinningShots;
    private int player2WinningShots;
    private int player1Aces;
    private int player2Aces;
    private int player1DirectFaults;
    private int player2DirectFaults;
    private int player1ActualSet, player2ActualSet;
    private int player1WonSets, player2WonSets;
    private int player1WinningReturns, player2WinningReturns;

    public void reset (){
        this.isStarted = false;
        this.player1 ="";
        this.player2 ="";
        this.sets = true;
        this.firstService =true;
        this.totalPoints = 0;
        this.pointNumber = 1;
        this.player1Points = 0;
        this.player2Points = 0;
        this.player1WinningShots = 0;
        this.player2WinningShots = 0;
        this.player1Aces = 0;
        this.player2Aces = 0;
        this.player1DirectFaults = 0;
        this.player2DirectFaults = 0;
        this.player1ActualSet = 0;
        this.player2ActualSet = 0;
        this.player1WonSets = 0;
        this.player2WonSets = 0;
        this.player1WinningReturns = 0;
        this.player1WinningReturns = 0;
    }


    public static Singleton getInstance() {
        if (uniqueInstance == null)
            uniqueInstance = new Singleton();
        return uniqueInstance;
    }


}
