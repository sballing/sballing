## Examination project 2 - Berrut interpolation

**Author**:   
Søren Skovgaard Balling

**Student number**:   
201807548 $\rightarrow$ 48 \% 23 = 2

**AU-mail**:    
201807548@post.au.dk

**Project description**:   
The overall purpose of this examination project was to implement a particular rational function interpolation algorithm, namely the Berrut B1 algorithm. This was done according to the information given in the note "interpolation.pdf", and in particular equation 38 has been used. The advantage of rational interpolants is that they (in general) are less prone to the Runge phenomenon, i.e. a wiggly interpolant when using polynomial interpolation over a set of equispaced interpolation points. As such, one should expect to see that the Runge phenomenon is reduced through the Berrut B1 interpolation algorithm.    

As mentioned, equation 38 of the note gives an expression for the function, which interpolates a given function between some points on the $$x$$-axis. Furthermore, this expression can be proven to have no poles on the real axis (Berrut 1988). This expression consists of sums introcing a varying sign on the weights, i.e. the $$(-1)^i$$ factors. However in this implementation, the end points (i.e. for $$i=0$$ and $$i=n$$) have been modified, such that they are scaled by a factor of $$1/2$$, such that they become $$1/2 \cdot (-1)^i$$, according to information given in the litterature (Salzer 1972). This turns out to be a rather important distinction from the note.    

The implemented Berrut interpolation algorithm has been tested for 4 sets of data points, all of which being prone to Runge phenomenon in general. The Berrut interpolation has then been compared to the qspline (quadratic spline) interpolation as implemented in the homework. The final results (i.e. the Berrut interpolation and qspline interpolation) can be seen in figures "test1.png", "test2.png", "test3.png" and "test4.png". One can clearly see that the interpolants are less wiggly for the Berrut implementation, when compared to the qspline interpolation, which indeed was the initial expectation.

**Self-evaluation**:    
Overall, this examination project was a succes. The Berrut B1 interpolation algorithm was implemented and yielded good results when interpolating data points prone to Runge phenomenon. Furthermore, the algorithm was compared to the qspline algorithm, which was not a part of the problem formulation. 