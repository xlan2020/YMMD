INCLUDE ../global.ink
{ tattooTalk: 
    - 0:
        ~ tattooTalk++
        ->first_talk

    - else: 
        ~ tattooTalk++
        ->default
}

==first_talk==
我：这里就是海名的纹身店了。#profile: painter_norm
我：我记得她好像有个很可怕的保镖，不会一进门就被绑在工作台画稿吧？#profile: painter_mournful
我：毕竟我鸽了她那么久。呃……要不要再做会儿心理准备呢？
+ [进入]
我：……呼。总之先尝试蒙混过关一下……#profile: painter_selfMock
->enter_tatoo_shop

+ [再等等]
我：反正我最不缺的就是时间了，先去别处逛一会儿吧。#profile: painter_selfMock
->DONE

==default==
：要不要再做会儿心理准备呢？#profile: hide
+ [进入]
我：……呼。总之先尝试蒙混过关一下……#profile: painter_selfMock
->enter_tatoo_shop

+ [再等等]
我：反正我最不缺的就是时间了，先去别处逛一会儿吧。#profile: painter_selfMock
->DONE

==enter_tatoo_shop==
：#loadScene: DAY2-5_TattooShop
-> DONE