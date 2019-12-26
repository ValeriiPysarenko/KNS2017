function [x,fval,exitflag,output,population,score] = lab2(nvars,StallGenLimit_Data)
% This is an auto generated M-file from Optimization Tool.

% Start with the default options
options = gaoptimset;
% Modify options setting
options = gaoptimset(options,'StallGenLimit', StallGenLimit_Data);
options = gaoptimset(options,'SelectionFcn', @selectionstochunif);
options = gaoptimset(options,'CrossoverFcn', @crossovertwopoint);
options = gaoptimset(options,'MutationFcn', {  @mutationuniform [] });
options = gaoptimset(options,'Display', 'iter');
options = gaoptimset(options,'PlotFcns', {  @gaplotbestf @gaplotbestindiv @gaplotrange @gaplotscores });
[x,fval,exitflag,output,population,score] = ...
ga(@my_fun5,nvars,[],[],[],[],[],[],[],options);
