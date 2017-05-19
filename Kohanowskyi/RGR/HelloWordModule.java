
import org.opt4j.core.config.annotations.Parent;
import org.opt4j.core.problem.ProblemModule;
import org.opt4j.tutorial.TutorialModule;

@Parent(TutorialModule.class)
public class HelloWordModule extends ProblemModule {

protected void config() {
	bindProblem(HelloWordCreator.class, HelloWordDecoder.class, HelloWordEvaluator.class);
}

}