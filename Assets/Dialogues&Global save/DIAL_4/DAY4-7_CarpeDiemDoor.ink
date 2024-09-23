INCLUDE ../global.ink
VAR r_count = 0 
 ：检测到来人的靠近，水晶旋转门悠悠启动。
{inCDBuilding:
    -false:
    ->rotating_in
    -true: 
    ->rotating_out
}
 
==rotating_in==
~r_count++
{r_count < 2:
 ：水晶门旋转了半圈。
    +[进入大厅]->indoor
    +[留在门里]->rotating_out
}
{r_count >= 2:
 ：水晶门{&又|再一次|接着}旋转了半圈。
    +[进入大厅]->indoor
    +[留在门里]->rotating_out
}

==rotating_out==
~r_count++
{r_count < 2:
 ：水晶门旋转了半圈。
    +[进入街道]->outdoor
    +[留在门里]->rotating_in
}
{r_count >= 2:
 ：水晶门{&又|再一次|接着}旋转了半圈。
    +[进入街道]->outdoor
    +[留在门里]->rotating_in
}
{r_count > 10:
->kick_out
}

==indoor==
~inCDBuilding = true
 ：大厅金碧辉煌。【进到玻璃隔板图层后面】
->END

==outdoor==
~inCDBuilding = false
 ：海风吹过街道。【回到街道】
->END

==kick_out==
~r_count=0
~inCDBuilding = false
保安：这位客人，请您不要玩旋转门。【回到街道】
->END

/**
// 这个是常规Carpe Diem入口文本的改良版，此外还有一个map general版本
我：（就是这里了，真是气派的建筑。）
+[走进旋转门]->enter_door
+[还是算了]->dont_enter

==dont_enter==
我：（总觉得还没做好准备，一会儿再进来吧。）
->END
*/
