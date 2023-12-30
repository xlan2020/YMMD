INCLUDE ../global.ink
{ foodOrdered: 
{~老板娘：等会儿啊，东西马上就来！|老板娘：一会儿就好！|老板娘：这会儿也没人，随便坐吧！|老板娘：做着呢！|老板娘：海边很多<color=green>凳子</color>呢，过去坐吧！}#profile: mama_norm
-> DONE
}
{ mamaTalk: 
    - 0:
        ~ mamaTalk++
        ->first_talk
        
    - else: 
        ~ mamaTalk++
        ->talk_again
}
===first_talk===
老板娘：哟，画家呀！今天还是老样子？#profile: mama_satisfied
我：（吃点什么好呢？）#profile：painter_happy
+ [排骨砂锅(￥12)]
{ money < 12: 
我：（这里的砂锅真是一绝，加点豆芽更好……等等，我好想忘记了一件事……）#profile：painter_eyeClosed
->no_money
- else: 
我：来一份排骨砂锅饭！#addMoney: -12 #profile：painter_happy
            ->you_know_displace
}
+ [烧烤套餐(￥16)]
{ money < 16: 
我：（烧烤自选套餐看起来不错，不过……）#profile：painter_eyeClosed
->no_money
- else: 
我：来个烧烤套餐吧！我要羊肉串和茄子。#addMoney: -16 #profile：painter_happy
->you_know_displace
}
+ [我没钱了]
->no_money

===you_know_displace===
老板娘：好嘞！#profile: mama_satisfied
老板娘：这次出手很干脆啊，看来你是已经知道关于置换的事情了？#profile: mama_norm
+ [那是当然]
我：那是当然。
老板娘：（心照不宣）哈，我懂的。
->buy_food
+ [置换？]
->explain_displace

===talk_again===
老板娘：想好吃什么了吗？#profile: mama_norm
+ {money > 12} [排骨砂锅(￥12)]
我：来一份排骨砂锅饭！#addMoney: -12 #profile：painter_高兴
->buy_food
+ {money > 16} [烧烤套餐(￥16)]
我：来个烧烤套餐吧！我要羊肉串和茄子。#addMoney: -16 #profile：painter_happy
->buy_food
+ [呃……]
老板娘：去置换一两件东西吧。#profile: mama_upset
->DONE
===no_money===
我：……………… #profile：painter_side
我：……我没钱了……那个，可以给我一碗白面条吗，我、我很抱歉，明天卖出一幅画，我一定还上来。#profile: painter_sideSweat
老板娘：怎么会没钱了呢？#profile: mama_norm
我：说实话，我也不太清楚。我一觉醒来，家里就什么都没有了，钱包也是空的。#profile: painter_depressed
我：（糟糕，这番话听起来真的很不要脸。我已经落魄到这种地步了吗？）#profile: painter_sideSweat
老板娘：哦，这样啊。画家呀，你这几个月经常来，我也不是不相信你呀，给你煮碗面条也行。#profile: mama_upset 
老板娘：不过，你身上这家伙事也不少，怎么就十几块钱也掏不出来了呢？#profile: mama_upset
老板娘：白面条多难吃，你一<color=magenta> 置换 </color>，这不就有钱了吗？哎，这可怜的，我多送你个鸡蛋！#profile: mama_norm
我：……置换呀。#profile: painter_sour
我：（对了、置换……）#profile: painter_eyeClosed #unlockNote: 2_3
-> explain_displace
    
=== explain_displace ===
老板娘：怎么啦？你还像原来那搞不明白置换吗？嗐，你还真不是个年轻人了，这地方谁不置换啊？#profile: mama_upset
老板娘：这事有什么难的，心里想着，我要把手里这东西换成钱——那不就成了嘛！#profile: mama_satisfied
{ not you_know_displace: 
老板娘：置换完再来下单吧。
我：（置换的规则是——对我来说越重要的东西，价值就越高。）#profile: painter_norm
我：（当然，一个东西在人心目中的地位会变，价值也会变。大部分人，都是无法准确预估什么东西价值多少的。）
我：（不知从什么时候起，置换就成了一种人人都会的魔法，无论何时，无论何处都可以进行。）
我：（然而，作为一种快速来钱的手段，置换有着最令我厌恶的<color=magenta>代价</color>……<color=gray>消失</color>。）
}
{ you_know_displace: 
我：（哈，我真是糊涂了。该不会是连“置换”这件事情，我都不记得了吧？）
老板娘：画家，想什么呢？#profile: mama_norm
我：（糟糕，又沉浸在自己的想法里了。）没什么！抱歉。#profile：painter_side
老板娘：你这孩子！#profile:mama_satisfied
-> buy_food
}  
我：…………………… #profile：painter_eyeClosed #unlockNote: 2_4
我：（实在是拉不下脸向老板娘讨饭了，还是看看有什么东西可以置换吧。）#event: showDisplace
-> DONE
    
===buy_food===
~ foodOrdered = true
老板娘：坐那儿等着吧！东西三分钟就给你送来。#profile: mama_satisfied #event: mama_back
->DONE