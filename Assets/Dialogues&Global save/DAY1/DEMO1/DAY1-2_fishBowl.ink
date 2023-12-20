INCLUDE ../global.ink
我：（咦？这个鱼缸明明看起来还挺不错的，这就没人要了吗？摊位都搬空了。）#profile: painter_norm
我：（这样的话，我是不是可以拿走……等等！）#profile: painter_happy
我：（这是什么？好漂亮的金鱼，它还住在里面。）#profile: painter_surprised
我：（可怜的小鱼，我也没有东西能喂你。这……我应该……）#profile: painter_depressed
+[就此离开吧] ->leave
+[我要这个鱼缸！]->want_bowl

===leave===
我：（没有更好的处理办法，还是先离开吧。）#profile: painter_norm
->DONE

===want_bowl===
我：（果然还是很想要这个鱼缸，所以……）#profile: painter_norm
+[连鱼带缸都端走]->both
+[我只要缸]->bowl_only
+[算了，离开吧]->leave

==both==
我：（带回家里养吧。）#event:getBowlFish #profile: painter_norm
->DONE

==bowl_only==
我：（我只想要缸，那么鱼该怎么办呢？）#profile: painter_eyeClosed
+[“放生”]->get_bowl
+[挪到隔壁水缸里]->get_bowl
+[算了，离开吧]->leave

==get_bowl==
我：（啊哈！好棒的鱼缸，我的了！）#event:getBowl #profile: painter_happy
->DONE

