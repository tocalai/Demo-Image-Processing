# Demo image processing

**Demo 1-1**
  * Drawing one-dimensional grating
  * Brightness of grating changed from 0-255 along with X-axis
  <img src="https://cloud.githubusercontent.com/assets/16344700/25095557/c982d74c-23ce-11e7-8721-769725b3440c.png" width="300" height="300">

**Demo 1-2**
  * Drawing two-dimensional grating
  * Brightness of grating changed from 0-255 along with X-axis and Y-axis (with Cosine wave)
  <img src="https://cloud.githubusercontent.com/assets/16344700/25095678/521c8f44-23cf-11e7-9df7-85a88ecf50c5.png" width="300" height="300">

**Demo 2-1**
  * Detect the noise pixel by pixel, using the average brightness of surrounding pixel(top, down, left, right) to determine the noise
  * Using the avergae brightness to replace the original(target) brightness if the target considerate as noise
  ![sample2](https://cloud.githubusercontent.com/assets/16344700/25113380/886989b2-2429-11e7-838d-b2757e9516ae.png "Before noise processing")[/Before processing/]
  ![smaple2-process](https://cloud.githubusercontent.com/assets/16344700/25113491/73be4e66-242a-11e7-93f7-673309461fae.png "After noise proccessing")[/After processing]

**Demo 2-2**
  * Detect the noise pixel by pixel, using the average brightness of surrounding pixel(top, down, left, right, topOfLeft, topOfRight, downOfLeft, downOfRight, itself) to determine the noise
  * Using the avergae brightness(exclude the most two higher and lower pixel) to replace the original(target) brightness if the target considerate as noise

**Pros and Corns for Demo 2-1 & 2-2**

*Refernce link*
[Cosine wave](https://willould.files.wordpress.com/2014/10/cosine-graph.jpg?w=604)
[Moiré pattern](https://en.wikipedia.org/wiki/Moir%C3%A9_pattern)
[Brightness of color RGB](http://stackoverflow.com/questions/596216/formula-to-determine-brightness-of-rgb-color)
