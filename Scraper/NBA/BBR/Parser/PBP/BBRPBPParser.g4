parser grammar BBRPBPParser;

@members
{
	protected const int EOF = Eof;
}

options { tokenVocab=BBRPBPLexer; }

game
	:	period+
	;

period
	:	startOfPeriod play+ endOfPeriod
	;

startOfPeriod
	:	TIME START_LITERAL OF_LITERAL periodIdentifier periodType
	;

endOfPeriod
	:	TIME END_LITERAL OF_LITERAL periodIdentifier periodType
	;

periodIdentifier
	:	FIRST_PBP
	|	SECOND_PBP
	|	THIRD_PBP
	|	FOURTH_PBP
	|	FIFTH_PBP
	|	SIXTH_PBP
	|	SEVENTH_PBP
	|	EIGHTH_PBP
	;

periodType
	:	QUARTER_PBP
	|	OVERTIME_PBP
	;

player
	:	PLAYER_URL PLAYER_NAME+
	;

play
	:	TIME (jumpBall
			 |	missedShot
			 |	madeShot
			 |	rebound
			 |	foul
			 |	turnover
			 |	freeThrow
			 |	substitution
			 |	violation
			 |	technicalFoul)
	;

jumpBall
	:	JUMP_LITERAL BALL_LITERAL player VS_LITERAL player player GAINS_LITERAL POSSESSION_LITERAL
	;

missedShot
	:	player MISSES_LITERAL shotValue SHOT_LITERAL FROM_LITERAL NUMBER FEET (block | )
	;

madeShot
	:	player MAKES_LITERAL shotValue SHOT_LITERAL shotDistance (assist | )
	;

shotDistance
	:	FROM_LITERAL NUMBER FEET
	|	AT_LITERAL RIM_LITERAL
	;

assist
	:	ASSIST_LITERAL BY_LITERAL player
	;

shotValue
	:	TWO_POINT
	|	THREE_POINT
	;

rebound
	:	reboundType REBOUND_LITERAL BY_LITERAL (player | TEAM_LITERAL)
	;

reboundType
	:	OFFENSIVE_LITERAL
	|	DEFENSIVE_LITERAL
	;

block
	:	BLOCK_LITERAL BY_LITERAL player
	;

foul
	:	foulType FOUL_LITERAL BY_LITERAL player (DRAWN_LITERAL BY_LITERAL player | )
	;

foulType
	:	LOOSE_LITERAL BALL_LITERAL
	|	SHOOTING_LITERAL
	|	PERSONAL_LITERAL
	|	OFFENNSIVE_LITERAL
	|	PERSONAL_LITERAL BLOCK_LITERAL
	|	PERSONAL_LITERAL TAKE_LITERAL
	;

turnover
	:	TURNOVER_LITERAL BY_LITERAL (player | TEAM_LITERAL) turnoverType (steal | )
	;

turnoverType
	:	BAD_LITERAL PASS_LITERAL
	|	TRAVELING_LITERAL
	|	DISCONTINUED_LITERAL DRIBBLE_LITERAL
	|	OFFENSIVE_LITERAL FOUL_LITERAL
	|	DOUBLE_LITERAL DRIBBLE_LITERAL
	|	LOST_LITERAL BALL_LITERAL
	|	NUMBER SEC_LITERAL
	|	SHOT_LITERAL CLOCK_LITERAL
	;

steal
	:	STEAL_LITERAL BY_LITERAL player
	;

freeThrow
	:	player (MISSES_LITERAL | MAKES_LITERAL) freeThrowType FREE_LITERAL THROW_LITERAL NUMBER OF_LITERAL NUMBER
	;

freeThrowType
	:	TECHNICAL_LITERAL
	|	FLAGRANT_LITERAL
	|	//empty
	;

//timeouts (Team Names)

substitution
	:	player ENTERS_LITERAL THE_LITERAL GAME_LITERAL FOR_LITERAL player
	;

violation
	:	VIOLATION_LITERAL BY_LITERAL (TEAM_LITERAL | player) violationType
	;

violationType
	:	JUMP_LITERAL BALL_LITERAL
	|	KICKED_LITERAL BALL_LITERAL
	;

technicalFoul
	:	DELAY_LITERAL TECH_LITERAL FOUL_LITERAL BY_LITERAL TEAM_LITERAL
	;


