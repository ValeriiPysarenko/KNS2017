clc;clear;close all;
nn=6; % кількість біт
ps=12; % чисельність популяції
ng=30; % Кількість поколінь
pm=0.05; % імовірність мутації
% Почати з випадкових x в межах х[-10,53]:
g=randi(64,1,ps)-11; 
for gc=1:ng % цикл поколінь
%селекція турнірна 1111111111111
'нове покоління gc='
gc
gt=g
gs=0;%для кращого перегляду результату
gt(2,1:ps)=getY(g)
gt(3,:)=0;
for i=1:ps/2
    test=1;
    while test==1
        ig=randi(ps);
        test=gt(3,ig);
    end
    gt(3,ig)=1;
    elem(1)=ig;
    %2
    test=1;
    while test==1
        ig=randi(ps);
        test=gt(3,ig);
    end
    gt(3,ig)=1;
    elem(2)=ig
    %вибір кращого
    if gt(2,elem(1))<gt(2,elem(2))
        gs(i)=gt(1,elem(1));
    else
        gs(i)=gt(1,elem(2));
    end
end
%схрещення 2222222222222222
gs
'одноточечне схрещення'
for psc=1:(ps/4)
        ts=randi(nn-1)+1 %точка схрещення 
       i1=1+2*(psc-1);
       i2=2+2*(psc-1);
       gs(i1)+10;
       gs(i2)+10;
       p1=bitget(gs(i1)+10,6:-1:1) %перший батько в бітовому представленні
       p2=bitget(gs(i2)+10,6:-1:1)%2 батько
       ch10=gs(i1)+10;
       for i=ts:6
           i;
           test_p2i=p2(7-i);
           ch10=bitset(ch10,i,p2(7-i)); % вставляємо біт
           bitget(ch10,6:-1:1);
       end
        child=bitget(ch10,6:-1:1)%arhiv
       gs(ps/2+i1)=ch10-10;
        
        ts=randi(nn-1)+1
       ch10=gs(i1)+10;
       for i=ts:6
           i;
           test_p2i=p2(7-i);
           ch10=bitset(ch10,i,p2(7-i)); % вставляємо біт
           bitget(ch10,6:-1:1);
       end
       child=bitget(ch10,6:-1:1)%arhiv
        gs(ps/2+i2)=ch10-10;
             
end
g=gs
'батьки'
gs(1:ps/2)
'відповідні діти'
gs(ps/2+1:ps)
%мутація
for psc=1:ps
    if rand<=pm
    'мутація!!!' 
    'мутує елемент № psc'
    psc
    em=g(psc)+10
     bitget(em,6:-1:1)
    igen=randi(6)
    gen=bitget(em,igen)
    if gen==0
        gen=1
    else
        gen=0
    end
    em=bitset(em,igen,gen)
    g(psc)=em-10
  
    end
end
%завершення
gt=g
gt(2,1:ps)=getY(g);
[minFunc(gc) imin]=min(gt(2,:))
minElem(gc)=gt(1,imin)
end
minFunc
minElem

x=-10:53;
y=getY(x);
minY=min(y)

