INCLUDE ../global.ink
//不是vip，是vip会有经理接管
//没写完
前台小李：欢迎光临纵享人生置换咨询事务所，Carpe Diem！
前台小李：请问您有什么需要呢？旁边也有<color=green>服务项目介绍单</color>，请随意翻看。
+[帮我介绍]->intro_for_me
+[购买服务]->buy_service
+[我自己看]->leave

==leave==
我：好的，我自己看看。
->END

==dont_want_to_buy==
我：呃，我想自己再看看。
前台小李：您请慢慢考虑，旁边有休息区，有问题随时叫我。
->END

==intro_for_me==
我：您能给介绍下吗？
前台小李：我的荣幸。本公司提供置换咨询服务，业务涵盖经济、心理、娱乐。
->three_program

==three_program==
前台小李：最受欢迎的项目有三种——置换心理精算估价咨询、置换事故遗忘康复咨询以及临终狂欢套餐。您想了解哪一种？
* [心理精算]->value_consult
* [遗忘康复]->memory_consult
* [临终狂欢]->sell_self_consult
+ ->secret_program

==secret_program==
前台小李：我们的基础项目就这几项。不过如果想要独属于您的私人咨询服务，可以购买我们的隐藏VVVIP会员套餐，全面托管人生。
前台小李：这意味着，从此，您的<color=green>一切人生决定，都由我们来进行负责</color>。目前的折扣价，只需要9999元。
+[我要购买！]->buy_secret_program
+[还是算了]->dont_want_to_buy

==buy_secret_program==
经理Matthew ：恭喜您，尊贵的VVVIP会员，可以选择自己的咨询师了。
+[尔橙三]
// 风格：追忆，换人
->DONE
+[刘先生]
// 风格：遗忘，赚钱
->DONE
+[Cindy女士]
// 风格：追忆，不换人
->DONE

==value_consult==
前台小李：置换心理精算咨询是我们最受欢迎的项目，可以帮您评估物品的心理价位，并且通过暗示的手法来进行调价。
前台小李：当然，这种暗示是绝对安全的，不会对您的记忆产生任何不良影响。
前台小李：想把自己的物品换成钱？没问题，我们尽量抬高物品在您心目中的价值。
前台小李：想要置换出新的物品？没问题，我们尽量帮你压低物品在你内心中的价值。
前台小李：忘了你要置换出什么？没问题，但是这超出了心理精算咨询的范围，我们推荐您加购置换事故创伤康复咨询套餐。
前台小李：这位客人，您有兴趣购买心理精算服务吗？
+ [我要购买]->buy_value_service
+ [讲讲别的]->three_program
+ [还是算了]->dont_want_to_buy

==memory_consult==
前台小李：如果你怀疑自己意外置换走了重要的东西，可以购买我们的服务，帮您确定遗忘的范围或者重新回想起过去的记忆。
前台小李：这可以为您尽量平缓置换事故所带来的创伤。
前台小李：当然，哪怕是我们的高级康复师，也不能保证你可以重新拥有失去的东西。
前台小李：这位客人，您有兴趣购买置换事故遗忘康复咨询服务吗？
+ [我要购买]->buy_memory_service
+ [讲讲别的]->three_program
+ [还是算了]->dont_want_to_buy

==sell_self_consult==
置换临终狂欢套餐：布拉布拉
+ [我要购买]->DONE
+ [讲讲别的]->three_program
+ [还是算了]->dont_want_to_buy

==buy_service==
我：我要购买服务。
前台小李：好的客人，我们这边可以提供单次初步体验服务和VIP会员服务，后者不限咨询次数。请问您感兴趣哪一种？
+[单次体验]->END
+[VIP套餐]->END
+[还是算了]->dont_want_to_buy




==buy_value_service==
前台小李：初步体验心理精算估价咨询服务，一次666元，您确定要购买吗？
+[购买单次]->value_program_start
+[购买VIP]->END
+[还是算了]->dont_want_to_buy

==value_program_start
心理精算服务开始。咨询师：尔橙三
->END

==buy_memory_service==
前台小李：初步体验置换事故遗忘康复咨询服务，一次666元，您确定要购买吗？当然，我们还有VIP套餐可供选择。
+[我要购买！]->memory_program_start
+[购买VIP]->END
+[还是算了]->dont_want_to_buy

==memory_program_start==
置换事故遗忘康复咨询服务开始。咨询师：Cindy女士
->END

