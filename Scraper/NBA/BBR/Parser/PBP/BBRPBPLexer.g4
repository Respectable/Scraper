lexer grammar BBRPBPLexer;

@members
{
	protected const int EOF = Eof;
	protected const int HIDDEN = Hidden;
}

QUARTER_TAG			:	'<Quarter>'		->	skip, pushMode(QUARTER_MODE) ;
GAME_HEADER_TAG		:	'<GameHeader>'	->	skip, pushMode(GAME_HEADER_MODE) ;
TIMED_EVENT_TAG		:	'<TimedEvent>'	->	skip, pushMode(TIMED_EVENT_MODE) ;
WS					:	(' '|'\t'|'\r'|'\n')+	-> skip;

//===========================================================
//===========================================================
mode QUARTER_MODE;

QUARTER_INFO_TAG	:	'<QuarterInfo>'		->	skip, pushMode(QUARTER_INFO_MODE) ;
QUARTER_START_TAG	:	'<QuarterStart>'	->	skip, pushMode(QUARTER_START_MODE) ;
QUARTER_END			:	'</Quarter>'		->	skip, popMode ;
WS_ALT_1			:	(' '|'\t'|'\r'|'\n')+	-> skip;

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
JUNK				:	'('~(')')+')' -> skip ;
WS_ALT_2			:	(' '|'\t'|'\r'|'\n')+	-> skip;	

//-----------------------------------------------------------
mode QUARTER_START_MODE;

QUARTER_START_END	:	'</QuarterStart>'	->	skip, popMode ;
QUARTER_STARTING	:	'true' ;
QUARTER_ENDING		:	'false' ;
WS_ALT_3			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//==============================================================
//==============================================================
mode GAME_HEADER_MODE;

HOME_TAG			:	'<Home>'		->	skip, pushMode(HOME_MODE) ;
AWAY_TAG			:	'<Away>'		->	skip, pushMode(AWAY_MODE) ;
GAME_HEADER_END		:	'</GameHeader>'	->	skip, popMode ;
WS_ALT_4			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//--------------------------------------------------------------
mode HOME_MODE;

HOME_NAME			:	[a-zA-Z]+ ;
HOME_END			:	'</Home>'	->	skip, popMode ;
WS_ALT_5			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//--------------------------------------------------------------
mode AWAY_MODE;

AWAY_NAME			:	[a-zA-Z]+ ;
AWAY_END			:	'</Away>'	->	skip, popMode ;
WS_ALT_6			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//==============================================================
//==============================================================
mode TIMED_EVENT_MODE;

TIME_TAG			:	'<Time>'		->	skip, pushMode(TIME_MODE) ;
PBP_EVENT_TAG		:	'<PBPEvent>'	->	skip, pushMode(PBP_EVENT_MODE) ;
TIMED_EVENT_END		:	'</TimedEvent>' ->	skip, popMode ;
WS_ALT_7			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//--------------------------------------------------------------
mode TIME_MODE;

TIME_END			:	'</Time>'	->	skip, popMode ;
TIME				:	[0-9]+':'[0-9][0-9]'.'[0-9] ;
WS_ALT_8			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//--------------------------------------------------------------
mode PBP_EVENT_MODE;

PBP_EVENT_END		:	'</PBPEvent>'	->	skip, popMode ;
CURRENT_SCORE		:	[0-9]+'-'[0-9]+ ;
ADD_ONE				:	'+1' ;
ADD_TWO				:	'+2' ;
ADD_THREE			:	'+3' ;
PLAYER_TAG			:	'['				->	skip, pushMode(PLAYER_MODE) ;
START_LITERAL		:	'Start'	;
OF_LITERAL			:	'of'	;
FIRST_PBP			:	'1st'	;
SECOND_PBP			:	'2nd' ;
THIRD_PBP			:	'3rd' ;
FOURTH_PBP			:	'4th' ;
FIFTH_PBP			:	'5th' ;
SIXTH_PBP			:	'6th' ;
SEVENTH_PBP			:	'7th' ;
EIGHTH_PBP			:	'8th' ;
QUARTER_PBP			:	'quarter' ;
OVERTIME_PBP		:	'overtime' ;
JUMP_LITERAL		:	'Jump' | 'jump' ;
BALL_LITERAL		:	'ball' ;
VS_LITERAL			:	'vs.' ;
GAINS_LITERAL		:	'gains' ;
POSSESSION_LITERAL	:	'possession' ;
MISSES_LITERAL		:	'misses' ;
TWO_POINT			:	'2-pt' ;
THREE_POINT			:	'3-pt' ;
SHOT_LITERAL		:	'shot' ;
FROM_LITERAL		:	'from' ;
FEET				:	'ft' ;
OFFENSIVE_LITERAL	:	'Offensive'	| 'offensive' ;
DEFENSIVE_LITERAL	:	'Defensive'	| 'defensive' ;
REBOUND_LITERAL		:	'Rebound'	| 'rebound' ;
BY_LITERAL			:	'by' ;
LOOSE_LITERAL		:	'Loose' ;
FOUL_LITERAL		:	'foul' ;
MAKES_LITERAL		:	'makes' ;
BLOCK_LITERAL		:	'block' ;
TURNOVER_LITERAL	:	'Turnover'	|	'turnover' ;
BAD_LITERAL			:	'bad' ;
PASS_LITERAL		:	'pass' ;
STEAL_LITERAL		:	'steal' ;
ASSIST_LITERAL		:	'assist' ;
TEAM_LITERAL		:	'Team'	| 'team' ;
SHOOTING_LITERAL	:	'Shooting' ;
DRAWN_LITERAL		:	'drawn' ;
FREE_LITERAL		:	'free' ;
THROW_LITERAL		:	'throw' ;
TRAVELING_LITERAL	:	'traveling' ;
AT_LITERAL			:	'at' ;
RIM_LITERAL			:	'rim' ;
FULL_LITERAL		:	'full' ;
TIMEOUT_LITERAL		:	'timeout' ;
LOST_LITERAL		:	'lost' ;
PERSONAL_LITERAL	:	'Personal' ;
ENTERS_LITERAL		:	'enters' ;
THE_LITERAL			:	'the' ;
GAME_LITERAL		:	'game' ;
FOR_LITERAL			:	'for' ;
DISCONT_LITERAL		:	'discontinued' ;
DRIBBLE_LITERAL		:	'dribble' ;
END_LITERAL			:	'End' ;
DOUBLE				:	'dbl' ;
VIOLATION_LITERAL	:	'Violation'	| 'violation' ;
SEC_LITERAL			:	'sec' ;
OFFICiAL_LITERAL	:	'Official' | 'official' ;
CLOCK_LITERAL		:	'clock' ;
TECHNICAL_LITERAL	:	'technical' | 'tech';
KICKED_LITERAL		:	'kicked' ;
CHARGE_LITERAL		:	'charge' ;
DELAY_LITERAL		:	'Delay' | 'delay' ;
FLAGRANT_LITERAL	:	'flagrant' ;
TAKE_LITERAL		:	'take' ;
NUMBER				:	[0-9]+ ;
SEMI_COLON			:	';' -> skip ;
OPEN_PAREN			:	'('  -> skip ;
CLOSED_PAREN		:	')' -> skip ;
TEXT				:	[a-zA-Z0-9\-.]+ ;
COLON				:	':' 	-> skip ;
WS_ALT_9			:	(' '|'\t'|'\r'|'\n')+	-> skip;


//--------------------------------------------------------------
mode PLAYER_MODE;

PLAYER_URL_TAG		:	'{'		->	skip, pushMode(PLAYER_URL_MODE) ;
PLAYER_END			:	']'		->	skip, popMode ;
APOSTROPHE			:	'&amp;apos;' ;
O_UMLAUT			:	'ö' ;
PLAYER_NAME			:	[a-zA-Z.-]+ ;
WS_ALT_10			:	(' '|'\t'|'\r'|'\n')+	-> skip;

//--------------------------------------------------------------
mode PLAYER_URL_MODE;

PLAYER_URL			:	[a-zA-Z0-9./]+ ;
PLAYER_URL_END		:	'}'		->	skip, popMode;
WS_ALT_11			:	(' '|'\t'|'\r'|'\n')+	-> skip;