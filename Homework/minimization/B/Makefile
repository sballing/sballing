all: out.txt higgs.png
	cat $<

higgs.png: higgs_pyxplot.gpi out.txt data.txt
	pyxplot $<

out.txt: main.exe data.txt
	mono $< > $@

main.exe: main.cs mini.dll matrix.dll vector.dll data.txt
	mcs $< -reference:mini.dll,matrix.dll,vector.dll

mini.dll: mini.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe out.txt fit.txt *.png
