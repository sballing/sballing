all: out.txt gamma.png
	cat out.txt

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
