all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs mcint.dll vector.dll
	mcs $< -target:exe -reference:mcint.dll,vector.dll

mcint.dll: mcint.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt
