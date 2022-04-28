char TransmitData, ReceiveData;
void main()
{
   ADCON1 |= 0x0F;
   CMCON |= 7;

   PORTB = 0x00;
   LATB = 0x00;
   TRISC0_bit = 1;
   TRISC1_bit = 1;
   TRISC2_bit = 1;

   TRISB0_bit = 1;
   TRISB1_bit = 1;
   TRISB2_bit = 1;

   PORTD = 0x00;
   LATD = 0x00;
   LATD0_bit = 1;
   LATD1_bit = 1;
   LATD2_bit = 1;
   LATD3_bit = 1;

   TRISD0_bit = 0;
   TRISD1_bit = 0;
   TRISD2_bit = 0;
   TRISD3_bit = 0;

   TRISE0_bit = 0;
   LATE0_bit = 1;
   TRISE1_bit = 0;
   LATE1_bit = 1;

  UART1_Init(9600);
  delay_ms(100);

  while(1)
  {
    //den warning
    if(LATD0_bit == 0)
    {
        LATE0_bit = !LATE0_bit;
        delay_ms(300);
    }
    else if(LATD0_bit == 1)
    {
       LATE0_bit = 1;
    }
    if(LATE0_bit == 0)
    {
      TransmitData = 'O';
      UART1_Write(TransmitData);
    }
    if(LATE0_bit == 1)
    {
      TransmitData = 'F';
      UART1_Write(TransmitData);
    }
    //thanh chan
    if(LATD0_bit == 0 && LATD1_bit == 1)
    {
      LATE1_bit = 0;
    }
    else { LATE1_bit = 1; }
    if(LATE1_bit == 0)
    {
      TransmitData = 'C';
      UART1_Write(TransmitData);
    }
    if(LATE1_bit == 1)
    {
      TransmitData = 'V';
      UART1_Write(TransmitData);
    }
    //nhan dieu khien
    if(Button(&PORTB,0,10,0))
    {
         int i;
         while(Button(&PORTB,0,10,0));
         LATD0_bit = 1;
         LATD1_bit = 1;
         for(i=0;i<17;i++)
         {
           LATE0_bit = !LATE0_bit;
           delay_ms(300);
           if(LATE0_bit == 0)
           {
              TransmitData = 'O';
              UART1_Write(TransmitData);
           }
           if(LATE0_bit == 1)
           {
              TransmitData = 'F';
              UART1_Write(TransmitData);
           }
           TransmitData = 'Q';
           UART1_Write(TransmitData);
         }
         TransmitData = 'A';
         UART1_Write(TransmitData);
         LATD0_bit = 0;
         LATD1_bit = 0;
    }
    if(Button(&PORTB,1,10,0))
    {
         int i;
         while(Button(&PORTB,1,10,0));
         LATD0_bit = 1;
         LATD1_bit = 1;
         for(i=0;i<17;i++)
         {
           LATE0_bit = !LATE0_bit;
           delay_ms(300);
           if(LATE0_bit == 0)
           {
              TransmitData = 'O';
              UART1_Write(TransmitData);
           }
           if(LATE0_bit == 1)
           {
              TransmitData = 'F';
              UART1_Write(TransmitData);
           }
           TransmitData = 'W';
           UART1_Write(TransmitData);
         }
         TransmitData = 'S';
         UART1_Write(TransmitData);
         LATD0_bit = 0;
         LATD1_bit = 1;
    }
    if (Button(&PORTB,2,10,0))
    {
         while(Button(&PORTB,2,10,0));
         TransmitData = 'D';
         UART1_Write(TransmitData);
         LATD0_bit = 1;
         LATD1_bit = 1;
    }
    if(LATD0_bit == 0 && LATD1_bit == 0)
    {
        if(BUTTON(&PORTC, 0, 10, 0))
        {
          TransmitData = 'G';
          UART1_Write(TransmitData);
          LATD0_bit = 1;
          LATD1_bit = 1;
        }
    }
    else
    {
        if(BUTTON(&PORTC, 2, 10, 0))
        {
          TransmitData = 'H';
          UART1_Write(TransmitData);
          LATD0_bit = 1;
          LATD1_bit = 1;
        }
    }
    if(UART1_Data_Ready() == 1)
    {
      ReceiveData = UART1_Read();
      if(ReceiveData == '!')
      {
        int i;
        LATD0_bit = 1;
        LATD1_bit = 1;
        for(i=0;i<17;i++)
        {
          LATE0_bit = !LATE0_bit;
          delay_ms(300);
          if(LATE0_bit == 0)
          {
              TransmitData = 'O';
              UART1_Write(TransmitData);
          }
           if(LATE0_bit == 1)
          {
              TransmitData = 'F';
              UART1_Write(TransmitData);
          }
        }
        TransmitData = 'A';
        UART1_Write(TransmitData);
        LATD0_bit = 0;
        LATD1_bit = 0;
      }
      else if(ReceiveData == '@')
      {
        int i;
        LATD0_bit = 1;
        LATD1_bit = 1;
        for(i=0;i<17;i++)
        {
          LATE0_bit = !LATE0_bit;
          delay_ms(300);
          if(LATE0_bit == 0)
          {
              TransmitData = 'O';
              UART1_Write(TransmitData);
          }
           if(LATE0_bit == 1)
          {
              TransmitData = 'F';
              UART1_Write(TransmitData);
          }
        }
        TransmitData = 'S';
        UART1_Write(TransmitData);
        LATD0_bit = 0;
        LATD1_bit = 1;
      }
      else if(ReceiveData == '#')
      {
        TransmitData = 'D';
        UART1_Write(TransmitData);
        LATD0_bit = 1;
        LATD1_bit = 1;
      }
      else if(ReceiveData == '$')
      {
        TransmitData = 'G';
        UART1_Write(TransmitData);
        LATD0_bit = 1;
        LATD1_bit = 1;
      }
      else if(ReceiveData == '%')
      {
        TransmitData = 'H';
        UART1_Write(TransmitData);
        LATD0_bit = 1;
        LATD1_bit = 1;
      }
    }
  }
}