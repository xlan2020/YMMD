INCLUDE ../global.ink
我：（先排上队再说。这味道闻起来还真上头，而且似乎已经不讨厌了。）#profile: painter_eyeClosed
{diyRead: 
- false:
我：（海报上写的是什么？……boroboro刨冰创意DIY，免费参与赢大奖……点赞量第一获得置换价值高达6660元的……古董鱼骨风铃？那是什么？不管了——）#profile: painter_eyeClosed
~ diyRead = true
我：（——6660元，免费参与，创意DIY！这个活动我要参加！）#profile: painter_happy
我：（排队是正确的，一会儿问问老板吧。）
->waiting
- true: 
    ->waiting
}

==waiting==
我：（这家生意不温不火，前面倒也有一两个人。等待的时候做些什么呢？）#profile: painter_norm
+[观察菜单]->menu
+[观察摊主]->owner
+[观察排队的人]->others


==menu==
我：（看看菜单……）#event: showMenu
+[我看好了]
->my_turn

==owner==
我：（这摊主的头套……不像是工业批量生产的样子，没准是自己做的。用得已经有点旧了，脸蛋和头发脏兮兮的。）#profile: painter_norm
我：（我倒还挺喜欢这种感觉的——海藻一样缠绕的头发，结块出苍蝇腿的睫毛膏……）#profile: painter_side
我：（……都叫我怀念。）
我：（咳，总之，头套不错。虽然是常见的大眼萌妹，但就是这种脏脏的感觉还挺可爱的，嘿嘿。）#profile: painter_happy
我：（这算是夸人的话吗？咳咳。）#profile: painter_selfMock
->my_turn

==others==
我：（排队的人看起来年纪都不大。这些会来充满噱头的时尚刨冰摊买新品的小家伙们……）#profile: painter_norm
我：（暑假快结束的学生？旅游的年轻人？我在别人眼里，是不是也和他们差不多？）#profile: painter_side
我：（我该算是他们中的一员吗？）
我：（但我只是个穷画家，在这个小镇上有重要的作品必须要完成……）#profile: painter_selfMock
->my_turn

==my_turn==
我：（啊，排到我了。）#profile: painter_norm #event: hideMenu
头套人：“啵咯啵咯”鱼鱼刨~冰！你好呀，“啵咯”酱为你服务❤！#profile: boro_welcome
boro酱：想要什么样的刨冰呢？要不要试试我们本周推出的限时特价新品——深水鱼雷炸弹冰？
+{money > 18} [我要点特价新品！]//Sherry Note: 要不要菜单上有的都放到选项？
->order_new
+{money > 24} [我要点人气经典！]
->order_classic
+[那个DIY活动……]
->diy

==order_new==
我：这个新品，我要了！#profile: painter_happy #addMoney: -18
boro酱：好品味！深水鱼雷炸弹冰是海底宝藏鱼鱼冰的改良版，三种海鱼大块蘸满“啵咯”酱藏在刨冰里面，吃起来超级满足的！#profile: boro_shy
boro酱：等我一下噢…… #profile: boro_escape
 ：………
 ：……………………
boro酱：好了，你的冰！#profile: boro_glad #event: addTorpedo
boro酱：还有什么别的需要吗？#profile: boro_thinking
+[那个DIY活动……]
->diy

==order_classic==
我：（刚才酒吧附近那几个路人手里拿的好像是这个至尊海鲜什么的……）我要这个人气经典款！#profile: painter_happy #addMoney: -24
boro酱：等我一下噢…… #profile: boro_escape
 ：……… #profile: hide 
 ：…………………… #profile: hide 
boro酱：好了，你的冰！#profile: boro_glad #event: addClassic
boro酱：还有什么别的需要吗？#profile: boro_thinking
+[那个DIY活动……]
->diy

==diy==
boro酱：哦，那个呀…… #profile: boro_thinking
我：嗯，还在办吗？#profile: painter_norm
boro酱：挂了好久也没几个正经人参加，都是一些小孩子，把店铺搞得一团乱。本来今天想撤下的…… #profile: boro_awkward
我：（挂了很久吗？之前都没印象，难道是刚摆到这一片儿来的……算了，我忘记的人和事都太多了。）#profile: painter_surprised
boro酱：不过，你是画家的话，也许可以让这个活动……起死回生呢！#profile: boro_thinking
我：哎，真是不好意思…… #profile: painter_happy
我：………………嗯？（她说了“画家”？）#profile: painter_stunned #bgm: pause
我：你认得我？
boro酱：…… #profile: boro_thinking
boro酱：……………… #profile: boro_awkward
boro酱：没有哦！#profile: boro_panic #bgm: play #bgm: 戏谑
boro酱：我觉得、你看起来，你的穿着打扮像是……哎呀，不对，好像是哪个顾客提到过你……还是在别的地方……哎呀不对，我们没见过的，而且、而且我也不是那种变态跟踪狂什么的…… #profile: boro_panic
我：（她怎么有点紧张？）说来惭愧，我最近其实忘记了一些事，我没准以前来买过刨冰，没有质问你的意思。#profile: painter_selfMock
boro酱：哦哦，你来买过刨冰？是哦、哈哈，我都忘记了，你来过的，这就对了。#profile: boro_awkward
我：（本来没什么的，她这么一说，总觉得哪里很可疑。）#profile: painter_worried
boro酱：DIY、DIY！自制属于你的刨冰，这个小台面是为你准备的~ #profile: boro_welcome
boro酱：快来试试吧！#profile: boro_glad #loadScene: DAY2-3_Boro
->DONE
