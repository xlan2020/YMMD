INCLUDE ../global.ink
 ：~~ 【走过去的时候触发的美人鱼影子从海水里冒头，然后触发对话框】
我：咦？#bgm: pause
 ：~~—- -【影子在更远处闪现（一共就是一个美人鱼小人水里冒头的小动画），走两步，下一句。】【bgm变调】#bgm: play 
我：那个是…… 

 ：~~ ~--~ ~=~ ~~ 
 ：__--~~ -=~ ... _==
 ：~~~【影子再次消失，出现在更远处。】
我：再近一点……
->END
鹅鹅：影子消失，出现在海里某个地方静止了（但是头发在飘）。此时对话框不是自动的，而是要走过去点一下，点下去的瞬间动画播放：水里的鱼回头看了你一眼，笑了一下，然后扎在水里消失了。
我：（那是……那是……）
我：（那是什么？？？！！！）
我：（刚才的那是什么？美人鱼？我看到美人鱼了？）
我：（不对……有什么不对……美人鱼不是应该消失了吗……）
我：（刚才的结论，难道不是她已经被置换走了吗？）
我：（我要去看看，我要去，但是……）
鹅鹅：这一片海域被围起来了，给cosplay大赛作准备，有栅栏阻止你过去。
：我在浅滩里走来走去，直到整条裤子都浸湿，却没有再看到那个身影。
->done_finding

==done_finding==
我：（……不见了。）
我：（………………）
我：（也是啊，如果她还在这世界上，我怎么可能不记得和她的故事？）
我：（就算是美人鱼，就算真的是她……）
我：（夜晚也到了。）
：她该走了。
我：（哈哈……哈哈哈……）
我：（…………）
->DONE

// 此处切入流动大脑，大概剧情：
// 我脱力地坐在面对大海的长椅上，盯着美人鱼方才出没得的海面，刚才发生的事情就仿佛我的幻觉。但是，已经决定了追溯她，就像海名说的，我不会放弃关于她的痕迹。
// 我一定要找她回来。我可以做到！——我决定把这一切画下来，这是我能做的最好的事。
// 我从眼前的大海画起，在我的想象中，美人鱼从海里冒头，正准备回去，我就把她揪出来【拖拽】放在了沙滩上。
// 鱼尾在沙滩上扭动，这实在是太不方便了，所以我下意识切掉了鱼尾，给她换上了双腿。
// 人鱼蜷成一团，不自然地并拢双腿，蜷缩在我身边的长椅上。
// 她用手摸着多出来的脚，神经质地抠着，水滴下来，从她的眼眶里。
// 救救我。人鱼对我说，我不想在这里，不想在这里……这里太干了，这里什么都没有，这里的一切都很无聊。我很无聊。我讨厌这里。为什么我一定要待在这里。这个世界充满了垃圾。垃圾。我想要更好的………
// 我试图把垃圾给擦掉，把多余的东西擦掉。美人鱼又哭了起来，说这里什么都没有，没有我在乎的东西，也没有人在乎我。我把她的眼泪擦掉，眼泪再冒出来。我把她的眼泪擦掉。
// 她的眼泪是擦不干的，就像是卡住了一样。直到……我打开背包，把美人鱼打火机送给她。
// 【原：给她置换出了一样东西来【问题：这个步骤其实也是稳定了，是吃钱的，如果欠钱了没钱了怎么办】
// 她惊喜地抱着那个礼物。打火机吐出蓝色的火焰，蒸干了美人鱼眼角的泪珠，然后就像是泪腺也被烧掉了一样，眼泪再也不流了。
// 美人鱼看着我，问这是给我的吗？我说这个小美人鱼和你很像。
// 真棒，我喜欢。美人鱼说，你可以带我回家吗？
// 让我成为你的东西吧。

// 这里流动大脑就结束了，我惊讶地发现，天已经黑了。
// 我看着完成的画作，我陷入了沉思。画里面，美人鱼就在这个长椅上，以一个二次元媚宅角度【不是！！】看着我【诱惑我】，手中的打火机在眼角吐出蓝色的火苗。
// 你长这个样子吗？我看着画作：面孔娇憨，表情忧郁又厌倦，动作有些粗野。
// 好想再见到你一次啊。我用手抚摸着画作的脸。让我来置换吧，为了离你更近一点，照着这张画，来置换吧。
// 填写金额，置换。结果1：珍珠项链。结果2：鱼缸？油灯？
// 虽然肯定不是你，跟我想的差了很多，但我也接受了这个结果。我会好好留着这些东西的。
// 我收起了画作和东西，看着远处的大海，虽然没什么希望，总觉得可以再找一找。也许，我拿着这些东西，你就会回来呢？
// 我卷起裤腿，和刚才做得一样，再次踏入了海水之中。正在此时……

//Sherry Note: 这个文件我先不改了，你写完我再仔细看！


==oldversion==
我：…………（问我在找什么？呵呵，这问题听着都有几分讽刺。）
+[“她”]->her
+[呵呵，人生方向]->life
+[把相机放下行吗？]->camera

==her==
我：你有看到一个美……一个紫色头发的女人吗？
我：她刚才还在的，就在这一片海里。
年轻人：紫发？没见过。怎么，你和同伴走散了？
年轻人：你给她打个电话呢？
我：没事，只是个陌生人罢了。
我：（我既不知道那是不是我的“她”，也不知道“她”有能算我的什么。）
年轻人：哈？
->this_place

==life==
->this_place

==camera==
我：你能先把相机放下吗？
年轻人：哦，这个啊。习惯了。
->this_place

==this_place==
年轻人：我说，这个地方是真有点邪门儿。人人都神神叨叨的。
我：……你是说奂门吗？
年轻人：对啊。你也是来旅游的吧？
我：为什么这么想？
年轻人：看你背着
请我入镜视频吧还是
->END
