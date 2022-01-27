Because I started this techincal test so long after the interview (prior commitments and being ill for two day) I've decided not to fully do it, but I want to present a basic POC about _how_ I would of done it


So changing the specifications from an either success/failure to a scoring system, based on the number of non-space values in the specification
For example 6 specification
 _ 
|_ 
|_|
would have a value of 6 as it has 6 total pipes/underscores

For input
 _ 
|_ 
|_|
the score value for the specification would be 0, meaning a perfect match

For input
 _ 
|_|
|_|
the score value would be 1, it would match all the correct places we've identified a non-space character, but because it has an extra pipe we increased the score

For input 
 _ 
|_ 
 _|
the score value would be 1, it would miss one pipe

For input 
  |
  |
the score would be 6, ie the worst possible score for a valid number input

this means if the valid number to meet the checksum is 6 but either the invalid pattern for 5 or 8 was detected, then these would be the two next numbers/specifications to assess




this also allows for configurable ranking, the UserStory4 only requires to add or remove (so only allow a score of 1 or below) but this range could be made to be higher, by using a higher allowed score, an allowed score of 2 for example would allow to add/remove two non-space character or to add and remove
this would mean that the input
 _ 
|_ 
|_|

in which 6/5/8 and all incorrect sums to be assessed as 
 _ 
|_|
 _|
