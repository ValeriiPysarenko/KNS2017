clear, clc, close all
    rho       = 2332e-18;%������� 
    F         = 1e3;     % ���� 
    E         = 180e3;   % ������ ����
    Sy        = 30;      % �������� ����������
    h=50;                % ������
    delta_max = 50;      % ����������� ���������

    f  = @(x,u) [...                         % ������ ���������
                    rho*h*x(2)*x(1)          % ����
                    (4*F*x(2)^3)/(E*h*x(1)^3)% ���������
                ];

    %% ���������
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
                 5   50           % ������� ���� ������ ����������  
                 300   1000       % ������� ���� ������� ���������� 
             ];
    label     = {'���� (kg)','³�������� (mkm)'}; 


%% ������� ��������� ��
mu      = 100;               % parent population size
lambda  = 100;               % ����� ���������
gen     = 100;               % ������� ���������
rec_obj = 2;                 % ������� ������ ���������
rec_str = 4;                 
u       = 0;                 % external excitation
[min_x, min_f] = ENSES(f, mu, lambda, gen, rec_obj, rec_str, u, nf, nx, limits, g, ng);

%% ��������� ���������
for i = 1:nf-1
  for k = i+1:nf
    figure (1)
    plot(min_f{1}(i,:),min_f{1}(k,:),'o')
    grid on
    title('��������� ���������, gen = 0','FontSize',8)
    xlabel(label{i},'FontSize',12);
    ylabel(label{k},'FontSize',12);
    legend('��������� ��������� ��� gen = 0','location','Best')
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

