all: OutA.txt
	cat OutA.txt

OutA.txt: stdin.exe
	echo 1 2 3 4 5 | mono $< > $@

stdin.exe: stdin.cs
	mcs -target:exe $<

clean:
	rm -f OutA.txt stdin.exe
