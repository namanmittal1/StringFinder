   M S B A M L   `   `   `  ����G  CStringFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:StringFinderStringFinder  5   	       StringFinder.DataViewer   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   *localclr-namespace:StringFinder    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
DataViewer��5   	   $	��330��6   $	��645��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K    � 	Resources 5       �� Source�� 5	   
   $$ /GlobalResourceDictionary.xaml?�6   %    .��5   
   � .+�5      �� $
��Left=�6   $	��290��5      $��0,0,0,0q�5      $	��Top=�5      .@�5      ��    TabItemStyle#��[  6@    � DataContext 6   ��  �� Path$ TextInstance���5      �� 5       �� Orientation$ 
Horizontal=�6!   .+�5      �� $��
Text File ��6$   �� 5      ��6$   �� *SearchCount+5      .��5      �� $��Visible=�6   $��Visible=�6G   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5       �� 5!   "   $
��Auto �63   .+�5$      �� 	 � Cursor$
	 Hand��6�   
 �� SelectedItem
 6#   �� $ SelectedListItem� �� Mode$ OneWayToSource=���6f   �� $ TestData� �� UpdateSourceTrigger$ PropertyChanged=� �� View 5%      �� 5'   "   .P�5(   &   �� $
��File��65    �� Width$	 220��6C    �� DisplayMemberBinding 6O   �� *FilenameList+�� 5)   &   $
��Line��65   $ 50��6C    6N   �� *Linenumber_List+�� 5*   &   $��Column��65   $ 60��6E    6P   �� *Position_List+�� 5+   &   $
��Data��65   $	 270��6C    6O   �� *Data_String+5-   #   5/      50      51      52      �� 55      #��[  6A    6   �� $ ExcelInstance���56      �� 57      $ 
Horizontal=�6!   .+�58      �� $��Excel File ��6$   �� 59      ��6$   �� *SearchCount+5:      .��5<      �� $��Visible=�6   $��Visible=�6G   .��5=      � ���	#FFE5E5E5 5>      �� 5?      $
��Auto �6/   .+�5B      �� $
	 Hand��6�   
 6$   �� $ SelectedListItem�$ OneWayToSource=���6g   �� $ 	ExcelData�$ PropertyChanged=� 5C      �� 5E   "   .P�5F   &   �� $
��File��65   $	 220��6C    6O   �� *FilenameList+�� 5G   &   $	��Row��65   $ 50��6B    6M   �� *Linenumber_List+�� 5H   &   $��Column��65   $ 60��6E    6P   �� *Position_List+�� 5I   &   $
��Data��65   $	 270��6C    6O   �� *Data_String+5K   #   5M      5N      5O      5P      �� 5S      #��[  6?    6   �� $ PDFInstance���5T      �� 5U      $ 
Horizontal=�6!   .+�5V      �� $��	PDF File ��6$   �� 5W      ��6$   �� *SearchCount+5X      .��5Z      �� $��Visible=�6   $��Visible=�6G   .��5[      � ���	#FFE5E5E5 5\      �� 5]      $
��Auto �6/   .+�5`      �� $
	 Hand��6�   
 6#   �� $ SelectedListItem�$ OneWayToSource=���6f   �� $ PDFData�$ PropertyChanged=� 5a      �� 5c   "   .P�5d   &   �� $
��File��65   $	 220��6C    6O   �� *FilenameList+�� 5e   &   $��X��65   $ 50��6@    6K   �� *Linenumber_List+�� 5f   &   $��Y��65   $ 60��6@    6K   �� *Position_List+�� 5g   &   $
��Data��65   $	 270��6C    6O   �� *Data_String+5i   #   5k      5l      5m      5n      �� 5q      #��[  6@    6   �� $ WordInstance���5r      �� 5s      $ 
Horizontal=�6!   .+�5t      �� $��
Word File ��6$   �� 5u      ��6$   �� *SearchCount+5v      .��5x      �� $��Visible=�6   $��Visible=�6G   .��5y      � ���	#FFE5E5E5 5z      �� 5{      $
��Auto �6/   .+�5~      �� $
	 Hand��6�   
 6#   �� $ SelectedListItem�$ OneWayToSource=���6f   �� $ WordData�$ PropertyChanged=� 5      �� 5�   "   .P�5�   &   �� $
��File��65   $	 220��6C    6O   �� *FilenameList+�� 5�   &   $
��Page��65   $ 60��6C    6N   �� *Page_Number+�� 5�   &   $
��Line��65   $ 50��6C    6N   �� *
Para_Num+�� 5�   &   $
��Data��65   $	 270��6C    6O   �� *Data_String+5�   #   5�      5�      5�      5�      �� 5�      #��[  6?    6   �� $ XMLInstance���5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��	XML File ��6$   �� 5�      ��6$   �� *SearchCount+5�      .��5�      �� $��Visible=�6   $��Visible=�6G   .��5�      � ���	#FFE5E5E5 5�      �� 5�      $
��Auto �6/   .+�5�      �� $
	 Hand��6�   
 6#   �� $ SelectedListItem�$ OneWayToSource=���6f   �� $ XMLData�$ PropertyChanged=� 5�      �� 5�   "   .P�5�   &   �� $
��File��65   $	 220��6C    6O   �� *FilenameList+�� 5�   &   $
��Line��65   $ 50��6C    6N   �� *Linenumber_List+�� 5�   &   $��Column��65   $ 60��6E    6P   �� *Position_List+�� 5�   &   $
��Data��65   $	 270��6C    6O   �� *Data_String+5�   #   5�      5�      5�      5�      5�      5�      5�      