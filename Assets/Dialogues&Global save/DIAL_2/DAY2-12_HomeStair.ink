INCLUDE ../global.ink
 ：要回家了吗？#profile: hide
+[再转转]->not_yet
+[回家吧]->go_back_home

==not_yet==
我：（还没到回家的时候，再在附近转转吧。）#profile: painter_norm
->DONE

==go_back_home==
我：（现在就回家吧。）#profile: painter_norm
->DONE

->letter_box

==letter_box==
我：（走廊里的灯还是没有修好啊……摸索出信箱里的东西，借着路灯看看吧。）
*[硬的卡片]->haiming_letter
*[软的纸片]->scale_flyer
* ->empty_box

==haiming_letter==

->letter_box

==scale_flyer==

->letter_box

==empty_box==
我：（信箱里摸不到东西了。扶着墙上楼梯吧。）
 ：我回到家中。#loadScene: DAY1-5_FluidBrain
->END