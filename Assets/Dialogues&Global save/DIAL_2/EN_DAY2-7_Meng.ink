INCLUDE ../global.ink
{ mengTalk: 
    - 0:
        ~ mengTalk++
        ->first_talk
    - else:
        ~ mengTalk++
        ->default
}

==first_talk==
Meng：*Aggressive head turn*#profile: meng_noWord
Meng：...
Meng：Painter.
Me：Here!... I mean, yes?#profile: painter_sideSweat
Meng：It's...pretty cool.#profile: meng_norm
Meng：......Ms. Sea...#profile: meng_noWord
Me: Huh?#profile: meng_norm
Meng: Chief also liked it.#profile: meng_noWord
Meng：...Could you...teach me? To draw.
Me：Eh...eh?#profile: painter_surprised
Me：No problem at all!#profile: painter_norm
Me：(Didn't expect that. Such lovely personality for a big guy like him.)#profile: painter_happy
Me：(No bad guy likes to paint, it's decided.)#profile: painter_laugh
Meng：...Thanks.#profile: meng_norm
Meng：I won't let you go. I mean, I'll be coming for you. No...I'll catch you later.#profile: meng_noWord
Me：...... #profile: painter_noComment
Meng：*Aggressively turns back* #profile: meng_noWord
->DONE

==default==
Meng：*Aggressive head turn* #profile: meng_noWord
Meng：...Hey.#profile: meng_norm
Meng：*Aggressively turns back* #profile: meng_noWord
//S: 未来有机会做教小孩画画（。
->DONE