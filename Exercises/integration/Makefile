all: Out.txt gamma.png
	cat $<

gamma.png: gamma.pyxplot.gpi gamma.txt
	pyxplot gamma.pyxplot.gpi

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -target:exe -reference:matlib.dll

clean:
	rm -r *.exe [Oo]ut.txt gamma.txt *.png
