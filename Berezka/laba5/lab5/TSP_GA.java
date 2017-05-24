package com.mnl.lab5;

public class TSP_GA {

    public static void main(String[] args) {

        City city = new City(60, 200);
        Manager.addCity(city);
        City city2 = new City(180, 200);
        Manager.addCity(city2);
        City city3 = new City(80, 180);
        Manager.addCity(city3);
        City city4 = new City(140, 180);
        Manager.addCity(city4);
        City city5 = new City(20, 160);
        Manager.addCity(city5);
        City city6 = new City(100, 160);
        Manager.addCity(city6);
        City city7 = new City(200, 160);
        Manager.addCity(city7);
        City city8 = new City(140, 140);
        Manager.addCity(city8);
        City city9 = new City(40, 120);
        Manager.addCity(city9);
        City city10 = new City(100, 120);
        Manager.addCity(city10);
        City city11 = new City(180, 100);
        Manager.addCity(city11);
        City city12 = new City(60, 80);
        Manager.addCity(city12);
        City city13 = new City(120, 80);
        Manager.addCity(city13);
        City city14 = new City(180, 60);
        Manager.addCity(city14);
        City city15 = new City(20, 40);
        Manager.addCity(city15);
        City city16 = new City(100, 40);
        Manager.addCity(city16);
        City city17 = new City(200, 40);
        Manager.addCity(city17);
        City city18 = new City(20, 20);
        Manager.addCity(city18);
        City city19 = new City(60, 20);
        Manager.addCity(city19);
        City city20 = new City(160, 20);
        Manager.addCity(city20);

        Population pop = new Population(50, true);

        pop = GA.evolvePopulation(pop);
        for (int i = 0; i < 100; i++) {
            pop = GA.evolvePopulation(pop);
        }

        System.out.println("Кількість міст: " + Manager.numberOfCities());
        System.out.println("Розмір популяції: " + pop.populationSize());
        System.out.println("Дистанція: " + pop.getFittest().getDistance());
        System.out.println("Шлях:");
        System.out.println(pop.getFittest());
    }
}