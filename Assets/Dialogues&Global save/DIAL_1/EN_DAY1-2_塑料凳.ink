INCLUDE ../global.ink
{ not foodOrdered: 
{~Me：(I'll sit down after I order some food.)|Me：(Just a half-new plastic stool that could be seen everywhere.)}#profile: painter_norm
->DONE
}
Me：(I can sit down to wait for the food.)#profile: painter_happy
Me：……#profile: painter_norm
Me：………………#profile: painter_noComment
Me：(Does everyone who comes alone sit dry for a meal like I do?)#profile: painter_eyeClosed
Me：(How did I used to do this? Did I own a cell phone? Or was there someone with me...）
Me：(Sunset over the ocean, blurring the edge between the sky and the sea. Such beautiful scenery.）#profile: painter_side
Me：...
Me：...... #event: 8-2_appearOnce #bgm:pause
Me：.........Huh?#profile: painter_sideSweat
Me：(Is it my eyes?)
Me：.........Ehhhhh?#event: 8-2_blink #profile: painter_stunned #bgm:悬疑
Me：(A...a pervert...My eyes hurt...no, my head hurts too...）
Me：(I suddenly remember something. It's Wednesday!）#profile: painter_frightened
Me：(August 26th, Wed. I promised a friend that we'd...he'd...）
Me：(Well, that could wait--)#profile: painter_alert
Me：(That thing's coming over!)#profile: painter_frightened #event: 8-2_walkCloser
Me：Oi!#profile: painter_surprised
???：My~~~little~~~painter!#profile: 8-2_smile #bgm:戏谑
Me：Huh？#profile: painter_alert
???：Sure enough, you don't recognize me again.#profile: 8-2_upset
???：Your cold indifference cuts me to the core.#profile: 8-2_upset
???：I'm your friend Eightminus Tue!#profile: 8-2_smile
Me：(Eight minus two? Six.)Bro, you've mistaken me for someone else.#profile: painter_sideSweat
8-2：*Claped*You just call me "bro"! Hey, I'd love that. Are you finally ready to join my One in Seven Fraternity?#event: 8-2_stayDressed #profile: 8-2_smile
Me：Fraternity?#profile: painter_side
Me：(Hmm? When did he put his clothes on?)#profile: painter_sideSweat
8-2：Gee, you're full of questions right now. It's okay, you'll get it in a moment.#profile: 8-2_smile
8-2：Painter!let's start by painting me a portrait!
Me：Slow down.(He called me "painter," did I know him from somewhere?)#profile: painter_side
8-2：Uh-huh. One two three, four five six, seven eight nine ten ARE YOU READY? Let's paint!#profile: 8-2_smile
8-2：Don't worry, I'll pay!
Me：(I do need some money though.)#profile: painter_happy
Me：(But wait, this guy still looks suspicious.)#painter: painter_alert
8-2：Here's the deposit.#addMoney: 100 #profile: 8-2_smile
Me：(No shit, a scammer don't give you money upfront.)#profile: painter_stunned
Me：Dear sir, what kind of portrait would you like?#profile: painter_happy
Me：Let me get the painting box ready first--
Me：Ooops! #loadScene:DAY1-3_Draw8-2
->DONE