
function scores = Rosenbruk(pop)
scores = zeros(size(pop,1),1);
for i = 1:size(pop,1)
    x = pop(i,:);
    scores(i) = 100*(x(2)-x(1)^2)^2+(1-x(1))^2;
end


