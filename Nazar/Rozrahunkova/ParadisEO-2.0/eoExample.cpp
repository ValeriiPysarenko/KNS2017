#include <eo>
...
 // Class involving a simple call to the function of initialisation of a solution
  ProblemInit chromInit;

  int popSize = 10;
  eoPop<Problem> pop(popSize, chromInit);  // Initialise the population

   // Declaration of class wrapping the evaluation function of the QAP
  ProblemEvalFunc eval;

  // SELECT
  // The robust tournament selection
  int tSize=2; // size of the tournament
  eoDetTournamentSelect<Problem> selectOne(tSize);
  // is now encapsulated in a eoSelectPerc (entage)
  eoSelectPerc<Problem> select(selectOne);// by default rate==1

  ProblemXover Xover;  // CROSSOVER ;
  double pCross = 0.6; //probability for crossover

  ProblemSwapMutation  mutationSwap;  // MUTATION 
  double pMut = 0.3; //probability for mutation

  // The operators are  encapsulated into an eoTRansform object
  eoSGATransform<Problem> transform(Xover, pCross, mutationSwap, pMut);

  // replacement engine
  eoPlusReplacement<Problem> replace;

  eoGenContinue<Problem> genCont(100); // number of maximum generation;

  eoEasyEA<Problem> gga(genCont, eval, select, transform, replace);

  // Apply algo to pop - that's it!
  gga(pop);
----------------------------------------
class ProblemInit : public eoInit<Problem> {
/* Thanks to the previous line, genotype of each individual 
is the same as the representation of our Problem*/
public:
void operator()(Problem & _problem) {
/* It is just a call of our problem initialization */
    _problem.%color=blue%create()%%;
  }
};


class ProblemXover : public eoQuadOp<Problem> {
public:
 /* The two parameters in input are the parents.
    The first parameter is also the output ie the child 
  */
 bool operator()(Problem & _problem1, Problem & _problem2)  {
    int i;
    int random, temp;
    int unassigned_positions[n];
    int remaining_items[n];
    int j = 0;

    /* 1) find the items assigned in different positions for the 2 parents */
    for (i = 0 ; i < n ; i++){
      if (_problem1.solution[i] != _problem2.solution[i]){
	unassigned_positions[j] = i;
	remaining_items[j] = _problem1.solution[i];
	j++;
      }
    }

    /* 2) shuffle the remaining items to ensure that remaining items 
       will be assigned at random positions */
    for (i = 0; i < j; i++){
      random = rand()%(j-i) + i;
      temp = remaining_items[i];
      remaining_items[i] = remaining_items[random];
      remaining_items[random] = temp;
    }

    /* 3) copy the shuffled remaining items at unassigned positions */
    for (i = 0; i < j ; i++)
      _problem1.solution[unassigned_positions[i]] = remaining_items[i];

    // crossover in our case is always possible
    return true; 
  }
};


class ProblemSwapMutation: public eoMonOp<Problem> {
public:
  bool operator()(Problem& _problem)   {
    int i,j;
    int temp;

    // generate two different indices
    i=rand()%n;
    do 
      j = rand()%n; 
    while (i == j);  

    // swap
    temp = _problem.solution[i];
    _problem.solution[i] = _problem.solution[j];
    _problem.solution[j] = temp;

    return true;

  }
};


