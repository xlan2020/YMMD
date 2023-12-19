INCLUDE ../global.ink
8-2：哎呦，光顾着看你画画儿了，都这么晚了？#profile: 8-2_raiseEyebrow
8-2：我一会儿找兄弟们还有点事儿……对了！这个你先拿着。#profile: 8-2_laugh
我：（咦？这是跟他脸上差不多的眼镜，侧面还刻着字……1/7是什么意思？等等、难道说……）#event: getGlasses #profile: painter_stunned
我：我可没说要加入你的兄弟会！#profile: painter_noComment
8-2：NO、NO、NO，说加入还早了点儿，预备成员而已，新人！你的第一轮考核已经通过了，接下来的六轮，再接再厉哈！#profile: 8-2_smile2
我：（算了，不和厚脸皮的家伙计较。）你忙这些是为了什么啊？#profile: painter_eyeClosed
8-2：说出来吓死你。#profile: 8-2_norm
8-2：人话来说，那就是掌控置换。嘛，我的课程也还是很公道的，当然，我这不是打广告啊，咱俩谁跟谁，你要什么哥们儿义务帮你。#profile: 8-2_smile2
8-2：画家，我能看得出来，你自己的日子也过得够呛吧？#profile: 8-2_norm3
我：（我……）#choiceType: BUTTON #profile: painter_norm
+[我失忆了]->I_lost
+[我没钱了]->I_lost
+[都是置换害得]->I_lost

==I_lost==
我：很明显吗？是，我失去了很多东西。最糟糕的是，我根本想不起来我曾经拥有过什么。#profile: painter_depressed
8-2：*一拍手*啧啧，你就没想过从置换中得到点什么吗？#profile: 8-2_weirdSmile
我：我不是那种喜欢钻营的投机分子。#profile: painter_alert
8-2：你这话不对。得到就是钻营吗？我说的是创造，是艺术！#profile: 8-2_smile2
8-2：你刚不是说，把消失的、不存在的东西置换回来，是不可能的事吗？#profile: 8-2_norm
8-2：从你嘴里说出来还真叫人失望。画家呀，在你落笔之前，这画儿也是不存在的。#profile: 8-2_cold
8-2：一样是凭空创造，怎么置换的艺术就离谱了呢？#profile: 8-2_smile2
我：谢谢你对我的肯定，不过我可不是神笔马良。画只是画而已。#profile: painter_norm
8-2：这就是我要说的！你的画可不只是有颜色的纸片，它印证的是你心目中对事物的<color=magenta>准确描述</color>。#profile: 8-2_smile2
8-2：如果你能够准确描述出已经<color=magenta>消失</color>的东西，如果你能一点不差地想起来它、画出来它……那么，你就有机会把它<color=magenta>置换回来</color>。#profile: 8-2_norm
8-2：我这么说，你能听懂吗？#profile: 8-2_smile2
->did_you_get_it

==did_you_get_it==
我：（这……）#profile: painter_norm
+[天方夜谭。]
我：我能听懂，只是真够忽悠人的。#profile: painter_noComment
->yes_I_understand
+[……]
我：………………#profile: painter_side
->yes_I_understand
+[啥？再来一遍]->repeat_description_again

==repeat_description_again==
8-2：你的画可不只是有颜色的纸片，它印证的是你心目中对事物的<color=magenta>准确描述</color>。#profile: 8-2_norm
8-2：如果你能够准确描述出已经<color=magenta>消失</color>的东西，如果你能一点不差地想起来它、画出来它……那么，你就有机会把它<color=magenta>置换回来</color>。
8-2：我这么说，你能听懂吗？#profile: 8-2_smile2
->did_you_get_it

==yes_I_understand==
8-2：当然，在你实施之前，这都是纸上谈兵。#profile: 8-2_norm3
8-2：将将！这就是你加入七分之一兄弟会的下一项挑战了。<color=magenta>把·消·失·的·东·西·换·回·来！</color> #bgm: 戏谑 #profile: 8-2_smile2
8-2：是不是很激动人心呢？这对你自己来说，可是大大的好处！#profile: 8-2_laugh
我：…………………………原来在这里等着我呢！#profile: painter_noComment
8-2：啊哈！当然，我会<color=red>等着</color>你的哦<color=green>❤</color>#profile: 8-2_laugh
8-2：等到合适的时候，我自然会<color=red>再次</color><color=green>出现</color>。#profile: 8-2_norm
8-2：今天太晚啦，我真得撤了。#profile: 8-2_smile2
我：快走吧，我头都疼了。#profile: painter_eyeClosed
8-2：拜拜喽画家~ #profile:8-2_smile2
我：回见。#profile: painter_norm
 ：8-2离开了。#bgm: fade_2_0 #event: 8-2left #profile: hide
我：（巴简二真是一名奇怪的朋友，他身上恐怕有很多我不知道的事。）#profile: painter_side
我：（不过，谁知道他的话有几分是真呢？）
我：……………………
我：（现在总算是有点零钱了，天却黑了，能买到画材的店都已经打烊。）
我：（西边是我租的公寓，东面的娱乐场所倒是开着——但现在我可去不起。）
我：（回家……可是家里什么都没有，还不如在外面消磨时间更自在点。至少，这里有一片<color=magenta>海滩</color>可以溜达。）#profile: painter_sideSweat
我：（随便转转，累了就<color=green>回家</color>吧。）#profile: painter_side
->DONE