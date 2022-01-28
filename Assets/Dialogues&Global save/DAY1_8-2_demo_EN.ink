INCLUDE global.ink

(Log: Enter the drawing interface from DAY1_Map_1)
(First of all, I should decide what materials to use...but since I've traded in everything I had, there aren't many choices at the moment.) #speaker: Me #choiceType: MATERIAL
    +[ ]
        I wonder what would you do if the restaurant doesn't have a pencil. #speaker: 8-2 #portrait: 8-2_frown
        Paint in your brain. #speaker: Me 
        ->start
    +[ ]
        Soy sauce seriously? How luxurious. #speaker: 8-2 #portrait: 8-2_frown
        Isn't this just right for you? #speaker: Me
        ->start

===start===
Can I move? Will it bother your performance? What if you take this as an excuse of drawing something terrible… #speaker: 8-2 #portrait: 8-2_smile
Move as you want to. #speaker: Me
All right, I know this. That's what you call an abstract art don't you? #speaker: 8-2 #portrait: 8-2_idle
Shut up. 
(Once I start to draw, I need to concentrate and observe my subject. But more than that...) #speaker: Me
...Actually, say something about yourself. 
(I need to know about the subject. If any observation pops up, I'll collect it for the drawing. )
Huh? About me? If this could contribute to a better drawing I'd cooperate. What little secret do you want to know about? #speaker: 8-2 #portrait: 8-2_smile
As you like.#speaker: Me
As I like? Or do you mean - WHO I like? I can see what you want to hear, but you are wrong, I will not waste time on women like some somebody did. #showObservee: woman 
 (...Somebody? Who is he talking about? There's something underneath his smile. ) Keep going. #speaker: Me #showObservee: glasses
All I love is human knowledge, endless and eternal. #speaker: 8-2 #portrait: 8-2_indiff
Just Kidding! Just guess, What would I do if I can't sleep? #portrait: 8-2_handsup
(Let me think... What would he do if he can't sleep? What kinds of person is he? ) --Submit idea to drawing when ready-- #choiceType: OBSERVEE
    +   [ ]
          ->woman
    +   [ ] 
           ->glasses
        
===woman===
        Get a mirror and see what your expression is like. You got to be thinking about woman. #speaker: Me
           ->count_sheeps
===glasses===
        I guess you might be reading? ...Don't tell me that you're reading about astrology and magic... #speaker: Me
           ->count_sheeps


===count_sheeps===
NO-NO-NO, Painter, You don't know what I am deep inside. #speaker: 8-2
I would be counting sheeps. I count to sleep every night and when I wake up, the counting still continues! 
Do you know how many sheeps you can count in one night? 
The answer is no more than 7. #portrait: 8-2_idle
Have you played the game 'count to 7'? The point is that you can not count 7. 
But of course 8 doesn't come after 6, so whenever reaching that number I have to start again. 
We kept counting and kept losing... When the night is over I still can't count to 7. #showObservee: we #portrait: 8-2_smile 
(Wait, what he just said sounds important. If I could just add that to the drawing...) #choiceType: OBSERVEE_CANSKIP
/*
For questions in type CANSKIP, the skip choice should always be the first choice - index 0. Else errors would occur. 
*/
    +[ ]
    (...What was that again? Never mind. I might be over-sensitive.) 
    Counting sheeps is not equal to count to 7. Why don't you just say 7? #speaker: Me
    -> cant_reach_7
    +[ ]
    -> catch_we

===catch_we===
    (Did he just say "We"?) Wait, who are you playing with? #speaker: Me
    ... #speaker: 8-2 #portrait: 8-2_indiff
    You sleep with your brothers? You didn't tell me you have a brother. #speaker: Me
    -> cant_reach_7
    
===cant_reach_7===
It's not that I don't want to, is that I can't. #speaker: 8-2
A child are not born to count. The action of counting in your head requires complex understanding of an abstract concept that repeats over time. It's difficult! #showObservee: child
Counting 7 means amnesia, counting 7 means disappearing...and then - DANG-DANG! You start over again. 
I didn't know that counting to 7 is your limit of mathmathematical ability. #speaker: Me
Exactly! 7 is the limit. #speaker: 8-2 #showObservee: name
Seven is something in this world you can never reach. Painter, do you know why? #portrait: 8-2_idle #choiceType: OBSERVEE 
    +   [ ]
     -> name_decides
    
    +   [ ]
     -> man_decides

===name_decides===
    (Eighminus Tue... 8-2... He wanted to be 7 but reducing was overdone. He went pass 7. ) #speaker: Me
    Is it because your name sounds like Eight minus two? 
    ...Yes, it's all decided. Name decides everything. #speaker: 8-2 #portrait: 8-2_indiff
    It is the identifier. Only through name one can be called... and changed.  #observee: name 
    But isn't it possible that people have identical names? See, Eighminus Tue isn't...ok this is a rare name. But... #speaker: Me
    You really believe in that my name is Eighminus Tue? #speaker: 8-2 #portrait: 8-2_smile
    ...Pardon me? (It can't be... this fibber lies on his name for all those years?) #speaker: Me
    Just kidding! But indeed, someone's true name might not ever be called once in a life. #speaker: 8-2 #portrait: 8-2_handsup
    It might be something that nobody knows. But the system...the Displacement system knows it. #portrait: 8-2_idle
    The void would find you no matter where you hide. #portrait: 8-2_indiff
    Hold on, so are your saying that it's safer not having anybody know your... 'true' name because it's dangerous? #speaker: Me
    No I didn't say say that. Actually, I want people to love each other. #speaker: 8-2 #portrait: 8-2_smile
    They never know what kind of love exists between us... #portrait: 8-2_idle 
    ...... #portrait: 8-2_idle
    Painter, what's that expression on your face? #portrait: 8-2_idle
    ...Nothing. Give me a moment, I'm almost done with drawing... #choiceType: AUTO
    -> done_painting
    
===man_decides===
     (A name decides nothing. Having a name like this doesn't mean that he is good at math or anything. ) #speaker: Me  #portrait: 8-2_idle
    So you're saying...like how a child did, you also find some troubles in counting? #speaker: Me 
    // Hey Painter! You are a better person than this! #speaker: 8-2 #portrait: 8-2_frown
    (But it can't be. Though he switches topics really fast and manythings are hardly relevant, 8-2 is indeed really smart. ) Sorry, I might be... 
    Yes. That's indeed my limit as who I've grown into. #speaker: 8-2 #portrait: 8-2_smile
    But I am never alone. People are grown to be different, but when they comes together they'd become a whole.
    ...Hold on a sec. Are we still talking about counting numbers below 10? #speaker: Me
    Yes! What's the issue? #speaker: 8-2 
    ...Nothing. Keep going.  #speaker: Me 
    So as you know, I can't form 7 because I only got 8 and 2 in my hand, but once I found somebody who has a "1"...
    I could dis... I could see a different world. #speaker: 8-2  #portrait: 8-2_smile
    (Did he just say 'dis?' Dis...placement? disappearance? ) Well, then I guess it's a good thing?  #speaker: Me 
    Yes it is! #speaker: 8-2
    Painting, how's your painting going? #speaker: 8-2
    Almost Done. Just give me a second... #speaker: Me #choiceType: AUTO
    -> done_painting
    
===done_painting===
    +   {name_decides}{not catch_we}[ ]
        -> predecided
        //玩乐 欲望 + 命运决定 = 命运都定好了，我只能在这混日子了
        //深处追求 + 命运决定 = 一切都有定数，保持敬意，知道我们的极限在哪里，我只有我的兄弟 */
    +   {man_decides} {woman} {not catch_we}[ ]
        -> shabi
         //玩乐 欲望 + 人决定的 = 我知道我想要选择什么样的生活，大家都是傻逼，peace
    +   {man_decides} {glasses} {not catch_we} [ ]
        -> fraternity
        // 深处追求 + 人决定的 = 我能够掌控置换，社会主义追求
    +   {catch_we} [ ]
        -> fraternity
       
    = predecided
        (Eighminus Tue said that everything is decided by the name - though I'm not 100% sure what he means.)
        (But I can see something important. )
        (Inside of his frivolous appearance there's an invisible 'limit' of 7.)
        (It almost seems like something...divine. ) 
        (Hold on, divine for 8-2? I'm making myself laugh. But nonetheless...)
        (This is the drawing.) #choiceType: DRAW_RESULT #DRAW_RESULT: 0
        -> after_done
    = shabi
        (This man does jokes a lot. I could hardly tell which is real and which is lie.)
        (Sometimes he did irritates me a little... But he always kn4ows what he's doing.)
        (He isn't one of those who make fun of people to feel good.)
        (If he call somebody an idiot, he must be calling himself an idiot as well.) 
        (Those sketchy little pamphlet and his words... I shouldn't take them too seriously. He just wan't some fun.)
        (Then, I'd offer him a fun drawing too!) #choiceType: DRAW_RESULT #DRAW_RESULT: 1
        -> after_done
    = fraternity
        (The way 8-2 talks always give me a weird feeling.)
        (Some times the words "we" "us" just slipped out from his mouth.)
        (There should be someone who's really closed to him. They must be important.)
        (It's not like talking about a girlfriend or something. It's almost like... a bunch of people. )
        (Strange. I've known 8-2 for all those years, but never seen him so closed to anybody. He looks just like a frivolous fibber.) 
        (But am I seeing the real 8-2? Maybe there's more than that. there's more...)
        (People. The "we" he mentions constitues him. )
        (I knew what to do. When drawing 8-2, I should never draw him alone.) #choiceType: DRAW_RESULT #DRAW_RESULT: 2
        -> after_done


===after_done===
The drawing is done. #speaker: Me #portrait: 8-2_idle 
Ohh, quite fast! Let me see... Huh? Huhhhh? #portrait: 8-2_suprised 
...... #portrait: 8-2_noexpression
...............#speaker: 8-2 #portrait: 8-2_serious
(Although it's my friend, his expression still makes me feel a little unsettled...) 
Uh, anything wrong with it?  #speaker: Me 
No...No. There's nothing wrong, even too right. 
...But how do you know? I never told you...
How do you know that it's seven people... #speaker: 8-2 #portrait: 8-2_serious
... Huh? #speaker: Me
Nothing.  #speaker: 8-2 #portrait: 8-2_serious
PAIN~TER~~!!! Well done!
Your future is GOLD! ❤❤! #speaker: 8-2 #portrait: 8-2_excited
(sign.)...Fine. This time you turned out to think its good? #speaker: Me
I am telling the truth. Your drawing has a potential- 
-Painter, Do you know what does it mean to own a person? #speaker: 8-2 #speaker: 8-2 #portrait: 8-2_idle
'Own'? Like owning an object? #speaker: Me
Exactly. If you own a person, you can displace them, make them disappear, exchange them for money... 
But to own someone is never easy. It requires you to describe the essence of the person accurately. 
I see talent in you! Drawing could be a way to make accurate description. If you can achieve that, then maybe you will be able to... #speaker: 8-2  #portrait: 8-2_idle
... displace a person. #speaker: 8-2  #portrait: 8-2_serious
... ... #speaker: Me
... Just to be clear... I'm not interested in human displacement at all. That's too evil. #speaker: Me
Oh~ So you become so upright all of a sudden? What are you thinking about at the moment? #speaker: 8-2 #portrait: 8-2_smile 

/*
    + [I thought of displacing you.]
    + [Is this the way to make a lot of money?]
*/

Yet you still have a looong way to go. #speaker: 8-2 #portrait: 8-2_smile 
Thinking about displacing me with this little drawing? HA-HA! No way! #speaker: 8-2 #portrait:8-2_handsup
However, seeing that you are so talented, I will give you some secret tips. 
(He takes out a crumpled piece of paper) Give me the pen... Ok, check your new page in the book. 
[Additional pages in the replacement manual: There is an extra page of Eighminus Tue's wrinkled paper, which talks about the relationship between possession-accurate description-painting. Part of it is supplemented by Eighminus Tue's second-hand writing.] #speaker: system
Here, the payment for your drawing--- a little bit more than usual--- I do like it very much. #speaker: 8-2

-> END
    
    