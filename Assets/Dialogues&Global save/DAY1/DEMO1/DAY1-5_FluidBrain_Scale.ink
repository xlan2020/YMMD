INCLUDE global.ink
VAR drinkTime = 0
我：哎，真是家徒四壁啊，晚上回到这种地方，果然还是开心不起来。#profile: painter_eyeClosed
 #bgm: 房间 
我：太空了。总觉得少了点什么，而且不止是家具这么简单。但是少了点什么呢？#profile: painter_mournful
我：我是画家。我排解空虚、探究自我的唯一办法就是——#profile: painter_alert #choiceType: BUTTON
+[画画！]
->I_should_draw
+[不如多睡会儿]
我：梦里什么都有吧？#profile: painter_sour
我：……不对！我是画家，我排解空虚、探究自我的唯一办法就是—— #profile: painter_alert
->I_should_draw
+[喝点小饮料]
我：……喝一口饮料，大概还是能让自己稍稍平静下来吧。#profile: painter_sour
 ：咕咚。
我：……不对！我是画家，我排解空虚、探究自我的唯一办法就是—— #profile: painter_alert
->I_should_draw

==I_should_draw==
我：画画！把缺失的一切再次创造出来。
我：这就是我的对象——无论怎么看，都只是一枚<color=green>鱼鳞</color>。不过，<color=green>摸</color>起来是什么感觉呢？  #bgm: 柴柴 #solve: next #profile: painter_side
我：坚硬的、潮湿的，这怎么可能？它已经离开水很久却还是这么湿润……
我：我确定它是很重要的东西。明明是小小的一个……
我：我得再凑近点瞧瞧。#event: closer 
我：等等，那闪光是什么？我要把它<color=green>捕捉</color>到画里。 #solve: next #profile: painter_alert
我：我看到了……水。到处都是水。水迹濡湿我的皮肤，几乎把我挠痒了。好痒！我难道对水过敏吗？#profile: painter_stunned
我：用手挠还不够，我得抓住一个更坚硬、更锐利的东西……
我：……鳞片。#event: largeScale
我：太痒了！我得<color=green>挠挠</color>—— #solve: next 
我：啊！疼！这比我想象的更尖利……我的鳞片呢？等等，那是什么……<color=green>鱼</color>？#solve: next #profile: painter_concerned
我：<color=green>鳞片</color>掉到哪里去了？我的宝儿，快回到我<color=green>手上</color>……#solve: next #profile: painter_frightened
我：呵呵，在这儿呢。#profile: painter_happy
我：但是手脏了，好腥，是因为那一点血吗？总之擦掉吧。#solve: next #profile: painter_norm
？？？：我已经准备好了呀，画家！#event: paintBlood #profile: hide
我：什么？谁在说话? #profile: painter_side
鱼？：快<color=green>把</color><color=purple>我</color><color=green>剥</color><color=purple>掉</color>吧。快呀~ #solve: next #profile: hide
我：什么……？刚才那是—— #profile: painter_frightened
鱼鳞？：看得到吗？那么多、那么多，货架上和我一模一样的东西无穷无尽——哪个才是我呀？#profile: hide
鱼鳞？：我对于画家来说，是特殊的吗？#event: zoomInTexture
鱼？：要把我带回家吗？
鱼？：一斤20元，不贵吧? 
鱼？：是害怕我吗？这也正常，鱼总是会跳来跳去的。那就<color=purple>把我的鳍也摘掉</color>吧，这样我就游不动了。#solve: next
鱼？：这样还不够吗？我都变成鱼肉了呀！你把我的麟刮掉，但是还不准备<color=purple>吃</color>我吗？
鱼？：不是吧，你的钱不够买一条鱼吗？那就买一片麟吧。
鱼鳞？：每天泡水，美容养生，强身健体，补肾壮阳，药效要到30天后才会失效哦！
鱼鳞？：三十天的时间，够你攒够<color=purple>下一次</color>的钱了吧？#solve: nextCanContinue #event: customizeButton
-> buy_me_scale

VAR buy_me_count = 0
===buy_me_scale===
鱼鳞：买我。#choiceType: AUTO
{ buy_me_count:
    - 5:
        ~ buy_me_count = 0
        +[无操作] -> buy_me_hint
        +[真的买了] -> bought 
    - else: 
        ~ buy_me_count++
        +[无操作] -> buy_me_scale
        +[真的买了] -> bought 
}

===buy_me_fish===
鱼：买我。 #choiceType: AUTO
{ buy_me_count:
    - 5:
        ~ buy_me_count = 0
        +[无操作] -> buy_me_hint
        +[真的买了] -> bought 
    - else: 
        ~ buy_me_count++
        +[无操作] -> buy_me_scale
        +[真的买了] -> bought 
}

===buy_me_hint===
我：我的鱼，我要买……<color=green>现金</color>在哪？ #choiceType: AUTO
+[无操作] -> buy_me_scale
+[真的买了] -> bought 

===bought===
我：我、我买……啊？#bgm: fade_5_0 #addMoney: -30 #profile: painter_stunned #choiceType: BUTTON
我：鳞片、鳞片还在手上。我的钱……少了。我买了什么东西？跟谁买的？鱼呢？#profile: painter_surprised
我：哈……真是疯了。我的房间里怎么会跑进来一条鱼向我推销自己？#profile: painter_sideSweat
我：我刚才干什么了？#profile: painter_side #choiceType: BUTTON
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
我：刚才明明是没有这杯水的。
我：可它就这么出现了，感觉上这么熟悉，就好像本来就属于这个房间一样，怎么会…… 
我：这是……<color=magenta>置换</color>！我刚才置换了。#bgm: 紧张 #bgm: fade_2_1 #profile: painter_stunned
我：一杯水。哈哈……我、我用刚赚来的钱，就买了这么一杯水？#profile: painter_concerned
我：我该做什么，把它供起来，把它喝了？喉咙好痛、头好晕……但是——#profile: painter_selfMock
我：我好像知道自己为什么需要这杯水了。#profile: painter_eyeClosed
“模特”：画家，休息休息，我该喝水啦！#profile: hide
 ：“画家”沉浸在自己的思绪里。
“画家”：这幅画的感觉不对……不够亲密、不够深刻。
“画家”：只凭肤浅的视觉，怎么可能创作出好的画作？
“画家”：聆听、触摸、轻嗅、品尝……
“画家”：新鲜的鱼生尝起来像舌头一样。
“画家”：但这对我来说太昂贵了。
“画家”：尝一尝<color=purple>鳞片的味道</color>…… #bgm: fade_4_0.3 #solve: next
我：……就当是见到你了。 #bgm: fade_2_1 #profile: painter_depressed
->scale_in_water

==scale_in_water==
 ：…… #profile: hide
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
我：我的模特 #typingSpeed: 1 #profile: painter_depressed
我：我的对象
我：她是  一个  美 人 鱼 。
我：我的 美人鱼…… #typingSpeed: 0.5 #loadScene: DAY1-6_DFD
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