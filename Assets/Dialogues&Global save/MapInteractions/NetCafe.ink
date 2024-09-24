INCLUDE ../global.ink
{ netCafeTalk:
    - 0:
        ~ netCafeTalk++
        ->first_talk
    - else: 
        ~ netCafeTalk++
        ->default
}

==default==
：要进入网吧吗？#profile: hide
+ [是]
我：（去看看最近有什么新闻吧。）#profile: painter_norm
：……#event: openNetBar
我：（感觉好像学到了什么了不得的东西。）
-> DONE

+ [否]
我：（先算了。）#profile: painter_norm
-> DONE

==first_talk==
：【e时代网吧作为本地优秀民营企业，将响应镇长号召，即日起设立便民上网免费机位，供因置换事故等不可抗力而暂时无个人电脑的市民临时使用。】#profile: hide
：【因运营安排，免费机位仅提供浏览功能，不支持登录、发帖及回复等交互操作，敬请谅解。】
：【e时代网吧将继续秉持服务社区、回馈社会的宗旨，竭诚为广大市民提供便利。】
我：（这张公告看起来已经有些年头了，怎么我以前从没注意到过？）#profile: painter_surprised
我：（难道我曾经也是富有到拥有一台自己的电脑的人吗？）#profile: painter_sideSweat
我：（不过，免费机位，真是再合适不过了。）#profile: painter_norm
我：（要不要现在就去体验一下？）
+ [是]
我：（看看最近有什么新闻吧。）#profile: painter_norm
：……#event: openNetBar
我：（感觉好像学到了什么了不得的东西。）
-> DONE

+ [否]
我：（先算了。）#profile: painter_norm
-> DONE
