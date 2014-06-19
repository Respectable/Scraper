lexer grammar Lexer1;

ONE			:	'['		->	skip, pushMode(QUARTER_MODE) ;
WS			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//===========================================================
//===========================================================
mode QUARTER_MODE;

NUMBER	:	[0-9]+	;
TWO			:	']'		->	skip, popMode ;
WS_ALT_1	:	(' '|'\t'|'\r'|'\n')+	-> skip;
