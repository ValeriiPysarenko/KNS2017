import jenes.GeneticAlgorithm;
import jenes.algorithms.SimpleGA;
 import jenes.chromosome.DoubleChromosome;
 import jenes.population.Individual;
import jenes.population.Population;
 import jenes.population.Population.Statistics;
 import jenes.population.Population.Statistics.Group;
 import jenes.tutorials.utils.Utils;
 

 public class EntropyProblem {
    
   private static int POPULATION_SIZE   = 100;
     private static int CHROMOSOME_LENGTH = 5;
    private static int GENERATION_LIMIT  = 100;
    
    private static GeneticAlgorithm<DoubleChromosome> ga; 
       
     public static void main(String[] args) {
         Utils.printHeader();
         System.out.println();
         
         System.out.println("TUTORIAL 4:");
         System.out.println("Find the probability distribution that maximizes (or minimize) the Shannon's entropy.");
         System.out.println();
         
         Individual<DoubleChromosome> sample = new Individual<DoubleChromosome>(new DoubleChromosome(CHROMOSOME_LENGTH,0,1));
         Population<DoubleChromosome> pop = new Population<DoubleChromosome>(sample, POPULATION_SIZE);
         
        ga = new SimpleGA<DoubleChromosome>(null, pop, GENERATION_LIMIT);
         
        System.out.println("Solving Max!:");
         solve( EntropyFitness.MAX );
 
         System.out.println("Solving Min!:");
       solve( EntropyFitness.MIN );
    }
    
    private static void solve(EntropyFitness fitness) {
        ga.setFitness(fitness);
         ga.evolve();
         
         Statistics stats = ga.getCurrentPopulation().getStatistics();
         GeneticAlgorithm.Statistics algostats = ga.getStatistics();
        
        Group legals = stats.getGroup(Population.LEGALS);       
         
         System.out.println(legals.get(0));
         System.out.format("found in %d ms.\n", algostats.getExecutionTime() );
         System.out.println();
        
         Utils.printStatistics(stats);        
     }
 }