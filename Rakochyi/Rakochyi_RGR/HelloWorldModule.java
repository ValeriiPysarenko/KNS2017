package helloworld;

import org.opt4j.core.problem.ProblemModule;

/**
 * Created by Taras on 19.05.2017.
 */
public class HelloWorldModule extends ProblemModule {
    protected void config() {
        bindProblem(HelloWorldCreator.class, HelloWorldDecoder.class, HelloWorldEvaluator.class);
    }
}
