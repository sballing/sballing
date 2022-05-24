all: out.txt hydrogen.png r_convergence.png acc_eps_convergence.png
	cat $<

r_convergence.png: r_convergence_pyxplot.gpi r_convergence.txt
	pyxplot $<

acc_eps_convergence.png: acc_eps_convergence_pyxplot.gpi acc_eps_convergence.txt
	pyxplot $<

hydrogen.png: hydrogen_pyxplot.gpi solution.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll vector.dll rk.dll genlist.dll
	mcs $< -reference:roots.dll,vector.dll,rk.dll,genlist.dll

roots.dll: roots.cs lineq.dll matrix.dll vector.dll
	mcs $< -target:library -reference:lineq.dll,matrix.dll,vector.dll

lineq.dll: lineq.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

rk.dll: rk.cs genlist.dll vector.dll
	mcs $< -target:library -reference:genlist.dll,vector.dll

genlist.dll: genlist.cs
	mcs $< -target:library

clean:
	rm -r *.dll *.exe *.txt *.png
