kst=40; % ������� ���
plot_size=10; % ����� ������ asx x asz

pop_kst=300; % ���������� ���������
pokol_kst=1500; % ʳ������ �������

pm=0.01; % ��������� ������� ���� ���
pm2=0.02; % ��������� ������� ���� ������ �����
pmf=0.08; % ��������� ������� ��������� ������� �����

graph=plot_size*rand(2,kst); % ��������� ����������� ���
vid_mat=zeros(kst,kst); % ������� ��������

for n1=1:kst-1
    r1=graph(:,n1);
    for n2=n1+1:kst
        r2=graph(:,n2);
        dr=r1-r2;
        dr2=dr'*dr;
        drl=sqrt(dr2);
        vid_mat(n1,n2)=drl;
        vid_mat(n2,n1)=drl;
    end
end

% ������ � ���������� ��������� ������:
G=zeros(pop_kst,kst); 
for psc=1:pop_kst
    G(psc,:)=randperm(kst);
end

plot(1)

% ���� ���������� �����:
hpb=plot(NaN,NaN,'r-');
ht=title(' ');
hold on;
% ���� ������ �����
for n=1:kst
    text(graph(1,n),graph(2,n),num2str(n));
end

plot(graph(1,:),graph(2,:),'k.'); % �������� ���� �� ���� �����

axis equal;

%������������ ������ �������
xlim([-0.1*plot_size 1.1*plot_size]);
ylim([-0.1*plot_size 1.1*plot_size]);

pthd=zeros(pop_kst,1); %������� �����
p=zeros(pop_kst,1); % ���������

%���� �������
for gc=1:pokol_kst
    % ������ ������� �����:
    for psc=1:pop_kst
        Gt=G(psc,:);
        pt=0; % ������������� ������� �����
        for nc=1:kst-1
            pt=pt+vid_mat(Gt(nc),Gt(nc+1));
        end
        % ������� � ������:
        pt=pt+vid_mat(Gt(kst),Gt(1));
        pthd(psc)=pt;
    end
    ipthd=1./pthd; % �������� ������� �����
    p=ipthd/sum(ipthd); % ��������� 
    
    [mbp bp]=max(p); 
    Gb=G(bp,:); % ��������� ����    
    
    % ��������� ������
    if mod(gc,5)==0
        set(hpb,'Xdata',[graph(1,Gb) graph(1,Gb(1))],'YData',[graph(2,Gb) graph(2,Gb(1))]);
        set(ht,'string',['��������: ' num2str(gc)  '  �������� ������� �����: ' num2str(pthd(bp))]);
        drawnow;
    end
    
   % �����������:
    ii=roulette_wheel_indexes(pop_kst,p); % �� - ���� ������ ���� ���, �� ������ ����������
    Gc=G(ii,:); % ���� ��� �����������
    Gch=zeros(pop_kst,kst); % ���
    for prc=1:(pop_kst/2) % ��������� ���
        i1=1+2*(prc-1);
        i2=2+2*(prc-1);
        g1=Gc(i1,:); % ������ ���
        g2=Gc(i2,:); % ������ ���
        cp=ceil((kst-1)*rand); % ����� �����������, ��������� ����� � �������� [1; nn-1]
        % ��� ����:
        g1ch=insert_begining(g1,g2,cp);
        g2ch=insert_begining(g2,g1,cp);
        Gch(i1,:)=g1ch;
        Gch(i2,:)=g2ch;
    end
    G=Gch; % ���
    
    % ������� ����� ���� ���������� ���:
    for psc=1:pop_kst
        if rand<pm
            rnp=ceil(kst*rand); % ��������� ����� ��� ��� �������
            rpnn=randperm(kst);
            ctp=rpnn(1:rnp); %������� rnp ���������� ��� ��� �������
            Gt=G(psc,ctp); % �������� �� ���� � ������
            Gt=Gt(randperm(rnp)); % ����������� ����
            G(psc,ctp)=Gt; % % ��������� ���� �����
         end
    end   
    
    % ������� ����� 2 ������ �����:
    for psc=1:pop_kst
        if rand<pm2
            cp=1+ceil((kst-3)*rand); % ������� [2 nn-2]
            G(psc,:)=[G(psc,cp+1:kst) G(psc,1:cp)];
        end
    end   
    
    % ������� ����� ��������� ������� �����:
    for psc=1:pop_kst
        if rand<pmf
            n1=ceil(kst*rand);
            n2=ceil(kst*rand);
            G(psc,n1:n2)=fliplr(G(psc,n1:n2));
        end
    end
    
   G(1,:)=Gb; % ���������  
end
