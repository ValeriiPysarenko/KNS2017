clc;clear;close all;
nn=50; % e?eue?nou i?no
asz=10; % ?ici?? iaeano? asx x asz
ps=200; % ?enaeui?nou iiioeyo??
ng=200; % E?eue?nou iieie?iu
pm=0.05; % ?iia??i?nou iooao??
r=asz*rand(2,nn); % aeiaaeiaa ?iciia?eaiiy i?no
dsm=zeros(nn,nn); % iao?eoy a?anoaiae
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
% Ii?aoe c aeiaaeiaeo caieiaieo oeyo?a:
G=zeros(ps,nn); 
for psc=1:ps
    G(psc,:)=randperm(nn);
end
figure('units','normalized','position',[0.05 0.2 0.9 0.6]);
subplot(1,2,1);
% aea?a iaee?auiai oeyoo:
hpb=plot(NaN,NaN,'r-');
ht=title(' ');
hold on;
% aea?a a?eyiie aocea
for n=1:nn
    text(r(1,n),r(2,n),num2str(n),'color',[0.7 0.7 0.7]);
end
plot(r(1,:),r(2,:),'k.'); % aeaiaeoe i?noa ye ?i?i? oi?ee
axis equal;
xlim([-0.1*asz 1.1*asz]);
ylim([-0.1*asz 1.1*asz]);
subplot(1,2,2);
pthd=zeros(ps,1); %aia?eia oeyoo
for gc=1:ng % oeee iieie?iu
    % ciaeoe aia?eio oeyoo:
    for psc=1:ps
        Gt=G(psc,:);
        pt=0; % i?anoiiaoaaiiy aia?eie oeyoo
        for nc=1:nn-1
            pt=pt+dsm(Gt(nc),Gt(nc+1));
        end
        % inoaii?e ? ia?oee:
        pt=pt+dsm(Gt(nn),Gt(1));
        pthd(psc)=pt;
    end
    min(pthd)
    [mbp(gc) bp]=min(pthd); 
    Gb=0;
    G(bp,:);
    Gb=G(bp,:); % iaee?auee oeyo    
    % iiiaeoe iaee?auee oeyo ia o?ao??:
    if mod(gc,5)==0
        set(hpb,'Xdata',[r(1,Gb) r(1,Gb(1))],'YData',[r(2,Gb) r(2,Gb(1))]);
        set(ht,'string',['generation: ' num2str(gc)  '  best path length: ' num2str(pthd(bp))]);
        plot(mbp)
        title('best path length');
        xlabel('generation number');
        ylabel('best path value');
        drawnow;
        
    end
   % no?auoaaiiy:
   Gch=zeros(ps,nn); % a?oe
   for psc=1:(ps/2)
       i1=1+2*(psc-1);
       i2=2+2*(psc-1);
       g1=G(i1,:); %ia?oee aai
       g2=G(i2,:); %?ioee aai
       for i3=0:1
           p1=0;
       p1(1)=randi([1,nn]);   %1 krok
       j=1;
       while j<nn
           temp=p1(j);
           if temp==nn
               temp=0;
           end
           j=j+1;
           fh1=dsm(p1(j-1),g1(temp+1)); %a?anoaiu i??  iiia?aai?i ia?aiei aaiii ? aaiii 1ai aaouea
           fh2=dsm(p1(j-1),g2(temp+1)); %a?anoaiu i??  iiia?aai?i ia?aiei aaiii ? aaiii 2ai aaouea
           j21=0; %?e aeaiaio g1(temp+1) a?a  a iauaaeo
           j22=0; %?e aeaiaio g2(temp+1) a?a  a iauaaeo
           j23=0; %?e aea?aii aai aey iauaaea
           for j1=1:j-1  %?e 2 aaie aaoue?a ? a iauaaeo
                   if p1(j1)==g1(temp+1)
                       j21=1;
                   end
                   if p1(j1)==g2(temp+1)
                       j22=1;
                   end
           end
           if [j21==0,j22==1] %yeui 1 iaia, 2 ?
               p1(j)=g1(temp+1);
               j23=1;
           end
           if [j22==0,j21==1] %yeui 2 iaia, 1 ?
               p1(j)=g1(temp+1);
               j23=1;
           end
           
           if [fh1<fh2,j21+j22==0] %yeui 1 aai iaioee oi eiai iae?a?i
               p1(j)=g1(temp+1);
           elseif (j21+j22)==0 %yeui 2 aai iaioee oi eiai iae?a?i
               p1(j)=g2(temp+1);
           else %yeui aai? aaie aaoue?a a?a ? a iauaaeo ai aee?a?i aeiaaeiaei ?eiii ?c ua ia ia?aieo
               j1=1;
               while j1>0
                 j1=0;
                 j2=randi([1,nn]);
                 for j3=1:j-1
                     if p1(j3)==j2
                         j1=1;
                     end
                 end
               end
            p1(j)=j2;
           end
       end % while
       Gch(i1+i3,:)=p1;
   end
  
   end %for psc=1:(ps/2)
   G=0;
   G=Gch;
   % iooao?y cieioiai ia?aoeio:
   for psc=1:ps
       if rand<pm
           n=ceil(nn*0.61803);
           G(psc,n:n+1)=fliplr(G(psc,n:n+1));
       end
   end
   G(1,:)=Gb; % ae?oa?i?nou  
end