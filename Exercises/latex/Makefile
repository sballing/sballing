ms.pdf: ms.tex exp_pyxplot.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $< If I had a bibliography!

exp_pyxplot.pdf: exp.pyxplot.gpi out.exp.txt tab.exp.txt
	pyxplot $<

out.exp.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $< -target:exe

clean:
	rm -r *.pdf *.aux [Oo]ut* *.exe *.log
