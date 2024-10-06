INCLUDE ../global.ink
Me：(Seanamae's studio looks awesome. How I'd love a studio of my own...)#profile: painter_side #portrait: haiming_3_idle #bgm: 日常_0.2 #drawingSystem: addBinaryVal_50
Me：(No wonder I'm just a self-proclaimed painter. There's nothing romantic about being penniless, when you look at it closely enough.)#profile: painter_sideSweat
Me：(Does Seanamae live in her studio, though? It's not the first time I'm here, but everything seem unfamiliar.)#profile: painter_side
Me：You'll turn what I draw into a tattoo design?#profile: painter_norm
Seanamae：Sure, if a client likes it. I'll also make some tattoo stickers out of them for sale.#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
Me：Sounds great. Is there any specific requirement for texture or material?#profile: painter_norm #drawingSystem: showMaterialWindow
Seanamae：Wow, your equipment box looks cool.#profile: hide 
Seanamae：I'm only using your draft as the basis for the final designs, so I'm cool with anything you feel like. #drawingSystem: selectMaterial
->theme

==theme==
Me：Cool. The theme would be, ugh, something about deep sea monsters, right?#profile: painter_side
Seanamae：You do remember that I like to call this place "Institute of Fantastic Creatures."#portrait: haiming_3_pushGlass #profile: hide
Seanamae: I work with monsters, exotic creatures, divine creatures, whether they are from ancient history books, rumors, or even comics. #portrait: haiming_3_norm
Me：(She is so obsessed with these legends. I could see it from her <color=green>hairband</color>. But isn't this...?)#showObservee: seaSlug #choiceType: OBSERVEE
//【捕捉：
//左边：Seanamae发饰中的海蛞蝓
//右边：细致的海蛞蝓(说起来鹅鹅demo的时候好像p过这个图，Me回头发来看看要不要直接用)
//描述：这家伙的发饰，似乎是一种海洋生物？不过，总觉得和神秘还有些距离。】
+[海蛞蝓提交]
->theme_continue

==theme_continue==
Me：Sea slugs, jellyfish... Aren't these just ordinary marine animals? I thought you're only interested in legends.#profile: painter_side #choiceType: BUTTON
Seanamae：Perceptive, aren't you?#profile: hide #portrait: haiming_3_squint
Seanamae：Everyone has their guilty pleasure. Mine is to connect fantasy with what's tangible, as if finding sources for the human imagination. #portrait: haiming_3_norm
Seanamae: A bit boring if I put it this way, isn't it?#portrait: haiming_3_norm
Me：Not at all. It's reasonable that you need something a sketching exercise. Before creating something convincingly imaginative, you need to find references first.#profile: painter_side 
Seanamae：Glad that you see it this way.#profile: hide
Me：I'm curious, thought, do you actually believe in these mystical creatures?#profile: painter_side
Seanamae：Of course I do!#profile: hide #portrait: haiming_3_squint
Seanamae：It's impossible--and also wrong, if I may add--to contain these mysterious beings in glass tanks like tourist attractions, but they could be concrete in some other ways.#portrait: haiming_2_idle #portrait: haiming_2_think
Seanamae: Physical locations where people could visit, like Lovecraft's grave at Providence? Stories of sightings, for us all to wonder?#portrait: haiming_2_think
Seanamae: The allusion to them, which we dug out in history books; or the blurred shadows that look strangely familiar, which we spotted in old photos...#portrait: haiming_2_thinkSquint
Seanamae: These are the traces of their existence. #portrait: haiming_2_know
Seanamae：You could dismiss them as myths, but you could also piece up the evidences that'd lead you to an "unpleasant" truth.#portrait: haiming_2_seeYou
Me：Wow. I didn't expect it to be so... serious. #profile: painter_side
Seanamae：Of course it's serious! And sincere. I wouldn't say that to any customer of the shop, though.#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
Seanamae：Hey, I've been talking so much today! It's rare that I became the client here. My customers usually do the talking.#portrait: haiming_1_wink
Seanamae：Perhaps painting is also a dangerous profession, don't you think?#portrait: haiming_1_squint
Me：Dangerous, how?#profile: painter_side
//【bonus捕捉：危险的职业. 待定，没想好怎么做】
Seanamae：It's just like being a bartender. You'll know more than you should. #profile: hide #portrait: haiming_1_smile 
Seanamae: To make it fair play, how about I tell you a secret?#bgm: fade_1_0.5
Me：Oh... You have other secrets?#profile: painter_side
Seanamae：Haha, if you agree to tell me a secret in return. #portrait: haiming_1_squint #profile: hide #bgm: fade_0.1_0.1
+[Deal.]->sure
+[Ugh……]->danger

==sure==
Me：Spit it.#profile: painter_side #bgm: fade_0.2_1
->trace_scholar

==danger==
Me：Ugh………… (Please don't tell me you have a secret occupation.) #profile: painter_alert #drawingSystem: addBinaryVal_10
Seanamae：Hey, relax. Forgot how paranoid you are. What about we call it a "fun fact?"#profile: hide #bgm: fade_2_1
Me：Okay, spit it out.#profile: painter_eyeClosed #portrait: haiming_1_smile
->trace_scholar

==trace_scholar==
Seanamae：So. Beyond being a tattoonist, I'm also an ichnologist. #portrait: haiming_3_pushGlass #portrait: haiming_3_norm #profile: hide
Me: Ichnology? Let me guess, it has something to do with traces.#profile: painter_side
Seanamae: You guessed right. Ichno- is, indeed, the greek root for "trace." The subject was originally about traces left by evolution, like fossils of dinasour footprints.#portrait: haiming_3_squint #profile: hide
Seanamae: While displacement gained popularity, the discipline evolved to include traces let behind by displacement. Well, you can see it as an applied track.
Me：Hmm. That sounds interesting, I've never heard of it before.#profile: painter_side
Me：(I'm so glad she isn't an agent for BIA.)#profile: painter_sideSweat #portrait: haiming_3_norm
Me：(Painter, mathematician, now ichnologist... Aren't we birds of a feather.)#profile: painter_side
Seanamae：Not at all practical, though. You couldn't really expect us help to with displacement accidents, or anything alike. It's all rather theoretical.#portrait: haiming_2_idle #portrait: haiming_2_think
Seanamae：It is our principle that everything leaves traces. We'd forget about them easily, yet it's precisely the effort it takes to trace them back that defines human agency.#portrait: haiming_2_seeYouKnow 
Me：(Her <color=green>expression</color> looks serious now.)#showObservee: traceScholar
//【捕捉：痕迹学家
//左边：认真的Seanamaehaiming_2_seeYouKnow这个表情
//右边：“痕迹学家”——眼镜反光的睿智学者Seanamae，和一堆书卷
//描述：Seanamae现在的样子，像是个真正埋首学术的学者！只要研究“痕迹”这种课题，就能找回消失的历史吗？】
Seanamae：In addition to studying the carriers of traces - for example, the razor left in the bathroom after your husband disappeared - we also study the mechanisms of forgetting.
Seanamae：The academia only officially recognized the Ichnology of Displacement a year ago, after Clara Tracé's article “On the Application of Ichnology to Reverse Displacement.” #portrait: haiming_2_frown #profile: hide 
Seanamae: Before Tracé, everyone thought we were delusional.
Seanamae：To finish this essay, Tracé displaced almost everything. It's said that she found everything back through traces. If it's real, it's a miricle.#portrait: haiming_2_think
Seanamae：In fact, I just returned from a conference at the Geminipolis. It's the first time Ichnologists meet on the east coast.#portrait: haiming_2_know
Seanamae：Oh, an interesting fact: Carpe Diem sponsored the event.#portrait: haiming_2_thinkSquint
Seanamae：Although we couldn't really trust the company, it's good that the industry's offering support. The capitalism found value in our work, evidently.
Me：...... #profile: painter_side  #portrait: haiming_2_seeYou
Me：(Darn it. How ignorant of me.)
Me：(She's not self-claimed, like 8-2 or myself...)#profile: painter_sideSweat #portrait: haiming_2_seeYouSquint
Me：Is it like an interdisciplinary research for you, originating from the art of tattoo?#profile: painter_norm #portrait: haiming_2_seeYouKnow
Me：Like, if we see tattoo as some sort of a trace.#profile: painter_stunned #portrait: haiming_3_pushGlass #portrait: haiming_3_norm
Me：We often make them to conmemorate things that are important to us, that we'd have them engraved on our body, in case we forget.#profile: painter_norm
Seanamae：Exactly. Even if it's just a tattoo on impulse, an arbiturary day, these things will start to have meaning because you chose to have ink injected into your skin on that exact day.  #profile: hide #portrait: haiming_3_squint
Seanamae：I had to complain, though, more people have been coming to me to cover their tattoos since displacement became popular.  #portrait: haiming_3_cold #bgm: 悬疑_3 #showObservee: coverTattoo_EN
//【捕捉：覆盖纹身
//左边：“覆盖文身四个字”
//右边：戴着手套口罩，拿着覆盖纹身器械的没有感情的杀(wenshen)手(shi)Seanamae，和一些空气中消失的纹身
//描述：没想到，一名纹身师接过最多的任务是消灭过往的痕迹。覆盖纹身……就好像把历史给丢掉了。】
Me：Because we are inclined to forget.#profile: painter_stunned
Seanamae：Could you have imagined? I've covered more tattoos of names than the names I actually know in life. #profile: hide #portrait: haiming_3_pushGlass
Me：... Somewhat horrific.#profile: painter_side
Me：It's creepy to think that there are things, once so precious that you'd have it carved into your body, would someday cease to be meaningful.
Seanamae：Only the traces left on the skin could remind you of a past you'd all forgotten.#profile: hide #portrait: haiming_2_idle #portrait: haiming_2_thinkSquint
Seanamae：Unsettling.#portrait: haiming_2_frown
Me：I understand... I could relate.#profile: painter_side #bgm: fade_1_0.3
Seanamae：Oh?#profile: hide #portrait: haiming_2_seeYou 
//S note：玩的时候感觉之前的有点不自然，改了一下
Me：It's my secret, in return for yours.#profile: painter_side #bgm: 日常_1 #portrait: haiming_2_seeYouSquint
Seanamae：I'm all ears.#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_squint
Me：This is the trace... that bothers me. #profile: painter_norm #event: showScale
Seanamae：... Fish scale?#profile: hide #portrait: haiming_2_idle #portrait: haiming_2_think
 ：Seanamae carefully observes the scale. #portrait: haiming_2_thinkSquint #event: giveScale
Me：You asked in your postcard how you couldn't reach me. Yesterday, I was probably involved in a displacement accident.#profile: painter_depressed 
Me：I lost all my stuff, except for this fish scale. Don't ask me what it is.#profile: painter_eyeClosed
Seanamae：I see.#profile: hide #portrait: haiming_2_know
Me：Really? I don't.#profile: painter_eyeClosed
Seanamae：I never thought you'd become one of my potential clients. Hey, I understand you. #profile: hide #portrait: haiming_2_seeYou
Seanamae：What do you want from me, then?#portrait: haiming_2_seeYouKnow
Me：From you?
Seanamae：As the tattoonist, I could help you cover it. Forget about it altogether, even. As the ichnologist, though, I'd help you get to the bottom of it. So, what is your wish?#bgm: fade_0.2_1 #portrait: haiming_2_seeYouSquint #choiceType: OBSERVEE
+[痕迹学家(+追忆)]->findOut
+[纹身师(+遗忘)]->cover

==findOut==
Me：I'd like to get to the bottom of it.#profile: painter_side #choiceType: BUTTON #drawingSystem: addBinaryVal_20
Seanamae：I'd expect nothing less of you.#profile: hide #portrait: haiming_2_seeYouKnow
Seanamae：This fish scale is, doubtless, the carrier of trace.#portrait: haiming_2_know
Me：You'er the marine expert. Could you tell where it's from?#profile: painter_side
Seanamae：Somehow, it feels familiar, although I'm sure I'd never seen anything like it before.#portrait: haiming_2_thinkSquint #profile: hide
Seanamae：Perhaps I've met its owner.#portrait: haiming_2_know
Me：Really!?#profile: painter_stunned #portrait: haiming_2_seeYou
Seanamae：Hey, don't get all worked up yet. Just a annoying feeling of familiarity.#profile: hide #portrait: haiming_2_frown
Me：You mean...#profile: painter_surprised
Seanamae：I think, its owner may have disappeared.#bgm: 柴柴_3 #profile: hide #portrait: haiming_2_think
Seanamae：From displacement, obviously, whatever fish it was.#portrait: haiming_2_seeYou
Me：It's a mermaid.#profile: painter_depressed
Seanamae：Huh?#profile: hide #portrait: haiming_2_seeYouSquint
Me：She's a mermaid.#profile: painter_depressed
->mermaid

==cover==
Me：I'd rather forget it completely.#profile: painter_side #choiceType: BUTTON #drawingSystem: addBinaryVal_-20
Me：At least I'd stop feeling like there's something lacking in my life.
Seanamae：This scale really bothers you.#profile: hide #portrait: haiming_2_seeYou 
Seanamae：Ever thought if displacing it?#portrait: haiming_2_seeYouSquint
Me：... #profile: painter_side
Me：......I'd rather not.#portrait: haiming_2_seeYou
Seanamae：Why?#profile: hide 
Me：It's important. It's vital to me.#profile: painter_side
Seanamae：It'd be just some random fish scale after you displace it.#portrait: haiming_2_seeYouSquint
Seanamae：Perhaps you'd be freed from the oblication, or angst, you're feeling right now.#portrait: haiming_2_know
Me：...... #profile: painter_side
Seanamae：Sure, you'd feel that it's a bit of a shame. But it's not your fault that you just want to live on without the weight on your life.#portrait: haiming_2_seeYou #profile: hide
Me：Perhaps my talk about forgetting isn't really true.#bgm: 柴柴_3 #profile: painter_depressed
Me：Mermaids... I couldn't escape her. She'd come back in my dream.#profile: painter_eyeClosed
Me：Like an illusion, the ocean burnt in her eyes. Her tail gently sweeps across my fingertips. A miracle, a whisper, a lure. 
Me：Yet she blurred into the waves in an instance, exhausting my gaze...
Seanamae：Wait, wait, a mermaid?#profile: hide #portrait: haiming_2_seeYouSquint
Me：Well, I feel the fish scale belongs to a mermaid.#profile: painter_norm
Seanamae：Tell me more about the mermaid part!#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
Seanamae：Don't displace it, I beg you. At least wait till you tell me more about the mermaid.#portrait: haiming_1_laugh
->mermaid

==mermaid==
Me：I think, I guess, I don't know... Well, after I drank the water infused with this scale...don't ask me why! Anyways. I drew a mermaid.#profile: painter_side 
Me：Okay. There's hardly any evidence.#profile: painter_sideSweat
Seanamae：Could you show me the drawing?#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile #event: showEmptyHand 
Me：Sure, I happened to have it with me.#profile: painter_side #portrait: haiming_1_squint #event: getScaleBack  
Me：Here. #event: showDrawing 
Seanamae：Well, how should I put it. It's beautiful in a surprising way.#portrait: haiming_2_idle #portrait: haiming_2_know #event: giveDrawing
Me：Hey, stop the teasing. Can you think of something?#profile: painter_side
Seanamae：Mermaid is one of the most welcomed fairytales about fantastic marine life.#profile: hide #portrait: haiming_2_think
Seanamae：some believe that they are just dugongs with seaweed on their heads. There are so many rumors about them, even literature favors them.#portrait: haiming_2_thinkSquint
Seanamae：Speaking of which, there are mermaid wetsuits for sale in town.#portrait: haiming_2_think
Seanamae：Mermaid are always the consumed. their bodies always labeled with beauty, obejct of desire, fragility, like foam. Sometimes even said to be used for refining oil and lighting lamps.#portrait: haiming_2_frown #showObservee: merch_EN
//【捕捉：消费人鱼或者炼油点灯——残忍廉价的消费品
//左边：文字框“炼油点灯”
//右边：残忍廉价的消费品，罐装的紫色鱼油
//描述：炼油点灯……人鱼这样的传说生物，也从生命变成了可以消耗的商品，细想来，这是多么残忍恐怖。】
Seanamae：Unfortunately, I don't remember this purple-haired mermaid. Perhaps, when modernity has us all, I am unable to imagine beyond the so-called “mermaid shows.”#portrait: haiming_2_seeYou
Seanamae：If they exist, I hope they're never found by humans.#portrait: haiming_2_think
Me：You think I shouldn't look for her?#portrait: haiming_2_seeYou #profile: painter_side
Seanamae：Hmm, is she just a mermaid to you?#profile: hide 
Me：I wish I knew more.#profile: painter_side
Seanamae：You can have the painting back. Sorry, I've not been of much help.#profile: hide #portrait: haiming_2_think #event: showEmptyHand
Seanamae：It's a great draft for tattoos, though.#portrait: haiming_2_seeYouKnow #event: getDrawingBack 
Me：Thanks. But I deteste the idea of her being tattooed onto someone else. #profile: painter_side #portrait: haiming_2_seeYouSquint
Me：Mass-produced tattoo stickers? No thanks.
 ：“She's mine!” #profile: painter_dark #portrait: haiming_2_seeYou
Seanamae：Ahh, I see. Definitely not just a mermaid, then.#profile: hide #portrait: haiming_2_seeYouKnow
Seanamae：I sense some unusual possessiveness here.#portrait: haiming_1_idle #portrait: haiming_1_smile #showObservee: lover_EN
//【捕捉：占有欲——情人
//左边：文字框“占有欲”
//右边：Me的温柔女友人鱼小姐
//描述：占有欲？想想还真羞人，也许在潜意识里，她就是Me的梦中情人吧。】
Me：Ahh.#profile: painter_side
Me：Stop messing... #bgm: 日常_3 #profile: painter_sideSweat #portrait: haiming_1_squint
Seanamae：I'm not messing. It's an important lead. Trace. #portrait: haiming_1_smile #profile: hide
Seanamae：Physical disappearance is always accompanied by oblivion.#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
Seanamae：Oblivion is a complex matter. While everyone would lose the memory of the disappeared object, it is also very personal.#portrait: haiming_3_cold
Seanamae：You could forget about one specific fish, but you couldn't forget the category of fish, as long as there's still fish left.#portrait: haiming_3_norm
Me：What if all fish disappeared?#profile: painter_side 
Seanamae：Good questions. It makes me wonder if something similar had already happened.#profile: hide #portrait: haiming_2_idle #portrait: haiming_2_frown
Seanamae：Perhaps there's always more to the world that we just can't remember.#portrait: haiming_2_know
Seanamae：Perhaps mermaids'd gone extinct, and you were doomed with the destiny of finding the last of them?#portrait: haiming_2_seeYouSquint
Me：......#profile: painter_noComment
Seanamae：It's not it, then. Back to the specific fish, though, for everyone who'd came into contact with it, they'd forget different things about it.#portrait: haiming_3_idle #portrait: haiming_3_norm #profile: hide 
Seanamae：To continue with life, we justify ourselves.#portrait: haiming_3_pushGlass
Seanamae：You would justify the disappearance of the fish as, for instance, you didn't own fish in the first place.
Seanamae: While the one who sold you the fish would justify their memory, that you bought another fish.#portrait: haiming_3_squint
Seanamae：Perhaps you're more resistant to self-justification by nature. Therefore you can't just choose to forget.#profile: hide #portrait: haiming_3_norm
Seanamae：I have but respect for you.#portrait: haiming_3_norm #bgm: fade_0.1_0.1 
Seanamae：It is also true that we all feel, to different degrees, nolstalgic about the things we lost.#bgm: fade_0.1_1 #portrait: haiming_3_eyeClosed
Seanamae：It's hard to trace exactly who experiences the disappearance of a loved one, but cases of depression are increasing since the displacement occurred.#portrait: haiming_3_cold
Seanamae: People often feel unexplained grief, most likely caused by the sense of absence that comes with displacement.
Seanamae：Therefore, feelings--depression, possessiveness, no matter how it occurs--are also traces to the "placeholders."#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
Me：Placeholders?#profile: painter_side 
Seanamae：We're all somewhat self-centered, that we only perceive things in relation to ourselves.  #profile: hide
Seanamae：If you had a child who disappeared, you'd maintain the habit of care-taking even when you'd forgotten all about the child.
Seanamae：Perhaps you would get a pet instead.
Seanamae：This behavior of finding substitutions, or "placeholders," helps with the illusion that nothing had changed. Eases the anxiety. #showObservee: nightmare_EN
//【捕捉：对自Me的焦虑——梦魇
//左边：文字框“对自Me产生的焦虑”
//右边：梦魇柴柴，一种恐怖的女鬼
//描述：Me对那人鱼的思念，或许也来自于一种焦虑？比起浪漫和爱，她或许只是一个影响Me的梦魇。】
Seanamae：Back to the mermaid. Perhaps the reason for your possessiveness of this fish scale...#portrait: haiming_1_idle #portrait: haiming_1_smile
Me：Is that there's a placeholder for a mermaid, somewhere in my mind.#profile: painter_side 
Seanamae：Welp. Yes. According to my nonsense.#portrait: haiming_1_squint
Seanamae：These are, in fact, the hypothesis I raised in my first ichnology essay. It didn't get published because I used words like "emotion" and "attitude" without clear definition. #portrait: haiming_1_dazed
Me：It seems convincing to me.#portrait: haiming_1_squint
Seanamae：Don't take it too seriously, but I wonder, what kind of a placeholder is this mermaid to you?#portrait: haiming_1_wink #choiceType: OBSERVEE
+[东西or消费品(不加不减)]->object
+[情人(+追忆)]->lover
+[梦魇(+遗忘)]->nightmare

==object==
Me：Well, I'm not even sure it's a person.#profile: painter_eyeClosed #choiceType: BUTTON #drawingSystem: addBinaryVal_5
Me：Although I'm inclined to believe that she might've been human.#profile: painter_eyeClosed
Me：She could've been just a thing.#profile: painter_norm
Me：That I've lost in a displacement accident.#profile: painter_depressed
Me：That really isn't important in itself. Perhaps I just don't like things to change.
Seanamae：Perhaps.#profile: hide #portrait: haiming_1_sad
Me：Would that be less interesting for you? If it's just an object?#profile: painter_depressed
Seanamae：Not at all. The opportunity to reverse displacement? I could make it my PhD thesis.#profile: hide #portrait: haiming_1_smile
Me：Thrilling. Is it really possible?#profile: painter_side
->canI

==lover==
Me：I don't know...#profile: painter_sideSweat #choiceType: BUTTON #drawingSystem: addBinaryVal_30
Seanamae：Ex-girlfriend?#profile: hide #portrait: haiming_1_wink
Me：......#profile: painter_side #portrait: haiming_1_squint
Me：Sorry. It's pathetic. How I rambled, like some alchoholic asshole who talks nonsense about being penniless and non-stop about the ex. Or something.#profile: painter_sideSweat
Seanamae：No one thought so until you said it.#profile: hide #portrait: haiming_1_squintLaugh
Me：So you think so now?#profile: painter_side #portrait: haiming_1_smile
Seanamae：* sign * No, painter. I'd rather you're just the regular alchoholic.#portrait: haiming_1_eyeClosed #profile: hide
Me：...regular alchoholic...#profile: painter_side
Me：(I think I get it.)#profile: painter_eyeClosed
Me：(Did I really lost a loved-one to the void?)#profile: painter_depressed
Me：(I should probalbly be in pain, but the only thing I'm feeling now is confusion.)#profile: painter_eyeClosed
Me：Do you think there's anyway I could get her back?#profile: painter_side
->canI

==nightmare==
Me：To be honest, I'm a bit scared of her somehow.#profile: painter_eyeClosed #choiceType: BUTTON #drawingSystem: addBinaryVal_-30
Me：I don't care about the things I lost. I'd live. I could draw with found objects. But the mermaid...#profile: painter_norm
Me：...is taking away my breath.#profile: painter_alert
Me：As if I just can't go on without figuring out her myth.#profile: painter_eyeClosed
Me：I hate it. But I also can't let go.#profile: painter_eyeClosed
Seanamae：I understand.#profile: hide #portrait: haiming_1_smile
Seanamae：You want to free the mermaid, before you free yourself.#portrait: haiming_1_sad
Me：You're making her sound like some earth-bound spirit.#profile: painter_sideSweat #portrait: haiming_1_smile
Seanamae：The void could've been the same place as the underworld.#profile: hide #portrait: haiming_1_squint
Me：Darn, Seanamae, your research on mystical creatures is going a bit too diversed.#portrait: haiming_1_eyeClosed
Seanamae：Heh.#portrait: haiming_1_squint #profile: hide
Me：Seriously. If she really is an earth-bound spirit, how could I set her free?#profile: painter_side
->canI

==canI==
Seanamae：I don't know, but I have faith in you. After all, you're the painter.#portrait: haiming_1_smile #profile: hide
Me：What use is being the painter?#portrait: haiming_1_squint #profile: painter_side
Seanamae：Painters scan life. Painters create the impossible. Painters visualize beyond imagination.#profile: hide #portrait: haiming_1_smile
Seanamae：Painters gave birth to the legends that I'm so passionate about.#portrait: haiming_1_wink
Me：Hey, stop it, you're making me shy. Besides, aren't you also an artist?#profile: painter_side
Seanamae：I won't consider myself as an artist, really, because I only recreate what's already here.#profile: hide #portrait: haiming_1_eyeClosed
Me：You'll be so disappointed in me when you see the draft.#profile: painter_side #portrait: haiming_1_squint
Seanamae：Let me see. Okay. So is this...#portrait: haiming_1_smile #profile: hide
Me：Uh. It's the tail. Please, take another look after I finish...#profile: painter_sideSweat
Seanamae：Don't worry. I think it's cool.#portrait: haiming_1_squint #profile: hide
Seanamae：I'm gonna make some tea, feel free to take your time.#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
Seanamae：By the way, you can take a look at the book shelf. For inspiration.#portrait: haiming_3_squint
 ：Seanamae left.#event: haimingLeave
Me：(Seanamae has quite a collection of books. Which one should I flip through?)#profile: painter_norm #choiceType: BUTTON
+[Field Guide]->monster_book
+[Essay]->trace_essay
+[？？？]->personal_stuff

==monster_book==
Me：(Field Guide of Mysterious Creatures. Sounds interesting.)#profile: painter_eyeClosed #drawingSystem: addBinaryVal_-10
Me：(Which one should I look at first?)#profile: painter_happy
+[Reincarnation Demon]->8_2_monster
+[Deepsea Taotie]->chai_monster
+[Ghost in Masks]->xstar_monster
//+[疾行旱兽]->chiru_monster

==8_2_monster==
 : Looks like a goat, with two horns and wings on its back. The second of the seven brothers, closely tied to his compatriots. #profile: hide
 : Disappears every Monday. Constantly disappearing and reappearing.
 : Born with his brothers in a high fever, vaporizing his mother's body before birth, the embryo still unbroken.
 : was partaken of by six brothers on the first day, and was reanimated by re-conception on the second day;
 ：the second brother was partaken of on the second day, and was reanimated on the third day;
 ：the third brother was partaken of on the third day, and was reanimated on the fourth day......
 : After seven days, all the brothers experienced death and rebirth before being born from the embryo.
 ：Since then, the seven brothers have disappeared into the world one day a week.
Me: (What a story...... Why does it sound a bit familiar?) #profile: painter_sideSweat
->haiming_back

==chai_monster==
 : A monster under the waters of the deep sea with an unlimited appetite but no digestion.#profile: hide
 ：She ate too much and she vomite. She vomite. She vomite. She vomite. 
 : She ate the sea and land. She vomited and made them meaningless garbage.
 : She was crushed and chained to the bottom of the ocean, until her swollen body was transformed. She seduced her guards, and subsequently ate them.
 : She went ashore and went cruising on land every day, tempting people into the water with her body. But she must return to the depth every evening.
Me: (...what a sad story.)#profile: painter_depressed #drawingSystem: addBinaryVal_25
->haiming_back

==xstar_monster==
 : Has many faces, never shows its true face. #profile: hide
 : Herbivorous, with an unusual appetite for struggle, and the ability to “hunt.”
 ：He doesn't kill or eat his prey, but only plays with them, removing parts of them as trophies and mounting them on himself.
 ：Always happy. The Beast, a symbol of energy and hope, is an omen of good fortune.
 ：A man once dreamed of seeing its true face, so he became its attendant.
 ：He told his friends, "I will take off his mask at night!"
 ：The next day, the attendant appeared. The friend asked the attendant, "What does he look like?"
 ：The attendant said, “It is what it is."
 ：On the third day, the friend's wife fled from the room in a panic, and asked everyone where her husband was, and everyone wondered, isn't he right beside you?
 I: (So what happened to the attendant and the friend? Eh, a beast of good omen?)#profile: painter_sideSweat
->haiming_back

==chiru_monster==
 ：有翅膀，可以飞翔无限遥远的地方；有双腿，可以丈量每一寸土地。)#profile: hide
 ：曾赠予最强大的国家地图，牠去过的地方成为世界的边界，没有牠攀登不了的山峰，没有牠飞跃不了的海洋。
 ：不会水。
 ：“牠的地图里只有陆地。”
 ：“但只有前往海洋深处，才能见识这个世界的全貌。”
 Me：(牠是明智的，不然还得和饕餮水怪打一架。))#profile: painter_eyeClosed
->haiming_back

==trace_essay==
Me: (Actually, I'm quite interested in ichnology. Let's have a challenge!) #profile: painter_norm #drawingSystem: addBinaryVal_10
 : ...... Difficulties in ichnology have long been recognized as stemming from the uncontrollable nature of samples. #profile: hide 
 : “Traces” themselves are an anchor for the physical study of memory, but their credible authentication can only be traced back to a section of the Code for the Authentication of the Replacement of Individual Ownership (henceforth: DP-3x3).
 : According to the DP-3x3 criterion, certification of the validity of traces requires the corroboration of the collective memory of three moments and three or more people.
 : In the post-replacement era, the loss of memory has been relegated to force majeure.
 ：Samples of memory lack the most basic stability required for experimentation, and certification of compliance with the standard is very difficult to obtain.
 : Even the data of DP-3x3 is suspected of being falsified due to its widespread use in the determination of property disputes among the population.
 : While materialized memories require traces as anchors, the authentication of traces requires DP-3x3 records that are almost impossible to obtain.
 ：This phenomenon is a reflection of the recursive difficulties of trace research.
 : We need to develop a whole new standard, a more flexible, bold, and imaginative norm; one that goes beyond the old scientific foundations of quantitative research.
 : We need more stories, drawings, art, sounds; we need to understand traces and memory in a whole new dimension......
Me: (...... I don't seem to be as interested as I think I am.)#profile: painter_sideSweat
 ->haiming_back

==personal_stuff==
Me：(What's this?)#profile: painter_surprised
Me：(Nice cover art. An artbook, perhaps?)#profile: painter_eyeClosed
 ：(Elegent caligraphy) First day at work, everyone in the group is so friendly ^_^ #profile: hide
 ：The company is so big, there's actually a replacement aquascape track, I feel like I'm already a slave to post-Fordism…
 +[turn pages]->note1
 
 ==note1==
 ：They would go so far as to stalk the clients, it's too much...
 ：Isn't psychological value just a lie this way?
 +[turn pages]->note2
 
 ==note2==
 ：(Scratchy handwriting) Hell of a product. It's plain robbery.
 +[turn pages]->note3
 
 ==note3==
 ：Want to go back to Huanmen now, this central air-conditioned... I want to puke.
 ：What kind of flavorings do they put in the air vents?...
 +[turn pages]->note4
 
 ==note4==
 ：I want to open a tattoo shop...
 +[turn pages]->note5
 
 ==note5==
 ：(handsome handwriting) Quitted. Today. Got so drunk. The name would be "Institute of Fantastic Creatures."
+[turn pages]->note6
 
 ==note6==
 ：I love how customers talked. And hate myself for poking my nose around.
 ：Bad habbit. Can't help it tho.
 +[turn pages]->note7
 
 ==note7==
 ：Huanmen's such a bore...
->haiming_back_personal

==haiming_back_personal==
Seanamae：Painter... #profile: hide
Me：(She's back!)#profile: painter_side
Me：(Don't let her catch me going through her diary, Oops, where did I take it from...)#profile: painter_sideSweat
Seanamae：What are you reading.#bgm: 戏谑_2 #profile: hide
Me：I could explain.#event: haimingAppear #profile: painter_sideSweat 
Seanamae：Mm-hmm.#portrait: haiming_1_idle #portrait: haiming_1_squint
Me：I'm so sorry! I just liked the cover... Okay I admit I did flip through a few pages...#profile: painter_sideSweat
Seanamae：It's alright. Just read.#profile: hide #portrait: haiming_3_idle #portrait: haiming_3_norm
Seanamae：Maybe it's not such a bad thing to have one's past known? I keep my notebook with my other books, maybe waiting for the day when they'll be read. #portrait: haiming_3_pushGlass
Me：I won't tell.#profile: painter_side
Seanamae：I believe you, painter. You shouldn't dare.#profile: hide #portrait: haiming_3_squint
Seanamae：By the way, is this jacket yours?#bgm: 日常_2 #portrait: haiming_3_norm
->lost_item

==haiming_back==
Seanamae：Huh, painter...#profile: hide
Me：(Seanamae seems to be calling me. These collections are quite interesting. I'll have a chance to look at them again afterward.)#profile: painter_side
Me：What's wrong?
Seanamae：Is this jacket yours?#profile: hide #event: haimingAppear #portrait: haiming_3_idle #portrait: haiming_3_norm
->lost_item


==lost_item==
Me：Wow, I forgot all about it. Thanks. I guest I left it here last time.#profile: painter_surprised
Seanamae：Must be a few weeks before.#profile: hide #portrait: haiming_3_eyeClosed
Me：Good for me to find something that belongs to me.#portrait: haiming_3_norm #profile: painter_sideSweat
Seanamae：Aw, painter.#profile: hide 
Me：It's a bit cold in there, I'll put it on...#profile: painter_eyeClosed
Me：Hmm...
Me：There's something in the pocket...
Me：Huh?#profile: painter_stunned #event: showLighter
Seanamae：Wow, what a classy lighter. Too bad you didn't pull out a pack of cigarettes from there too.#portrait: haiming_3_pushGlass
Me：...#profile: painter_stunned
Me：I don't smoke.#bgm: fade_0.2_0 
Seanamae：Ah, I see. Well, I didn't really notice before...#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_squint
Seanamae：...Eh?#portrait: haiming_1_smile
Me：...... #profile: painter_stunned
Seanamae：...... #profile: hide #portrait: haiming_1_squint
Seanamae：So why do you have a lighter in your pocket?#portrait: haiming_1_dazed
Me：Exactly, why?#bgm: 紧张 #bgm: fade_5_0.2   #profile: painter_stunned
Seanamae：... #portrait: haiming_2_idle #portrait: haiming_2_think #profile: hide
Seanamae：Let me see it.#portrait: haiming_2_seeYou 
Seanamae：It's a mermaid.#portrait: haiming_2_know #event: giveLighter
Seanamae：Are you the guy who buys fancy lighters to light birthday candels?#portrait: haiming_2_seeYouKnow
Me：Do I look like that to you?#profile: painter_side
Seanamae：Is this your lighter?#bgm: fade_5_0.6 #portrait: haiming_2_seeYou #profile: hide
Me：I'm a little dizzy... #profile: painter_side
Seanamae：Well. There's a way to test it. If you can displace it, you own it.#profile: hide #portrait: haiming_2_think
Me：(Displace the lighter to see if I own it...)#profile: painter_side
+[Great idea.]->good_idea
+[Nooooo.]->nope

==good_idea==
Me：You're a genius, Seanamae. #profile: painter_side
Me：...... #portrait: haiming_2_seeYou #event: displaceEffect #drawingSystem: addBinaryVal_-10
Me：I can't seem to displace it.
Seanamae：That was fast.#profile: hide #portrait: haiming_2_seeYouKnow
Seanamae：Hey, if you really displaced it away, there's no need to investigate anything anymore.#portrait: haiming_2_seeYou
Me：I think it's in the fate that it stayed.#profile: painter_side
Me：Perhaps a messege from the void? "Go find the mermaid!" Or something.#profile: painter_alert
->my_past

==nope==
Me：Stop kidding, what if I really displaced it away?#profile: painter_norm #drawingSystem: addBinaryVal_10
Me：We forget about this together? Then we start our conversation today all over again?#profile: painter_eyeClosed
Seanamae：Okay. Let's spread it out. I think this lighter is key for us to trace back what happened between you and the mermaid.#profile: hide #portrait: haiming_2_seeYou
->my_past

==my_past==
Seanamae：...I seem to understand why you're so obsessed. Mermaids just keep popping out in your life.#profile: hide #portrait: haiming_2_think
Seanamae：You can't think of anything at all about where you got this lighter? #portrait: haiming_2_seeYou
Me：I can't...but it feels familiar. Perhaps a gift from someone?#profile: painter_eyeClosed
Seanamae：Self justification.#profile: hide #portrait: haiming_2_seeYouDoubt
Me：Eh?#profile: painter_stunned
Seanamae：You're justifying your memory, because you forgot where the lighter came from.#profile: hide
Me：(Man, that's true. Seanamae looks suddenly serious.)#profile: painter_side
Seanamae：The lighter might be the container of trace. Like the razor in the story with the disappeared husband.#portrait: haiming_2_think
Seanamae：Are you sure the jacket is yours?#portrait: haiming_2_seeYou
Me：I'm certain.#profile: painter_side
Seanamae：Lighters always feel intimate. Mind if I try it?#profile: hide
Me：Go ahead.#profile: painter_side #portrait: haiming_2_think
Seanamae：Hey, it's fun. Different flames appear when you press the head and the tail. Blue-purple? Amazing. Must be two different kinds of oil... #profile: hide #portrait: haiming_2_thinkSquint #event: lightUp
Me：Ew! #profile: painter_sideSweat #event: lightUp
Seanamae：What?#profile: hide #portrait: haiming_2_seeYou 
Me：Mermaid-oil lamp...#profile: painter_sideSweat
Seanamae：That kind of things don't exist! ...Oops. Said it out loud. #portrait: haiming_2_seeYouDoubt #profile: hide 
Me：Do you really believe in these creatures or not?!#profile: painter_side #portrait: haiming_2_think #event: lightUp
Me：Anyways. It's not the point...
Seanamae：Its look shows signs of use, scratches on the surface, both tubes of oil half empty.#portrait: haiming_2_thinkSquint #profile: hide #event: lightUp
Seanamae：Must be someone very close to you, right? Would carry their own lighter in your pocket.#portrait: haiming_2_seeYou
Me：Mr. Wong asked me in the morning, "you're not with your you-know-who?" Then he claimed he was mistaken.#profile: painter_eyeClosed
Me：That sounded weird.
Seanamae：*sign*... #portrait: haiming_1_idle #portrait: haiming_1_sad #profile: hide #event: getLighterBack
Seanamae：I'm sorry, painter.
Seanamae：Now we could say for sure. It is someone close to you, who had disappeared due to displacement.#bgm: 黄昏_4
Me：... #profile: painter_depressed
Me：...... #portrait: haiming_1_sad
Me：What should I do, then... #profile: painter_eyeClosed
Seanamae：Ichnology is, afterall, only theoretical. It can't help much about telling you what to do.#profile: hide #portrait: haiming_3_idle #portrait: haiming_3_cold
Me：You've met her too, right? The jacket's at your place.#profile: painter_eyeClosed
Seanamae：... #portrait: haiming_3_cold
Seanamae：As your friend, I'd suggest you let her go. You don't have to give up more in life, just to remember a faint shadow from the void.#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
Seanamae：But if you've made up your mind to trace her back, I'll do my best to help.#portrait: haiming_3_pushGlass
Seanamae：Perhaps the ultimate fantasy of an ichnologist is to follow the trails of a mermaid and retrieve true love from the void?#portrait: haiming_3_eyeClosed
Seanamae：......#portrait: haiming_3_norm
Seanamae：Looks like you've decided. Then, promise me that you won't let any trace go without close examination. Even the slightest ones.#portrait: haiming_3_squint 
Seanamae：She will come back.#portrait: haiming_3_norm #portrait: haiming_3_pushGlass
Me：Thanks...really, thank you, Seanamae.#profile: painter_side
Me：I'm sorry, I think I won't be albe to finish it today.
Seanamae：It's okay.#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
Seanamae：Painter... #portrait: haiming_1_sad
Seanamae：...
Seanamae：Can I see the draft?#portrait: haiming_1_smile
Me：... Sure... Well... It's...#profile: painter_depressed
Me：...#profile: painter_eyeClosed
+[Hand out drawing]
 ：#drawingSystem: showDrawResult #profile: none #bgm: fade_0.5_0
->END