all: Out.txt
	cat Out.txt

Out.txt : hello.exe
		mono hello.exe > Out.txt

hello.exe : hello.cs
		mcs hello.cs

clean:
		rm -f out.txt hello.exe
