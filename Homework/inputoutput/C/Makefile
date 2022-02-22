all: OutC.txt
	cat OutC.txt

OutC.txt: fileio.exe
	mono $< -input:input.txt -output:$@

fileio.exe: fileio.cs
	mcs -target:exe $<

clean:
	rm -f OutC.txt fileio.exe
