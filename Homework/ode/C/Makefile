all: out.txt
	cat out.txt
	make figure8.png

figure8.png: figure8_pyxplot.gpi solution.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs vector.dll rk.dll genlist.dll
	mcs $< -reference:vector.dll,rk.dll,genlist.dll

rk.dll: rk.cs vector.dll genlist.dll
	mcs $< -target:library -reference:vector.dll,genlist.dll

genlist.dll: genlist.cs
	mcs $< -target:library

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.png *.txt
