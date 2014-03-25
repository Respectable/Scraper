lexer grammar BBRLexer;

@members
{
	protected const int EOF = Eof;
	protected const int HIDDEN = Hidden;
}

WS
	:	' ' -> channel(HIDDEN)
	;
