   M S B A M L   `   `   `  ����  StringFinder    StringFinder.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��240��6   $	��520��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K    � 	Resources 5       �� Source�� 5   
   $$ /GlobalResourceDictionary.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $��90 �6   6*   �� 5      $��40 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��350 �6   6-   �� 5      $��* �6   6+   ��5   
   �� 5       �� ImageSource$ 
search.jpg��6   64   .+�5   
   �� $��Arial)�6   $��24(�6#   $
��Bold"�61   $��Center=�6C   $��2��6`   .��6t   String Finder6�   �� 5   
   $��Arial)�6   $��15(�6#   $
��Bold"�61   $��
10,50,5,20q�6C   $��0��6X   $��0��6e   .��6u   Browse Folder6�   �� 5   
   $��120,45,5,15q�6   $��0��6'   $��0��64      	textBoxes#��[  6D    �� 
IsReadOnly . ��6g   �� *
FolderName+	 �� Mode$	 OneWay=�
 �� ValidatesOnDataErrors
 . 6�   �� 5   
   $��0��6   $��1��6   $��22,45,80,15q�6.   $
��Bold"�6C     browseButton#��[ 6U   ��6{   �� *BrowseCommand+.��6�   . . .6�   �� 5!   
   $��Arial)�6   $��15(�6#   $
��Bold"�61   $��82,10,10,10q�6C   $��1��6Y   $��0��6f   .��6v   Text6|   �� 5"   
   $��	121,5,5,5q�6   $��1��6%   $��0��62   #��[  6B   ��6e   �� *SearchString+$	 OneWayToSource=� �� UpdateSourceTrigger$ 	LostFocus=�
 . 6�   �� 5#   
   $��1��6   $��1��6   $��	22,5,80,5q�6.     searchButton#��[ 6A   ��6g   �� *SearchCommand+5$      �� 5&   
   $��Arial)�6   $��15(�6#   $
��Bold"�61   $��76,10,10,10q�6C   $��2��6Y   $��0��6f   .��6v   Mode6|   �� 5'   
   $��Ignore Case��6   $��2��6�   $��121,10,20,20q�6�   $��Arial)�6�   $��13(�6�   $��DemiBold"�6�   $	��8,0q�6�   ��6)   �� *CheckCommand+$	 TwoWay=� d� 	IsChecked 6W   ��  �� Path$ IgnoreCaseSelected�$	 TwoWay=�6�   �� 5(   
   $��Match Exact Content��6   $��2��6�   $��230,10,20,20q�6�   $��Arial)�6�   $��13(�6�   $��DemiBold"�6�   $	��8,0q�6   $��2��6  ��61   �� *CheckCommand+$	 TwoWay=� 6_   �� $$ MatchEntireCellContentSelected�$	 TwoWay=�6$  � 5)   
     ProgressBar#��[ 6   $��2��6�   $��2��6�   $��50,40,70,10q�6�    � Minimum$ 1Q�6�    � Maximum$	 100Q�6�    � Value 6;   �� *CurrentProgress+$	 OneWay=�$ PropertyChanged=�6�   5*      5+      