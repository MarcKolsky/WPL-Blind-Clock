   M S B A M L   `   `   `  ����   WPL_Blind_Clock     WPL_Blind_Clock.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  WPL Blind Clock�� � WindowStartupLocation$ CenterScreen=� � ShowInTaskbar .  
���   �$
��1000��$	��600��.��(� .��� $	��985��.+��� -    ��Name$ timer_Label��$��Stretch=�$��133,10,134,496q�$��Stretch=�$	��525��$��Time Remaining�� �� TextAlignment$ Center=�$��40(�
�������$
��Bold"� J� IsHitTestVisible .  ��Z� �� -   $ timerCountdown��$��Stretch=�$	��137��$��230,43,231,390q�$��Stretch=�$	��525��$ Center=�$	��100(�
������� .  �� $��Center=�$	��370��$��354,182,353,0q�$	��Top=�$	��278��$��Images/WPL_Logo.png���� -    ��Name$ 
smallBlind��$
��Left=�$	��151��$��
83,312,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��190��
�������$	��100(�$
��Bold"� �� TextAlignment$ Center=�	 J� 	AllowDrop	 .  |�.   .  ��Z� ��Z� 
 �� SelectionBrush
 Z� �� -   $ bigBlind��$
��Left=�$	��151��$��689,312,0,0q�$
 Wrap=�$	��Top=�$	��245��
�������$	��100(�$
��Bold"�$ Center=�|�.  	 .   .  ��Z� ��Z� 
 Z� �� -   $ smallBlind_Label��$
��Left=�$��69��$��
58,243,0,0q�$
 Wrap=�$��Small Blind��$	��Top=�$	��242��
�������$��40(�$
��Bold"�$ Center=�$��Italic$�	 .  |�.   .  ��Z� ��Z� 
 Z� �� -   $ bigBlind_Label��$
��Left=�$��69��$��689,243,0,0q�$
 Wrap=�$��	Big Blind��$	��Top=�$	��245��
�������$��40(�$
��Bold"�$ Center=�$��Italic$�	 .  |�.   .  ��Z� ��Z� 
 Z�  �� TextDecorations Z� �� -    ��Name$ 
playButton��$�� ��$
��Left=�$��438,530,0,0q�$	��Top=�$��30��$��30��$��20(�$
��Bold"����	#FFA60000���	#FF080808$��1q�|�.  ����  �� ImageSource$ Images/Play.png���� -   $ pauseButton��$�� ��$
��Left=�$��480,530,0,0q�$	��Top=�$��30��$��30��$��20(�$
��Bold"����	#FFA60000
���   �$��1q�|�.  ���� $ Images/Pause.png���� -	   $ replayButton��$�� ��$
��Left=�$��523,530,0,0q�$	��Top=�$��30��$��30��$��20(�$
��Bold"����	#FFA60000
���   �$��1q�|�.  ���� $ Images/Replay.png���� -
   $ 
backButton��$�� ��$
��Left=�$��396,530,0,0q�$	��Top=�$��30��$��30��$��20(�$
��Bold"����	#FFA60000���	#FF080808$��1q�|�.  ���� $ Images/Back.png���� -   $ 
nextButton��$�� ��$
��Left=�$��566,530,0,0q�$	��Top=�$��30��$��30��$��20(�$
��Bold"����	#FFA60000���	#FF080808$��1q�|�.  ���� $ Images/Next.png���� -   $ 
plusButton��$�� ��$
��Left=�$��465,178,0,0q�$	��Top=�$��23��$��23��$��20(�$
��Bold"����	#FFA60000���	#FF080808$��1q�|�.  ���� $ Images/Plus.png���� -   $ minusButton��$�� ��$
��Left=�$��497,178,0,0q�$	��Top=�$��23��$��23��$��20(�$
��Bold"����	#FFA60000���	#FF080808$��1q�|�.  ���� $ Images/Minus.png��