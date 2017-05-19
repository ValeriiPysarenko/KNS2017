import org.opt4j.config.annotations.Parent;
import org.opt4j.core.optimizer.MaxIterations;
import org.opt4j.core.optimizer.OptimizerModule;

public class MutateOptimizerModule extends OptimizerModule {
	@MaxIterations
	protected int iterations = 1000;
	public int getIterations() {
		return iterations;
	}
	public void setIterations(int iterations) {
		this.iterations = iterations;
	}
	@Override
	public void config() {
		bindIterativeOptimizer(MutateOptimizer.class);
	}
}
