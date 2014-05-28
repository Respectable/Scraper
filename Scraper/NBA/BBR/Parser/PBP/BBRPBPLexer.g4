lexer grammar BBRPBPLexer;

@members
{
	protected const int EOF = Eof;
	protected const int HIDDEN = Hidden;
}

QUARTER_TAG	:	'<Quarter>'		->	skip, pushMode(QUARTER) ;

//===========================================================
mode QUARTER;

QUARTER_INFO_TAG	:	'<QuarterInfo>'		->	skip, pushMode(QUARTER_INFO) ;
QUARTER_START_TAG	:	'<QuarterStart>'	->	skip, pushMode(QUARTER_START) ;

//-----------------------------------------------------------
mode QUARTER_INFO;

//-----------------------------------------------------------
mode QUARTER_START;

