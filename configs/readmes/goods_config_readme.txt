
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


*good_type* = <good_name> { 
    *initial_price* = %d
    *category* = [category of good] #Must reference a category of good in goods_categories_config.txt
}
