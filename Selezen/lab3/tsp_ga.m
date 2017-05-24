nn=40; % ������� ���
asz=10; % ����� ������ asx x asz
ps=300; % ���������� ���������
ng=500; % ʳ������ �������
pm=0.01; % ��������� ������� ����� 2 ���������� ��� �� ����� (per gene, per genration)
pm2=0.02; % ��������� ������� ����� 2 ������ ����� (per gene, per genration)
pmf=0.08; % ��������� ������� ����� ��������� ������� �����
r=asz*rand(2,nn); % ��������� ����������� ���
dsm=zeros(nn,nn); % ������� ��������
for n1=1:nn-1
    r1=r(:,n1);
    for n2=n1+1:nn
        r2=r(:,n2);
        dr=r1-r2;
        dr2=dr'*dr;
        drl=sqrt(dr2);
        dsm(n1,n2)=drl;
        dsm(n2,n1)=drl;
    end
end
% ������ � ���������� ��������� ������:
G=zeros(ps,nn); 
for psc=1:ps
    G(psc,:)=randperm(nn);
end
figure('units','normalized','position',[0.05 0.2 0.9 0.6]);
subplot(1,2,1);
% ���� ���������� �����:
hpb=plot(NaN,NaN,'r-');
ht=title(' ');
hold on;
% ���� ������ �����
for n=1:nn
    text(r(1,n),r(2,n),num2str(n),'color',[0.7 0.7 0.7]);
end
plot(r(1,:),r(2,:),'k.'); % �������� ���� �� ���� �����
axis equal;
xlim([-0.1*asz 1.1*asz]);
ylim([-0.1*asz 1.1*asz]);
subplot(1,2,2);
hi=imagesc(G);
title('color is city number');
colorbar;
xlabel('index in sequence of cities');
ylabel('path number');
pthd=zeros(ps,1); %������� �����
p=zeros(ps,1); % ���������
for gc=1:ng % ���� �������
    % ������ ������� �����:
    for psc=1:ps
        Gt=G(psc,:);
        pt=0; % ������������� ������� �����
        for nc=1:nn-1
            pt=pt+dsm(Gt(nc),Gt(nc+1));
        end
        % ������� � ������:
        pt=pt+dsm(Gt(nn),Gt(1));
        pthd(psc)=pt;
    end
    ipthd=1./pthd; % �������� ������� �����
    p=ipthd/sum(ipthd); % ��������� 
    [mbp bp]=max(p); 
    Gb=G(bp,:); % ��������� ����    
    % ������� ��������� ���� �� �����:
    if mod(gc,5)==0
        set(hpb,'Xdata',[r(1,Gb) r(1,Gb(1))],'YData',[r(2,Gb) r(2,Gb(1))]);
        set(ht,'string',['generation: ' num2str(gc)  '  best path length: ' num2str(pthd(bp))]);
        set(hi,'CData',G);
        drawnow;
    end
   % �����������:
    ii=roulette_wheel_indexes(ps,p); % ���� � �������� ��� ii ������ ���������� � ����������
    Gc=G(ii,:); % ���� ��� �����������
    Gch=zeros(ps,nn); % ���
    for prc=1:(ps/2) % ��������� ���
        i1=1+2*(prc-1);
        i2=2+2*(prc-1);
        g1=Gc(i1,:); %������ ���
        g2=Gc(i2,:); %����� ���
        cp=ceil((nn-1)*rand); % ����� �����������, ��������� ����� � �������� [1; nn-1]
        % ��� ����:
        g1ch=insert_begining(g1,g2,cp);
        g2ch=insert_begining(g2,g1,cp);
        Gch(i1,:)=g1ch;
        Gch(i2,:)=g2ch;
    end
    G=Gch; % ��� ���
    % ������� ����� ���� ���������� ���:
    for psc=1:ps
        if rand<pm
            rnp=ceil(nn*rand); % ��������� ����� ��� ��� ������������
            rpnn=randperm(nn);
            ctp=rpnn(1:rnp); %������� rnp ���������� ��� ��� ������������
            Gt=G(psc,ctp); % �������� ���� � ������
            Gt=Gt(randperm(rnp)); % ����������� ����
            G(psc,ctp)=Gt; % % ��������� ���� �����
         end
    end   
    % ������� ����� 2 ������ �����:
    for psc=1:ps
        if rand<pm2
            cp=1+ceil((nn-3)*rand); % ������� [2 nn-2]
            G(psc,:)=[G(psc,cp+1:nn) G(psc,1:cp)];
        end
    end   
    % ������� ����� ��������� ������� �����:
    for psc=1:ps
        if rand<pmf
            n1=ceil(nn*rand);
            n2=ceil(nn*rand);
            G(psc,n1:n2)=fliplr(G(psc,n1:n2));
        end
    end
   G(1,:)=Gb; % ���������  
end
