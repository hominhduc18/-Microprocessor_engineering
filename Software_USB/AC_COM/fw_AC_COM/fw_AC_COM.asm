
_main:

;fw_AC_COM.c,2 :: 		void main()
;fw_AC_COM.c,4 :: 		ADCON1 |= 0x0F;
	MOVLW       15
	IORWF       ADCON1+0, 1 
;fw_AC_COM.c,5 :: 		CMCON |= 0x07;
	MOVLW       7
	IORWF       CMCON+0, 1 
;fw_AC_COM.c,7 :: 		PORTC = 0x00; LATC = 0x00;
	CLRF        PORTC+0 
	CLRF        LATC+0 
;fw_AC_COM.c,8 :: 		TRISC0_bit = 1;
	BSF         TRISC0_bit+0, BitPos(TRISC0_bit+0) 
;fw_AC_COM.c,9 :: 		TRISC1_bit = 1;
	BSF         TRISC1_bit+0, BitPos(TRISC1_bit+0) 
;fw_AC_COM.c,10 :: 		TRISC2_bit = 1;
	BSF         TRISC2_bit+0, BitPos(TRISC2_bit+0) 
;fw_AC_COM.c,12 :: 		PORTB = 0x00; LATB = 0x00;
	CLRF        PORTB+0 
	CLRF        LATB+0 
;fw_AC_COM.c,13 :: 		TRISB0_bit = 1;
	BSF         TRISB0_bit+0, BitPos(TRISB0_bit+0) 
;fw_AC_COM.c,14 :: 		TRISB1_bit = 1;
	BSF         TRISB1_bit+0, BitPos(TRISB1_bit+0) 
;fw_AC_COM.c,15 :: 		TRISB2_bit = 1;
	BSF         TRISB2_bit+0, BitPos(TRISB2_bit+0) 
;fw_AC_COM.c,17 :: 		PORTE = 0x00; LATE = 0x00;
	CLRF        PORTE+0 
	CLRF        LATE+0 
;fw_AC_COM.c,18 :: 		TRISE0_bit = 0;
	BCF         TRISE0_bit+0, BitPos(TRISE0_bit+0) 
;fw_AC_COM.c,19 :: 		LATE0_bit = 1;
	BSF         LATE0_bit+0, BitPos(LATE0_bit+0) 
;fw_AC_COM.c,20 :: 		TRISE1_bit = 0;
	BCF         TRISE1_bit+0, BitPos(TRISE1_bit+0) 
;fw_AC_COM.c,21 :: 		LATE1_bit = 1;
	BSF         LATE1_bit+0, BitPos(LATE1_bit+0) 
;fw_AC_COM.c,22 :: 		TRISE2_bit = 0;
	BCF         TRISE2_bit+0, BitPos(TRISE2_bit+0) 
;fw_AC_COM.c,23 :: 		LATE2_bit = 1;
	BSF         LATE2_bit+0, BitPos(LATE2_bit+0) 
;fw_AC_COM.c,25 :: 		PORTD = 0x00; LATD = 0x00;
	CLRF        PORTD+0 
	CLRF        LATD+0 
;fw_AC_COM.c,26 :: 		TRISD0_bit = 0;
	BCF         TRISD0_bit+0, BitPos(TRISD0_bit+0) 
;fw_AC_COM.c,27 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;fw_AC_COM.c,28 :: 		TRISD1_bit = 0;
	BCF         TRISD1_bit+0, BitPos(TRISD1_bit+0) 
;fw_AC_COM.c,29 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;fw_AC_COM.c,30 :: 		TRISD2_bit = 0;
	BCF         TRISD2_bit+0, BitPos(TRISD2_bit+0) 
;fw_AC_COM.c,31 :: 		LATD2_bit = 1;
	BSF         LATD2_bit+0, BitPos(LATD2_bit+0) 
;fw_AC_COM.c,32 :: 		TRISD3_bit = 0;
	BCF         TRISD3_bit+0, BitPos(TRISD3_bit+0) 
;fw_AC_COM.c,33 :: 		LATD3_bit = 1;
	BSF         LATD3_bit+0, BitPos(LATD3_bit+0) 
;fw_AC_COM.c,35 :: 		UART1_Init(9600);
	BSF         BAUDCON+0, 3, 0
	MOVLW       2
	MOVWF       SPBRGH+0 
	MOVLW       8
	MOVWF       SPBRG+0 
	BSF         TXSTA+0, 2, 0
	CALL        _UART1_Init+0, 0
;fw_AC_COM.c,36 :: 		delay_ms(100);
	MOVLW       3
	MOVWF       R11, 0
	MOVLW       138
	MOVWF       R12, 0
	MOVLW       85
	MOVWF       R13, 0
L_main0:
	DECFSZ      R13, 1, 1
	BRA         L_main0
	DECFSZ      R12, 1, 1
	BRA         L_main0
	DECFSZ      R11, 1, 1
	BRA         L_main0
	NOP
	NOP
;fw_AC_COM.c,38 :: 		while(1)
L_main1:
;fw_AC_COM.c,40 :: 		if(Button(&PORTB,0,10,0))
	MOVLW       PORTB+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTB+0)
	MOVWF       FARG_Button_port+1 
	CLRF        FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	CLRF        FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main3
;fw_AC_COM.c,42 :: 		TransmitData = 'A';
	MOVLW       65
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,43 :: 		UART1_Write(TransmitData);
	MOVLW       65
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,44 :: 		}
	GOTO        L_main4
L_main3:
;fw_AC_COM.c,45 :: 		else if(Button(&PORTB,0,10,1))
	MOVLW       PORTB+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTB+0)
	MOVWF       FARG_Button_port+1 
	CLRF        FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	MOVLW       1
	MOVWF       FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main5
;fw_AC_COM.c,47 :: 		TransmitData = 'S';
	MOVLW       83
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,48 :: 		UART1_Write(TransmitData);
	MOVLW       83
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,49 :: 		}
L_main5:
L_main4:
;fw_AC_COM.c,50 :: 		if(Button(&PORTB,1,10,0))
	MOVLW       PORTB+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTB+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       1
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	CLRF        FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main6
;fw_AC_COM.c,52 :: 		TransmitData = 'D';
	MOVLW       68
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,53 :: 		UART1_Write(TransmitData);
	MOVLW       68
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,54 :: 		}
	GOTO        L_main7
L_main6:
;fw_AC_COM.c,55 :: 		else if(Button(&PORTB,1,10,1))
	MOVLW       PORTB+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTB+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       1
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	MOVLW       1
	MOVWF       FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main8
;fw_AC_COM.c,57 :: 		TransmitData = 'F';
	MOVLW       70
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,58 :: 		UART1_Write(TransmitData);
	MOVLW       70
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,59 :: 		}
L_main8:
L_main7:
;fw_AC_COM.c,60 :: 		if(Button(&PORTB,2,10,0))
	MOVLW       PORTB+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTB+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       2
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	CLRF        FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main9
;fw_AC_COM.c,62 :: 		TransmitData = 'G';
	MOVLW       71
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,63 :: 		UART1_Write(TransmitData);
	MOVLW       71
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,64 :: 		}
	GOTO        L_main10
L_main9:
;fw_AC_COM.c,65 :: 		else if(Button(&PORTB,2,10,1))
	MOVLW       PORTB+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTB+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       2
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	MOVLW       1
	MOVWF       FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main11
;fw_AC_COM.c,67 :: 		TransmitData = 'H';
	MOVLW       72
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,68 :: 		UART1_Write(TransmitData);
	MOVLW       72
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,69 :: 		}
L_main11:
L_main10:
;fw_AC_COM.c,70 :: 		if(Button(&PORTC,0,10,0))
	MOVLW       PORTC+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTC+0)
	MOVWF       FARG_Button_port+1 
	CLRF        FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	CLRF        FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main12
;fw_AC_COM.c,72 :: 		TransmitData = '1';
	MOVLW       49
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,73 :: 		UART1_Write(TransmitData);
	MOVLW       49
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,74 :: 		}
	GOTO        L_main13
L_main12:
;fw_AC_COM.c,75 :: 		else if(Button(&PORTC,0,10,1))
	MOVLW       PORTC+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTC+0)
	MOVWF       FARG_Button_port+1 
	CLRF        FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	MOVLW       1
	MOVWF       FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main14
;fw_AC_COM.c,77 :: 		TransmitData = '2';
	MOVLW       50
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,78 :: 		UART1_Write(TransmitData);
	MOVLW       50
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,79 :: 		}
L_main14:
L_main13:
;fw_AC_COM.c,80 :: 		if(Button(&PORTC,1,10,0))
	MOVLW       PORTC+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTC+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       1
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	CLRF        FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main15
;fw_AC_COM.c,82 :: 		TransmitData = '3';
	MOVLW       51
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,83 :: 		UART1_Write(TransmitData);
	MOVLW       51
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,84 :: 		}
	GOTO        L_main16
L_main15:
;fw_AC_COM.c,85 :: 		else if(Button(&PORTC,1,10,1))
	MOVLW       PORTC+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTC+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       1
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	MOVLW       1
	MOVWF       FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main17
;fw_AC_COM.c,87 :: 		TransmitData = '4';
	MOVLW       52
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,88 :: 		UART1_Write(TransmitData);
	MOVLW       52
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,89 :: 		}
L_main17:
L_main16:
;fw_AC_COM.c,90 :: 		if(Button(&PORTC,2,10,0))
	MOVLW       PORTC+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTC+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       2
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	CLRF        FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main18
;fw_AC_COM.c,92 :: 		TransmitData = '5';
	MOVLW       53
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,93 :: 		UART1_Write(TransmitData);
	MOVLW       53
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,94 :: 		}
	GOTO        L_main19
L_main18:
;fw_AC_COM.c,95 :: 		else if(Button(&PORTC,2,10,1))
	MOVLW       PORTC+0
	MOVWF       FARG_Button_port+0 
	MOVLW       hi_addr(PORTC+0)
	MOVWF       FARG_Button_port+1 
	MOVLW       2
	MOVWF       FARG_Button_pin+0 
	MOVLW       10
	MOVWF       FARG_Button_time_ms+0 
	MOVLW       1
	MOVWF       FARG_Button_active_state+0 
	CALL        _Button+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_main20
;fw_AC_COM.c,97 :: 		TransmitData = '6';
	MOVLW       54
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,98 :: 		UART1_Write(TransmitData);
	MOVLW       54
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,99 :: 		}
L_main20:
L_main19:
;fw_AC_COM.c,100 :: 		if(UART1_Data_Ready() == 1)
	CALL        _UART1_Data_Ready+0, 0
	MOVF        R0, 0 
	XORLW       1
	BTFSS       STATUS+0, 2 
	GOTO        L_main21
;fw_AC_COM.c,102 :: 		ReceiveData = UART1_Read();
	CALL        _UART1_Read+0, 0
	MOVF        R0, 0 
	MOVWF       _ReceiveData+0 
;fw_AC_COM.c,103 :: 		if(ReceiveData == '!')
	MOVF        R0, 0 
	XORLW       33
	BTFSS       STATUS+0, 2 
	GOTO        L_main22
;fw_AC_COM.c,105 :: 		LATE0_bit = 0;
	BCF         LATE0_bit+0, BitPos(LATE0_bit+0) 
;fw_AC_COM.c,106 :: 		TransmitData = 'q';
	MOVLW       113
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,107 :: 		UART1_Write(TransmitData);
	MOVLW       113
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,108 :: 		}
	GOTO        L_main23
L_main22:
;fw_AC_COM.c,109 :: 		else if(ReceiveData == '@')
	MOVF        _ReceiveData+0, 0 
	XORLW       64
	BTFSS       STATUS+0, 2 
	GOTO        L_main24
;fw_AC_COM.c,111 :: 		LATE0_bit = 1;
	BSF         LATE0_bit+0, BitPos(LATE0_bit+0) 
;fw_AC_COM.c,112 :: 		TransmitData = 'w';
	MOVLW       119
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,113 :: 		UART1_Write(TransmitData);
	MOVLW       119
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,114 :: 		}
	GOTO        L_main25
L_main24:
;fw_AC_COM.c,115 :: 		else if(ReceiveData == '#')
	MOVF        _ReceiveData+0, 0 
	XORLW       35
	BTFSS       STATUS+0, 2 
	GOTO        L_main26
;fw_AC_COM.c,117 :: 		LATE1_bit = 0;
	BCF         LATE1_bit+0, BitPos(LATE1_bit+0) 
;fw_AC_COM.c,118 :: 		TransmitData = 'e';
	MOVLW       101
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,119 :: 		UART1_Write(TransmitData);
	MOVLW       101
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,120 :: 		}
	GOTO        L_main27
L_main26:
;fw_AC_COM.c,121 :: 		else if(ReceiveData == '$')
	MOVF        _ReceiveData+0, 0 
	XORLW       36
	BTFSS       STATUS+0, 2 
	GOTO        L_main28
;fw_AC_COM.c,123 :: 		LATE1_bit = 1;
	BSF         LATE1_bit+0, BitPos(LATE1_bit+0) 
;fw_AC_COM.c,124 :: 		TransmitData = 'r';
	MOVLW       114
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,125 :: 		UART1_Write(TransmitData);
	MOVLW       114
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,126 :: 		}
	GOTO        L_main29
L_main28:
;fw_AC_COM.c,127 :: 		else if(ReceiveData == '%')
	MOVF        _ReceiveData+0, 0 
	XORLW       37
	BTFSS       STATUS+0, 2 
	GOTO        L_main30
;fw_AC_COM.c,129 :: 		LATE2_bit = 0;
	BCF         LATE2_bit+0, BitPos(LATE2_bit+0) 
;fw_AC_COM.c,130 :: 		TransmitData = 't';
	MOVLW       116
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,131 :: 		UART1_Write(TransmitData);
	MOVLW       116
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,132 :: 		}
	GOTO        L_main31
L_main30:
;fw_AC_COM.c,133 :: 		else if(ReceiveData == '^')
	MOVF        _ReceiveData+0, 0 
	XORLW       94
	BTFSS       STATUS+0, 2 
	GOTO        L_main32
;fw_AC_COM.c,135 :: 		LATE2_bit = 1;
	BSF         LATE2_bit+0, BitPos(LATE2_bit+0) 
;fw_AC_COM.c,136 :: 		TransmitData = 'y';
	MOVLW       121
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,137 :: 		UART1_Write(TransmitData);
	MOVLW       121
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,138 :: 		}
	GOTO        L_main33
L_main32:
;fw_AC_COM.c,139 :: 		else if(ReceiveData == '&')
	MOVF        _ReceiveData+0, 0 
	XORLW       38
	BTFSS       STATUS+0, 2 
	GOTO        L_main34
;fw_AC_COM.c,141 :: 		LATD0_bit = 0;
	BCF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;fw_AC_COM.c,142 :: 		TransmitData = 'z';
	MOVLW       122
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,143 :: 		UART1_Write(TransmitData);
	MOVLW       122
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,144 :: 		}
	GOTO        L_main35
L_main34:
;fw_AC_COM.c,145 :: 		else if(ReceiveData == '*')
	MOVF        _ReceiveData+0, 0 
	XORLW       42
	BTFSS       STATUS+0, 2 
	GOTO        L_main36
;fw_AC_COM.c,147 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;fw_AC_COM.c,148 :: 		TransmitData = 'x';
	MOVLW       120
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,149 :: 		UART1_Write(TransmitData);
	MOVLW       120
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,150 :: 		}
	GOTO        L_main37
L_main36:
;fw_AC_COM.c,151 :: 		else if(ReceiveData == '(')
	MOVF        _ReceiveData+0, 0 
	XORLW       40
	BTFSS       STATUS+0, 2 
	GOTO        L_main38
;fw_AC_COM.c,153 :: 		LATD1_bit = 0;
	BCF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;fw_AC_COM.c,154 :: 		TransmitData = 'c';
	MOVLW       99
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,155 :: 		UART1_Write(TransmitData);
	MOVLW       99
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,156 :: 		}
	GOTO        L_main39
L_main38:
;fw_AC_COM.c,157 :: 		else if(ReceiveData == ')')
	MOVF        _ReceiveData+0, 0 
	XORLW       41
	BTFSS       STATUS+0, 2 
	GOTO        L_main40
;fw_AC_COM.c,159 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;fw_AC_COM.c,160 :: 		TransmitData = 'v';
	MOVLW       118
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,161 :: 		UART1_Write(TransmitData);
	MOVLW       118
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,162 :: 		}
	GOTO        L_main41
L_main40:
;fw_AC_COM.c,163 :: 		else if(ReceiveData == '_')
	MOVF        _ReceiveData+0, 0 
	XORLW       95
	BTFSS       STATUS+0, 2 
	GOTO        L_main42
;fw_AC_COM.c,165 :: 		LATD2_bit = 0;
	BCF         LATD2_bit+0, BitPos(LATD2_bit+0) 
;fw_AC_COM.c,166 :: 		TransmitData = 'b';
	MOVLW       98
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,167 :: 		UART1_Write(TransmitData);
	MOVLW       98
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,168 :: 		}
	GOTO        L_main43
L_main42:
;fw_AC_COM.c,169 :: 		else if(ReceiveData == '+')
	MOVF        _ReceiveData+0, 0 
	XORLW       43
	BTFSS       STATUS+0, 2 
	GOTO        L_main44
;fw_AC_COM.c,171 :: 		LATD2_bit = 1;
	BSF         LATD2_bit+0, BitPos(LATD2_bit+0) 
;fw_AC_COM.c,172 :: 		TransmitData = 'n';
	MOVLW       110
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,173 :: 		UART1_Write(TransmitData);
	MOVLW       110
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,174 :: 		}
	GOTO        L_main45
L_main44:
;fw_AC_COM.c,175 :: 		else if(ReceiveData == '<')
	MOVF        _ReceiveData+0, 0 
	XORLW       60
	BTFSS       STATUS+0, 2 
	GOTO        L_main46
;fw_AC_COM.c,177 :: 		LATD3_bit = 0;
	BCF         LATD3_bit+0, BitPos(LATD3_bit+0) 
;fw_AC_COM.c,178 :: 		TransmitData = 'm';
	MOVLW       109
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,179 :: 		UART1_Write(TransmitData);
	MOVLW       109
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,180 :: 		}
	GOTO        L_main47
L_main46:
;fw_AC_COM.c,181 :: 		else if(ReceiveData == '>')
	MOVF        _ReceiveData+0, 0 
	XORLW       62
	BTFSS       STATUS+0, 2 
	GOTO        L_main48
;fw_AC_COM.c,183 :: 		LATD3_bit = 1;
	BSF         LATD3_bit+0, BitPos(LATD3_bit+0) 
;fw_AC_COM.c,184 :: 		TransmitData = 'l';
	MOVLW       108
	MOVWF       _TransmitData+0 
;fw_AC_COM.c,185 :: 		UART1_Write(TransmitData);
	MOVLW       108
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;fw_AC_COM.c,186 :: 		}
L_main48:
L_main47:
L_main45:
L_main43:
L_main41:
L_main39:
L_main37:
L_main35:
L_main33:
L_main31:
L_main29:
L_main27:
L_main25:
L_main23:
;fw_AC_COM.c,187 :: 		}
L_main21:
;fw_AC_COM.c,188 :: 		}
	GOTO        L_main1
;fw_AC_COM.c,190 :: 		}
L_end_main:
	GOTO        $+0
; end of _main
