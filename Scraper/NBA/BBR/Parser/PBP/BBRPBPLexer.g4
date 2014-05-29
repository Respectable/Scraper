lexer grammar BBRPBPLexer;

@members
{
	protected const int EOF = Eof;
	protected const int HIDDEN = Hidden;
}

QUARTER_TAG			:	'<Quarter>'		->	skip, pushMode(QUARTER_MODE) ;
GAME_HEADER_TAG		:	'<GameHeader>'	->	skip, pushMode(GAME_HEADER_MODE) ;
TIMED_EVENT_TAG		:	'<TimedEvent>'	->	skip, pushMode(TIMED_EVENT_MODE) ;

//===========================================================
//===========================================================
mode QUARTER_MODE;

QUARTER_INFO_TAG	:	'<QuarterInfo>'		->	skip, pushMode(QUARTER_INFO_MODE) ;
QUARTER_START_TAG	:	'<QuarterStart>'	->	skip, pushMode(QUARTER_START_MODE) ;
QUARTER_END			:	'</Quarter>'		->	skip, popMode ;

//-----------------------------------------------------------
mode QUARTER_INFO_MODE;

QUARTER_INFO_END	:	'</QuarterInfo>'	->	skip, popMode ;
FIRST				:	'1st' ;
SECOND				:	'2nd' ;
THIRD				:	'3rd' ;
FOURTH				:	'4th' ;
FIFTH				:	'5th' ;
SIXTH				:	'6th' ;
SEVENTH				:	'7th' ;
EIGHTH				:	'8th' ;
QUARTER				:	'Quarter' ;
OVERTIME			:	'Overtime' ;	

//-----------------------------------------------------------
mode QUARTER_START_MODE;

QUARTER_START_END	:	'</QuarterStart>'	->	skip, popMode ;
QUARTER_STARTING	:	'true' ;
QUARTER_ENDING		:	'false' ;

//==============================================================
//==============================================================
mode GAME_HEADER_MODE;

HOME_TAG			:	'<Home>'		->	skip, pushMode(HOME_MODE) ;
AWAY_TAG			:	'<Away>'		->	skip, pushMode(AWAY_MODE) ;
GAME_HEADER_END		:	'</GameHeader>'	->	skip, popMode ;

//--------------------------------------------------------------
mode HOME_MODE;

HOME_NAME			:	[a-zA-Z]+ ;
HOME_END			:	'</Home>'	->	skip, popMode ;

//--------------------------------------------------------------
mode AWAY_MODE;

AWAY_NAME			:	[a-zA-Z]+ ;
AWAY_END			:	'</Away>'	->	skip, popMode ;

//==============================================================
//==============================================================
mode TIMED_EVENT_MODE;

TIME_TAG			:	'<Time>'		->	skip, pushMode(TIME_MODE) ;
PBP_EVENT_TAG		:	'<PBPEvent>'	->	skip, pushMode(PBP_EVENT_MODE) ;

//--------------------------------------------------------------
mode TIME_MODE;

TIME_END			:	'</Time>'	->	skip, popMode ;
TIME				:	[0-9]+':'[0-9][0-9]'.'[0-9] ;

//--------------------------------------------------------------
mode PBP_EVENT_MODE;

PBP_EVENT_END		:	'</PBPEvent>'	->	skip, popMode ;
CURRENT_SCORE		:	[0-9]+'-'[0-9]+ ;
SCORE_INCREASE		:	'+'[1-3] ;
PLAYER_TAG			:	'['				->	skip, pushMode(PLAYER_MODE) ;

//--------------------------------------------------------------
mode PLAYER_MODE;

PLAYER_URL_TAG		:	'{'		->	skip, pushMode(PLAYER_URL_MODE) ;
PLAYER_END			:	']'		->	skip, popMode ;
PLAYER_NAME			:	[a-zA-Z.-]+ ;

//--------------------------------------------------------------
mode PLAYER_URL_MODE;

PLAYER_URL			:	[a-zA-Z0-9.] ;
PLAYER_URL_END		:	'}'		->	skip, popMode;