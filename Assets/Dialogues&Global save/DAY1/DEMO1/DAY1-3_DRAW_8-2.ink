INCLUDE ../../global.ink
INCLUDE DAY1-2_global.ink
8-2：啊哈！别说，还真是一穷二白啊。让我别动你东西，你也得有东西让我可动啊？#bgm:日常 #profile: painter_mad #portrait: 8-2_smile2
我：（画箱还是被他打开了……）这下您满意了吧？能让我一个人安静会儿吗？#profile: painter_side
8-2：哎呦，没<color=magenta>画材</color>你就不会画画了？#portrait: 8-2_laugh
8-2：你<b>以前</b>可不是这样的。#portrait: 8-2_admire
8-2：再看看箱子里的东西吧。真的没什么能拿来画画的东西吗？#portrait: 8-2_smile
我：咦？仔细一看还真是……有灵感了！#profile: painter_surprised
操作：【此时点击背包里的东西，会出现新的note。不确定对话框画家是否会对东西的用途进行说明（ink print说明variable）】
系统：收集到的<color=magenta>物品</color>可以作为<color=magenta>画材</color>使用，分为纸、笔、颜料三类。
系统：每次使用画材时会消耗1点<color=magenta>耐久</color>，<color=magenta>耐久</color>清空后物品会<color=magenta>消失</color>
系统：注意，耐久消耗过多时，物品的置换价值也会随之发生变化。
系统：个别特殊的物品则不可作为画材使用。
我：（我有主意了。不过在此之前，还有重要的事情需要确认……）#profile: painter_side
我：呃，你刚才说的给钱，算数吗？#profile: painter_sideSweat
8-2：当然，咱俩谁跟谁啊！行，你要还不信的话……#portrait: 8-2_laugh
8-2：这是定金。#addMoney: 100 #profile: painter_stunned #portrait: 8-2_mysterious
我：（我去！骗子怎么可能先给我钱？）尊贵的先生，请问您想要什么样的画呢？#profile: painter_happy
系统：不同的画材会对画面产生不同的效果，有稳定、生机、实验和昂贵四种属性
系统：根据金主的喜好，使用不同属性的画材会影响当次画画委托的收益。试着投其所好吧！
8-2：我想要一些有意思的画。嗯，都行吧，你亲手画的东西总是能让我大吃一惊。#portrait: 8-2_thinking
我：（全世界的甲方都一样不擅长描述需求，猜度他们的心思也是工作很重要的一部分。）#profile: painter_eyeClosed
我：（有意思、亲手、大吃一惊……就按这个需求选择画材吧。）#profile: painter_happy
+[我明白了]
->select_material_and_draw
+[什么意思？]
我：（他什么意思啊？我得冷静想想。“有意思、大吃一惊”就是非常规，看来实验性的材料会比较适合他。）#profile: painter_side
我：（他要我“亲手”，看来就不能利用有自动性的动物和机械作画了，生机性对他来说并不重要。）
我：（那么，就选择一些<color=magenta>实验性</color>，但是<color=magenta>没有生机性</color>的画材吧。）#profile: painter_happy
->select_material_and_draw

==select_material_and_draw==
操作：【要求还写在对话框里，此时玩家选择画材并且确认。确认后背包栏消失。】
我：（现在拥有的材料还是太有限了，先凑合着用吧，反正对方是8-2。）#profile: painter_norm
我：（……嗯？我刚刚在想什么？怪怪的。还是先决定画什么吧。）#profile: painter_side
我：肖像画，对吧？#profile: painter_norm
8-2：老规矩，当然可以。#portrait: 8-2_smile2
8-2：……#portrait: 8-2_cold
8-2：……等等，你对着我量什么呢？不会就要画速写了吧？#portrait: 8-2_raiseEyebrow
8-2：停停停！你得把对我最深刻的理解体现出来。“画画，是对事物的准确描述！”#profile: painter_eyeClosed
8-2：我要的可不是眼前的我，而是更本质的我，之前的我，<b>真正</b>的我。#profile: painter_noComment #portrait: 8-2_deepLove
我：呃，你年轻的时候……吗？#profile: painter_side
8-2：…………………… #portrait: 8-2_norm3
我：…………………#profile: painter_sideSweat
我：抱歉。#portrait: 8-2_thinking2
8-2：*叹气*咱们慢慢来吧。#portrait: 8-2_norm2
老板娘：您的饭好了！#profile: mama_satisfied 
老板娘：呦，朋友也来啦？哎呀，你是不是那个……那个谁，那个八加二大师？#bgm:戏谑
我：（噗……大师？）#profile: painter_sour
8-2：咳，巴简二，姐姐。#portrait: 8-2_smile2
老板娘：对对，瞧我这记性。我爱人经常听你的课嘞！#profile: mama_satisfied
老板娘：多亏了大师呀，他要不是辞去了那个打渔的活儿，我天天都得牵肠挂肚！
系统：observee介绍，收集大师（p一个图）
老板娘：现在好啊，靠着置换也发了点小财，一天赚的比以前跑三趟还多！
8-2：不用谢，姐姐。我这个人啊，没别的爱好，就是喜欢帮助别人。#portrait: 8-2_deepLove
老板娘：大师的心地就是好呀……给您上点儿茶水。想要什么尽管点，您叫这个名，我就给您打六折！
8-2：哈哈，看来我得改名叫巴简七了。#portrait: 8-2_smile2
老板娘：哎呦，大师可真爱开玩笑！呵呵，八减七不成了一折了……
老板娘：您先看着菜单，有需要再叫我啊！
8-2：没办法，粉丝就是这么多，看来以后得低调点了。#bgm:日常 #profile: painter_side #portrait: 8-2_laugh
8-2：……我去！一没留神，你怎么都给炫完了？#portrait: 8-2_surprised
我：我很饿……嗝。嗯，现在饱了。#profile: painter_sideSweat
我：你是做什么职业的啊，“大师”？#profile: painter_norm
8-2：我是个数学家。#portrait: 8-2_smile
我：（8-2的数学吗？）呃，你给老板娘的爱人……上数学课？#profile: painter_side
8-2：哦，那个是另外的兼职。数学是一门很基础的学科，数字是构成这个世界的基本单位 #portrait: 8-2_norm2
8-2：1就是有，0就是无。#portrait: 8-2_smile
8-2：1是真理，0是假货。#portrait: 8-2_smile2
操作：收集？
8-2：我每天的工作就是研究存在和真理。就像你是个画家一样，我是个数学家。#portrait: 8-2_deepLove
我：（哈？这比我每天探究艺术的真谛还要离谱呢。）……所以，是自封的。#profile: painter_norm
我：而且你这个1和0的说法，听着更像是数字命理学之类的吧？
8-2：嗯，嗯，你就是这么理解的吗？浅了啊，画家。#portrait: 8-2_laugh
8-2：数字可是很重要的！看看你头顶上，那里可是有个很显眼、很重要的数字。#portrait: 8-2_smile2
我：（很显眼、很重要的数字，是……）#profile: painter_stunned
+[{money}]
我：头顶上的数字……{money}？
我：等等！你怎么能看到我头顶上……这个是我的、我所有财产的金额！#bgm:戏谑 #profile: painter_frightened #portrait: 8-2_chuckle
8-2：哦~原来你的所有财产是这个数字啊。#portrait: 8-2_laugh
我：……哎？#profile: painter_side 
8-2：这可是你告诉我的呀~画家~#profile: painter_sideSweat 
我：……………………
我：你这个骗子！#profile: painter_mad 
8-2：不，我只是个数学家。#portrait: 8-2_mysterious #bgm:日常
->value_number
+[什么数字？]
我：哪里有数字？你在逗我吗。#profile: painter_noComment 
8-2：哎呀，不就是{money}吗！你自己看不到？#portrait: 8-2_smile2 
我：嗯？{money}，这个……这个是……#profile: painter_stunned #bgm:pause
我：这是我所有财产的金额！#profile: painter_frightened #portrait: 8-2_laugh #bgm:戏谑
我：等等！你怎么知道的？#profile: painter_surprised
8-2：我说过，我是个数学家。#portrait: 8-2_mysterious
我：你这人还真有点邪门儿。#profile: painter_happy
我：（不过，多半是刚才翻包的时候瞧见的吧。现在的骗术可真是防不胜防。）#profile: painter_norm #bgm:日常
->value_number

==value_number==
我：呵呵，这也算数学吗？#profile: painter_side
8-2：这当然算数学了。本来，人的生活中有很多有意义的数字，不过现在最重要的，就只剩下这个数—— #portrait: 8-2_norm2
8-2：——代表<color=magenta>价值</color>的数。#portrait: 8-2_norm3
8-2：每个人头上都顶着这个数，每件东西上也都悬着这个数。当然，我说的可不是商店里的标价，而是那个虚虚乎乎的，每个人都知道，但每个人看到的都不一样的——
8-2：——所谓<color=magenta>心理价值</color>。把那玩意置换掉了，你钱包里也就会多出这个数。
8-2：但就这么一个数，人也还是看不清楚。#portrait: 8-2_thinking
8-2：所以呢，我的置换成功学课程也就应运而生。哈哈，你刚问我教那老爷子什么，这么说吧，我兼职做的是讲师。#portrait: 8-2_smile2
我：（果然，不出我所料。）*叹气*你是个职业骗子。#profile: painter_side #portrait: 8-2_laugh
我：你居然还好意思说自己研究真理……天，你真应该向老板娘道歉。
8-2：瞧你说得多难听，这怎么能叫骗人呢？#portrait: 8-2_norm2
8-2：多少人都不了解自己想要什么，能失去的是什么……换来换去，换得一场空。#portrait: 8-2_thinking
8-2：我只是在帮助大家了解自我罢了。#portrait: 8-2_deepLove
8-2：说到这了，画家，咱们打开天窗说亮话。我能感觉到——你身上是不是也发生过类似的事？
8-2：如果能更了解自己的话，就不会闹得一无所有，还一无所知了。
我：……………………#profile: painter_side
我：（别说，今天睡醒的事我还真是想不明白，这家伙或许能知道点什么。）#profile: painter_sideSweat
我：（我该相信他的话吗？）#profile: painter_norm
+[帮我看看，大师]->teach_me

+[这人有问题！]->reveal_liar

==teach_me==
我：哈，别说，就今天，我身上也发生了一件怪事。要不，您给我出出主意？#profile: painter_sour
8-2：嗯嗯，好啊，什么怪事？#portrait: 8-2_chuckle
我：（……嗯？他刚才是不是笑了一下？……眼花了吧。）#portrait: 8-2_norm2
我：我今天一觉醒来，就发现屋子和钱包都空了，我的东西一件也不剩，什么也想不起来。#profile: painter_eyeClosed
8-2：啧，失败的置换。置换事故。#portrait: 8-2_thinking
我：多半是吧。哎，但都说是置换了，总得换出点什么来吧？我到现在还一头雾水呢。#profile: painter_side
8-2：你的手上没剩下一件东西吗？#portrait: 8-2_norm2
我：……这倒是有。
我：喏，你看，就这个……好像是枚鳞片。
8-2：这对你来说是很重要的东西吧？#portrait: 8-2_deepLove
我：是的，我能感觉到……不过，我并不知道这是什么。
8-2：呦！这纹路，我瞧着有点眼熟啊。#portrait: 8-2_thinking
我：真的吗？！#profile: painter_surprised
8-2：哎呀，我这眼神不太好。你能让我凑近点看看吗？#portrait: 8-2_chuckle
我：（也是，他戴着个大眼镜，估计是近视吧？）#profile: painter_norm
+[观察眼镜]
我：（……不对！仔细一看，这副眼镜的镜框也太粗了，而且藏在后面的五官一点缩小都没有。）#profile: painter_stunned
我：（这根本就是一副装饰用的平光镜吧？）#profile: painter_noComment
我：（仔细一看，这家伙的小眼睛闪着精光呢！哪里是眼神不好的样子？）#profile: painter_norm
我：（这么重要的东西，不能轻易交给他。我自己能研究出来。）
8-2：怎么，不打算给我吗？#portrait: 8-2_norm2
8-2：好吧、好吧。我就知道画家还不相信我，哎呀，看来数值很难涨啊。#portrait: 8-2_thinking
8-2：现在应该是0.3吗？还是0.2呢？不，应该没有那么低，0.25吧……#portrait: 8-2_thinking2
我：（这个怪人，真是搞不明白了……）你在嘟囔什么？#profile: painter_side
->owning_value
+[递给他]
我：（这么小的东西，离得太远也看不清楚。我太需要知道这是什么了。）#profile: painter_norm 
我：喏，您给看看，能认出这是什么吗？*递出鳞片*#profile: painter_side
8-2：*接过鳞片*嗯、嗯，我看看啊…… #portrait: 8-2_norm
8-2：…………#portrait: 8-2_serious
8-2：…………………………哎呀！#portrait: 8-2_surprised
8-2：手滑了！掉到哪里去了？#profile: painter_stunned #portrait: 8-2_norm #portrait: 8-2_surprised
我：你做什么！这么重要的东西，我看看，我看看，是不是掉到地上了……#profile: painter_frightened
8-2：哎呀，不慌不慌，原来是掉到我另一只手上了。#portrait: 8-2_smile2
我：……哈？#profile: painter_surprised
8-2：上当了！啊哈哈哈哈哈~#profile: painter_noComment #bgm:戏谑 #portrait: 8-2_laugh
8-2：你也太容易相信别人了，画家，这样下去很危险的。这么重要的东西，怎么能轻易交给别人呢？#profile: painter_angry #portrait: 8-2_smile
8-2：我好好看了啊，这是一枚……鱼鳞！至于什么鱼嘛，要不你问卖鱼的试试？#portrait: 8-2_smile2
我：……………………还给我。#profile: painter_mad
8-2：好了好了，给你。开个玩笑，别生气嘛。
8-2：…………#profile: painter_angry #portrait: 8-2_norm2 #bgm:pause
8-2：*自言自语*难不成我真的很讨人嫌？好吧，这下要从0.5跌到0.2了，不，甚至更低……#portrait: 8-2_thinking2 #bgm:日常
8-2：不对不对，0.15？#portrait: 8-2_raiseEyebrowLookAway
我：（这个混蛋，绝对不值得信任……）你在嘟囔什么？#profile: painter_side
->owning_value

==reveal_liar==
我：所以呢，你打算向我卖课吗？#profile: painter_side #bgm:pause
我：先是装作认识我的样子，然后给我点小钱博取我的信任，还让我画画，哈，我就知道没什么人想要我的画的，又是用的这么廉价的画材。#portrait: 8-2_norm2 #bgm:悬疑
我：然后，你利用老板娘给自己立了个“大师”的人设，让我主动问你，免得一上来就推销让人怀疑……天，老板娘不会是你的托儿吧？
我：然后你东拉西扯，故意拿“数学家”和“画家”类比，跟我套近乎。
我：早在你动我包的时候就瞄到我有多少钱了，偷偷记住了这个数，过了很久冷不丁说出来，显得自己很神通。
我：然后就该卖课了吧？如果我说我没钱买课，你是不是该推荐个熟人给我放贷了？#portrait: 8-2_norm
我：行，现在的骗术是挺厉害的，我算是服了。不过大哥，下次还是别做这行了，迟早报应！#profile: painter_angry
8-2：真是不错的推理。虽然有很多漏洞，不过画家，你的智慧又长进了。#portrait: 8-2_smile2
8-2：我得记下来……画家……-0.5……#portrait: 8-2_thinking2
我：你在说什么？我摊开说了哈，我不信你。#profile: painter_side
我：实在咽不下这口气，就把你的100块本金收回去吧。
8-2：你还真是清高啊画家，都穷成这样了，连“骗子”的钱都不好意思吞？#portrait: 8-2_smile2
8-2：我说了，那是给你的定金。定金你收了，画呢，也得给我。委托也是生意，生意讲究诚信。#portrait: 8-2_norm
我：（骗子跟我讲诚信？）行，行，我不像你，我会把你的<b>真面目</b>给画出来的。#profile: painter_norm
我：那我把画给你，你也得给我报酬。呵呵，你要想给我两分一毛的羞辱我，我也认了。#profile: painter_selfMock
8-2：拜托，要不要这么敏感？#portrait: 8-2_unhappy 
8-2：看来-0.5还不够了，画家……-0.6？不对，那样就变成负数了…… #portrait: 8-2_thinking2 
我：（他在念叨什么？不能被他牵着跑，这明显是个套儿……）#profile: painter_side
8-2：-0.55吧，现在估计已经接近0了……#portrait: 8-2_raiseEyebrowLookAway
我：（不能被他牵着跑……不能……）……你在念什么？#profile: painter_side #bgm:日常
->owning_value


==owning_value==
8-2：舍得问啦？嘿嘿，这是每个人第二个重要的数。#portrait: 8-2_smile2
8-2：我管这个数叫做——拥有度。#portrait: 8-2_norm2
我：（不行，我实在是太好奇了……）什么意思？
8-2：你知道置换的诀窍吗？我是说，决定置换能不能成功的关键。#portrait: 8-2_smile
我：价值相等？
8-2：还不只是这样。你说，我觉得我老板的车子很很值钱，我想给置换了，我能成功吗？
我：当然不能，那又不是你的东西。
8-2：BINGO！不是自己的东西就置换不了。#portrait: 8-2_smile2
我：……（这不是废话吗？）
8-2：我知道你想说什么，不过先别急。你有没有想过，置换的系统——就当它有个系统吧——是怎么判断什么东西属于你吗？#portrait: 8-2_smile
+[法律？]
我：法律有规定吧。
8-2：啊哈！你想说置换的系统和咱们的立法机关有联系？噗……没想到你是这么古典派的人，哈哈…… #portrait: 8-2_laugh
我：（……仔细想想，确实不是这样的。置换，就像是自然的一部分一样。）
->owning_continue
+[气味？]
我：难道说……气味？就像动物一样，人也是有自己的标识的……或者类似的东西。
8-2：嗯嗯，信息素？#portrait: 8-2_smile2
我：对！这个词不错。
8-2：……噗。#portrait: 8-2_chuckle
8-2：噗哈哈哈哈哈！信息素！你说置换系统是靠信息素判断主人的！哈哈哈！我表妹的网络小说里才有这个词…… #portrait: 8-2_laugh
我：（被他这么一说，好像确实是个很愚蠢的答案，真是丢人……）信息素这个词是你先说的吧？
8-2：噗……嗯？是吗？#portrait: 8-2_chuckle
->owning_continue
+[指纹？]
我：指纹？……呃，我知道这听起来怪怪的，但就像警察探案一样，总有办法辨别这东西跟着谁比较久。
8-2：嗯、嗯，你想说的，是不是<color=magenta>痕迹</color>这个词？#portrait: 8-2_smile2
我：痕迹……对、痕迹！
8-2：*自言自语*痕迹学家就快要到这个镇上了吧？这个词在置换里是一个很重要的概念，很接近了……不过，这还不是我的答案。#portrait: 8-2_thinking2
->owning_continue

==owning_continue==
我：*叹气*……你不会要说，你的答案就是那什么，拥有度吧？
我：决定谁拥有什么东西的衡量标准是拥有度——这不是文字游戏吗？
8-2：是，但是也不是。你说，物品知道自己属于谁吗？#portrait: 8-2_smile
8-2：当然不知道。你怎么问老板的车，它也不会答应你。就是老板自己问它也没用。#portrait: 8-2_smile2
8-2：不过，所有人都知道那辆车是老板的，所以它就是。#portrait: 8-2_smile
8-2：拥有这个概念，是人发明、人创造、人使用的。
我：也包括动物，别太人类中心了。
8-2：行！也包括动物。总而言之，谁拥有什么东西，是这个社会的规则。#portrait: 8-2_smile2
8-2：置换知道、置换明白，置换跟人一样聪明，但也和人一样愚蠢。要想拥有一样东西，那唯一的办法就是——
8-2：<b>让所有人都觉得你拥有它</b>。#portrait: 8-2_mysterious
我：包括使用欺骗的方式？
8-2：*轻声*当然，包括。#portrait: 8-2_norm2
8-2：那么提问，该如何拥有一个人呢？#portrait: 8-2_smile2
我：………………
8-2：了解ta的全部，准确描述ta的一切特征。最重要的是——#portrait: 8-2_norm2
8-2：——<b>信任</b>。让ta百分之一百地相信你，相信到觉得自己已经是你的东西。#portrait: 8-2_smile
我：怎么可能……
8-2：怎么不可能？家人。爱人。老师。“拥有”并不是多么罕见的事。#portrait: 8-2_smile2
8-2：更不用说，大多数人出生的时候就拥有一样东西——
我：……自己。
8-2：没错，自己。那么，你应该能理解我说的，第二个重要的隐形数字——
8-2：<color=magenta>拥有度</color>。如果用在人身上，就是你对ta的了解乘以ta对你的信任，所达到的一个值。#portrait: 8-2_smile
8-2：100%的了解和100%的信任叠加，那数值就是完美的1。当然，可能都不需要达到1，有个90分就够置换咯！#portrait: 8-2_smile2
8-2：很遗憾，画家，我能看得见，你对我的信任已经接近0了，所以不用担心了！我拥有不了你，也害不了你。#portrait: 8-2_laugh
我：你知道这番话听起来有多……多……邪恶吗？
8-2：坏了，你觉得我是个糟蛋！#portrait: 8-2_unhappy
8-2：这下我岂不是得拿到一张贼眉鼠眼的肖像画了？不好不好，得挽回我在你心目中的形象。#portrait: 8-2_raiseEyebrowLookAway
我：不必担心，我已经快要画完了。
8-2：那就是生死有命富贵在天喽？#portrait: 8-2_raiseEyebrow
我：……你已经问过我太多问题了，我只想问你一个问题，来作为这幅肖像画的收尾。
8-2：好紧张哦，问、问、问、问、问吧。#portrait: 8-2_smile2
我：<b>你置换过活人吗？</b> 
8-2：瞧你问的！这还用说？我当然……#portrait: 8-2_laugh
8-2：……<b>置换过</b>。#portrait: 8-2_cold #bgm:pause
我：……
8-2：不问我理由吗？#portrait: 8-2_smile
8-2：也不好奇是我的什么人？
我：你会对我说实话吗？
8-2：好问题。不过你不问我，我也不知道怎么答。#portrait: 8-2_thinking #bgm:日常
我：*笑*人各有志，咱俩这萍水相逢，也就不用知道太多了。
8-2：萍水相逢……吗？哈哈。#portrait: 8-2_smile2
我：你的画快画完了，之后你爱讲你的课就加油吧，跟你聊天挺有意思，但我还没到要付费听的程度，今天我还有事……
我：……等等，不对，你……咦？#portrait: 8-2_laugh 
我：8月28日星期三，哈，我说呢，我忘了的那个老朋友，就是你啊！
我：天哪，这都多少年没见了？你也长高太多了……变化这么大，我都认不出来了。
8-2：*叹气*呵呵，哪有多少年……画家，你这日子过得呀，真叫人看不下去。#portrait: 8-2_norm2
8-2：不过，倒是一点儿变化也没有。
我：瞧你这话说得，真不给人面子。
我：说起来我还真有点糊涂，只记得跟人约了见面，结果也想不起来是谁。
我：你从哪冒出来的？来这多久了？
8-2：海边，半个小时前。
我：嗯……嗯？
8-2：你不是看着我<b>冒出来</b>的吗？
我：啊？对，等等，我怎么忘了，你刚出来的时候……连衣服都没穿！
我：你这是去哪儿了？什么情况啊？
8-2：我哪儿也没去。
8-2：或者说……去了<color=magenta>虚空</color>。
我：你……你，你去那地方干嘛？
我：你的意思不会是……你被人置换走了？
8-2：嗯哼。
我：（还真是这样……他消失过！我理解了，所以我才会在他刚出现的时候想不起来他是谁。）
我：那你是怎么回来的？
8-2：这就是我们七分之一兄弟会的顶级机密了。
我：哈？
8-2：你有兴趣成为我们的预备成员吗？有兴趣的话，我就透露一点。
8-2：每一段时间，我们都会有一名成员被置换走，唔，应该叫做出差吗？
8-2：当然，既然是出差，就有回来的一天啦。
我：…………………………
我：我……你……这怎么可能？
我：已经消失过的东西，怎么可能回得来？
8-2：为什么不可能回来呢？
我：没人想得起来消失过的东西。难道不是这样吗？
8-2：呵呵……
我：咳，8-2，那边是什么样子？
8-2：嗯？
我：你知道的，我有点好奇……虚空是什么样子的。
8-2：如果有样子的话，就不叫虚空了。
8-2：……再说了，我也不记得。虚空里装着的只有不存在的东西，我都不存在了，当然也就不知道了。唔，不如说，本来我就没去过？
我：好吧，真是很有帮助的答案。
我：不过，你的画也画完了。

->DONE
