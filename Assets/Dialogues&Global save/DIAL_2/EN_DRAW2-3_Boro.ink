INCLUDE ../global.ink
boro-chan：Here. The ice's already filled in the bowl. These are the ingredients free for use. Just start.#profile: hide #portrait: boro_2_idle #portrait: boro_welcome #bgm: 日常_0.1 #drawingSystem: addBinaryVal_50
System：Looks like the painter has an unusual commission.
System：Some clients may provide <color=green>specified materials</color> for the artwork, such as boro-chan's shaved ice creation. It must be made with ice, sauce, and ingredients.#drawingSystem: showMaterialWindow
System：The specified materials will be temporarily availiable in the list, while the painter's drawing materials <color=green>cannot be selected</color>.
System：It's not quite hygienic to use brushes and paint on food, right?
System：Choose <color=green>materials provided by boro-chan</color> and start painting!#drawingSystem: selectMaterial
Me：(Painting with shaved-ice, that's a first.)#profile: painter_norm
Me：(And I want the grand prize! That means I have to create something popular... Liked by the general public...)#profile: painter_eyeClosed
Me：(Liked... What a brutal word... How do I know what people like?!) #profile: painter_sideSweat
Me：(No time to dwell on this.) Boro-chan? What kind of ice do customers usually like?#profile: painter_side
boro-chan：Are you asking, boro-chan, what kind of ice customers like?#profile: hide #portrait: boro_1_idle #portrait: boro_1_thinking
boro-chan：What kind of ice customers like... Customers like... #portrait: boro_1_awkward #portrait: boro_1_keepScratch #profile: hide
boro-chan：How do I know what kind of ice they like!#portrait: boro_1_panic #bgm: 戏谑_0.3
Me：Huh? You don't know?#profile: painter_sideSweat
boro-chan：Why would you ask boro-chan? Why do you think boro-chan could answer you?#portrait: boro_1_keepScratchFast #profile: hide 
boro-chan：Every single day, boro-chan peeks at those popular shops... Homepages, ads, owner biographies birth signs personality types... Recipes for new product... Design concepts...#portrait: boro_1_awkward
boro-chan：What's in, what's out, there's no pattern at all!
boro-chan：Abandoned dignity and begged for good reviews on Wellp but the rating's still a mediocre, embarrassing 3.4... #portrait: boro_1_keepScratch
boro-chan：The secret to being popular, boro-chan wants to know too!! #portrait: boro_1_panic #portrait: boro_1_idle #showObservee: girl
Me：(This is strangely familiar.)#profile: painter_side 
//【收集：
//左边：冒出来的文字泡“受人欢迎的秘密，Me也很想要知道啊！”
//右边：呐喊的女高中生boro-chan
//描述：这一瞬间，老板完全就是一个渴望受欢迎的高中小女生！这、这还是在卖刨冰吗？刨冰对于她究竟意味着什么？
//】
Me：(Just like a teenage girl!)#profile: painter_noComment
Me：(Wait! I seem to get it.)#profile: painter_eyeClosed
Me：Boro-chan, is this the persona of your character?#profile: painter_side
boro-chan：...Eh?#profile: hide #portrait: boro_1_thinking
Me：You know, the attention-seeking thing, it's like a personification of the shop? Is this your market plan?#profile: painter_side
boro-chan：You mean, my angst is a persona?#portrait: boro_1_awkward #profile: hide
Me：... Sorry, I only thought it's cute.#profile: painter_side
boro-chan：I'd rather it's a persona! The whole "persona" thing sounds like what popular people at the top of the food chain would do.#portrait: boro_1_thinking 
boro-chan：Popular people -- you see them throwing money into that cool, pop store just behind me.#portrait: boro_1_shy
boro-chan："So anxious, so sad -- Not really! I just want to see people not as trendy as I am lining up to comfort me!" 
boro-chan：Ahhh!! Boro-chan wants to be like them too! Popular people with lots of love but are cold inside, what do they think about every day?
boro-chan：If I can live like that, as long as I look glamorous, it doesn't matter if I'm already rotten on the inside... Better than being a stinky dried salt fish.#portrait: boro_1_awkward #showObservee: saltFish
boro-chan：They say don't worry, love yourself, a teenage girl is great enough as long as she breathes... But what about tomorrow? Won't it be even more unattended? #portrait: boro_1_keepScratch
boro-chan：Boro-chan hides, got to hide those fishy smell, got to try harder...#portrait: boro_1_keepScratchFast
boro-chan：...Eh?#portrait: boro_2_idle #portrait: boro_1_thinking
boro-chan：Ahhhh, sorry, accidentally said my inner monologue out loud... What were we talking about? Yes, persona.#portrait: boro_2_idle #portrait: boro_2_welcome
boro-chan：Hehe, yes, it's just a persona! I don't actually worry about being popular, nor do I care about guest flow, ratings on Wellp, or likes on Z, it's just -- persona!#portrait: boro_2_turnHeadOnce
Me：...(Eh...)#profile: painter_side
Me：(I'm confused. Are we still taking about marketing the shop? Is this part of the performance?)#profile: painter_sideSweat
Me：(There's something strange about our conversation. As a truck owner who sells fish, boro-chan sounds really like a girl in middle school.)
Me：(And boro-chan's personality is all mixed up with the shop. What's going on here?)#profile: painter_side #choiceType: OBSERVEE
+[提交“咸鱼”：店铺营销罢了！土鳖+]->sells_tactics
+[提交“呐喊”：她真就是女高中生！潮流+]->really_is_teen


==sells_tactics==
Me：* sign * Boro-chan, are you're always so...#profile: painter_norm #choiceType: BUTTON #drawingSystem: addBinaryVal_-20
boro-chan：So...?#profile: hide
Me：So into the performance.#profile: painter_eyeClosed
boro-chan：...#profile: hide
boro-chan：Heh, did I scare you?#portrait: boro_2_glad #bgm: 日常_1
boro-chan：Thanks for the compliment! "persona" -- I didn't think of the word if you didn't mention it. It's working well!
Me：(So relieved she admitted it. I really can't be sure if she's performing.) I'm really impressed.#profile: painter_eyeClosed
boro-chan：* blushes * Heh, heh... #profile: hide #portrait: boro_1_idle #portrait: boro_1_shy
boro-chan：In the old days, no one thinks about likes or dislikes. But look at those KOLs on the internet... They're so pretty! I'd also love to eat whatever their hands made...
boro-chan：Who's eat the things made by my hands...#portrait: boro_1_thinking
boro-chan：But! Boro-chan is the symbol of this shop, she wants to be liked, discussed, eaten!#portrait: boro_1_shy
boro-chan：It's fun, isn't it?#portrait: boro_2_idle #portrait: boro_2_welcome
->why_boro

==really_is_teen==
Me：(Perhaps this is boro-chan's actual personality... A teenage girl who had to run a shop all on her own, must be very stressful.)#profile: painter_eyeClosed #bgm: 日常_1 #choiceType: BUTTON #drawingSystem: addBinaryVal_30
Me：(Just like our lives as artists... Life, work, business, personality, value... All mixed together.)#profile: painter_norm
Me：(Who said shace-ice creators can't be artists?)
Me：(Perhaps we don't have to make all the distinctions in life. This is Boro-chan's way!)#profile: painter_happy
Me：I'm sorry, I didn't mean to put pressure on you... #profile: painter_side
boro-chan：Oh, not at all, I'm always like this. #profile: hide 
Me：I think you're cute! People will like you, no matter in life or in business.#profile: painter_side 
Me：(...although I'm making ice right now with free ingredients. I should buy something afterwards.)#profile: painter_sideSweat #portrait: boro_2_glad 
boro-chan：He, heh.#portrait: boro_3_idle #portrait: boro_3_superShy #profile: hide
 ：The inside of the head gets a little warmer.
boro-chan：Life doesn't really matter, though. As long as the shop is popular.#portrait: boro_2_turnHeadOnce #portrait: boro_2_welcome
boro-chan：I'va past the age of craving attention.#bgm: 戏谑_1
Me：... Huh?#profile: painter_norm
Me：I thought... I thought... #profile: painter_surprised
boro-chan：What? You think I'm a little girl?#profile: hide #portrait: boro_2_glad
Me：(More like teenage girl...)#portrait: boro_2_welcome #profile: painter_sideSweat #showObservee: roughHand #choiceType: OBSERVEE_CANSKIP
//【收集：
//左边：boro-chan拿着刨冰的手(拿刨冰的那个动作)
//右边：放大的粗糙的手
//咦？这双手，并不像一般少女那样柔嫩。
//】
+[没发现]->no_discovery
+[观察鲍罗的手(土鳖+)]->hand

==no_discovery==
Me：(Is she or is she not "boro-chan"? Is it all a performance?)#profile: painter_side #choiceType: BUTTON
->why_boro

==hand==
Me：(Her hands...)#profile: painter_side #choiceType: BUTTON #drawingSystem: addBinaryVal_-15
Me：(Look really aged!)#profile: painter_sideSweat
Me：(Is she or is she not "boro-chan"? Is it all a performance?)
->why_boro

==why_boro==
Me：I'm curious, what's the inspiration for boro-chan's image?#bgm: 日常_1 #profile: painter_side
boro-chan："inspiration"? Artsy.#profile: hide #portrait: boro_2_welcome
boro-chan：I love teenage girls!#portrait: boro_2_glad
boro-chan：I want to be like her! I want to eat her!#portrait: boro_2_turnHead
Me：(Actuallty, you look like you're the one who's being eaten. By the head.)#profile: painter_sideSweat
boro-chan：This is how "boro-chan" came to life.#portrait: boro_2_idle #portrait: boro_2_welcome #profile: hide 
Me：Talking about which -- why the name? It's exactly the same with the secret sauce "boro-chan," right?#profile: painter_side
Me：Which one comes first? The sauce or the personification?#profile: painter_sideSweat
Me：It's really confusing, you know, with boro-chan selling "boro-chan"...#profile: painter_side 
boro-chan：...#portrait: boro_1_idle #portrait: boro_1_thinking #profile: hide
boro-chan：...... You can smell it, right?#portrait: boro_1_shy
Me：什么？#profile: painter_side 
boro-chan：In the pot over there, the smell of boro-chan.#portrait: boro_1_shy #profile: hide
Me：Hmm-hm. I could smell it from far away. The smell is...impressive.#profile: painter_side 
boro-chan：Stinky smell, heavenly taste. Dead fish, teenage girl.#profile: hide
boro-chan：Popular girls could also live in garbage piles. They might hate washing their hair, they might hate how they smell...
boro-chan：Every morning, I throw a lot of fish into the pot and simmer them. It's hard to keep them fresh in the heat.#portrait: boro_1_thinking
boro-chan：Add more salt? Bitter salt fish. Add more sugar? Cloying jam.#portrait: boro_1_keepScratch
boro-chan：What kind of taste do I want to preserve? It is the essence of that stinky, fishy smell.
boro-chan：You'll love it, you'll be addicted--to me, and to the stinky smell of the sauce... #portrait: boro_1_keepScratchFast
Me：--boro-chan。#portrait: boro_1_idle #profile: painter_side
boro-chan：Yes!#portrait: boro_2_idle #portrait: boro_2_glad #profile: hide 
Me：Okay. I seem to get it. #profile: painter_norm
Me：Perhaps by "eat," you mean "consume"? Teenage girls and shaved-ice are both images under consumerism, being objectified, rendered objects that could be bought, owned, with money.
Me：You want the sauce to stay stinky, because the idea "teenage girls should all be sweet and innocent" is nothing but a stereotype, a shackle.#portrait: boro_1_idle #portrait: boro_1_thinking
Me：I get it! The shop looks pink and sweet, but the stinky smell contrasts this image. You have to really taste and feel to understand, to love her!#showObservee: concept
//【收集：
//左边：理念-画家对boro-chan理念的bulabula学术文字铺满背景，具体内容参考上文(或者其他表达方式)
//右边：高级、时尚、独立的boro-chan招牌，以潮人们最喜欢的形式出现。或者是网上帖子标题。里面有boro-chan的形象。
//描述：打破对少女们甜美无害的刻板印象，迎接真实的自Me——这一定就是boro-chan的核心理念！哦，自由的她简直就是少女们的偶像！
//】
boro-chan：Oh.#profile: hide 
Me：Did I get it right?#profile: painter_side 
boro-chan：Well, I don't know, I just like stinky tofu.#profile: hide #portrait: boro_1_shy #portrait: boro_1_idle 
boro-chan：I just thought that we should have a stinky shaved-ice. And here you can get seafood for low prices.#showObservee: tofu
//【收集：臭豆腐的念头
//左边：boro-chan思考文字泡里面有个臭豆腐
//右边：非常土的boro刨冰招牌/广告。里面有boro-chan的形象。】
//描述：刨冰界自己的臭豆腐……臭豆腐……原来boro刨冰是这么接地气的产品改良？一下子格调就变了。】
Me：......... #profile: painter_sideSweat
Me：Right...#profile: painter_eyeClosed
Me：(It's hard. One second she's talking metaphysics, the next she'd say something so down-to-earth.)#portrait: boro_1_thinking
boro-chan：How to become popular? I tried to sell regular ice, the sweet ones, but no one really liked them.#profile: hide #portrait: boro_2_idle #portrait: boro_2_welcome
boro-chan：The ice I invented, with fish on top of the ice, what does it look like to you>#choiceType: OBSERVEE
+[高级刺身拼盘(提交理念)(潮流+)]->sashimi
+[海鲜市场水产(提交臭豆腐)(土鳖+)]->vendor

==sashimi==
Me：Like sashimi platter from some chic cuisine.#profile: painter_side #choiceType: BUTTON #drawingSystem: addBinaryVal_30
boro-chan：People are willing to spend so much money for sashimi platter. They're just sliced fish.#profile: hide 
boro-chan：Only "good" fish could be made into sashimi.
boro-chan：Is my fish ice "good" fish?#portrait: boro_1_idle #portrait: boro_1_thinking
->displacement_time


==vendor==
Me：Like fish vendor from seafood market.#profile: painter_side #choiceType: BUTTON #drawingSystem: addBinaryVal_-30
boro-chan：Ha! Vendors at the market use ice only to keep the fish fresh.#profile: hide #portrait: boro_2_turnHeadOnce #portrait: boro_2_welcome
boro-chan：Me, I sell them. They're the main part of the shaved ice.
boro-chan：Do you think that makes me a shady fish vendor?#portrait: boro_1_idle #portrait: boro_1_thinking
->displacement_time

==displacement_time==
boro-chan：Values -- too elusive in the era of displacement.
boro-chan：When we want ice, we just displace them at home.
boro-chan：Once you know how to make the ice, you can displace it directly from the void. The ingredients are so cheap, why pay for the work?#portrait: boro_1_awkward
boro-chan：The regular ice -- mango, pineapple? No one would buy them anymore. Get them through displacement, with absolutely fair prices.#portrait: boro_1_thinking
boro-chan：When everyone starts to do that, what happens to our shaved-ice shops? What should I sell for a living?#portrait: boro_2_idle #portrait: boro_2_welcome
Me：Ice that couldn't be displaced out of the void?#profile: painter_side
boro-chan：Exactly! People could only displace things they could imagine. What I sell, is beyond imagination.#profile: hide #portrait: boro_2_glad
boro-chan：In this era, that's how we survive--selling imagination.#portrait: boro_2_welcome
boro-chan：You ever been to the pop shop behind? I learned from it.#portrait: boro_2_escape 
Me：I see, so that's why you're obsessed with popularity. (Only that boro-chan's image is quite classical...)#profile: painter_side
Me：(Is this really trendy?)#profile: painter_sideSweat
Me：But how do you ensure that? How do you know people can't imagine it?#profile: painter_side 
boro-chan：Because, I sell boro-chan, boro-chan is me. Heh.#portrait: boro_2_welcome #profile: hide 
boro-chan：No on can really understand me in this world. That's my biggest advantage.#portrait: boro_2_glad #bgm: pause 
 ：boro-chan sounds cheerful.
 ：All people could see is the head with an eternal smile.
boro-chan：Do you know why the shop is pink?#bgm: play
+[Cute?]
Me：Because it's kawaii?#profile: painter_side
boro-chan：Pfft, Kawaii?#profile: hide 
->pink
+[Warm?]
Me：Pink is warm, makes people feel welcomed?#profile: painter_side 
boro-chan：Heh.#portrait: boro_1_idle #portrait: boro_1_shy
boro-chan：But it's the summer, is warm a bad thing? Would I lose customers because of this? Ahhh...#portrait: boro_1_awkward #portrait: boro_1_keepScratch
Me：It's not that warm!!#profile: painter_side 
boro-chan：Whew. #portrait: boro_1_idle #portrait: boro_1_thinking #profile: hide 
->pink
+[Wild?]
Me：Pink is powerful. Like blood.#profile: painter_side
boro-chan：Powerful? Hmm. Yes, just like blood.#portrait: boro_1_idle #portrait: boro_1_thinking #profile: hide
->pink

==pink==
boro-chan：I see pink more often than any other color.#portrait: boro_1_idle #portrait: boro_1_thinking #bgm: 柴柴_3
boro-chan：People often forget that fish also bleed.
boro-chan：Blood, in the ocean, in the ice, diluted by water, turns into a light pink. #portrait: boro_1_shy
boro-chan：Pink is the color of a wounded fish.
Me：(Wait...)#profile: painter_stunned
Me：Why would you know that?#profile: painter_surprised #bgm: fade_0.1_0
boro-chan：Eh? Why, why wouldn't I?#profile: hide #portrait: boro_1_keepScratch
Me：(Last night, I drew a mermaid...peeling scales, bleeding fish, bleeding... I was... Ah! My head aches...)#profile: painter_eyeClosed 
Me：Why would you know so much?#profile: painter_alert #portrait: boro_1_keepScratchFast #bgm: 紧张_1 #bgm: fade_0.1_0.2
boro-chan：What are you taking about? Why wouldn't I?#portrait: boro_1_panic #profile: hide 
boro-chan：My job involves cutting up a lot of fish? On daily basis.
Me：Fish?#profile: painter_alert 
boro-chan：What...what about fish?#profile: hide #portrait: boro_1_keepScratchSuperFast
Me：(She is nervous. Why is she nervous?)#bgm: fade_5_0.7 #profile: painter_stunned
Me：Fish. Fish. Fish.#profile: painter_alert
boro-chan：You...you want more fish? Let me get them... #profile: hide 
Me：Who are you?#profile: painter_alert 
boro-chan：... #profile: hide #portrait: boro_3_idle #portrait: boro_3_silence 
Me：Who are you?#profile: painter_alert
boro-chan：...... #profile: hide 
Me：Do you know the mermaid? #bgm: fade_4_1 #profile: painter_alert
Me：Have you ever seen a mermaid?#portrait: boro_3_shiver 
Me：I... I had a dream... No, I remember a mermaid. In this town. I have to find her. Do you know about her?#profile: painter_depressed
boro-chan：............#profile: hide 
Me：Please say something?#profile: painter_frightened
Me：Oh! I have a fish scale here, could you please take a look?#profile: painter_stunned
boro-chan：Ahhhhhhhhh NO!#profile: hide #portrait: boro_2_idle #portrait: boro_2_escape
Me：Please!!#profile: painter_alert
boro-chan：i don't i don't...#profile: hide #portrait: boro_2_turnHead #portrait: boro_noEXPR
// 这里动画不知道为什么不work
Me：Beg you!!!#profile: painter_angry #event: showScale
boro-chan：i don't i don't i don't i don't... #profile: hide #portrait: boro_2_turnHeadFast 
boro-chan：......quack.#portrait: boro_3_idle #portrait: boro_3_silence #bgm: fade_1_0
boro-chan：ah. I see.
boro-chan：...
boro-chan：...... Oh.
Me：You recognize it? #profile: painter_side 
boro-chan：Well I don't.#portrait: boro_2_idle #portrait: boro_2_glad #bgm: 日常_0.2 #bgm:fade_0.2_1 
Me：Really?#profile: painter_side
boro-chan：Why would I lie about this?#profile: hide 
Me：Okay, but you make fish! You have no idea what kind of fish this is?#profile: painter_side 
boro-chan：Huh, I thought you said mermaid.#profile: hide #portrait: boro_1_idle #portrait: boro_1_thinking 
Me：It's just my guess... After all, we don't even know if mermaids exist.#profile: painter_sideSweat
boro-chan：I've never seen a scale like this before. Either it's one of the really expensive ones, or it's not a fish at all.#profile: hide 
Me：Not a fish? #profile: painter_alert 
boro-chan：You know how people would use food dyes to make food look attractive and gorgeous? You're the painter, must be good at something like this.#profile: hide 
Me：The scale is exactly like this when I found it.#profile: painter_eyeClosed
Me：(Boro-chan's panic from earlier completely disappeared.)#profile: painter_norm
Me：Boro, can I trust you?#profile: painter_side 
boro-chan：Of course! Boro-chan is sincere, trustworthy!#profile: hide #portrait: boro_1_keepScratch #portrait: boro_1_panic
Me：... Who exactly are you?#profile: painter_side #portrait: boro_1_keepScratchFast #event: hideScale
boro-chan：...... #profile: hide #portrait: boro_3_idle #portrait: boro_3_silence
Me：...I remember a mermaid from my dream.#profile: painter_eyeClosed
Me：A wounded mermaid, her blood dissolves in the sea.
Me：I miss her.#profile: painter_depressed
boro-chan：You don't think I'm your mermaid?#profile: hide #portrait: boro_3_headUp #bgm: fade_1_0
Me：... #profile: painter_depressed
boro-chan：Psst.#profile: hide #portrait: boro_2_idle #portrait: boro_2_welcome #bgm: fade_1_0.3
boro-chan：That's definitely not me. I promise.#portrait: boro_2_glad
boro-chan：Okay?
Me：...#profile: painter_side
+[Okay.]
Me：Okay.#profile: painter_eyeClosed #bgm: fade_1_1
boro-chan：Pinky swear!#profile: hide #portrait: boro_2_turnHead #portrait: boro_noEXPR 
boro-chan：I am boro-chan, stinky smell~heavenly taste~~boro-chan!#profile: hide 
->back_to_boro

+[Don't understand.]
Me：I don't understand.#profile: painter_eyeClosed
boro-chan：Don't you get it? Boro-chan is only boro-chan, stinky smell~heavenly taste~~the only~boro-chan!#profile: hide #portrait: boro_2_turnHead #portrait: boro_noEXPR #bgm: fade_1_1
->back_to_boro

==back_to_boro==
boro-chan：Don't you dare forget me again~❤ #portrait: boro_2_idle #portrait: boro_2_welcome
Me：Fine, Boro.#profile: painter_sideSweat #portrait: boro_2_glad
Me：(I'm pretty much done with the ice.)#profile: painter_side #portrait: boro_2_welcome 
Me：(Is it going to be popular? I have no idea. More confused about popularity, after the mysterious conversation with boro-chan.)
Me：(Food isn't like oil painting that could be modified over and over again. It's like watercolor, you can't add more when it's full.)
Me：(Let's wrap up this painting...this bowl of shaved-ice!)
Me：Boro, I'm finished. The last step would be-- #profile: painter_norm
boro-chan：Here!#profile: hide #portrait: boro_2_glad
Me：That's it!#profile: painter_laugh
+[Squeez boro-chan sauce]
 ：#drawingSystem: showDrawResult #profile: none #bgm: fade_0.5_0
->END