INCLUDE ../global.ink
{ iceEatTalk: 
    - 0:
        ~ iceEatTalk++
        ->first_talk
        
    - else: 
        ~ iceEatTalk++
        ->eating
}

==eating==
John：...Click...squeak...crunch...Hah!...#profile: mobB_norm
->DONE

==first_talk==
Jill：Actually, it tastes good!#profile: mobA_norm
John：It's like stinky tofu, the smell sucks but the taste...Click...squeak...crunch...Hah!...#profile:mobB_norm
Me：(Wow, they're really enjoying it.)#profile: painter_surprised
Me：(The bar isn't open yet, the food must be from somewhere else. It's, uh, seafood?)#profile: painter_norm
Me：(Must be where that stinky fish smell comes from. I should...)#profile: painter_norm
+[Go up and ask]->ask
+[Can't talk, just go]->leave

==ask==
Me：Uh, hey? #profile: painter_side
Jill：Hey...?#profile: mobA_norm
John：crunch...Hey？ #profile: mobB_norm
Me：Just wanted to ask, what's this you're eating?#profile: painter_side
Jill：Oh, it's just shaved ice, from that food truck over there.#profile: mobA_norm
John：It's really good! I'm already a fan of Boro-chan.#profile: mobB_norm
Me：Boro-chan?#profile: painter_side
John：It's this sauce. Stinky smell, heavenly taste~#profile: mobB_norm
Jill：Boro-chan, Boro's secret sauce! Kinda confusing, though, cuz the truck owner's also called Boro-chan...#profile: mobA_norm
Me：Cool, thanks.#profile: painter_side
Me：(Boro-chan's Boro-chan sauce. Fascinating. I can't wait to check it out!)
->DONE

==leave==
Me：(The source of the smell seems to be further ahead. Better move on.)#profile: painter_eyeClosed
->DONE