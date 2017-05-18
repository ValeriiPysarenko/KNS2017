package travelingsalesman;

import com.google.inject.Inject;
import org.opt4j.core.genotype.PermutationGenotype;
import org.opt4j.core.problem.Creator;

import java.util.Collections;

/**
 * Created by Taras on 19.05.2017.
 */
public class SalesmanCreator implements Creator<PermutationGenotype<SalesmanProblem.City>> {
    protected final SalesmanProblem problem;
    @Inject
    public SalesmanCreator(SalesmanProblem problem) {
        this.problem = problem;
    }
    public PermutationGenotype<SalesmanProblem.City> create() {
        PermutationGenotype<SalesmanProblem.City> genotype = new PermutationGenotype<SalesmanProblem.City>();
        for (SalesmanProblem.City city : problem.getCities()) {
            genotype.add(city);
        }
        Collections.shuffle(genotype);
        return genotype;
    }
}

