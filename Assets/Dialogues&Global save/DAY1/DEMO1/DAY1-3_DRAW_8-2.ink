INCLUDE ../../global.ink
INCLUDE DAY1-2_global.ink
8-2：啊哈！别说，还真是一穷二白。让我别动你东西，你也得有东西让我可动啊？#bgm:日常 #profile: painter_mad #portrait: 8-2_smile2
我：（画箱还是被他打开了……）这下您满意了吧？能让我一个人安静会儿吗？#profile: painter_side
8-2：哎呦，没<color=magenta>画材</color>你就不会画画了？#portrait: 8-2_laugh
8-2：你<b>以前</b>可不是这样的。#portrait: 8-2_admire
8-2：再看看箱子里的东西吧。真的没什么能拿来画画的东西吗？#portrait: 8-2_smile
我：咦？仔细一看还真是……有了！#profile: painter_surprised
【操作】：【此时点击背包里的东西，会出现新的note。】
系统：收集到的<color=magenta>物品</color>可以作为<color=magenta>画材</color>使用，分为纸、笔、颜料三类。
系统：每次使用画材时会消耗1点<color=magenta>耐久</color>，<color=magenta>耐久</color>清空后物品会<color=magenta>消失</color>。
系统：注意，耐久消耗过多时，物品的置换价值也会随之发生变化。
系统：个别特殊的物品则不可作为画材使用。
我：（我有主意了。不过在此之前，还有重要的事情需要确认……）#profile: painter_side
我：呃，你刚才说的给钱，算数吗？#profile: painter_sideSweat
8-2：当然，咱俩谁跟谁啊！行，你要还不信的话……#portrait: 8-2_laugh
8-2：这是定金。#addMoney: 100 #profile: painter_stunned #portrait: 8-2_mysterious
我：（我去！骗子怎么可能先给我钱？）尊贵的先生，请问您想要什么样的画呢？#profile: painter_happy
系统：不同的画材会对画面产生不同的效果，有稳定、生机、实验和昂贵四种属性。
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
我：（现在拥有的材料还是太有限了，先凑合着用吧，反正对方是8-2。）#profile: painter_norm #portrait: 8-2_norm2
我：（……嗯？我刚刚在想什么？怪怪的。还是先决定画什么吧。）#profile: painter_side
我：肖像画，对吧？#profile: painter_norm
8-2：老规矩，当然可以。#portrait: 8-2_smile2
8-2：……#portrait: 8-2_cold
8-2：……等等，你对着我量什么呢？不会就要画速写了吧？#portrait: 8-2_raiseEyebrow
8-2：停停停！你得把对我最深刻的理解体现出来。“画画，是对事物的准确描述！”#profile: painter_eyeClosed
8-2：我要的可不是眼前的我，而是更本质的我，之前的我，<b>真正</b>的我。#profile: painter_noComment #portrait: 8-2_deepLove
我：呃，你年轻的时候……吗？#profile: painter_side
8-2：…………………… #portrait: 8-2_norm3 #bgm: fade_2_0.2
我：…………………#profile: painter_sideSweat
我：抱歉。
8-2：*叹气*咱们慢慢来吧。#portrait: 8-2_norm2
我：（……无论如何，我确实下笔太草率了。）
我：（画画的第一步是<color=magenta>观察</color>，除了死板的比例关系，我还得把<color=magenta>对象</color>——也就是8-2——的精气神儿抓住。）
我：（仔细观察对象吧，有什么可以<color=magenta>捕捉</color>的东西吗？）
【操作】：【observee-8-2的脸-出现】
系统：在画画过程中，屏幕中会时不时出现可以捕捉的<color=magenta>观察点</color>。
系统：在观察点上单击<color=magenta>鼠标左键</color>，将其<color=magenta>拖放</color>到<color=magenta>构想窗口</color>内，观察点会自动转变为<color=magenta>灵感</color>。
系统：未来，画家可能会持有多种灵感。选择呈现合适的灵感，会改变画画的结果，也决定了画家对绘画对象的态度，故事因此发生改变。
系统：在需要的时机把灵感呈现在<color=magenta>画布</color>上，才能让画画进行下去。
系统：咦，画布已经亮起了。现在，试着把灵感拖放到画布上吧！
+[提交：8-2的脸]->mama_appears
==mama_appears==
我：（果然，我不应该用年轻这个词来形容8-2。再看看他吧，还有什么值得注意的……嗯？那个是……老板娘。我的饭！）
老板娘：给您放桌上了！#profile: mama_satisfied  
老板娘：呦，朋友也来啦？哎呀，你是不是那个……那个谁，那个八加二大师？#bgm:戏谑_0.5
我：（噗……大师？）#profile: painter_sour
系统：除了视觉上的观察，声音、语言、气味都可以成为构想画面的重要信息。除了对象附近，观察点也可以出现在屏幕的任何地方。
系统：对于普通的观察点，只有捕捉才能让画画进行下去。
系统：但是，个别的观察点会随着对话发展而被<color=magenta>错过</color>，从而限制故事的走向。错过不一定是坏事，但这点还请留意。
系统：关于观察点，之后不会再有提醒了。画家要记得观察和捕捉哦！
【操作】：【需要捕捉observee才能进行下去。要改一个点，observee出现和必须捕捉是两回事】
8-2：咳，巴简二，姐姐。#portrait: 8-2_smile2
老板娘：对对，瞧我这记性。我爱人经常听你的课嘞！#profile: mama_satisfied
老板娘：多亏了大师呀，他要不是辞去了那个打渔的活儿，我天天都得揪心呐。
老板娘：现在好啊，靠着置换也发了点小财，一天赚的比以前跑三趟还多！
8-2：不用谢，姐姐。我这个人啊，没别的爱好，就是喜欢帮助别人。#portrait: 8-2_deepLove
老板娘：大师的心地就是好呀……给您上点儿茶水。想要什么尽管点，您叫这个名，我就给您打六折！
8-2：哈哈，看来我得改名叫巴简七了。#portrait: 8-2_smile2
老板娘：哎呦，大师可真爱开玩笑！呵呵，八减七不成了一折了……
老板娘：您先看着菜单，有需要再叫我啊！
8-2：没办法，粉丝就是这么多，看来以后得低调点了。#bgm:日常_5 #profile: painter_side #portrait: 8-2_laugh
8-2：……我去！一没留神，你怎么都给炫完了？#portrait: 8-2_surprised
我：我很饿……嗝。嗯，现在饱了。#profile: painter_sideSweat
我：（在接单的时候吃饭，可真是不专业的表现。现在开始专注在对象上吧，应该从哪开始呢？）
+[提交：大师]->profession_mathematician

==profession_mathematician==
我：你是做什么职业的啊，“大师”？#profile: painter_norm
8-2：我是个数学家。#portrait: 8-2_smile
我：（8-2的数学吗？）呃，你给老板娘的爱人……上数学课？#profile: painter_side
8-2：哦，那个是另外的兼职。数学是一门很基础的学科，数字是构成这个世界的基本单位。 #portrait: 8-2_norm2
8-2：1就是有，0就是无。<br>1是真理，0是假货。#portrait: 8-2_smile
8-2：我每天的工作就是研究存在和真理。就像你是个画家一样，我是个数学家。#portrait: 8-2_deepLove
我：（哈？这比我每天探究艺术的真谛还要离谱呢。）……所以，是自封的。#profile: painter_norm
我：而且你这个1和0的说法，听着更像是数字命理学之类的吧？
8-2：嗯，嗯，你就是这么理解的吗？浅了啊，画家。#portrait: 8-2_laugh
8-2：数字可是很重要的！看看你头顶上，那里可是有个很显眼、很重要的数字。#portrait: 8-2_smile2
【操作】：【observee-钱出现。这个可以skip】
我：（很显眼、很重要的数字，是……）#profile: painter_stunned
+[{money}]
我：头顶上的数字……{money}？
我：等等！你怎么能看到我头顶上……这个是我的、我所有财产的金额！#bgm:戏谑_0.5 #profile: painter_frightened #portrait: 8-2_smile
8-2：哦~原来你的所有财产是这个数字啊。#portrait: 8-2_laugh
我：……哎？#profile: painter_side 
8-2：这可是你告诉我的呀~画家~#profile: painter_sideSweat 
我：……………………
我：你这个骗子！#profile: painter_mad 
8-2：不，我只是个数学家。#portrait: 8-2_mysterious #bgm:日常_3
->value_number
+[什么数字？]
我：哪里有数字？你在逗我吗。#profile: painter_noComment 
8-2：哎呀，不就是{money}吗！你自己看不到？#portrait: 8-2_smile
我：嗯？{money}，这个……这个是……#profile: painter_stunned #bgm:pause
我：这是我所有财产的金额！#profile: painter_frightened #portrait: 8-2_laugh #bgm:戏谑_0.5
我：等等！你怎么知道的？#profile: painter_surprised
8-2：我说过，我是个数学家。#portrait: 8-2_mysterious
我：你这人还真有点邪门儿。#profile: painter_happy
我：（不过，多半是刚才翻包的时候瞧见的吧。现在的骗术可真是防不胜防。）#profile: painter_norm #bgm:日常_3
->value_number

==value_number==
我：呵呵，这也算数学吗？#profile: painter_side
8-2：这当然算数学了。本来，人的生活中有很多有意义的数字，不过现在最重要的，就只剩下这个数—— #portrait: 8-2_norm2
8-2：——代表<color=magenta>价值</color>的数。#portrait: 8-2_norm3
8-2：每个人头上都顶着这个数，每件东西上也都悬着这个数。当然，我说的可不是商店里的标价，而是那个虚虚乎乎的，每个人都知道，但每个人看到的都不一样的——#portrait: 8-2_smile
8-2：——所谓<color=magenta>心理价值</color>。把那玩意置换掉了，你钱包里也就会多出这个数。
8-2：但就这么一个数，人也还是看不清楚。#portrait: 8-2_thinking
8-2：所以呢，我的置换成功学课程也就应运而生。哈哈，你刚问我教那老爷子什么，这么说吧，我兼职做的是讲师。#portrait: 8-2_smile2
我：（果然，不出我所料。）……你是个兼职骗子。#profile: painter_side #portrait: 8-2_laugh
【操作】：【收集observee-8-2脸上的坏笑。说他是骗子的时候，他还笑了！怎么有这么厚颜无耻的人？】
我：你居然还好意思说自己研究真理……天，你真应该向老板娘道歉。
8-2：瞧你说得多难听，这怎么能叫骗人呢？#portrait: 8-2_norm
8-2：多少人都不了解自己想要什么，能失去的是什么……换来换去，换得一场空。#portrait: 8-2_thinking
8-2：我只是在帮助大家掌控自我罢了。
8-2：说到这了，画家，咱们打开天窗说亮话。我能感觉到——你身上是不是也发生过类似的事？#portrait: 8-2_deepLove
8-2：如果能更了解自己的话，就不会闹得一无所有，还一无所知了。
【操作】：【收集observee-深沉的、仿佛闪烁着泪光的眼睛，仿佛能轻易看穿我内心的想法、我的过去，却还保持着一种一视同仁的悲悯！】
我：……………………#profile: painter_side
我：（别说，今天睡醒的事我还真是想不明白，这家伙或许能知道点什么。）#profile: painter_sideSweat
我：（我该相信他的话吗？）#profile: painter_norm
系统：目前可以呈现的灵感有两种，必须要做出<color=magenta>选择</color>了。
系统：选择不同的灵感会给画面带来改变，也决定了画家对绘画对象的<color=magenta>理解</color>和<color=magenta>态度</color>。未来说不定会因此发生改变！
我：（必须要做出选择了……我该相信8-2吗？）
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
8-2：…………………………哎呀！#portrait: 8-2_surprised #bgm: fade_2_0.3
8-2：手滑了！掉到哪里去了？#profile: painter_stunned #portrait: 8-2_norm #portrait: 8-2_surprised
我：你做什么！这么重要的东西，我看看，我看看，是不是掉到地上了……#profile: painter_frightened #bgm: fade_1_0.1
8-2：哎呀，不慌不慌，原来是掉到我另一只手上了。#portrait: 8-2_smile2
我：……哈？#profile: painter_surprised
8-2：上当了！啊哈哈哈哈哈~#profile: painter_noComment #bgm:戏谑_0.3 #portrait: 8-2_laugh
8-2：你也太容易相信别人了，画家，这样下去很危险的。这么重要的东西，怎么能轻易交给别人呢？#profile: painter_angry #portrait: 8-2_smile
8-2：我好好看了啊，这是一枚……鱼鳞！至于什么鱼嘛，要不你问卖鱼的试试？#portrait: 8-2_smile2
我：……………………还给我。#profile: painter_mad
8-2：好了好了，给你。开个玩笑，别生气嘛。
8-2：…………#profile: painter_angry #portrait: 8-2_norm2 #bgm:日常_5
8-2：*自言自语*难不成我真的很讨人嫌？好吧，这下要从0.5跌到0.2了，不，甚至更低……#portrait: 8-2_thinking2 
8-2：不对不对，0.15？#portrait: 8-2_raiseEyebrowLookAway
我：（这个混蛋，绝对不值得信任……）你在嘟囔什么？#profile: painter_side
->owning_value

==reveal_liar==
我：所以呢，你打算向我卖课吗？#profile: painter_side #bgm:fade_0.2_0.5
我：先是装作认识我的样子，然后给我点小钱博取我的信任，还让我画画，哈，我就知道没什么人想要我的画的，又是用的这么廉价的画材。#portrait: 8-2_norm2 #bgm:悬疑_1
我：然后，你利用老板娘给自己立了个“大师”的人设，让我主动问你，免得一上来就推销让人怀疑……天，老板娘不会是你的托儿吧？
我：然后你东拉西扯，故意拿“数学家”和“画家”类比，跟我套近乎。
我：早在你动我包的时候就瞄到我有多少钱了，偷偷记住了这个数，过了很久冷不丁说出来，显得自己很神通。
我：然后就该卖课了吧？如果我说我没钱买课，你是不是该推荐个熟人给我放贷了？#portrait: 8-2_norm
我：行，现在的骗术是挺厉害的，我算是服了。不过大哥，下次还是别做这行了，迟早报应！#profile: painter_angry
8-2：真是不错的推理。虽然从最开始就错了，不过画家，你的智慧又长进了。#portrait: 8-2_smile2 
8-2：我得记下来……画家……-0.5……#portrait: 8-2_thinking2
我：你在说什么？我摊开说了哈，我不信你。#profile: painter_side
我：实在咽不下这口气，就把你的100块本金收回去吧。#portrait: 8-2_norm2
8-2：你还真是清高啊画家，都穷成这样了，连“骗子”的钱都不好意思吞？#portrait: 8-2_smile2
8-2：我说了，那是给你的定金。定金你收了，画呢，也得给我。委托也是生意，生意讲究诚信。#portrait: 8-2_norm
我：（骗子跟我讲诚信？）行，行，那我说到做到。我会把你的<b>真面目</b>给如实画出来的。#profile: painter_norm #bgm:日常_5
我：那我把画给你，你也得给我报酬。呵呵，你要想给我两分一毛的羞辱我，我也认了。#profile: painter_selfMock #portrait: 8-2_norm2
8-2：拜托，要不要这么敏感？#portrait: 8-2_unhappy 
8-2：看来-0.5还不够了，画家……-0.6？不对，那样就变成负数了…… #portrait: 8-2_thinking2 
我：（他在念叨什么？……算了，这明显是个套儿，不要理他，赶紧把画画完吧。）#profile: painter_side
8-2：-0.55吧，现在估计已经接近0了……#portrait: 8-2_raiseEyebrowLookAway
我：（不能被他牵着跑……不能……）
我：……你在念什么？#profile: painter_side
->owning_value


==owning_value==
8-2：终于舍得问啦？嘿嘿，这是每个人第二个重要的数。#portrait: 8-2_smile2
8-2：我管这个数叫做——<color=magenta>拥有度</color>。#portrait: 8-2_norm2
我：（不行，我实在是太好奇了……）什么意思？
8-2：你知道置换的诀窍吗？我是说，决定置换能不能成功的关键。#portrait: 8-2_smile
我：价值相等？
8-2：还不只是这样。你说，我觉得我老板的车子很很值钱，我想给置换了，我能成功吗？
我：当然不能，那又不是你的东西。
8-2：BINGO！不是自己的东西就置换不了。#portrait: 8-2_smile2
我：……（这不是废话吗？）
8-2：先别急，你有没有想过，置换的系统——就当它有个系统吧——怎么判断东西是不是属于你的？#portrait: 8-2_smile
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
8-2：噗哈哈哈哈哈！信息素！你说置换系统是靠信息素判断主人的……哈哈哈！我表妹的网络小说里才有这个词…… #portrait: 8-2_laugh
我：（被他这么一说，好像确实是个很愚蠢的答案，真是丢人……）信息素这个词是你先说的吧？
8-2：噗……嗯？是吗？#portrait: 8-2_chuckle
->owning_continue
+[指纹？]
我：指纹？……呃，我知道这听起来怪怪的，但就像侦探探案一样，总有办法辨别这东西跟谁比较久。
8-2：嗯、嗯，你想说的，是不是<color=magenta>痕迹</color>这个词？#portrait: 8-2_smile2
我：痕迹……对、痕迹！
8-2：*自言自语*痕迹学家就快要到这个镇上了吧？这个词在置换里是一个很重要的概念，很接近了……不过，这还不是我的答案。#portrait: 8-2_thinking2
->owning_continue

==owning_continue==
我：*叹气*……你不会要说，你的答案就是那什么，拥有度吧？#portrait: 8-2_norm2
我：“决定谁拥有什么东西的衡量标准是拥有度”——这不是文字游戏吗？
8-2：是，但是也不是。你说，物品知道自己属于谁吗？#portrait: 8-2_smile
8-2：当然不知道。你怎么问老板的车，它也不会答应你。就是老板自己问它也没用。#portrait: 8-2_smile2
8-2：不过，所有人都知道那辆车是老板的，所以它就是。#portrait: 8-2_smile
8-2：拥有这个概念，是人发明、人创造、人使用的。
我：也包括动物，别太人类中心了。
8-2：行！也包括动物。总而言之，谁拥有什么东西，是这个社会的规则。#portrait: 8-2_smile2
8-2：置换知道、置换明白，置换跟人一样聪明，但也和人一样愚蠢。要想拥有一样东西，那唯一的办法就是——#portrait: 8-2_smile
8-2：<b>让所有人都觉得你拥有它</b>。#portrait: 8-2_smile2
我：包括使用欺骗的方式？
8-2：当然，包括。#portrait: 8-2_smile
8-2：那么提问，该如何拥有一个人呢？#portrait: 8-2_laugh
我：………………
8-2：了解ta的全部，准确描述ta的一切特征。最重要的是——#portrait: 8-2_deepLove
8-2：——<b>信任</b>。让ta百分之一百地相信你，相信到觉得自己已经是你的东西。#portrait: 8-2_smile
我：怎么可能……
8-2：怎么不可能？家人、爱人、师生……“拥有”并不是多么罕见的事。#portrait: 8-2_smile2
8-2：“我是你的”——这句话听着挺浪漫、挺耳熟吧？
【操作】：observee-我是你的 8-2会对别人说这句话吗？好难想象啊，恐怕不会吧。灵感是8-2深情款款地说我是你的的样子
8-2：更不用说，大多数人出生的时候就拥有一样东西——
我：……自己。
8-2：没错，自己。虽然，随着时间推移，也有人会丢失“自己”这样东西。
8-2：现在，你应该能理解我说的，第二个重要的隐形数字——
8-2：——<color=magenta>拥有度</color>。如果用在人身上，就是你对Ta的了解乘以Ta对你的信任，所达到的一个值。#portrait: 8-2_smile
8-2：100%的了解和100%的信任叠加，那数值就是完美的1。当然，可能都不需要达到1，有个90分就够置换咯！#portrait: 8-2_smile2
【操作】：observee-90分 他怎么知道这些数值的？……难道说，他拥有很多人？灵感是邪恶的8-2一双大手操纵一堆人的样子
8-2：很遗憾，画家，我能看得见，你对我的信任已经接近0了，所以不用担心了！我拥有不了你，也害不了你。#portrait: 8-2_laugh
我：你知道这番话听起来有多……多……邪恶吗？
8-2：坏了，你觉得我是个糟蛋！#portrait: 8-2_unhappy
8-2：这下我岂不是得拿到一张贼眉鼠眼的肖像画了？不好不好，得挽回我在你心目中的形象。#portrait: 8-2_raiseEyebrowLookAway
我：不必担心，我已经快要画完了。
8-2：那就是生死有命富贵在天喽？#portrait: 8-2_raiseEyebrow
我：……你已经问过我太多问题了，我只想问你一个问题。
8-2：好紧张哦，问、问、问、问、问吧。#portrait: 8-2_smile2
我：（关于8-2的肖像应该是什么样子，我已经有了大概的答案。只剩下，我想问的问题是……）
【鹅】：特别是这里，感觉投递选项的时候应该有办法预览问的问题是啥，也许hover到画画board的时候对话框/细节框会出现具体的问题？
+[你置换过活人吗？]
我：<b>你置换过活人吗？</b> 
8-2：瞧你问的！这还用说？我当然……#portrait: 8-2_laugh
8-2：……<b>置换过</b>。#portrait: 8-2_cold #bgm:pause #bgm:fade_0.1_0
我：……
8-2：不问我理由吗？#portrait: 8-2_smile #bgm:play #bgm:fade_1_0.15
8-2：也不好奇是我的什么人？
我：你会对我说实话吗？ #bgm:fade_0.5_0.3
8-2：好问题。不过你没问出口，我也不知道我会怎么答。#portrait: 8-2_thinking #bgm:fade_3_1
我：*笑*人各有志，咱俩这萍水相逢，也就不用知道太多了。
8-2：萍水相逢……吗？哈哈。#portrait: 8-2_smile2
->almost_done
+[有其他人拥有你吗？]
我：有其他人拥有你吗？
8-2：…………#portrait: 8-2_norm2
8-2：为什么这么问？#portrait: 8-2_smile
我：你在这里侃侃而谈，还开课传授什么掌控自己、操纵别人的秘诀……高高在上的。
我：不过，被拥有的人是什么感觉，你也能理解吗？
8-2：瞧你问的！我成什么人了？我当然…… #portrait: 8-2_laugh
8-2：……理解。有很多人都拥有我，随时随地可以置换我。#bgm:pause #bgm:fade_0.1_0 #portrait: 8-2_admire
8-2：被拥有是危险的，但也是幸福的。没被他人拥有的家伙……嗯，那句话怎么说的来着？……只能度过相对失败的人生！#bgm:play #bgm:fade_1_0.2 #portrait: 8-2_norm2
8-2：…………怎么？被我的言论感动到了？哈哈！这句说得真好，我得记下来下次上课讲…… #bgm:fade_4_1 #portrait: 8-2_smile
我：大可不必。……而且这也不是你的原创吧。
我：不过，就说是艺术的直觉吧……我很喜欢这句话。#portrait: 8-2_laugh
->almost_done

==almost_done==
我：给你的画快画完了，之后你爱讲你的课就加油吧，跟你聊天挺有意思，但我还没到想要付费听的程度。今天我还有事……
我：（……对啊！明明是有事的，怎么现在才想起来？）#bgm: fade_3_0.2
我：（8月26日星期三，我有个老朋友要从远方过来，我们约在……热麻麻门口见面……热麻麻？那不就是这里吗……咦？）
我：……等等，不对，你……啊？#portrait: 8-2_smile #bgm: fade_0.5_0
我：我要见的那个老朋友，不会就是你吧？！#portrait: 8-2_laugh #bgm:戏谑_0.2
我：我去，这都多少年没见了？……你的变化也<b>太</b>大了！……我都认不出来了。
8-2：*叹气*呵呵，哪有多少年……画家，你这日子过得呀，真叫人看不下去。#portrait: 8-2_norm
我：说起来我还真有点糊涂，跟人约了见面，结果也想不起来是谁。哎？但现在怎么就想起来了……
我：嗐，都怪你冒出来的时候太吓人了。你……呃？等等，你从哪里冒出来的？#portrait: 8-2_smile
我：你刚出来的时候……连衣服都没穿！你这是去哪儿了？
8-2：我哪儿也没去。
8-2：或者说……去了<color=magenta>那边</color>。我去了<color=magenta>虚空</color>。#portrait: 8-2_norm
我：你……你，你去那边干嘛？
8-2：出差。#portrait: 8-2_laugh
我：……啊？
我：你的意思不会是……
我：……你被人置换走了？
8-2：嗯哼。#portrait: 8-2_smile
我：（还真是这样……他<color=magenta>消失</color>过！）
我：（出现和消失的过程都是<color=magenta>逐渐</color>的，所以在他刚出现的时候，我才会记不起他是谁。）
我：那你是怎么回来的？
8-2：这就是我们<color=magenta>七分之一兄弟会</color>的顶级机密了。#portrait: 8-2_laugh
我：………………
8-2：怎么样，你有兴趣成为我们的预备成员吗？#portrait: 8-2_smile2
+[我有兴趣！]
我：听起来有点儿意思。你们都做什么？
->disclose_secret
+[算了吧]
我：呃………………#profile: painter_sideSweat
8-2：谨慎的家伙。好吧，那我就大发慈悲地透露一点儿。
->disclose_secret

==disclose_secret==
8-2：每隔一段时间，我们都会把一名宝贵的成员置换走，以此换取一大笔流动资产。这就叫做出差。#portrait: 8-2_smile
8-2：既然是出差，那当然就有回来的一天啦。#portrait: 8-2_laugh
我：………………………………（什么人会加入这种兄弟会啊！）
我：你……你们……这怎么可能？#portrait: 8-2_smile
我：已经消失过的东西，怎么可能回得来？
8-2：为什么不可能回来呢？
我：没人想得起来消失过的东西。难道不是这样吗？
8-2：呵呵……#portrait: 8-2_mysterious
我：咳，8-2，那边是什么样子的？
8-2：如果有样子的话，就不叫虚空了。#portrait: 8-2_norm
8-2：……再说了，我也不记得。虚空里装着的只有不存在的东西，我都不存在了，当然也就不知道了。唔，不如说，其实我根本没去过？#portrait: 8-2_thinking
我：好吧，真是很有帮助的答案。#portrait: 8-2_smile
我：不过，你的画也画完了。

->DONE
