INCLUDE ../global.ink
System: now you can preview your material window. #drawingSystem: showMaterialWindow #profile: hide

System: and now you can select your drawing material. #drawingSystem: selectMaterial
System: choose one of the result that the dialogue branches will lead you to.
Me：in my eyes, the subject is a... #profile: painter_side
+[LIER!] ->fraud
+[brothers!] ->brother
+[take my soul...] ->saint

==fraud==
Me: 8-2 is a fraud. 
->result 
==brother==
Me: 8-2 is your brother. #drawingSystem: addBinaryVal_60
->result
==saint==
Me: 8-2 is a saint. #drawingSystem: addBinaryVal_90
->result
==result==
System: then, here is your result: #profile: hide
System: see - #drawingSystem: showDrawResult
->END
