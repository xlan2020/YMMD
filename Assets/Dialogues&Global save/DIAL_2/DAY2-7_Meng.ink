INCLUDE ../global.ink
：{mengTalk}
{ mengTalk: 
    - 0:
        ~ mengTalk++
        ：{mengTalk}
        ->first_talk
        
    - else: 
        ~ mengTalk++
        ：{mengTalk}++
        ->default
}

==first_talk==
孟猛：*凶狠地转头* #profile: meng_noWord
孟猛：……
孟猛：画家。
我：到！……不是。嗯？#profile: painter_sideSweat
孟猛：那个………挺酷的。#profile: meng_norm
孟猛：（超小声）…………………………海、海名姐姐……店长也很喜欢。#profile: meng_noWord
孟猛：……请问……可不可以教教我，画画？
我：啊……啊？#profile: painter_surprised
我：诶，当然可以啦。#profile: painter_norm
我：（没想到他这么大块头，性格原来还挺可爱的。）#profile: painter_happy
我：（嗯！喜欢画画的一定都是好人！）#profile: painter_laugh
孟猛：……谢谢。#profile: meng_norm
孟猛：我不会放过你的……我是说，我会去找你的。#profile: meng_noWord
我：……………… #profile: painter_noComment
孟猛：*凶狠地回头* #profile: meng_noWord
->DONE

==default==
孟猛：*凶狠地转头* #profile: meng_noWord
孟猛：……你好呀。#profile: meng_norm
孟猛：*凶狠地回头* #profile: meng_noWord
//S: 未来有机会做教小孩画画（。
->DONE