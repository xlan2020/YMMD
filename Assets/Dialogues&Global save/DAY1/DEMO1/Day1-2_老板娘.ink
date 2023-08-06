INCLUDE DAY1-2_global.ink
{ mamaTalk: 
    - 0:
        ~ mamaTalk++
        ->first_talk
        
    - else: 
        ~ mamaTalk++
        ->talk_again
}

===first_talk===
    老板娘：哟，画家呀！今天还是老样子？#profile: mama_满意
    我：（吃点什么好呢？）#profile：painter_高兴
        + [排骨砂锅(￥12)]
        { money < 12: 
            我：（这里的砂锅真是一绝，加点豆芽更好……等等，我好想忘记了一件事……）#profile：painter_半闭眼 
            ->no_money
        - else: 
            我：来一份排骨砂锅饭！
            ->buy_food
        }
        + [羊肉串(￥8)]
        { money < 8: 
            我：（烧烤自选套餐看起来不错，不过……）#profile：painter_半闭眼
            ->no_money
        - else: 
            我：来一盘羊肉串吧！
            ->buy_food
        }
        + [我没钱了]
        ->no_money

===talk_again===
    老板娘：想好吃什么了吗？#profile: mama_满意
    老板娘：去置换一两件东西吧。#profile: mama_不爽
->DONE
===no_money===
    我：……………… #profile：painter_侧
    我：……我没钱了……那个，可以给我一晚白面条吗，我、我很抱歉，明天卖出一幅画，我一定还上来。#profile: painter_侧流汗
    老板娘：怎么会没钱了呢？#profile: mama_正常
    我：说实话，我也不太清楚。我一觉醒来，家里就什么都没有了，钱包也是空的。#profile:painter_沮丧
    我：（糟糕，这番话听起来真的很不要脸。我已经落魄到这种地步了吗？）#profile: painter_侧流汗
    老板娘：哦，这样啊。画家呀，你这几个月经常来，我也不是不相信你呀，给你煮碗面条也行。#profile: mama_不爽
    老板娘：不过，你身上这家伙事也不少，怎么就十几块钱也掏不出来了呢？#profile: mama_不爽
    老板娘：白面条多难吃，你一置换，这不就有钱了吗？哎，这可怜的，我多送你个鸡蛋！#profile: mama_正常
    我：……置换呀。#profile: painter_古怪
    我：（对了、置换……）#profile: painter_半闭眼 #unlockNote: 2_3_置换 
    老板娘：怎么啦？你还像原来那样不爱置换吗？嗐，你还真不是个年轻人了，这地方谁不置换啊？#profile: mama_不爽
    老板娘：这事有什么难的，心里想着，我要把手里这东西换成钱——那不就成了嘛！#profile: mama_满意
    老板娘：置换完再来下单吧。
    我：（置换的规则是——对我来说越重要的东西，价值就越高。）#profile: painter_正常
    我：（当然，一个东西在人心目中的地位会变，价值也会变。大部分人，都是无法准确预估什么东西价值多少的。）
    我：（实在是拉不下脸向老板娘讨饭了，还是看看有什么东西可以置换吧。）
    -> DONE
    
===buy_food===
    老板娘：（眉开眼笑）好嘞！坐那椅子上等会啊，三分钟就给你送来！#profile: mama_满意
    ->DONE
    
===finish_displace===
我：（这就算是完成了？是了，我现在有钱了。）
我：（等等，我刚才换走了什么东西来着？）
我：（……我果然很讨厌这种感觉。被置换的东西就会彻底从世界上消失，连存在过的概念都被人遗忘，没人能想得起来那是什么。）#unlockNote: 3_1_消失
我：（现在去找老板娘买晚饭吧。）
->DONE
->END

