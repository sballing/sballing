all: out.txt cgamma.png
	cat $<

cgamma.png: cgamma.txt
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "Re($$z$$)" ;\
	set ylabel "Im($$z$$)" ;\
	set title "Complex Gamma function" ;\
	set key below ;\
	set grid ;\
	set size 7 square ;\
	plot 3d "$<" index 0 using 2:1:3 with surface col black fillcol green title "abs[$$\Gamma$$($$z$$)]" ;\
	' | tee log.pyx.gpi | pyxplot

out.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs $< -target:exe -reference:cmath.dll

clean:
	rm -r *.png log* *.txt *.exe
