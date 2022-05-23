all: out.txt timing.png
	cat $<

timing.png: timing_pyxplot.gpi times.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll vector.dll evd.dll
	mcs $< -reference:matrix.dll,vector.dll,evd.dll

evd.dll: evd.cs vector.dll matrix.dll
	mcs $< -target:library -reference:vector.dll,matrix.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png
