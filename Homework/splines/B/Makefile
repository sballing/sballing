qspline.png: qspline.pyxplot.gpi out.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs qspline.dll
	mcs $< -target:exe -reference:qspline.dll

qspline.dll: qspline.cs
	mcs $< -target:library

clean:
	rm -r *.exe *.dll out.txt *.png
