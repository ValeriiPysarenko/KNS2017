nn=40; % кількість міст
asz=10; % розмір області

ps=500; % чисельність популяції
ng=240; % Кількість поколінь

pm=0.1; % імовірність мутації двох міст
pm2=0.1; % імовірність мутації двох частин шляху
pmf=0.5; % імовірність мутації випадкової частини шляху

r=asz*rand(2,nn);  % випадкове розподілення міст
dsm=zeros(nn,nn); % матриця відстаней
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

% Почати з випадкових замкнених шляхів:
G=zeros(ps,nn); 
for psc=1:ps
    G(psc,:)=randperm(nn);
end

plot(1);

% вивід найкращого шляху:
hpb=plot(NaN,NaN,'g-');
ht=title(' ');

hold on;

% вивід ділянок вузла
for n=1:nn
    text(r(1,n),r(2,n),num2str(n));
end

plot(r(1,:),r(2,:),'ko');% виводити міста як чорні точки

axis equal;

%встановлення розміру графіка
xlim([-0.1*asz 1.1*asz]);
ylim([-0.1*asz 1.1*asz]);

pthd=zeros(ps,1); %довжина шляху
p=zeros(ps,1); % імовірності
 
%цикл поколінь
for gc=1:ng
        % знайти довжину шляху:
    for psc=1:ps
        Gt=G(psc,:);
        pt=0;% підсумовування довжини шляху
        for nc=1:nn-1
            pt=pt+dsm(Gt(nc),Gt(nc+1));
        end
        % останній і перший:
        pt=pt+dsm(Gt(nn),Gt(1));
        pthd(psc)=pt;
    end
    ipthd=1./pthd; % зворотня довжина шляху
    p=ipthd/sum(ipthd); % імовірності 
    
    [mbp bp]=max(p); 
    Gb=G(bp,:); % найкращий шлях   
    % Оновлення фігури
   
    if mod(gc,1)==0
        set(hpb,'Xdata',[r(1,Gb) r(1,Gb(1))],'YData',[r(2,Gb) r(2,Gb(1))]);
        set(ht,'string',['генерацій: ' num2str(gc)  '  найкраща довжина шляху: ' num2str(pthd(bp))]);

        drawnow;
    end
    
    % схрещування:
    ii=greedy(ps,p); % іі - гени номери генів міст, що будуть використані
    Gc=G(ii,:); % гени для схрещування
    Gch=zeros(ps,nn); % діти
    for prc=1:(ps/2) % підрахунок пар
        i1=1+2*(prc-1);
        i2=2+2*(prc-1);
        g1=Gc(i1,:); % перший ген
        g2=Gc(i2,:); % другий ген
        cp=ceil((nn-1)*rand);% точка схрещування, випадкове число в інтервалі [1; nn-1]
        % двоє дітей:
        g1ch=mutation_gold(g1,g2,cp);
        g2ch=mutation_gold(g2,g1,cp);
        Gch(i1,:)=g1ch;
        Gch(i2,:)=g2ch;
    end
    G=Gch; 

    for psc=1:ps
        if rand<pm
            rnp=ceil(nn*rand); 
            rpnn=randperm(nn);
            ctp=rpnn(1:rnp); 
            Gt=G(psc,ctp); 
            Gt=Gt(randperm(rnp)); 
            G(psc,ctp)=Gt;
         end
    end
        % мутація золотого перетину:
    for psc=1:ps
        if rand<pm2
            cp=1+ceil((nn-3)*rand); % діапазон 
            G(psc,:)=[G(psc,cp+1:nn) G(psc,1:cp)];
        end
    end
    
    for psc=1:ps
        if rand<pmf
            n1=ceil(nn*rand);
            n2=ceil(nn*rand);
            G(psc,n1:n2)=fliplr(G(psc,n1:n2));
        end
    end
    
    G(1,:)=Gb;    
end
