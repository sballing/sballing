timing.png: timing_pyxplot.gpi out.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs lineq.dll matrix.dll vector.dll
	mcs $< -reference:lineq.dll,matrix.dll,vector.dll

lineq.dll: lineq.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png
