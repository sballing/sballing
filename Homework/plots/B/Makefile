all: out.txt gamma.png lngamma.png
	cat out.txt

gamma.png: gamma.txt tab.fac.txt
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$\Gamma(x)$$" ;\
	set title "Gamma function" ;\
	set grid ;\
	set key right bottom ;\
	plot [-5:5] [-15:15] "$<" index 0 using 1:2 with lines title "$$\Gamma(x)$$",\
	"tab.fac.txt" using 1:2 with points pointtype 17 title "Tabulated data" \
	'| tee log.pyx.gpi | pyxplot

lngamma.png: lngamma.txt tab.lnfac.txt
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "ln($$\Gamma(x)$$)" ;\
	set title "Ln of the Gamma function" ;\
	set grid ;\
	set key left top ;\
	plot [0:6] "$<" index 0 using 1:2 with lines title "ln($$\Gamma(x)$$)",\
	"tab.lnfac.txt" using 1:2 with points pointtype 17 title "Tabulated data" \
	'| tee log.pyx.gpi | pyxplot

out.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $< -target:exe

clean:
	rm -r *.png log* [Oo]ut* *.exe gamma.txt lngamma.txt
