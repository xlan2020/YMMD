INCLUDE ../global.ink
 ：Ready to go home?#profile: hide
+[Not yet]->not_yet
+[Go home]->go_back_home

==not_yet==
Me：(I'm not tired yet. Take another walk.)#profile: painter_norm
->DONE

==go_back_home==
Me：(I should probably hit the sack.)#profile: painter_norm
->letter_box

==letter_box==
Me：(The light in the hallway is still broken. Let's take a look at what's in the mailbox outside.)
*[Cardpaper]->haiming_letter
*[Soft paper]->scale_flyer
* ->empty_box
==haiming_letter==
Postcard：What happened? I called and messaged you, nobody answered. I hope that you're still alive.#profile: hide
Postcard：I'll be back the 25th. You promised to paint me a "deep sea monster," that's still a deal, right? :)
Postcard：I'll be in the shop by Thursday. Meet me at <color=magenta>Institute of Mysterious Beast</color> when you feel like it!
Postcard：* ——seanamae 8月20日
Me：(seanamae... Oh, the tattooist. It said the 25th, she was back yesterday.)#profile: painter_side
Me：(...I completely forgot the commission, and I have zero inspiration about what to draw.)#profile: painter_sideSweat
Me：(Why don't I talk to her at the shop <color=blue>tomorrow</color>? I had the impression that she's the friendly type.)#profile: painter_norm
->letter_box

==scale_flyer==
Flyer：Swipe the code to place an order for Rare Fish Scale Brewing Ingredients x 8. Attacking cold with cold, creating blood and replenishing qi, prolonging life, nourishing yin and replenishing yang!#event: collectFlyer
Me：(Useless stuff, why does it looks familiar?)
->letter_box

==empty_box==
Me：(The mailbox is empty.)
 ：I am back at home.#loadScene: DAY1-5_FluidBrain
->END