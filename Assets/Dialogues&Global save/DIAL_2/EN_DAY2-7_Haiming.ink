INCLUDE ../global.ink
{ haimingTalk: 
    - 0:
        ~ haimingTalk++
        ->first_talk
        
    - else: 
        ~ haimingTalk++
        ->default
}

==first_talk==
Seanamae：Already back? The draft's ready?#profile: haiming_seeYouKnow
Me：Ah, uh, no idea. Sorry. So sorry.#profile: painter_concerned
Seanamae：Enough teasing. #profile: haiming_smile
Seanamae：I'm going to keep investigating for the mermaid. I'll let you know once I get anything worth mentioning.#profile: haiming_think
Seanamae：Tea or coffee? Make yourself home.#profile: haiming_yinyang
->DONE

==default==
Seanamae：I'll let you know once I get anything worth mentioning about the mermaid.#profile: haiming_think
Seanamae：Tea or coffee? Make yourself home.#profile: haiming_yinyang
->DONE