all: out.txt linterp.png
	cat $<

linterp.png: lspline.pyxplot.gpi linterp.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs lspline.dll
	mcs $< -target:exe -reference:lspline.dll

lspline.dll: lspline.cs
	mcs $< -target:library

clean:
	rm -r *.txt *.dll *.exe *.png
