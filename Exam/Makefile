all: out.txt berrut.png qspline.png
	cat $<

out.txt: main.exe
	mono $< > $@

berrut.png: berrut.pyxplot.gpi out.txt
	pyxplot $<

qspline.png: qspline.pyxplot.gpi out.txt
	pyxplot $<

main.exe: main.cs berrut.dll qspline.dll
	mcs $< -reference:berrut.dll,qspline.dll

berrut.dll: berrut.cs
	mcs $< -target:library

qspline.dll: qspline.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png
