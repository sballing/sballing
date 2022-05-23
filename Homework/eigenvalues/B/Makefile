all: out.txt hydrogen.png rmax_conv.png npoints_conv.png
	cat $<

rmax_conv.png: rmax_pyxplot.gpi conv_rmax.txt
	pyxplot $<

npoints_conv.png: npoints_pyxplot.gpi conv_npoints.txt
	pyxplot $<

hydrogen.png: hydrogen_pyxplot.gpi solutions.txt analytical.txt
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
