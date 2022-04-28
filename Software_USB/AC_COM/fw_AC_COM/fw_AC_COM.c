char TransmitData, ReceiveData;
void main()
{
  ADCON1 |= 0x0F;
  CMCON |= 0x07;
  PORTC = 0x00; LATC = 0x00;
  TRISC0_bit = 1;
  TRISC1_bit = 1;
  TRISC2_bit = 1;
  PORTB = 0x00; LATB = 0x00;
  TRISB0_bit = 1;
  TRISB1_bit = 1;
  TRISB2_bit = 1;
  PORTE = 0x00; LATE = 0x00;
  TRISE0_bit = 0;
  LATE0_bit = 1;
  TRISE1_bit = 0;
  LATE1_bit = 1;
  TRISE2_bit = 0;
  LATE2_bit = 1;
  PORTD = 0x00; LATD = 0x00;
  TRISD0_bit = 0;
  LATD0_bit = 1;
  TRISD1_bit = 0;
  LATD1_bit = 1;
  TRISD2_bit = 0;
  LATD2_bit = 1;
  TRISD3_bit = 0;
  LATD3_bit = 1;

  UART1_Init(9600);
  delay_ms(100);

  while(1)
  {
    if(Button(&PORTB,0,10,0))
    {
       TransmitData = 'A';
       UART1_Write(TransmitData);
    }
    else if(Button(&PORTB,0,10,1))
    {
       TransmitData = 'S';
       UART1_Write(TransmitData);
    }
    if(Button(&PORTB,1,10,0))
    {
       TransmitData = 'D';
       UART1_Write(TransmitData);
    }
    else if(Button(&PORTB,1,10,1))
    {
       TransmitData = 'F';
       UART1_Write(TransmitData);
    }
    if(Button(&PORTB,2,10,0))
    {
       TransmitData = 'G';
       UART1_Write(TransmitData);
    }
    else if(Button(&PORTB,2,10,1))
    {
       TransmitData = 'H';
       UART1_Write(TransmitData);
    }
    if(Button(&PORTC,0,10,0))
    {
       TransmitData = '1';
       UART1_Write(TransmitData);
    }
    else if(Button(&PORTC,0,10,1))
    {
       TransmitData = '2';
       UART1_Write(TransmitData);
    }
    if(Button(&PORTC,1,10,0))
    {
       TransmitData = '3';
       UART1_Write(TransmitData);
    }
    else if(Button(&PORTC,1,10,1))
    {
       TransmitData = '4';
       UART1_Write(TransmitData);
    }
    if(Button(&PORTC,2,10,0))
    {
       TransmitData = '5';
       UART1_Write(TransmitData);
    }
    else if(Button(&PORTC,2,10,1))
    {
       TransmitData = '6';
       UART1_Write(TransmitData);
    }
    if(UART1_Data_Ready() == 1)
    {
       ReceiveData = UART1_Read();
       if(ReceiveData == '!')
       {
          LATE0_bit = 0;
          TransmitData = 'q';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '@')
       {
          LATE0_bit = 1;
          TransmitData = 'w';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '#')
       {
          LATE1_bit = 0;
          TransmitData = 'e';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '$')
       {
          LATE1_bit = 1;
          TransmitData = 'r';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '%')
       {
          LATE2_bit = 0;
          TransmitData = 't';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '^')
       {
          LATE2_bit = 1;
          TransmitData = 'y';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '&')
       {
          LATD0_bit = 0;
          TransmitData = 'z';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '*')
       {
          LATD0_bit = 1;
          TransmitData = 'x';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '(')
       {
          LATD1_bit = 0;
          TransmitData = 'c';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == ')')
       {
          LATD1_bit = 1;
          TransmitData = 'v';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '_')
       {
          LATD2_bit = 0;
          TransmitData = 'b';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '+')
       {
          LATD2_bit = 1;
          TransmitData = 'n';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '<')
       {
          LATD3_bit = 0;
          TransmitData = 'm';
          UART1_Write(TransmitData);
       }
       else if(ReceiveData == '>')
       {
          LATD3_bit = 1;
          TransmitData = 'l';
          UART1_Write(TransmitData);
       }
    }
  }

}