INCLUDE ../global.ink
{ tattooTalk: 
    - 0:
        ~ tattooTalk++
        ->first_talk

    - else: 
        ~ tattooTalk++
        ->default
}

==first_talk==
Me：This is Seanamae's tattoo shop, "Institute of Fantastic Creatures."#profile: painter_norm
Me：I remember that she has a scary bodyguard. Would I be tied up to the workbench for not submitting the draft?#profile: painter_mournful
Me: I did put this off for too long. Eh...should I prepare myself for longer?#profile: painter_selfMock
+ [Enter]
Me：...Ha. I'll find a way...#profile: painter_selfMock
->enter_tatoo_shop
+ [Wait]
Me：I still have time for strolling around. #profile: painter_selfMock
->DONE

==default==
：should I prepare myself for longer?#profile: hide
+ [Enter]
Me：...Ha. I'll find a way...#profile: painter_selfMock
->enter_tatoo_shop
+ [Wait]
Me：I still have time for strolling around. #profile: painter_selfMock

==enter_tatoo_shop==
：#loadScene: DAY2-5_TattooShop
-> DONE