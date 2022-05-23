all: Out.txt erf.png
	cat $<

erf.png: erf.pyxplot.gpi erf.txt
	pyxplot erf.pyxplot.gpi

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -target:exe -reference:matlib.dll

clean:
	rm -r *.exe [Oo]ut.txt gamma.txt *.png
