function scores = func3(x)
scores = zeros(size(x,1),1);
for i = 1:size(x,1)
    z = x(i,:);
    scores(i) = 100*(z(2)-z(1)^2)^2+(1-z(1))^2;
end
