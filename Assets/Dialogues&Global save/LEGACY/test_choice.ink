/*
#INCLUDE global.ink
-> main

=== main ===
打算加几，加到三老王就能想起马冬梅住哪儿#speaker: 刨冰#portrait: 刨冰
    +[加个一]
        ->chosen ("那就加1",1)
    +[减一吧]
        ->chosen ("减一吧那就",-1)
    +[让茄子出现！]
        出现了！
#        ~ showEggplant = 1
        ->DONE
        
 === chosen(reply, value) ===
#~ failTimes = failTimes + value
#好，{reply}；现在是{failTimes}；#speaker: 刨冰#portrait: 刨冰
#{failTimes>3:
    <>他记起来了！
#- else:
    <>他不记得了！
}
-> END
*/