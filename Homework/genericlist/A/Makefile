all: Out.txt
	cat $<

Out.txt: main.exe input.txt
	mono $< > $@ input.txt

main.exe: main.cs genlist.dll
	mcs $< -target:exe -out:$@ -reference:genlist.dll

genlist.dll: genlist.cs
	mcs $< -target:library -out:$@

clean:
	rm -r *.dll *.exe [Oo]ut*
