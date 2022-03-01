cgamma.pyxplot.png: out.cgamma.txt
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "Re($$z$$)" ;\
	set ylabel "Im($$z$$)" ;\
	set title "Complex Gamma function" ;\
	set key below ;\
	set grid ;\
	set size 8 square ;\
	plot 3d "$<" index 0 using 2:1:3 with surface col black fillcol green title "abs[$$\Gamma$$($$z$$)]" ;\
	' | tee log.pyx.gpi | pyxplot

out.cgamma.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs $< -target:exe -reference:cmath.dll

CMATHDIR = /mnt/c/Users/soere/sballing/Exercises/complex
cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

clean:
	rm -r *.png log* [Oo]ut* *.exe *.dll
