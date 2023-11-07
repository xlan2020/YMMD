INCLUDE DAY1-2_global.ink
VAR drinkTime = 0
我：（哎，真是家徒四壁啊，晚上回到这种地方，果然还是开心不起来。）
 #bgm: 房间 
我：（太空了。总觉得少了点什么，而且不止是家具这么简单。但是少了点什么呢？）
我：（我是画家。我排解空虚、探究自我的唯一办法就是——）
+[画画！]
->I_should_draw
+[不如多睡会儿]
我：（梦里什么都有吧？）
我：（……不对！我是画家，我排解空虚、探究自我的唯一办法就是——）
->I_should_draw
+[喝点小饮料]
我：（……喝一口饮料，大概还是能让自己稍稍平静下来吧。）
 ：咕咚。
我：（……不对！我是画家，我排解空虚、探究自我的唯一办法就是——）
->I_should_draw

==I_should_draw==
我：画画！把缺失的一切再次创造出来。
我：这就是我的对象——无论怎么看，都只是一枚鱼鳞。不过，摸起来是什么感觉呢？  #bgm: 柴柴 #solve: next
我：坚硬的、潮湿的，这怎么可能？它已经离开水很久却还是这么湿润……
我：我确定它是很重要的东西，我得凑近瞧瞧。#solve: next
我：……等等，那闪光是什么？我要把它<color=green>捕捉</color>到画里。#solve: next
我：我看到了……水。到处都是水。水迹濡湿我的皮肤，几乎把我挠痒了。好痒！
我：太痒了，我对水过敏吗？我得挠挠、我得抓住一个更坚硬、更锐利的东西……抓住鱼鳞。 #solve: next 
我：太痒了—— #solve: next 
我：啊！好痛，这比我想象的更尖利……我的鱼鳞呢？等等，那是什么……鱼？#solve: next
我：我的鱼鳞掉到哪里去了？我的宝物，快快回到我的手上……#solve: next
我：呵呵，在这儿呢。
我：但是手脏了，好腥，是因为那一点血吗？总之擦掉吧。#solve: next 
？？？：我已经准备好了呀，画家！#event: paintBlood
我：什么？谁在说话? 
鱼？：快<color=green>把</color><color=purple>我</color><color=green>剥</color><color=purple>掉</color>吧。快呀~ #solve: next 
我：什么……？刚才那是—— 
鱼鳞？：看得到吗？那么多、那么多，货架上和我一模一样的东西无穷无尽——哪个才是我呀？ #solve: next 
鱼鳞？：我对于画家来说，是特殊的吗？
鱼？：要把我带回家吗？
鱼？：一斤20元，不贵吧? 
鱼？：是害怕我吗？这也正常，鱼总是会跳来跳去的。那就<color=purple>把我的鳍也摘掉</color>吧，这样我就游不动了。#solve: next
鱼？：这样还不够吗？我都变成鱼肉了呀！你把我的麟刮掉，但是还不准备<color=purple>吃</color>我吗？
鱼？：不是吧，你的钱不够买一条鱼吗？那就买一片麟吧。
鱼鳞？：每天泡水，美容养生，强身健体，补肾壮阳，药效要到30天后才会失效哦！
鱼鳞？：三十天的时间，够你攒够<color=purple>下一次</color>的钱了吧？#solve: nextCanContinue
-> buy_me_scale

===buy_me_scale===
鱼鳞：买我。#choiceType: AUTO
+[无操作] -> buy_me_fish
+[真的买了] -> bought 

==buy_me_fish===
鱼：买我。 #choiceType: AUTO
+[无操作] -> buy_me_scale
+[真的买了] -> bought 

===bought===
我：我、我买……啊？#bgm: fade_5_0 #addMoney: -30
我：鳞片、鳞片还在手上。我的钱……少了。我买了什么东西？跟谁买的？鱼呢？
我：哈……真是疯了。我的房间里怎么会跑进来一条鱼向我推销自己？
我：我刚才干什么了？
+[摸了鱼] ->mo_yu
+[做了梦] ->dream

==mo_yu==
我：……没意识到的时候已经画了个美女出来，呃，这也是常有的事。
->something_wrong
==dream==
我：明明一直睁着眼睛，却像是做了一场乱梦。
->something_wrong

==something_wrong==
我：等等，好像还是有哪里不对……是<color=purple>多</color>了什么吧？ #solve: next
我：房间里本来没有这杯水的。
我：这是……<color=magenta>置换</color>！我刚才置换了。#bgm: 紧张 #bgm: fade_2_1
我：一杯水。哈哈……我、我用刚赚来的钱，就买了这么一杯水？
我：我该做什么，把它供起来，把它喝了？喉咙好痛、头好晕……但是——
我：我好像知道自己为什么需要这杯水了。
“模特”：画家，我该喝水啦！
“画家”：我们应该再亲密一点。
“画家”：我对你的感受还不够深刻。
“画家”：只凭浅薄的视觉，怎么可能创作出好的画作？
“画家”：聆听、触摸、轻嗅、品尝……
“画家”：新鲜的鱼生尝起来像舌头一样。
“画家”：但这对我来说太昂贵了。
“画家”：尝一尝<color=purple>鳞片的味道</color>…… #bgm: fade_4_0.3 #solve: next
我：……就当是见到你了。 #bgm: fade_2_1
->scale_in_water

==scale_in_water==
 ：……
 ：………………
 ：鳞片水泡好了。#choiceType: BUTTON
+ [喝一口] ->water_lessen


==water_lessen==
 ：鳞片水少了一点。 #event: drinkWater
{ drinkTime: 
    - 6:
        ->done_drinking
    - else: 
        ~ drinkTime++
        +[喝一口]
        ->water_lessen
}

==done_drinking==
 ：杯子空了。#bgm: fade_4_0
我：我的模特 #typingSpeed: 1
我：我的对象
我：她是  一个  美 人 鱼 。
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