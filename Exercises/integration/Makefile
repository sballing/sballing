all: Out_int.txt gamma.png
	cat $<

gamma.png: gamma.pyxplot.gpi Out_gamma.txt
	pyxplot gamma.pyxplot.gpi

Out_int.txt: main_int.exe
	mono $< > $@

Out_gamma.txt: main_gamma.exe
	mono $< > $@

main_gamma.exe: main_gamma.cs matlib.dll
	mcs $< -out:main_gamma.exe -target:exe -reference:matlib.dll

main_int.exe: main_int.cs matlib.dll
	mcs $< -out:main_int.exe -target:exe -reference:matlib.dll

clean:
	rm -r *.exe *.txt *.png
