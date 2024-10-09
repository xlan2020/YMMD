INCLUDE ../global.ink
Me：(I can get in the line here. The smell... I think I've gotten used to it.)#profile: painter_eyeClosed
{diyRead: 
- false:
Me：(What's this? DIY contest, free entry, grand prize?)#profile: painter_eyeClosed
~ diyRead = true
Me：(Grand Prize! I'm in!)#profile: painter_happy
Me：(I should ask the owner about it when it's my turn.)
->waiting
- true: 
    ->waiting
}

==waiting==
Me：(Few people are in the line, but you also can't say it's not popular at all.)#profile: painter_norm
+[Look at the menu]->menu
+[Look at owner]->owner
+[Look at the line]->others


==menu==
Me：(Let me see...)#event: showMenu 
+[I'm done.]
->my_turn

==owner==
Me：(The head...looks sort of home-made.)#profile: painter_norm
Me：(Seaweed-like tangled hair, clumped out mascara...I like it.)#profile: painter_side
Me：(Nostalgic, somehow.)
Me：(Ahem. Nice head. You could sense the anime girl cliche, but the dirty finish really appeals to me. Cute.)#profile: painter_happy
Me：(Is this even a compliment? Ahem.)#profile: painter_selfMock
->my_turn

==others==
Me：(People in this line look pretty young. Young enough for a gimmick-filled, trendy food truck.)#profile: painter_norm
Me：(Students during summer vacation? Young travellers attracted by the affordable beach?)#profile: painter_side
Me：(Am I one of them?)
Me：(But I'm just a penniless painter, with important work to finish in this town...)#profile: painter_selfMock
->my_turn

==my_turn==
Me：(Ah, my turn.)#profile: painter_norm #event: hideMenu
？？？："Boroboro" Fish Shaved~Ice! Hello there, "Boro-chan" at your service❤!#profile: boro_welcome
boro-chan：What kind of shaved ice would you like? Would you taste our limited special -- Torpedo Avocado Aficionado's Ice?
+ {money > 18} [Torpedo, please!]//Sherry Note: 要不要菜单上有的都放到选项？
->order_new
+ {money > 24} [I want the classic.]
->order_classic
+[The DIY event...]
->diy

==order_new==
Me：The torpedo-something, I want it!#profile: painter_happy #addMoney: -18
boro-chan：Great choice!#profile: boro_shy
boro-chan: The Torpedo Avocado Afictionado's Ice is the modified version of our most-beloved Deep Sea Treasure Ice, with chunks of three different fishes dipped in boro-chan sauce, hidden inside the ice.#profile: boro_thinking
boro-chan：Just a sec... #profile: boro_escape
 ：......
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #event: addTorpedo
boro-chan: Is there anything else you need?#profile: boro_thinking
+[The DIY event...]
->diy

==order_classic==
Me：(The couple at the bar were holding what looked like this Premium Platter ice...)#profile: painter_happy
Me: I'm having the Premium Platter! #addMoney: -24
boro-chan：Just a sec... #profile: boro_escape
 ：......
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #event: addClassic
boro-chan: Is there anything else you need?#profile: boro_thinking
+[The DIY event...]
->diy

==diy==
boro-chan：Oh, that. #profile: boro_thinking
Me: Is the contest still on?#profile: painter_norm
boro-chan：It's been on for a while, no one's serious about it, only some kids who wanted to play. Messed up the truck. Bad. Was gonna take it down today...#profile: boro_awkward
Me：(It's been up for a long time? I don't remember it at all... Never mind, I've forgotten too much recently.)#profile: painter_surprised
boro-chan：But if it's the painter...you might bring it back alive.#profile: boro_thinking
Me：Hehe, thanks a lot... #profile: painter_happy
Me：...Eh? You recognize me?#profile: painter_stunned #bgm: pause
boro-chan：... #profile: boro_thinking
boro-chan：...... #profile: boro_awkward
boro-chan：Oh no!#profile: boro_panic #bgm: play #bgm: 戏谑
boro-chan：I think, I thought, you look like... Oops, must've come up somewhere before... No, no, we've never met, and, and I'm not some creepy stalker or anything... #profile: boro_panic
Me：(She sounds nervous?) I'm sorry, I've forgotten a few things lately. Actually, I think I might've been here before.#profile: painter_selfMock
boro-chan：Ohhh, you came before? For ice? That makes sense. Ha, I've forgotten too. That's right.#profile: boro_awkward
Me：(It's nothing, but when she said that, it started to seem suspicious.)#profile: painter_worried
boro-chan：DIY, DIY! Make your ice yourself! You're free to use this countertop here~ #profile: boro_welcome
boro-chan：Come, try now!#profile: boro_glad #loadScene: DAY2-3_Boro
->DONE
