max_min = @(x) prod(x);
% ????????? ??
optGA = gaoptimset('PlotFcns', @gaplotbestfun, 'PlotInterval', 10, 'PopInitRange', [-10 ; 53]);
[Xga,Fga] = ga(max_min,2,optGA)