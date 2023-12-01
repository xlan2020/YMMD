INCLUDE global.ink
{ foodOrdered: 
{~Mama：Hold on, the stuff will be ready soon.|Mama：Just a minute.|Mama：Make yourself comfortable while you wait.|Mama：On it!}#profile: mama_norm
-> DONE
}
{ mamaTalk: 
    - 0:
        ~ mamaTalk++
        ->first_talk
        
    - else: 
        ~ mamaTalk++
        ->talk_again
}
===first_talk===
Mama：Hey, it's the painter! You'll have the usual?#profile: mama_satisfied
Me：(What should I order?)#profile：painter_happy
+ [Spare Ribs Casserole(￥12)]
{ money < 12: 
Me：(The casserole here is a real treat, even better with some bean sprouts...wait, I think I forgot something.）#profile：painter_eyeClosed
->no_money
- else: 
Me：I'll have the Spare Ribs Casserole with rice!#addMoney: -12 #profile：painter_happy
            ->you_know_displace
}
+ [BBQ set(￥16)]
{ money < 16: 
Me：(The BBQ set looks good, but...)#profile：painter_eyeClosed
->no_money
- else: 
Me：I'll have the BBQ set! Lamb kebabs and grilled eggplant, please.#addMoney: -16 #profile：painter_happy
->you_know_displace
}
+ [I'm out of cash]
->no_money

===you_know_displace===
Mama：Coming right up!#profile: mama_satisfied
Mama：You didn't hesitate to pay, I'll take it that you already know about displacement?#profile: mama_norm
+ [Of Course]
Me：Of Course.
Mama：Ha, I understand.
->buy_food
+ [Displacement?]
->explain_displace

===talk_again===
Mama：What would you like to have?#profile: mama_norm
+ {money > 12} [Spare Ribs Casserole(￥12)]
Me：I'll have the Spare Ribs Casserole with rice!#addMoney: -12 #profile：painter_高兴
->buy_food
+ {money > 16} [BBQ Set(￥16)]
Me：I'll have the BBQ set! Lamb kebabs and grilled eggplant, please.#addMoney: -16 #profile：painter_happy
->buy_food
+ [Uhhhh.]
Mama：Just displace something.#profile: mama_upset
->DONE
===no_money===
Me：......... #profile：painter_side
Me：...I'm out of cash...Could you please kindheartedly give me some plain noodles, I'm so sorry...I'll sell a painting tomorrow and pay it back.#profile: painter_sideSweat
Mama：How come you're broke?#profile: mama_norm
Me：To be honest, I'm not sure. I woke up and everything's gone.#profile: painter_depressed
Me：(Crap, I sound like a shameless lier.）#profile: painter_sideSweat
Mama：Right. You're a regular here, it's not like I don't trust you. It's okay to cook you something to eat.#profile: mama_upset 
Mama：But you're carrying quite a few things with you.#profile: mama_upset
Mama：Why don't you <color=magenta>displace</color> something for cash?#profile: mama_norm
Me：Displacement.#profile: painter_sour
Me：(Right, displacement...)#profile: painter_eyeClosed #unlockNote: 2_3
-> explain_displace
    
=== explain_displace ===
Mama：What's wrong? You still can't figure out displacement? Why, you're not like a young person. Everyone displaces here.#profile: mama_upset
Mama：Just focus on the thought of turning this thing into money--see, how hard is that?#profile: mama_satisfied
{ not you_know_displace: 
Mama：Your turn. Displace something, and I promise I'll make you a delicious meal.
Me：(The rule of thumb of displacement: the more important something is to me, the more it's worth in cash.)#profile: painter_norm
Me：(Of course, the status of an object in one's mind changes, and so does its worth. Most people can't accurately predict how much something is worth. That's a risk you'll have to take.）
Me：(Displacement has become a magic that everyone can do, whenever and wherever they want.）
Me：(However, as a means of quick money, displacement has a <color=magenta>price</color> that I just hate to afford: <color=gray>disappearance</color>.）
}
{ you_know_displace: 
Me：(What's wrong with me! I don't even remember the whole displacement thing.）
Mama：Painter, what's on your mind?#profile: mama_norm
Me：(Lost in my thoughts again.）Nothing! Sorry.#profile：painter_side
Mama：Haha, you're like a child.#profile:mama_satisfied
-> buy_food
}  
Me：.........#profile：painter_eyeClosed #unlockNote: 2_4
Me：(I really can't pull myself together to beg for food, so I'd better see if there's anything worth displacing.)#event: showDisplace
-> DONE
    
===buy_food===
~ foodOrdered = true
Mama：Sit down and wait! The food will be ready in three minutes.#profile: mama_satisfied #event: mama_back
->DONE
    
===finish_displace===
Me：(That's it? Well, I have some money now.)
Me：(Wait, what did I just trade away?)
Me：(Such a pain in the ass. Stop trying to remember it--it just disappeared, leaving no trace of existence.）#unlockNote: 3_1
Me：(Anyways, it doesn't matter. Now I can buy something from Mama.)
->DONE
->END