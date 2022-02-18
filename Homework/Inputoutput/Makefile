all: OutA.txt OutB.txt OutC.txt
	cat OutA.txt OutB.txt OutC.txt

OutA.txt: stdin.exe
	echo 1 2 3 4 5 | mono $< > $@

OutB.txt: cmdline.exe
	mono $< 1 2 3 4 5 > $@

OutC.txt: fileio.exe
	mono $< -input:input.txt -output:$@

stdin.exe: stdin.cs
	mcs -target:exe $<

cmdline.exe: cmdline.cs
	mcs -target:exe $<

fileio.exe: fileio.cs
	mcs -target:exe $<

clean:
	rm -f OutA.txt OutB.txt OutC.txt stdin.exe cmdline.exe fileio.exe
