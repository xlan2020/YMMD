INCLUDE ../global.ink
我：（该用什么画材呢？毕竟只是给自己的小稿，用方便<color=green>速写</color>的趁手画材就好了。
我：（这样就算是选好了。写生、写生。）
我：（仔细一看，人真的来了好多，而且还在继续增加。）
我：（不过，最让人感觉不舒服的，还是……）#profile: painter_alert
我：（在场的美人鱼也太多了吧！！）
我：（究竟是有几只啊？她们都穿着类似的衣服……等等，那边吆喝的是——）
老王：这位美女，要不要也买一身美人鱼衣服参赛？
老王：显瘦，显白，拍照可好看了！
我：（……原来全都是从老王无穷小卖部买的服装吗？）#profile: painter_noComment
我：（这样一看，人鱼这样的角色显得——）
 ：好廉价。
 ：真是再俗不过的选择了。
我：（总觉得，这场大赛给人的感觉……）
+[酷毙了]->cool
+[玷污了COSPLAY!]->not_cos
+[玷污了美人鱼！]->not_mermaid

==cool==
我：（能让小镇的人都聚在一起热闹，总是一件令人幸福的事！）【喝彩+】
我：（虽然不知道在期待什么，但总之是期待了。）
->before_contest

==not_cos==
我：（这根本就不是在COSPLAY吧！）【喝彩--】
我：（在奂门这种地方办活动，结果只能是如此了吧。都穿着一样的衣服，还有什么意思？）
我：（只是显眼包们发泄表现欲的场所罢了。真无聊，看完boro酱就回去吧。）
->before_contest

==not_mermaid==
我：（美人鱼才不是这样子。美人鱼明明应该更……）【喝彩-】【追忆+】
我：（……更神秘，更脆弱，更粗野，更忧郁……不。）
我：（我没有资格定义美人鱼是什么样的。COSPLAY大赛还没开始，也许后面有很精彩的演出呢？）
->before_contest

==before_contest==
8-2：嘿！这不是画家吗？
我：嗯？8-2，你也来了。
8-2：【立绘浮现】嘿嘿，今早我四弟掐指一算，说海滩边将有要事发生。
8-2：没想到还有这种活动，我倒要来瞅瞅是什么事儿。
我：想凑热闹的话，不用给自己编这么多借口。#profile: painter_noComment
我：而且，总觉得你这副扮相，你不该出现在我们观众这边。
我：你应该在台上。
8-2：啊哈，我就当是赞美了。那你说，我像是个什么角色啊？
+[大法师]->fashi
+[轮回胎魔【需要看过图鉴】]->lunhui
+[……]->suanle

==fashi==
我：你可以直接说你在COSPLAY魔法大师，活了一千年，还有一个人类妹妹。
8-2：听起来还不错。不过，一个妹妹可不够，兄弟姐妹来六个还差不多。
我：那你还不如直接出个葫芦来得轻松。
->contest_start

==lunhui==
我：你知道轮回胎魔吗？
8-2：噗哈哈哈！那算是什么名字？
我：在一本神秘生物图鉴上看到的。总之，你已经有两只角了，只要再来一对翅膀涂个羊脸就差不多了。
->contest_start

==suanle==
我：……
我：算了，你的本色出演就已经很重量级了。
我：这可不是在夸你！
->contest_start

==contest_start==
8-2：哈哈哈！很可惜，这就是鄙人的日常打扮。
8-2：还没问你呢，画家，你是来凑哪门子的热闹呀？
我：倒也不是凑什么热闹，算是来看朋友吧，还有就是……
我：我在找美人鱼。
 ：8-2向四周看了看。
8-2：要几条？
8-2：还是几斤？
我：不是说这些人！
我：……唉，简直一言难尽……我在找一个消失的人。
8-2：嗯嗯，消失的人呐，感觉是很忧伤的故事耶。
我：（他怎么还这么嬉皮笑脸？）
8-2：看来，一天没见，画家身上又多了些故事哎？我得听你好好说道说……
叭叭叭大嘴鱼：吼↘↗吼→吼↘！奂门的观众朋友们，大家下~午好~！我是主持人叭叭叭大嘴鱼~！叭叭叭叭叭！
我：（好糟糕的名字！好讨厌的主持风格！）
叭叭叭大嘴鱼：欢迎来到由纵享人生水中生活中心特别举办的奂门“海滨幻梦”主题COSPLAY大赛！Carpe~ Diem~！
观众：Carpe Diem！
8-2：Capre Diem！Carpe Diem！
我：（………………………………） #portrait: painter_noComment
我：（拜托，这个人看起来不要太开心！）
叭叭叭大嘴鱼：大赛的人气冠军将由现场的观众投票选出！没错没错，就是你们，每一人都可以决定优胜者的命运！
我：（所以标准是什么啊？不用考虑还原度吗？）
叭叭叭大嘴鱼：人气前三的参赛者将会获得价值无限的特殊奖品——LastLust致幻饮料的任意限量款！……
我：就一瓶饮料？
8-2：他还真没唬人，LastLust有几个限量款，黑市上都炒出器官的价格了。
8-2：特别是那款“人生刷新饮料”风很大，听说过没？
我：再怎么吹，也只是致幻剂吧？
8-2：是“置换”剂。关于你的出身、性别、外貌、甚至年龄……没准都可以重新自定义哦。
我：置换只能换走有实体的东西。
8-2：什么才算是实体呢？年龄不就是细胞的衰老程度吗？
8-2：只要掌握合理的置换技巧，加上一点小小的科技辅助，你就可以自由地掌控自己的人生——
我：你再卖课，我就和你割席。
8-2：真不给面子，我才不是为了赚兄弟的钱。
工作人员：您好，二位拿一下您的喝彩摇摇蛋。
我：咦，给我们的？【左边出现喝彩摇摇蛋，拖到右边关键时候就可以用，没用完的最后背包里会有。】
工作人员：一枚<color=magenta>喝彩摇摇蛋</color>里面有五颗<color=magenta>喝彩换换珠</color>，会在被<color=magenta>置换</color>走的同时发出响声。
工作人员：这是<color=green>投票</color>用的，用的是纯植物材料，没什么价值，用不完的话会很快腐败。请两位在喜欢的选手上台时随意使用。
我：还会腐败？好麻烦的东西。
8-2：他要不加上这一句，没准不懂的人还能多换出点钱来。
我：所以说我不喜欢置换科技产品。又要卖给你，又要控制你的思维。#profile: painter_eyeClosed
8-2：所以你只要掌控……
我：闭嘴！
叭叭叭大嘴鱼：……奂门的参赛者会给我们带来什么样的奇迹呢？库库库~！现在就有请一号参赛者上场！
参赛者1号：大，大家好。我的名字是蝶泪，我扮演的角色是天使蝶泪美人鱼。
天使蝶泪美人鱼：现在，我要向大家展示我的舞蹈，轻盈泪之舞……
我：……这不是随口编出来的角色吗？蝴蝶美人鱼的生理构造到底是什么样的啊？
8-2：啧啧啧！真是看错你了，你就好奇人家的生理构造？
我：我只是想知道她婴儿时期是不是蠕虫！
柔和的女声：传说中，人鱼蝶的幼年期是在水中度过的，跟一般的鱼苗没什么两样，只是在成年之前会在河岸边结透明的茧。
我：她竟然是真的在cosplay！……咦，海名？
海名：又见面了，画家。
海名：你看起来状态还不错。
我：就那样吧，不过，也算是下定决心去找她了。
我：对了，这位是我的朋友……
8-2：哟呵，大痕迹学家。
海名：呵呵，骗子。
8-2：唉呀，宅女刺青妞。
海名：嘻嘻，老六。
我：……你们认识啊？
8-2&海名：不算认识。
我：………………（完了，他们俩绝对有恩怨！）
叭叭叭大嘴鱼：感谢天使蝶泪美人鱼的精彩演出！喜欢她的观众，请摇动手里的喝彩摇摇蛋，置换其中的喝彩换换珠为她应援！记住，一共只有五颗哦！
// 这里可以操作，还有音效
// 同时显示一共会有几个参赛者（剪影）
叭叭叭大嘴鱼：好的，让我们来看参赛者二号登场！
参赛者2号：我的耳朵可以听见，亲爱的渔夫，你在浅滩的呼唤……只是那种粗野的音律，不值得我们鲛人停驻。而此时此刻，我们的相逢，是一场来自大海对陆地的反侵略行动！
海名：啊呀，《鲛音战姬》里的温莎尼露娜！好可爱呢。
我：至少是有真的COSER在场。
8-2：哈哈哈哈！她的妆好搞笑，这个鼻环好大好像牛……
海名：……【怒】
我：……（特别是你，没有任何资格说人家。）
叭叭叭大嘴鱼：感谢二号参赛者又酷~又飒的演出！让我们为温莎尼露娜献上最诚挚的欢~呼！
叭叭叭大嘴鱼：三号？什么？三号在看了过于精彩的演出后，弃权了吗？你确定吗？好吧，我们尊重三号的意愿，那么现在有请四号参赛者登场！
叭叭叭大嘴鱼：哇哦，2号参赛者是一名魅力型男，今天他是不是来COSPLAY猛男鱼的呢？
孟猛：*凶狠地走上舞台*
我：噗——！
8-2：你认识？
我：为什么，总觉得他应该不是自愿的……
海名：噗嗤……哈哈哈……噗哈哈……呜呜……哈哈……
海名：*狂摇喝彩摇摇蛋*
我：（他一定不是自愿的。）
孟猛：*凶狠地走下舞台*
叭叭叭大嘴鱼：四号？四号没有什么要说的了吗？好的，感谢四号短暂但是不失精彩的演出！…
我：（真是一场闹剧。光是看着，就觉得脑子都要炸了。）
海名：…咳，抱歉，失态了。
海名：说起来，在场这么多人鱼，有让画家想起什么吗？
我：很遗憾。
我：…………………
我：不如说，我更有点搞不懂了。
 ：现场好吵。
 ：每一秒，每一处地方都在发出声音。
小孩：呜——哇——————啊~啊——
路人乙：家长干嘛呢？管管啊！
家长：吼谁呢？！啊？你不是从小孩长大的呀！
 ：什么速写，根本没办法进行下去。
叭叭叭大嘴鱼：感谢上一位选手的精彩演出！吼吼~挥舞你的双手，哦~哦，摇~动喝彩的摇摇蛋吧！
 ：叭叭叭大嘴鱼，这个主持真是人如其名。
8-2：画家你看啊，后面有个人COSPLAY王八翻不过来了！
 ：8-2，今天见面起就一副没心没肺的样子，装疯卖傻。
海名：画家，你还好吗？是不是有点中暑？
 ：海名，你和8-2不中暑，画家也不会有事。
 ：我在这里，究竟是来干什么的？
 ：我是为了和boro酱的约定而来的吗？
 ：还是为了寻找潜在的客人？
 ：为了见到美人鱼？这世界上的鱼实在是太多了。
 ：其实我明白的。我如今呼吸的每一秒，都只是为了一件事。
 ：只是为了再次见到那个身影。
 ：只是为了冥冥之中的美梦成真而等待着。
 ：只是为了……
？？？：………………【柴柴立绘浮现】
叭叭叭大嘴鱼：哦哦？看来我们的第29号参赛者很心急呢！她已经大步走上舞台了！
参赛者29号：什么嘛。
参赛者29号：好多人。
参赛者29号：在看我吗？
参赛者29号：我好看吗？
 ：…
大胆的观众：好看！
疯狂的观众：大美女啊！！
参赛者29号：嗯、嗯，这样呀。
参赛者29号：也看够了吧。【冷脸】
叭叭叭大嘴鱼：呃，参赛者29号的扮相也是很有特点，没有选择华丽的服饰，也没有穿戴今年特别流行的鱼尾！
叭叭叭大嘴鱼：这位小姐，请问你扮演的角色是谁呢？大声地说出你的名字吧！
参赛者29号：我吗？
参赛者29号：算了吧，我谁也不是。
海名：画家你干什么去？
 ：……
8-2：算了算了，求偶本能这种事情，总是很难抑制的。
 ：…………【海名和8-2立绘消失】
叭叭叭大嘴鱼：好的，感谢参赛者29号“谁也不是”小姐的精彩表现！请问还有什么话要对观众们说吗？
参赛者29号：……
参赛者29号：…垃圾。【流泪】
叭叭叭大嘴鱼：呃，“垃圾”，参赛者29号说“垃圾”！这是什么意思呢？这是……
大胆的观众：我是垃圾！
疯狂的观众：我是我是！我才是垃圾！
叭叭叭大嘴鱼：……这是在今年的“海滨幻梦”主题中，呼吁我们保护大海、减少垃圾污染的意思！哈哈，还请大家在散场后收拾好个人物品，不要进行违规置换哦！
疯狂的观众：什么烂主持？
大胆的观众：嘘——
叭叭叭大嘴鱼：…请大家为“谁也不是”小姐欢呼吧！摇动你们手里的狂欢、呃、喝彩摇摇蛋吧！
疯狂的观众：等等，她怎么下场了！
观众们：29号！29号！
观众们：我爱你！❤❤~！
 ：欢呼声响彻沙滩。
 ：…………
我：（等等，她刚才明明是从这个口下来的。）
我：（为什么转眼就不见了？）
我：（这怎么可能？为什么、为什么又是这样……）
我：（她为什么又在眼皮底下消失了？）
我：（糟糕，现场的人真的太多了，不止我一个人想要去出口堵她。）别挤！
大胆的观众：你别挤！
疯狂的观众：喂，你有看到29号吗？
大胆的观众：“谁也不是”小姐去哪了？
我：（看来问别人也不会有结果了。真是……哈哈，又是这样……）
我：（这一次，总不可能是幻觉了吧？）
？？？：嘿，画家！
藏羚羊：你找到那个人了吗？
我：没有！
藏羚羊：……
藏羚羊：这在镜头里或许不是坏事，但是画家，你怎么总是这么情绪化？
我：……对不起，藏羚羊，我有点顾不上这个了——你看到29号了吗？
我：就是她。
藏羚羊：什么意思？那个态度恶劣的参赛者29号就是你要找的美人鱼？
我：对。
藏羚羊：可是，这么多参赛者里，她是少数没穿鱼尾的，你认定她是美人鱼，有根据吗？
我：没根据……你看到她了吗？
藏羚羊：没有。她下台就消失了。
藏羚羊：画家？
藏羚羊：……
藏羚羊：虽然我还搞不懂你为什么认定就是她，但无论如何，你有没有想过一件事。
藏羚羊：这是一场COSPLAY大赛，台上的人是COSER，是角色。就算那真是你要找的人，也不会是真实的吧？
我：她可能只是不懂吧。
我：她总是那样子，就刚才那样，一幅不知道身在何处的感觉。
我：总觉得还挺……
藏羚羊：惹人怜爱？
藏羚羊：没想到你这么纯情。这种表现我见多了，无一例外，全都是精心设计好的。
藏羚羊：……
藏羚羊：怪我说话太直接吗？
我：没有的事，你是对的。
我：嗯，我们回去看比赛吧。COSPLAY大赛，还挺有趣的吧？
+[找座位坐下]->contest_resume

==contest_resume==
叭叭叭大嘴鱼：好了，30、31、32、33都退赛的情况下，接下来的参赛者，是否还能掀起29号那样的狂潮呢？呃，这位观众请先回到座位……
叭叭叭大嘴鱼：……让我们拭目以待。现在有请34号参赛者登场~！
boro酱：………………
我：（咦？已经到boro酱登场了吗？）
我：（她看起来有点紧张，要不要为她加油呢？）
+[加油boro酱！]->cheers
+[算了吧]->no_cheers

==cheers==
我：boro酱——！！加——油——啊！
我：（这一下，真是用光所有的勇气了啊。那家伙的头套太大了，也看不出来有什么反应。）
我：（咦，她好像抬头了。我的鼓励有效果吗？）
->boro_time

==no_cheers==
我：（这么多人面前，果然还是有点拉不下脸来。我只能在心里为你起到了，boro酱！）
我：（咦，她好像抬头了。我的祈祷有效果吗？）
->boro_time

==boro_time==
boro酱：…………大……大家，大家好…………
叭叭叭大嘴鱼：你好呀参赛者34号，面对29号带来的压力，你是如何调整心态的呢？是对自己的演绎很有自信吗？
boro酱：……我是，我是，是，是……bo，bo，boro…酱………
叭叭叭大嘴鱼：呃，好的，参赛者34号的答复是，她是boro酱！是不是身为boro酱，就会有这样的信心呢？
boro酱：boro……boro……
boro酱：boroboro刨冰…………
叭叭叭大嘴鱼：boro……菠萝刨冰？好的，参赛者34号，是不是演绎着一个喜欢菠萝味刨冰的可爱女生角色呢？
boro酱：……世界上最好吃的刨冰…闻起来……
boro酱：……闻起来臭臭……吃起来香香的boro酱……
boro酱：……新鲜秘制酱料，一、一口爱上……
我：（糟了！她不会是……）
boro酱：……忘不掉的美味boro酱……尽在boroboro刨冰……
大胆的观众：广告？
叭叭叭大嘴鱼：参赛者34号，请根据你的角色作出表演，哦？
叭叭叭大嘴鱼：观众朋友们~我们的活动由Carpe Diem公司独家赞助，唯一指定冠名产品LastLust致幻饮料，和任何其他企业均无关系！
boro酱：……最美味的刨冰，就在奂门海滨大道东侧……常驻……
我：（不要再继续下去了啊！至少，至少植入得软一点啊！）
大胆的观众：嘘————
疯狂的观众：嘘————
 ：台下嘘声一片。
叭叭叭大嘴鱼：参赛者34号，请不要干扰比赛秩序，现在马上离开舞台。
boro酱：……清晨8点准时营业……闻起来香……臭臭吃起来臭臭、吃起来…
疯狂的观众：滚啊！这种时候打什么广告！
愤怒的观众：什么东西，谁要吃你的臭刨冰啊！
我：（救命，不要再念稿了……）
boro酱：……吃起来香香的…………
叭叭叭大嘴鱼：这位观众！请回到自己座位，不要进入舞台！……参赛者！请立刻离开舞台！安保！
boro酱：……boro、boro……
叭叭叭大嘴鱼：全都给我下去——安保——！安保！
愤怒的观众：去他妈的广告！
 ：……
 ：愤怒的观众冲上了舞台。
 ：愤怒的观众和参赛者34号“boro酱”发生了争执。
 ：参赛者34号“boro酱”的头套飞了出去。
 ：头套之下……
 ：……是一个鱼头。
 ：……
 ：……………
 ：…………………………
 ：………………………………………………………………………………………………………………………………………………………………………………………………
观众：天哪！怪物！
观众：啊啊啊啊啊啊啊啊啊！鱼头怪物啊！
观众：快跑啊啊啊啊啊啊啊！
鱼头人“boro酱”：……
鱼头人“boro酱”：呜……呜呜…………
鱼头人“boro酱”：呜呜呜呜……呜呜……呜……
 ：鱼头人的哭泣好似啸叫，仿佛能听到水滴的声音。
 ：无论有没有那个滑稽的头套，都没有人能读懂它的表情。
 鱼头人“boro酱”：呜呜呜…………呜……呜……………
 ：它离开了。
->END




//下一届cosplay大赛冠军cosplay上一届cosplay冠军