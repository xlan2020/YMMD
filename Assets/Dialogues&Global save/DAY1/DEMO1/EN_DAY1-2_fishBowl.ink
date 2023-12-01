INCLUDE global.ink
Me：(Huh? This fish tank looks pretty. No one wants it? All the stalls are empty.)#profile: painter_norm
Me：(In this case, could I take it away...Oh.)#profile: painter_happy
Me：(There's beautiful goldfish living in it.)#profile: painter_surprised
Me：(Poor little thing, I don't have anything to feed you either...）#profile: painter_depressed
+[Leave it behind] ->leave
+[I want the fish tank!]->want_bowl

===leave===
Me：(I can't even keep myself alive. Someone else will take care of it.)#profile: painter_norm
->DONE

===want_bowl===
Me：(I really want the fish tank, so...)#profile: painter_norm
+[Take the fish and the tank away]->both
+[I only want the tank.]->bowl_only
+[Forget it, I don't want it anymore.]->leave

==both==
Me：(I'll feed it somehow.)#event:getBowlFish #profile: painter_norm
->DONE

==bowl_only==
Me：(What should I do with the fish though?)#profile: painter_eyeClosed
+["release" it into the sewer]->get_bowl
+[Drop it into another tank]->get_bowl
+[Forget it, I don't want it anymore.]->leave

==get_bowl==
Me：(What a great tank, it's mine!)#event:getBowl #profile: painter_happy
->DONE

