   M S B A M L   `   `   `  ���� Q  MWeightedTeamsGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WeightedTeamsGeneratorWeightedTeamsGenerator  '    !WeightedTeamsGenerator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:WeightedTeamsGenerator     -     �Name$  MainWindow1�� � Title$  Futsal Team Generator v0.2��$��960.5��$	��909�� � 
ResizeMode$ CanMinimize=�.��� $
��1234��$��0,0,-446,-323q�.+�� -   $��progressBarMagic��$y�Hidden=�$
��Left=�$��10��$��750,167,0,0q�$	��Top=�$	��100�� � Value$ 23Q� � IsIndeterminate . �� $��10,10,648,322q�$��Images/futsal_pitch.png��$
��Fill=�A� -    A�Name$ Team2Player1��$��169,503,1063,619q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ����  �� ImageSource$  Images/Players/unknown.jpg���� -   $��Team2Player1Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��169,620,0,0q�$	��Top=�
�������A� -   $��Team2Player2��$��448,503,784,620q�   ���� $  Images/Players/unknown.jpg���� -   $��Team2Player2Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��454,619,0,0q�$	��Top=�
�������A� -   $��Team2Player3��$��165,656,1068,472q�   ���� $  Images/Players/unknown.jpg���� -   $��Team2Player3Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��165,767,0,0q�$	��Top=�
�������A� -	   $��Team2Player4��$��448,650,784,472q�   ���� $  Images/Players/unknown.jpg���� -
   $��Team2Player4Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��454,767,0,0q�$	��Top=�
�������A� -   $��Team2Player5��$��295,758,947,371q�   ���� $  Images/Players/unknown.jpg���� -    ��Name$ Team2Player5Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��294,863,0,0q�$	��Top=�
�������A� -   $ Team2Player6��$y�Hidden=�$��619,686,650,472q�   ���� $  Images/Players/unknown.jpg���� -   $ Team2Player6Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��591,767,0,0q�$	��Top=�
�������A� -   $ Team2Player7��$y�Hidden=�$��619,793,650,365q�   ���� $  Images/Players/unknown.jpg���� -   $ Team2Player7Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��590,869,0,0q�$	��Top=�
��������� -   $ team1LabelValue��$y�Hidden=�$��?��$
��Left=�$��326,422,0,0q�$	��Top=�$��22(�$��Impact)�
�������   	   
BlurRadius$	 8Q�
   	Direction$	
 325Q��� -   $��team2LabelValue��$y�Hidden=�$��?��$
��Left=�$��326,470,0,0q�$	��Top=�$��22(�$��Impact)�
�������   $	 8Q�$	
 325Q��� -    ��Name$ loadPlayersDataButton��$��Load players data��$
��Left=�$��
725,39,0,0q�$	��Top=�$	��151��$��60���� -   $ magicButton��$��Magic()��$
��Left=�$��725,107,0,0q�$	��Top=�$	��151��$��60���� -   $ revealTeam1Button��$y�Hidden=�$��Reveal Team 1��$
��Left=�$��725,232,0,0q�$	��Top=�$	��151��$��60���� -   $ revealTeam2Button��$y�Hidden=�$��Reveal Team 2��$
��Left=�$��725,299,0,0q�$	��Top=�$	��151��$��60���� -   $ nextSuggestionButton��$y�Hidden=�$��Next suggestion��$
��Left=�$��725,445,0,0q�$	��Top=�$	��151��$��60���� -   $ firstSuggestionButton��$y�Hidden=�$��First suggestion��$
��Left=�$��726,515,0,0q�$	��Top=�$	��151��$��60���� -   $ increaseDifferenceButton��$y�Hidden=�$��Increase difference��$
��Left=�$��726,584,0,0q�$	��Top=�$	��151��$��60���� -   $ decreaseDifferenceButton��$y�Hidden=�$��Decrease difference��$
��Left=�$��726,651,0,0q�$	��Top=�$	��151��$��60���� -   $��differenceCurrentLabel��$y�Hidden=�$��Difference: ��$
��Left=�$��726,384,0,0q�$	��Top=��� -   $��numberOfSuggestionsLabel��$y�Hidden=�$��Number of suggestions: ��$
��Left=�$��726,409,0,0q�$	��Top=�A� -   $ Team1Player1��$��165,298,1067,824q�   ���� $  Images/Players/unknown.jpg���� -   $ Team1Player1Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��165,410,0,0q�$	��Top=�
�������A� -   $ Team1Player2��$��444,299,788,824q�   ���� $  Images/Players/unknown.jpg���� -    $ Team1Player2Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��448,409,0,0q�$	��Top=�
�������A� -!   $ Team1Player3��$��164,143,1069,985q�   ���� $  Images/Players/unknown.jpg���� -"   $ Team1Player3Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��169,255,0,0q�$	��Top=�
�������A� -#   $ Team1Player4��$��442,143,790,979q�   ���� $  Images/Players/unknown.jpg���� -$   $ Team1Player4Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��448,255,0,0q�$	��Top=�
�������A� -%   $ Team1Player5��$��294,51,944,1078q�   ���� $  Images/Players/unknown.jpg���� -&   $ Team1Player5Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��290,157,0,0q�$	��Top=�
�������A� -'   $ Team1Player6��$y�Hidden=�$��622,153,647,1005q�   ���� $  Images/Players/unknown.jpg���� -(   $ Team1Player6Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��590,229,0,0q�$	��Top=�
�������A� -)   $ Team1Player7��$y�Hidden=�$��622,39,647,1119q�   ���� $  Images/Players/unknown.jpg���� -*   $ Team1Player7Label��$y�Hidden=�$��Team1Player1Label��$
��Left=�$��590,118,0,0q�$	��Top=�
�������