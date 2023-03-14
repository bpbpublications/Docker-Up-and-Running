package com.example;

public class App 
{
    public static void main( String[] args )
    {
        System.out.println("Starting debugging demo application");
        int i = 1;
        while(true){
            System.out.println("Round " + i);
            try {
                Thread.sleep(5000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            i++;
        }
    }
}
