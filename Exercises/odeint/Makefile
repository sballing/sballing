all: out.txt ode.png
	cat $<

ode.png: odeint.pyxplot.gpi out.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -out:main.exe -target:exe -reference:matlib.dll

clean:
	rm -r *.txt *.exe *.png
