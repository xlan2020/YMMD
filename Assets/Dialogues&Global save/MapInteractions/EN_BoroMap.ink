INCLUDE ../global.ink
boro-chan："Borobor" Fish Shaved~Ice! Hello there, "Boro-chan" at your service❤!#profile: boro_welcome
//之后的VAR检测是否和足够的人提起boro
// - promoteBoro == 5:
boro酱：Don't forget to <color=green>mention boro-chan to five different people</color>. You promised!#profile: boro_awkward
//boro酱：你这次想要什么样的刨冰呢？#profile: boro_shy
// - else:
boro酱：What ice would you like?#profile: boro_shy
+ [Let me think...]
->order_ice
+ [No thanks.]
->end_order

==order_ice==
Me：What to order... #profile: painter_norm
+ [Pineapple!]
->order_sweet
+ [Torpedo!]
->order_new
+ [Premium!]
->order_classic

==order_new==
Me：I'll have this Torpedo ice!#profile: painter_happy #addMoney:
boro-chan：Just a sec... #profile: boro_escape
 ：......
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #sceneEvent: 
boro-chan: Is there anything else you need?#profile: boro_thinking
+ [Let me think...]
->order_ice
+ [No thanks.]
->end_order

==order_classic==
Me：I'll have this Premium Platter Ice!#profile: painter_happy #addMoney:
boro-chan：Just a sec... #profile: boro_escape
 ：......
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #sceneEvent: 
boro-chan: Is there anything else you need?#profile: boro_thinking
+ [Let me think...]
->order_ice
+ [No thanks.]
->end_order

==order_sweet==
Me：I'll have the Pineapple one!#profile: painter_happy #addMoney:
boro-chan：Just a sec... #profile: boro_escape
 ：......
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #sceneEvent: 
boro-chan: Is there anything else you need?#profile: boro_thinking
+ [Let me think...]
->order_ice
+ [No thanks.]
->end_order

==end_order==
// - promoteBoro == 5:
boro-chan：Promise me that you won't forget, <color=green>five people</color>!#profile: boro_awkward
Me：(It's sounding increasingly like a threat...)#profile: painter_mournful
//boro-chan：~~Come for ice more often!
// - else:
boro-chan：~~Come for ice more often! #profile: boro_glad

->DONE
