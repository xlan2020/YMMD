INCLUDE global.ink
VAR drinkTime = 0
Me：*sigh* Such a cold empty room to return to at night. It hardly feels like home to anyone.#profile: painter_eyeClosed
 #bgm: 房间 
Me：It's lacking something, not just the furniture...something more intimate, closer to the heart.#profile: painter_mournful
Me：I am the painter. The only way of self-realization and existential fullfillment is--#profile: painter_alert #choiceType: BUTTON
+[To paint!]
->I_should_draw
+[To sleep!]
Me：Everything's in the dreams!#profile: painter_sour
Me：Wait, I'm the painter, not the sleeper. The only way of self-realization and existential fullfillment is--#profile: painter_alert
->I_should_draw
+[To drink!]
Me：Say no more, it's all in the wine...#profile: painter_sour
 ：*gulp*
Me：Wait, I'm the painter, not the drinker. The only way of self-realization and existential fullfillment is--#profile: painter_alert
->I_should_draw

==I_should_draw==
Me：To paint! Paint my way to fulfill the lack.
Me：This is my object-how ever you look at it, it's just a <color=green>fish scale</color>. But how does it <color=green>feel</color> like?#bgm: 柴柴 #solve: next #profile: painter_side
Me：Cold and wet. How is it possible? It's been in my pocket for the whole night, yet it's still wet.
Me：I'm sure it's of great significance, despite being so tiny.
Me：I need to take a closer look.#event: closer 
Me：Wait, what was that sparkle? I have to <color=green>capture</color> that. #solve: next #profile: painter_alert
Me：There's...water. Water everywhere, tickling my skin... It itches! Am I allergic to water?#profile: painter_stunned
Me：So itchy! I want to scratch my skin with something harder, something sharper...
Me：...the fish scale.#event: largeScale
Me：I have to <color=green>scratch</color>-- #solve: next 
Me：Ouch! It's sharper than I thought... Where's my scale? Wait, what's this...<color=green>鱼</color>？#solve: next #profile: painter_concerned
Me：Where did the <color=green>scale</color> go? My precious, come back to my <color=green>hands</color>...#solve: next #profile: painter_frightened
Me：Heh, it's here.#profile: painter_happy
Me：But my hands are dirty with blood... I should wipe them...#solve: next #profile: painter_norm
???：I'm ready, painter.#event: paintBlood #profile: hide
Me：What? Who's talking?#profile: painter_side
Fish?：<color=green>Strip</color> <color=purple>me</color> <color=green>naked</color> <color=purple>now</color>.#solve: next #profile: hide
Me：What? That was... #profile: painter_frightened
Fish scale?：Do you see me? There's so, so many me on the shelf--which one is the real me?#profile: hide
Fish scale?：Am I special?#event: zoomInTexture
Fish?：Will you take me home?
Fish?：￥40 per kilogram, that isn't too expensive for you, is it?
Fish?：Are you afraid of me? It's okay. Fish likes to jump around. <color=purple>Strip me of my fins</color>, too-So that I can't swim away from you anymore.#solve: next
Fish?：Is it still not enough? I'm literally ready for the table. You've scaled me off, yet still not ready to <color=purple>eat</color> me?
Fish?：What, you don't have enough money for a fish? Buy a piece of scale, then.
Fish scale?：Take with water, it will help you regain beauty and health. Strengthens the body, replenishes kidney and Yang... The efficacy of the medicine will last 30 days!
Fish scale?：30 days should be long enough for you to save up for <color=purple>the next time</color>.#solve: nextCanContinue #event: customizeButton
-> buy_me_scale

VAR buy_me_count = 0
===buy_me_scale===
Fish scale：Buy me.#choiceType: AUTO
{ buy_me_count:
    - 5:
        ~ buy_me_count = 0
        +[Do nothing] -> buy_me_hint
        +[Buy it] -> bought 
    - else: 
        ~ buy_me_count++
        +[Do nothing] -> buy_me_scale
        +[Buy it] -> bought 
}

===buy_me_fish===
Fish：Buy me. #choiceType: AUTO
{ buy_me_count:
    - 5:
        ~ buy_me_count = 0
        +[Do nothing] -> buy_me_hint
        +[Buy it] -> bought 
    - else: 
        ~ buy_me_count++
        +[Do nothing] -> buy_me_scale
        +[Buy it] -> bought 
}

===buy_me_hint===
Me：My fish, I'll buy... Where's my <color=green>cash</color>?#choiceType: AUTO
+[Do nothing] -> buy_me_scale
+[Buy it] -> bought 

===bought===
Me：I, I'll buy......#bgm: fade_5_0 #addMoney: -30 #profile: painter_stunned #choiceType: BUTTON
Me：The fish scale... It's still in my hands. My cash...disappeared. What did I buy? Whom did I buy it from? Where's the fish?#profile: painter_surprised
Me：Shit, that's crazy. How on earth did a fish get into my room to sell itself to me?#profile: painter_sideSweat
Me：What did I do?#profile: painter_side #choiceType: BUTTON
+[Touched the fish] ->mo_yu
+[Had a dream] ->dream

==mo_yu==
Me：I touched... Wait, I drew a beautiful women. Without me noticing. Okay, I hope it's not too weird...
->something_wrong
==dream==
Me：I was not asleep, yet it felt like I just had a confusing dream.
->something_wrong

==something_wrong==
Me：But there's still something wrong. Something that <color=purple>wasn't here before appeared</color> in the room. #solve: next 
Me：There wasn't a glass of water just now.
Me：But it appeared out of nothing. It feels so familiar as if it belongs to this room. 
Me：It's <color=magenta>displacement</color>! I just displaced it from the void.#bgm: 紧张 #bgm: fade_2_1 #profile: painter_stunned
Me：A cup of water. Heh, I used up my money to buy a cup of water?#profile: painter_concerned
Me：What should I do, place it on an altar or drink it up? My throat hurts...#profile: painter_selfMock
Me：...Okay, I see why I need this cup of water.#profile: painter_eyeClosed
"Model"：Pain~ter! Take a break, please? I need some water.#profile: hide
 ：The "painter" was absorbed into their own thoughts.
"Painter"：This painting feels wrong... It lacks intimacy and depth.
"Painter"：How is it possible to create masterpieces with vision alone?
"Painter"：To hear, to touch, to semll, to taste...
"Painter"：Fresh sashimi tastes like tougue.
"Painter"：But it's too expensive for me.
"Painter"：<color=purple>Taste the scale</color> instead... #bgm: fade_4_0.3 #solve: next
Me：...as if I had met you again. #bgm: fade_2_1 #profile: painter_depressed
->scale_in_water

==scale_in_water==
 ：... #profile: hide
 ：......
 ：Fish scale tea is ready.#choiceType: BUTTON
+ [Drink] ->water_lessen


==water_lessen==
 ：Fish scale tea becomes a bit less.#event: drinkWater
{ drinkTime: 
    - 6:
        ->done_drinking
    - else: 
        ~ drinkTime++
        +[Drink]
        ->water_lessen
}

==done_drinking==
 ：The glass is empty.#bgm: fade_4_0
Me：My model #typingSpeed: 1 #profile: painter_depressed
Me：My object
Me：She    is    a    mermaid.
Me：MY mermaid. #typingSpeed: 0.5 #loadScene: DAY1-6_DFD
->DONE

 
（鼠标被迫移动打开背包）
欧耶! 谢谢谢谢，谢谢老板。 
……
不过画家对我来说，并不是特殊的。
还有很多人在等我。
天黑了。时间到了。
我 该 走 了 。
啊
……
Thank you for playing we code and code and code, day and night, and it's not done yet. #speaker: Hello  #speakerMode: norms
-> END