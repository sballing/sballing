all: out.txt interpolation.png
	cat $<

out.txt: main.exe
	mono $< > $@

interpolation.png: ann_pyxplot.gpi out.txt toPlot.txt
	pyxplot $<

main.exe: main.cs ann.dll mini.dll matrix.dll vector.dll
	mcs $< -reference:ann.dll,mini.dll,matrix.dll,vector.dll

ann.dll: ann.cs mini.dll matrix.dll vector.dll
	mcs $< -target:library -reference:mini.dll,matrix.dll,vector.dll

mini.dll: mini.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png
