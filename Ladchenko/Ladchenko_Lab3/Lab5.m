clear, clc, close all
    rho       = 2332e-18;%густина 
    F         = 1e3;     % сила 
    E         = 180e3;   % модуль Юнга
    Sy        = 30;      % граничне напруження
    h=50;                % ширина
    delta_max = 50;      % максимальне відхилення

    f  = @(x,u) [...                         % фукція мінімізацції
                    rho*h*x(2)*x(1)          % маса
                    (4*F*x(2)^3)/(E*h*x(1)^3)% відхилення
                ];

    %% Обмеження
    g = @(x,u) [...                 
                    Sy - (6*F*x(2))/(h*x(1)^2)                                          
                    delta_max - (4*F*x(2)^3)/(E*h*x(1)^3)             
                    x(1) - 5                                                                              
                    50 - x(1)                                                                        
                    x(2) - 300                                                                             
                    1000 - x(2)                                                                            
               ];
             
    nx     = 2;                        % 'n_x' states
    nf     = length(f(nan(nx,1)));     % length of the output vector 'f(x,y)'
    ng     = length(g(nan(nx,1)));     % length of the constraint vector 'g(x,y)'
    limits = [...                      % State variables boundaries
                 5   50           % діапазон зміни ширини кантелівера  
                 300   1000       % діапазон зміни довжини кантелівера 
             ];
    label     = {'Маса (kg)','Відхилення (mkm)'}; 


%% задання параметрів ГА
mu      = 100;               % parent population size
lambda  = 100;               % розмір популяції
gen     = 100;               % кількість генерацій
rec_obj = 2;                 % кількість змінних параметрів
rec_str = 4;                 
u       = 0;                 % external excitation
[min_x, min_f] = ENSES(f, mu, lambda, gen, rec_obj, rec_str, u, nf, nx, limits, g, ng);

%% початкова популяція
for i = 1:nf-1
  for k = i+1:nf
    figure (1)
    plot(min_f{1}(i,:),min_f{1}(k,:),'o')
    grid on
    title('Початкова популяція, gen = 0','FontSize',8)
    xlabel(label{i},'FontSize',12);
    ylabel(label{k},'FontSize',12);
    legend('Початкова популяція для gen = 0','location','Best')
  end
end

%% Plot function
for i = 1:nf-1
  for k = i+1:nf
    figure (2)
    for j = 1:size(min_f,2)
      d = plot(min_f{j}(i,:),min_f{j}(k,:),'o');
      axis([min(min_f{j}(i,:)) max(min_f{j}(i,:)) min(min_f{j}(k,:)) max(min_f{j}(k,:))]);
      grid on
      title('Pareto optimal front','FontSize',12)
      xlabel(label{i},'FontSize',12);
      ylabel(label{k},'FontSize',12);
      pause(0.1)
      hold on
      if j ~= size(min_f,2)
        delete(d);
      end
    end
  end
end

if nf == 3
  figure (3)
  plot3(min_f{end}(1,:),min_f{end}(2,:),min_f{end}(3,:),'bo')
  grid on
  title('Pareto optimal front','FontSize',12)
  xlabel(label{1},'FontSize',12);
  ylabel(label{2},'FontSize',12);
  zlabel(label{3},'FontSize',12);
end

