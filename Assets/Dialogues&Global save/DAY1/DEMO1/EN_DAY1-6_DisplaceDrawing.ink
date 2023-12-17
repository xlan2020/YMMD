INCLUDE global.ink
 ：The painting is finished.#bgm: 房间 #profile: hide
System：This is the first time in a few days that the painter finishes their own <color=magenta>creation</color>.
System：Different from commissions, personal creations would not bring any return in cash, but could become an <color=magenta>accurate description</color> of objects.
System：With a painting that constitutes an accurate description of an object, the painter could bring the <color=magenta>non-existing</color> object into existence.
System：In this case, by paying an <color=magenta>equivalent amount of money</color>, the painter can <color=magenta>displace</color> the object from the void.
System：Of course, displacement does not garentee satisfactory results. The deviations in the painting, the lack of money... these could influence the result of displacement.
System：In short, when the painting is finished, according to <color=magenta>how much money you're willing to pay</color>, the painter would receive <color=magenta>different objects</color>.
System：It's a game and an adventure...
System：After displacement, the money cannot be returned regardless of the result. The painting, because it is only the description, will not disappear. You can try displacing multiple times based on the same painting, as long as you're willing to pay.
System：Isn't that romantic. You should try it out.
Me：I still don't understand, but I feel that it's very important to me-a mermaid. A mermaid... Does mermaids' non-existence marks their potential of existence from the Void?#profile: painter_side
Me：Anyways. I want it.
Me：I could feel it... By paying <color=green>more</color>, I could touch it. I could swim around with it... Wait, it feels familiar.
Me：I remember seeing some mermaid diving suits on the street... The price tag said <color=green>￥299</color>. It'd sure be nice to own its caress for a <color=color>lower price</color>...
->displace_input

==displace_input==
Me：How much should I displace?#profile: painter_side #choiceType: PAUSE #event: showInput
+[置换成功] ->displace_success
+[没有那么多钱]->not_enough_as_input
+[输入金额为0]->input_is_zero
+[没有输入数字]->input_not_number
->DONE

==not_enough_as_input==
Me：Eh, I don't have that much money.#profile: painter_sideSweat #event: hideInput #choiceType: BUTTON
->displace_input

==input_is_zero==
System：You could exchange nothing for nothing. #profile: hide #event: hideInput #choiceType: BUTTON
->displace_input

==input_not_number==
System：Input the amount of cash you'd like to displace.#choiceType: BUTTON #profile: hide #event: hideInput
->displace_input

==displace_success==
Me：It appeared out of nowhere!#profile: painter_surprised #event: hideInput #choiceType: BUTTON
Me：But is this what I want? No, it's far from enough...#profile: painter_depressed 
Me：It's dissappointing. Is it because of the drawing, or is it because of the money? Perhaps it's both.
Me：What is a mermaid, after all?#profile: painter_norm
Me：......#profile: painter_eyeClosed
Me：I should collect some information about the <color=purple>mermaid</color> tomorrow for more inspiration.#profile: painter_norm
Me：I should really hit the sack. <color=green>Turn off the light</color> and sleep.#profile: painter_eyeClosed #event: enableSwitch
->DONE