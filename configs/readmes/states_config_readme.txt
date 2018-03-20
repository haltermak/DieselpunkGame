LEGEND = __________________________________________________________________________________________
        |*text* ------------ A key or meaningful text. Must be exactly like the text in asterisks  |
        |[text] ------------ A reference to something in another file. The comment should say      |
        |                     what exactly.                                                        |
        |% ----------------- A number with the given format                                        |
        |<text> ------------ This is the origin of something that will be referenced elsewhere,    |
        |                     so it doesn't need to reference something in another file.           |
        |                     Also used to denote data as opposed to references                    |
        |#text  ------------ A comment explaining something about the entry                        |
        |__________________________________________________________________________________________|


*state* = <state id {
    *name* = <name of state>
    *owner* = [name of owning country] #Must line up with an entry in countries_config.txt
    *capital_county* = [county id] #References counties_config.txt, and must be a county that is part of the state.
    *counties* = { 
        [county id]... #references counties_config.txt, can be any number of counties, but all counties must belong to exactly one state.
    }
    *autonomy_type* = [autonomy level] #Must reference an entry in autonomy_config.txt
    *region* = [region id] #References region_config.txt. Each state must belong to exactly one region.
}