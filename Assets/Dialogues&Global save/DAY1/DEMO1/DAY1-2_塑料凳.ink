INCLUDE DAY1-2_global.ink
{ not foodOrdered: 
{~我：（先找老板娘点单再坐下吧。）|我：（随处可见的塑料凳，半新不旧的。）}#profile: painter_norm
->DONE
}
我：（那就先坐下等等吧。）#profile: painter_happy
我：……#profile: painter_norm
我：………………#profile: painter_noComment
我：（一个人等餐，都像我这样干坐着吗？）#profile: painter_eyeClosed
我：（以前是怎么做的呢？我也有过一部手机吗？还是说，有哪个人在我身边……）
我：（还是看看远处吧。海上的落日，呵呵……我也是为了美景才搬到这里来的。）#profile: painter_side
我：……
我：………… #event: 8-2_appearOnce #bgm:pause
我：………………嗯？#profile: painter_sideSweat
我：（是我眼花了吗？）
我：………………嗯？？#event: 8-2_blink #profile: painter_stunned #bgm:悬疑
我：（哪里冒出来的变态……眼睛好痛……不、头也好痛……对了！）
我：（好像想起了一件要紧事，今天是……星期三！）#profile: painter_frightened
我：（8月28日……星期三。我有个朋友，我们说好了，他会……他会……）
我：（不对，现在不是想这种事情的时候——）#profile: painter_alert
我：（那东西要过来了！）#profile: painter_frightened #event: 8-2_walkCloser
我：喂！#profile: painter_surprised
？？？：画~~~家~~~！#profile: 8-2_smile #bgm:戏谑
我：……哈？#profile: painter_alert
？？？：果然，又认不出我了吗？#profile: 8-2_upset
？？？：你的冷漠真是令我心如刀割啊。#profile: 8-2_upset
？？？：我是你的老朋友巴简二啊！#profile: 8-2_smile
我：（8-2？6。）大哥，你认错人了吧？#profile: painter_sideSweat
8-2：*一拍手*大哥！嘿，这我可爱听。你终于准备加入我的七分之一兄弟会了吗？#event: 8-2_stayDressed #profile: 8-2_smile
我：什么……兄弟会？#profile: painter_side
我：（等等！他是什么时候把衣服穿上的？）#profile: painter_sideSweat
8-2：哎呀，我知道你现在一定有很多问题。这也难免啦，没关系，过一会儿你就懂了。#profile: 8-2_smile
8-2：画家！先来给我画幅画吧！
我：啊？你……让我先缓缓。#profile: painter_side
8-2：嗯嗯。一二三，四五六，七八九十缓好了吗？画吧！#profile: 8-2_smile
我：（这是在唱哪一出啊，头好痛……）我的画材都没了。#profile: painter_noComment
8-2：都没了？#profile: 8-2_upset
我：没错，我现在一无所有。所以也画不了了，呵呵。#profile: painter_sideSweat
8-2：真的假的？让我看看——#profile: 8-2_smile
我：喂！你干什么！#profile: painter_angry
我：别动我的画箱—— #profile: painter_mad
->DONE
# 要研究确定一下收集物品这里是不是真的在地图里进行，还是说已经有画画的UI了，在UI里发现要填画材的地方没有东西，然后再捡？但是这样不会又折回去了吗？总之再想想吧。