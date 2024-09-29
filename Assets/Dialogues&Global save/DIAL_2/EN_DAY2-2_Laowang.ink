INCLUDE ../global.ink
{ lwTalk: 
    - 0:
        ~ lwTalk++
        ->first_talk
        
    - else: 
        ~ lwTalk++
        ->default
}

==default==
 ：Old Wang's <color=red>Infinity</color>Kiosk, restocking directly through displacement，{lwText_EN}!#profile:hide
{ lwText_EN == "Nothing's ever sold out":
    +[restocking from displacement] ->displace_renew
    +[I see] ->come_buy //为什么玩的时候点这个选项，这个Done就会不done? 暂且改成这个之后没有这个bug了:still typing, can't continue story. 这时候任何操作都不算数。
    // UnityEngine.Debug:Log (object)InkDialogueManager:ContinueStory () (at Assets/Scripts/New Dialogue System/InkDialogueManager.cs:431) UnityEngine.EventSystems.EventSystem:Update () (at ./Library/PackageCache/com.unity.ugui@1.0.0/Runtime/EventSystem/EventSystem.cs:530)
 - else:
    +[Stocking from displacement?] ->displace_renew
    +[Never sold out?] ->never_empty
    +[I see] ->come_buy
}

==displace_renew==
Me：Hey, sir. What's this "restocking directly through displacement"?#profile:painter_side
Old Wong：Hey, great question! We don't have to contact the manufacturers for restocking, but displace them in. The goods appear directly in store, avoiding bumps and bruises on the way completely! Everything's the best.#profile: laowang_pleased
Me：From displacement...meaning these're all second-hand?#profile: painter_side
Old Wong：Second-hand? Of course not! Brand new! Directly from factory to the void, from the void to the Old Wong's. Second-hand!#profile: laowang_mad
Me：Sorry, misunderstanding. I mean, I acutally like vintage stuff... #profile: painter_side
Old Wong：There isn't any! All brand new! Look, the ink on this label's still shiny...you don't get that on second-hand stuff...#profile: laowang_mad
Me：...I see. It's perfect.#profile: painter_side
Me：(Sounds economical. Mr. Wong knows the manufacturing cost of the goods, so it would cost less for him if he restocks through displacement, according to his psychological value.)#profile: painter_norm
Me: (The manufacturers...directly exchange goods into money. Farewell to dead stock.)
Me：(The displacement becomes a flawless retail and transportation hub of the world.)
Me：(...Really, the more perfect it sounds, the more ominous I feel.)#profile: painter_eyeClosed
Old Wong：Come buy often. New things in stock every day!#profile: laowang_norm
->DONE

==never_empty==
Me：Eh, sir, had anyone told you that "never sold out" sounds a bit like...dead stock.#profile: painter_side
Old Wong：.........#profile: laowang_think
Me：(Sorry. Don't be angry please...)#profile: painter_sideSweat
Old Wong：You guys. What do I have to say. I've already changed the shop's name from "Good Neighbour Old Wong" to "Old Wong ∞," what more would you expect?#profile: laowang_mad
Old Wong: Now "never sold out" is also wrong? Dear me... 
Me：Sorry! I'm so sorry!#profile: painter_sideSweat
Me：But still, what about "always buy, always new?"#profile: painter_norm
~lwText_CH = "常买常新"
~lwText_EN = "always buy, always new"
Old Wong：......#profile: laowang_think
Old Wong: Sounds about right! I'll change it right away.#profile: laowang_pleased
->DONE

==first_talk==
Old Wong：Yo, painter!#profile:laowang_norm
Me：Hey, Mr. Wong.#profile: painter_norm
Old Wong：You're not with <color=magenta>the you-know-who</color> together?#profile:laowang_norm
Me：Huh? Who?#profile:painter_surprised
Old Wong：...... #bgm: fade_0.2_0 #profile: laowang_think
Old Wong：Look at my memory! Hey, wrong person. Couldn't have been you. You artists always like to keep to yourselves, don't you?#bgm: fade_1_1 #profile:laowang_pleased 
Me：(Wrong person? Weird. As if I used to show up often with somebody else. Should I ask again?) #profile: painter_side
+[Are you talking about 8-2？]->masaka
+[Who are you thinking of?]->whom
+[Nothing to ask]->dont_ask

==masaka==
Me：You can't be talking about Eightminustwo, my friend with red hair who's always full of shit?#profile: painter_side
Me：(Though I just forgot him yesterday. He doesn't seem to have been around often. But I don't have much friends.)
Old Wong：Eightminustwo...red hair... Yes, yes, I know the kid. Ha! no mistake, you used to come up here together. How's he doing?#profile: laowang_think
Me：He seems well.#profile: painter_sideSweat
Old Wong：That's good! Hey, I remember that he loves buying <color=red>mini books</color>.#profile: laowang_norm
Old Wong: Painter, don't you want to take a look at what's in stock today?#profile: laowang_pleased
+[Sure.]
->shop
+[No, thanks.]
->come_buy

==whom==
Me：(Somehow I can't let it go.) Who are you talking about?#profile: painter_side
Old Wong：Told you, wrong person!#profile: laowang_mad
Me：Hey, I'm just curious. Just a hypothesis, who do you think I was with? #profile: painter_side
Old Wong："Hypothesis!" You artists. Okay, let me think.#profile: laowang_think
Old Wong：Think... 
Old Wong：Thinking...#profile: laowang_mad
Old Wong：Sweet girl...comes often... #profile: laowang_think
Old Wong：They're an item. Who comes here often.#profile: laowang_norm
Old Wong：OK, satisfied? All I remember is that one of them picks and the other pays. Painter, don't you want to take a look at what's in stock today?#profile: laowang_pleased
+[Sure.]
->shop
+[No, thanks.]
->come_buy

==dont_ask==
Me：(Wrong person. No big deal.)#profile: painter_norm
->come_buy

==shop==
Me: Let me take a look.
Me: ... #event
Me: Thanks a lot!
->come_buy

==come_buy==
Old Wong：Come back soon, painter! Restocking daily, directly from displacement.#profile: laowang_norm
->DONE
