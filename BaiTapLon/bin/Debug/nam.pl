ask:- write('là độg vật máu nóng'),nl,read(X),mauNong(X).

mauNong(co):-write('Da có vảy không'),nl,read(X),daCoVay(X).
daCoVay(co):-write('Có nhảy không'),nl,read(X),nhay(X).
nhay(co):-write('Là con ếch').
nhay(khong):-write('Là con kì nhông').
