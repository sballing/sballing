linterp.png: linterp.gpi out.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs lspline.dll
	mcs $< -target:exe -reference:lspline.dll

lspline.dll: lspline.cs
	mcs $< -target:library

clean:
	rm -r out.txt *.dll *.exe *.png
