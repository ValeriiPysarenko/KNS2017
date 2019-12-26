ObjectiveFunction = @fun;
nvars = 3;   
LB = [-10]; 
UB = [53]; 
ConstraintFunction = @constraint;
[x,fval] = ga(ObjectiveFunction,nvars,[],[],[],[],LB,UB,ConstraintFunction)