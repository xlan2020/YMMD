INCLUDE ../global.ink
Me：......#profile: painter_side #portrait: 8-2_norm
8-2：......#portrait: 8-2_raiseEyebrow #profile: none
Me：So. All my drawing materials are gone.#profile: painter_sideSweat
Me：I probably can't draw. I mean, without my supplies.
8-2：You're literally penniless, painter. You always surprise me.#bgm:日常 #portrait: 8-2_laugh #profile: none
8-2：But you can't draw without <color=magenta>drawing materials</color>?#portrait: 8-2_smile
8-2：You <b>used to</b> be better than that.#portrait: 8-2_admire
8-2：Why don't you look around first? Is there really nothing you could use to draw?#portrait: 8-2_smile
Me：(Huh. Tissue paper, pencil, soy sauce... These could work!）<color=green>*Click to pick up items on the table*</color>#profile: painter_surprised #drawingSystem: showMaterialWindow
 ：The collected <color=magenta>items</color> could be used as <color=magenta>drawing materials</color>--canvas, brush, and paint. #profile: hide
 ：Note that there are special items that cannot be used as drawing material.
 ：Each time you use an item, its <color=magenta>durability</color> will be reduced by 1 point. When the <color=magenta>durability</color> is cleared, the item will <color=magenta>break</color>.
 ：Some of the brushes include paint. Using them would cost 2 durability points.
 ：As an item's durability reduces, its displacement value will change.
Me：(These stuff are good enough for doodling, but for a commission...) Is it really okay with you if I paint with soy sauce? #profile: painter_side 
8-2：Of course! Play around and blow me away with something that isn't boring.#portrait:8-2_laugh #profile: none
 ：Different drawing materials will have different effects on the image, with four attributes--stable, organic, experimental, and premium. #profile: hide
 ：Using materials with different attributes will affect the earnings of the current commission. Try to pick something according to the client's preference!
 ：You can now choose the drawing material.
Me：(If "<color=magenta>blow me away</color>" count as a demand, I should probably use some <color=magenta>experimental</color> materials. Of course, the choice is still mine. There's nothing smoother than pencils after all.)#profile: painter_side #drawingSystem: selectMaterial
->select_material_and_draw

==select_material_and_draw==
Me：(The materials I have now are still too limited, let's make do with what we have. Should be enough with 8-2 anyways.）#profile: painter_norm #portrait: 8-2_norm2
Me：（...I just sounded like I know 8-2 well? Weird. Now, let's decide what to draw.)#profile: painter_side
Me：Portrait, right？#profile: painter_norm 
8-2：The usual. Of course.#portrait: 8-2_smile2
8-2：......#portrait: 8-2_cold
8-2：What are you doing with your brush? Don't tell me you're going to fool me with a quick sketch.#portrait: 8-2_raiseEyebrow
8-2：Stop! You should express your deeeeeep understanding of me. As you used to say, "Drawing is the accurate description of an object!"#profile: painter_eyeClosed
8-2：I don't want to see what's in front of you right now, but the essential ME, the ME from before, the <b>real</b> ME.#profile: painter_noComment #portrait: 8-2_deepLove
Me：Eh, like when you were younger?#profile: painter_side
8-2：......... #portrait: 8-2_norm3 #bgm: fade_2_0.2
Me：......#profile: painter_sideSweat
Me：My apologies.
8-2：*sigh*Take it slowly.#portrait: 8-2_smile2
Me：(...perhaps I am being a bit too hasty.)
Me：(The first step of drawing is <color=magenta>observation</color>. Besides the rigid proportionality, I should capture the essence of my <color=magenta>object</color>.)
Me：(Observe 8-2 closely. Is there anything worth <color=magenta>capturing</color>?）
 ：In the process of drawing, <color=magenta>observation points</color> that can be captured would occur on the screen. #profile: hide
 ：Click the <color=magenta>left mouse button</color> on an observation point and <color=magenta>drag</color> it into the <color=magenta>conception window</color>, the observation point will be transformed into an <color=magenta>inspiration</color>.#showObservee: face
 ：The painter may hold multiple inspirations at the same time. In this case, you should choose carefully. The inspiration you choose will change the outcome of the painting. It also determines the painter's attitude towards the client, therefore changing the story between them.#portrait: 8-2_norm2
 ：Present the inspiration on the <color=magenta>canvas</color> to continue drawing.
 ：The canvas is lighted up. Try dragging and dropping the inspiration onto the canvas!#choiceType: OBSERVEE
+[Submit]->mama_appears
==mama_appears==
Me：(Let's observe him to the finest details... Mama! My meal!）#drawingSystem: addBinaryVal_10 #choiceType: BUTTON #profile: painter_happy
Mama：Enjoy!#profile: mama_satisfied  
Mama：Hey, is that your friend? Wait, I know you, you're...MASTER EIGHT PLUS TWO!!#bgm:戏谑_0.5
8-2：*cough*Eightminus Tue, sis.#portrait: 8-2_smile2
Me：(Pssss...master eight plus two also sounds fine.）#profile: painter_sour
 ：Sounds, words, and smells could also provide vital information for conceptualizing the painting. Observation points could occur anywhere on the screen.  #profile: hide
 ：You need to capture some of the observation points to continue drawing.
Mama：Yes, of course, excuse my bad memory, MASTER, such a pleasure--my lover is absorbed by your lectures!#profile: mama_satisfied #showObservee: master_EN
 ：In addition to mandatory observation points, there are also optional ones that could be <color=green>missed</color> as the dialog develops, limiting the direction of the story. 
 ：Missing isn't necessarily a bad thing, but you could always look out for an unexpected observation point when the canvas lights up and submit it <color=green>in one drag-n-drop</color>. 
 ：That's all about observation points--don't forget to catch them if you can!
Mama：I was so worried when he quit the fishing job, but thanks to our master here, we're rich now. #profile: mama_satisfied
Mama：Ah, by displacement, our earnings tripled! You saved my family, master...
8-2：You're welcome, sister. Me, I don't have many hobbies. I just enjoy helping others so much. #portrait: 8-2_deepLove
Mama：Such kind-hearted, master. Here's our best Oolong tea, just for you! Let me know what you'd like for dinner, I'll give you 40% off everything.
8-2：Only have to pay Sixty percent for everything? Ha, I really should've changed my name to Eightminus Seven.#portrait: 8-2_smile2
Mama：Hahaha... Master, that was a very cold joke.
Mama：Please take your time to look at the menu, call me if you need anything.
8-2：Heh, look at my lovely fans! Maybe I should start paying attention to my public image.#bgm:日常_5 #profile: painter_side #portrait: 8-2_laugh
8-2：...No shit bro, you've already wolfed it all down?#portrait: 8-2_surprised
Me：I was hungry... Now I'm full.#profile: painter_sideSweat
Me：(Eating while taking a commission was unprofessional. I should really start concentrating on the object.）#choiceType: OBSERVEE
+[Submit: master]->profession_mathematician

==profession_mathematician==
Me：So, what does "master" do for a living?#profile: painter_norm #drawingSystem: addBinaryVal_20 #choiceType: BUTTON
8-2：I'm a mathematician.#portrait: 8-2_smile
Me：You taught Mama's lover...maths?#profile: painter_side
8-2：Oh, that's just a part-time job. Maths is a fundamental subject. Numbers are the basic units that make up the world.#portrait: 8-2_norm2
8-2：1 means is, 0 means is not.
8-2：1 is true, 0 is false。#portrait: 8-2_smile
8-2：Studying existence and truth is my occupation. Just like you're a painter, I'm a mathematician.#portrait: 8-2_deepLove
Me：(That sounds crazier than my "inquiry into the nature of art".) You mean that you're self-appointed. #profile: painter_norm
Me：This talk about 1 and 0 sounds familiar, isn't that called numerology or something?
8-2：Well, well, that's your understanding? Shallow, ah.#portrait: 8-2_laugh
8-2：Numbers are crucial! Look at what's on top of your head, yes, <color=green>right in the middle</color>--that's a very important number.#portrait: 8-2_smile2
Me：(A very important number... Huh? Does "on top of my head" mean...the <color=green>middle number above</color> everything? I'd submit it directly to the drawing if I can find it...)#profile: painter_stunned #showObservee: moneyAmount #choiceType: OBSERVEE_CANSKIP
+[ ]->where_is_number
+[ ]->found_number

==where_is_number==
Me：A number on my head? Don't be ridiculous.#profile: painter_noComment #choiceType: BUTTON
8-2：Gee, isn't it {money}! Can't you see it?#portrait: 8-2_smile
Me：Huh? {money}, that's...#profile: painter_stunned #bgm:pause
Me：That's the amount of money in my wallet!#profile: painter_frightened #portrait: 8-2_laugh #bgm:戏谑_0.5
Me：How in the world did you know that?#profile: painter_surprised
8-2：Told ya, I'm a mathematician.#portrait: 8-2_mysterious
Me：You're really something.#profile: painter_happy
Me：(I'm pretty sure he peeked at my wallet when I was going through my bag. You can't be too careful with scams these days.)#profile: painter_norm #bgm:日常_3 
->value_number

==found_number==
Me：The number on top of my head... {money}?#choiceType: BUTTON
Me：But how did you know? That's the ammount of money in my wallet!#bgm:戏谑_0.5 #profile: painter_frightened #portrait: 8-2_smile #drawingSystem: addBinaryVal_30
8-2：Oh~ So that's how rich you are.#portrait: 8-2_laugh
Me：...Huh?#profile: painter_side 
8-2：Now I know, painter, now I know.#profile: painter_sideSweat 
Me：......
Me：You liar!#profile: painter_mad 
8-2：Nope, I'm just a mathematician.#portrait: 8-2_mysterious #bgm:日常_3
->value_number

==value_number==
Me：That's not maths.#profile: painter_side 
8-2：Of course its' maths. There were a lot of meaningful numbers in one's life, but now there's only one left.#portrait: 8-2_norm2
8-2：The one that represents <color=magenta>value</color>.#portrait: 8-2_norm3
8-2：It's on top of everyone's head, on top of everything. I'm not talking about a price tag. bro. #portrait: 8-2_smile
8-2：You'll recognize that number when you see one--the elusive one, the one that's unique to everyone.
8-2：Yes! I'm talking about the mythical <color=magenta>value to you</color>. When you displace something, you'll receive that number in cash.
8-2：It's just a number, yet no one can see it clearly.#portrait: 8-2_thinking
8-2：That's where my Displacement to Success lecture comes in. You catch what I mean?#portrait: 8-2_smile2
Me：Uh-huh, You're a part-time scammer.#profile: painter_side #portrait: 8-2_laugh 
Me：(And he laughed when I called him a scammer! Look at <color=green>his smile</color>, how could anyone be so brazen?)#showObservee: evilSmile
Me：I can't believe you have the nerve to claim that you study the truth. Gosh, you should apologize to Mama.
8-2：Mind your language, painter, how could you call that a scam?#portrait: 8-2_norm
8-2：Few people know what they want and what they can afford to lose. They'd end up displacing everything for nothing.#portrait: 8-2_thinking
8-2：I'm just helping them to grasp their fate with their own hands.
8-2：Speaking of which, painter, let's open up. I can feel it--did something similar happened to you?#portrait: 8-2_deepLove
8-2：If you know yourself better, you wouldn't have ended up in a mess and still know nothing.#showObservee: deepLove
Me：......#profile: painter_side
Me：(When I think about it this way, I did wake up in a weird way today.)#profile: painter_sideSweat
Me：(This dude obviously knows a lot about displacement. Should I listen to what he had to say?)#profile: painter_norm
 ：There are two different inspirations at hand, and you'll have to make a <color=magenta>choice</color>.#profile: hide 
 ：Choosing different inspirations would determine how the painting looks like as well as the painter's<color=magenta> interpretation</color> of the subject - did you notice the slide bar on the right? That is the painter's evaluation. 
 ：The choice decides the future stories, while the evaluation changes naturally as the dialogue goes. 
 ：Eventually, the painter will make <color=green>different drawing</color> depending on this value.
Me：(I have to make a choice here... Can I trust 8-2?)#choiceType: OBSERVEE #profile: painter_norm
+[Help me, master]->teach_me
+[There's something wrong with this guy!]->reveal_liar

==teach_me==
Me：Actually, something weird happened to me today. Would you give me some advice?#profile: painter_sour #drawingSystem: addBinaryVal_50 #choiceType: BUTTON
8-2：Sure, what happened?#portrait: 8-2_chuckle
Me：(Did he just smile?)#portrait: 8-2_norm2
Me：I woke up today and found my appartment empty. Everything's gone, along with all my money. The worst part? I don't remember a thing.#profile: painter_eyeClosed
8-2：Tsk, failed displacement. Displacement accident.#portrait: 8-2_thinking
Me：Perhaps. But there should be something coming out of the displacement, right? I'm still confused.#profile: painter_side
8-2：You didn't find anything at all?#portrait: 8-2_norm2
Me：Hmm, I did find something.
Me：Here it is. It's, I think, a fish scale.
8-2：It should be something very, very significant to you, right?#portrait: 8-2_deepLove
Me：Well, it feels like yes, but I have no idea what it is.
8-2：Yo bro it looks familiar to me.#portrait: 8-2_thinking
Me：Really?!#profile: painter_surprised
8-2：Eh my eyes hurt, can I take a closer look?#portrait: 8-2_chuckle
Me：(Right, he must be nearsighted since he wears that huge <color=magenta>pair of glasses</color>.)#profile: painter_norm #showObservee: glasses #choiceType: OBSERVEE_CANSKIP
+[hand the scale to 8-2]
Me：(I need to know what it is.)#profile: painter_norm #drawingSystem: addBinaryVal_20 #choiceType: BUTTON
Me：Please take a good look.*hands over the scale*#profile: painter_side
8-2：*takes the scale*Yes, yes, let's see...#portrait: 8-2_norm
8-2：......#portrait: 8-2_serious
8-2：.........Opps!#portrait: 8-2_surprised #bgm: fade_2_0.3
8-2：Hands slipped! Where did it go?#profile: painter_stunned #portrait: 8-2_norm #portrait: 8-2_surprised
Me：What the... You handle such an important object like that? Let me see, did it fall on the floor...#profile: painter_frightened #bgm: fade_1_0.1
8-2：Hey, it has fallen into my other hand.#portrait: 8-2_smile2
Me：HUH?#profile: painter_surprised
8-2：Gotcha! Hahaha~#profile: painter_noComment #bgm:戏谑_0.3 #portrait: 8-2_laugh
8-2：Don't be too gullible, painter, it's dangerous. Don't easily hand over something so important to other people.#profile: painter_angry #portrait: 8-2_smile
8-2：I took a good look at it, it's... A fish scale! I'm not sure which type of fish it's from, why don't you ask Mama's lover? He's pretty good at fish stuff.#portrait: 8-2_smile2
Me：......just give it back.#profile: painter_mad
8-2：Okay, okay, here you go. I was just kidding, don't be angry.
8-2：......#profile: painter_angry #portrait: 8-2_norm2 #bgm:日常_5
8-2：*talks to himself* Am I really that obnoxious? Oh my, it's gonna drop from 0.5 to 0.2... No, even lower...#portrait: 8-2_thinking2 
8-2：No way, 0.15?#portrait: 8-2_raiseEyebrowLookAway
Me：(This dude is definitely not trustworthy, I shouldn't have trusted him.）What are you mumbling about?#profile: painter_side #drawingSystem: addBinaryVal_-40
->owning_value
+[Observe the glasses]
Me：(...Wait! Taking a closer look, the frames of these glasses are too thick, and his eyes behind them did not shrink at all.)#profile: painter_stunned #drawingSystem: addBinaryVal_-20 #choiceType: BUTTON
Me：(This is simply a pair of decorative flat glasses, isn't it?)#profile: painter_noComment
Me：(His eyes are sparkling with shrewdness!)#profile: painter_norm
Me：(I could smell conspiracy brewing.) Forget it, I'll figure it out myself.
8-2：What, you won't let me take a look?#portrait: 8-2_norm2
8-2：Sure, okay, I knew you didn't trust me. Gee, it's hard to get the value up.#portrait: 8-2_thinking
8-2：It should be 0.3 now? Or is it 0.2? I'll take it 0.25...#portrait: 8-2_thinking2
Me：(This confusing weirdo...) What are you mumbling about?#profile: painter_side
->owning_value

==reveal_liar==
Me：So, are you selling me your lectures?#profile: painter_side #bgm:fade_0.2_0.5 #drawingSystem: addBinaryVal_-30 #choiceType: BUTTON
Me：First pretending to know me, then pay me to draw to convince me that you're not a scammer... Ha, no one wants to buy my painting except scammers.#portrait: 8-2_norm2 #bgm:悬疑_1
Me：Then you used Mama's trust to establish the image of a "master," luring me to ask you about the lectures... Gosh, Mama can't be your trustee, right?
Me：Then you deliberately took "mathematician" as an analogy of "painter," trying to pull me closer.
Me：Worse, you peaked into my wallet when I was looking for drawing materials and memorized that number to shock me and make yourself look smart.
Me：Let's guess what should follow--it's time to sell me some lectures, isn't it? If I say that I don't have the money, don't tell me you're not going to recommend an "acquaintance" who can lend me some.#portrait: 8-2_norm
Me：Okay, I admit, you scammers are quite powerful, almost fooled me. One advice though--quit, bro.#profile: painter_angry
8-2：Bravo! That's some deduction there, although with wrong premises. It's good to see you grow more intelligent though.#portrait: 8-2_smile2 
8-2：I have to write it down...Painter, -0.5...#portrait: 8-2_thinking2
Me：What are you mumbling about? I'm telling you, I don't trust you at all.#profile: painter_side
Me：Take your money back if you like.#portrait: 8-2_norm2
8-2：Hey, painter, such a noble person who won't take money from a "scammer."#portrait: 8-2_smile2
8-2：That was a deposit for a painting. I still want the painting, you're not reneging on your words, right? #portrait: 8-2_norm
Me：(A scammer lecturing me on reneging?) Okay, fine, I'll capture your <b>true self</b>.#profile: painter_norm #bgm:日常_5
Me：Promise that you'll pay the rest when I give you the painting.#profile: painter_selfMock #portrait: 8-2_norm2
8-2：Come on, painter, stop being so sensitive.#portrait: 8-2_unhappy 
8-2：Looks like -0.5 isn't low enough. -0.6? No, that's a negative number...#portrait: 8-2_thinking2 
Me：(What's he mumbling about? Anyways, it's obviously a trap. Concentrate on finishing the painting...)#profile: painter_side
8-2：-0.55. Infinitely close to 0...#portrait: 8-2_raiseEyebrowLookAway
Me：(Don't be curious... Don't...)
Me：... What on earth is that you've been mumbling about?#profile: painter_side
->owning_value


==owning_value==
8-2：Heh, I'm glad that you finally asked. It's the second important number in life.#portrait: 8-2_smile2
8-2：I call it <color=magenta>ownership</color>.#portrait: 8-2_norm2
Me：(U'm just too curious...) What does it mean?
8-2：Do you know the trick of displacement? I mean, the key that determine the success of the displacement.#portrait: 8-2_smile
Me：Equal value?
8-2：That's not all. Say, I think my boss's car worths a lot of money, and I want to displace it for cash. Would it work?
Me：Of course not, the car's not yours.
8-2：BINGO! You can't displace something that's not yours.#portrait: 8-2_smile2
Me：Tell me something that's not as apparent.
8-2：Have you ever wondered how the system of displacement-let's say it's a system-determines if something belongs to you?#portrait: 8-2_smile
+[Law?]
Me：Same as the law?
8-2：You mean the system is connected to legislature? Pfft, classic.#portrait: 8-2_laugh
Me：(...When I think about it, it feels more natural.)
->owning_continue
+[Scent?]
Me：Something like scent? Like how cats mark and recognize their belongings through smell...
8-2：You mean pheromones?#portrait: 8-2_smile2
Me：Something like that.
8-2：Pfft.#portrait: 8-2_chuckle
8-2：You mean the system judges whether an object is yours through your pheromones. Hahahahaha! Did you learn that from some ABO fanfic?#portrait: 8-2_laugh
Me：(Shit. I sounded stupid.) You said pheromones, I didn't.
8-2：Okay, okay.#portrait: 8-2_chuckle
->owning_continue
+[Fingerprints?]
Me：Fingerprints? I mean, like in detective mystery, you identify the owner of an object by examining the fingerprints left on it.
8-2：Do you mean <color=magenta>traces</color>?#portrait: 8-2_smile2
Me：Yes, traces!
8-2：*talks to himself* The Jill of All Traces is coming back in town soon. This is a very important concept in displacement, but it's still not the answer.#portrait: 8-2_thinking2
->owning_continue

==owning_continue==
Me：*sigh* I guess you'll tell me that your answer is "ownership."#portrait: 8-2_norm2
Me："Ownership determines an object's ownership" - that's still crap.
8-2：That's a fact. Say, do objects know to whom they belong to?#portrait: 8-2_smile
8-2：Of course not. How ever you question your boss's car, it will not respond.#portrait: 8-2_smile2
8-2：But everyone knows that the car belongs to your boss. So it is.#portrait: 8-2_smile
8-2：The concept of "ownership" is created, defined, and used only by humans.
Me：Don't be so humancentric, animals could feel like they own something too.
8-2：Fine, humans and animals. In short, ownership is a unwritten rule in the society.#portrait: 8-2_smile2
8-2：Displacement knows, displacement is as clever and as stupid as humans. If you want to own something, here's the only way.#portrait: 8-2_smile
8-2：<b>Make everyone believe that you own it</b>.#portrait: 8-2_smile2
Me：I could cheat everyone that I own something. Does that count as ownership?
8-2：Of course it does.#portrait: 8-2_smile
8-2：So, here's a question: is it possible to own a person?#portrait: 8-2_laugh
Me：......
8-2：Yes, it is-as long as your ownership can convince everyone: know everything about them, accurately describe all their traits.#portrait: 8-2_deepLove
8-2：And most importantly, win their full, 100%, <b>trust</b>. Not the casual type of trust, but the form of trust that make them believe that they belongs to you.#portrait: 8-2_smile
Me：That sounds toxic, if not impossible.
8-2：Think about it. Don't you "have" your Family, lover, friend?#portrait: 8-2_smile2
8-2："I'm yours"-doesn't it sound familiar and romantic?#showObservee:imYours_EN
8-2：Not to say that most people were born with a person--
Me：The self.
8-2：Correct, the self. Although some could also lose their selves as time passes.
8-2：Now, you should understand the second important number--
8-2：<color=magenta>Ownership</color>. When it applies to other people, it would be the number that represents the total of your understanding of them and their trust in you.#portrait: 8-2_smile
8-2：100% of understanding times 100% of trust: the perfect 100! You don't have to reach perfection, 90 is good enough for displacement.#portrait: 8-2_smile2 #showObservee: formula_EN
8-2：Unfortunately, painter, I could see that you have around 0% of trust in me. Stop being so worried, I can't own you, so I can't harm you.#portrait: 8-2_laugh
Me：You do know that you sound evil?
8-2：Ah crap, you think I'm terrible!#portrait: 8-2_unhappy
8-2：I don't want a crafty-looking portrait! Wait, before you finish, let me rescue my image in your mind.#portrait: 8-2_raiseEyebrowLookAway
Me：Don't worry about that, I'm about to finish the last strokes.
8-2：All to the fate, I guess?#portrait: 8-2_raiseEyebrow
Me：As you've been asking a lot of questions, now I think it's my turn.
8-2：Ah I'm nervous. Do...do...do ask.#portrait: 8-2_smile2
Me：(I am pretty sure about 8-2's portrait. My question is...)#choiceType: OBSERVEE
+[Have you ever displaced a person?]
Me：<b>Have you ever displaced a person?</b> #choiceType: BUTTON
8-2：Hey, it goes without saying.#portrait: 8-2_laugh
8-2：<b>Of course I did</b>.#portrait: 8-2_cold #bgm:pause #bgm:fade_0.1_0 #drawingSystem: addBinaryVal_-20
Me：...
8-2：You're not asking me why?#portrait: 8-2_smile #bgm:play #bgm:fade_1_0.15
8-2：And not asking me who?
Me：Will you be honest with me?#bgm:fade_0.5_0.3
8-2：Good question. But since you didn't ask, I don't know how I would've answered.#portrait: 8-2_thinking #bgm:fade_3_1
Me：*smile* Everyone has their own path. I don't have to know too much about yours.
8-2：Everyone has their own path? Heh.#portrait: 8-2_smile2
->almost_done
+[Have you ever been owned by someone else?]
Me：Have you ever been owned by someone else?#choiceType: BUTTON
8-2：......#portrait: 8-2_norm2
8-2：Why the question?#portrait: 8-2_smile
Me：You've been talking about handling oneself and manipulating others, as if you were superior.
Me：Do you understand how it feels to be owned?
8-2：Hey, it goes without saying. #portrait: 8-2_laugh
8-2：Of course I understand. Many people own me. They could displace me whenever they like.#bgm:pause #bgm:fade_0.1_0 #portrait: 8-2_admire #drawingSystem: addBinaryVal_30
8-2：Being owned is risky but also happy. People who has never been owned are sad, you know. Their lives have relatively failed.#bgm:play #bgm:fade_1_0.2 #portrait: 8-2_norm2
8-2：...What, are you impressed? Heh, that was a good one, I'll write it down for my next lecture...#portrait: 8-2_smile
Me：It's not like, that good.
我：But I liked that. Perhaps the intuition of an artist.#portrait: 8-2_laugh
->almost_done

==almost_done==
Me：The painting is almost finished, good luck with your lectures, it's fun talking with you but I've got things to do...
Me：(Right, I had to meet someone, and I almost forgot.)#bgm: fade_3_0.2
Me：(Wednesday, Aug. 26th. I've got a friend who's coming from far awary, and we promised to meet up at HotMama... Wait, that's right here.)
Me：...Wait. #portrait: 8-2_smile 
Me：The old friend I'm meeting is you?#portrait: 8-2_laugh #bgm:戏谑_0.2
Me：Darn bro, how long has it been? You've changed <b>so much</b>! I didn't even recognize you.
8-2：*sigh* It's only been a few weeks, painter.#portrait: 8-2_norm
Me：Hey, I've been stupid. I didn't even remember that I promised to meet up.
Me：You scared me when you just...poped up! Where have you been?#portrait: 8-2_smile
Me：You didn't even have your cloths on when you just...appeared! When I think about it, how did you ever get on public transportation like that? 
8-2：I didn't take public transportation. I haven't even left the town.
8-2：Or should I say, I wen to <color=magenta>the other side</color>. I went to <color=magenta>the Void</color>.#portrait: 8-2_norm #unlockNote: 3_3
Me：You...you died?
8-2：No you idot. I was only on a work trip.#portrait: 8-2_laugh
Me：...Huh?
Me：You mean...
Me：You were displaced by somebody, for work?
8-2：Uh-huh.#portrait: 8-2_smile
Me：(That's hell of a crazy job, but it's true that he had <color=magenta>disappeared</color> and reappeared!)
Me：(Disappearing and reappearing <color=magenta>take time</color>. That's why I didn't remember him when he poped up.)
Me：How did you come back, then?
8-2：That's a top secret at our <color=magenta>One in Seven Fraternity</color>.#portrait: 8-2_laugh
Me：...
8-2：I could tell you, though, if you're interested in becoming our reserve.#portrait: 8-2_smile2
+[I'm interested!]
Me：Sounds fun, if you tell me how you managed that.#drawingSystem: addBinaryVal_10
->disclose_secret
+[No thanks]
Me：Ummmmm... (Sounds like a very demanding, crazy job.)#profile: painter_sideSweat
8-2：Painter, you're too cautious. Okay, I'll reveal just a bit.
->disclose_secret

==disclose_secret==
8-2：So. In short, once in a while. we displace each other for a large amount of liquid asset. That's called a work trip.#portrait: 8-2_smile
8-2：Since it's a work trip, there would, of course, be a day when the trip ends. At that day the displaced member would come back.#portrait: 8-2_laugh
Me：............(Now it sounds like a terrible, vicious, crazy job with extremely high risks.)
Me：But how's that possible?#portrait: 8-2_smile
Me：How could something come back to existence from disappearance?
8-2：But why not?
Me：Nobody could remember the things that have disappeared, isn't it?
8-2：Heh.#portrait: 8-2_mysterious
Me：Hey, tell me what it's like on the other side.
8-2：It'd not be called "the Void" if there's anything there except the void.#portrait: 8-2_norm
8-2：Take a step back, I wouldn't be able to remember anything. Only the non-existent goes to the void. I didn't even exist, how could I know? #portrait: 8-2_thinking
8-2：Well, I guess you could also say that I didn't go anywhere. The Void is metaphorical, you see.
Me：Fine. No comments.#portrait: 8-2_smile 
Me：(Yet the existence...the non-existence of the Void is captivating. There's nothing and everything at the same time.)
Me：(Something still feels missing, though.)#unlockNote: 3_4
Me：(But anyways, the portrait of 8-2 is already finished.)
+[Give it to 8-2]
 ：#drawingSystem: showDrawResult #profile: none #bgm: fade_0.5_0
->DONE
