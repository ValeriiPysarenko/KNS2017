function f = my_fun3(pop)
f = zeros(size(pop,1),1);
for i = 1:size(pop,1)
    x = pop(i,:);
    f(i) = x^2;
end
