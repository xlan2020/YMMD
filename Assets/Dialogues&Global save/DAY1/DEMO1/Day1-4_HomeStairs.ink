INCLUDE global.ink
 ：要回家了吗？#profile: hide
+[再转转]->not_yet
+[回家吧]->go_back_home

==not_yet==
我：（还没到回家的时候，再在附近转转吧。）#profile: painter_norm
->DONE

==go_back_home==
我：（该回家了。）#profile: painter_norm
->letter_box

==letter_box==
我：（走廊里的灯还是没有修好啊……摸索出信箱里的东西，借着路灯看看吧。）
*[硬的卡片]->haiming_letter
*[软的纸片]->scale_flyer
* ->empty_box
==haiming_letter==
明信片：最近打你的电话一直不通，消息也没回过，是发生什么事情了吗？#profile: hide
明信片：我25号晚回镇上，上回答应的海底怪兽约稿，还做数吧：）
明信片：周四之后我就在店里了。有空来<color=magenta>神秘生物研究所</color>坐坐吧！
明信片：* ——seanamae 8月20日
我：（seanamae……sea……海……原来是她呀，见过几面的纹身师。信上说25号，看来昨天她就回来了。）#profile: painter_side
我：（……约稿的事情还一笔没动，灵感也约等于无。）#profile: painter_sideSweat
我：（不如<color=blue>明天</color>去店里和她聊聊吧。印象里，她是个很好相处的人。）#profile: painter_norm
->letter_box

==scale_flyer==
传单：扫码下单珍稀鱼鳞泡酒材料×8，以寒攻寒、造血补气、延年益寿、滋阴补阳！#event: collectFlyer
我：（没用的东西。不过怎么好像有点眼熟？）
->letter_box

==empty_box==
我：（信箱里摸不到东西了。扶着墙上楼梯吧。）
 ：我回到家中。#loadScene: DAY1-5_FluidBrain
->END