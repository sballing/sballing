all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > $@

main.exe: main.cs integrator.dll python_res.txt
	mcs $< -reference:integrator.dll

python_res.txt: python_test.py
	python3 $< > $@

integrator.dll: integrator.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt
