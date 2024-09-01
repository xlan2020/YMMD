莉莉：我是调酒师……咦，画家，又见面了。今天想喝点什么？
+ [有什么推荐吗？] -> AttributeQuestion
+ [算了] -> ShowResult.toEnd

=== AttributeQuestion ===
我：给我推荐点什么吧？
莉莉：没问题。还是老样子，我想先从几个问题开始。
我：我已经迫不及待了。
~ temp questionIndex = RANDOM(0, 5)
{
- questionIndex == 0:
    莉莉：首先，你更喜欢现代生活，还是对神话时代的故事情有独钟？
    + [现代] -> Select("Modern")
    + [神话] -> Select("Mythology")

- questionIndex == 1:
    莉莉：首先，如果可以生活在任何地方，你会选择海上还是陆地？
    + [海洋] -> Select("Sea")
    + [陆地] -> Select("Land")
    
- questionIndex == 2:
    莉莉：首先，你更想体验冰冷的寒意，还是感受炽热的热情？
    + [冰冷] -> Select("Cold")
    + [炽热] -> Select("Hot")
    
- questionIndex == 3:
    莉莉：首先，有些人喜欢自然，也有人觉得人造带来了真正的自由，你属于哪种？
    + [自然] -> Select("Nature")
    + [人造] -> Select("Artificial")
    
- questionIndex == 4:
    莉莉：首先，你更倾向脚踏实地、关注现实，还是更偏爱沉浸在梦境和幻想中？
    + [现实] -> Select("Reality")
    + [梦境] -> Select("Dream")
    
- else:                        莉莉：首先，你今天希望纵情迷失于未知的奇遇里，还是想要寻觅熟悉和安全、踏上归途？
    + [迷失] -> Select("Lost")
    + [回归] -> Select("Return")

}

=== Select(choice) ===
莉莉：{~嗯，听起来不错。|很好的选择。|我完全理解。} #event: 
//通过event call wineselectmanager的HandleWine(choice)？
->AskNextQuestion

=== AskNextQuestion ===
~temp flavorQuestion = RANDOM(1, 3)// 从C#读取nextQuestion的值
{
- flavorQuestion == 1:
    莉莉：你想喝偏甜一点的口味，还是偏干一点？
    + [甜] -> Select("Sweet")
    + [干] -> Select("Dry")

- flavorQuestion == 2:
    莉莉：你想来杯清爽点的，还是浓郁点的？
    + [清] -> Select("Light")
    + [浊] -> Select("Rich")

- flavorQuestion == 3:
    莉莉：成熟的果或是盛放的花，你更喜欢哪种？
    + [果] -> Select("Fruit")
    + [花] -> Select("Flower")
}

=== ShowResult ===
selectedWine = //从C#获取selectedWine
temp wineDescription = {selectedWine}.wineDescription //已经写了，这个能做吗？
temp wineCritique = {selectedWine}.wineCritique //还没有写，不好做的话就算了
temp winePrice = {selectedWine}.winePrice //酒都一个价格的话也可以不要

莉莉：我明白了，我明白了……我已经找到了，今晚属于你的酒是【{selectedWine}】。
莉莉：{wineDescription}
莉莉：专为画家调制，双份酒精。怎么样，尝一口试试看？
我：……哇。
我：{wineCritique}
莉莉：你喜欢就是最好的。这杯算你常客优惠，{winePrice}元。
莉莉：要再来一杯吗？
+ [喝！] -> toAgain //不知道这个做起来方不方便，不方便就不要了
+ [算了] -> toEnd

= toAgain
我：那必须的！
-> AttributeQuestion

= toEnd
我：谢谢你，还是算了。
莉莉：诶，真是遗憾呢。
莉莉：改天一定要再来呀。回去的路上注意安全！
-> END


/*
=== DSS ===
= wineDescription
“冰凉的、漆黑的、深不⻅底的。”以金酒作为基酒，调入红茶、柠檬，深海特调的口感清冽而奇异。来自深海的鱿鱼墨汁和稀有的人鱼泪不仅造就了它视觉上的冲击力，同时也让酒体呈现粘稠、鲜咸的口感。

= wineCritique
巴拉巴拉

= winePrice
65

=== HMM ===
= wineDescription
“炽热而无法驯服，奂⻔人的精神客厅。”这款由热麻麻餐厅赞助的鸡尾酒以波本作为基酒，主打麻辣口味，酒体呈火焰一般的橘红色。鲜姜、花椒碎、小米辣的三种辣味完美地与利口酒的甜调和在一起，再辅以热麻麻精品苹果醋解腻，可谓色香味俱全。

= wineCritique
巴拉巴拉

= winePrice
85

=== WB ===
= wineDescription
“一条腿的女巫住在⻓着⻦类脚爪的森林木屋里，引诱迷途的孩子。”这款味道非同寻常的鸡尾酒的灵感来自东欧的芭芭雅嘎的传说，她拥有超然的力量，通常乘坐一只大铁锅在空中飞行。龙舌兰和接骨木花利口酒的混合提高了它的酒精度数，但却使它很好入口。打发的鸡蛋清给了它一种绵密的口感，再配上茴香，仿佛女巫在熬煮的奇异草药汤。

= wineCritique
巴拉巴拉

= winePrice
85

=== SS ===
= wineDescription
"她的诡异旋律散在海⻛中。”这款酒就像塞壬的歌声一样诱人。以柔润的银朗姆作为基酒，注入海妖之歌的精髓；刚入口时，荔枝利口酒和木槿糖浆会给你一种甜丝丝的错觉，而随后则是强烈的酒精感。杯口的海盐更是为它提供了丰富的口感和层次。

= wineCritique
巴拉巴拉

= winePrice
75

=== SAND ===
= wineDescription
“她游荡于沙漠，使旅人沉入永恒的梦境。”这款由砂女的传说作为灵感的鸡尾酒，像沙漠的风一样厚重、凝练、无孔不入。藏红花白兰地、洋甘菊利口酒的混合给了它一种酸酸甜甜的异域风情，调入菠萝汁和椰奶则平衡了洋甘菊轻微的苦涩感。可使用金粉悬浮在酒体中，仿佛砂女化作的沙之风暴。

= wineCritique
巴拉巴拉

= winePrice
75

= TS
= wineDescription
“为炎热夏日带来神秘的清爽感，隐藏着秘密与魔法。”这款夏季特调最适合今天这样炎热的天气，以口感纯净的伏特加作为基酒，喝起来就像清爽的薄荷蓝莓气泡水，非常好入口。不同于其他小甜水儿，它后调里微微苦涩的薰衣草香为它增添了丰富的层次。

= wineCritique
巴拉巴拉

= winePrice
55
