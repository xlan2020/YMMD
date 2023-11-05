INCLUDE DAY1-2_global.ink
我：...So here I'm in this empty room. Nothing but a table and a mattress. #bgm: 房间 
我：It doesn't feel so good to call somewhere like this home. 
我：Everything has been displaced... but this mysterious fish scale. Oh, great, now I've still got 8-2' overstocking shitty book with me. 
我：So empty. As if something has been missing. It's not just the furniture but something more... complex and import. But what could that be? 
我：Maybe-maybe 8-2 doesn't trick me this time. If a portrait of accuracy could be sufficient to displace something for money, then could I...
我：...displace something back from the void, through another portrait of accuracy? 
我：Maybe I can figure it out. Maybe I could recall what had happened on me. 
我：Then I could escape from this hollow. 
我：I'm a painter. The only way to figure out the truth is to - DRAW what has been missing! 
我：So this is my subject. No matter how I see it it's nothing but a plain fish scale. How would it feels to have it in hand?  #bgm: 柴柴 #solve: next
我：...strong, and...wet. How can it be? It has left the water for this long and it's still...
我：I'm sure it's something important. I'd take a closer look. #solve: next
我：...Wait, what was that glow? #solve: next
我：I see... water. Water coming out from somewhere, traces damping my skin that almost tickles me. Itchy...! 
我：So itchy that I want to scratch. I want to hold something firmly. This fish scale in my hand - #solve: next 
我：Feel it - #solve: next 
我：Ouch! That's sharper than I've... Where is it... Wait, what is that? #solve: next
我：Where did my scale dropped... My precious...  #solve: next
我：Here it is. 
我：但是手脏了，好腥，是因为那一点血吗？总之擦掉吧。  #solve: next
？？？：我已经准备好了呀，画家！
我：什么？谁在说话? 
鱼？：快<color=green>把</color><color=purple>我</color><color=green>剥</color><color=purple>掉</color>吧。快呀~ #solve: next 
我：什么……？刚才那是—— 
鱼鳞？：看到了吗？那么多一样的东西，哪个才是我？ #solve: next 
鱼鳞？：我对于画家来说，是特殊的吗？
鱼？：要把我带回家吗？
鱼？：一斤20元，不贵吧? #solve: next
鱼？：咦，不打算吗。可是我都变成鱼肉了呀。你把我的麟刮掉，但是还不准备吃我吗？
鱼？：不是吧，你的钱不够买一条鱼吗？那就买一片麟吧。
鱼鳞？：每天泡水，美容养生，强身健体，补肾壮阳，药效要到30天后才会失效哦！
鱼鳞？：三十天的时间，够你攒够下一次的钱了吧 
-> buy_me

===buy_me===
鱼鳞：买我。
鱼：买我。 #choiceType: SOLVE_OR_LOOP
+[ ] 
-> buy_me 
+[ ] 
-> bought 

===bought===
->DONE

（鼠标被迫移动打开背包）
欧耶! 谢谢谢谢，谢谢老板。 
……
不过画家对我来说，并不是特殊的。
还有很多人在等我。
天黑了。时间到了。
我 该 走 了 。
啊
……
Thank you for playing we code and code and code, day and night, and it's not done yet. #speaker: Hello  #speakerMode: norms
-> END