INCLUDE ../global.ink
 ：画作完成了。#bgm: 房间 #profile: hide
 ：这是画家近些天第一次完成自己的<color=magenta>创作</color>。
 ：和给顾客的稿件不同，创作并不会带来金钱上的收益，却有机会成为对事物的<color=magenta>准确描绘</color>。
 ：参照准确描绘的画作，画家可以凭空想象出世界上<color=magenta>不存在</color>的东西。
 ：在这种情况下，只要有<color=magenta>等价的金钱</color>作为筹码，就可以把画作里的东西<color=magenta>置换</color>出来！
 ：当然，置换并不会每一次都带给你想要的。金钱的限制、作画的偏差……这一切，都让置换的结果存在不确定性。
 ：简单来说，在画作已经完成的情况下，根据<color=magenta>付出金钱的多少</color>，画家有机会获得<color=magenta>不同的东西</color>。
 ：这是一场博弈和冒险，或者说，比那更加孤注一掷。
 ：在置换完成后，付出的金钱是无法追回的，但画作本身并不会消失，只要愿意再次投入，无论置换多少次都可以。
 ：这么想来，是不是还挺浪漫的？那么，现在就请画家试试看吧。
我：虽然还完全不明白，但我直觉它是对我很重要的东西——一条美人鱼。……美人鱼？这个世界上存在这种东西吗？#profile: painter_side
我：没什么好说的，我想要它。
我：对于能置换出什么，我有一种模糊的感觉。花<color=green>更多的钱</color>就可以触碰到它，在水中一起遨游……等等，怎么感觉很熟悉？
我：在街上似乎看到过什么，美人鱼潜水服……豪华赠礼……价值<color=green>￥299</color>……当然，<color=color>更少的钱</color>也好，至少可以得到它的呵护。
->displace_input

==displace_input==
我：要花多少钱置换呢？#profile: painter_side #choiceType: PAUSE #event: showInput
+[置换成功] ->displace_success
+[没有那么多钱]->not_enough_as_input
+[输入金额为0]->input_is_zero
+[没有输入数字]->input_not_number
->DONE

==not_enough_as_input==
我：呃，虽然想多投入点，但我并没有那么多钱。#profile: painter_sideSweat #event: hideInput #choiceType: BUTTON
->displace_input

==input_is_zero==
 ：你在想什么呢！舍不得本钱可什么都得不到哦。#profile: hide #event: hideInput #choiceType: BUTTON
->displace_input

==input_not_number==
 ：金额需要输入数字哦！#choiceType: BUTTON #profile: hide #event: hideInput
->displace_input

==displace_success==
我：凭空出现了！#profile: painter_surprised #event: hideInput #choiceType: BUTTON
我：……但这就是我想要的吗？总觉得有点失望，这远远不够……#profile: painter_depressed 
我：不如说是差得太多了。是画得不够准确，还是筹码不够？……大概，哪个条件都无法满足吧。
我：美人鱼，究竟指的是什么？#profile: painter_norm
我：………………#profile: painter_eyeClosed
我：也许，明天应该多去收集一些<color=purple>人鱼</color>相关的情报，也许会有一些你发现吧？#profile: painter_norm
我：今天就到这里，<color=green>关灯</color>睡觉吧。#profile: painter_eyeClosed #event: enableSwitch
->DONE