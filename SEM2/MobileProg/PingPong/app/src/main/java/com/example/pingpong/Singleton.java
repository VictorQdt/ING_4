package com.example.pingpong;

/**
 *
 */
public class Singleton {
    private static Singleton uniqueInstance;

    public short getPlayer1WonSets() {
        return player1WonSets;
    }

    public void setPlayer1WonSets(short player1WonSets) {
        this.player1WonSets = player1WonSets;
    }

    public short getPlayer2WonSets() {
        return player2WonSets;
    }

    public void setPlayer2WonSets(short player2WonSets) {
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


    public short getPlayer1WinningReturns() {
        return player1WinningReturns;
    }

    public void setPlayer1WinningReturns(short player1WinningReturns) {
        this.player1WinningReturns = player1WinningReturns;
    }

    public short getPlayer2WinningReturns() {
        return player2WinningReturns;
    }

    public void setPlayer2WinningReturns(short player2WinningReturns) {
        this.player2WinningReturns = player2WinningReturns;
    }



    public short getPlayer1Points() {
        return player1Points;
    }

    public void setPlayer1Points(short player1Points) {
        this.player1Points = player1Points;
    }

    public short getPlayer2Points() {
        return player2Points;
    }

    public void setPlayer2Points(short player2Points) {
        this.player2Points = player2Points;
    }

    public short getPlayer1WinningShots() {
        return player1WinningShots;
    }

    public void setPlayer1WinningShots(short player1WinningShots) {
        this.player1WinningShots = player1WinningShots;
    }

    public short getPlayer2WinningShots() {
        return player2WinningShots;
    }

    public void setPlayer2WinningShots(short player2WinningShots) {
        this.player2WinningShots = player2WinningShots;
    }

    public short getPlayer1Aces() {
        return player1Aces;
    }

    public void setPlayer1Aces(short player1Aces) {
        this.player1Aces = player1Aces;
    }

    public short getPlayer2Aces() {
        return player2Aces;
    }

    public void setPlayer2Aces(short player2Aces) {
        this.player2Aces = player2Aces;
    }

    public short getPlayer1DirectFaults() {
        return player1DirectFaults;
    }

    public void setPlayer1DirectFaults(short player1DirectFaults) {
        this.player1DirectFaults = player1DirectFaults;
    }

    public short getPlayer2DirectFaults() {
        return player2DirectFaults;
    }

    public void setPlayer2DirectFaults(short player2DirectFaults) {
        this.player2DirectFaults = player2DirectFaults;
    }


    public short getTotalPoints() {
        return totalPoints;
    }

    public void setTotalPoints(short totalPoints) {
        this.totalPoints = totalPoints;
    }

    public boolean isStarted() {
        return isStarted;
    }

    public void setStarted(boolean started) {
        isStarted = started;
    }



    public short getPointNumber() {
        return pointNumber;
    }

    public void setPointNumber(short pointNumber) {
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

    public String getWinnersName() {
        return winnersName;
    }

    public void setWinnersName(String winnersName) {
        this.winnersName = winnersName;
    }
    public long getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(long timestamp) {
        this.timestamp = timestamp;
    }

    private boolean isStarted;
    private String player1;
    private String player2;
    private String winnersName;
    private long timestamp;
    private boolean sets, firstService;
    private short pointNumber;
    private short totalPoints;
    private short player1Points;
    private short player2Points;
    private short player1WinningShots;
    private short player2WinningShots;
    private short player1Aces;
    private short player2Aces;
    private short player1DirectFaults;
    private short player2DirectFaults;
    private int player1ActualSet, player2ActualSet;
    private short player1WonSets;
    private short player2WonSets;
    private short player1WinningReturns;
    private short player2WinningReturns;

    public void reset (){
        this.isStarted = false;
        this.player1 ="";
        this.player2 ="";
        this.winnersName ="";
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
        this.timestamp = 0;
    }


    public static Singleton getInstance() {
        if (uniqueInstance == null)
            uniqueInstance = new Singleton();
        return uniqueInstance;
    }


}
