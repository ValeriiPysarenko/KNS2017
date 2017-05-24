function y = func2(x)
y = zeros(size(x,1),1);
for i = 1:size(x,1)
    z = x(i);
    y(i) = i*z^2;
end