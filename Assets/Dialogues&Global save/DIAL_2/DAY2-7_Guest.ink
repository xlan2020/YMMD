INCLUDE ../global.ink
{ guestTalk: 
    - 0:
        ~ guestTalk++
        ->first_talk
        
    - else: 
        ~ guestTalk++
        ->default
}
==first_talk==
客人：决定好了，决定好了，就是她了…… #profile: laowang_pleased
我：（谁？好想知道是谁！）#profile: painter_stunned
客人：美杜莎！好喜欢美杜莎！想把美杜莎纹在心尖尖上！#profile: laowang_pleased
我：（………………原来不是深海传说也是可以的啊！）#profile: painter_noComment
->DONE

==default==
客人：决定好了，决定好了…… #profile: laowang_pleased
->DONE