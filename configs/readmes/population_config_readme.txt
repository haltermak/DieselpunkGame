all pop types should be in the following format:

LEGEND = __________________________________________________________________________________________
        |*text* ------------ A key or meaningful text. Must be exactly like the text in asterisks  |
        |[text] ------------ A reference to something in another file. The comment should say      |
        |                     what exactly.                                                        |
        |#text  ------------ A comment explaining something about the entry                        |
        |__________________________________________________________________________________________|



*pop_type* = [name of pop type] {
    *produces*=[name of produced good] #This has to line up with a good from goods_config.txt
    *prod_rate* = [number of good produced per person] #Remember that good numbers are supposed to represent the amount that a single person needs or wants per day.
    *needs* = {
        [name of good needed] #This can be any number of goods. They all must match up with goods from goods_config.txt. Goods needed have a large impact on happiness if not met, but 
                              # only a small one if met
       }
    *wants* = {
        [name of good wanted] #Same as goods needed. Has a much larger positive impact if met, and a smaller negative impact if not met. However, also has a small impact if needs are not
                              #met, even if the wants are met completely.
       }
}