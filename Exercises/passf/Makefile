all: Out.txt
	cat Out.txt

Out.txt: passf.exe
	mono $< > $@

passf.exe: passf.cs
	mcs -target:exe $<

clean:
	rm -r *.exe [Ou]ut.txt
