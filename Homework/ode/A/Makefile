all: out.txt ode_test.png
	cat out.txt

ode_test.png: ode_pyxplot.gpi sol.txt
	pyxplot $<

out.txt: main.exe
	mono $< 1> out.txt 2> sol.txt

main.exe: main.cs vector.dll rk.dll
	mcs $< -reference:vector.dll,rk.dll

rk.dll: rk.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.png *.txt
