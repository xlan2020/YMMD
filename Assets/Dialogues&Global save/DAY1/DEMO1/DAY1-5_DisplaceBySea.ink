INCLUDE DAY1-2_global.ink
大海：~~~ ~~~ ~~~ #profile: hide
 ：看着夜晚的大海，画家生出一种空洞无措的感觉。#profile: hide
 ：渴望着拥有更多东西，所以——
+[置换吧]->displace
+[赶紧离开]->leave_soon

==leave_soon==
我：（我怎么会有这种念头？夜晚的大海太危险了，赶紧离开吧。）#profile:painter_frightened
->DONE

==displace==
 ：要花多少钱去置换呢？
 +[￥10/次]->price_10
 +[￥100/次]->price_100
 +[不置换了]->leave_soon

==price_10==
{ money >= 10: 
~ money -= 10
 ：置换成功了，现在那是你的东西了。#event: displaceOut10
 ->displace_again
 - else:
 ：置换失败，价值不对等。你没有足够的钱。
 ->money_not_enough
 }
 
==price_100==
{ money >= 100: 
~ money -= 100
 ：置换成功了，现在那是<color=purple>你的东西</color>了。#event: displaceOut100
 ->displace_again
 - else:
 ：置换失败，价值不对等。你没有足够的钱。
 ->money_not_enough
 }
 
 ==displace_again==
 ：还要再置换吗？
 +[还要置换] ->displace
 +[快走吧] ->displace_and_leave

==high_rank==
 :置换成功了，现在那是<color=purple>你的东西</color>了。还要再置换吗？
 +[还要置换] ->displace
 +[快走吧] ->displace_and_leave
->displace

==displace_and_leave==
我：（不能再多置换了，赶紧离开吧。）#profile:painter_frightened
->DONE

==money_not_enough==
我：（钱不够了，赶紧离开吧。）
->DONE

感觉可以有大海PROMAX是十连，还有648在
->DONE