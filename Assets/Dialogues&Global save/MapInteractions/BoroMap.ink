INCLUDE ../global.ink
boro酱：“啵咯啵咯”鱼鱼刨~冰！你好呀，“啵咯”酱为你服务❤！#profile: boro_welcome
//之后的VAR检测是否和足够的人提起boro
// - promoteBoro == 5:
boro酱：别忘了<color=green>跟五个人提起boro酱</color>，你可是答应人家了的。#profile: boro_awkward
//boro酱：你这次想要什么样的刨冰呢？#profile: boro_shy
// - else:
boro酱：你这次想要什么样的刨冰呢？#profile: boro_shy
+ [让我想想]
->order_ice
+ [算了。]
->end_order

==order_ice==
我：点什么好呢…… #profile: painter_norm
+ {money>=8} [菠萝甜甜冰！]
->order_sweet
+ {money>=18}[我要特价新品！]
->order_new
+ {money>=24}[我要人气经典！]
->order_classic
+ {money<24} [算了。]
->end_order

==order_new==
我：这个新品，我要了！#profile: painter_happy #addMoney: -18
boro酱：等我一下噢…… #profile: boro_escape
 ：……… #profile: hide 
 ：……………………
boro酱：好了，你的冰！#profile: boro_glad #event: addTorpedo
boro酱：还想要点别的什么？
+ [让我想想]
->order_ice
+ [算了。]
->end_order

==order_classic==
我：我要这个人气经典款！#profile: painter_happy #addMoney: -24
boro酱：等我一下噢…… #profile: boro_escape
 ：……… #profile: hide 
 ：……………………
boro酱：好了，你的冰！#profile: boro_glad #event: addClassic 
boro酱：还有什么别的需要吗？#profile: boro_thinking
+ [让我想想]
->order_ice
+ [算了。]
->end_order

==order_sweet==
我：来一碗这个菠萝的！#profile: painter_happy #addMoney: -8
boro酱：等我一下噢…… #profile: boro_escape
 ：……… #profile: hide 
 ：……………………
boro酱：好了，你的冰！#profile: boro_glad #event: addSweet
boro酱：还要什么别的吗？#profile: boro_thinking
+ [让我想想]
->order_ice
+ [算了。]
->end_order

==end_order==
// - promoteBoro == 5:
boro酱：那你可千万别忘了，你可是答应人家了的。<color=green>跟五个人提起boro酱</color>。#profile: boro_awkward
我：（越来越像是威胁了……）#profile: painter_mournful
//boro酱：~~要常来光顾刨冰摊哦！
// - else:
boro酱：~~一定要常来光顾刨冰摊哦！#profile: boro_glad
->DONE
