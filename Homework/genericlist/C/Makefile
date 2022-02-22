all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs genlist.dll
	mcs $< -reference:genlist.dll -target:exe -out:$@

genlist.dll: genlist.cs node.cs
	mcs $^ -target:library -out:$@

clean:
	rm -r *.dll *.exe [Ou]ut*
