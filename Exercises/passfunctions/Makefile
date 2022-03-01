all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs passf.dll
	mcs -target:exe -out:$@ -reference:passf.dll $<

passf.dll: passf.cs
	mcs $< -target:library -out:passf.dll

clean:
	rm -r *.exe *.dll [Ou]ut.txt
