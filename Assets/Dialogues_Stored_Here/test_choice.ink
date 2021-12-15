-> main

=== main ===
你瞅啥?#speaker: 刨冰#portrait: 刨冰
    +[瞅你咋地]
        ->chosen ("找打")
    +[啊，没瞅你]
        ->chosen ("不知道我是谁")
        
 === chosen(reply) ===
你是不是{reply}!#speaker: 刨冰#portrait: 刨冰
-> END