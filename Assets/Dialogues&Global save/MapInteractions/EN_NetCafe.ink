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
：Enter the e-Era Net Cafe?#profile: hide
+ [Yes]
Me：(I want to check out the news.)#profile: painter_norm
：......#event: openNetBar
Me：(Feels like I'm learning something new, just not sure what.)
-> DONE

+ [No]
Me：(Maybe later.)#profile: painter_norm
-> DONE

==first_talk==
：【As an excellent local business, e-Era now provides free internet access, for temporary use of citizens who lost access to PC due to incidents like displacement accidents.】#profile: hide
：【Due to operation arrangement, the free machine only provides browsing function. It does not support interactive functions such as logging in, posting, replying, etc.】
：【e-Era will always be with you. Community is our priority, and we will continue to give back to your support, providing convenience for the general public with all sincerity.】
Me：(This announcement looks a bit old, how come I never noticed it before?)#profile: painter_surprised
Me：(It can't be that I used to own a PC.)#profile: painter_sideSweat
Me：(Free internet service, it's for me.)#profile: painter_norm
Me：(Shall I try it out now?)
+ [Yes]
Me：(I want to check out the news.)#profile: painter_norm
：......#event: openNetBar
Me：(Feels like I'm learning something new, just not sure what.)
-> DONE

+ [No]
Me：(Maybe later.)#profile: painter_norm
-> DONE
