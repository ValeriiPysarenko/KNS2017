%% ����������� ������������� ��������� (���5)

function [xoverKids] = CrossoverFcn( parents, options, nvars, FitnessFcn, ...
    unused,thisPopulation )

% parents - ������� ������ � ������� ���������, �� ������ ������ � ����������.
% nvars - ������� ������ (����)
% thisPopulation - ������� ��������� (�������)

result = zeros(length(parents)/2, nvars);
for i = 1:2:length(parents)-1
    parent1 = thisPopulation(parents(i), :);
    parent2 = thisPopulation(parents(i+1), :);
    
    separator = randi([2, nvars-1],1,1);        %���������� ������ �������� �����
    gene1 = randi([1, separator-1],1,1);        %���������� ������ ���
    gene2 = randi([separator+1, nvars],1,1);    %���������� ������ ���
    
    child = zeros(1, nvars);                    %����������� �������
    child(1,1:gene1) = parent1(1:gene1);        %��������� ���� ���� �� 1�� ����
    child(1,gene2:nvars) = parent1(gene2:nvars);%��������� ���� ������ �� 2�� ����
    
    nextGene = gene1+1;                         %��������� ��� ���� 1��
    inarr = ismember(parent2(1,:), child);      %�������� �������� ���� ������� � ������� ������
    for j = 1:1:nvars
        if (inarr(j) == 0)
            child(1, nextGene) = parent2(j);    %��������� ���� �������
            nextGene = nextGene + 1;
        end
    end
    
    result((i+1)/2,:) = child;
end;

xoverKids = result;
end


%% ʳ����
