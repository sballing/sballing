all: out.txt cspline.png
	cat $<

cspline.png: cspline.pyxplot.gpi cinterp.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs cspline.dll
	mcs $< -target:exe -reference:cspline.dll

cspline.dll: cspline.cs
	mcs $< -target:library

clean:
	rm -r *.exe *.dll *.txt *.png
