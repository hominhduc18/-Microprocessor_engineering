
_main:

;bai8_fw.c,2 :: 		void main()
;bai8_fw.c,4 :: 		ADCON1 |= 0x0F;
	MOVLW       15
	IORWF       ADCON1+0, 1 
;bai8_fw.c,5 :: 		CMCON |= 7;
	MOVLW       7
	IORWF       CMCON+0, 1 
;bai8_fw.c,7 :: 		PORTB = 0x00;
	CLRF        PORTB+0 
;bai8_fw.c,8 :: 		LATB = 0x00;
	CLRF        LATB+0 
;bai8_fw.c,9 :: 		TRISC0_bit = 1;
	BSF         TRISC0_bit+0, BitPos(TRISC0_bit+0) 
;bai8_fw.c,10 :: 		TRISC1_bit = 1;
	BSF         TRISC1_bit+0, BitPos(TRISC1_bit+0) 
;bai8_fw.c,11 :: 		TRISC2_bit = 1;
	BSF         TRISC2_bit+0, BitPos(TRISC2_bit+0) 
;bai8_fw.c,13 :: 		TRISB0_bit = 1;
	BSF         TRISB0_bit+0, BitPos(TRISB0_bit+0) 
;bai8_fw.c,14 :: 		TRISB1_bit = 1;
	BSF         TRISB1_bit+0, BitPos(TRISB1_bit+0) 
;bai8_fw.c,15 :: 		TRISB2_bit = 1;
	BSF         TRISB2_bit+0, BitPos(TRISB2_bit+0) 
;bai8_fw.c,17 :: 		PORTD = 0x00;
	CLRF        PORTD+0 
;bai8_fw.c,18 :: 		LATD = 0x00;
	CLRF        LATD+0 
;bai8_fw.c,19 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,20 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,21 :: 		LATD2_bit = 1;
	BSF         LATD2_bit+0, BitPos(LATD2_bit+0) 
;bai8_fw.c,22 :: 		LATD3_bit = 1;
	BSF         LATD3_bit+0, BitPos(LATD3_bit+0) 
;bai8_fw.c,24 :: 		TRISD0_bit = 0;
	BCF         TRISD0_bit+0, BitPos(TRISD0_bit+0) 
;bai8_fw.c,25 :: 		TRISD1_bit = 0;
	BCF         TRISD1_bit+0, BitPos(TRISD1_bit+0) 
;bai8_fw.c,26 :: 		TRISD2_bit = 0;
	BCF         TRISD2_bit+0, BitPos(TRISD2_bit+0) 
;bai8_fw.c,27 :: 		TRISD3_bit = 0;
	BCF         TRISD3_bit+0, BitPos(TRISD3_bit+0) 
;bai8_fw.c,29 :: 		TRISE0_bit = 0;
	BCF         TRISE0_bit+0, BitPos(TRISE0_bit+0) 
;bai8_fw.c,30 :: 		LATE0_bit = 1;
	BSF         LATE0_bit+0, BitPos(LATE0_bit+0) 
;bai8_fw.c,31 :: 		TRISE1_bit = 0;
	BCF         TRISE1_bit+0, BitPos(TRISE1_bit+0) 
;bai8_fw.c,32 :: 		LATE1_bit = 1;
	BSF         LATE1_bit+0, BitPos(LATE1_bit+0) 
;bai8_fw.c,34 :: 		UART1_Init(9600);
	BSF         BAUDCON+0, 3, 0
	MOVLW       2
	MOVWF       SPBRGH+0 
	MOVLW       8
	MOVWF       SPBRG+0 
	BSF         TXSTA+0, 2, 0
	CALL        _UART1_Init+0, 0
;bai8_fw.c,35 :: 		delay_ms(100);
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
;bai8_fw.c,37 :: 		while(1)
L_main1:
;bai8_fw.c,40 :: 		if(LATD0_bit == 0)
	BTFSC       LATD0_bit+0, BitPos(LATD0_bit+0) 
	GOTO        L_main3
;bai8_fw.c,42 :: 		LATE0_bit = !LATE0_bit;
	BTG         LATE0_bit+0, BitPos(LATE0_bit+0) 
;bai8_fw.c,43 :: 		delay_ms(300);
	MOVLW       8
	MOVWF       R11, 0
	MOVLW       157
	MOVWF       R12, 0
	MOVLW       5
	MOVWF       R13, 0
L_main4:
	DECFSZ      R13, 1, 1
	BRA         L_main4
	DECFSZ      R12, 1, 1
	BRA         L_main4
	DECFSZ      R11, 1, 1
	BRA         L_main4
	NOP
	NOP
;bai8_fw.c,44 :: 		}
	GOTO        L_main5
L_main3:
;bai8_fw.c,45 :: 		else if(LATD0_bit == 1)
	BTFSS       LATD0_bit+0, BitPos(LATD0_bit+0) 
	GOTO        L_main6
;bai8_fw.c,47 :: 		LATE0_bit = 1;
	BSF         LATE0_bit+0, BitPos(LATE0_bit+0) 
;bai8_fw.c,48 :: 		}
L_main6:
L_main5:
;bai8_fw.c,49 :: 		if(LATE0_bit == 0)
	BTFSC       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main7
;bai8_fw.c,51 :: 		TransmitData = 'O';
	MOVLW       79
	MOVWF       _TransmitData+0 
;bai8_fw.c,52 :: 		UART1_Write(TransmitData);
	MOVLW       79
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,53 :: 		}
L_main7:
;bai8_fw.c,54 :: 		if(LATE0_bit == 1)
	BTFSS       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main8
;bai8_fw.c,56 :: 		TransmitData = 'F';
	MOVLW       70
	MOVWF       _TransmitData+0 
;bai8_fw.c,57 :: 		UART1_Write(TransmitData);
	MOVLW       70
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,58 :: 		}
L_main8:
;bai8_fw.c,60 :: 		if(LATD0_bit == 0 && LATD1_bit == 1)
	BTFSC       LATD0_bit+0, BitPos(LATD0_bit+0) 
	GOTO        L_main11
	BTFSS       LATD1_bit+0, BitPos(LATD1_bit+0) 
	GOTO        L_main11
L__main65:
;bai8_fw.c,62 :: 		LATE1_bit = 0;
	BCF         LATE1_bit+0, BitPos(LATE1_bit+0) 
;bai8_fw.c,63 :: 		}
	GOTO        L_main12
L_main11:
;bai8_fw.c,64 :: 		else { LATE1_bit = 1; }
	BSF         LATE1_bit+0, BitPos(LATE1_bit+0) 
L_main12:
;bai8_fw.c,65 :: 		if(LATE1_bit == 0)
	BTFSC       LATE1_bit+0, BitPos(LATE1_bit+0) 
	GOTO        L_main13
;bai8_fw.c,67 :: 		TransmitData = 'C';
	MOVLW       67
	MOVWF       _TransmitData+0 
;bai8_fw.c,68 :: 		UART1_Write(TransmitData);
	MOVLW       67
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,69 :: 		}
L_main13:
;bai8_fw.c,70 :: 		if(LATE1_bit == 1)
	BTFSS       LATE1_bit+0, BitPos(LATE1_bit+0) 
	GOTO        L_main14
;bai8_fw.c,72 :: 		TransmitData = 'V';
	MOVLW       86
	MOVWF       _TransmitData+0 
;bai8_fw.c,73 :: 		UART1_Write(TransmitData);
	MOVLW       86
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,74 :: 		}
L_main14:
;bai8_fw.c,76 :: 		if(Button(&PORTB,0,10,0))
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
	GOTO        L_main15
;bai8_fw.c,79 :: 		while(Button(&PORTB,0,10,0));
L_main16:
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
	GOTO        L_main17
	GOTO        L_main16
L_main17:
;bai8_fw.c,80 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,81 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,82 :: 		for(i=0;i<17;i++)
	CLRF        main_i_L2+0 
	CLRF        main_i_L2+1 
L_main18:
	MOVLW       128
	XORWF       main_i_L2+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main67
	MOVLW       17
	SUBWF       main_i_L2+0, 0 
L__main67:
	BTFSC       STATUS+0, 0 
	GOTO        L_main19
;bai8_fw.c,84 :: 		LATE0_bit = !LATE0_bit;
	BTG         LATE0_bit+0, BitPos(LATE0_bit+0) 
;bai8_fw.c,85 :: 		delay_ms(300);
	MOVLW       8
	MOVWF       R11, 0
	MOVLW       157
	MOVWF       R12, 0
	MOVLW       5
	MOVWF       R13, 0
L_main21:
	DECFSZ      R13, 1, 1
	BRA         L_main21
	DECFSZ      R12, 1, 1
	BRA         L_main21
	DECFSZ      R11, 1, 1
	BRA         L_main21
	NOP
	NOP
;bai8_fw.c,86 :: 		if(LATE0_bit == 0)
	BTFSC       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main22
;bai8_fw.c,88 :: 		TransmitData = 'O';
	MOVLW       79
	MOVWF       _TransmitData+0 
;bai8_fw.c,89 :: 		UART1_Write(TransmitData);
	MOVLW       79
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,90 :: 		}
L_main22:
;bai8_fw.c,91 :: 		if(LATE0_bit == 1)
	BTFSS       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main23
;bai8_fw.c,93 :: 		TransmitData = 'F';
	MOVLW       70
	MOVWF       _TransmitData+0 
;bai8_fw.c,94 :: 		UART1_Write(TransmitData);
	MOVLW       70
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,95 :: 		}
L_main23:
;bai8_fw.c,96 :: 		TransmitData = 'Q';
	MOVLW       81
	MOVWF       _TransmitData+0 
;bai8_fw.c,97 :: 		UART1_Write(TransmitData);
	MOVLW       81
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,82 :: 		for(i=0;i<17;i++)
	INFSNZ      main_i_L2+0, 1 
	INCF        main_i_L2+1, 1 
;bai8_fw.c,98 :: 		}
	GOTO        L_main18
L_main19:
;bai8_fw.c,99 :: 		TransmitData = 'A';
	MOVLW       65
	MOVWF       _TransmitData+0 
;bai8_fw.c,100 :: 		UART1_Write(TransmitData);
	MOVLW       65
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,101 :: 		LATD0_bit = 0;
	BCF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,102 :: 		LATD1_bit = 0;
	BCF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,103 :: 		}
L_main15:
;bai8_fw.c,104 :: 		if(Button(&PORTB,1,10,0))
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
	GOTO        L_main24
;bai8_fw.c,107 :: 		while(Button(&PORTB,1,10,0));
L_main25:
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
	GOTO        L_main26
	GOTO        L_main25
L_main26:
;bai8_fw.c,108 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,109 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,110 :: 		for(i=0;i<17;i++)
	CLRF        main_i_L2_L2+0 
	CLRF        main_i_L2_L2+1 
L_main27:
	MOVLW       128
	XORWF       main_i_L2_L2+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main68
	MOVLW       17
	SUBWF       main_i_L2_L2+0, 0 
L__main68:
	BTFSC       STATUS+0, 0 
	GOTO        L_main28
;bai8_fw.c,112 :: 		LATE0_bit = !LATE0_bit;
	BTG         LATE0_bit+0, BitPos(LATE0_bit+0) 
;bai8_fw.c,113 :: 		delay_ms(300);
	MOVLW       8
	MOVWF       R11, 0
	MOVLW       157
	MOVWF       R12, 0
	MOVLW       5
	MOVWF       R13, 0
L_main30:
	DECFSZ      R13, 1, 1
	BRA         L_main30
	DECFSZ      R12, 1, 1
	BRA         L_main30
	DECFSZ      R11, 1, 1
	BRA         L_main30
	NOP
	NOP
;bai8_fw.c,114 :: 		if(LATE0_bit == 0)
	BTFSC       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main31
;bai8_fw.c,116 :: 		TransmitData = 'O';
	MOVLW       79
	MOVWF       _TransmitData+0 
;bai8_fw.c,117 :: 		UART1_Write(TransmitData);
	MOVLW       79
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,118 :: 		}
L_main31:
;bai8_fw.c,119 :: 		if(LATE0_bit == 1)
	BTFSS       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main32
;bai8_fw.c,121 :: 		TransmitData = 'F';
	MOVLW       70
	MOVWF       _TransmitData+0 
;bai8_fw.c,122 :: 		UART1_Write(TransmitData);
	MOVLW       70
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,123 :: 		}
L_main32:
;bai8_fw.c,124 :: 		TransmitData = 'W';
	MOVLW       87
	MOVWF       _TransmitData+0 
;bai8_fw.c,125 :: 		UART1_Write(TransmitData);
	MOVLW       87
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,110 :: 		for(i=0;i<17;i++)
	INFSNZ      main_i_L2_L2+0, 1 
	INCF        main_i_L2_L2+1, 1 
;bai8_fw.c,126 :: 		}
	GOTO        L_main27
L_main28:
;bai8_fw.c,127 :: 		TransmitData = 'S';
	MOVLW       83
	MOVWF       _TransmitData+0 
;bai8_fw.c,128 :: 		UART1_Write(TransmitData);
	MOVLW       83
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,129 :: 		LATD0_bit = 0;
	BCF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,130 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,131 :: 		}
L_main24:
;bai8_fw.c,132 :: 		if (Button(&PORTB,2,10,0))
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
	GOTO        L_main33
;bai8_fw.c,134 :: 		while(Button(&PORTB,2,10,0));
L_main34:
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
	GOTO        L_main35
	GOTO        L_main34
L_main35:
;bai8_fw.c,135 :: 		TransmitData = 'D';
	MOVLW       68
	MOVWF       _TransmitData+0 
;bai8_fw.c,136 :: 		UART1_Write(TransmitData);
	MOVLW       68
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,137 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,138 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,139 :: 		}
L_main33:
;bai8_fw.c,140 :: 		if(LATD0_bit == 0 && LATD1_bit == 0)
	BTFSC       LATD0_bit+0, BitPos(LATD0_bit+0) 
	GOTO        L_main38
	BTFSC       LATD1_bit+0, BitPos(LATD1_bit+0) 
	GOTO        L_main38
L__main64:
;bai8_fw.c,142 :: 		if(BUTTON(&PORTC, 0, 10, 0))
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
	GOTO        L_main39
;bai8_fw.c,144 :: 		TransmitData = 'G';
	MOVLW       71
	MOVWF       _TransmitData+0 
;bai8_fw.c,145 :: 		UART1_Write(TransmitData);
	MOVLW       71
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,146 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,147 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,148 :: 		}
L_main39:
;bai8_fw.c,149 :: 		}
	GOTO        L_main40
L_main38:
;bai8_fw.c,152 :: 		if(BUTTON(&PORTC, 2, 10, 0))
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
	GOTO        L_main41
;bai8_fw.c,154 :: 		TransmitData = 'H';
	MOVLW       72
	MOVWF       _TransmitData+0 
;bai8_fw.c,155 :: 		UART1_Write(TransmitData);
	MOVLW       72
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,156 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,157 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,158 :: 		}
L_main41:
;bai8_fw.c,159 :: 		}
L_main40:
;bai8_fw.c,161 :: 		if(UART1_Data_Ready() == 1)
	CALL        _UART1_Data_Ready+0, 0
	MOVF        R0, 0 
	XORLW       1
	BTFSS       STATUS+0, 2 
	GOTO        L_main42
;bai8_fw.c,163 :: 		ReceiveData = UART1_Read();
	CALL        _UART1_Read+0, 0
	MOVF        R0, 0 
	MOVWF       _ReceiveData+0 
;bai8_fw.c,164 :: 		if(ReceiveData == '!')
	MOVF        R0, 0 
	XORLW       33
	BTFSS       STATUS+0, 2 
	GOTO        L_main43
;bai8_fw.c,167 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,168 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,169 :: 		for(i=0;i<17;i++)
	CLRF        main_i_L3+0 
	CLRF        main_i_L3+1 
L_main44:
	MOVLW       128
	XORWF       main_i_L3+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main69
	MOVLW       17
	SUBWF       main_i_L3+0, 0 
L__main69:
	BTFSC       STATUS+0, 0 
	GOTO        L_main45
;bai8_fw.c,171 :: 		LATE0_bit = !LATE0_bit;
	BTG         LATE0_bit+0, BitPos(LATE0_bit+0) 
;bai8_fw.c,172 :: 		delay_ms(300);
	MOVLW       8
	MOVWF       R11, 0
	MOVLW       157
	MOVWF       R12, 0
	MOVLW       5
	MOVWF       R13, 0
L_main47:
	DECFSZ      R13, 1, 1
	BRA         L_main47
	DECFSZ      R12, 1, 1
	BRA         L_main47
	DECFSZ      R11, 1, 1
	BRA         L_main47
	NOP
	NOP
;bai8_fw.c,173 :: 		if(LATE0_bit == 0)
	BTFSC       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main48
;bai8_fw.c,175 :: 		TransmitData = 'O';
	MOVLW       79
	MOVWF       _TransmitData+0 
;bai8_fw.c,176 :: 		UART1_Write(TransmitData);
	MOVLW       79
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,177 :: 		}
L_main48:
;bai8_fw.c,178 :: 		if(LATE0_bit == 1)
	BTFSS       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main49
;bai8_fw.c,180 :: 		TransmitData = 'F';
	MOVLW       70
	MOVWF       _TransmitData+0 
;bai8_fw.c,181 :: 		UART1_Write(TransmitData);
	MOVLW       70
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,182 :: 		}
L_main49:
;bai8_fw.c,169 :: 		for(i=0;i<17;i++)
	INFSNZ      main_i_L3+0, 1 
	INCF        main_i_L3+1, 1 
;bai8_fw.c,183 :: 		}
	GOTO        L_main44
L_main45:
;bai8_fw.c,184 :: 		TransmitData = 'A';
	MOVLW       65
	MOVWF       _TransmitData+0 
;bai8_fw.c,185 :: 		UART1_Write(TransmitData);
	MOVLW       65
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,186 :: 		LATD0_bit = 0;
	BCF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,187 :: 		LATD1_bit = 0;
	BCF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,188 :: 		}
	GOTO        L_main50
L_main43:
;bai8_fw.c,189 :: 		else if(ReceiveData == '@')
	MOVF        _ReceiveData+0, 0 
	XORLW       64
	BTFSS       STATUS+0, 2 
	GOTO        L_main51
;bai8_fw.c,192 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,193 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,194 :: 		for(i=0;i<17;i++)
	CLRF        main_i_L3_L3+0 
	CLRF        main_i_L3_L3+1 
L_main52:
	MOVLW       128
	XORWF       main_i_L3_L3+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main70
	MOVLW       17
	SUBWF       main_i_L3_L3+0, 0 
L__main70:
	BTFSC       STATUS+0, 0 
	GOTO        L_main53
;bai8_fw.c,196 :: 		LATE0_bit = !LATE0_bit;
	BTG         LATE0_bit+0, BitPos(LATE0_bit+0) 
;bai8_fw.c,197 :: 		delay_ms(300);
	MOVLW       8
	MOVWF       R11, 0
	MOVLW       157
	MOVWF       R12, 0
	MOVLW       5
	MOVWF       R13, 0
L_main55:
	DECFSZ      R13, 1, 1
	BRA         L_main55
	DECFSZ      R12, 1, 1
	BRA         L_main55
	DECFSZ      R11, 1, 1
	BRA         L_main55
	NOP
	NOP
;bai8_fw.c,198 :: 		if(LATE0_bit == 0)
	BTFSC       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main56
;bai8_fw.c,200 :: 		TransmitData = 'O';
	MOVLW       79
	MOVWF       _TransmitData+0 
;bai8_fw.c,201 :: 		UART1_Write(TransmitData);
	MOVLW       79
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,202 :: 		}
L_main56:
;bai8_fw.c,203 :: 		if(LATE0_bit == 1)
	BTFSS       LATE0_bit+0, BitPos(LATE0_bit+0) 
	GOTO        L_main57
;bai8_fw.c,205 :: 		TransmitData = 'F';
	MOVLW       70
	MOVWF       _TransmitData+0 
;bai8_fw.c,206 :: 		UART1_Write(TransmitData);
	MOVLW       70
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,207 :: 		}
L_main57:
;bai8_fw.c,194 :: 		for(i=0;i<17;i++)
	INFSNZ      main_i_L3_L3+0, 1 
	INCF        main_i_L3_L3+1, 1 
;bai8_fw.c,208 :: 		}
	GOTO        L_main52
L_main53:
;bai8_fw.c,209 :: 		TransmitData = 'S';
	MOVLW       83
	MOVWF       _TransmitData+0 
;bai8_fw.c,210 :: 		UART1_Write(TransmitData);
	MOVLW       83
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,211 :: 		LATD0_bit = 0;
	BCF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,212 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,213 :: 		}
	GOTO        L_main58
L_main51:
;bai8_fw.c,214 :: 		else if(ReceiveData == '#')
	MOVF        _ReceiveData+0, 0 
	XORLW       35
	BTFSS       STATUS+0, 2 
	GOTO        L_main59
;bai8_fw.c,216 :: 		TransmitData = 'D';
	MOVLW       68
	MOVWF       _TransmitData+0 
;bai8_fw.c,217 :: 		UART1_Write(TransmitData);
	MOVLW       68
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,218 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,219 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,220 :: 		}
	GOTO        L_main60
L_main59:
;bai8_fw.c,221 :: 		else if(ReceiveData == '$')
	MOVF        _ReceiveData+0, 0 
	XORLW       36
	BTFSS       STATUS+0, 2 
	GOTO        L_main61
;bai8_fw.c,223 :: 		TransmitData = 'G';
	MOVLW       71
	MOVWF       _TransmitData+0 
;bai8_fw.c,224 :: 		UART1_Write(TransmitData);
	MOVLW       71
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,225 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,226 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,227 :: 		}
	GOTO        L_main62
L_main61:
;bai8_fw.c,228 :: 		else if(ReceiveData == '%')
	MOVF        _ReceiveData+0, 0 
	XORLW       37
	BTFSS       STATUS+0, 2 
	GOTO        L_main63
;bai8_fw.c,230 :: 		TransmitData = 'H';
	MOVLW       72
	MOVWF       _TransmitData+0 
;bai8_fw.c,231 :: 		UART1_Write(TransmitData);
	MOVLW       72
	MOVWF       FARG_UART1_Write_data_+0 
	CALL        _UART1_Write+0, 0
;bai8_fw.c,232 :: 		LATD0_bit = 1;
	BSF         LATD0_bit+0, BitPos(LATD0_bit+0) 
;bai8_fw.c,233 :: 		LATD1_bit = 1;
	BSF         LATD1_bit+0, BitPos(LATD1_bit+0) 
;bai8_fw.c,234 :: 		}
L_main63:
L_main62:
L_main60:
L_main58:
L_main50:
;bai8_fw.c,235 :: 		}
L_main42:
;bai8_fw.c,236 :: 		}
	GOTO        L_main1
;bai8_fw.c,237 :: 		}
L_end_main:
	GOTO        $+0
; end of _main
