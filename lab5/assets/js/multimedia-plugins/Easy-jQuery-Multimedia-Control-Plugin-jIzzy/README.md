jIzzy
=====

A jQuery Plugin geared towards making programmers even more lazy.

###How To Use

Using jIzzy is very simple.

```
<script src="jquery.min.js"></script>
<script src="jquery.jizzy.js"></script>
<script src="yourjavascript.js"></script>
```

###What it can do (as of now)

Cycle through changing CSS aspects of elements.

```
// cycleColor function generic

$('thing').cycleColors('cssProperty',['HEXVALUE','HEXVALUE','HEXVALUE'], milliseconds);

// Example

$('#titleBanner').cycleColors('color',['#ff6347','#ffff00','#ee82ee'],500);
```

Turn a div into an ```<audio>``` object.

```
// musicify() function generic

$('thing').musicify('file', options);

// Example

$('#musicDiv').musicify('musicfile.mp3', {controls:"true",autoplay:"true",loop:"false"});
```

###Contribute

Right now jIzzy is very small. If you would like to contribute please make a fork and supply your code.
