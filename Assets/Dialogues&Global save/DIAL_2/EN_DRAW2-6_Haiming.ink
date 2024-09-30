INCLUDE ../global.ink
我：（海名的工作室看起来可真棒，在这里画画倒是一件美事。）#profile: painter_side #portrait: haiming_3_idle #bgm: 日常_0.2 #drawingSystem: addBinaryVal_50
我：（说来惭愧，我自封为画家，却连自己的工作室也没有。“流浪”这个浪漫的名号，也有些迫不得已的成分。）#profile: painter_sideSweat
我：（咦，不过海名好像也住在工作室里？……瞧我，明明不是第一次来了，总觉得印象有点模糊。）#profile: painter_side
我：（无论如何，先专心眼前的事吧！）这次的稿件，会被转化成文身吗？#profile: painter_norm
海名：当然，如果有客户喜欢，就会纹在身上，另外也会挑一些合适的做成纹身贴。#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
我：那么，对作画的材料有要求吗？#profile: painter_norm #drawingSystem: showMaterialWindow
海名：嘿，这是你的画箱吗？很酷。#profile: hide 
海名：毕竟我会后续做处理，你按照自己的习惯画就好。不过，原稿轮廓清晰的话，我处理起来也方便些，能够精细一些就再好不过了。#drawingSystem: selectMaterial
->theme

==theme==
我：没问题。题材还是“海底怪兽”，对吧？#profile: painter_side
海名：没错。我这里姑且也有个店名，就叫“神秘生物研究所”，怪兽、异兽、神兽，不管是古籍史册还是坊间传闻，甚至漫画里的怪物，都是我的创作主题。#portrait: haiming_3_pushGlass #profile: hide 
我：（她的确对这些事情痴迷，这一点从<color=green>发饰</color>就能看出来。不过，有一点……）#showObservee: seaSlug #choiceType: OBSERVEE
//【捕捉：
//左边：海名发饰中的海蛞蝓
//右边：细致的海蛞蝓（说起来鹅鹅demo的时候好像p过这个图，我回头发来看看要不要直接用）
//描述：这家伙的发饰，似乎是一种海洋生物？不过，总觉得和神秘还有些距离。】
+[海蛞蝓提交]
->theme_continue

==theme_continue==
我：海蛞蝓、水母……说起来，这些都是浅海就能看到的生物，甚至奂门都有。而“海底怪兽”，是住在深海的吧？#profile: painter_side #choiceType: BUTTON
海名：很敏锐嘛。#profile: hide #portrait: haiming_3_squint
海名：我也在想，我的脑袋里是不是也有点老学究的古板，一面喜欢幻想题材，另一面，又偏要找出传说和这些可以触及的东西之间的联系。#portrait: haiming_3_norm
我：从一个画家的角度来说，这就像是写生练习？就算最终要创作出不存在的事物，也得先参考这些肉眼可见的事物。#profile: painter_side 
海名：可以这么说。#profile: hide
我：所以，你其实不相信神秘生物的存在？#profile: painter_side
海名：这个还是相信的。#profile: hide #portrait: haiming_3_squint
海名：那些传说中的怪兽，大概永远不会有一天被关在水箱里展示给所有人，但却留下了无数故事。#portrait: haiming_2_idle #portrait: haiming_2_think
海名：真实存在的地点、目击者、史书的记载、画像……全都是它们存在过的痕迹。#portrait: haiming_2_thinkSquint
海名：我们只能从痕迹中拼凑出它们的存在的真相。我不会全然寄希望于任何一种说法，但不信任不代表它们没有价值。#portrait: haiming_2_know
海名：就好像，我喜欢辟谣文章的程度，也是和喜欢怪谈的程度不相上下的。#portrait: haiming_2_seeYou
我：这听起来非常……严肃。 #profile: painter_side
海名：很枯燥吧？对顾客我倒不会说这些，只会介绍些寓意和故事，当然，其实在这里顾客说的话倒是更多一些。#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
海名：咦？难道是因为我成了你的“顾客”，所以才会一下子讲这么多话吗？#portrait: haiming_1_wink
海名：也许，画家也是个危险的职业呢。#portrait: haiming_1_squint
我：危险？#profile: painter_side
//【bonus捕捉：危险的职业. 待定，没想好怎么做】
海名：这样吧，告诉你一个秘密。#profile: hide #portrait: haiming_1_smile #bgm: fade_1_0.5
我：秘密？#profile: painter_side
海名：不过，我得要你的一个秘密来交换。#portrait: haiming_1_squint #profile: hide #bgm: fade_0.1_0.1
+[好呀！]->sure
+[……]->danger

==sure==
我：没问题，你说吧。#profile: painter_side #bgm: fade_0.2_1
->trace_scholar

==danger==
我：………… #profile: painter_alert #drawingSystem: addBinaryVal_10
海名：……也不用这么如临大敌。差点忘记了，你也是个心思重的家伙，比起“秘密”，或许更应该叫做“有趣的事实”？#profile: hide #bgm: fade_2_1
我：好吧，那你先说。#profile: painter_eyeClosed #portrait: haiming_1_smile
->trace_scholar

==trace_scholar==
海名：除去纹身的工作，我也是一名痕迹学家。#portrait: haiming_3_pushGlass #portrait: haiming_3_norm #profile: hide
我：痕迹学家……？是类似刑侦工作那样的吗？#profile: painter_side
海名：呵呵，倒也没有那么实用。也许，我们只是一群执着于“痕迹”的疯子罢了。#portrait: haiming_3_squint #profile: hide
我：有意思，我还是第一次听说。#profile: painter_side
我：（吓死我了，还以为她真是什么秘密侦探呢。）#profile: painter_sideSweat #portrait: haiming_3_norm
我：（画家、数学家、痕迹学家……呵呵，看来给自己的找个名号来依托是人之常情。）#profile: painter_side
海名：痕迹学，就是研究物品因置换而消失后所留下的痕迹的学说。#portrait: haiming_2_idle #portrait: haiming_2_think
海名：万物消失之后必将留下痕迹，只是痕迹常常被人遗忘。而追寻痕迹，却是人重新获得存在的自主性的方式。#portrait: haiming_2_seeYouKnow 
我：（她的<color=green>神色</color>一下子变得好认真。）#showObservee: traceScholar
//【捕捉：痕迹学家
//左边：认真的海名haiming_2_seeYouKnow这个表情
//右边：“痕迹学家”——眼镜反光的睿智学者海名，和一堆书卷
//描述：海名现在的样子，像是个真正埋首学术的学者！只要研究“痕迹”这种课题，就能找回消失的历史吗？】
海名：除了研究作为痕迹载体的物品——比如说，你的丈夫消失之后留在浴室的刮胡刀——，我们也研究留下痕迹的行为，研究遗忘的机制。
海名：学界也是在一年前克莱拉·崔西那篇《论痕迹研究在逆转置换事故中的应用》之后才正式承认痕迹学的存在的，在那之前，所有人都当我们是妄想症和闭门造车的偏执狂。#portrait: haiming_2_frown #profile: hide 
海名：但为了写出这篇数据详实的论文，崔西几乎掏空了自己的一切，又通过痕迹把一切都寻了回来……真的是个奇迹。#portrait: haiming_2_think
海名：现在的待遇好多了。其实，我离开的这几天是去参加学术峰会了，还是头一次，痕迹学家能聚在一起。#portrait: haiming_2_know
海名：会场是Carpe Diem资助的。#portrait: haiming_2_thinkSquint
海名：也许是在我们身上发现了某种商业价值吧，他们愿意分享部分数据作研究。我实在没办法信任那个公司，但至少现状是有利于我们的。
我：……………… #profile: painter_side  #portrait: haiming_2_seeYou
我：（还好我没说出口。太尴尬了。）
我：（人家不是自封的……………………）#profile: painter_sideSweat #portrait: haiming_2_seeYouSquint
我：原来如此，这也算是纹身实践之余的一种学术上的实践了。……你是个跨学科人才。#profile: painter_norm #portrait: haiming_2_seeYouKnow
我：这样想的话，纹身其实也是一种痕迹？#profile: painter_stunned #portrait: haiming_3_pushGlass #portrait: haiming_3_norm
我：就像是人生节点的印记之类的。#profile: painter_norm
海名：自然是这样。甚至，就算是随意的图案、随意的一天，也会因为自己选择去受一小顿皮肉之苦而有了含义。#profile: hide #portrait: haiming_3_squint
海名：只是，自置换之后，覆盖纹身的工作就变多了。#portrait: haiming_3_cold #bgm: 悬疑_3 #showObservee: coverTattoo
//【捕捉：覆盖纹身
//左边：“覆盖文身四个字”
//右边：戴着手套口罩，拿着覆盖纹身器械的没有感情的杀（wenshen）手（shi）海名，和一些空气中消失的纹身
//描述：没想到，一名纹身师接过最多的任务是消灭过往的痕迹。覆盖纹身……就好像把历史给丢掉了。】
我：因为人们会忘记。#profile: painter_stunned
海名：我覆盖过最多的图案，其实是文字。 #profile: hide 
海名：有一些是名字。#portrait: haiming_3_pushGlass
我：总觉得有点恐怖。#profile: painter_side
我：曾经珍重到愿意刻在身上的东西，突然有一天就不再拥有含义了。
海名：只有留在真皮层的痕迹会不断地提醒你，过去曾经存在过。#profile: hide #portrait: haiming_2_idle #portrait: haiming_2_thinkSquint
海名：这大概是一种很令人不安的感受吧。#portrait: haiming_2_frown
我：我明白了。事实上……我非常能理解这种不安。#profile: painter_side #bgm: fade_1_0.3
海名：哦？#profile: hide #portrait: haiming_2_seeYou 
//S note：玩的时候感觉之前的有点不自然，改了一下
我：这是我的秘密，和你交换。#profile: painter_side #bgm: 日常_1 #portrait: haiming_2_seeYouSquint
海名：洗耳恭听。#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_squint
我：这就是我的痕迹。#profile: painter_norm #event: showScale
海名：鱼鳞？#profile: hide #portrait: haiming_2_idle #portrait: haiming_2_think
 ：海名小心翼翼地接过鳞片。#portrait: haiming_2_thinkSquint #event: giveScale
我：你明信片里问过怎么联系不上我，其实，就在昨天，我大概是遭遇了一起置换事故。#profile: painter_depressed 
我：我的东西全没了，只剩下这枚鱼鳞。不要问我它是什么。#profile: painter_eyeClosed
海名：我明白了。#profile: hide #portrait: haiming_2_know
我：是吗？我都不明白。#profile: painter_eyeClosed
海名：没想到画家也有一天，会露出和我的客人这么相似的神情。我理解你。#profile: hide #portrait: haiming_2_seeYou
海名：不过，画家今天在我面前拿出这枚“痕迹”，是为了什么呢？#portrait: haiming_2_seeYouKnow
我：为了……什么？
海名：作为纹身师，我的工作是覆盖痕迹。作为痕迹学家，我只会刨根问底。画家，你希望我怎么帮助你呢？#bgm: fade_0.2_1 #portrait: haiming_2_seeYouSquint #choiceType: OBSERVEE
+[痕迹学家（+追忆）]->findOut
+[纹身师（+遗忘）]->cover

==findOut==
我：我当然想知道鳞片的来历。#profile: painter_side #choiceType: BUTTON #drawingSystem: addBinaryVal_20
海名：就知道你会这么说。#profile: hide #portrait: haiming_2_seeYouKnow
海名：这枚鳞片，就是痕迹的载体。#portrait: haiming_2_know
我：海洋生物爱好者，能看出它是什么吗？#profile: painter_side
海名：她不像是我见过的任何一种生物，绝不是常见的鱼类。但是……总觉得非常熟悉。#portrait: haiming_2_thinkSquint #profile: hide
海名：说不定，我见过它的主人呢。#portrait: haiming_2_know
我：哎？！#profile: painter_stunned #portrait: haiming_2_seeYou
海名：别激动，这只是一种令人有点讨厌的熟悉感。也许，和你的感受别无二致。#profile: hide #portrait: haiming_2_frown
我：你是说…… #profile: painter_surprised
海名：我想，鳞片的主人可能已经消失了。#bgm: 柴柴_3 #profile: hide #portrait: haiming_2_think
海名：无论它是什么鱼，应该是被置换走了。#portrait: haiming_2_seeYou
我：……美人鱼。#profile: painter_depressed
海名：咦？#profile: hide #portrait: haiming_2_seeYouSquint
我：她是一条美人鱼。#profile: painter_depressed
->mermaid

==cover==
我：如果能彻底忘记就好了。#profile: painter_side #choiceType: BUTTON #drawingSystem: addBinaryVal_-20
我：就当是删档从来！重生之我是大画家！……之类的。
海名：这枚鳞片让你很困扰。#profile: hide #portrait: haiming_2_seeYou 
海名：有没有想过置换走它？#portrait: haiming_2_seeYouSquint
我：…… #profile: painter_side
我：………………不。#portrait: haiming_2_seeYou
海名：为什么？#profile: hide 
我：因为它对我很重要。#profile: painter_side
海名：如果它就此消失的话，重不重要也就无所谓了。#portrait: haiming_2_seeYouSquint
海名：而且因为它很重要，你说不定可以拿到，你说的——“重生之我是暴发户！”——的剧本呢。#portrait: haiming_2_know
我：………… #profile: painter_side
海名：你听了我先前的话，可能会觉得这样做有些可惜。但毕竟，我也只是置身事外，查查资料听听故事罢了。世界这么乱，想轻松一点生活，算不上过错。#portrait: haiming_2_seeYou #profile: hide
我：我猜，也许我并不是真的想彻底忘记。#bgm: 柴柴_3 #profile: painter_depressed
我：就连我的梦里，也总混入美人鱼的身影……#profile: painter_eyeClosed
我：像发了一场高烧。是我记错了吗？仿佛大海在她眼中燃烧，她的鱼尾轻轻扫过我的指尖，像奇迹、像召唤、像引诱。可须臾间她模糊在海浪里，连我的目光都耗尽……
海名：停停停，打住！美人鱼？#profile: hide #portrait: haiming_2_seeYouSquint
我：嗯，我认为，这枚鳞片属于一条美人鱼。#profile: painter_norm
海名：你说这个我可就精神了！#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
海名：千万不要换掉，就算要，也等讲完美人鱼的故事再换吧！#portrait: haiming_1_laugh
->mermaid

==mermaid==
我：我想、我猜……我不知道，但就在我摸着鳞片……不、喝了鳞片水之后……不要问我为什么，总之，就画出了一条美人鱼。#profile: painter_side 
我：好吧，根本就是毫无根据。#profile: painter_sideSweat
海名：可以给我看看画吗？嗯，鳞片还给你。#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile #event: showEmptyHand 
我：没问题，我正好夹在画箱里。#profile: painter_side #portrait: haiming_1_squint #event: getScaleBack  
我：喏。 #event: showDrawing 
海名：很美丽呢。虽说，你的作画条件有点……出乎意料。#portrait: haiming_2_idle #portrait: haiming_2_know #event: giveDrawing
我：别挤兑我了。这能让你想到什么吗？#profile: painter_side
海名：人鱼本身，大概也是最流行的传说生物之一了。#profile: hide #portrait: haiming_2_think
海名：鲛人、人鱼，当然也有人认为，它们只是头顶海草的儒艮。甚至于，对于他们的传闻多到不需要去刻意收集，连文艺作品都偏爱它们。#portrait: haiming_2_thinkSquint
海名：说起来，镇上还有卖人鱼潜水服的。#portrait: haiming_2_think
海名：自古以来，无论人鱼是否存在，它们就算在传说故事里，也是被消费的存在，身体被用来炼油点灯，却被冠上“美”的前缀，总觉得有些可怜。#portrait: haiming_2_frown #showObservee: merch
//【捕捉：消费人鱼或者炼油点灯——残忍廉价的消费品
//左边：文字框“炼油点灯”
//右边：残忍廉价的消费品，罐装的紫色鱼油
//描述：炼油点灯……人鱼这样的传说生物，也从生命变成了可以消耗的商品，细想来，这是多么残忍恐怖。】
海名：很遗憾，我对这条紫色头发的人鱼没有印象。也许在这一点上，我作为一个肤浅的现代人，在见过所谓“美人鱼表演”之后，就没办法跳出这些维度去想象了。#portrait: haiming_2_seeYou
海名：和很多其他神秘生物不同，如果美人鱼存在的话，我希望她们永远不要被人类找到。#portrait: haiming_2_think
我：……你的意思是，我应该放弃寻找她吗？#portrait: haiming_2_seeYou #profile: painter_side
海名：哎？我倒没有这个意思。不过，她对你来说，只是“美人鱼”吗？#profile: hide 
我：我倒希望我能知道更多。#profile: painter_side
海名：好像没能帮到你，画先还给你吧。#profile: hide #portrait: haiming_2_think #event: showEmptyHand
海名：说起来，这也是海底怪兽呀！画很美，我都想开个价了。#portrait: haiming_2_seeYouKnow #event: getDrawingBack 
我：谢谢你，不过我一想到她会被纹在别人的身上……嘶。 #profile: painter_side #portrait: haiming_2_seeYouSquint
我：或是被做成批量生产的贴纸？真是个可怕的念头。
 ：“她是我的！” #profile: painter_dark #portrait: haiming_2_seeYou
海名：咦？嗯，那看来，确实不止美人鱼这么简单了。#profile: hide #portrait: haiming_2_seeYouKnow
海名：画家很有占有欲嘛。#portrait: haiming_1_idle #portrait: haiming_1_smile #showObservee: lover
//【捕捉：占有欲——情人
//左边：文字框“占有欲”
//右边：我的温柔女友人鱼小姐
//描述：占有欲？想想还真羞人，也许在潜意识里，她就是我的梦中情人吧。】
我：哎？#profile: painter_side
我：不是，什么啊…… #bgm: 日常_3 #profile: painter_sideSweat #portrait: haiming_1_squint
海名：放松。我可没有在取笑你，这是线索，也是痕迹。#portrait: haiming_1_smile #profile: hide
海名：消失的影响本来就是两方面的，一面是本体在物理意义上不复存在，另一面是人的遗忘。#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
海名：遗忘远没有物理上的消失那么干净。它既有群体性，意味着所有人会在同时间失去对某样物体的记忆，但同时，人失去的记忆却是非常个人的。#portrait: haiming_3_cold
海名：消失的只能是可见的事物，失去一条鱼，并不会让人忘记鱼的概念，而只会忘记你和具体那条鱼之间发生的所有故事。#portrait: haiming_3_norm
我：如果全世界的鱼都消失呢？#profile: painter_side 
海名：你问住我了。我也在想，这样的灭绝，是不是已经在世界上发生了呢？#profile: hide #portrait: haiming_2_idle #portrait: haiming_2_frown
海名：也许，过去的世界远比你看到的一切更加丰富立体。#portrait: haiming_2_know
海名：说不定人鱼一直存在，只是某一天就灭绝了，于是画家背负了找回“最后一条人鱼”的使命？#portrait: haiming_2_seeYouSquint
我：……总觉得无论真相是什么，都不应该是这个。#profile: painter_noComment
海名：不逗你了。回到“那条鱼”的事情，就说你从鱼贩手里买了这条鱼，你所遗忘的故事，和鱼贩遗忘的是不同的。#portrait: haiming_3_idle #portrait: haiming_3_norm #profile: hide 
海名：为了继续生活，人们会自圆其说。#portrait: haiming_3_pushGlass
海名：你们会对各种各样的痕迹做出解释——也许你和鱼贩首先会不约而同地忘记彼此，然后你会认为自己砍价失败所以没有买鱼，但鱼贩留意到进账的记录，认为你买了别的鱼。
海名：如果买了另一条鱼的顾客在此时恰巧消失了，也许这个解释会更加完美？#portrait: haiming_3_squint 
我：不要一脸笑容地讲这么地狱的事情啊！#profile: painter_eyeClosed
海名：其实，每个人自圆其说的程度也有不同。画家如此受消失困扰，也许是因为，你就是那种下意识抗拒自圆其说的类型。#profile: hide #portrait: haiming_3_norm
海名：我尊敬你们。#portrait: haiming_3_norm #bgm: fade_0.1_0.1 
海名：但无论如何自圆其说，人对消失之物的感情却不会那么快不见。#bgm: fade_0.1_1 #portrait: haiming_3_eyeClosed
海名：人们难以追溯具体谁经历了挚爱的消失，但从数据的角度，自置换以来，精神疾病的负担是与日俱增，人们经常感到无来由的哀伤，很可能是置换带来的缺失感造成的。#portrait: haiming_3_cold
海名：总之，你所感受到的情感、下意识的态度，是可以用来推定“占位角色”的重要痕迹。#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
我：占位角色？#profile: painter_side 
海名：人的脑袋是很自我的，归根结底，事物和自己的联系才是记忆的关键。#profile: hide
海名：假如你曾经拥有孩子，有一天孩子消失了，你无法回忆起孩子的样貌和性格，但是你依然保持着忧虑的习惯，依然有照护的责任。
海名：有人会选择移情，把爱寄托到别的事物上，也许会开始养宠物。
海名：这是因为，你的行为模式中，依然留有一个“孩子”的占位角色，如果不填补上，就会感到惶恐。
海名：这种惶恐倒不一定是因为爱或者执念，反倒可能是因为现实与自己习惯中的生活之间的割裂，而对自我产生的焦虑。#showObservee: nightmare
//【捕捉：对自我的焦虑——梦魇
//左边：文字框“对自我产生的焦虑”
//右边：梦魇柴柴，一种恐怖的女鬼
//描述：我对那人鱼的思念，或许也来自于一种焦虑？比起浪漫和爱，她或许只是一个影响我的梦魇。】
海名：所以，觉得这片鱼鳞很宝贵，你不希望美人鱼成为别人身上的图案…… #portrait: haiming_1_idle #portrait: haiming_1_smile
我：是因为我心目中留有一个属于美人鱼的“占位角色”，并且如你所说，对她有很强的占有欲？#profile: painter_side 
海名：按我的歪理邪说，就是这样。#portrait: haiming_1_squint
海名：上述内容是我投稿的第一篇痕迹学研究的摘要，但由于对“情感”“态度”这些概念的使用太不专业，当年就被驳回了。#portrait: haiming_1_dazed
我：至少我听起来很唬人。#portrait: haiming_1_squint
海名：那就说明这不太靠谱，大部分学术研究听起来都相当枯燥。#portrait: haiming_1_smile
海名：但就当是随便聊天吧。在你的心中，“美人鱼”属于什么样的占位角色呢？#portrait: haiming_1_wink #choiceType: OBSERVEE
+[东西or消费品（不加不减）]->object
+[情人（+追忆）]->lover
+[梦魇（+遗忘）]->nightmare

==object==
我：听你这么说完，我都有点怀疑美人鱼到底是不是人了。#profile: painter_eyeClosed #choiceType: BUTTON #drawingSystem: addBinaryVal_5
我：瞧我这话说的，我想我一直默认把她当成某个重要的人来看待。#profile: painter_norm
我：但说到底，我对于那些传说，也没有什么真实感。#profile: painter_eyeClosed
我：也许它只是一样东西。#profile: painter_norm
我：也许我只是曾经拥有它，然后在置换后把它弄丢了。#profile: painter_depressed
我：没什么特别重要的，但就好像我也想回到置换事故之前的状态，让我的家里变回原样吧。
海名：画家是很守旧的人呢。#profile: hide #portrait: haiming_1_sad
我：是吗？#profile: painter_depressed
海名：不过，把你的所有物变回原样——这样的追溯，对于痕迹学家来说，可是非常激动人心的实验项目。#profile: hide #portrait: haiming_1_smile
我：听起来是个大工程，真的有办法做到吗？#profile: painter_side
->canI

==lover==
我：有点不好意思说出口……#profile: painter_sideSweat #choiceType: BUTTON #drawingSystem: addBinaryVal_30
海名：前女友？#profile: hide #portrait: haiming_1_wink
我：……#profile: painter_side #portrait: haiming_1_squint
我：听起来是不是有点像猥琐大叔酒后胡言？变成了穷光蛋，还哭着意淫自己的前妻什么的。#profile: painter_sideSweat
海名：你不说出来，才没有人会这么想。#profile: hide #portrait: haiming_1_squintLaugh
我：所以你现在这么想了吗？#profile: painter_side #portrait: haiming_1_smile
海名：*叹气*不，画家。我倒希望你干脆变成猥琐大叔算了。#portrait: haiming_1_eyeClosed #profile: hide
我：……………………#profile: painter_side
我：（海名的话有点绕，但我好像明白了。）#profile: painter_eyeClosed
我：（如果这一切不是我的空幻想，那么我曾经亲密的情人，真的已经归于虚空了吗？）#profile: painter_depressed
我：（我或许应该感到痛苦，但我现在唯一的感受，就只有困惑。）#profile: painter_eyeClosed
我：你说，我还有办法找回她吗？#profile: painter_side
->canI

==nightmare==
我：说实话，我有点害怕她。#profile: painter_eyeClosed #choiceType: BUTTON #drawingSystem: addBinaryVal_-30
我：怎么说呢，其实家里就剩个床垫，大夏天的也一样能过。画材没了，捡点东西做创作也是一种乐趣，但只有美人鱼……#profile: painter_norm
我：只要想到，就有种喘不过气的感觉。#profile: painter_alert
我：好像无论做什么，只要不解决掉关于她的谜团，就没办法继续生活。#profile: painter_eyeClosed
我：我很讨厌这种感觉……不过，别叫我置换走鳞片啊！我不会那样做的。#profile: painter_eyeClosed
海名：我明白的。#profile: hide #portrait: haiming_1_smile
海名：画家想要解脱，却也觉得，在自己解脱之前，得做点什么让那条人鱼也解脱才对。#portrait: haiming_1_sad
我：你这样讲，显得美人鱼像某种哀怨的地缚灵一样。#profile: painter_sideSweat #portrait: haiming_1_smile
海名：谁说虚空不可能是冥界呢？#profile: hide #portrait: haiming_1_squint
我：姐，你的神秘生物“研究”涉猎是不是有点太杂了？#portrait: haiming_1_eyeClosed
海名：呵呵。#portrait: haiming_1_squint #profile: hide
我：说真的，“让她解脱”什么的，我能做到吗？#profile: painter_side
->canI

==canI==
海名：这句话我不会对其他人说，但是我相信你，因为你是画家。#portrait: haiming_1_smile #profile: hide
我：画家有什么用？#portrait: haiming_1_squint #profile: painter_side
海名：画家的眼睛是用来扫描生活的，同时，又能想象出那些不存在的东西。#profile: hide #portrait: haiming_1_smile
海名：我热衷的那些传说生物，有多少是画家描摹出的呢？#portrait: haiming_1_wink
我：你说得我都不好意思了……再说，你也画画，就这么自夸吗？#profile: painter_side
海名：哪有，我知道自己没太多想象力的，只喜欢照着描述去制图。#profile: hide #portrait: haiming_1_eyeClosed
我：你就别捧我了，现在我这画还描得乱七八糟的呢。#profile: painter_side #portrait: haiming_1_squint
海名：我看看……嗯，这里是……#portrait: haiming_1_smile #profile: hide
我：呃这个是尾巴，不过我还没画完……呃，要不等我画完再看吧。#profile: painter_sideSweat
海名：呵呵，那我就不打扰你了。#portrait: haiming_1_squint #profile: hide
海名：对了，后面这一柜子书，你都可以翻翻找灵感，任何时候都欢迎。#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
海名：除了这几个格子是学术书籍，其他都是和神秘生物有关的，有画册，海洋的在这里……你随意看，我去添点茶水。#portrait: haiming_3_squint
 ：海名站起身。#event: haimingLeave
我：（海名的藏书真不少。应该翻翻哪本呢？）#profile: painter_norm #choiceType: BUTTON
+[神秘生物图册]->monster_book
+[痕迹学论文]->trace_essay
+[？？？]->personal_stuff

==monster_book==
我：（还是看看神秘生物图册吧，也许可以当作参考。）#profile: painter_eyeClosed #drawingSystem: addBinaryVal_-10
我：（看看目录……好有趣，应该先看哪个呢？）#profile: painter_happy
+[轮回胎魔]->8_2_monster
+[饕餮水怪]->chai_monster
+[假面灵鬼]->xstar_monster
//+[疾行旱兽]->chiru_monster

==8_2_monster==
 ：貌似山羊，有两只角，背生双翅。七兄弟中的二哥，和同胞们紧密地联系在一起。#profile: hide
 ：在每一个周一失踪。不断地消失，不断地重新出现。
 ：与兄弟出生于高热之中，在出生之前蒸发了母亲的身体，胚胎还未破。
 ：于第一天被六个弟弟分食，第二天被重新孕育而复生；第二天二弟被分食，在第三天复生；第三天三弟被分食，第四天复生……
 ：七天之后，所有的兄弟都经历了死亡与重生，才从胚胎中诞生。自此，七兄弟每周都会有一天消失在这个世界上。
我：（好玄幻的故事……嗯？怎么总觉得有点耳熟？））#profile: painter_sideSweat
->haiming_back

==chai_monster==
 ：深海水底的怪兽，有无限的食欲，但没有配套的消化功能。吃多了会呕吐，吐出的东西变成无意义的垃圾。#profile: hide
 ：早晚有一天大海和陆地都会被她吃下去。
 ：被讨伐，用铁链把膨胀的身体锁在海底，直到她变化出了绝美的形态诱惑看守，随后把看守吃了下去。
 ：上岸，每个白天去陆地游弋，以人类的身体诱惑人下水，但每个傍晚都必须回到深海里去。
我：（为什么会有这样的生物……总觉得，什么都不在乎的话，这一辈子也太可怜了。））#profile: painter_depressed #drawingSystem: addBinaryVal_25
->haiming_back

==xstar_monster==
 ：有很多种面孔，从不以真面目示人。）#profile: hide
 ：草食，具有不同寻常的斗争欲，有“捕猎”能力——他不会杀死或吃掉猎物，只会与其玩耍，拆掉他们的一部分作为战利品，装到自己身上去。
 ：总是快乐的。瑞兽，象征活跃的文化与希望，化形为祥瑞之兆。
 ：曾有一男子梦想见识牠的真面目，于是成为其侍从，告诉亲朋：我要在夜晚摘下他的假面！
 ：第二天，侍从出现。友人问侍从：牠长成什么样子？侍从说，就是这般模样。
 ：第三天，友人妻子从房中惊慌逃窜，逢人便问她丈夫在哪，众人皆疑惑：你身边的不就是吗？
 我：（所以侍从和友人怎么了？……你确定这是瑞兽？））#profile: painter_sideSweat
->haiming_back

==chiru_monster==
 ：有翅膀，可以飞翔无限遥远的地方；有双腿，可以丈量每一寸土地。）#profile: hide
 ：曾赠予最强大的国家地图，牠去过的地方成为世界的边界，没有牠攀登不了的山峰，没有牠飞跃不了的海洋。
 ：不会水。
 ：“牠的地图里只有陆地。”
 ：“但只有前往海洋深处，才能见识这个世界的全貌。”
 我：（牠是明智的，不然还得和饕餮水怪打一架。））#profile: painter_eyeClosed
->haiming_back

==trace_essay==
我：其实，我对海名口中的痕迹学也挺感兴趣的。来挑战一下吧！）#profile: painter_norm #drawingSystem: addBinaryVal_10
 ：……痕迹研究的困难一直被认为来源于样本的不可控性。#profile: hide 
 ：“痕迹”本身是对记忆的实体化研究的锚点，其具有公信力的认证规范却只能追溯到《个人所有物置换认证规范》的一节（后称：DP-3x3）。
 ：根据DP-3x3标准，痕迹的有效性认证需要三个时刻、三个人以上集体记忆的佐证。
 ：在后置换时代，记忆的消失已然被归于不可抗力。记忆的样本缺乏实验需要最基本的稳定性，符合标准的认证非常难以获得。
 ：甚至于，由于DP-3x3广泛用于对民众财产纠纷的判定，其数据具有伪造嫌疑。
 ：实体化记忆需要痕迹为锚点，痕迹的认证却需要几乎不可能获得的DP-3x3记录。这种现象，正是痕迹学研究递归性困难的体现。
 ：我们需要制定一种全新的标准，一种更灵活、更大胆、更有想象力的规范；这种规范必须跳出量化研究的老旧科学基础。
 ：我们需要更多的故事、绘图、艺术、声音；我们需要以一种全新的维度来理解痕迹和记忆。……
我：（……我好像没有自己认为的那么感兴趣。）#profile: painter_sideSweat
 ->haiming_back

==personal_stuff==
我：（……嗯？这是什么？）#profile: painter_surprised
我：（好漂亮的封面图案，是绘本吧……）#profile: painter_eyeClosed
 ：（娟秀的字迹）第一天上班，组里的人都好友善^_^ #profile: hide
 ：公司好大，居然还有置换造景跑道，感觉自己已经是后福特主义的奴隶了…
 +[翻过几页]->note1
 
 ==note1==
 ：（娟秀的字迹）前辈为了业绩竟然会去跟踪客户，也太拼了吧，而且还在伪造一些巧合……
 ：这样做的话，心里估价和pua还有什么区别？……
 +[翻过几页]->note2
 
 ==note2==
 ：（大了几号的字迹）真是疯了，这种魔鬼想出来的产品还大肆广告，这简直是在杀人……
 +[翻过几页]->note3
 
 ==note3==
 ：（潦草的字迹）想回奂门了，再呼吸一秒这个中央空调的空气都想吐。所有人都道貌岸然。
 ：……他们在风口加的什么香精？……
 +[翻过几页]->note4
 
 ==note4==
 ：（潦草的字迹）要不开个纹身店吧。每天可以用针扎人，没有比这更令人开心的工作了。……
 +[翻过几页]->note5
 
 ==note5==
 ：（潇洒的字迹）跑路了。店名就叫“神秘生物研究所”吧。……
+[翻过几页]->note6
 
 ==note6==
 ：（潇洒的字迹）新客人们话也不少，总觉得能察觉到好多故事。前司真是给我留下了好多恶心的习惯，看到有趣的纹身就忍不住打探别人的秘密。……
 ：（潇洒的字迹）……就打探了！哦耶。……
 +[翻过几页]->note7
 
 ==note7==
 ：（潇洒的字迹）饱暖思淫欲，好无聊，奂门也太……
->haiming_back_personal

==haiming_back_personal==
海名：咦，画家…… #profile: hide
我：（糟糕！她回来了。）#profile: painter_side
我：（别让她发现我在翻她的日记本。哎，刚才从哪一格拿的来着……）#profile: painter_sideSweat
海名：画、家。#bgm: 戏谑_2 #profile: hide
我：（……来不及了。）#event: haimingAppear #profile: painter_sideSweat 
海名：你好像在做一件很危险的事情呀。#portrait: haiming_1_idle #portrait: haiming_1_squint
我：对不起！我没想到那个是你的，我就是看封皮很漂亮……好吧我承认，我发现后确实多翻了几页……对不起！#profile: painter_sideSweat
海名：算了，你看吧。或许这就是知道太多秘密的报应？#profile: hide #portrait: haiming_3_idle #portrait: haiming_3_norm
海名：也许被人知道自己的过去也不是一件坏事？我把笔记本和其他书摆在一起，说不定也在等被翻开的一天。#portrait: haiming_3_pushGlass
我：我不会说出去的。#profile: painter_side
海名：我相信你，画家。你应该是不敢的。#profile: hide #portrait: haiming_3_squint
海名：翻篇了。对了，这件外套是你的吗？#bgm: 日常_2 #portrait: haiming_3_norm
->lost_item

==haiming_back==
海名：咦，画家…… #profile: hide
我：（海名好像在叫我。这些藏书虽说有点奇怪，但还是蛮有趣的，之后也有机会再看。）#profile: painter_side
我：怎么了？
海名：这件外套是你的吗？#profile: hide #event: haimingAppear #portrait: haiming_3_idle #portrait: haiming_3_norm
->lost_item


==lost_item==
我：哎？……还真是！上次落在你这的？#profile: painter_surprised
海名：看来是这样了。不是第一次有客人在这里落东西了，我离开两周，回来都忘记了。#profile: hide #portrait: haiming_3_eyeClosed
我：哈哈，这对于现在的我来说，还真是个好消息。#portrait: haiming_3_norm #profile: painter_side
我：（这可是我为数不多的财物了。）#profile: painter_sideSweat
海名：惨的呀，画家。#profile: hide 
我：*接过衣服*空调衣，真是奢侈的发明……不过你这里还真有点冷，先穿上吧。#profile: painter_eyeClosed
我：嗯……嗯？哎？
我：兜里什么东西……
我：咦？#profile: painter_stunned #event: showLighter
海名：哇哦，好有格调的打火机。可惜没摸出一包烟，不然就真是惊喜了。#portrait: haiming_3_pushGlass
我：……#profile: painter_stunned
我：我不抽烟。#bgm: fade_0.2_0 
海名：这样吗？呵呵，我之前也没留意……#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_squint
海名：………………哎？#portrait: haiming_1_smile
我：…………………… #profile: painter_stunned
海名：…………………… #profile: hide #portrait: haiming_1_squint
海名：………为什么你兜里会有打火机？#portrait: haiming_1_dazed
我：对呀，为什么呢？#bgm: 紧张 #bgm: fade_5_0.2   #profile: painter_stunned
海名：…… #portrait: haiming_2_idle #portrait: haiming_2_think #profile: hide
海名：给我看看。#portrait: haiming_2_seeYou 
海名：是美人鱼的造型呢。#portrait: haiming_2_know #event: giveLighter
海名：画家，原来你是会为了点生日蜡烛或者烟花之类的，而买这么漂亮的打火机的家伙吗？#portrait: haiming_2_seeYouKnow
我：你看我像那种人吗？#profile: painter_side
海名：火机是你的吗？#bgm: fade_5_0.6 #portrait: haiming_2_seeYou #profile: hide
我：我有点晕…… #profile: painter_side
海名：有个检验的办法。如果你能置换走它，但就说明你拥有它。#profile: hide #portrait: haiming_2_think
我：（置换走美人鱼打火机，以此来检验自己是否拥有它……）#profile: painter_side
+[好主意。]->good_idea
+[才不要！]->nope

==good_idea==
我：好主意。让我试试…… #profile: painter_side
我：……………… #portrait: haiming_2_seeYou #event: displaceEffect #drawingSystem: addBinaryVal_-10
我：我好像换不走它。
海名：你动作也太快了点吧？#profile: hide #portrait: haiming_2_seeYouKnow
海名：开玩笑的，真换走了，我们也没必要再调查任何事了。#portrait: haiming_2_seeYou
我：我想，无论换得走还是换不走，都是一种天意。#profile: painter_side
我：看来必须得追根溯源了。#profile: painter_alert
->my_past

==nope==
我：算了吧，等我换走了，咱们一起忘记这回事吗？#profile: painter_norm #drawingSystem: addBinaryVal_10
我：大痕迹学家，就别在这逗我了。#profile: painter_eyeClosed
海名：好，那我们摊开说吧。我想，这就是我们追溯往事的重要契机。#profile: hide #portrait: haiming_2_seeYou
->my_past

==my_past==
海名：又是美人鱼。我好像能理解一些你的执念了。#profile: hide #portrait: haiming_2_think
海名：关于这枚火机的来历，画家一点都想不起来吗？ #portrait: haiming_2_seeYou
我：完全不能……不过有点熟悉，可能是我准备给什么人的礼物吧，或者别人给我的。#profile: painter_eyeClosed
海名：自圆其说。#profile: hide #portrait: haiming_2_seeYouDoubt
我：哎？#profile: painter_stunned
海名：因为遗忘了火机的来历，你在自圆其说。 #profile: hide
我：（天，我好像真的在……海名的神情突然好严肃。）#profile: painter_side
海名：这枚火机，应该就是一种痕迹。#portrait: haiming_2_think
海名：无论你能不能换走它，对于不抽烟的画家来说，打火机都不是自己常用的物件。
海名：你确定这件衣服是你的？#portrait: haiming_2_seeYou
我：非常确定。#profile: painter_side
海名：火机这种东西，总感觉是很私密的。介意让我试一下吗？#profile: hide
我：请。#profile: painter_side #portrait: haiming_2_think
海名：咦？还挺高档的，摁头和尾巴出现得火焰颜色不同……蓝紫色的？好神奇，灌了两种油吧……#profile: hide #portrait: haiming_2_thinkSquint #event: lightUp
我：*脸色一白*…… #profile: painter_sideSweat #event: lightUp
海名：画家？怎么了？#profile: hide #portrait: haiming_2_seeYou 
我：呕……鲛人油灯…… #profile: painter_sideSweat
海名：那种东西不存在啦！……哎呀，说出来了。#portrait: haiming_2_seeYouDoubt #profile: hide 
我：你到底信不信啊？其实研究神秘生物只是看乐子吧？算了，这个也不是现在的重点…… #profile: painter_side #portrait: haiming_2_think #event: lightUp
海名：看起来是有使用过的痕迹，表面有点划痕，两管油都空了一半。大概，也不是画家准备送人的礼物，而就算是别人给你的，也被画家之外的人用过。#portrait: haiming_2_thinkSquint #profile: hide #event: lightUp
海名：是很亲密的人吧？会把打火机揣在你的兜里。#portrait: haiming_2_seeYou
我：早上，王大爷对我说过一句话：“你没和那个谁一起吗？”然后就说自己记错人了。#profile: painter_eyeClosed
我：我当时还觉得有点奇怪。
海名：*长叹一口气*…… #portrait: haiming_1_idle #portrait: haiming_1_sad #profile: hide #event: getLighterBack
海名：画家，我很抱歉。
海名：你身边的人消失了。因为置换。#bgm: 黄昏_4
我：…… #profile: painter_depressed
我：……………… #portrait: haiming_1_sad
我：…………………………
我：我能怎么办哪…… #profile: painter_eyeClosed
海名：痕迹学说到底也是一种研究理论问题的学术，没办法解决一切的。#profile: hide #portrait: haiming_3_idle #portrait: haiming_3_cold
我：你见过她吧？呵呵，外套可是落在你这里的。#profile: painter_eyeClosed
海名：…… #portrait: haiming_3_cold
海名：作为朋友，我其实觉得，画家可以试着放下她。记挂虚空里的人，太难啦。把过往覆盖掉，刷一层大白，再去生活吧。#portrait: haiming_3_pushGlass #portrait: haiming_3_norm
海名：不过，如果你想要去寻找她，我会竭尽所能地帮助你。#portrait: haiming_3_pushGlass
海名：痕迹学的终极幻想，就是循着人鱼回归大海的水迹，从虚空中捞回挚爱吧？#portrait: haiming_3_eyeClosed
海名：………… #portrait: haiming_3_norm
海名：看来你已经决定了。那么画家，答应我，不要放弃任何一点关于她的痕迹。#portrait: haiming_3_squint 
海名：她一定会回到你身边的。#portrait: haiming_3_norm #portrait: haiming_3_pushGlass
我：谢谢你。真的……谢谢你。#profile: painter_side
我：抱歉，我有点……这幅画，我今天可能没办法完成了。
海名：没关系，之后还有时间，要是想在我这里画也是可以的。#profile: hide #portrait: haiming_1_idle #portrait: haiming_1_smile
海名：画家呀…… #portrait: haiming_1_sad
海名：……
海名：刚才的画，给我看看吧？就算是没完成的草稿，也没有关系。#portrait: haiming_1_smile
我：………………嗯……好。#profile: painter_depressed
我：………………#profile: painter_eyeClosed
+[递出未完成的画作]
->END