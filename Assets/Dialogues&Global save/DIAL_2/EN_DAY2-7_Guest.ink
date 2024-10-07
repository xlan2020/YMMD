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
Guest：I've decided! It'll be her... #profile: tattoo_glad
Me：(Who? I want to know!)#profile: painter_stunned
Guest：Medusa! I love her! Tattoo her on the tip of my heart!#profile: tattoo_glad
Me：(Hey, that's not a legend of the sea...)#profile: painter_noComment
->DONE

==default==
Guest：I've decided... Hehe... #profile: tattoo_glad
->DONE