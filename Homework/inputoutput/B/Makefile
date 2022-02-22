all: OutB.txt
	cat OutB.txt

OutB.txt: cmdline.exe
	mono $< 1 2 3 4 5 > $@

cmdline.exe: cmdline.cs
	mcs -target:exe $<

clean:
	rm -f OutB.txt cmdline.exe
