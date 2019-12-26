package salesman_problem;

import java.awt.Graphics2D;
import java.util.Date;

import javax.swing.SwingUtilities;



public class TSP {
	    
	    static int nsity=45;
	 
    	static int npop=350;
    	
    	static int [] x=new int[nsity];
    	static int [] y=new int[nsity];
    	static int [] xline= new int[nsity];
    	static int [] yline= new int[nsity];
    	
    public static void main(String[] args) {

    	
    	System.out.println("��������� ���:");
    	for (int i = 0; i < nsity ; i++)
        {
         int newx = (int)(Math.random()*200);
         x[i]=newx;
         int newy = (int)(Math.random()*200);
         y[i]=newy;
         System.out.print("["+x[i]+","+y[i]+"],");
         if(i%10==9 ){
        	 System.out.println();
         }
        }
       
    	
    	for(int i = 0; i < x.length; i++){
    		TourManager.addCity(new City(x[i],y[i]));
    	}
    
        Population pop = new Population(npop, true);
        System.out.println("\n����� ���������: "+npop);
        Date currentTimeBefore = new Date();
        long timeBefore = currentTimeBefore.getTime();
    
        pop = GA.evolvePopulation(pop);
       
        for (int i = 0; i < 100; i++) {
        
            pop = GA.evolvePopulation(pop);
        }
        Date currentTimeAfter = new Date();
        long timeAfter= currentTimeAfter.getTime();;
        long time = timeAfter-timeBefore;
     
       
        System.out.println("������� �����: " + pop.getFittest().getDistance());
        System.out.println("��� ���������: " + time + " ��");
        System.out.println("��������� ����:");
        
        Tour t=new Tour();
        t=pop.getFittest();
        for(int i=0;i<nsity;i++){
        	   xline[i]= t.getCity(i).x;
        	   yline[i]= t.getCity(i).y;
        }
        
       for (int i = 0; i < nsity ; i++)
        {
           System.out.print("["+xline[i]+","+yline[i]+"],");
           if(i%10==9 ){
        	   System.out.println();
         }
        }
       
        SwingUtilities.invokeLater(new Runnable() {
                    
         @Override
         public void run() {
          CartesianFrame frame = new CartesianFrame();
          frame.showUI();;
         }
        });
        
    }
}