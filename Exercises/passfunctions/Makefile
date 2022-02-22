all: Out.txt
	cat Out.txt

Out.txt: passfunctions.exe
	mono $< > $@

passfunctions.exe: passfunctions.cs
	mcs -target:exe $<

clean:
	rm -r *.exe [Ou]ut.txt
