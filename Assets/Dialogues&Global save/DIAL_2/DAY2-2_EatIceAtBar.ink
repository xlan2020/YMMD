INCLUDE ../global.ink
{ iceEatTalk: 
    - 0:
        ~ iceEatTalk++
        ->first_talk
        
    - else: 
        ~ iceEatTalk++
        ->eating
}

==eating==
路人乙：……咔嚓……吸溜吸溜……吧吱吧吱……哈……#profile: mobB_norm
->DONE

==first_talk==
路人甲：居然味道不错！#profile: mobA_norm
路人乙：就像臭豆腐一样，闻着恶心但吃起来……咔嚓……吸溜吸溜……吧吱吧吱……哈……#profile:mobB_norm
我：（天，他吃得好香！！）#profile: painter_surprised
我：（酒吧还没有开门，他们吃的东西来自别的地方。这是……呃，海鲜？）#profile: painter_norm
我：（也许他们会知道那股鱼腥味的来源。我应该……）#profile: painter_norm
+[上前问问]->ask
+[社恐，走吧]->leave

==ask==
我：那个……嗨~ #profile: painter_side
路人甲：嗨~……？#profile: mobA_norm
路人乙：吸溜吸溜……嗨~？ #profile: mobB_norm
我：……我就是想问问，你们吃的这个是什么？#profile: painter_side
路人甲：这个啊，是旁边那家刨冰摊卖的新品。#profile: mobA_norm
路人乙：味道不错呢！啊哈，我已经是boro酱的粉丝了！#profile: mobB_norm
我：boro酱？#profile: painter_side
路人乙：就是这种闻起来臭臭吃起来香香的boro酱~#profile: mobB_norm
路人甲：是他们家的秘制酱料啦！不过，那个头套人摊主也叫boro酱，这一点也挺迷惑的……#profile: mobA_norm
我：好的，谢谢你们。#profile: painter_side
我：（头套人开的刨冰摊？似乎就在前面，过去看看吧。）
->DONE

==leave==
我：（味道的来源似乎还在更前面……还是接着走吧。）#profile: painter_eyeClosed
->DONE