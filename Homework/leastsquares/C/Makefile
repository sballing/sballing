all: out.txt best_fit_pm.png
	cat $<

best_fit_pm.png: lsfit_pyxplot.gpi data_points.txt best_fit_pm.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs lsfit.dll matrix.dll vector.dll
	mcs $< -reference:lsfit.dll,matrix.dll,vector.dll

lsfit.dll: lsfit.cs matrix.dll vector.dll lineq.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll,lineq.dll

lineq.dll: lineq.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png
