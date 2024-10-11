INCLUDE ../global.ink
8-2：Ah, I was so obsessed with your painting that I forgot to check the time.#profile: 8-2_raiseEyebrow
8-2：I have to meet up with my brothers now. Take this before I forget...#profile: 8-2_laugh
Me：(Eh? A pair of glasses, just like 8-2's. There's something engraved on the side: "1/7.")#event: getGlasses #profile: painter_stunned
Me：I never said that I'm joining you!#profile: painter_noComment
8-2：NO, NO, NO, you're just the reserve, not a member, yet. You've passed the first round of examination. Good luck for the next six!#profile: 8-2_smile2
Me：(Whatever.) Why do you take the fraternity thing so seriously?#profile: painter_eyeClosed
8-2：I'll scare the shit out of you if I tell you.#profile: 8-2_norm
8-2：To make it short, we are working to control displacement. Well, my lectures are really worth the price-I'm not trying to sell them to you, bro, I'd help you for free whenever needed. All for our friendship.#profile: 8-2_smile2
8-2：Painter, I could see that you're having a hard time.#profile: 8-2_norm3
Me：(I lost...)#choiceType: BUTTON #profile: painter_norm
+[...my memory]->I_lost
+[...all my money]->I_lost
+[fuck displacement]->I_lost

==I_lost==
Me：It's that obvious? Yes, I lost to displacement. Worse, I don't even remember what I had.#profile: painter_depressed
8-2：*claps* You should earn something back from displacement!#profile: 8-2_weirdSmile
Me：I'm not that type of opportunist who likes to exploit.#profile: painter_alert
8-2：That's not right. To own is to exploit? No! I'm talking about creation, about art!#profile: 8-2_smile2
8-2：You just told me that it's impossible to displace things out of the Void.#profile: 8-2_norm
8-2：It's disappointing to hear that coming out of you. Painter, before you paint, the painting didn't exist either.#profile: 8-2_cold
8-2：Both being creating existence out of nothingness, how is the art of displacement different?#profile: 8-2_smile2
Me：Well thanks for the acknowledgement, but I'm not the God's pen. A painting is just a painting.#profile: painter_norm
8-2：Hey, that's not what I mean. Your paintings aren't just paper with colors on it. It is an <color=magenta>accurate depiction</color> of an object.#profile: 8-2_smile2
8-2：If you could accurately depict something that has <color=magenta>disappeared</color>, if you could remember it and draw it out just as it is... Then you could <color=magenta>displace it back</color>.#profile: 8-2_norm
8-2：Did you get what I mean?#profile: 8-2_smile2
->did_you_get_it

==did_you_get_it==
Me：(It's...)#profile: painter_norm
+[No way!]
Me：I hear you, but it sounds nothing more than crap.#profile: painter_noComment
->yes_I_understand
+[.....]
Me：………………#profile: painter_side
->yes_I_understand
+[What? Tell me again.]->repeat_description_again

==repeat_description_again==
8-2：Your paintings aren't just paper with colors on it. It is an <color=magenta>accurate depiction</color> of an object.#profile: 8-2_smile2
8-2：If you could accurately depict something that has <color=magenta>disappeared</color>, if you could remember it and draw it out just as it is... Then you could <color=magenta>displace it back</color>.#profile: 8-2_norm
8-2：Did you get what I mean?#profile: 8-2_smile2
->did_you_get_it

==yes_I_understand==
8-2：Of course, it's all crap if you don't try.#profile: 8-2_norm3
8-2：Ta-da! This is the next challenge towards your membership in the One in Seven Fraternity. <color=magenta>Displace to make something that had disappeared to reappear out of the Void</color>. #bgm: 戏谑 #profile: 8-2_smile2
8-2：Isn't it exciting! Not to mention how beneficial it would be for you.#profile: 8-2_laugh
Me：...Here awaits the same old offer.#profile: painter_noComment
8-2：Hey, I'll <color=red>wait</color> for you <color=green>❤</color>#profile: 8-2_laugh
8-2：I'll <color=red>appear</color> <color=green>again</color> when the time comes.#profile: 8-2_norm
8-2：I really have to go.#profile: 8-2_smile2
Me：Just leave, my head aches.#profile: painter_eyeClosed
8-2：Bye dear~ #profile:8-2_smile2
Me：Catch you later.#profile: painter_norm
 ：8-2 left.#bgm: fade_2_0 #event: 8-2left #profile: hide
Me：(Eightminus Tue is a weird friend of mine. He has more secrets than I dare to guess.)#profile: painter_side
Me：(And you never know if he's telling the truth.)
Me：......
Me：(At least I've got some cash. But I can't find an art supply store that opens till this late.)
Me：(My appartment is to the west. To the east, there are places where I could kill time...if I weren't so impoverished.)
Me：(Back home...there's nothing besides the walls. At least here's a stretch of <color=green>beach</color> where I could take a walk.)#profile: painter_sideSweat
Me：(Let's take a stroll before <color=green>going back home</color>.)#profile: painter_side
->DONE