INCLUDE ../global.ink
{ lwTalk: 
    - 0:
        ~ lwTalk++
        ->first_talk
        
    - else: 
        ~ lwTalk++
        ->default
}

==default==
 ：老王<color=red>无穷</color>小卖部，每日置换上新，{lwText_CH}！#profile:hide
+[置换上新？] ->displace_renew
+[永不售空？] ->never_empty
+[知道了] -> DONE

==displace_renew==
我：哎，王大爷，这个置换上新是什么意思？#profile:painter_side
老王：哈，这就问对了！店里上货不用跟厂家联系，都是走置换！把钱换成东西，这商品直接在店里出现，肯定是没有运输时磕磕碰碰的，我给挑的款也都是最好的。#profile: laowang_pleased
我：靠置换进货……这不成了二手货了吗？#profile: painter_side
老王：什么二手货！厂家也都是这么办的，做好的商品直接置换到虚空里面，我再给换出来，瞧，崭新的！#profile: laowang_mad
我：大爷，您误会了，我没说旧货不好，我其实很喜欢…… #profile: painter_side
老王：店里可没有二手货！你瞅瞅，这标上的墨水都泛着油光呢！#profile: laowang_mad
我：……好，我知道了。#profile: painter_side
我：（王大爷清楚东西的成本，靠置换进货的心理价格就比市价低了，确实有利润。不过厂家……直接把做好的商品换成钱？#profile: painter_norm
我：（听起来，置换系统就像是一个完美无缺的中介、世界的运输中枢。）
我：（……真是，听起来越完美就越不祥。）#profile: painter_eyeClosed
老王：常来看，店里东西每天都上新啊！#profile: laowang_norm
->DONE

==never_empty==
我：呃、大爷，有没有人跟你说过，这广告牌上写的永不售空听起来有点像……滞销。#profile: painter_side
老王：……………… #profile: laowang_think
我：（完了，他不会生气了吧？我还真敢说啊。）#profile: painter_sideSweat
老王：真是没辙了，这店名叫“隔壁老王”也有人说，改成“老王∞”也有人说，现在这“永不售空”也能被挑出刺来。 #profile: laowang_mad
我：对不起！……………………对不起！#profile: painter_sideSweat
我：不过，改成“常买常新”怎么样？#profile: painter_norm
~lwText_CH = "常买常新"
~lwText_EN = "always buy, always new"
老王：哎，听着不错！就这么办了！
->DONE

==first_talk==
老王：哟，画家。#profile:laowang_norm
我：嘿，王大爷早。#profile: painter_norm
老王：今天没和<color=magenta>你那个谁</color>在一块儿啊？#profile:laowang_norm
我：嗯？……什么，谁？#profile:painter_surprised
老王：………… #bgm: fade_0.2_0 #profile: laowang_think
老王：嗐！瞧我这记性，不是你不是你，记错人了。也是，你这搞艺术的就爱独来独往的哈。#bgm:0.5_1 #profile:laowang_pleased
我：（记错人了？总觉得哪里怪怪的……就像我以前经常和谁一起出现似的。要再问问吗？） #profile: painter_side
+[您难道说8-2？]->masaka
+[您想的人是谁?]->whom
+[没什么好问的]->dont_ask

==masaka==
我：您不会是在说巴简二吧？呃，就那个红发长发满嘴跑火车的家伙。#profile: painter_side
我：（虽然我昨天才想起来他是我朋友，他也似乎很久没出现过了……但我一共也没几个朋友在这边。）
老王：八减二……红色长发……对对，我见过这小子。哈！没记错没记错，就是他！他咋样啊？#profile: laowang_think
我：……挺好的。#profile: painter_sideSweat
老王：那好！哎，我记得呢，他爱来店里转，买过好几次<color=red>小人书</color>。#profile: laowang_norm
->come_buy

==whom==
我：（不知为何，我很在意这件事。）大爷，您刚才想的那个人是谁？#profile: painter_side
老王：说了，记错人了！#profile: laowang_mad
我：（再追问一次就是我的极限了……）哎，我就是好奇，甭管是我还是哪个跟我挺像的，就说您刚才觉得我应该和谁一起出现，这个设想能再给说说吗？#profile: painter_side
老王：你这，还设想！也不知道听了要干什么。行，我想想啊。#profile: laowang_think
老王：我想想…… 
老王：想想……………… #profile: laowang_mad
老王：………………总爱来买东西的……好姑娘…… #profile: laowang_think
老王：一对儿常客。#profile: laowang_norm
老王：行，满意了不？我就想起来了一对儿常客！一个只管挑一个只管买，画家，要不也上店里来看看？#profile: laowang_pleased
->come_buy

==dont_ask==
我：（都说是认错人了，那也没什么好问的。）#profile: painter_norm
->come_buy

==come_buy==
老王：店里每天都靠置换上新，货架就在那，自己随便挑哈！#profile: laowang_norm
->DONE
