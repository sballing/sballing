all: out.txt test1.png test2.png test3.png test4.png
	cat $<

out.txt: main.exe
	mono $< > $@

test1.png: test1.pyxplot.gpi out.txt
	pyxplot $<

test2.png: test2.pyxplot.gpi out.txt
	pyxplot $<

test3.png: test3.pyxplot.gpi out.txt
	pyxplot $<

test4.png: test4.pyxplot.gpi out.txt
	pyxplot $<

main.exe: main.cs berrut.dll qspline.dll
	mcs $< -reference:berrut.dll,qspline.dll

berrut.dll: berrut.cs
	mcs $< -target:library

qspline.dll: qspline.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png
