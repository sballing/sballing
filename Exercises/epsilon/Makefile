all: Out.txt
	cat $< 

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -f Out.txt main.exe
