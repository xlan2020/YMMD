INCLUDE global.ink
The sea：~~~ ~~~ ~~~ #profile: hide
 ：Staring at the sea encompassed by the colors of the night, the painter feels a strong sense of deprivation.#profile: hide
 ：There's a burning desire for more, so--
+[Displace!]->displace
+[Leave]->leave_soon

==leave_soon==
Me：(The sea seduces me. I should leave now.)#profile:painter_frightened
->DONE

==displace==
 ：How much money would you use to displace?
 +[￥10]->price_10
 +[￥100]->price_100
 +[Leave]->leave_soon

==price_10==
{ money >= 10: 
~ money -= 10
 ：The displacement is finished. Now it's yours.#event: displaceOut10
 ->displace_again
 - else:
 ：You don't have enough money.
 ->money_not_enough
 }
 
==price_100==
{ money >= 100: 
~ money -= 100
 ：The displacement is finished. Now it's <color=purple>yours</color>.#event: displaceOut100
 ->displace_again
 - else:
 ：You don't have enough money.
 ->money_not_enough
 }
 
 ==displace_again==
 ：Displace for something else?
 +[Displace!] ->displace
 +[Leave] ->displace_and_leave

==high_rank==
 :The displacement is finished. Now it's <color=purple>yours</color>. Displace for something else?
 +[Displace!] ->displace
 +[Leave] ->displace_and_leave
->displace

==displace_and_leave==
Me：(I shouldn't... Leave now, before it's too late.)#profile:painter_frightened
->DONE

==money_not_enough==
Me：(I don't have enough money for displacement. Perhaps I'll come back when I do...)
->DONE

感觉可以有大海PROMAX是十连，还有648在
-草啊！
->DONE