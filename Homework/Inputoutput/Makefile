all: OutA.txt
	cat OutA.txt

OutA.txt: stdin.exe
	echo 1 2 3 4 5 | mono stdin.exe > OutA.txt

stdin.exe: stdin.cs
	mcs -target:exe stdin.cs

clean:
	rm -f OutA.txt stdin.exe
