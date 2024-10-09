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
+ {money>=8}[Pineapple!]
->order_sweet
+ {money>=18}[Torpedo!]
->order_new
+ {money>=24}[Premium!]
->order_classic
+ {money<24} [No thanks.]
->end_order

==order_new==
Me：I'll have this Torpedo ice!#profile: painter_happy #addMoney: -18
boro-chan：Just a sec... #profile: boro_escape
 ：...... #profile: hide 
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #event: addTorpedo
boro-chan: Is there anything else you need?#profile: boro_thinking
+ [Let me think...]
->order_ice
+ [No thanks.]
->end_order

==order_classic==
Me：I'll have this Premium Platter Ice!#profile: painter_happy #addMoney: -24
boro-chan：Just a sec... #profile: boro_escape
 ：...... #profile: hide 
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #event: addClassic
boro-chan: Is there anything else you need?#profile: boro_thinking
+ [Let me think...]
->order_ice
+ [No thanks.]
->end_order

==order_sweet==
Me：I'll have the Pineapple one!#profile: painter_happy #addMoney: -8
boro-chan：Just a sec... #profile: boro_escape
 ：...... #profile: hide 
 ：.........
boro-chan：It's ready! Hope you enjoy it!#profile: boro_glad #event: addSweet
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
