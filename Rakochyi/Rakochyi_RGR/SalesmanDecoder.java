package travelingsalesman;

import org.opt4j.core.genotype.PermutationGenotype;
import org.opt4j.core.problem.Decoder;

public class SalesmanDecoder implements Decoder<PermutationGenotype<SalesmanProblem.City>, SalesmanRoute> {
    public SalesmanRoute decode(PermutationGenotype<SalesmanProblem.City> genotype) {
        SalesmanRoute salesmanRoute = new SalesmanRoute();
        for (SalesmanProblem.City city : genotype) {
            salesmanRoute.add(city);
        }
        return salesmanRoute;
    }
}

