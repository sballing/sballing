all: out.txt
	cat out.txt
	make gamma.png

gamma.png: gamma_pyxplot.gpi gamma.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs integrator.dll
	mcs $< -reference:integrator.dll

integrator.dll: integrator.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe out.txt gamma.txt *.png
