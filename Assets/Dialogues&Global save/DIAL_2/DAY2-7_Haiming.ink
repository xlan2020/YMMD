INCLUDE ../global.ink
{ haimingTalk: 
    - 0:
        ~ haimingTalk++
        ->first_talk
        
    - else: 
        ~ haimingTalk++
        ->default
}

==first_talk==
海名：怎么，这么快就回来给我交稿了？#profile: haiming_seeYouKnow
我：啊，嗯，不知道。抱歉。对不起。#profile: painter_concerned
海名：不逗你了。 #profile: haiming_smile
海名：有关美人鱼的信息，我要继续调查一下。有情报就告诉你。#profile: haiming_think
海名：喝茶吗？别客气，随便坐。#profile: haiming_yinyang
->DONE

==default==
海名：有关美人鱼的信息，我要继续调查一下。有情报就告诉你。#profile: haiming_think
海名：喝茶吗？别客气，随便坐。#profile: haiming_yinyang
->DONE